using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmTeclado : Form
    {
        public frmTeclado()
        {
            InitializeComponent();
        }

        private void btnUno_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "1";
        }

        private void btnDos2_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "0";
        }

        private void frmTeclado_Load(object sender, EventArgs e)
        {
            this.txtNumero.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.txtNumero.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Ingrese una cantidad");
            }
            else
            {
                frmVenta.f1.txtCantidad.Text = this.txtNumero.Text.Trim();
                this.Hide();
            }
          
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnRetroceso_Click(object sender, EventArgs e)
        {
            if(this.txtNumero.Text.Length == 1)
            {
                this.txtNumero.Text = string.Empty;
            }
            else if (this.txtNumero.Text.Length != 0)
            {
                this.txtNumero.Text = this.txtNumero.Text.Substring(0, this.txtNumero.Text.Length - 1);
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            if ((int)e.KeyChar == (int)Keys.Enter && this.txtNumero.Text != string.Empty)
            {

                if (this.txtNumero.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Ingrese una cantidad");
                }
                else
                {
                    frmVenta.f1.txtCantidad.Text = this.txtNumero.Text.Trim();
                    this.Hide();
                }
            }
        }
    }
}
