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
    public partial class frmCorteParcial : Form
    {
        public frmCorteParcial()
        {
            InitializeComponent();
        }

        public void ingresosEfectivo()
        {
            DataTable dt;
            dt = NTurno.MostrarIngresosEfectivoTurno(1, Convert.ToDateTime(this.lblfechaApert.Text), DateTime.Now);
            if (dt.Rows[0]["Monto"].ToString() == "")
            {
                this.txtVentaEfectivo.Text = "00.00";
            }
            else
            {
                this.txtVentaEfectivo.Text = dt.Rows[0]["Monto"].ToString();
                this.txtVentaEfectivo.Text = string.Format("{0:#,##0.00}", Convert.ToDouble(this.txtVentaEfectivo.Text));
            }

            //cuenta_usuario.idCliente(txtUsuario.Text, txtContraseña.Text);
            // dt.Rows[0]["Estado"].ToString();
        }

        public void ingresosTarjeta()
        {
            DataTable dt;
            dt = NTurno.MostrarIngresosTarjetaTurno(1, Convert.ToDateTime(this.lblfechaApert.Text), DateTime.Now);
            if (dt.Rows[0]["Monto"].ToString() == "")
            {
                this.txtTarjeta.Text = "00.00";
            }
            else
            {
                this.txtTarjeta.Text = dt.Rows[0]["Monto"].ToString();
                this.txtTarjeta.Text = string.Format("{0:#,##0.00}", Convert.ToDouble(this.txtTarjeta.Text));
            }
        }


        public void total()
        {
            decimal ventasEfectivo = 00.00m;
            decimal ventasTarjeta = 00.00m;
            decimal otrosIngresos = 00.00m;
            decimal egresos = 00.00m;
            decimal totalVentas = 00.00m;
            decimal totalParcial = 00.00m;
            decimal totalCaja = 00.00m;
            decimal montoApertura = 00.00m;

            ventasEfectivo = Convert.ToDecimal(txtVentaEfectivo.Text.Trim());
            ventasTarjeta = Convert.ToDecimal(txtTarjeta.Text.Trim());
            otrosIngresos = Convert.ToDecimal(txtOtrosIngresos.Text.Trim());
            egresos = Convert.ToDecimal(txtEgresos.Text);
            montoApertura = Convert.ToDecimal(lblMontoInicial.Text);
            totalParcial = ventasEfectivo + otrosIngresos - egresos;
            totalCaja = totalParcial + montoApertura;
            totalVentas = ventasEfectivo + ventasTarjeta;
            lblTotalParcial.Text = totalParcial.ToString();
            lblTotalCaja.Text = totalCaja.ToString();
            lblTotalVentas.Text = totalVentas.ToString();

        }

        //cuenta_usuario.idCliente(txtUsuario.Text, txtContraseña.Text);
        // dt.Rows[0]["Estado"].ToString();

        public void egresos()
        {
            DataTable dt;
            dt = NTurno.MostrarEgresosTurno(1, Convert.ToDateTime(this.lblfechaApert.Text), DateTime.Now);
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
            dt = NTurno.MostrarVentasTurno(Convert.ToDateTime(this.lblfechaApert.Text), DateTime.Now);
            if(dt.Rows[0][0].ToString() != "")
            {
                this.txtEnEfectivo.Text = dt.Rows[0][0].ToString();
                this.txtVentaEfectivo.Text = dt.Rows[0][0].ToString();
            }
            else
            {
                this.txtEnEfectivo.Text= "00.00";
                this.txtVentaEfectivo.Text = "00.00";
            }

            if (dt.Rows[1][0].ToString() != "")
            {
                this.txtTarjeta.Text = dt.Rows[1][0].ToString();
            }
            else
            {
                this.txtTarjeta.Text = "00.00";
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
                this.txtEgresos.Text = dt.Rows[4][0].ToString();
            }
            else
            {
                this.txtEgresos.Text = "00.00";
            }
            //cuenta_usuario.idCliente(txtUsuario.Text, txtContraseña.Text);
            // dt.Rows[0]["Estado"].ToString();
            this.total();
        }

        private void frmCierreTurno_Load(object sender, EventArgs e)
        {
           this.Top = 0;
            this.Left = 0;
            this.ventas();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            //rpta = NCaja_A.Insertar(Convert.ToInt32(this.lblidUsuario.Text), "Caja 1", DateTime.Now, Convert.ToDecimal(this.lblTotalEfectivo.Text), "Cerrada", 1);
            //  rpta = NTurno.Insertar(Convert.ToInt32(this.lblidUsuario.Text),DateTime.Now,)
            //rpta = NTurno.Insertar(Convert.ToInt32(this.lblidUsuario.Text), DateTime.Now, Convert.ToDecimal(this.txtVentaEfectivo.Text), "Cerrado", Convert.ToDecimal(this.txtTarjeta.Text),
            //  Convert.ToDecimal(this.txtEgresos.Text));
            DateTime? fechaApertura = null;
            rpta = NCaja_A.Insertar(Convert.ToInt32(this.lblidUsuario.Text), "Caja 1", DateTime.Now, Convert.ToDecimal(lblTotalCaja.Text), "Corte Caja", 1, Convert.ToDecimal(txtTarjeta.Text),
                Convert.ToDecimal(txtEgresos.Text), Convert.ToDecimal(txtOtrosIngresos.Text), Convert.ToDecimal(txtVentaEfectivo.Text), Convert.ToDecimal(lblMontoInicial.Text),fechaApertura);
            if (rpta != "OK")
            {
                MessageBox.Show("Se registró correctamente");
                //Application.Exit();
                NImprimirCierreTurno.imprimirCom(lblTrabajador.Text, lblfechaApert.Text, DateTime.Now, lblMontoInicial.Text, txtVentaEfectivo.Text, txtOtrosIngresos.Text, txtEgresos.Text,
                    lblTotalCaja.Text, lblNroVentas.Text, txtTarjeta.Text, lblTotalParcial.Text);
                this.Hide();
                frmPrincipal.f1.ValidarAcceso();
                frmPrincipal.f1.ValidarControlesR();
                
            }
            else
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

        private void frmCierreTurno_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void frmCierreTurno_FormClosed(object sender, FormClosedEventArgs e)
        {
     
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
