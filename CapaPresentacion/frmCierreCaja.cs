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
    public partial class frmCierreCaja : Form
    {
        public frmCierreCaja()
        {
            InitializeComponent();
        }

        public void ingresosEfectivo()
        {
          

            //cuenta_usuario.idCliente(txtUsuario.Text, txtContraseña.Text);
            // dt.Rows[0]["Estado"].ToString();
        }

        public void ingresosTarjeta()
        {
            
        }


        public void total()
        {
            decimal ventasEfectivo = 00.00m;
            decimal ventasTarjeta = 00.00m;
            decimal otrosIngreso = 00.00m;
            decimal totalParcial = 00.00m;
            decimal totalCaja = 00.00m;
            decimal egresos = 00.00m;

            decimal totalVenta = 00.00m;
            decimal montoApertura = 00.00m;

            ventasEfectivo = Convert.ToDecimal(txtVentaEfectivo.Text);
            ventasTarjeta = Convert.ToDecimal(txtTarjeta.Text);
            otrosIngreso = Convert.ToDecimal(txtOtrosIngresos.Text);
            egresos = Convert.ToDecimal(txtEgresos.Text);
            totalParcial = ventasEfectivo + otrosIngreso - egresos;
            montoApertura = Convert.ToDecimal(lblMontoInicial.Text);
            totalCaja = totalParcial + montoApertura;
            totalVenta = ventasEfectivo + ventasTarjeta;

            lblTotalParcial.Text = totalParcial.ToString();
            lblTotalCaja.Text = totalCaja.ToString();
            lblTotalVentas.Text = totalVenta.ToString();

        }

        //cuenta_usuario.idCliente(txtUsuario.Text, txtContraseña.Text);
        // dt.Rows[0]["Estado"].ToString();

        public void egresos()
        {
            DataTable dt;
            dt = NCaja_A.MostrarEgresos(1, Convert.ToDateTime(this.lblfechaApert.Text), DateTime.Now);
            if (dt.Rows[0]["Monto"].ToString() == "")
            {
                this.txtEgresos.Text = "00.00";
            }
            else
            {
                this.txtEgresos.Text = dt.Rows[0]["Monto"].ToString();
                this.txtEgresos.Text = string.Format("{0:#,##0.00}", Convert.ToDouble(this.txtEgresos.Text));
            }

            //cuenta_usuario.idCliente(txtUsuario.Text, txtContraseña.Text);
            // dt.Rows[0]["Estado"].ToString();
        }

        public void ventas()
        {
            DataTable dt;
            dt = NCaja_A.MostrarVentasCaja(Convert.ToDateTime(this.lblfechaApert.Text), DateTime.Now);
            if (dt.Rows[0][0].ToString() != "")
            {
                this.lblVentasEfectivo.Text = dt.Rows[0][0].ToString();
                this.txtVentaEfectivo.Text = dt.Rows[0][0].ToString();
                this.txtEnEfectivo.Text = dt.Rows[0][0].ToString();
            }
            else
            {
                this.lblVentasEfectivo.Text = "00.00";
                this.txtVentaEfectivo.Text = "00.00";
                this.txtEnEfectivo.Text = "00.00";
            }

            if (dt.Rows[1][0].ToString() != "")
            {
                this.lblVentasTarjeta.Text = dt.Rows[1][0].ToString();
                this.txtTarjeta.Text = dt.Rows[1][0].ToString();
            }
            else
            {
                this.lblVentasTarjeta.Text = "00.00";
                this.txtTarjeta.Text = "00.00";
            }

            if (dt.Rows[2][0].ToString() != "")
            {
                this.lblOtrosIngresos.Text = dt.Rows[2][0].ToString();
                this.txtOtrosIngresos.Text = dt.Rows[2][0].ToString();
            }
            else
            {
                this.lblOtrosIngresos.Text = "00.00";
                this.txtOtrosIngresos.Text = "00.00";
            }

            if (dt.Rows[3][0].ToString() != "")
            {
                this.lblToVentas.Text = dt.Rows[3][0].ToString();
            }
            else
            {
                this.lblToVentas.Text = "0";
            }
            if (dt.Rows[4][0].ToString() != "")
            {
                this.txtTickets.Text = dt.Rows[4][0].ToString();
            }
            else
            {
                this.txtTickets.Text = "0";
            }
            if (dt.Rows[5][0].ToString() != "")
            {
                this.lblNroBoletas.Text = dt.Rows[5][0].ToString();
                this.txtBoletas.Text = dt.Rows[5][0].ToString();
            }
            else
            {
                this.txtBoletas.Text = "0";

            }
            if (dt.Rows[6][0].ToString() != "")
            {
                this.txtFacturas.Text = dt.Rows[6][0].ToString();
            }
            else
            {
                this.txtFacturas.Text = "0";
            }
            if (dt.Rows[7][0].ToString() != "")
            {
                this.txtEgresos.Text = dt.Rows[7][0].ToString();
            }
            else
            {
                this.txtEgresos.Text = "00.00";
            }
            if (dt.Rows[8][0].ToString() != "")
            {
                this.txtFacManual.Text = dt.Rows[8][0].ToString();
            }
            else
            {
                this.txtFacManual.Text = "00.00";
            }
            if (dt.Rows[9][0].ToString() != "")
            {
                this.txtBolManual.Text = dt.Rows[9][0].ToString();
            }
            else
            {
                this.txtBolManual.Text = "00.00";
            }
            //cuenta_usuario.idCliente(txtUsuario.Text, txtContraseña.Text);
            // dt.Rows[0]["Estado"].ToString();
            total();
        }
        private void frmCierreCaja_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            ventas();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            DateTime fechaApertura = Convert.ToDateTime(this.lblfechaApert.Text);
           rpta= NCaja_A.Insertar(Convert.ToInt32(this.lblidUsuario.Text),"Caja 1", DateTime.Now,Convert.ToDecimal(lblTotalCaja.Text), "Cerrada", 1,Convert.ToDecimal(txtTarjeta.Text),
               Convert.ToDecimal(this.txtEgresos.Text),Convert.ToDecimal(txtOtrosIngresos.Text),Convert.ToDecimal(txtVentaEfectivo.Text),Convert.ToDecimal(lblMontoInicial.Text),fechaApertura);
            if (rpta != "OK")
            {
                int diezCen, veinteCen, cincuentaCen, unSol, dosSoles, cincoSoles, diezSoles, veinteSoles, cincuentaSoles, cienSoles, doscientosSoles;
                if (txtDiezCentimos.Text.Trim() == string.Empty)
                {
                    diezCen = 0;
                }else
                {
                    diezCen = Convert.ToInt32(txtDiezCentimos.Text.Trim());
                }

                if (txtVeinteCentimos.Text.Trim() == string.Empty)
                {
                    veinteCen = 0;
                }
                else
                {
                    veinteCen = Convert.ToInt32(txtVeinteCentimos.Text.Trim());
                }

                if (txtCincuentaCentimos.Text.Trim() == string.Empty)
                {
                    cincuentaCen = 0;
                }
                else
                {
                    cincuentaCen = Convert.ToInt32(txtCincuentaCentimos.Text.Trim());
                }

                if (txtUnSol.Text.Trim() == string.Empty)
                {
                    unSol = 0;
                }
                else
                {
                    unSol = Convert.ToInt32(txtUnSol.Text.Trim());
                }

                if (txtDosSoles.Text.Trim() == string.Empty)
                {
                    dosSoles = 0;
                }
                else
                {
                    dosSoles = Convert.ToInt32(txtDosSoles.Text.Trim());
                }

                if (txtCincoSoles.Text.Trim() == string.Empty)
                {
                    cincoSoles = 0;
                }
                else
                {
                    cincoSoles = Convert.ToInt32(txtCincoSoles.Text.Trim());
                }

                if (txtDiezSoles.Text.Trim() == string.Empty)
                {
                    diezSoles = 0;
                }
                else
                {
                    diezSoles = Convert.ToInt32(txtDiezSoles.Text.Trim());
                }

                if (txtVeinteSoles.Text.Trim() == string.Empty)
                {
                    veinteSoles = 0;
                }
                else
                {
                    veinteSoles = Convert.ToInt32(txtVeinteSoles.Text.Trim());
                }

                if (txtCincuentaSoles.Text.Trim() == string.Empty)
                {
                    cincuentaSoles = 0;
                }
                else
                {
                    cincuentaSoles = Convert.ToInt32(txtCincuentaSoles.Text.Trim());
                }

                if (txtCienSoles.Text.Trim() == string.Empty)
                {
                    cienSoles = 0;
                }
                else
                {
                    cienSoles = Convert.ToInt32(txtCienSoles.Text.Trim());
                }

                if (txtDoscientoSoles.Text.Trim() == string.Empty)
                {
                    doscientosSoles = 0;
                }
                else
                {
                    doscientosSoles = Convert.ToInt32(txtDoscientoSoles.Text.Trim());
                }

                string rpta1=NDetalleCaja.Insertar(Convert.ToInt32(rpta), diezCen, veinteCen,cincuentaCen, unSol, dosSoles,cincoSoles,diezSoles, veinteSoles,cincuentaSoles, cienSoles, doscientosSoles);
                if(rpta1 == "OK")
                {
                    MessageBox.Show("Se cerró la caja");
                    NImprimirCierreTurno.imprimirCaja(this.lblTrabajador.Text, lblfechaApert.Text, DateTime.Now,lblMontoInicial.Text,txtVentaEfectivo.Text,txtOtrosIngresos.Text,txtEgresos.Text,
                        lblTotalCaja.Text,lblToVentas.Text,txtTarjeta.Text,txtTickets.Text,txtBoletas.Text,txtFacturas.Text,lblTotalParcial.Text);
                    Application.Exit();
                   
                }else
                {
                    MessageBox.Show(rpta1);
                }
             
            }else
            {
                MessageBox.Show(rpta);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmMovimientoCaja frm = new frmMovimientoCaja();
            frm.lblFechaApertura.Text = this.lblfechaApert.Text;
            frm.ShowDialog();
        }

        private void mostrarTotalBilletes()
        {
            decimal totalMoneda = 00.00m, totalArqueo = 00.00m, totalBilletes = 00.00m;
            decimal diezSoles, veinteSoles, cincuentaSoles, cienSoles, doscientosSoles;
            if (txtDiezSoles.Text.Trim() == string.Empty)
            {
                diezSoles = 00.00m;
                lblImpDiezSoles.Text = "00.00";
            }
            else
            {
                diezSoles = 10 * Convert.ToDecimal(this.txtDiezSoles.Text.Trim());
                lblImpDiezSoles.Text = (10 * Convert.ToDecimal(this.txtDiezSoles.Text.Trim())).ToString();
            }

            if (txtVeinteSoles.Text.Trim() == string.Empty)
            {
                veinteSoles = 00.00m;
                lblImpVeinteSoles.Text = "00.00";
            }
            else
            {
                veinteSoles = 20 * Convert.ToDecimal(this.txtVeinteSoles.Text.Trim());
                lblImpVeinteSoles.Text = (20 * Convert.ToDecimal(this.txtVeinteSoles.Text.Trim())).ToString();
            }

            if (txtCincuentaSoles.Text.Trim() == string.Empty)
            {
                cincuentaSoles = 00.00m;
                lblImpCincuentaSoles.Text = "00.00";
            }
            else
            {
                cincuentaSoles = 50 * Convert.ToDecimal(this.txtCincuentaSoles.Text.Trim());
                lblImpCincuentaSoles.Text = (50 * Convert.ToDecimal(this.txtCincuentaSoles.Text.Trim())).ToString();
            }

            if (txtCienSoles.Text.Trim() == string.Empty)
            {
                cienSoles = 00.00m;
                lblImpCienSoles.Text = "00.00";
            }
            else
            {
                cienSoles = 100 * Convert.ToDecimal(this.txtCienSoles.Text.Trim());
                lblImpCienSoles.Text = (100 * Convert.ToDecimal(this.txtCienSoles.Text.Trim())).ToString();
            }

            if (txtDoscientoSoles.Text.Trim() == string.Empty)
            {
                doscientosSoles = 00.00m;
                lblImpDoscientosSoles.Text = "00.00";
            }
            else
            {
                doscientosSoles = 200 * Convert.ToDecimal(this.txtDoscientoSoles.Text.Trim());
                lblImpDoscientosSoles.Text = (200 * Convert.ToDecimal(this.txtDoscientoSoles.Text.Trim())).ToString();
            }


            totalBilletes = diezSoles + veinteSoles + cincuentaSoles + cienSoles + doscientosSoles ;
            totalMoneda = Convert.ToDecimal(this.lblTotalMonedas.Text);
            totalArqueo = totalBilletes + totalMoneda;
            this.lblTotalArqueo.Text = totalArqueo.ToString();

            this.lblTotalBilletes.Text = totalBilletes.ToString();

        }
        private void mostrarTotalMonedas()
        {
            decimal totalMoneda = 00.00m, totalArqueo = 00.00m, totalBilletes = 00.00m;
            decimal diezCen,veinteCen,cincuentaCen,unSol,dosSoles,cincoSoles;
            if(txtDiezCentimos.Text.Trim() == string.Empty)
            {
                diezCen = 00.00m;
                lblImpDiezC.Text = "00.00";
            }else
            {
                diezCen = 0.10m * Convert.ToDecimal(this.txtDiezCentimos.Text.Trim());
                lblImpDiezC.Text = (0.10m * Convert.ToDecimal(this.txtDiezCentimos.Text.Trim())).ToString();
                
            }

            if (txtVeinteCentimos.Text.Trim() == string.Empty)
            {
                veinteCen = 00.00m;
                lblImpVeinteC.Text = "00.00";
            }
            else
            {
                veinteCen = 0.20m * Convert.ToDecimal(this.txtVeinteCentimos.Text.Trim());
                lblImpVeinteC.Text = (0.20m * Convert.ToDecimal(this.txtVeinteCentimos.Text.Trim())).ToString();
            }

            if (txtCincuentaCentimos.Text.Trim() == string.Empty)
            {
                cincuentaCen = 00.00m;
                lblImpCincuentaC.Text = "00.00";
            }
            else
            {
                cincuentaCen = 0.50m * Convert.ToDecimal(this.txtCincuentaCentimos.Text.Trim());
                lblImpCincuentaC.Text = (0.50m * Convert.ToDecimal(this.txtCincuentaCentimos.Text.Trim())).ToString();
            }

            if (txtUnSol.Text.Trim() == string.Empty)
            {
                unSol = 00.00m;
                lblImpUnSol.Text = "00.00";
            }
            else
            {
                unSol = 1 * Convert.ToDecimal(this.txtUnSol.Text.Trim());
                lblImpUnSol.Text = (1 * Convert.ToDecimal(this.txtUnSol.Text.Trim())).ToString();
            }

            if (txtDosSoles.Text.Trim() == string.Empty)
            {
                dosSoles = 00.00m;
                lblImpDosSoles.Text = "00.00";
            }
            else
            {
                dosSoles = 2 * Convert.ToDecimal(this.txtDosSoles.Text.Trim());
                lblImpDosSoles.Text = (2 * Convert.ToDecimal(this.txtDosSoles.Text.Trim())).ToString();
            }

            if (txtCincoSoles.Text.Trim() == string.Empty)
            {
                cincoSoles = 00.00m;
            }
            else
            {
                cincoSoles = 5 * Convert.ToDecimal(this.txtCincoSoles.Text.Trim());
                lblImpCincoSoles.Text = (5 * Convert.ToDecimal(this.txtCincoSoles.Text.Trim())).ToString();
            }

            totalMoneda = diezCen + veinteCen + cincuentaCen + unSol + dosSoles + cincoSoles;
            totalBilletes = Convert.ToDecimal(this.lblTotalBilletes.Text);
            totalArqueo = totalBilletes + totalMoneda;
            this.lblTotalArqueo.Text = totalArqueo.ToString();

            this.lblTotalMonedas.Text = totalMoneda.ToString();

        }
        private void txtDiezCentimos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
                e.Handled = true;
                return;
            }

        }

        private void txtDiezCentimos_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotalMonedas();
        }

        private void txtVeinteCentimos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtVeinteCentimos_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotalMonedas();
        }

        private void txtCincuentaCentimos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtCincuentaCentimos_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotalMonedas();
        }

        private void txtUnSol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtUnSol_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotalMonedas();
        }

        private void txtDosSoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtDosSoles_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotalMonedas();
        }

        private void txtCincoSoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtCincoSoles_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotalMonedas();
        }

        private void txtDiezSoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtDiezSoles_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotalBilletes();
        }

        private void txtVeinteSoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtVeinteSoles_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotalBilletes();
        }

        private void txtCincuentaSoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtCincuentaSoles_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotalBilletes();
        }

        private void txtCienSoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtCienSoles_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotalBilletes();
        }

        private void txtDoscientoSoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtDoscientoSoles_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotalBilletes();
        }

        private void frmCierreCaja_FormClosed(object sender, FormClosedEventArgs e)
        {
         
        }
    }
}
