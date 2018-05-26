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
    public partial class frmInsumo : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public frmInsumo()
        {
            InitializeComponent();
        }

        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar
        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtStockMinimo.Text = string.Empty;
            this.txtIdInsumo.Text = string.Empty;

            this.cbUnidad.SelectedIndex = -1;
        }

        //Habilitar Controles
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.cbUnidad.Enabled = valor;
            this.txtStockMinimo.ReadOnly = !valor;

        }

        //Habilitar Botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
                this.btnEliminar.Enabled = false;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.btnEliminar.Enabled = false;
            }
        }

        private void ocultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            //this.dataListado.Columns[6].Visible = false;
            //this.dataListado.Columns[7].Visible = false;
            this.dataListado.Columns[9].Visible = false;
            this.dataListado.Columns[10].Visible = false;
            this.dataListado.Columns[11].Visible = false;
            this.dataListado.Columns[12].Visible = false;
            this.dataListado.Columns[13].Visible = false;
            //this.dataListado.Columns[14].Visible = false;
            //this.dataListado.Columns[4].Visible = false;


            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[1].Width = 100;
            this.dataListado.Columns[3].Width = 414;
            this.dataListado.Columns[4].Width = 465;
            this.dataListado.Columns[2].Width = 212;

            // this.dataListado.Columns[7].Width = 120;

            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            this.dataListado.RowsDefaultCellStyle.BackColor = Color.White;
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NInsumo.Mostrar();
            
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
            }
            else
            {
                this.dataListado.Visible = true;
                this.ocultarColumnas();
                this.dataListado.ClearSelection();
            }
        }

        private void Buscar()
        {
            this.dataListado.DataSource = NInsumo.Buscar(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void cargarUnidadMedida()
        {
            cbUnidad.DataSource = NUnidadMedida.Mostrar();
            cbUnidad.ValueMember = "Codigo";
            cbUnidad.DisplayMember = "Unidad_Medida";
            cbUnidad.SelectedIndex = -1;
            //lblPrueba.Text = cbCategoria.SelectedValue.ToString();

        }



        private void Guardar()
        {
            try
            {
                string rpta = "";
                decimal costo = 00.00m;

                if (this.cbUnidad.SelectedIndex == -1)
                {
                    MensajeError("Seleccione una unidad");
                    errorIcono.SetError(cbUnidad, "Seleccionar unidad");
                }
                
                else if (this.txtNombre.Text.Trim() == string.Empty)
                {
                    MensajeError("Ingrese el nombre del insumo");
                    errorIcono.SetError(txtNombre, "Ingrese el nombre");
                }
                else if (this.txtCosto.Text.Trim() == string.Empty)
                {
                    MensajeError("Ingrese el costo del insumo");
                    errorIcono.SetError(txtCosto, "Ingrese el costo");
                }
                else
                {
                    decimal stockMinimo;
                    if (this.txtStockMinimo.Text == "")
                    {
                        stockMinimo = 00.00m;
                    }
                    else
                    {
                        stockMinimo = Convert.ToDecimal(this.txtStockMinimo.Text.Trim());
                    }

                    costo = Convert.ToDecimal(this.txtCosto.Text.Trim());
    
                    if (this.IsNuevo)
                    {
                        //rpta = NInsumo.Insertar(Convert.ToInt32(this.cbUnidad.SelectedValue.ToString()), this.txtNombre.Text.Trim().ToUpper(), costo, Convert.ToDecimal(this.txtStock.Text.Trim()),
                                                //stockMinimo, "A");

                        rpta = NProducto.Insertar(this.txtNombre.Text.Trim().ToUpper(), this.txtDescripcion.Text.Trim(), 00.00m, 00.00m,"I", "A",10,
                                                    "", stockMinimo, costo, Convert.ToInt32(this.cbUnidad.SelectedValue));
                    }
                    else
                    {
                        //rpta = NInsumo.Editar(Convert.ToInt32(this.txtIdInsumo.Text), Convert.ToInt32(this.cbUnidad.SelectedValue.ToString()), this.txtNombre.Text.Trim().ToUpper(), costo, Convert.ToDecimal(this.txtStock.Text.Trim()),
                        //stockMinimo, "A");

                        rpta = NProducto.Editar(Convert.ToInt32(this.txtIdInsumo.Text), this.txtNombre.Text.Trim().ToUpper(), this.txtDescripcion.Text.Trim(), 00.00m, 00.00m, "I", "A",10,
                                                    "", stockMinimo, costo, Convert.ToInt32(this.cbUnidad.SelectedValue));
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOK("Se insertó correctamente");
                        }
                        else
                        {
                            this.MensajeOK("Se actualizó correctamente");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                    this.tabControl2.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void frmInsumo_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.cargarUnidadMedida();
            this.Botones();
          
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.cbUnidad.Focus();
            this.dataListado.ClearSelection();
            this.tabControl2.SelectedIndex = 1;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.Guardar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdInsumo.Text.Equals(""))
            {
                this.btnCancelar.Enabled = true;
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
                this.txtNombre.Focus();
                this.tabControl2.SelectedIndex = 1;
            }
            else
            {
                this.MensajeError("Seleccione un registro");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Mostrar();
            this.Limpiar();
            this.Habilitar(false);
            this.dataListado.ClearSelection();
            this.tabControl2.SelectedIndex = 0;
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

        private void cbEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
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
                            rpta = NInsumo.Eliminar(Convert.ToInt32(codigo));
                        }

                    }

                    if (rpta.Equals("OK"))
                    {
                        this.MensajeOK("Se eliminó correctamente el registro");
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.Mostrar();
                    this.Limpiar();
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataListado_Click(object sender, EventArgs e)
        {

            string idCategoria, idUnidad;
            if (this.IsNuevo)
            {
                this.Habilitar(false);

                this.btnGuardar.Enabled = false;
            }
            this.btnEditar.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.txtIdInsumo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);

            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Descripcion"].Value);
            this.txtStockMinimo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["stockMinimo"].Value);
            this.txtCosto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Costo"].Value);

            idUnidad = Convert.ToString(this.dataListado.CurrentRow.Cells["idUnidadMedida"].Value);

            cbUnidad.SelectedValue = idUnidad;

        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {

           
        }

        private void txtStockMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {

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

            for (int i = 0; i < txtStockMinimo.Text.Length; i++)
            {
                if (txtStockMinimo.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 3)
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

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtCosto_KeyPress_1(object sender, KeyPressEventArgs e)
        {
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

            for (int i = 0; i < txtCosto.Text.Length; i++)
            {
                if (txtCosto.Text[i] == '.')
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmRInsumo frm = new frmRInsumo();
            frm.ShowDialog();
        }

        private void frmInsumo_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
