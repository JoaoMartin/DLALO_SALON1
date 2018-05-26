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
    public partial class frmControlCaja : Form
    {
        public frmControlCaja()
        {
            InitializeComponent();
        }

        public void ventas()
        {
            DataTable dt;
            dt = NCaja_A.MostrarVentasCaja(Convert.ToDateTime(this.lblFechaApertura.Text), DateTime.Now);
            if (dt.Rows[0][0].ToString() != "")
            {
                this.txtVentaEfectivo.Text = dt.Rows[0][0].ToString();
            }
            else
            {
                this.txtVentaEfectivo.Text = "00.00";
            }

            if (dt.Rows[1][0].ToString() != "")
            {
                this.txtVentaTarjeta.Text = dt.Rows[1][0].ToString();
            }
            else
            {
                this.txtVentaTarjeta.Text = "00.00";
            }

            if (dt.Rows[2][0].ToString() != "")
            {
                this.txtOtrosIngresos.Text = dt.Rows[2][0].ToString();
            }
            else
            {
                this.txtOtrosIngresos.Text = "00.00";
            }

            if (dt.Rows[3][0].ToString() != "")
            {
                this.lblNroVentas.Text = dt.Rows[3][0].ToString();
            }
            else
            {
                this.lblNroVentas.Text = "0";
            }
            if (dt.Rows[4][0].ToString() != "")
            {
                this.lblNroTickets.Text = dt.Rows[4][0].ToString();
            }
            else
            {
                this.lblNroTickets.Text = "0";
            }
            if (dt.Rows[5][0].ToString() != "")
            {
                this.lblNroBoletas.Text = dt.Rows[5][0].ToString();
            }
            else
            {
                this.lblNroBoletas.Text = "0";

            }
            if (dt.Rows[6][0].ToString() != "")
            {
                this.lblNroFacturas.Text = dt.Rows[6][0].ToString();
            }
            else
            {
                this.lblNroFacturas.Text = "0";
            }

            if (dt.Rows[7][0].ToString() != "")
            {
                this.txtSalidas.Text = dt.Rows[7][0].ToString();
            }
            else
            {
                this.txtSalidas.Text = "00.00";
            }

            if (dt.Rows[8][0].ToString() != "")
            {
                this.lblFacManual.Text = dt.Rows[8][0].ToString();
            }
            else
            {
                this.lblFacManual.Text = "00.00";
            }
            if (dt.Rows[9][0].ToString() != "")
            {
                this.lblBolManual.Text = dt.Rows[9][0].ToString();
            }
            else
            {
                this.lblBolManual.Text = "00.00";
            }

            //cuenta_usuario.idCliente(txtUsuario.Text, txtContraseña.Text);
            // dt.Rows[0]["Estado"].ToString();
            decimal total = 00.00m;
            total = total + Convert.ToDecimal(txtMontoApertura.Text) + Convert.ToDecimal(txtVentaEfectivo.Text)  + Convert.ToDecimal(txtOtrosIngresos.Text) - Convert.ToDecimal(txtSalidas.Text);
            lblTotal.Text = total.ToString();
            btnNuevo.Enabled = true;
        }
        private void frmControlCaja_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ventas();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmMovimientoCaja frm = new frmMovimientoCaja();
            frm.lblFechaApertura.Text = this.lblFechaApertura.Text;
            frm.ShowDialog();
        }
    }
}
