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
    public partial class frmAnularPedido : Form
    {
        public frmAnularPedido()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string rpta = NVenta.EditarReservaCancelada(Convert.ToInt32(frmVentasReservadas.f1.lblIdVenta.Text));
            if(rpta == "OK")
            {
                if(rbSI.Checked == true)
                {
                    NCaja.Insertar(Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), "1", "EGRESO", Convert.ToDecimal(this.lblEfectivo.Text), this.txtDescripcion.Text.Trim(), "EFECTIVO");
                    this.Close();
                    frmVentasReservadas.f1.Mostrar();

                }else
                {
                    this.Close();
                    frmVentasReservadas.f1.Mostrar();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
