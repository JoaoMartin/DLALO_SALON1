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
    public partial class frmTrabajador : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public frmTrabajador()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Trabajador");
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
            this.txtApellidos.Text = string.Empty;
            this.txtFechaNac.Text = string.Empty;
            this.txtNumDoc.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtIdTrabajador.Text = string.Empty;

            this.pbFecha.Enabled = false;
            this.cbEliminar.Checked = false;
            this.cbTipoDoc.SelectedIndex = -1;
            this.cbCargo.SelectedIndex = -1;
            this.rbFemenino.Checked = false;
            this.rbMasculino.Checked = false;
        }

        //Habilitar Controles
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtApellidos.ReadOnly = !valor;
            this.cbTipoDoc.Enabled = valor;
            this.cbCargo.Enabled = valor;
            this.pbFecha.Enabled = valor;
            this.txtNumDoc.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.rbMasculino.Enabled = valor;
            this.rbFemenino.Enabled = valor;
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
            this.dataListado.Columns[4].Visible = false;
            this.dataListado.Columns[7].Visible = false;
            this.dataListado.Columns[10].Visible = false;
            this.dataListado.Columns[9].Visible = false;
            this.dataListado.Columns[12].Visible = false;
            this.dataListado.Columns[13].Visible = false;
            this.dataListado.Columns[14].Visible = false;
            //this.dataListado.Columns[4].Visible = false;

            this.dataListado.Columns[1].Width = 80;
            this.dataListado.Columns[2].Width = 170;
            this.dataListado.Columns[3].Width = 170;
            this.dataListado.Columns[8].Width = 300;

            this.dataListado.Columns[11].Width = 146;
            //this.dataListado.Columns[7].Width = 120;

            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NTrabajador.Mostrar();
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

        private void BuscarNombre()
        {
            this.dataListado.DataSource = NTrabajador.BuscarNombre(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarApellidos()
        {
            this.dataListado.DataSource = NTrabajador.BuscarApellido(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarDni()
        {
            this.dataListado.DataSource = NTrabajador.BuscarDni(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarSexo()
        {
            this.dataListado.DataSource = NTrabajador.BuscarSexo(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarTipo()
        {
            this.dataListado.DataSource = NTrabajador.BuscarTipoTrabajador(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void cargarTrabajador()
        {
            cbCargo.DataSource = NTipoTrabajador.Mostrar();
            cbCargo.ValueMember = "Codigo";
            cbCargo.DisplayMember = "Tipo";
            cbCargo.SelectedIndex = -1;
            //lblPrueba.Text = cbCategoria.SelectedValue.ToString();

        }

        private void Guardar()
        {
            try
            {
                string rpta = "";
                string sexo = "";
                DateTime fecNac;

                if (this.cbCargo.SelectedIndex == -1)
                {
                    MensajeError("Seleccione un cargo");
                    errorIcono.SetError(cbCargo, "Seleccionar cargo");
                }
                else if (this.txtNombre.Text.Trim() == string.Empty)
                {
                    MensajeError("Ingrese el nombre del trabajador");
                    errorIcono.SetError(txtNombre, "Ingrese el nombre");
                }
                else if (this.txtApellidos.Text.Trim() == string.Empty)
                {
                    MensajeError("Ingrese los apellidos del trabajador");
                    errorIcono.SetError(txtApellidos, "Ingrese el nombre");
                }
                else if (this.cbTipoDoc.SelectedIndex == -1)
                {
                    MensajeError("Seleccione un tipo de documento");
                    errorIcono.SetError(cbTipoDoc, "Seleccionar tipo");
                }
                else if (this.txtNumDoc.Text.Trim() == string.Empty)
                {
                    MensajeError("Ingrese el número de documento");
                    errorIcono.SetError(txtNumDoc, "Ingrese el número de documento");
                }
                else if (this.rbMasculino.Checked == false && this.rbFemenino.Checked == false)
                {
                    MensajeError("Seleccione el sexo");
                    errorIcono.SetError(rbMasculino, "Seleccionar");
                }
                else if (this.txtFechaNac.Text.Trim() == string.Empty)
                {
                    MensajeError("Seleccione la fecha de Nacimiento");
                    errorIcono.SetError(txtFechaNac, "Seleccione la fecha de nacimiento");
                }
                else if (this.txtDireccion.Text.Trim() == string.Empty)
                {
                    MensajeError("Ingrese la dirección del trabajador");
                    errorIcono.SetError(txtDireccion, "Ingrese la dirección");
                }
                else if (this.txtTelefono.Text.Trim() == string.Empty)
                {
                    MensajeError("Ingrese el telefono del trabajador");
                    errorIcono.SetError(txtTelefono, "Ingrese el telefono");
                }
                else
                {
                    if (this.txtFechaNac.Text == "")
                    {
                        fecNac = DateTime.MinValue;
                    }
                    else
                    {
                        fecNac = Convert.ToDateTime(this.txtFechaNac.Text);
                    }
                    if (this.rbMasculino.Checked == true)
                    {
                        sexo = "M";
                    }
                    else
                    {
                        sexo = "F";
                    }
                    if (this.IsNuevo)
                    {
                        rpta = NTrabajador.Insertar(this.txtNombre.Text.Trim().ToUpper(), this.txtApellidos.Text.Trim().ToUpper(), this.cbTipoDoc.SelectedItem.ToString(),
                                                    this.txtNumDoc.Text.Trim(), sexo, fecNac, this.txtDireccion.Text.Trim(), this.txtTelefono.Text.Trim(), this.txtEmail.Text.Trim(),
                                                    "A", Convert.ToInt32(this.cbCargo.SelectedValue.ToString()), this.txtUsuario.Text.Trim(), this.txtPass.Text.Trim());
                    }
                    else
                    {
                        rpta = NTrabajador.Editar(Convert.ToInt32(this.txtIdTrabajador.Text), this.txtNombre.Text.Trim().ToUpper(), this.txtApellidos.Text.Trim().ToUpper(), this.cbTipoDoc.SelectedItem.ToString(),
                                                    this.txtNumDoc.Text.Trim(), sexo, fecNac, this.txtDireccion.Text.Trim(), this.txtTelefono.Text.Trim(), this.txtEmail.Text.Trim(),
                                                    "A", Convert.ToInt32(this.cbCargo.SelectedValue.ToString()), this.txtUsuario.Text.Trim(), this.txtPass.Text.Trim());
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOK("Se insertó correcatamente");
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
        private void frmTrabajador_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.cargarTrabajador();
            this.Botones();
            this.rbTodos.Checked = true;
        }

        private void pbFecha_Click(object sender, EventArgs e)
        {
            if (mcFecha.Visible == true)
            {
                mcFecha.Visible = false;
            }
            else
            {
                mcFecha.Visible = true;
            }
        }

        private void mcFecha_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtFechaNac.Text = mcFecha.SelectionStart.ToShortDateString();
            mcFecha.Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.cbCargo.Focus();
            this.cbTipoDoc.SelectedIndex = 0;
            this.dataListado.ClearSelection();
            this.tabControl2.SelectedIndex = 1;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (this.rbNombre.Checked == true)
            {
                this.BuscarNombre();
            }
            else if (this.rbApellido.Checked == true)
            {
                this.BuscarApellidos();
            }
            else if (this.rbDni.Checked == true)
            {
                this.BuscarDni();
            }

            else if (this.rbTipoTrabajador.Checked == true)
            {
                this.BuscarTipo();
            }
            else if (this.rbTodos.Checked == true)
            {
                this.BuscarNombre();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.Guardar();
        }

        private void dataListado_Click(object sender, EventArgs e)
        {


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdTrabajador.Text.Equals(""))
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
                            rpta = NTrabajador.Eliminar(Convert.ToInt32(codigo));
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

        private void dataListado_Click_1(object sender, EventArgs e)
        {
            if (this.IsNuevo)
            {
                this.Habilitar(false);

                this.btnGuardar.Enabled = false;
            }
            this.btnEditar.Enabled = true;
            this.btnCancelar.Enabled = true;
            DateTime fechaNac;
            String fechaNacimiento;
            string sexo = "";
            string idTipoTrabajador;

            this.txtIdTrabajador.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.txtApellidos.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Apellidos"].Value);
            this.cbTipoDoc.SelectedItem = Convert.ToString(this.dataListado.CurrentRow.Cells["Tipo_Doc"].Value);
            this.txtNumDoc.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nro_Doc"].Value);
            sexo = Convert.ToString(this.dataListado.CurrentRow.Cells["Sexo"].Value);
            if (sexo == "M")
            {
                this.rbMasculino.Checked = true;
            }
            else
            {
                this.rbFemenino.Checked = true;
            }
            fechaNacimiento = Convert.ToString(this.dataListado.CurrentRow.Cells["Fecha_Nac"].Value);
            fechaNac = Convert.ToDateTime(fechaNacimiento);
            if (fechaNacimiento == "01/01/0001 12:00:00 a. m.")
            {
                this.txtFechaNac.Text = "";
            }
            else
            {
                this.txtFechaNac.Text = fechaNac.ToShortDateString();
            }


            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Email"].Value);
            this.txtUsuario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Usuario"].Value);
            this.txtPass.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Password"].Value);
            idTipoTrabajador = Convert.ToString(this.dataListado.CurrentRow.Cells["idTipoTrabajador"].Value);
            cbCargo.SelectedValue = idTipoTrabajador;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodos.Checked == true)
            {
                this.Mostrar();
                this.txtBuscar.Text = string.Empty;
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmRTrabajador frm = new frmRTrabajador();
            frm.ShowDialog();
        }

        private void frmTrabajador_FormClosed(object sender, FormClosedEventArgs e)
        {
        } 
            
    }
}
