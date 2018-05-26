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
    public partial class frmLogin : Form
    {
        public static frmLogin f3;
        public frmLogin()
        {
            InitializeComponent();
            frmLogin.f3 = this;

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login()
        {
            if(this.txtPass.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la clave");
            }
            else
            {
                DataTable datos = NTrabajador.LoginMesero(this.txtPass.Text.Trim());
                if (datos.Rows.Count == 0)
                {
                    MessageBox.Show("El usuario no existe", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DataTable dtEstado = NCaja_A.MostrarEstadoCaja(1);
                    DataTable dtEstadoMonto = NCaja_A.MostrarEstadoCajaMonto(1);

                    string estado;
                    DateTime fecha_estado;

                    if (dtEstado.Rows.Count > 0)
                    {
                        estado = dtEstado.Rows[0]["Estado"].ToString();
                    }
                    else
                    {
                        estado = "0";
                    }

                    if (estado == "0" || estado == "Cerrada")
                    {
                        MessageBox.Show("La Caja esta cerrada, aperturela");
                        return;
                    }
                    else
                    {
                        frmModuloSalon frm = new frmModuloSalon();
                        frm.lblIdUsuario.Text = datos.Rows[0][0].ToString();
                        frm.lblUsuario.Text = datos.Rows[0][1].ToString();
                        /*
                            if (dtCorte.Rows.Count <=0)
                        {
                            frm.lblFechaCorteCaja.Text = dtMonto.Rows[0]["fecha"].ToString();
                            frm.lblMontoCorteCaja.Text = dtMonto.Rows[0]["monto"].ToString();
                        }
                        else
                        {
                            frm.lblFechaCorteCaja.Text = dtCorte.Rows[0]["fecha"].ToString();
                            frm.lblMontoCorteCaja.Text = dtCorte.Rows[0]["monto"].ToString();
                        }*/
                        this.txtPass.Text = string.Empty;

                        frm.Show();
                    }

                    
                    this.Hide();
                }
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            this.Login();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.Login();

            }
        }

        private void txtUsuario_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.Login();
            }
        }

        private void btnUno_Click(object sender, EventArgs e)
        {
            this.txtPass.Text += "1";
        }

        private void btnDos2_Click(object sender, EventArgs e)
        {
            this.txtPass.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            this.txtPass.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            this.txtPass.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            this.txtPass.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            this.txtPass.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            this.txtPass.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            this.txtPass.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            this.txtPass.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            this.txtPass.Text += "0";
        }

        private void btnRetroceso_Click(object sender, EventArgs e)
        {
            if (this.txtPass.Text.Length == 1)
            {
                this.txtPass.Text = string.Empty;
            }
            else if (this.txtPass.Text.Length != 0)
            {
                this.txtPass.Text = this.txtPass.Text.Substring(0, this.txtPass.Text.Length - 1);
            }
        }
    }
}
