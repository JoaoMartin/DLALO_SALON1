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
    public partial class frmPagar : Form
    {
        public static frmPagar f1;
        private string formaPago;
        private decimal efectivo, tarjeta;
        private string efectivo1, vuelto1, tarjeta1, formaPago1, modoProd;
        private DataTable dtDetalleR;
        
        public frmPagar()
        {
            InitializeComponent();
            frmPagar.f1 = this;
        }
        private void Deshabilitado()
        {
            this.btnDescuentoTotal.Visible = false;

        }
        private void ValidarAcceso()
        {
            this.Deshabilitado();
            DataTable dtIdTipoTrabajador = NTipoTrabajador.MostrarIdTipoUsuario(Convert.ToInt32(this.lblIdUsuario.Text));
            DataTable dtNivel = NNivel.Mostrar(Convert.ToInt32(dtIdTipoTrabajador.Rows[0][0].ToString()));
            for (int i = 0; i < dtNivel.Rows.Count; i++)
            {
                if (dtNivel.Rows[i][2].ToString() == "Venta-Dcto General")
                {
                    this.btnDescuentoTotal.Visible = true;
                }
 
            }
        }

        private void frmPagar_Load(object sender, EventArgs e)
        {
            if(lblBanderaCobro.Text == "1")
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                btnTicket.Enabled = false;
                btnBoleta.Enabled = false;
                btnFactura.Enabled = false;
                lblVuelto.Text = "Saldo";
            }
            else
            {
                lblVuelto.Text = "Vuelto";
            }

            if(lblBanderaCobro.Text == "3")
            {
                this.gbRecoge.Visible = true;
                dataDetalleReserva.DataSource = NVenta.reporteDetalleVenta(Convert.ToInt32(lblIdVenta.Text));
                mostrarTotalesReserva();
                lblAdelanto.Visible = true;
                lblSAdelanto.Visible = true;
                lblMontoAdelanto.Visible = true;
                dtDetalleR= NVenta.reporteDetalleVenta(Convert.ToInt32(lblIdVenta.Text));

            }
            else
            {
                this.gbRecoge.Visible = false;
            }
            this.txtEfectivo.Focus();
            this.ValidarAcceso();
            this.txtEfectivo.Select();
        }
            
        private void mostrarTotalesReserva()
        {
            decimal total = 00.00m, subtotal = 00.00m, igv = 00.00m, dctoInd = 00.00m, totalCA = 00.00m, adelanto = 00.00m;
            for(int i = 0; i < dataDetalleReserva.Rows.Count; i++)
            {
                total = total + Convert.ToDecimal(dataDetalleReserva.Rows[i].Cells["Importe"].Value.ToString());
                dctoInd = dctoInd + Convert.ToDecimal(dataDetalleReserva.Rows[i].Cells["Dcto"].Value.ToString());
            }
            subtotal = (total - dctoInd)/1.18m;
            lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(subtotal));

            igv = total - subtotal;
            lblIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(igv));
            lblDescuento.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(dctoInd));
            adelanto = Convert.ToDecimal(this.lblMontoAdelanto.Text);
            totalCA = total - adelanto;
            lblTotalReal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(total));
            lblTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalCA));
        }
        private void enviarFormaPago()
        {
            if (rbTarjeta.Checked)
            {
                efectivo1 = "TARJETA";
                tarjeta1 = lblTotal.Text;
                vuelto1 = "00.00";
                formaPago1 = "TARJETA";
            }
            else if (rbEfectivo.Checked)
            {
                efectivo1 = this.txtEfectivo.Text.Trim();
                tarjeta1 = "00.00";
                vuelto1 = this.txtVuelto.Text.Trim();
                formaPago1 = "EFECTIVO";
            }
            else if (rbMixto.Checked)
            {
                efectivo1 = this.txtEfectivo.Text.Trim();
                tarjeta1 = this.txtTarjeta.Text.Trim();
                vuelto1 = "00.00";
                formaPago1 = "MIXTO";
            }
            if (rbDetallado.Checked)
            {
                modoProd = "Detallado";
            }
            else if (rbConsumo.Checked)
            {
                modoProd = "Por Consumo";
            }
        }
       
        public void Facturador(int idVenta, DataTable dtDetalle)
        {
            if(this.lblBanderaComprobante.Text != "0")
            {
                enviarFormaPago();
                int? tipoDoc;
                string cantidad, codigo, descr, valorUnitario, dcto, importe, nroDoc,nombre;
                decimal igvUn, afecIgv, valUn;

                if (this.txtDocumento.Text.Length == 8)
                {
                    tipoDoc = 1;
                    nroDoc = this.txtDocumento.Text.Trim();
                    
                }
                else if (this.txtDocumento.Text.Length == 11)
                {
                    tipoDoc = 6;
                    nroDoc = this.txtDocumento.Text.Trim();
                }
                else
                {
                    tipoDoc = 1;
                    nroDoc = "0";
                }

                if(this.txtNombre.Text == string.Empty)
                {
                    nombre = "SIN DNI";
                }else
                {
                    nombre = this.txtNombre.Text.Trim();
                }


                string tipoCompr = "";
                if (this.lblBanderaComprobante.Text == "1")
                {
                    tipoCompr = "BOLETA";
                }
                else if (this.lblBanderaComprobante.Text == "2")
                {
                    tipoCompr = "FACTURA";
                }

                NFacturador.registrarComprobanteCabecera("01", DateTime.Now.ToString("yyyy-MM-dd"), "", tipoDoc, nroDoc,nombre, "PEN", this.lblDctoGeneral.Text.Trim(),
                    "0.00", this.lblDctoGeneral.Text.Trim(), this.lblSubTotal.Text.Trim(), "0.00", "0.00", this.lblIgv.Text.Trim(), "0.00", "0.00", this.lblTotal.Text, tipoCompr, idVenta);

                for (int i = 0; i <dtDetalle.Rows.Count; i++)
                {
                    cantidad = dtDetalle.Rows[i]["Cant"].ToString();
                    codigo = dtDetalle.Rows[i]["Cod"].ToString();
                    descr = dtDetalle.Rows[i]["Descripcion"].ToString();
                    valorUnitario = dtDetalle.Rows[i]["Precio_Un"].ToString();
                    valUn = Convert.ToDecimal(valorUnitario);
                    dcto = dtDetalle.Rows[i]["Descuento"].ToString();
                    igvUn = Convert.ToDecimal(valorUnitario) * (18 / 100);
                    afecIgv = (Convert.ToDecimal(cantidad) * Convert.ToDecimal(valorUnitario)) * 0.18m;
                    importe = dtDetalle.Rows[i]["Importe"].ToString();

                    decimal mtoDsctoItem = Convert.ToDecimal(dcto) / Convert.ToDecimal(cantidad);
                    decimal mtoPrecioVentaItem = Decimal.Round((Convert.ToDecimal(importe) / 1.18m),2) ;
                    decimal mtoIgvItem = Convert.ToDecimal(importe) - mtoPrecioVentaItem;
                    decimal mtoValorUnitario = mtoPrecioVentaItem / Convert.ToDecimal(cantidad);
         

                    NFacturador.registrarComprobanteDetalle("NIU", cantidad, codigo, "", descr, mtoValorUnitario.ToString("#0.00#"), mtoDsctoItem.ToString("#0.00#"), mtoIgvItem.ToString("#0.00#"), "10","0.00", "",
                        mtoPrecioVentaItem.ToString("#0.00#"),importe, tipoCompr, idVenta);
                }
            }
           
            
        }

        public void FacturadorR(int idVenta, DataTable dtDetalle)
        {
            if (this.lblBanderaComprobante.Text != "0")
            {
                enviarFormaPago();
                int? tipoDoc;
                string cantidad, codigo, descr, valorUnitario, dcto, importe, nroDoc, nombre;
                decimal igvUn, afecIgv, valUn;

                if (this.txtDocumento.Text.Length == 8)
                {
                    tipoDoc = 1;
                    nroDoc = this.txtDocumento.Text.Trim();

                }
                else if (this.txtDocumento.Text.Length == 11)
                {
                    tipoDoc = 6;
                    nroDoc = this.txtDocumento.Text.Trim();
                }
                else
                {
                    tipoDoc = 1;
                    nroDoc = "0";
                }

                if (this.txtNombre.Text == string.Empty)
                {
                    nombre = "SIN DNI";
                }
                else
                {
                    nombre = this.txtNombre.Text.Trim();
                }


                string tipoCompr = "";
                if (this.lblBanderaComprobante.Text == "1")
                {
                    tipoCompr = "BOLETA";
                }
                else if (this.lblBanderaComprobante.Text == "2")
                {
                    tipoCompr = "FACTURA";
                }

                NFacturador.registrarComprobanteCabecera("01", DateTime.Now.ToString("yyyy-MM-dd"), "", tipoDoc, nroDoc, nombre, "PEN", this.lblDctoGeneral.Text.Trim(),
                    "0.00", this.lblDctoGeneral.Text.Trim(), this.lblSubTotal.Text.Trim(), "0.00", "0.00", this.lblIgv.Text.Trim(), "0.00", "0.00", this.lblTotalReal.Text, tipoCompr, idVenta);

                for (int i = 0; i < dtDetalle.Rows.Count; i++)
                {
                    cantidad = dtDetalle.Rows[i]["Cant"].ToString();
                    codigo = dtDetalle.Rows[i]["Cod_Producto"].ToString();
                    descr = dtDetalle.Rows[i]["Descr"].ToString();
                    valorUnitario = dtDetalle.Rows[i]["Precio"].ToString();
                    valUn = Convert.ToDecimal(valorUnitario);
                    dcto = dtDetalle.Rows[i]["Dcto"].ToString();
                    igvUn = Convert.ToDecimal(valorUnitario) * (18 / 100);
                    afecIgv = (Convert.ToDecimal(cantidad) * Convert.ToDecimal(valorUnitario)) * 0.18m;
                    importe = dtDetalle.Rows[i]["Importe"].ToString();

                    decimal mtoDsctoItem = Convert.ToDecimal(dcto) / Convert.ToDecimal(cantidad);
                    decimal mtoPrecioVentaItem = Decimal.Round((Convert.ToDecimal(importe) / 1.18m), 2);
                    decimal mtoIgvItem = Convert.ToDecimal(importe) - mtoPrecioVentaItem;
                    decimal mtoValorUnitario = mtoPrecioVentaItem / Convert.ToDecimal(cantidad);


                    NFacturador.registrarComprobanteDetalle("NIU", cantidad, codigo, "", descr, mtoValorUnitario.ToString("#0.00#"), mtoDsctoItem.ToString("#0.00#"), mtoIgvItem.ToString("#0.00#"), "10", "0.00", "",
                        mtoPrecioVentaItem.ToString("#0.00#"), importe, tipoCompr, idVenta);
                }
            }


        }

        private void mostrarTotales()
        {
            if(lblBanderaCobro.Text == "0" || lblBanderaCobro.Text == "3")
            {
                decimal total = Convert.ToDecimal(this.lblTotal.Text);
                decimal tarjeta;
                decimal efectivo = 0;
                if (rbEfectivo.Checked)
                {
                    if (this.txtEfectivo.Text != "")
                    {
                        efectivo = Convert.ToDecimal(this.txtEfectivo.Text);
                        decimal vuelto = efectivo - total;
                        this.txtVuelto.Text = vuelto.ToString();
                    }
                    else
                    {
                        this.txtVuelto.Text = string.Empty;
                    }
                }
                else if (rbTarjeta.Checked)
                {
                    this.txtEfectivo.Text = string.Empty;
                    this.txtTarjeta.Text = string.Empty;
                    this.txtVuelto.Text = string.Empty;
                }
                else if (rbMixto.Checked)
                {
                    if (this.txtEfectivo.Text != "")
                    {
                        efectivo = Convert.ToDecimal(this.txtEfectivo.Text);
                        tarjeta = total - efectivo;
                        this.txtTarjeta.Text = tarjeta.ToString();
                        this.txtVuelto.Text = string.Empty;
                    }
                    else
                    {
                        this.txtTarjeta.Text = string.Empty;
                    }

                }
            }else
            {
                decimal total = Convert.ToDecimal(this.lblTotal.Text);
                decimal tarjeta;
                decimal efectivo = 0;
                if (rbEfectivo.Checked)
                {
                    if (this.txtEfectivo.Text != "")
                    {
                        efectivo = Convert.ToDecimal(this.txtEfectivo.Text);
                        decimal vuelto = total - efectivo;
                        this.txtVuelto.Text = vuelto.ToString();
                    }
                    else
                    {
                        this.txtVuelto.Text = string.Empty;
                    }
                }

            }
            

        }



        private bool insertarCaja()
        {
            string rptaCaja = "";
            try
            {
                if (rbEfectivo.Checked == true)
                {
                    rptaCaja = NCaja.Insertar(Convert.ToInt32(this.lblIdUsuario.Text), "1", "Ingreso", Convert.ToDecimal(this.lblTotal.Text), "VENTA","EFECTIVO");
                    if (rptaCaja == "OK")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                   
                }
                else if(rbTarjeta.Checked == true)
                {
                    rptaCaja = NCaja.Insertar(Convert.ToInt32(this.lblIdUsuario.Text), "1", "Ingreso", Convert.ToDecimal(this.lblTotal.Text),  "VENTA", "TARJETA");
                    if (rptaCaja == "OK")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if(rbMixto.Checked == true)
                {
                    rptaCaja = NCaja.Insertar(Convert.ToInt32(this.lblIdUsuario.Text), "1", "Ingreso", Convert.ToDecimal(this.txtEfectivo.Text),"VENTA", "EFECTIVO");
                    rptaCaja = NCaja.Insertar(Convert.ToInt32(this.lblIdUsuario.Text), "1", "Ingreso", Convert.ToDecimal(this.txtTarjeta.Text), "VENTA", "TARJETA");
                    if (rptaCaja == "OK")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            return true;
        }

        private bool verMontosPago()
        {
            if(rbEfectivo.Checked == true)
            {
                efectivo = Convert.ToDecimal(this.lblTotal.Text);
                tarjeta = 00.00m;
                return true;
            }
            else if(rbTarjeta.Checked == true)
            {
                efectivo = 00.00m;
                tarjeta = Convert.ToDecimal(this.lblTotal.Text);
                return true;
            }
            else if(rbMixto.Checked == true)
            {
                if(this.txtEfectivo.Text.Trim().Equals(string.Empty) || this.txtTarjeta.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Complete el campo efectivo y/o tarjeta");
                    return false;
                }
                else
                {
                    if(Convert.ToDecimal(this.lblTotal.Text)>(Convert.ToDecimal(this.txtEfectivo.Text) + Convert.ToDecimal(this.txtTarjeta.Text)))
                    {
                        MessageBox.Show("Los monto son menores al total, complete los campos");
                        return false;
                    }
                    else
                    {
                        efectivo = Convert.ToDecimal(this.txtEfectivo.Text.Trim());
                        tarjeta = Convert.ToDecimal(this.txtTarjeta.Text.Trim());
                    }

                }

            }
            return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text += "1";

                mostrarTotales();
                this.dataListadoProducto.Select();
              
            }
            else if (this.lblBanderaTexto.Text == "1")
            {
                this.txtTarjeta.Text += "1";
                this.dataListadoProducto.Select();
            }
        }

        private void txtTarjeta_Click(object sender, EventArgs e)
        {
            this.lblBanderaTexto.Text = "1";
        }

        private void txtEfectivo_Click(object sender, EventArgs e)
        {
            this.lblBanderaTexto.Text = "0";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text += "2";
                mostrarTotales();
                this.dataListadoProducto.Select();
            }
            else if (this.lblBanderaTexto.Text == "1")
            {
                this.txtTarjeta.Text += "2";
                this.dataListadoProducto.Select();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text += "3";
                mostrarTotales();
                this.dataListadoProducto.Select();
            }
            else if (this.lblBanderaTexto.Text == "1")
            {
                this.txtTarjeta.Text += "3";
                this.dataListadoProducto.Select();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text += "4";
                mostrarTotales();
                this.dataListadoProducto.Select();
            }
            else if (this.lblBanderaTexto.Text == "1")
            {
                this.txtTarjeta.Text += "4";
                this.dataListadoProducto.Select();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text += "5";
                mostrarTotales();
                this.dataListadoProducto.Select();
            }
            else if (this.lblBanderaTexto.Text == "1")
            {
                this.txtTarjeta.Text += "5";
                this.dataListadoProducto.Select();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text += "6";
                mostrarTotales();
                this.dataListadoProducto.Select();
            }
            else if (this.lblBanderaTexto.Text == "1")
            {
                this.txtTarjeta.Text += "6";
                this.dataListadoProducto.Select();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text += "7";
                mostrarTotales();
                this.dataListadoProducto.Select();
            }
            else if (this.lblBanderaTexto.Text == "1")
            {
                this.txtTarjeta.Text += "7";
                this.dataListadoProducto.Select();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text += "8";
                mostrarTotales();
                this.dataListadoProducto.Select();
            }
            else if (this.lblBanderaTexto.Text == "1")
            {
                this.txtTarjeta.Text += "8";
                this.dataListadoProducto.Select();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text += "9";
                mostrarTotales();
                this.dataListadoProducto.Select();
            }
            else if (this.lblBanderaTexto.Text == "1")
            {
                this.txtTarjeta.Text += "9";
                this.dataListadoProducto.Select();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text += ".";
                mostrarTotales();
                this.dataListadoProducto.Select();
            }
            else if (this.lblBanderaTexto.Text == "1")
            {
                this.txtTarjeta.Text += ".";
                this.dataListadoProducto.Select();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text += "0";
                mostrarTotales();
                this.dataListadoProducto.Select();
            }
            else if (this.lblBanderaTexto.Text == "1")
            {
                this.txtTarjeta.Text += "0";
                this.dataListadoProducto.Select();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {

            if (this.lblBanderaTexto.Text == "0")
            {
               
                if (this.txtEfectivo.Text.Length == 1)
                {
                    this.txtEfectivo.Text = string.Empty;
                }
                else if (this.txtEfectivo.Text.Length != 0)
                {
                    this.txtEfectivo.Text = this.txtEfectivo.Text.Substring(0, this.txtEfectivo.Text.Length - 1);

                }
                mostrarTotales();
                this.dataListadoProducto.Select();

            }
            else if (this.lblBanderaTexto.Text == "1")
            {
                if (this.txtTarjeta.Text.Length == 1)
                {
                    this.txtTarjeta.Text = string.Empty;
                    this.dataListadoProducto.Select();
                }
                else if (this.txtTarjeta.Text.Length != 0)
                {
                    this.txtTarjeta.Text = this.txtTarjeta.Text.Substring(0, this.txtTarjeta.Text.Length - 1);
                    this.dataListadoProducto.Select();
                }


            }
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            if (!(char.IsNumber(e.KeyChar)) && !(e.KeyChar == '.'))
            {
                e.Handled = true;
                return;
            }
            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtEfectivo.Text.Length; i++)
            {
                if (txtEfectivo.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;


 
        }

        private void txtTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            if (!(char.IsNumber(e.KeyChar)) && !(e.KeyChar == '.'))
            {
                e.Handled = true;
                return;
            }
            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtTarjeta.Text.Length; i++)
            {
                if (txtTarjeta.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void txtEfectivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                if (this.lblBanderaCobro.Text == "0")
                {
                    Cobrar();
                }
                else if(this.lblBanderaCobro.Text == "3")
                {
                    CobrarReserva();
                }else
                {
                    CobrarAdelanto();
                }


            }
        }

        private void txtEfectivo_KeyUp(object sender, KeyEventArgs e)
        {

            mostrarTotales();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void CobrarReserva()
        {
            decimal efectivo, total, vuelto;
            if (this.txtEfectivo.Text.Trim() == "")
            {
                efectivo = 0;
            }
            else
            {
                efectivo = Convert.ToDecimal(this.txtEfectivo.Text.Trim());
            }



            total = Convert.ToDecimal(this.lblTotal.Text);

            if ((efectivo < total) && (rbEfectivo.Checked == true))
            {
                MessageBox.Show("El efectivo es insuficiente");
                this.txtEfectivo.Focus();
            }
            else
            {
                int? idCliente = null;
                if (this.txtIdCliente.Text != string.Empty)
                {
                    idCliente = Convert.ToInt32(this.txtIdCliente.Text);
                }
                else
                {
                    idCliente = null;
                }

                if (txtVuelto.Text == string.Empty)
                {
                    vuelto = 00.00m;
                }
                else
                {
                    vuelto = Convert.ToDecimal(this.txtVuelto.Text);
                }

                if (this.lblIdVenta.Text != "0")
                {
                    try
                    {
                        if (this.txtEfectivo.Text == "" && (this.rbEfectivo.Checked == true || this.rbMixto.Checked == true))
                        {
                            MessageBox.Show("El campo efectivo es obligatorio");
                        }
                        else
                        {
                            string rpta = "";
                            string rpta1 = "";

                            if (verMontosPago() == true)
                            {
                                this.verMontosPago();
                                this.verFormaPago();
                                if (this.lblBanderaComprobante.Text == "0" || this.lblBanderaComprobante.Text == "1")
                                {
                                        
                                            
                                            for (int p = 0; p < dataDetalleReserva.Rows.Count; p++)
                                            {
                                                if (dataDetalleReserva.Rows[p].Cells["Tipo"].Value.ToString() == "C")
                                                {

                                                    DataTable dtDetalleProducto = new DataTable();
                                                    dtDetalleProducto = NProducto.mostrarDetalleProducto_Venta(Convert.ToInt32(dataDetalleReserva.Rows[p].Cells["Cod_Producto"].Value.ToString()));
                                                    int cantPedido = Convert.ToInt32(dataDetalleReserva.Rows[p].Cells["Cant"].Value.ToString());
                                                    for (int j = 0; j < dtDetalleProducto.Rows.Count; j++)
                                                    {
                                                        int idProducto_Com = Convert.ToInt32(dtDetalleProducto.Rows[j][0].ToString());
                                                        int cantRequerida = Convert.ToInt32(dtDetalleProducto.Rows[j][1].ToString());

                                                        NProducto.EditarStock(idProducto_Com, cantRequerida * cantPedido);
                                                    }

                                                }
                                        NDetalleVenta.EditarStockProductoR(Convert.ToInt32(Convert.ToInt32(dataDetalleReserva.Rows[p].Cells["Cant"].Value.ToString())),
                                            Convert.ToInt32(dataDetalleReserva.Rows[p].Cells["idProducto"].Value.ToString()));
                                            }


                                    string estadoR = "";
                                    if(rbRecojo.Checked == true)
                                    {
                                        estadoR = "PAGADA-RECOGIDA";
                                    }else
                                    {
                                        estadoR = "PAGADA-R";
                                    }

                                    rpta = NVenta.EditarVentaCanceladaR(Convert.ToInt32(this.lblIdVenta.Text),estadoR);
                                    
                                    if (rpta == "OK")
                                    {
                                        string formaPago = "";
                                        decimal pagoEfectivo = 00.00m, pagoTarjeta = 00.00m;
                                        if (rbEfectivo.Checked == true)
                                        {
                                            formaPago = "EFECTIVO";
                                            pagoEfectivo = Convert.ToDecimal(this.lblTotal.Text);
                                            pagoTarjeta = 00.00m;
                                        }
                                        else if (rbTarjeta.Checked == true)
                                        {
                                            formaPago = "TARJETA";
                                            pagoEfectivo = 00.00m;
                                            pagoTarjeta = Convert.ToDecimal(this.lblTotal.Text);
                                        }
                                        else if (rbMixto.Checked == true)
                                        {
                                            formaPago = "MIXTO";
                                            pagoEfectivo = Convert.ToDecimal(this.txtEfectivo.Text);
                                            pagoTarjeta = Convert.ToDecimal(this.txtTarjeta.Text);
                                        }

                                        string tipoCompr = "";
                                        if (this.lblBanderaComprobante.Text == "0")
                                        {
                                            tipoCompr = "TICKET";
                                        }
                                        else if (this.lblBanderaComprobante.Text == "1")
                                        {
                                            tipoCompr = "BOLETA";
                                        }
                                        else
                                        {
                                            tipoCompr = "FACTURA";
                                        }

                                        rpta1 = NComprobante.Insertar(tipoCompr, 1, Convert.ToDecimal(this.lblIgv.Text), DateTime.Now, Convert.ToInt32(this.lblIdVenta.Text), "EMITIDA", idCliente,
                                                        Convert.ToDecimal(this.lblTotalReal.Text), pagoEfectivo, pagoTarjeta, 00.00m, formaPago, vuelto);
                                        if (rpta1 == "OK")
                                        {
                                            if (insertarCaja() == true)
                                            {
                                                // MessageBox.Show("Se registró correctamente");
                                              
                                                //frmModuloSalon.f3.limpiarMesas();
                                                //frmModuloSalon.f3.mostrarSalones();

                                                this.enviarFormaPago();

                                                NImprimir_Comprobante.imprimirComR(Convert.ToInt32(this.lblIdVenta.Text), tipoCompr, this.txtNombre.Text.Trim(), 
                                                    this.txtDireccion.Text.Trim(),this.txtDocumento.Text.Trim(),
                                             
                                                                         dataDetalleReserva, this.lblDescuento.Text, this.lblDctoGeneral.Text, this.lblSubTotal.Text,
                                                                         this.lblIgv.Text, this.lblTotalReal.Text, efectivo1, vuelto1, tarjeta1, formaPago1, modoProd, "00.00", "",
                                                                         lblMontoAdelanto.Text,frmPrincipal.f1.lblIdUsuario.Text+frmPrincipal.f1.lblApellidos.Text);


                                                this.FacturadorR(Convert.ToInt32(this.lblIdVenta.Text), dtDetalleR);
                                                frmVentasReservadas.f1.Mostrar();
                                                this.Close();
                                               

                                            }

                                        }
                                        else
                                        {
                                            MessageBox.Show(rpta1);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show(rpta);
                                    }


                                }
                                else
                                {

                                    if (this.txtIdCliente.Text != string.Empty && txtDocumento.Text.Trim().Length == 11)
                                    {




                                        for (int p = 0; p < dataDetalleReserva.Rows.Count; p++)
                                        {
                                            if (dataDetalleReserva.Rows[p].Cells["Tipo"].Value.ToString() == "C")
                                            {

                                                DataTable dtDetalleProducto = new DataTable();
                                                dtDetalleProducto = NProducto.mostrarDetalleProducto_Venta(Convert.ToInt32(dataDetalleReserva.Rows[p].Cells["Cod_Producto"].Value.ToString()));
                                                int cantPedido = Convert.ToInt32(dataDetalleReserva.Rows[p].Cells["Cant"].Value.ToString());
                                                for (int j = 0; j < dtDetalleProducto.Rows.Count; j++)
                                                {
                                                    int idProducto_Com = Convert.ToInt32(dtDetalleProducto.Rows[j][0].ToString());
                                                    int cantRequerida = Convert.ToInt32(dtDetalleProducto.Rows[j][1].ToString());

                                                    NProducto.EditarStock(idProducto_Com, cantRequerida * cantPedido);
                                                }

                                            }
                                            NDetalleVenta.EditarStockProductoR(Convert.ToInt32(Convert.ToInt32(dataDetalleReserva.Rows[p].Cells["Cant"].Value.ToString())),
                                                Convert.ToInt32(dataDetalleReserva.Rows[p].Cells["idProducto"].Value.ToString()));

                                            DataTable dtReceta = NReceta.Mostrar(Convert.ToInt32(dataDetalleReserva.Rows[p].Cells["Cod_Producto"].Value.ToString()));

                                            if (dtReceta.Rows.Count > 0)
                                            {
                                                int cantInsumo = Convert.ToInt32(dataDetalleReserva.Rows[p].Cells["Cant"].Value.ToString());
                                                decimal cantTotal;
                                                for (int k = 0; k < dtReceta.Rows.Count; k++)
                                                {
                                                    cantTotal = cantInsumo * Convert.ToDecimal(dtReceta.Rows[k][3].ToString());
                                                    NInsumo.EditarStock(Convert.ToInt32(dtReceta.Rows[k][0].ToString()), cantTotal);
                                                }

                                            }
                                        }




                                        //   rpta1= NFactura.Insertar(1, Convert.ToDecimal(this.lblIgv.Text), DateTime.Now, Convert.ToInt32(this.lblIdVenta.Text),"EMITIDA", Convert.ToInt32(this.lblIdMesa.Text));
                                        string estadoR = "";
                                        if (rbRecojo.Checked == true)
                                        {
                                            estadoR = "PAGADA-RECOGIDA";
                                        }
                                        else
                                        {
                                            estadoR = "PAGADA-R";
                                        }

                                        rpta = NVenta.EditarVentaCanceladaR(Convert.ToInt32(this.lblIdVenta.Text), estadoR);
                                        if (rpta == "OK")
                                        {
                                            string formaPago = "";
                                            decimal pagoEfectivo = 00.00m, pagoTarjeta = 00.00m;
                                            if (rbEfectivo.Checked == true)
                                            {
                                                formaPago = "EFECTIVO";
                                                pagoEfectivo = Convert.ToDecimal(this.lblTotal.Text);
                                                pagoTarjeta = 00.00m;
                                            }
                                            else if (rbTarjeta.Checked == true)
                                            {
                                                formaPago = "TARJETA";
                                                pagoEfectivo = 00.00m;
                                                pagoTarjeta = Convert.ToDecimal(this.lblTotal.Text);
                                            }
                                            else if (rbMixto.Checked == true)
                                            {
                                                formaPago = "MIXTO";
                                                pagoEfectivo = Convert.ToDecimal(this.txtEfectivo.Text);
                                                pagoTarjeta = Convert.ToDecimal(this.txtTarjeta.Text);
                                            }
                                            rpta1 = NComprobante.Insertar("FACTURA", 1, Convert.ToDecimal(this.lblIgv.Text), DateTime.Now, Convert.ToInt32(this.lblIdVenta.Text),
                                                "EMITIDA", Convert.ToInt32(this.txtIdCliente.Text), Convert.ToDecimal(this.lblTotalReal.Text), pagoEfectivo, pagoTarjeta, 00.00m, formaPago, vuelto);
                                            if (rpta1 == "OK")
                                            {
                                                if (insertarCaja() == true)
                                                {

                                                    // MessageBox.Show("Se registró correctamente");
                                                  
                                                    enviarFormaPago();
                                                    // this.imprimir(Convert.ToInt32(this.lblIdVenta.Text));


                                                    NImprimir_Comprobante.imprimirComR(Convert.ToInt32(this.lblIdVenta.Text), "FACTURA", this.txtNombre.Text.Trim(),
                                                        this.txtDireccion.Text.Trim(), this.txtDocumento.Text.Trim(),

                                                                             dataDetalleReserva, this.lblDescuento.Text, this.lblDctoGeneral.Text, this.lblSubTotal.Text,
                                                                             this.lblIgv.Text, this.lblTotalReal.Text, efectivo1, vuelto1, tarjeta1, formaPago1, modoProd, "00.00", "",
                                                                             lblMontoAdelanto.Text, frmPrincipal.f1.lblIdUsuario.Text + frmPrincipal.f1.lblApellidos.Text);


                                                    //this.imprimir(Convert.ToInt32(this.lblIdVenta.Text));
                                                    this.FacturadorR(Convert.ToInt32(this.lblIdVenta.Text), dtDetalleR);
                                                    frmVentasReservadas.f1.Mostrar();
                                                    this.Close();
                                                }

                                            }
                                            else
                                            {
                                                MessageBox.Show(rpta1);
                                            }

                                        }
                                        else
                                        {
                                            MessageBox.Show(rpta);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Seleccione un cliente o ingrese un numero de RUC correcto");
                                    }


                                }
                            }


                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.StackTrace);
                    }

                }

            }
        }

        private void CobrarAdelanto()
        {
            decimal efectivo, total, vuelto;
            if (this.txtEfectivo.Text.Trim() == "")
            {
                efectivo = 0;
            }
            else
            {
                efectivo = Convert.ToDecimal(this.txtEfectivo.Text.Trim());
            }



            total = Convert.ToDecimal(this.lblTotal.Text);

            if ((efectivo >= total) && (rbEfectivo.Checked == true))
            {
                MessageBox.Show("Seleccione la opción PAGO TOTAL");
                this.txtEfectivo.Focus();
            }
            else
            {
                int? idCliente = null;
                if (this.txtIdCliente.Text != string.Empty)
                {
                    idCliente = Convert.ToInt32(this.txtIdCliente.Text);
                }
                else
                {
                    idCliente = null;
                }

                if (txtVuelto.Text == string.Empty)
                {
                    vuelto = 00.00m;
                }
                else
                {
                    vuelto = Convert.ToDecimal(this.txtVuelto.Text);
                }

                if(lblIdVenta.Text =="0")
                {
                    try
                    {
                        if (this.txtEfectivo.Text == "" && (this.rbEfectivo.Checked == true || this.rbMixto.Checked == true))
                        {
                            MessageBox.Show("El campo efectivo es obligatorio");
                        }
                        else
                        {
                            if (verMontosPago() == true)
                            {
                                string formaPago = "";
                                decimal pagoEfectivo = 00.00m, pagoTarjeta = 00.00m;
                                if (rbEfectivo.Checked == true)
                                {
                                    formaPago = "EFECTIVO";
                                    pagoEfectivo = Convert.ToDecimal(this.lblTotal.Text);
                                    pagoTarjeta = 00.00m;
                                }
                                else if (rbTarjeta.Checked == true)
                                {
                                    formaPago = "TARJETA";
                                    pagoEfectivo = 00.00m;
                                    pagoTarjeta = Convert.ToDecimal(this.lblTotal.Text);
                                }
                                else if (rbMixto.Checked == true)
                                {
                                    formaPago = "MIXTO";
                                    pagoEfectivo = Convert.ToDecimal(this.txtEfectivo.Text);
                                    pagoTarjeta = Convert.ToDecimal(this.txtTarjeta.Text);
                                }
                                this.verFormaPago();
                                if (this.lblBanderaComprobante.Text == "0" || this.lblBanderaComprobante.Text == "1")
                                {
                                    string tipoCompr = "";
                                    if (this.lblBanderaComprobante.Text == "0")
                                    {
                                        tipoCompr = "TICKET";
                                    }
                                    else
                                    {
                                        tipoCompr = "BOLETA";
                                    }
                                    string rpta = "";
                                    /*
                                    rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "RESERVADA", formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text)
                                                                                , Convert.ToInt32(this.lblIdUsuario.Text), "CU", 1, tipoCompr, 1, Convert.ToDecimal(this.lblIgv.Text), "EMITIDA-R",
                                                                                Convert.ToDecimal(this.lblTotal.Text), pagoEfectivo, pagoTarjeta,
                                                                                00.00m, frmVenta.f1.dtDetalle, vuelto, frmVenta.f1.dtDetalleMenu,
                                                                                Convert.ToDateTime(this.lblFechaEntrega.Text),Convert.ToDecimal(this.txtEfectivo.Text), Convert.ToInt32(this.lblIdUsuario.Text),this.lblObs.Text);
                                                                                */
                                    rpta = NVenta.InsertarPedidoPagadoR(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "RESERVADA", formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text),
Convert.ToInt32(this.lblIdUsuario.Text), "CU", 1, frmVenta.f1.dtDetalle, frmVenta.f1.dtDetalleMenu, Convert.ToDateTime(this.lblFechaEntrega.Text),
Convert.ToDecimal(this.txtEfectivo.Text), Convert.ToInt32(this.lblIdUsuario.Text), this.lblObs.Text, frmReservar.f1.txtMotivo.Text.Trim(),
frmReservar.f1.txtNombre.Text.ToUpper().Trim(),frmReservar.f1.txtCel.Text.Trim());
                                    if (rpta != "")
                                    {
                                        for (int p = 0; p < frmVenta.f1.dataListadoDetalle.Rows.Count; p++)
                                        {
                                            if (frmVenta.f1.dataListadoDetalle.Rows[p].Cells["Tipo"].Value.ToString() == "C")
                                            {

                                                DataTable dtDetalleProducto = new DataTable();
                                                dtDetalleProducto = NProducto.mostrarDetalleProducto_Venta(Convert.ToInt32(frmVenta.f1.dataListadoDetalle.Rows[p].Cells["Cod"].Value.ToString()));
                                                int cantPedido = Convert.ToInt32(frmVenta.f1.dataListadoDetalle.Rows[p].Cells["Cant"].Value.ToString());
                                                for (int j = 0; j < dtDetalleProducto.Rows.Count; j++)
                                                {
                                                    int idProducto_Com = Convert.ToInt32(dtDetalleProducto.Rows[j][0].ToString());
                                                    int cantRequerida = Convert.ToInt32(dtDetalleProducto.Rows[j][1].ToString());

                                                    NProducto.EditarStock(idProducto_Com, cantRequerida * cantPedido);
                                                }

                                            }
                                            DataTable dtReceta = NReceta.Mostrar(Convert.ToInt32(frmVenta.f1.dataListadoDetalle.Rows[p].Cells["Cod"].Value.ToString()));

                                            if (dtReceta.Rows.Count > 0)
                                            {
                                                int cantInsumo = Convert.ToInt32(frmVenta.f1.dataListadoDetalle.Rows[p].Cells["Cant"].Value.ToString());
                                                decimal cantTotal;
                                                for (int k = 0; k < dtReceta.Rows.Count; k++)
                                                {
                                                    cantTotal = cantInsumo * Convert.ToDecimal(dtReceta.Rows[k][3].ToString());
                                                    NInsumo.EditarStock(Convert.ToInt32(dtReceta.Rows[k][0].ToString()), cantTotal);
                                                }

                                            }

                                        }
                                        if (insertarCaja() == true)
                                        {
                                            //MessageBox.Show("Se registró correctamente");
                                            NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                                            frmModuloSalon.f3.limpiarMesas();
                                            frmModuloSalon.f3.mostrarSalones();

                                            enviarFormaPago();
                                            // this.imprimir(Convert.ToInt32(this.lblIdVenta.Text));
                                            /*
                                            NImprimir_Comprobante.imprimirCom(Convert.ToInt32(rpta), tipoCompr, this.txtNombre.Text.Trim(), this.txtDireccion.Text.Trim(),
                                                                this.txtDocumento.Text.Trim(), frmVenta.f1.lblMesero.Text, frmVenta.f1.lblSalon.Text, frmVenta.f1.lblMesa.Text,
                                                                frmVenta.f1.dataListadoDetalle, this.lblDescuento.Text, this.lblDctoGeneral.Text, this.lblSubTotal.Text,
                                                                this.lblIgv.Text, this.lblTotal.Text, efectivo1, vuelto1, tarjeta1, formaPago1, modoProd, "00.00", "");


    */
                                            //this.imprimir(Convert.ToInt32(rpta));
                                            // this.Facturador(Convert.ToInt32(rpta), frmVenta.f1.dtDetalle);
                                            NImprimirComanda.imprimirReserva(frmVenta.f1.dataListadoDetalle, lblFechaEntrega.Text, lblObs.Text, rpta, lblTotal.Text,txtEfectivo.Text,txtVuelto.Text,frmPrincipal.f1.lblUsuario.Text+
                                                " " +frmPrincipal.f1.lblApellidos, frmReservar.f1.txtNombre.Text.Trim(),
                                                frmReservar.f1.txtCel.Text.Trim(), frmReservar.f1.txtMotivo.Text.Trim());
                                            this.Close();
                                            frmVenta.f1.Close();
                                            frmReservar.f1.Close();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show(rpta);
                                    }


                                }
                                else
                                {
                                    if (this.txtIdCliente.Text.Trim() != string.Empty && this.txtDocumento.Text.Trim().Length == 11)
                                    {

                                        string rpta = "";
                                        /*rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "RESERVADA", formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text)
                                                                                       , Convert.ToInt32(this.lblIdUsuario.Text), "CU", 1, "FACTURA", 1, Convert.ToDecimal(this.lblIgv.Text), "EMITIDA-R",
                                                                                       Convert.ToDecimal(this.lblTotal.Text), pagoEfectivo, pagoTarjeta,
                                                                                       00.00m, frmVenta.f1.dtDetalle, vuelto, frmVenta.f1.dtDetalleMenu,
                                                                                       Convert.ToDateTime(this.lblFechaEntrega.Text), Convert.ToDecimal(this.txtEfectivo.Text), Convert.ToInt32(this.lblIdUsuario.Text), this.lblObs.Text);

                                        */
                                        rpta = NVenta.InsertarPedidoPagadoR(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "RESERVADA", formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text),
                                            Convert.ToInt32(this.lblIdUsuario.Text), "CU", 1, frmVenta.f1.dtDetalle, frmVenta.f1.dtDetalleMenu, Convert.ToDateTime(this.lblFechaEntrega.Text),
                                            Convert.ToDecimal(this.txtEfectivo.Text), Convert.ToInt32(this.lblIdUsuario.Text), this.lblObs.Text,
                                            frmReservar.f1.txtMotivo.Text.Trim(),
frmReservar.f1.txtNombre.Text.ToUpper().Trim(), frmReservar.f1.txtCel.Text.Trim());
                                        if (rpta != "")
                                        {
                                            if (insertarCaja() == true)
                                            {
                                                //MessageBox.Show("Se registró correctamente");
                                                NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                                                frmModuloSalon.f3.limpiarMesas();
                                                frmModuloSalon.f3.mostrarSalones();
                                                //this.imprimir(Convert.ToInt32(rpta));
                                                enviarFormaPago();

                                                /*  NImprimir_Comprobante.imprimirCom(Convert.ToInt32(rpta), "FACTURA", this.txtNombre.Text.Trim(), this.txtDireccion.Text.Trim(),
                                                                           this.txtDocumento.Text.Trim(), frmVenta.f1.lblMesero.Text, frmVenta.f1.lblSalon.Text, frmVenta.f1.lblMesa.Text,
                                                                           frmVenta.f1.dataListadoDetalle, this.lblDescuento.Text, this.lblDctoGeneral.Text, this.lblSubTotal.Text,
                                                                           this.lblIgv.Text, this.lblTotal.Text, efectivo1, vuelto1, tarjeta1, formaPago1, modoProd, "00.00", "");


                                                  this.Facturador(Convert.ToInt32(rpta), frmVenta.f1.dtDetalle);
                                                  */
                                                NImprimirComanda.imprimirReserva(frmVenta.f1.dataListadoDetalle,lblFechaEntrega.Text, lblObs.Text, rpta,lblTotal.Text,txtEfectivo.Text,txtVuelto.Text,
                                                    frmPrincipal.f1.lblUsuario.Text + " "+ frmPrincipal.f1.lblApellidos.Text, frmReservar.f1.txtNombre.Text.Trim(),
                                                frmReservar.f1.txtCel.Text.Trim(), frmReservar.f1.txtMotivo.Text.Trim());
                                                this.Close();
                                                frmVenta.f1.Hide();
                                                frmVenta.f1.Close();
                                                frmReservar.f1.Close();
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show(rpta);
                                        }


                                    }
                                    else
                                    {
                                        MessageBox.Show("Seleccione un cliente o ingrese un numero de RUC correcto");
                                    }
                                }
                            }

                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.StackTrace);
                    }

                }
            }
        }

        private void Cobrar()
        {
            decimal efectivo, total, vuelto;
            if (this.txtEfectivo.Text.Trim() == "")
            {
                efectivo = 0;
            }
            else
            {
                efectivo = Convert.ToDecimal(this.txtEfectivo.Text.Trim());
            }



            total = Convert.ToDecimal(this.lblTotal.Text);

            if ((efectivo < total) && (rbEfectivo.Checked == true))
            {
                MessageBox.Show("El efectivo es insuficiente");
                this.txtEfectivo.Focus();
            }
            else
            {
                int? idCliente = null;
                if (this.txtIdCliente.Text != string.Empty)
                {
                    idCliente = Convert.ToInt32(this.txtIdCliente.Text);
                }
                else
                {
                    idCliente = null;
                }

                if (txtVuelto.Text == string.Empty)
                {
                    vuelto = 00.00m;
                }
                else
                {
                    vuelto = Convert.ToDecimal(this.txtVuelto.Text);
                }

                if (this.lblIdVenta.Text != "0")
                {
                    try
                    {
                        if (this.txtEfectivo.Text == "" && (this.rbEfectivo.Checked == true || this.rbMixto.Checked == true))
                        {
                            MessageBox.Show("El campo efectivo es obligatorio");
                        }
                        else
                        {
                            string rpta = "";
                            string rpta1 = "";

                            if (verMontosPago() == true)
                            {
                                this.verMontosPago();
                                this.verFormaPago();
                                if (this.lblBanderaComprobante.Text == "0" || this.lblBanderaComprobante.Text == "1")
                                {

                                    int cont = Convert.ToInt32(frmVenta.f1.lblNroFilas.Text);

                                    for (int j = 0; j < cont; j++)
                                    {
                                        NDetalleVenta.EditarDetalleVenta(Convert.ToInt32(frmVenta.f1.dataListadoDetalle.Rows[j].Cells[7].Value.ToString()),
                                                                       Convert.ToDecimal(frmVenta.f1.dataListadoDetalle.Rows[j].Cells[4].Value.ToString()),
                                                                       Convert.ToDecimal(frmVenta.f1.dataListadoDetalle.Rows[j].Cells[3].Value.ToString()));
                                    }

                                    if (cont >= frmVenta.f1.dataListadoDetalle.Rows.Count)
                                    {

                                    }
                                    else
                                    {
                                        for (int i = cont; i < frmVenta.f1.dataListadoDetalle.Rows.Count; i++)
                                        {
                                            int idProducto = Convert.ToInt32(frmVenta.f1.dataListadoDetalle.Rows[i].Cells[0].Value.ToString());
                                            int cantidad = Convert.ToInt32(frmVenta.f1.dataListadoDetalle.Rows[i].Cells[2].Value.ToString());
                                            decimal prVenta = Convert.ToDecimal(frmVenta.f1.dataListadoDetalle.Rows[i].Cells[3].Value.ToString());
                                            decimal desc = Convert.ToDecimal(frmVenta.f1.dataListadoDetalle.Rows[i].Cells[4].Value.ToString());
                                            string barra = frmVenta.f1.dataListadoDetalle.Rows[i].Cells["Barra"].Value.ToString();
                                            string tipo = frmVenta.f1.dataListadoDetalle.Rows[i].Cells["Tipo"].Value.ToString();
                                            string estado = frmVenta.f1.dataListadoDetalle.Rows[i].Cells["Estado"].Value.ToString();
                                            NDetalleVenta.InsertarAdicPedido(Convert.ToInt32(frmVenta.f1.lblIdVenta.Text), idProducto, cantidad, prVenta, desc,
                                                frmVenta.f1.dataListadoDetalle.Rows[i].Cells[6].Value.ToString(), tipo, barra, frmVenta.f1.dtDetalleMenu,"Pedido");
                                            for (int p = cont; p < frmVenta.f1.dataListadoDetalle.Rows.Count; p++)
                                            {
                                                if (frmVenta.f1.dataListadoDetalle.Rows[i].Cells["Tipo"].Value.ToString() == "C")
                                                {

                                                    DataTable dtDetalleProducto = new DataTable();
                                                    dtDetalleProducto = NProducto.mostrarDetalleProducto_Venta(Convert.ToInt32(frmVenta.f1.dataListadoDetalle.Rows[i].Cells["Cod"].Value.ToString()));
                                                    int cantPedido = Convert.ToInt32(frmVenta.f1.dataListadoDetalle.Rows[i].Cells["Cant"].Value.ToString());
                                                    for (int j = 0; j < dtDetalleProducto.Rows.Count; j++)
                                                    {
                                                        int idProducto_Com = Convert.ToInt32(dtDetalleProducto.Rows[j][0].ToString());
                                                        int cantRequerida = Convert.ToInt32(dtDetalleProducto.Rows[j][1].ToString());

                                                        NProducto.EditarStock(idProducto_Com, cantRequerida * cantPedido);
                                                    }

                                                }
                                            }
                                        }

                                    }

                                    rpta = NVenta.EditarVentaCancelada(Convert.ToInt32(this.lblIdVenta.Text), Convert.ToDecimal(this.lblDctoGeneral.Text), formaPago,"");
                                    if (rpta == "OK")
                                    {
                                        string formaPago = "";
                                        decimal pagoEfectivo = 00.00m, pagoTarjeta = 00.00m;
                                        if (rbEfectivo.Checked == true)
                                        {
                                            formaPago = "EFECTIVO";
                                            pagoEfectivo = Convert.ToDecimal(this.lblTotal.Text);
                                            pagoTarjeta = 00.00m;
                                        }
                                        else if (rbTarjeta.Checked == true)
                                        {
                                            formaPago = "TARJETA";
                                            pagoEfectivo = 00.00m;
                                            pagoTarjeta = Convert.ToDecimal(this.lblTotal.Text);
                                        }
                                        else if (rbMixto.Checked == true)
                                        {
                                            formaPago = "MIXTO";
                                            pagoEfectivo = Convert.ToDecimal(this.txtEfectivo.Text);
                                            pagoTarjeta = Convert.ToDecimal(this.txtTarjeta.Text);
                                        }

                                        string tipoCompr = "";
                                        if (this.lblBanderaComprobante.Text == "0")
                                        {
                                            tipoCompr = "TICKET";
                                        }
                                        else if (this.lblBanderaComprobante.Text == "1")
                                        {
                                            tipoCompr = "BOLETA";
                                        }
                                        else
                                        {
                                            tipoCompr = "FACTURA";
                                        }

                                        rpta1 = NComprobante.Insertar(tipoCompr, 1, Convert.ToDecimal(this.lblIgv.Text), DateTime.Now, Convert.ToInt32(this.lblIdVenta.Text), "EMITIDA", idCliente,
                                                        Convert.ToDecimal(this.lblTotal.Text), pagoEfectivo, pagoTarjeta, 00.00m, formaPago, vuelto);
                                        if (rpta1 == "OK")
                                        {
                                            if (insertarCaja() == true)
                                            {
                                               // MessageBox.Show("Se registró correctamente");
                                                NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                                                frmModuloSalon.f3.limpiarMesas();
                                                frmModuloSalon.f3.mostrarSalones();

                                                this.enviarFormaPago();
                                                int count = 0;
                                                DataTable dtCategoriaProducto = new DataTable();
                                                for (int i = 0; i < frmVenta.f1.dtDetalleVenta.Rows.Count; i++)
                                                {

                                                    dtCategoriaProducto = NCategoria.MostrarCategoriaProducto(Convert.ToInt32(frmVenta.f1.dtDetalleVenta.Rows[i][0].ToString()));
                                                    if (dtCategoriaProducto.Rows[0][1].ToString() == "BOCADITOS POR MENOR" || dtCategoriaProducto.Rows[0][1].ToString() == "PANES POR MENOR")
                                                    {
                                                        count = count + 1;
                                                    }

                                                }
                                                if (count != frmVenta.f1.dtDetalleVenta.Rows.Count)
                                                {
                                                    NImprimir_Comprobante.imprimirCom(Convert.ToInt32(this.lblIdVenta.Text), tipoCompr, this.txtNombre.Text.Trim(), this.txtDireccion.Text.Trim(),
                                                                            this.txtDocumento.Text.Trim(), frmVenta.f1.lblMesero.Text, frmVenta.f1.lblSalon.Text, frmVenta.f1.lblMesa.Text,
                                                                            frmVenta.f1.dataListadoDetalle, this.lblDescuento.Text, this.lblDctoGeneral.Text, this.lblSubTotal.Text,
                                                                            this.lblIgv.Text, this.lblTotal.Text, efectivo1, vuelto1, tarjeta1, formaPago1, modoProd, "00.00", "");
                                                }

                                                   
                                                

                                                this.Facturador(Convert.ToInt32(this.lblIdVenta.Text), frmVenta.f1.dtDetalleVenta);

                                                this.Close();
                                                frmVenta.f1.Hide();
                                                frmModuloSalon.f3.tEstado.Enabled = true;

                                            }

                                        }
                                        else
                                        {
                                            MessageBox.Show(rpta1);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show(rpta);
                                    }


                                }
                                else
                                {

                                    if (this.txtIdCliente.Text != string.Empty && txtDocumento.Text.Trim().Length == 11)
                                    {
                                        int cont = Convert.ToInt32(frmVenta.f1.lblNroFilas.Text);
                                        if (cont >= frmVenta.f1.dataListadoDetalle.Rows.Count)
                                        {

                                        }
                                        else
                                        {
                                            for (int i = cont; i < frmVenta.f1.dataListadoDetalle.Rows.Count; i++)
                                            {
                                                int idProducto = Convert.ToInt32(frmVenta.f1.dataListadoDetalle.Rows[i].Cells[0].Value.ToString());
                                                int cantidad = Convert.ToInt32(frmVenta.f1.dataListadoDetalle.Rows[i].Cells[2].Value.ToString());
                                                decimal prVenta = Convert.ToDecimal(frmVenta.f1.dataListadoDetalle.Rows[i].Cells[3].Value.ToString());
                                                decimal desc = Convert.ToDecimal(frmVenta.f1.dataListadoDetalle.Rows[i].Cells[4].Value.ToString());
                                                string barra = frmVenta.f1.dataListadoDetalle.Rows[i].Cells["Barra"].Value.ToString();
                                                string tipo = frmVenta.f1.dataListadoDetalle.Rows[i].Cells["Tipo"].Value.ToString();
                                                NDetalleVenta.InsertarAdicPedido(Convert.ToInt32(frmVenta.f1.lblIdVenta.Text), idProducto, cantidad, prVenta, desc,
                                                    frmVenta.f1.dataListadoDetalle.Rows[i].Cells[6].Value.ToString(), tipo, barra, frmVenta.f1.dtDetalleMenu,"Pedido");

                                                for (int p = cont; p < frmVenta.f1.dataListadoDetalle.Rows.Count; p++)
                                                {
                                                    if (frmVenta.f1.dataListadoDetalle.Rows[i].Cells["Tipo"].Value.ToString() == "C")
                                                    {

                                                        DataTable dtDetalleProducto = new DataTable();
                                                        dtDetalleProducto = NProducto.mostrarDetalleProducto_Venta(Convert.ToInt32(frmVenta.f1.dataListadoDetalle.Rows[i].Cells["Cod"].Value.ToString()));
                                                        int cantPedido = Convert.ToInt32(frmVenta.f1.dataListadoDetalle.Rows[i].Cells["Cant"].Value.ToString());
                                                        for (int j = 0; j < dtDetalleProducto.Rows.Count; j++)
                                                        {
                                                            int idProducto_Com = Convert.ToInt32(dtDetalleProducto.Rows[j][0].ToString());
                                                            int cantRequerida = Convert.ToInt32(dtDetalleProducto.Rows[j][1].ToString());

                                                            NProducto.EditarStock(idProducto_Com, cantRequerida * cantPedido);
                                                        }

                                                    }


                                                    DataTable dtReceta = NReceta.Mostrar(Convert.ToInt32(frmVenta.f1.dataListadoDetalle.Rows[p].Cells["Cod"].Value.ToString()));

                                                    if (dtReceta.Rows.Count > 0)
                                                    {
                                                        int cantInsumo = Convert.ToInt32(frmVenta.f1.dataListadoDetalle.Rows[p].Cells["Cant"].Value.ToString());
                                                        decimal cantTotal;
                                                        for (int k = 0; k < dtReceta.Rows.Count; k++)
                                                        {
                                                            cantTotal = cantInsumo * Convert.ToDecimal(dtReceta.Rows[k][3].ToString());
                                                            NInsumo.EditarStock(Convert.ToInt32(dtReceta.Rows[k][0].ToString()), cantTotal);
                                                        }

                                                    }
                                                }
                                            }
                                        }

                                        //   rpta1= NFactura.Insertar(1, Convert.ToDecimal(this.lblIgv.Text), DateTime.Now, Convert.ToInt32(this.lblIdVenta.Text),"EMITIDA", Convert.ToInt32(this.lblIdMesa.Text));
                                        rpta = NVenta.EditarVentaCancelada(Convert.ToInt32(this.lblIdVenta.Text), Convert.ToDecimal(this.lblDctoGeneral.Text), formaPago,"");
                                        if (rpta == "OK")
                                        {
                                            string formaPago = "";
                                            decimal pagoEfectivo = 00.00m, pagoTarjeta = 00.00m;
                                            if (rbEfectivo.Checked == true)
                                            {
                                                formaPago = "EFECTIVO";
                                                pagoEfectivo = Convert.ToDecimal(this.lblTotal.Text);
                                                pagoTarjeta = 00.00m;
                                            }
                                            else if (rbTarjeta.Checked == true)
                                            {
                                                formaPago = "TARJETA";
                                                pagoEfectivo = 00.00m;
                                                pagoTarjeta = Convert.ToDecimal(this.lblTotal.Text);
                                            }
                                            else if (rbMixto.Checked == true)
                                            {
                                                formaPago = "MIXTO";
                                                pagoEfectivo = Convert.ToDecimal(this.txtEfectivo.Text);
                                                pagoTarjeta = Convert.ToDecimal(this.txtTarjeta.Text);
                                            }
                                            rpta1 = NComprobante.Insertar("FACTURA", 1, Convert.ToDecimal(this.lblIgv.Text), DateTime.Now, Convert.ToInt32(this.lblIdVenta.Text),
                                                "EMITIDA", Convert.ToInt32(this.txtIdCliente.Text), Convert.ToDecimal(this.lblTotal.Text), pagoEfectivo, pagoTarjeta, 00.00m, formaPago, vuelto);
                                            if (rpta1 == "OK")
                                            {
                                                if (insertarCaja() == true)
                                                {

                                                   // MessageBox.Show("Se registró correctamente");
                                                    NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                                                    frmModuloSalon.f3.limpiarMesas();
                                                    frmModuloSalon.f3.mostrarSalones();
                                                    enviarFormaPago();
                                                    // this.imprimir(Convert.ToInt32(this.lblIdVenta.Text));
                                                    int count = 0;
                                                    DataTable dtCategoriaProducto = new DataTable();
                                                    for (int i = 0; i < frmVenta.f1.dtDetalleVenta.Rows.Count; i++)
                                                    {

                                                        dtCategoriaProducto = NCategoria.MostrarCategoriaProducto(Convert.ToInt32(frmVenta.f1.dtDetalleVenta.Rows[i][0].ToString()));
                                                        if (dtCategoriaProducto.Rows[0][1].ToString() == "BOCADITOS POR MENOR" || dtCategoriaProducto.Rows[0][1].ToString() == "PANES POR MENOR")
                                                        {
                                                            count = count + 1;
                                                        }

                                                    }
                                                    if (count != frmVenta.f1.dtDetalleVenta.Rows.Count)
                                                    {
                                                        NImprimir_Comprobante.imprimirCom(Convert.ToInt32(this.lblIdVenta.Text), "FACTURA", this.txtNombre.Text.Trim(), this.txtDireccion.Text.Trim(),
                                                                          this.txtDocumento.Text.Trim(), frmVenta.f1.lblMesero.Text, frmVenta.f1.lblSalon.Text, frmVenta.f1.lblMesa.Text,
                                                                          frmVenta.f1.dataListadoDetalle, this.lblDescuento.Text, this.lblDctoGeneral.Text, this.lblSubTotal.Text,
                                                                          this.lblIgv.Text, this.lblTotal.Text, efectivo1, vuelto1, tarjeta1, formaPago1, modoProd, "00.00", "");
                                                    }
                                                        
                                                    

                                                    //this.imprimir(Convert.ToInt32(this.lblIdVenta.Text));
                                                    this.Facturador(Convert.ToInt32(this.lblIdVenta.Text), frmVenta.f1.dtDetalleVenta);

                                                    this.Close();
                                                    frmVenta.f1.Hide();
                                                    frmModuloSalon.f3.tEstado.Enabled = true;
                                                }

                                            }
                                            else
                                            {
                                                MessageBox.Show(rpta1);
                                            }

                                        }
                                        else
                                        {
                                            MessageBox.Show(rpta);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Seleccione un cliente o ingrese un numero de RUC correcto");
                                    }


                                }
                            }


                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.StackTrace);
                    }

                }
                else
                {
                    try
                    {
                        if (this.txtEfectivo.Text == "" && (this.rbEfectivo.Checked == true || this.rbMixto.Checked == true))
                        {
                            MessageBox.Show("El campo efectivo es obligatorio");
                        }
                        else
                        {
                            string fechaEntrega = "", estadoVenta = "";
                            if (lblFechaEntrega.Text == "1")
                            {
                                fechaEntrega = DateTime.Now.ToLongDateString();
                                estadoVenta = "PAGADA";
                            }
                            else
                            {
                                fechaEntrega = this.lblFechaEntrega.Text;
                                estadoVenta = "PAGADA-R";
                            }
                            if (verMontosPago() == true)
                            {
                                string formaPago = "";
                                decimal pagoEfectivo = 00.00m, pagoTarjeta = 00.00m;
                                if (rbEfectivo.Checked == true)
                                {
                                    formaPago = "EFECTIVO";
                                    pagoEfectivo = Convert.ToDecimal(this.lblTotal.Text);
                                    pagoTarjeta = 00.00m;
                                }
                                else if (rbTarjeta.Checked == true)
                                {
                                    formaPago = "TARJETA";
                                    pagoEfectivo = 00.00m;
                                    pagoTarjeta = Convert.ToDecimal(this.lblTotal.Text);
                                }
                                else if (rbMixto.Checked == true)
                                {
                                    formaPago = "MIXTO";
                                    pagoEfectivo = Convert.ToDecimal(this.txtEfectivo.Text);
                                    pagoTarjeta = Convert.ToDecimal(this.txtTarjeta.Text);
                                }
                                this.verFormaPago();
                                if (this.lblBanderaComprobante.Text == "0" || this.lblBanderaComprobante.Text == "1")
                                {
                                    string tipoCompr = "";
                                    if (this.lblBanderaComprobante.Text == "0")
                                    {
                                        tipoCompr = "TICKET";
                                    }
                                    else
                                    {
                                        tipoCompr = "BOLETA";
                                    }
                                    string rpta = "";
                             
                                    if(lblFechaEntrega.Text == "1")
                                    {
                                        rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, estadoVenta, formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text)
                                                                              , Convert.ToInt32(this.lblIdUsuario.Text), "CU", 1, tipoCompr, 1, Convert.ToDecimal(this.lblIgv.Text), "EMITIDA",
                                                                              Convert.ToDecimal(this.lblTotal.Text), pagoEfectivo, pagoTarjeta,
                                                                              00.00m, frmVenta.f1.dtDetalle, vuelto, frmVenta.f1.dtDetalleMenu,
                                                                              Convert.ToDateTime(fechaEntrega), Convert.ToDecimal(lblTotal.Text), Convert.ToInt32(this.lblIdUsuario.Text), 
                                                                              this.lblObs.Text,"","","");
                                    }else
                                    {
                                        rpta = NVenta.InsertarPedidoPagadoR(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, estadoVenta, formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text)
                                                                              , Convert.ToInt32(this.lblIdUsuario.Text), "CU", 1, tipoCompr, 1, Convert.ToDecimal(this.lblIgv.Text), "EMITIDA",
                                                                              Convert.ToDecimal(this.lblTotal.Text), pagoEfectivo, pagoTarjeta,
                                                                              00.00m, frmVenta.f1.dtDetalle, vuelto, frmVenta.f1.dtDetalleMenu,
                                                                              Convert.ToDateTime(fechaEntrega), Convert.ToDecimal(lblTotal.Text), Convert.ToInt32(this.lblIdUsuario.Text),
                                                                              this.lblObs.Text,frmReservar.f1.txtMotivo.Text.Trim(),frmReservar.f1.txtNombre.Text.Trim(),
                                                                              frmReservar.f1.txtCel.Text.Trim());
                                    }
                                  
                                    if (rpta != "")
                                    {
                                        for (int p = 0; p < frmVenta.f1.dataListadoDetalle.Rows.Count; p++)
                                        {
                                            if (frmVenta.f1.dataListadoDetalle.Rows[p].Cells["Tipo"].Value.ToString() == "C")
                                            {

                                                DataTable dtDetalleProducto = new DataTable();
                                                dtDetalleProducto = NProducto.mostrarDetalleProducto_Venta(Convert.ToInt32(frmVenta.f1.dataListadoDetalle.Rows[p].Cells["Cod"].Value.ToString()));
                                                int cantPedido = Convert.ToInt32(frmVenta.f1.dataListadoDetalle.Rows[p].Cells["Cant"].Value.ToString());
                                                for (int j = 0; j < dtDetalleProducto.Rows.Count; j++)
                                                {
                                                    int idProducto_Com = Convert.ToInt32(dtDetalleProducto.Rows[j][0].ToString());
                                                    int cantRequerida = Convert.ToInt32(dtDetalleProducto.Rows[j][1].ToString());

                                                    NProducto.EditarStock(idProducto_Com, cantRequerida * cantPedido);
                                                }

                                            }
                                            DataTable dtReceta = NReceta.Mostrar(Convert.ToInt32(frmVenta.f1.dataListadoDetalle.Rows[p].Cells["Cod"].Value.ToString()));

                                            if (dtReceta.Rows.Count > 0)
                                            {
                                                int cantInsumo = Convert.ToInt32(frmVenta.f1.dataListadoDetalle.Rows[p].Cells["Cant"].Value.ToString());
                                                decimal cantTotal;
                                                for (int k = 0; k < dtReceta.Rows.Count; k++)
                                                {
                                                    cantTotal = cantInsumo * Convert.ToDecimal(dtReceta.Rows[k][3].ToString());
                                                    NInsumo.EditarStock(Convert.ToInt32(dtReceta.Rows[k][0].ToString()), cantTotal);
                                                }

                                            }

                                        }
                                        if (insertarCaja() == true)
                                        {
                                            //MessageBox.Show("Se registró correctamente");
                                            NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                                            frmModuloSalon.f3.limpiarMesas();
                                            frmModuloSalon.f3.mostrarSalones();

                                            enviarFormaPago();
                                            // this.imprimir(Convert.ToInt32(this.lblIdVenta.Text));
                                            int count = 0;
                                            DataTable dtCategoriaProducto = new DataTable();
                                            for (int i = 0; i < frmVenta.f1.dtDetalle.Rows.Count; i++)
                                            {

                                                dtCategoriaProducto = NCategoria.MostrarCategoriaProducto(Convert.ToInt32(frmVenta.f1.dtDetalle.Rows[i][0].ToString()));
                                                if (dtCategoriaProducto.Rows[0][1].ToString() == "BOCADITOS POR MENOR" || dtCategoriaProducto.Rows[0][1].ToString() == "PANES POR MENOR")
                                                {
                                                    count = count + 1;
                                                }

                                            }
                                            if (count != frmVenta.f1.dtDetalle.Rows.Count)
                                            {
                                                NImprimir_Comprobante.imprimirCom(Convert.ToInt32(rpta), tipoCompr, this.txtNombre.Text.Trim(), this.txtDireccion.Text.Trim(),
                                                                    this.txtDocumento.Text.Trim(), frmVenta.f1.lblMesero.Text, frmVenta.f1.lblSalon.Text, frmVenta.f1.lblMesa.Text,
                                                                    frmVenta.f1.dataListadoDetalle, this.lblDescuento.Text, this.lblDctoGeneral.Text, this.lblSubTotal.Text,
                                                                    this.lblIgv.Text, this.lblTotal.Text, efectivo1, vuelto1, tarjeta1, formaPago1, modoProd, "00.00", "");
                                            }
                                                
                                            
                                            if(this.lblFechaEntrega.Text != "1")
                                            {
                                                NImprimirComanda.imprimirReserva(frmVenta.f1.dataListadoDetalle, lblFechaEntrega.Text, lblObs.Text, rpta, lblTotal.Text,
                                                    "00", "00.00",frmPrincipal.f1.lblUsuario.Text + " " + frmPrincipal.f1.lblApellidos.Text, frmReservar.f1.txtNombre.Text.Trim(),
                                                frmReservar.f1.txtCel.Text.Trim(), frmReservar.f1.txtMotivo.Text.Trim());
                                            }

                                            //this.imprimir(Convert.ToInt32(rpta));
                                            this.Facturador(Convert.ToInt32(rpta), frmVenta.f1.dtDetalle);

                                            this.Close();
                                            frmVenta.f1.Hide();
                                            if(lblFechaEntrega.Text != "1")
                                            {
                                                frmReservar.f1.Close();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show(rpta);
                                    }


                                }
                                else
                                {
                                    if (this.txtIdCliente.Text.Trim() != string.Empty && this.txtDocumento.Text.Trim().Length == 11)
                                    {

                                        string rpta = "";
                                        if(lblFechaEntrega.Text == "1")
                                        {
                                            rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, estadoVenta, formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text)
                                                                             , Convert.ToInt32(this.lblIdUsuario.Text), "CU", 1, "FACTURA", 1, Convert.ToDecimal(this.lblIgv.Text),
                                                                             "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), pagoEfectivo,
                                                                             pagoTarjeta, 00.00m, frmVenta.f1.dtDetalle, vuelto,
                                                                             frmVenta.f1.dtDetalleMenu, Convert.ToDateTime(fechaEntrega), Convert.ToDecimal(lblTotal.Text),
                                                                             Convert.ToInt32(this.lblIdUsuario.Text), this.lblObs.Text, "", "","");
                                        }
                                       else
                                        {
                                            rpta = NVenta.InsertarPedidoPagadoR(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, estadoVenta, formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text)
                                                                             , Convert.ToInt32(this.lblIdUsuario.Text), "CU", 1, "FACTURA", 1, Convert.ToDecimal(this.lblIgv.Text),
                                                                             "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), pagoEfectivo,
                                                                             pagoTarjeta, 00.00m, frmVenta.f1.dtDetalle, vuelto,
                                                                             frmVenta.f1.dtDetalleMenu, Convert.ToDateTime(fechaEntrega), Convert.ToDecimal(lblTotal.Text),
                                                                             Convert.ToInt32(this.lblIdUsuario.Text), this.lblObs.Text, frmReservar.f1.txtMotivo.Text.Trim(), frmReservar.f1.txtNombre.Text.Trim(),
                                                                              frmReservar.f1.txtCel.Text.Trim());
                                        }
                                        if (rpta != "")
                                        {
                                            if (insertarCaja() == true)
                                            {
                                                //MessageBox.Show("Se registró correctamente");
                                                NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                                                frmModuloSalon.f3.limpiarMesas();
                                                frmModuloSalon.f3.mostrarSalones();
                                                //this.imprimir(Convert.ToInt32(rpta));
                                                enviarFormaPago();

                                                int count = 0;
                                                DataTable dtCategoriaProducto = new DataTable();
                                                for (int i = 0; i < frmVenta.f1.dtDetalle.Rows.Count; i++)
                                                {

                                                    dtCategoriaProducto = NCategoria.MostrarCategoriaProducto(Convert.ToInt32(frmVenta.f1.dtDetalle.Rows[i][0].ToString()));
                                                    if (dtCategoriaProducto.Rows[0][1].ToString() == "BOCADITOS POR MENOR" || dtCategoriaProducto.Rows[0][1].ToString() == "PANES POR MENOR")
                                                    {
                                                        count = count + 1;
                                                    }

                                                }
                                                if (count != frmVenta.f1.dtDetalle.Rows.Count)
                                                {
                                                    NImprimir_Comprobante.imprimirCom(Convert.ToInt32(rpta), "FACTURA", this.txtNombre.Text.Trim(), this.txtDireccion.Text.Trim(),
                                                                            this.txtDocumento.Text.Trim(), frmVenta.f1.lblMesero.Text, frmVenta.f1.lblSalon.Text, frmVenta.f1.lblMesa.Text,
                                                                            frmVenta.f1.dataListadoDetalle, this.lblDescuento.Text, this.lblDctoGeneral.Text, this.lblSubTotal.Text,
                                                                            this.lblIgv.Text, this.lblTotal.Text, efectivo1, vuelto1, tarjeta1, formaPago1, modoProd, "00.00", "");
                                                }
                                                   

                                                if (this.lblFechaEntrega.Text != "1")
                                                {
                                                    NImprimirComanda.imprimirReserva(frmVenta.f1.dataListadoDetalle, lblFechaEntrega.Text, lblObs.Text, rpta, 
                                                        lblTotal.Text, "00", "00.00",frmPrincipal.f1.lblUsuario.Text + " "+frmPrincipal.f1.lblApellidos.Text, frmReservar.f1.txtNombre.Text.Trim(),
                                                frmReservar.f1.txtCel.Text.Trim(), frmReservar.f1.txtMotivo.Text.Trim());
                                                }
                                                this.Facturador(Convert.ToInt32(rpta), frmVenta.f1.dtDetalle);

                                                this.Close();
                                                frmVenta.f1.Hide();
                                                if (lblFechaEntrega.Text != "1")
                                                {
                                                    frmReservar.f1.Close();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show(rpta);
                                        }


                                    }
                                    else
                                    {
                                        MessageBox.Show("Seleccione un cliente o ingrese un numero de RUC correcto");
                                    }
                                }
                            }

                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.StackTrace);
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(lblBanderaCobro.Text == "1")
            {
                CobrarAdelanto();
            }else if(lblBanderaCobro.Text == "3")
            {
                CobrarReserva();
            }else
            {
                Cobrar();
            }

            
        }

        private void btnBoleta_Click(object sender, EventArgs e)
        {
            this.lblBanderaComprobante.Text = "1";
            this.btnBoleta.BackColor = Color.FromArgb(236, 236, 236);
            this.btnFactura.BackColor = Color.FromArgb(205, 201, 201);
            this.btnTicket.BackColor = Color.FromArgb(205, 201, 201);

            decimal totalText = Convert.ToDecimal(this.lblTotal.Text);
            decimal totalSubTotalText = (totalText - Convert.ToDecimal(this.lblDctoGeneral.Text)) / 1.18m;

            this.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalSubTotalText));
            decimal totalIgvText = totalText - totalSubTotalText;
            this.lblIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalIgvText));
            this.dataListadoProducto.Select();

        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            this.lblBanderaComprobante.Text = "2";
            this.btnFactura.BackColor = Color.FromArgb(236, 236, 236);
            this.btnBoleta.BackColor = Color.FromArgb(205, 201, 201);
            this.btnTicket.BackColor = Color.FromArgb(205, 201, 201);

            decimal totalText = Convert.ToDecimal(this.lblTotal.Text);
            decimal totalSubTotalText = (totalText - Convert.ToDecimal(this.lblDctoGeneral.Text)) / 1.18m;

            this.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalSubTotalText));
            decimal totalIgvText = totalText - totalSubTotalText;
            this.lblIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalIgvText));
            this.dataListadoProducto.Select();
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            frmVistaClientePagoVenta form = new frmVistaClientePagoVenta();
            form.ShowDialog();
            this.dataListadoProducto.Select();
        }

        private void txtDescuento_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void btnDescuentoTotal_Click(object sender, EventArgs e)
        {
            frmDescuentoTotal form = new frmDescuentoTotal();
            form.lblIdBandera.Text = "0";
            form.ShowDialog();
            this.dataListadoProducto.Select();
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                DataTable dtClienteVenta;
                dtClienteVenta = NCliente.mostrarClienteVenta(this.txtDocumento.Text.Trim());
                if(dtClienteVenta.Rows.Count <= 0)
                {
                    MessageBox.Show("No existe el cliente, regístrelo");
                }
                else
                {
                    this.txtIdCliente.Text = dtClienteVenta.Rows[0][0].ToString();
                    this.txtNombre.Text = dtClienteVenta.Rows[0][1].ToString();
                    this.txtDocumento.Text = dtClienteVenta.Rows[0][2].ToString();
                    this.txtDireccion.Text = dtClienteVenta.Rows[0][3].ToString();
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.btnGuardar.Enabled = true;
            this.txtNombre.ReadOnly = false;
            this.txtDireccion.ReadOnly = false;
            this.txtNombre.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtDocumento.Text = string.Empty;
            this.txtIdCliente.Text = string.Empty;
            this.txtDocumento.Focus();
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            if(this.txtDocumento.Text.Length == 11)
            {
                if(this.txtNombre.Text.Trim() == "" || this.txtDireccion.Text.Trim() == "")
                {
                    MessageBox.Show("Complete el nombre y dirección");
                }
                else
                {
                    rpta = NCliente.InsertarVenta(this.txtNombre.Text.Trim().ToUpper(), DateTime.MinValue, "RUC", this.txtDocumento.Text, this.txtDireccion.Text.Trim(), "", "");
                    this.txtIdCliente.Text = rpta;
                    this.txtNombre.ReadOnly = true;
                    this.txtDireccion.ReadOnly = true;
                    this.btnGuardar.Enabled = false;
                    this.btnNuevo.Enabled = false;
                    this.dataListadoProducto.Select();
                }

            }else if(this.txtDocumento.Text.Length == 8)
            {
                if (this.txtNombre.Text.Trim() == "")
                {
                    MessageBox.Show("Complete el nombre");
                    this.dataListadoProducto.Select();
                }
                else
                {
                    rpta = NCliente.InsertarVenta(this.txtNombre.Text.Trim().ToUpper(), DateTime.MinValue, "DNI", this.txtDocumento.Text, this.txtDireccion.Text.Trim(), "", "");
                    this.txtIdCliente.Text = rpta;
                    this.txtNombre.ReadOnly = true;
                    this.txtDireccion.ReadOnly = true;
                    this.dataListadoProducto.Select();
                }
             
            }
            else
            {
                MessageBox.Show("Ingrese un nro de Documento válido");
                this.dataListadoProducto.Select();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text = "10";

                mostrarTotales();
                this.dataListadoProducto.Select();

            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text = "20";

                mostrarTotales();
                this.dataListadoProducto.Select();

            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text = "50";

                mostrarTotales();
                this.dataListadoProducto.Select();

            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text = "100";

                mostrarTotales();
                this.dataListadoProducto.Select();

            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text = "200";

                mostrarTotales();
                this.dataListadoProducto.Select();

            }
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            this.lblBanderaComprobante.Text = "0";
            this.btnTicket.BackColor = Color.FromArgb(236, 236, 236);
            this.btnFactura.BackColor = Color.FromArgb(205, 201, 201);
            this.btnBoleta.BackColor = Color.FromArgb(205, 201, 201);

            decimal totalText = Convert.ToDecimal(this.lblTotal.Text);
            decimal totalSubTotalText = (totalText - Convert.ToDecimal(this.lblDctoGeneral.Text)) / 1.18m;

            this.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalSubTotalText));
            decimal totalIgvText = totalText - totalSubTotalText;
            this.lblIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalIgvText));
            this.dataListadoProducto.Select();
        }

        private void rbSinComprobante_CheckedChanged(object sender, EventArgs e)
        {

            btnBoleta.Enabled = false;
            btnFactura.Enabled = false;
            btnTicket.Enabled = false;

        }

        private void rbDetallado_CheckedChanged(object sender, EventArgs e)
        {
            btnBoleta.Enabled = true;
            btnFactura.Enabled = true;
            btnTicket.Enabled = true;
            this.dataListadoProducto.Select();

        }

        private void rbConsumo_CheckedChanged(object sender, EventArgs e)
        {
            btnBoleta.Enabled = true;
            btnFactura.Enabled = true;
            btnTicket.Enabled = true;
            this.dataListadoProducto.Select();

        }

        private void dataListadoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                if (lblBanderaCobro.Text == "1")
                {
                    CobrarAdelanto();
                }
                else if (lblBanderaCobro.Text == "3")
                {
                    CobrarReserva();
                }
                else
                {
                    Cobrar();
                }


            }
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {

        }

        private void verFormaPago()
        {
            if (rbEfectivo.Checked == true)
            {
                formaPago = rbEfectivo.Text;
            }
            else if (rbTarjeta.Checked == true)
            {
                formaPago = rbTarjeta.Text;
            }
            else if (rbMixto.Checked == true)
            {
                formaPago = rbMixto.Text;
            }

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if(rbMixto.Checked == true)
            {
                this.txtEfectivo.ReadOnly = false;
                this.txtTarjeta.ReadOnly = true;
                this.txtVuelto.ReadOnly = true;
                this.txtEfectivo.Focus();
                mostrarTotales();
                this.dataListadoProducto.Select();
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTarjeta.Checked == true)
            {
                this.txtTarjeta.ReadOnly = true;
                this.txtEfectivo.ReadOnly = true;
                this.txtVuelto.ReadOnly = true;
                mostrarTotales();
                this.dataListadoProducto.Select();
            }
        }

        private void txtTarjeta_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            if(rbEfectivo.Checked == true)
            {
                this.txtTarjeta.ReadOnly = true;
                this.txtEfectivo.ReadOnly = false;
                this.txtVuelto.ReadOnly = true;
                this.txtEfectivo.Focus();
                this.txtTarjeta.Text = "";
                mostrarTotales();
                this.dataListadoProducto.Select();
            }
        }
    }
}
