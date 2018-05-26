using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class frmDescuento : Form
    {

        private bool isNuevo = false;
        private bool IsEditar = false;

        private string tipo;
        public frmDescuento()
        {
            InitializeComponent();
          
        }
        private void Limpiar()
        {

            this.txtPorcentaje.Text = string.Empty;

            this.cbAplicar.SelectedIndex = -1;
            this.cbProducto.SelectedIndex = -1;

        }

        private void Habilitar(bool valor)
        {
            this.cbAplicar.Enabled = valor;
            this.cbProducto.Enabled = valor;
            //this.cbTipoIngreso.SelectedIndex = 0;
            //this.cbAlmacen.SelectedIndex = 0;
            this.txtPorcentaje.ReadOnly = !valor;

        }

        private void MostrarDescuentoCategoria()
        {
            this.dataListado.DataSource = NDescuento.MostrarDescuentoCategoria();

            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
            }
            else
            {
                this.dataListado.Visible = true;
                // this.ocultarColumnas();
            }
        }

        private void MostrarDescuentoProducto()
        {
            this.dataListado.DataSource = NDescuento.MostrarDescuentoProducto();

            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
            }
            else
            {
                this.dataListado.Visible = true;
                // this.ocultarColumnas();
            }
        }

        private void frmDescuento_Load(object sender, EventArgs e)
        {
            this.Left = 0;
            this.Top = 0;
            Botones();
            Habilitar(false);

            this.dataListado.Columns[0].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void ocultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[5].Visible = false;
            this.dataListado.Columns[6].Visible = false;


            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[1].Width = 70;
            this.dataListado.Columns[2].Width = 389;
            this.dataListado.Columns[3].Width = 150;
            this.dataListado.Columns[4].Width = 80;

            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }

        private void Botones()
        {
            if (this.isNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnEliminar.Enabled = false;
                this.btnCancelar.Enabled = true;
                this.btnDesactivar.Enabled = false;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnEliminar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.btnDesactivar.Enabled = false;
            }
        }

        private void Guardar()
        {
            if (this.cbAplicar.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de descuento");
            }
            else if (this.cbProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el producto o categoria");
            }
            else if (this.txtPorcentaje.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el porcetaje de Descuento");
            }
            else
            {
                try
                {
                    string rpta = "";
                    decimal porcentaje = Convert.ToDecimal(this.txtPorcentaje.Text.Trim());
                    int idProducto = Convert.ToInt32(this.cbProducto.SelectedValue.ToString());
                    if (this.isNuevo)
                    {
                        rpta = NDescuento.Insertar(idProducto, tipo, porcentaje, "A");
                        if (tipo == "C")
                        {
                            rbCategoria.Checked = true;
                            MostrarDescuentoCategoria();
                        }
                        else if (tipo == "P")
                        {
                            rbTodos.Checked = true;
                            MostrarDescuentoProducto();
                        }

                    }
                    else
                    {
                        rpta = NDescuento.Editar(Convert.ToInt32(this.txtIdDescuento.Text), Convert.ToInt32(cbProducto.SelectedValue), Convert.ToDecimal(this.txtPorcentaje.Text.Trim()), "A");

                        if (rbCategoria.Checked == true)
                        {
                            MostrarDescuentoCategoria();
                        }
                        else if (rbTodos.Checked == true)
                        {
                            MostrarDescuentoProducto();
                        }
                        this.dataListado.ClearSelection();
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.isNuevo)
                        {
                            MessageBox.Show("Se insertó correctamente");
                            this.dataListado.ClearSelection();
                        }
                        else
                        {
                            MessageBox.Show("Se actualizó correctamente");
                            this.dataListado.ClearSelection();
                        }

                        this.isNuevo = false;
                        Habilitar(false);
                    }
                    else
                    {
                        MessageBox.Show(rpta);
                        Habilitar(false);

                    }

                    this.Botones();
                    this.Limpiar();

                    this.txtPorcentaje.ReadOnly = true;
                    Habilitar(false);

                    this.tbInfo.SelectedIndex = 0;
                    this.dataListado.Columns[0].Visible = false;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.isNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.tbInfo.SelectedIndex = 1;
            this.cbAplicar.Select();
            this.txtIdDescuento.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.isNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.tbInfo.SelectedIndex = 0;
            this.dataListado.ClearSelection();
        }

        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (this.btnGuardar.Enabled == true)
                {
                    this.Guardar();
                }

            }

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            if (!(char.IsNumber(e.KeyChar)) && !(e.KeyChar == '.'))
            {
                e.Handled = true;
                return;
            }
            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtPorcentaje.Text.Length; i++)
            {
                if (txtPorcentaje.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }
        private void cargarCategoria()
        {
            cbProducto.DataSource = NCategoria.Mostrar();
            cbProducto.ValueMember = "Codigo";
            cbProducto.DisplayMember = "Categoria";
            cbProducto.SelectedIndex = -1;
        }

        private void cargarProducto()
        {
            cbProducto.DataSource = NProducto.MostrarProductoDescuento();
            cbProducto.ValueMember = "Codigo";
            cbProducto.DisplayMember = "Nombre";
            cbProducto.SelectedIndex = -1;
        }

        private void cbAplicar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAplicar.SelectedIndex == 1)
            {
                tipo = "C";
                cargarCategoria();

            }
            else if (cbAplicar.SelectedIndex == 0)
            {
                tipo = "P";
                cargarProducto();

            }
        }

        private void rbCategoria_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCategoria.Checked == true)
            {
                this.MostrarDescuentoCategoria();
                ocultarColumnas();

            }
            else if (rbTodos.Checked == true)
            {
                this.MostrarDescuentoProducto();
                ocultarColumnas();

            }
            this.btnEditar.Enabled = false;
            this.btnDesactivar.Enabled = false;
            this.btnCancelar.Enabled = false;
        }

        private void dataListado_Click(object sender, EventArgs e)
        {
            if (this.isNuevo)
            {
                this.Habilitar(false);
                this.btnGuardar.Enabled = false;
            }
            this.btnEditar.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.btnDesactivar.Enabled = true;
            string tipo, estado;
            string idCategoria;
            tipo = Convert.ToString(this.dataListado.CurrentRow.Cells["Tipo"].Value);
            estado = Convert.ToString(this.dataListado.CurrentRow.Cells["Estado"].Value);
            txtIdDescuento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            idCategoria = Convert.ToString(this.dataListado.CurrentRow.Cells["Cod"].Value);

            if (tipo == "C")
            {
                cbAplicar.SelectedIndex = 1;
                cargarCategoria();
                cbProducto.SelectedValue = idCategoria;

            }
            else if (tipo == "P")
            {
                cbAplicar.SelectedIndex = 0;
                cargarProducto();
                cbProducto.SelectedValue = idCategoria;
            }

            if (estado == "A")
            {
                this.btnDesactivar.Text = "Desactivar";
            }
            else
            {
                this.btnDesactivar.Text = "Activar";
            }

            this.txtPorcentaje.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Porcentaje"].Value);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdDescuento.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
                cbAplicar.Enabled = false;
                this.tbInfo.SelectedIndex = 1;

            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }

        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCategoria.Checked == true)
            {
                this.MostrarDescuentoCategoria();
                ocultarColumnas();
            }
            else if (rbTodos.Checked == true)
            {
                this.MostrarDescuentoProducto();
                ocultarColumnas();
            }
            this.btnEditar.Enabled = false;
            this.btnDesactivar.Enabled = false;
            this.btnCancelar.Enabled = false;
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (this.btnDesactivar.Text == "Desactivar")
            {
                string rpta;
                rpta = NDescuento.Editar(Convert.ToInt32(this.txtIdDescuento.Text), Convert.ToInt32(cbProducto.SelectedValue), Convert.ToDecimal(this.txtPorcentaje.Text.Trim()), "I");
                if (rpta == "OK")
                {
                    MessageBox.Show("Se desactivó el descuento");
                    if (tipo == "C")
                    {
                        dataListado.ClearSelection();
                        MostrarDescuentoCategoria();
                        Habilitar(false);
                        this.dataListado.ClearSelection();

                    }
                    else if (tipo == "P")
                    {
                        dataListado.ClearSelection();
                        MostrarDescuentoProducto();
                        Habilitar(false);
                        this.dataListado.ClearSelection();
                    }
                }

            }
            else
            {
                string rpta;
                rpta = NDescuento.Editar(Convert.ToInt32(this.txtIdDescuento.Text), Convert.ToInt32(cbProducto.SelectedValue), Convert.ToDecimal(this.txtPorcentaje.Text.Trim()), "A");
                if (rpta == "OK")
                {
                    MessageBox.Show("Se activó el descuento");
                    if (tipo == "C")
                    {
                        dataListado.ClearSelection();
                        MostrarDescuentoCategoria();
                        Habilitar(false);
                        this.dataListado.ClearSelection();
                    }
                    else if (tipo == "P")
                    {
                        dataListado.ClearSelection();
                        MostrarDescuentoProducto();
                        Habilitar(false);
                        this.dataListado.ClearSelection();
                    }
                }
            }
        }

        private void cbEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.btnEliminar.Enabled = false;
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Está seguro de eliminar los registros?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (opcion == DialogResult.OK)
                {
                    string codigo;
                    string rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToString(row.Cells[1].Value);
                            rpta = NDescuento.Eliminar(Convert.ToInt32(codigo));
                        }

                    }

                    if (rpta.Equals("OK"))
                    {
                        MessageBox.Show("Se eliminó correctamente el registro");
                        cbEliminar.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show(rpta);
                    }

                    if (tipo == "C")
                    {
                        MostrarDescuentoCategoria();
                    }
                    else if (tipo == "P")
                    {
                        MostrarDescuentoProducto();
                    }

                    this.Limpiar();
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnDesactivar.Enabled = false;
                    this.btnGuardar.Enabled = false;
                    this.btnNuevo.Enabled = true;
                    ocultarColumnas();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                this.btnEliminar.Enabled = true;
                this.btnCancelar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnNuevo.Enabled = false;
                DataGridViewCheckBoxCell cbEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                cbEliminar.Value = !Convert.ToBoolean(cbEliminar.Value);
            }
        }
    }
}
