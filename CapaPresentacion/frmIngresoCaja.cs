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
    public partial class frmIngresoCaja : Form
    {
        public frmIngresoCaja()
        {
            InitializeComponent();
        }

        private void frmIngresoCaja_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(this.txtMonto.Text.Trim()=="" || this.txtDescripcion.Text.Trim() == "")
            {
                MessageBox.Show("Complete los dos campos");
            }else
            {
                decimal monto = Convert.ToDecimal(this.txtMonto.Text.Trim());
                if (monto <= 0)
                {
                    MessageBox.Show("Ingrese un monto mayor a cero");
                }else
                {
                    string rpta = "";
                    rpta = NCaja.Insertar(Convert.ToInt32(this.lblIdUsuario.Text), "1", "INGRESO", monto, this.txtDescripcion.Text.Trim(), "EFECTIVO");
                    if (rpta == "OK")
                    {
                        MessageBox.Show("Se registró correctamente");
                      
                        this.Hide();
                    }else
                    {
                        MessageBox.Show(rpta);

                    }
                }
            }
        }

        private void frmIngresoCaja_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }
    }
}
