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
    public partial class frmProveedor : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public frmProveedor()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Proveedor");
            this.ttMensaje.SetToolTip(this.txtNumDoc, "Ingrese el Número de Documento");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la dirección");
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
            this.txtNumDoc.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtIdProveedor.Text = string.Empty;

            this.cbEliminar.Checked = false;
            this.cbTipoDoc.SelectedIndex = 0;
        }

        //Habilitar Controles
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.cbTipoDoc.Enabled = valor;
            this.txtNumDoc.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
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
                this.btnEliminar.Enabled = false;
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }

        private void ocultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[7].Visible = false;
            //this.dataListado.Columns[4].Visible = false;

            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[1].Width = 75;
            this.dataListado.Columns[2].Width = 280;
            this.dataListado.Columns[5].Width = 465;
            this.dataListado.Columns[6].Width = 125;

            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NProveedor.Mostrar();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
            }
            else
            {
                this.dataListado.Visible = true;
                this.ocultarColumnas();

            }
        }

        private void BuscarRazonSocial()
        {
            this.dataListado.DataSource = NProveedor.BuscarRazonSocial(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarRuc()
        {
            this.dataListado.DataSource = NProveedor.BuscarRuc(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarCodigo()
        {
            this.dataListado.DataSource = NProveedor.BuscarCodigo(this.txtBuscar.Text.Trim());
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
                    MensajeError("Ingrese el nombre del provedor");
                    errorIcono.SetError(txtNombre, "Ingrese el nombre");
                }else if (this.txtNumDoc.Text.Trim() == string.Empty)
                {
                    MensajeError("Ingrese el número de documento");
                    errorIcono.SetError(txtNombre, "Ingrese el número");
                }
                else if (this.txtDireccion.Text.Trim() == string.Empty)
                {
                    MensajeError("Ingrese la direeción");
                    errorIcono.SetError(txtDireccion, "Ingrese la dirección");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NProveedor.Insertar(this.txtNombre.Text.Trim().ToUpper(),this.cbTipoDoc.SelectedItem.ToString(),this.txtNumDoc.Text.Trim(),
                                                   this.txtDireccion.Text.Trim().ToUpper(),this.txtTelefono.Text.Trim(),this.txtEmail.Text.Trim(),"A");
                    }
                    else
                    {
                        rpta = NProveedor.Editar(Convert.ToInt32(this.txtIdProveedor.Text), this.txtNombre.Text.Trim().ToUpper(), this.cbTipoDoc.SelectedItem.ToString(), 
                                                                 this.txtNumDoc.Text.Trim(),this.txtDireccion.Text.Trim().ToUpper(), this.txtTelefono.Text.Trim(), this.txtEmail.Text.Trim(), "A");
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

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.rbTodos.Checked = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (this.rbNombre.Checked == true)
            {
                this.BuscarRazonSocial();
            }
            else if (this.rbNroDoc.Checked == true)
            {
                this.BuscarRuc();
            }
            else if (this.rbCodigo.Checked == true)
            {
                this.BuscarCodigo();
            }
            else if (this.rbTodos.Checked == true)
            {
                this.BuscarRazonSocial();
            }
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
            this.txtIdProveedor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Razon_Social"].Value);
            this.cbTipoDoc.SelectedItem = Convert.ToString(this.dataListado.CurrentRow.Cells["Tipo_Doc"].Value);
            this.txtNumDoc.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nro_Doc"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Email"].Value);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdProveedor.Text.Equals(""))
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
            this.Mostrar();
            this.Habilitar(false);
            this.dataListado.ClearSelection();
            this.tabControl2.SelectedIndex = 0;
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
                            rpta = NProveedor.Eliminar(Convert.ToInt32(codigo));
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

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodos.Checked == true)
            {
                this.Mostrar();
                this.txtBuscar.Text = string.Empty;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmRProveedor frm = new frmRProveedor();
            frm.ShowDialog();
        }

        private void frmProveedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
