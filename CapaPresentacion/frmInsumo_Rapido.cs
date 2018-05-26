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
    public partial class frmInsumo_Rapido : Form
    {
        public frmInsumo_Rapido()
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

        private void cargarUnidad()
        {
            cbUnidad.DataSource = NUnidadMedida.Mostrar();
            cbUnidad.ValueMember = "Codigo";
            cbUnidad.DisplayMember = "Unidad_Medida";
            cbUnidad.SelectedIndex = -1;
            //lblPrueba.Text = cbCategoria.SelectedValue.ToString();

        }
        private void frmInsumo_Rapido_Load(object sender, EventArgs e)
        {
           
            cargarUnidad();
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
                int  idUnidad;

               if (this.cbUnidad.SelectedIndex == -1)
                {
                    MensajeError("Seleccione una medida");
                    errorIcono.SetError(cbUnidad, "Seleccione una medida");
                }
                else if (this.txtNombre.Text.Trim() == string.Empty)
                {
                    MensajeError("Ingrese el nombre");
                    errorIcono.SetError(txtNombre, "Ingrese el nombre");
                }

                else
                {
                    string imprimir = "";

                    idUnidad = Convert.ToInt32(this.cbUnidad.SelectedValue.ToString());
                    rpta = NProducto.Insertar(this.txtNombre.Text.Trim().ToUpper(), "", 0, 00.00m,"I","A",10, imprimir, 0, 00.00m, idUnidad);

                    if (rpta.Equals("OK"))
                    {
                        this.MensajeOK("Se insertó correctamente");

                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    frmVistaInsumo_Ingreso.f1.Mostrar();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
