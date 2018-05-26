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
    public partial class frmProductoRapido : Form
    {
        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public frmProductoRapido()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.cbCategoria, "Seleccione la categoria");
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Producto");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cargarCategoria()
        {
            cbCategoria.DataSource = NCategoria.Mostrar();
            cbCategoria.ValueMember = "Codigo";
            cbCategoria.DisplayMember = "Categoria";
            cbCategoria.SelectedIndex = -1;
            //lblPrueba.Text = cbCategoria.SelectedValue.ToString();

        }

        private void cargarUnidad()
        {
            cbUnidad.DataSource = NUnidadMedida.Mostrar();
            cbUnidad.ValueMember = "Codigo";
            cbUnidad.DisplayMember = "Unidad_Medida";
            cbUnidad.SelectedIndex = -1;
            //lblPrueba.Text = cbCategoria.SelectedValue.ToString();

        }
        private void frmProductoRapido_Load(object sender, EventArgs e)
        {
            cargarCategoria();
            cargarUnidad();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                int idCategoria, idUnidad;

                if (this.cbCategoria.SelectedIndex == -1)
                {
                    MensajeError("Seleccione una categoría");
                    errorIcono.SetError(cbCategoria, "Seleccione una categoría");
                }
                else if (this.cbUnidad.SelectedIndex == -1)
                {
                    MensajeError("Seleccione una medida");
                    errorIcono.SetError(cbCategoria, "Seleccione una medida");
                }
                else if (this.txtNombre.Text.Trim() == string.Empty)
                {
                    MensajeError("Ingrese el nombre");
                    errorIcono.SetError(txtNombre, "Ingrese el nombre");
                }

                else 
                {
                    string imprimir="";
                
                    idCategoria = Convert.ToInt32(this.cbCategoria.SelectedValue.ToString());
                    idUnidad = Convert.ToInt32(this.cbUnidad.SelectedValue.ToString());
                    rpta = NProducto.Insertar(this.txtNombre.Text.Trim().ToUpper(), "",0,00.00m,"A", "A", idCategoria,imprimir,0,00.00m,idUnidad);

                     if (rpta.Equals("OK"))
                     {
                         this.MensajeOK("Se insertó correctamente");

                     }
                     else
                     {
                         this.MensajeError(rpta);
                     }

                    frmVistaProductoIngreso.f1.Mostrar();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void frmProductoRapido_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmVistaProductoIngreso.f1.Show();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
