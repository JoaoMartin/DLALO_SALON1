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
    public partial class frmSalon : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public frmSalon()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Salón");
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
            this.txtIdMarca.Text = string.Empty;

            this.cbEliminar.Checked = false;
        }

        //Habilitar Controles
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.errorIcono.Clear();
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
            this.dataListado.Columns[3].Visible = false;

            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[1].Width = 140;
            this.dataListado.Columns[2].Width = 337;

            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NSalon.Mostrar();
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
            }
            else
            {
                this.dataListado.Visible = true;
            }
        }

        private void Buscar()
        {
            this.dataListado.DataSource = NSalon.Buscar(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void Guardar()
        {
            try
            {
                string rpta = "";
                if (this.txtNombre.Text.Trim() == string.Empty)
                {
                    MensajeError("Ingrese la marca");
                    errorIcono.SetError(txtNombre, "Ingrese el nombre");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NSalon.Insertar(this.txtNombre.Text.Trim().ToUpper(), "A");
                    }
                    else
                    {
                        rpta = NSalon.Editar(Convert.ToInt32(this.txtIdMarca.Text), this.txtNombre.Text.Trim().ToUpper(), "A");
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOK("Se insertó correcatamente");
                        }
                        else
                        {
                            this.MensajeOK("Se actualizó correcatamente");
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

        private void frmSalon_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
            this.dataListado.ClearSelection();
            this.tabControl2.SelectedIndex = 1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.Guardar();
        }

        private void dataListado_Click(object sender, EventArgs e)
        {
            if (this.IsNuevo)
            {
                this.Habilitar(false);               
                this.btnGuardar.Enabled = false;
            }
            this.btnEditar.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.txtIdMarca.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Cod_Salon"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Salon"].Value);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdMarca.Text.Equals(""))
            {
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
            this.Limpiar();
            this.Habilitar(false);
            this.Mostrar();
            this.tabControl2.SelectedIndex = 0;
            this.dataListado.ClearSelection();
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
                            rpta = NSalon.Eliminar(Convert.ToInt32(codigo));
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

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (this.btnGuardar.Enabled == true)
                {
                    this.Guardar();
                }

            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void frmSalon_FormClosed(object sender, FormClosedEventArgs e)
        {
     
        }
    }
}
        
