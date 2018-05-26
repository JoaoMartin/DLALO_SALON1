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
    public partial class frmAperturaTurno : Form
    {
        public frmAperturaTurno()
        {
            InitializeComponent();
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
                    //rpta = NCaja.Insertar(Convert.ToInt32(this.lblIdUsuario.Text), "Caja 1", DateTime.Now, Convert.ToDecimal(this.txtMonto.Text.Trim()), "Abierta", 1);
                    if(frmPrincipal.f1.lblEstadoCaja.Text == "Abierta")
                    {
                        rpta = NTurno.Insertar(Convert.ToInt32(this.lblIdUsuario.Text), DateTime.Now, Convert.ToDecimal(this.txtMonto.Text.Trim()), "Abierto",00.00m,00.00m);
                        if (rpta == "OK")
                        {
                            MessageBox.Show("Se aperturó el turno");
                            // Application.Exit();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show(rpta);
                        }
                    }else
                    {
                        MessageBox.Show("Primero aperture la caja");
                      
                        this.Hide();
                    }
                   

                }

            }
        }
        private void frmAperturaTurno_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Aperturar();
            frmPrincipal.f1.ValidarAcceso();
            frmPrincipal.f1.ValidarControlesR();
        }

        private void frmAperturaTurno_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
