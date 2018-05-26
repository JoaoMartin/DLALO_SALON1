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
    public partial class frmCambioPass : Form
    {
        public frmCambioPass()
        {
            InitializeComponent();
        }

        private void frmCambioPass_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(this.txtPassActual.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Ingrese la contraseña actual");
            }else if(this.txtPassNueva.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Ingrese la contraseña nueva");
            }else if(this.txtPassRepetida.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Ingrese la contraseña repetida");
            }else
            {
                if(this.txtPassActual.Text.Trim() != this.lblPassword.Text)
                {
                    MessageBox.Show("La contraseña actual no es la correcta");
                }
                else if (this.txtPassNueva.Text.Trim() != this.txtPassRepetida.Text.Trim())
                {
                    MessageBox.Show("Las contraseña nueva no coincide");
                }else
                {
                    string rpta = "";
                    rpta = NTrabajador.cambiarPass(Convert.ToInt32(this.lblIdTrabajador.Text), this.lblUsuario.Text, this.txtPassNueva.Text.Trim());
                    if (rpta == "OK")
                    {
                        MessageBox.Show("La contraseña se modificó, vuelva a ingresar al sistema");
                        Application.Exit();
                    }else
                    {
                        MessageBox.Show(rpta);
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmCambioPass_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }
    }
}
