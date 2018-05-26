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
    public partial class frmProveedorRapido : Form
    {
        public frmProveedorRapido()
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
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtNombre.Text.Trim() == string.Empty)
                {
                    MensajeError("Ingrese el nombre del provedor");
                    errorIcono.SetError(txtNombre, "Ingrese el nombre");
                }
                else if (this.txtNumDoc.Text.Trim() == string.Empty)
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
   
                        rpta = NProveedor.Insertar(this.txtNombre.Text.Trim().ToUpper(), this.cbTipoDoc.SelectedItem.ToString(), this.txtNumDoc.Text.Trim(),
                                                   this.txtDireccion.Text.Trim().ToUpper(),"","", "A");


                    if (rpta.Equals("OK"))
                    {

                            this.MensajeOK("Se insertó correctamente");

                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    frmVistaProveedorIngreso.f1.Mostrar();
                    this.Hide();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void frmProveedorRapido_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmVistaProveedorIngreso.f1.Show();
            
        }

        private void frmProveedorRapido_Load(object sender, EventArgs e)
        {
            this.cbTipoDoc.SelectedIndex = 0;
        }
    }
}
