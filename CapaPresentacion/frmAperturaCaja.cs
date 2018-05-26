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
    public partial class frmAperturaCaja : Form
    {
        public frmAperturaCaja()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 )
            {
                e.Handled = false;

                if ((int)e.KeyChar == (int)Keys.Enter && this.txtMonto.Text != string.Empty)
                {
                    this.Aperturar();
                    frmPrincipal.f1.ValidarAcceso();
                    frmPrincipal.f1.ValidarControlesC();

                }
                return;
            }
            if (!(char.IsNumber(e.KeyChar)) && !(e.KeyChar == '.'))
            {
                e.Handled = true;

                if ((int)e.KeyChar == (int)Keys.Enter && this.txtMonto.Text != string.Empty)
                {
                    this.Aperturar();
                    frmPrincipal.f1.ValidarAcceso();
                    frmPrincipal.f1.ValidarControlesC();

                }
                return;
            }
            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtMonto.Text.Length; i++)
            {
                if (txtMonto.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46 )
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;


        

        }

        private void Aperturar()
        {
            if (this.txtMonto.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese un monto válido");
                txtMonto.Focus();
            }
            else
            {
                decimal monto = 00.00m;
                monto = Convert.ToDecimal(this.txtMonto.Text.Trim());
                if (monto <= 0)
                {
                    MessageBox.Show("Ingrese un monto mayor a cero");
                    txtMonto.Focus();
                }
                else
                {
                    string rpta = "";
                    DateTime? fechaApertura = null;
                    rpta=NCaja_A.Insertar(Convert.ToInt32(this.lblIdUsuario.Text), "Caja 1", DateTime.Now, Convert.ToDecimal(this.txtMonto.Text.Trim()), "Abierta",1,00.00m,00-00m,
                        00.00m,00.00m, Convert.ToDecimal(this.txtMonto.Text.Trim()),fechaApertura);
                    if(rpta != "No se ingresó el Registro")
                    {
                        MessageBox.Show("Se aperturó la caja");
                        // Application.Exit();
                        this.Hide();
                      
                    }else
                    {
                        MessageBox.Show(rpta);
                    }
                  
                }

            }
        }

        private void frmAperturaCaja_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.Aperturar();
            frmPrincipal.f1.ValidarAcceso();
            frmPrincipal.f1.ValidarControlesC();
            frmPrincipal.f1.ValidarAcceso();
        }

        private void frmAperturaCaja_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
