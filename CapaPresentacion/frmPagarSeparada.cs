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
    public partial class frmPagarSeparada : Form
    {
        Button[] btnCuenta;
        int nroCuentas;
        public static frmPagarSeparada f1;
        private string formaPago;
        private decimal efectivo, tarjeta;
        private string efectivo1, vuelto1, tarjeta1, formaPago1, modoProd;

        public frmPagarSeparada()
        {
            InitializeComponent();
            frmPagarSeparada.f1 = this;
        }

        public void Facturador(int idVenta, DataGridView dtDetalle)
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
                    "0.00", this.lblDctoGeneral.Text.Trim(), this.lblSubTotal.Text.Trim(), "0.00", "0.00", this.lblIgv.Text.Trim(), "0.00", "0.00", this.lblTotal.Text, tipoCompr, idVenta);

                for (int i = 0; i < dtDetalle.Rows.Count; i++)
                {
                    codigo = dtDetalle.Rows[i].Cells["Cod"].Value.ToString();
                    cantidad = dtDetalle.Rows[i].Cells["Cant"].Value.ToString();

                    descr = dtDetalle.Rows[i].Cells["Descripcion"].Value.ToString();
                    valorUnitario = dtDetalle.Rows[i].Cells["Precio_Un"].Value.ToString();
                    valUn = Convert.ToDecimal(valorUnitario);
                    dcto = dtDetalle.Rows[i].Cells["Descuento"].Value.ToString();
                    igvUn = Convert.ToDecimal(valorUnitario) * (18 / 100);
                    afecIgv = (Convert.ToDecimal(cantidad) * Convert.ToDecimal(valorUnitario)) * 0.18m;
                    importe = dtDetalle.Rows[i].Cells["Importe"].Value.ToString();

                    decimal mtoDsctoItem = Convert.ToDecimal(dcto) / Convert.ToDecimal(cantidad);
                    decimal mtoPrecioVentaItem = Decimal.Round((Convert.ToDecimal(importe) / 1.18m), 2) - mtoDsctoItem;
                    decimal mtoIgvItem = Convert.ToDecimal(importe) - mtoPrecioVentaItem;
                    decimal mtoValorUnitario = Decimal.Round(mtoPrecioVentaItem / Convert.ToDecimal(cantidad), 2);


                    NFacturador.registrarComprobanteDetalle("NIU", cantidad, codigo, "", descr, mtoValorUnitario.ToString("#0.00#"), mtoDsctoItem.ToString("#0.00#"), mtoIgvItem.ToString("#0.00#"), "10", "0.00", "",
                        mtoPrecioVentaItem.ToString("#0.00#"), importe, tipoCompr, idVenta);
                }
            }
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

        private void mostrarTotales()
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

        }

        private bool insertarCaja()
        {
            string rptaCaja = "";
            try
            {
                if (rbEfectivo.Checked == true)
                {
                    rptaCaja = NCaja.Insertar(Convert.ToInt32(this.lblIdUsuario.Text), "1", "Ingreso", Convert.ToDecimal(this.lblTotal.Text), "VENTA", "EFECTIVO");
                    if (rptaCaja == "OK")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else if (rbTarjeta.Checked == true)
                {
                    rptaCaja = NCaja.Insertar(Convert.ToInt32(this.lblIdUsuario.Text), "1", "Ingreso", Convert.ToDecimal(this.lblTotal.Text), "VENTA", "TARJETA");
                    if (rptaCaja == "OK")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (rbMixto.Checked == true)
                {
                    rptaCaja = NCaja.Insertar(Convert.ToInt32(this.lblIdUsuario.Text), "1", "Ingreso", Convert.ToDecimal(this.txtEfectivo.Text), "VENTA", "EFECTIVO");
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            return true;
        }

        private void Limpiar()
        {
            this.txtIdCliente.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtDocumento.Text = string.Empty;

            this.txtEfectivo.Text = string.Empty;
            this.txtTarjeta.Text = string.Empty;
            this.txtVuelto.Text = string.Empty;
            this.lblSubTotal.Text = "00.00";
            this.lblDescuento.Text = "00.00";
            this.lblDctoGeneral.Text = "00.00";
            this.lblIgv.Text = "00.00";
            this.lblTotal.Text = "00.00";
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

        private void frmPagarSeparada_Load(object sender, EventArgs e)
        {
            this.ValidarAcceso();
            this.txtEfectivo.Select();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            this.rbEfectivo.Checked = true;
            this.button1.Enabled = true;

            decimal precioVenta,total;
            precioVenta =Convert.ToDecimal(frmSepararCuenta.f1.lblTotalC1.Text);
            total = precioVenta + Convert.ToDecimal(frmSepararCuenta.f1.tdC1.Text);
            this.lblTotal.Text = frmSepararCuenta.f1.lblTotalC1.Text;
            this.lblDescuento.Text = frmSepararCuenta.f1.lblDescuento_Actual.Text;
            decimal subTotal = (precioVenta - Convert.ToDecimal(frmSepararCuenta.f1.tdC1.Text)) / 1.18m;
            this.lblDescuento.Text = frmSepararCuenta.f1.tdC1.Text;
            this.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(subTotal));
            decimal igv = precioVenta - Convert.ToDecimal(this.lblSubTotal.Text);
            this.lblIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(igv));


            this.lblBanderaCuenta.Text = "1";
            this.lblBanderaComprobante.Text = "0";
            this.btnTicket.BackColor = Color.FromArgb(236, 236, 236);
            this.btnBoleta.BackColor = Color.FromArgb(205, 201, 201);
            this.btnFactura.BackColor = Color.FromArgb(205, 201, 201);
            this.txtEfectivo.Select();

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            this.rbEfectivo.Checked = true;
            this.button1.Enabled = true;
            this.txtEfectivo.Select();
            decimal precioVenta, total;
            precioVenta = Convert.ToDecimal(frmSepararCuenta.f1.lblTotalC2.Text);
            total = precioVenta + Convert.ToDecimal(frmSepararCuenta.f1.tdC2.Text);
            this.lblTotal.Text = frmSepararCuenta.f1.lblTotalC2.Text;
            this.lblDescuento.Text = frmSepararCuenta.f1.lblDescuento_Actual.Text;
            decimal subTotal = (precioVenta - Convert.ToDecimal(frmSepararCuenta.f1.tdC2.Text)) / 1.18m;
            this.lblDescuento.Text = frmSepararCuenta.f1.tdC2.Text;
            this.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(subTotal));
            decimal igv = precioVenta - Convert.ToDecimal(this.lblSubTotal.Text);
            this.lblIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(igv));
            this.lblBanderaCuenta.Text = "2";
            this.lblBanderaComprobante.Text = "0";
            this.btnTicket.BackColor = Color.FromArgb(236, 236, 236);
            this.btnBoleta.BackColor = Color.FromArgb(205, 201, 201);
            this.btnFactura.BackColor = Color.FromArgb(205, 201, 201);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            this.rbEfectivo.Checked = true;
            this.button1.Enabled = true;
            this.txtEfectivo.Select();
            decimal precioVenta, total;
            precioVenta = Convert.ToDecimal(frmSepararCuenta.f1.lblTotalC3.Text);
            total = precioVenta + Convert.ToDecimal(frmSepararCuenta.f1.tdC3.Text);
            this.lblTotal.Text = frmSepararCuenta.f1.lblTotalC3.Text;
            this.lblDescuento.Text = frmSepararCuenta.f1.lblDescuento_Actual.Text;
            decimal subTotal = (precioVenta - Convert.ToDecimal(frmSepararCuenta.f1.tdC3.Text)) / 1.18m;
            this.lblDescuento.Text = frmSepararCuenta.f1.tdC3.Text;
            this.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(subTotal));
            decimal igv = precioVenta - Convert.ToDecimal(this.lblSubTotal.Text);
            this.lblIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(igv));
            this.lblBanderaCuenta.Text = "3";
            this.lblBanderaComprobante.Text = "0";
            this.btnTicket.BackColor = Color.FromArgb(236, 236, 236);
            this.btnBoleta.BackColor = Color.FromArgb(205, 201, 201);
            this.btnFactura.BackColor = Color.FromArgb(205, 201, 201);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            this.rbEfectivo.Checked = true;
            this.button1.Enabled = true;
            this.txtEfectivo.Select();
            decimal precioVenta, total;
            precioVenta = Convert.ToDecimal(frmSepararCuenta.f1.lblTotalC4.Text);
            total = precioVenta + Convert.ToDecimal(frmSepararCuenta.f1.tdC4.Text);
            this.lblTotal.Text = frmSepararCuenta.f1.lblTotalC4.Text;
            this.lblDescuento.Text = frmSepararCuenta.f1.lblDescuento_Actual.Text;
            decimal subTotal = (precioVenta - Convert.ToDecimal(frmSepararCuenta.f1.tdC4.Text)) / 1.18m;
            this.lblDescuento.Text = frmSepararCuenta.f1.tdC4.Text;
            this.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(subTotal));
            decimal igv = precioVenta - Convert.ToDecimal(this.lblSubTotal.Text);
            this.lblIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(igv));
            this.lblBanderaCuenta.Text = "4";
            this.lblBanderaComprobante.Text = "0";
            this.btnTicket.BackColor = Color.FromArgb(236, 236, 236);
            this.btnBoleta.BackColor = Color.FromArgb(205, 201, 201);
            this.btnFactura.BackColor = Color.FromArgb(205, 201, 201);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            this.rbEfectivo.Checked = true;
            this.button1.Enabled = true;
            this.txtEfectivo.Select();
            decimal precioVenta, total;
            precioVenta = Convert.ToDecimal(frmSepararCuenta.f1.lblTotalC5.Text);
            total = precioVenta + Convert.ToDecimal(frmSepararCuenta.f1.tdC5.Text);
            this.lblTotal.Text = frmSepararCuenta.f1.lblTotalC5.Text;
            this.lblDescuento.Text = frmSepararCuenta.f1.lblDescuento_Actual.Text;
            decimal subTotal = (precioVenta - Convert.ToDecimal(frmSepararCuenta.f1.tdC5.Text)) / 1.18m;
            this.lblDescuento.Text = frmSepararCuenta.f1.tdC5.Text;
            this.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(subTotal));
            decimal igv = precioVenta - Convert.ToDecimal(this.lblSubTotal.Text);
            this.lblIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(igv));
            this.lblBanderaCuenta.Text = "5";
            this.lblBanderaComprobante.Text = "0";
            this.btnTicket.BackColor = Color.FromArgb(236, 236, 236);
            this.btnBoleta.BackColor = Color.FromArgb(205, 201, 201);
            this.btnFactura.BackColor = Color.FromArgb(205, 201, 201);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            this.rbEfectivo.Checked = true;
            this.button1.Enabled = true;
            this.txtEfectivo.Select();
            decimal precioVenta, total;
            precioVenta = Convert.ToDecimal(frmSepararCuenta.f1.lblTotalC6.Text);
            total = precioVenta + Convert.ToDecimal(frmSepararCuenta.f1.tdC6.Text);
            this.lblTotal.Text = frmSepararCuenta.f1.lblTotalC6.Text;
            this.lblDescuento.Text = frmSepararCuenta.f1.lblDescuento_Actual.Text;
            decimal subTotal = (precioVenta - Convert.ToDecimal(frmSepararCuenta.f1.tdC6.Text)) / 1.18m;
            this.lblDescuento.Text = frmSepararCuenta.f1.tdC6.Text;
            this.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(subTotal));
            decimal igv = precioVenta - Convert.ToDecimal(this.lblSubTotal.Text);
            this.lblIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(igv));
            this.lblBanderaCuenta.Text = "6";
            this.lblBanderaComprobante.Text = "0";
            this.btnTicket.BackColor = Color.FromArgb(236, 236, 236);
            this.btnBoleta.BackColor = Color.FromArgb(205, 201, 201);
            this.btnFactura.BackColor = Color.FromArgb(205, 201, 201);
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
                string rpta = "";
                if (this.lblIdVenta.Text == "0")
                {
                    if (this.txtEfectivo.Text == "" && (this.rbEfectivo.Checked == true || this.rbMixto.Checked == true))
                    {
                        MessageBox.Show("El campo efectivo es obligatorio");
                    }
                    else
                    {
                        if (verMontosPago() == true)
                        {
                            this.verFormaPago();
                            if (lblBanderaCuenta.Text == "1")
                            {
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
                                    rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA", formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim())
                                                                    , Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, tipoCompr, 1, Convert.ToDecimal(this.lblIgv.Text), "EMITIDA",
                                                                    Convert.ToDecimal(this.lblTotal.Text), efectivo, tarjeta, 00.00m,
                                                                    frmSepararCuenta.f1.dtDetalle, vuelto, frmVenta.f1.dtDetalleMenu,
                                                                    DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),"","","","");

                                    this.button1.Enabled = false;
                                }
                                else if (this.lblBanderaComprobante.Text == "2")
                                {
                                    if (this.txtIdCliente.Text.Trim() == string.Empty || this.txtDocumento.Text.Trim().Length != 11)
                                    {
                                        MessageBox.Show("Seleccione un cliente o ingrese un número de RUC válido");
                                        return;
                                    }
                                    else
                                    {
                                        rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA",
                                            formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, "FACTURA",
                                            1, Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), efectivo, tarjeta, 00.00m,
                                            frmSepararCuenta.f1.dtDetalle, vuelto, frmVenta.f1.dtDetalleMenu, DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text), "",
                                            "", "","");

                                        this.button1.Enabled = false;
                                    }

                                }
                                if (rpta == "OK")
                                {
                                    if (insertarCaja() == true)
                                    {
                                        MessageBox.Show("Se registró correctamente");
                                        enviarFormaPago();
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

                                        int count = 0;
                                        DataTable dtCategoriaProducto = new DataTable();
                                        for (int i = 0; i < frmSepararCuenta.f1.dgCuenta1.Rows.Count; i++)
                                        {

                                            dtCategoriaProducto = NCategoria.MostrarCategoriaProducto(Convert.ToInt32(frmSepararCuenta.f1.dgCuenta1.Rows[i].Cells[0].ToString()));
                                            if (dtCategoriaProducto.Rows[0][1].ToString() == "BOCADITOS POR MENOR" || dtCategoriaProducto.Rows[0][1].ToString() == "PANES POR MENOR")
                                            {
                                                count = count + 1;
                                            }

                                        }
                                        if (count != frmSepararCuenta.f1.dgCuenta1.Rows.Count)
                                        {
                                            NImprimir_Comprobante.imprimirCom(Convert.ToInt32(this.lblIdVenta.Text), tipoCompr, this.txtNombre.Text.Trim(), this.txtDireccion.Text.Trim(),
                                                               this.txtDocumento.Text.Trim(), frmSepararCuenta.f1.lblTrabajador.Text, frmSepararCuenta.f1.lblSalon.Text,
                                                               frmSepararCuenta.f1.lblMesa.Text, frmSepararCuenta.f1.dgCuenta1, this.lblDescuento.Text, this.lblDctoGeneral.Text,
                                                               this.lblSubTotal.Text, this.lblIgv.Text, this.lblTotal.Text, efectivo1, vuelto1, tarjeta1, formaPago1, modoProd, "00.00", "");

                                        }


                                        this.Facturador(Convert.ToInt32(this.lblIdVenta.Text), frmSepararCuenta.f1.dgCuenta1);
                                        this.Limpiar();
                                    }
                                    this.btn1.Enabled = false;
                                    if (btn1.Enabled == false && btn2.Enabled == false && btn3.Enabled == false && btn4.Enabled == false && btn5.Enabled == false && btn6.Enabled == false)
                                    {
                                        NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");


                                        frmModuloSalon.f3.limpiarMesas();
                                        frmModuloSalon.f3.mostrarSalones();

                                        this.Hide();
                                        frmVenta.f1.Hide();
                                        frmSepararCuenta.f1.Hide();
                                        frmModuloSalon.f3.tEstado.Enabled = true;

                                    }

                                }
                                else
                                {
                                    MessageBox.Show(rpta);
                                }


                            }
                            else if (lblBanderaCuenta.Text == "2")
                            {
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
                                    rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA",
                                        formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, tipoCompr, 1, Convert.ToDecimal(this.lblIgv.Text), "EMITIDA",
                                                                    Convert.ToDecimal(this.lblTotal.Text), efectivo, tarjeta, 00.00m,
                                                                    frmSepararCuenta.f1.dtDetalle2, vuelto, frmVenta.f1.dtDetalleMenu,
                                                                    DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),"","","","");

                                    this.button1.Enabled = false;

                                }
                                else if (this.lblBanderaComprobante.Text == "2")
                                {
                                    if (this.txtIdCliente.Text.Trim() == string.Empty || this.txtDocumento.Text.Trim().Length != 11)
                                    {
                                        MessageBox.Show("Seleccione un cliente o ingrese un número de RUC válido");
                                        return;
                                    }
                                    else
                                    {
                                        rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA",
                                            formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, "FACTURA", 1,
                                            Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), efectivo,
                                            tarjeta, 00.00m, frmSepararCuenta.f1.dtDetalle2, vuelto, frmVenta.f1.dtDetalleMenu,
                                            DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),"","","","");

                                        this.button1.Enabled = false;
                                    }
                                }
                                if (rpta == "OK")
                                {
                                    if (insertarCaja() == true)
                                    {
                                        MessageBox.Show("Se registró correctamente");
                                        enviarFormaPago();
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

                                        int count = 0;
                                        DataTable dtCategoriaProducto = new DataTable();
                                        for (int i = 0; i < frmSepararCuenta.f1.dgCuenta2.Rows.Count; i++)
                                        {

                                            dtCategoriaProducto = NCategoria.MostrarCategoriaProducto(Convert.ToInt32(frmSepararCuenta.f1.dgCuenta2.Rows[i].Cells[0].ToString()));
                                            if (dtCategoriaProducto.Rows[0][1].ToString() == "BOCADITOS POR MENOR" || dtCategoriaProducto.Rows[0][1].ToString() == "PANES POR MENOR")
                                            {
                                                count = count + 1;
                                            }

                                        }
                                        if (count != frmSepararCuenta.f1.dgCuenta2.Rows.Count)
                                        {
                                            NImprimir_Comprobante.imprimirCom(Convert.ToInt32(this.lblIdVenta.Text), tipoCompr, this.txtNombre.Text.Trim(), this.txtDireccion.Text.Trim(),
                                                            this.txtDocumento.Text.Trim(), frmSepararCuenta.f1.lblTrabajador.Text, frmSepararCuenta.f1.lblSalon.Text,
                                                            frmSepararCuenta.f1.lblMesa.Text, frmSepararCuenta.f1.dgCuenta2, this.lblDescuento.Text, this.lblDctoGeneral.Text,
                                                            this.lblSubTotal.Text, this.lblIgv.Text, this.lblTotal.Text, efectivo1, vuelto1, tarjeta1, formaPago1, modoProd, "00.00", "");
                                        }


                                        this.Facturador(Convert.ToInt32(this.lblIdVenta.Text), frmSepararCuenta.f1.dgCuenta2);
                                        this.Limpiar();
                                    }
                                    this.Limpiar();
                                    this.btn2.Enabled = false;
                                    if (btn1.Enabled == false && btn2.Enabled == false && btn3.Enabled == false && btn4.Enabled == false && btn5.Enabled == false && btn6.Enabled == false)
                                    {
                                        NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                                        frmModuloSalon.f3.limpiarMesas();
                                        frmModuloSalon.f3.mostrarSalones();
                                        this.Hide();
                                        frmVenta.f1.Hide();
                                        frmSepararCuenta.f1.Hide();
                                        frmModuloSalon.f3.tEstado.Enabled = true;

                                    }

                                }
                                else
                                {
                                    MessageBox.Show(rpta);
                                }


                            }
                            else if (lblBanderaCuenta.Text == "3")
                            {
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
                                    rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA", formaPago,
                                        Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, tipoCompr, 1,
                                        Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), efectivo, tarjeta,
                                        00.00m, frmSepararCuenta.f1.dtDetalle3, vuelto, frmVenta.f1.dtDetalleMenu, DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),"",
                                        "","","");

                                    this.button1.Enabled = false;
                                }
                                else if (this.lblBanderaComprobante.Text == "2")
                                {
                                    if (this.txtIdCliente.Text.Trim() == string.Empty || this.txtDocumento.Text.Trim().Length != 11)
                                    {
                                        MessageBox.Show("Seleccione un cliente o ingrese un número de RUC válido");
                                        return;
                                    }
                                    else
                                    {
                                        rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA",
                                            formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, "FACTURA", 1,
                                            Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), efectivo,
                                            tarjeta, 00.00m, frmSepararCuenta.f1.dtDetalle3, vuelto, frmVenta.f1.dtDetalleMenu,
                                            DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),"","","","");

                                        this.button1.Enabled = false;
                                    }
                                }
                                if (rpta == "OK")
                                {
                                    if (insertarCaja() == true)
                                    {
                                        MessageBox.Show("Se registró correctamente");
                                        enviarFormaPago();
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
                                        int count = 0;
                                        DataTable dtCategoriaProducto = new DataTable();
                                        for (int i = 0; i < frmSepararCuenta.f1.dgCuenta3.Rows.Count; i++)
                                        {

                                            dtCategoriaProducto = NCategoria.MostrarCategoriaProducto(Convert.ToInt32(frmSepararCuenta.f1.dgCuenta3.Rows[i].Cells[0].ToString()));
                                            if (dtCategoriaProducto.Rows[0][1].ToString() == "BOCADITOS POR MENOR" || dtCategoriaProducto.Rows[0][1].ToString() == "PANES POR MENOR")
                                            {
                                                count = count + 1;
                                            }

                                        }
                                        if (count != frmSepararCuenta.f1.dgCuenta3.Rows.Count)
                                        {
                                            NImprimir_Comprobante.imprimirCom(Convert.ToInt32(this.lblIdVenta.Text), tipoCompr, this.txtNombre.Text.Trim(), this.txtDireccion.Text.Trim(),
                                                           this.txtDocumento.Text.Trim(), frmSepararCuenta.f1.lblTrabajador.Text, frmSepararCuenta.f1.lblSalon.Text,
                                                           frmSepararCuenta.f1.lblMesa.Text, frmSepararCuenta.f1.dgCuenta3, this.lblDescuento.Text, this.lblDctoGeneral.Text,
                                                           this.lblSubTotal.Text, this.lblIgv.Text, this.lblTotal.Text, efectivo1, vuelto1, tarjeta1, formaPago1, modoProd, "00.00", "");
                                        }

                                        this.Facturador(Convert.ToInt32(this.lblIdVenta.Text), frmSepararCuenta.f1.dgCuenta3);
                                        this.Limpiar();
                                    }
                                    this.Limpiar();
                                    this.btn3.Enabled = false;
                                    if (btn1.Enabled == false && btn2.Enabled == false && btn3.Enabled == false && btn4.Enabled == false && btn5.Enabled == false && btn6.Enabled == false)
                                    {
                                        NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                                        frmModuloSalon.f3.limpiarMesas();
                                        frmModuloSalon.f3.mostrarSalones();
                                        this.Hide();
                                        frmVenta.f1.Hide();
                                        frmSepararCuenta.f1.Hide();
                                        frmModuloSalon.f3.tEstado.Enabled = true;

                                    }

                                }
                                else
                                {
                                    MessageBox.Show(rpta);
                                }


                            }
                            else if (lblBanderaCuenta.Text == "4")
                            {
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
                                    rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA",
                                        formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, tipoCompr, 1,
                                        Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), efectivo, tarjeta,
                                        00.00m, frmSepararCuenta.f1.dtDetalle4, vuelto, frmVenta.f1.dtDetalleMenu,
                                        DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),"","","","");

                                    this.button1.Enabled = false;
                                }
                                else if (this.lblBanderaComprobante.Text == "2")
                                {
                                    if (this.txtIdCliente.Text.Trim() == string.Empty || this.txtDocumento.Text.Trim().Length != 11)
                                    {
                                        MessageBox.Show("Seleccione un cliente o ingrese un número de RUC válido");
                                        return;
                                    }
                                    else
                                    {
                                        rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA",
                                            formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, "FACTURA", 1,
                                            Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), efectivo,
                                            tarjeta, 00.00m, frmSepararCuenta.f1.dtDetalle4, vuelto, frmVenta.f1.dtDetalleMenu,
                                            DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),"","","","");

                                        this.button1.Enabled = false;
                                    }
                                }
                                if (rpta == "OK")
                                {
                                    if (insertarCaja() == true)
                                    {
                                        MessageBox.Show("Se registró correctamente");
                                        enviarFormaPago();
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

                                        int count = 0;
                                        DataTable dtCategoriaProducto = new DataTable();
                                        for (int i = 0; i < frmSepararCuenta.f1.dgCuenta4.Rows.Count; i++)
                                        {

                                            dtCategoriaProducto = NCategoria.MostrarCategoriaProducto(Convert.ToInt32(frmSepararCuenta.f1.dgCuenta4.Rows[i].Cells[0].ToString()));
                                            if (dtCategoriaProducto.Rows[0][1].ToString() == "BOCADITOS POR MENOR" || dtCategoriaProducto.Rows[0][1].ToString() == "PANES POR MENOR")
                                            {
                                                count = count + 1;
                                            }

                                        }
                                        if (count != frmSepararCuenta.f1.dgCuenta4.Rows.Count)
                                        {
                                            NImprimir_Comprobante.imprimirCom(Convert.ToInt32(this.lblIdVenta.Text), tipoCompr, this.txtNombre.Text.Trim(), this.txtDireccion.Text.Trim(),
                                                                this.txtDocumento.Text.Trim(), frmSepararCuenta.f1.lblTrabajador.Text, frmSepararCuenta.f1.lblSalon.Text,
                                                                frmSepararCuenta.f1.lblMesa.Text, frmSepararCuenta.f1.dgCuenta4, this.lblDescuento.Text, this.lblDctoGeneral.Text,
                                                                this.lblSubTotal.Text, this.lblIgv.Text, this.lblTotal.Text, efectivo1, vuelto1, tarjeta1, formaPago1, modoProd, "00.00", "");
                                        }

                                        this.Facturador(Convert.ToInt32(this.lblIdVenta.Text), frmSepararCuenta.f1.dgCuenta4);
                                        this.Limpiar();
                                    }
                                    this.Limpiar();
                                    this.btn4.Enabled = false;
                                    if (btn1.Enabled == false && btn2.Enabled == false && btn3.Enabled == false && btn4.Enabled == false && btn5.Enabled == false && btn6.Enabled == false)
                                    {
                                        NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                                        frmModuloSalon.f3.limpiarMesas();
                                        frmModuloSalon.f3.mostrarSalones();
                                        this.Hide();
                                        frmVenta.f1.Hide();
                                        frmSepararCuenta.f1.Hide();
                                        frmModuloSalon.f3.tEstado.Enabled = true;

                                    }

                                }
                                else
                                {
                                    MessageBox.Show(rpta);
                                }


                            }
                            else if (lblBanderaCuenta.Text == "5")
                            {
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
                                    rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA",
                                        formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, tipoCompr, 1,
                                        Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", efectivo, tarjeta, Convert.ToDecimal(this.lblTotal.Text),
                                        00.00m, frmSepararCuenta.f1.dtDetalle5, vuelto, frmVenta.f1.dtDetalleMenu,
                                        DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text), "", "","","");

                                    this.button1.Enabled = false;
                                }
                                else if (this.lblBanderaComprobante.Text == "2")
                                {
                                    if (this.txtIdCliente.Text.Trim() == string.Empty || this.txtDocumento.Text.Trim().Length != 11)
                                    {
                                        MessageBox.Show("Seleccione un cliente o ingrese un número de RUC válido");
                                        return;
                                    }
                                    else
                                    {
                                        rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA",
                                            formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, "FACTURA", 1,
                                            Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), efectivo,
                                            tarjeta, 00.00m, frmSepararCuenta.f1.dtDetalle5, vuelto, frmVenta.f1.dtDetalleMenu,
                                            DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),"","","","");

                                        this.button1.Enabled = false;
                                    }
                                }
                                if (rpta == "OK")
                                {
                                    if (insertarCaja() == true)
                                    {
                                        MessageBox.Show("Se registró correctamente");
                                        enviarFormaPago();
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

                                        int count = 0;
                                        DataTable dtCategoriaProducto = new DataTable();
                                        for (int i = 0; i < frmSepararCuenta.f1.dgCuenta5.Rows.Count; i++)
                                        {

                                            dtCategoriaProducto = NCategoria.MostrarCategoriaProducto(Convert.ToInt32(frmSepararCuenta.f1.dgCuenta5.Rows[i].Cells[0].ToString()));
                                            if (dtCategoriaProducto.Rows[0][1].ToString() == "BOCADITOS POR MENOR" || dtCategoriaProducto.Rows[0][1].ToString() == "PANES POR MENOR")
                                            {
                                                count = count + 1;
                                            }

                                        }
                                        if (count != frmSepararCuenta.f1.dgCuenta5.Rows.Count)
                                        {
                                            NImprimir_Comprobante.imprimirCom(Convert.ToInt32(this.lblIdVenta.Text), tipoCompr, this.txtNombre.Text.Trim(), this.txtDireccion.Text.Trim(),
                                                                    this.txtDocumento.Text.Trim(), frmSepararCuenta.f1.lblTrabajador.Text, frmSepararCuenta.f1.lblSalon.Text,
                                                                    frmSepararCuenta.f1.lblMesa.Text, frmSepararCuenta.f1.dgCuenta5, this.lblDescuento.Text, this.lblDctoGeneral.Text,
                                                                    this.lblSubTotal.Text, this.lblIgv.Text, this.lblTotal.Text, efectivo1, vuelto1, tarjeta1, formaPago1, modoProd, "00.00", "");
                                        }


                                        this.Facturador(Convert.ToInt32(this.lblIdVenta.Text), frmSepararCuenta.f1.dgCuenta5);
                                        this.Limpiar();
                                    }
                                    this.Limpiar();
                                    this.btn5.Enabled = false;
                                    if (btn1.Enabled == false && btn2.Enabled == false && btn3.Enabled == false && btn4.Enabled == false && btn5.Enabled == false && btn6.Enabled == false)
                                    {
                                        NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                                        frmModuloSalon.f3.limpiarMesas();
                                        frmModuloSalon.f3.mostrarSalones();
                                        this.Hide();
                                        frmVenta.f1.Hide();
                                        frmSepararCuenta.f1.Hide();
                                        frmModuloSalon.f3.tEstado.Enabled = true;

                                    }

                                }
                                else
                                {
                                    MessageBox.Show(rpta);
                                }

                            }
                            else if (lblBanderaCuenta.Text == "6")
                            {
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
                                    rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA",
                                        formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, tipoCompr, 1,
                                        Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), efectivo,
                                        tarjeta, 00.00m, frmSepararCuenta.f1.dtDetalle6, vuelto, frmVenta.f1.dtDetalleMenu,
                                        DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),"","","","");

                                    this.button1.Enabled = false;
                                }
                                else if (this.lblBanderaComprobante.Text == "2")
                                {
                                    if (this.txtIdCliente.Text.Trim() == string.Empty || this.txtDocumento.Text.Trim().Length != 11)
                                    {
                                        MessageBox.Show("Seleccione un cliente o ingrese un número de RUC válido");
                                        return;
                                    }
                                    else
                                    {
                                        rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA",
                                            formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, "FACTURA", 1,
                                            Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), efectivo,
                                            tarjeta, 00.00m, frmSepararCuenta.f1.dtDetalle6, vuelto, frmVenta.f1.dtDetalleMenu,
                                            DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),"","","","");

                                        this.button1.Enabled = false;
                                    }
                                }
                                if (rpta == "OK")
                                {
                                    if (insertarCaja() == true)
                                    {
                                        MessageBox.Show("Se registró correctamente");
                                        enviarFormaPago();
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
                                        int count = 0;
                                        DataTable dtCategoriaProducto = new DataTable();
                                        for (int i = 0; i < frmSepararCuenta.f1.dgCuenta6.Rows.Count; i++)
                                        {

                                            dtCategoriaProducto = NCategoria.MostrarCategoriaProducto(Convert.ToInt32(frmSepararCuenta.f1.dgCuenta6.Rows[i].Cells[0].ToString()));
                                            if (dtCategoriaProducto.Rows[0][1].ToString() == "BOCADITOS POR MENOR" || dtCategoriaProducto.Rows[0][1].ToString() == "PANES POR MENOR")
                                            {
                                                count = count + 1;
                                            }

                                        }
                                        if (count != frmSepararCuenta.f1.dgCuenta6.Rows.Count)
                                        {
                                            NImprimir_Comprobante.imprimirCom(Convert.ToInt32(this.lblIdVenta.Text), tipoCompr, this.txtNombre.Text.Trim(), this.txtDireccion.Text.Trim(),
                                                                this.txtDocumento.Text.Trim(), frmSepararCuenta.f1.lblTrabajador.Text, frmSepararCuenta.f1.lblSalon.Text,
                                                                frmSepararCuenta.f1.lblMesa.Text, frmSepararCuenta.f1.dgCuenta6, this.lblDescuento.Text, this.lblDctoGeneral.Text,
                                                                this.lblSubTotal.Text, this.lblIgv.Text, this.lblTotal.Text, efectivo1, vuelto1, tarjeta1, formaPago1, modoProd, "00.00", "");
                                        }

                                        this.Facturador(Convert.ToInt32(this.lblIdVenta.Text), frmSepararCuenta.f1.dgCuenta6);
                                        this.Limpiar();
                                    }
                                    this.Limpiar();
                                    this.btn6.Enabled = false;
                                    if (btn1.Enabled == false && btn2.Enabled == false && btn3.Enabled == false && btn4.Enabled == false && btn5.Enabled == false && btn6.Enabled == false)
                                    {
                                        NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                                        frmModuloSalon.f3.limpiarMesas();
                                        frmModuloSalon.f3.mostrarSalones();
                                        this.Hide();
                                        frmVenta.f1.Hide();
                                        frmSepararCuenta.f1.Hide();
                                        frmModuloSalon.f3.tEstado.Enabled = true;

                                    }

                                }
                                else
                                {
                                    MessageBox.Show(rpta);
                                }

                            }
                        }
                    }
                }

                //AQUI OTRO
                else if (this.lblIdVenta.Text != "0")
                {
                    if (this.txtEfectivo.Text == "" && (this.rbEfectivo.Checked == true || this.rbMixto.Checked == true))
                    {
                        MessageBox.Show("El campo efectivo es obligatorio");
                    }
                    else
                    {
                        if (verMontosPago() == true)
                        {
                            this.verFormaPago();

                            if (lblBanderaCuenta.Text == "1")
                            {

                                //recorrer dg1 y eliminar detalles
                                if (this.txtIdCliente.Text == string.Empty && this.lblBanderaComprobante.Text == "2")
                                {
                                    MessageBox.Show("Seleccione un cliente");
                                    return;
                                }
                                else if (this.lblBanderaComprobante.Text == "2" && this.txtDocumento.Text.Trim().Length != 11)
                                {
                                    MessageBox.Show("Ingrese un número de RUC válido");
                                    return;
                                }
                                else
                                {
                                    for (int i = 0; i < frmSepararCuenta.f1.dtDetalle.Rows.Count; i++)
                                    {
                                        rpta = NDetalleVenta.Eliminar(Convert.ToInt32(frmSepararCuenta.f1.dtDetalle.Rows[i]["idDetalleVenta"].ToString()));
                                    }

                                }


                                if (rpta == "OK")
                                {
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
                                        rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA",
                                            formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, tipoCompr, 1,
                                            Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), efectivo,
                                            tarjeta, 00.00m, frmSepararCuenta.f1.dtDetalle, vuelto, frmVenta.f1.dtDetalleMenu,
                                            DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),"","","","");


                                        this.button1.Enabled = false;
                                    }
                                    else if (this.lblBanderaComprobante.Text == "2")
                                    {
                                        if (this.txtIdCliente.Text.Trim() == string.Empty || this.txtDocumento.Text.Trim().Length != 11)
                                        {
                                            MessageBox.Show("Seleccione un cliente o ingrese un número de RUC válido");
                                            return;
                                        }
                                        else
                                        {
                                            rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA",
                                                formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, "FACTURA", 1,
                                                Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), efectivo,
                                                tarjeta, 00.00m, frmSepararCuenta.f1.dtDetalle, vuelto, frmVenta.f1.dtDetalleMenu,
                                                DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),"","","","");

                                            this.button1.Enabled = false;

                                        }

                                    }
                                    if (rpta != "")
                                    {
                                        if (insertarCaja() == true)
                                        {
                                            MessageBox.Show("Se registró correctamente");
                                            enviarFormaPago();
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

                                                NImprimir_Comprobante.imprimirCom(Convert.ToInt32(rpta), tipoCompr, this.txtNombre.Text.Trim(), this.txtDireccion.Text.Trim(),
                                                                this.txtDocumento.Text.Trim(), frmSepararCuenta.f1.lblTrabajador.Text, frmSepararCuenta.f1.lblSalon.Text,
                                                                frmSepararCuenta.f1.lblMesa.Text, frmSepararCuenta.f1.dgCuenta1, this.lblDescuento.Text, this.lblDctoGeneral.Text,
                                                                this.lblSubTotal.Text, this.lblIgv.Text, this.lblTotal.Text, efectivo1, vuelto1, tarjeta1, formaPago1, modoProd, "00.00", "");
                                           


                                            this.Facturador(Convert.ToInt32(rpta), frmSepararCuenta.f1.dgCuenta1);
                                            this.Limpiar();
                                        }

                                        this.btn1.Enabled = false;
                                        if (btn1.Enabled == false && btn2.Enabled == false && btn3.Enabled == false && btn4.Enabled == false && btn5.Enabled == false && btn6.Enabled == false)
                                        {
                                            rpta = NVenta.EliminarCS(Convert.ToInt32(this.lblIdVenta.Text));
                                            NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                                            frmModuloSalon.f3.limpiarMesas();
                                            frmModuloSalon.f3.mostrarSalones();
                                            this.Hide();
                                            frmVenta.f1.Hide();
                                            frmSepararCuenta.f1.Hide();
                                            frmModuloSalon.f3.tEstado.Enabled = true;

                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show(rpta);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(rpta);
                                }


                            }
                            else if (lblBanderaCuenta.Text == "2")
                            {
                                if (this.txtIdCliente.Text == string.Empty && this.lblBanderaComprobante.Text == "2")
                                {
                                    MessageBox.Show("Seleccione un cliente");
                                    return;
                                }
                                else if (this.lblBanderaComprobante.Text == "2" && this.txtDocumento.Text.Trim().Length != 11)
                                {
                                    MessageBox.Show("Ingrese un número de RUC válido");
                                    return;
                                }
                                else
                                {
                                    for (int i = 0; i < frmSepararCuenta.f1.dtDetalle2.Rows.Count; i++)
                                    {
                                        rpta = NDetalleVenta.Eliminar(Convert.ToInt32(frmSepararCuenta.f1.dtDetalle2.Rows[i]["idDetalleVenta"].ToString()));

                                    }
                                }

                                if (rpta == "OK")
                                {
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
                                        rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA",
                                            formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, tipoCompr, 1,
                                            Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), efectivo,
                                            tarjeta, 00.00m, frmSepararCuenta.f1.dtDetalle2, vuelto, frmVenta.f1.dtDetalleMenu,
                                            DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),"","","","");

                                        this.button1.Enabled = false;
                                    }
                                    else if (this.lblBanderaComprobante.Text == "2")
                                    {
                                        if (this.txtIdCliente.Text.Trim() == string.Empty || this.txtDocumento.Text.Trim().Length != 11)
                                        {
                                            MessageBox.Show("Seleccione un cliente o ingrese un número de RUC válido");
                                            return;
                                        }
                                        else
                                        {
                                            rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA",
                                                formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, "FACTURA", 1,
                                                Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", Convert.ToDecimal(this.lblTotal.Text),
                                                efectivo, tarjeta, 00.00m, frmSepararCuenta.f1.dtDetalle2, vuelto, frmVenta.f1.dtDetalleMenu,
                                                DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),"","","","");

                                            this.button1.Enabled = false;
                                        }
                                    }
                                    if (rpta != "")
                                    {
                                        if (insertarCaja() == true)
                                        {
                                            MessageBox.Show("Se registró correctamente");
                                            enviarFormaPago();
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


                                                NImprimir_Comprobante.imprimirCom(Convert.ToInt32(rpta), tipoCompr, this.txtNombre.Text.Trim(), this.txtDireccion.Text.Trim(),
                                                                this.txtDocumento.Text.Trim(), frmSepararCuenta.f1.lblTrabajador.Text, frmSepararCuenta.f1.lblSalon.Text,
                                                                frmSepararCuenta.f1.lblMesa.Text, frmSepararCuenta.f1.dgCuenta2, this.lblDescuento.Text, this.lblDctoGeneral.Text,
                                                                this.lblSubTotal.Text, this.lblIgv.Text, this.lblTotal.Text, efectivo1, vuelto1, tarjeta1, formaPago1, modoProd, "00.00", "");
                                           

                                            this.Facturador(Convert.ToInt32(rpta), frmSepararCuenta.f1.dgCuenta2);
                                            this.Limpiar();
                                        }

                                        this.btn2.Enabled = false;
                                        if (btn1.Enabled == false && btn2.Enabled == false && btn3.Enabled == false && btn4.Enabled == false && btn5.Enabled == false && btn6.Enabled == false)
                                        {
                                            rpta = NVenta.EliminarCS(Convert.ToInt32(this.lblIdVenta.Text));
                                            NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                                            frmModuloSalon.f3.limpiarMesas();
                                            frmModuloSalon.f3.mostrarSalones();
                                            this.Hide();
                                            frmVenta.f1.Hide();
                                            frmSepararCuenta.f1.Hide();
                                            frmModuloSalon.f3.tEstado.Enabled = true;

                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show(rpta);
                                    }

                                }
                                else
                                {
                                    MessageBox.Show(rpta);
                                }

                            }
                            else if (lblBanderaCuenta.Text == "3")
                            {
                                if (this.txtIdCliente.Text == string.Empty && this.lblBanderaComprobante.Text == "2")
                                {
                                    MessageBox.Show("Seleccione un cliente");
                                    return;
                                }
                                else if (this.lblBanderaComprobante.Text == "2" && this.txtDocumento.Text.Trim().Length != 11)
                                {
                                    MessageBox.Show("Ingrese un número de RUC válido");
                                    return;
                                }
                                else
                                {
                                    for (int i = 0; i < frmSepararCuenta.f1.dtDetalle3.Rows.Count; i++)
                                    {
                                        rpta = NDetalleVenta.Eliminar(Convert.ToInt32(frmSepararCuenta.f1.dtDetalle3.Rows[i]["idDetalleVenta"].ToString()));
                                    }
                                }

                                if (rpta == "OK")
                                {
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
                                        rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA",
                                            formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, tipoCompr, 1,
                                            Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), efectivo,
                                            tarjeta, 00.00m, frmSepararCuenta.f1.dtDetalle3, vuelto, frmVenta.f1.dtDetalleMenu,
                                            DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),"","","","");

                                        this.button1.Enabled = false;
                                    }
                                    else if (this.lblBanderaComprobante.Text == "2")
                                    {
                                        if (this.txtIdCliente.Text.Trim() == string.Empty || this.txtDocumento.Text.Trim().Length != 11)
                                        {
                                            MessageBox.Show("Seleccione un cliente o ingrese un número de RUC válido");
                                            return;
                                        }
                                        else
                                        {
                                            rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA",
                                                formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, "FACTURA", 1,
                                                Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), efectivo,
                                                tarjeta, 00.00m, frmSepararCuenta.f1.dtDetalle3, vuelto, frmVenta.f1.dtDetalleMenu,
                                                DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),"","","","");

                                            this.button1.Enabled = false;
                                        }
                                    }
                                    if (rpta != "")
                                    {
                                        if (insertarCaja() == true)
                                        {
                                            MessageBox.Show("Se registró correctamente");
                                            enviarFormaPago();
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

                                                NImprimir_Comprobante.imprimirCom(Convert.ToInt32(rpta), tipoCompr, this.txtNombre.Text.Trim(), this.txtDireccion.Text.Trim(),
                                                                   this.txtDocumento.Text.Trim(), frmSepararCuenta.f1.lblTrabajador.Text, frmSepararCuenta.f1.lblSalon.Text,
                                                                   frmSepararCuenta.f1.lblMesa.Text, frmSepararCuenta.f1.dgCuenta3, this.lblDescuento.Text, this.lblDctoGeneral.Text,
                                                                   this.lblSubTotal.Text, this.lblIgv.Text, this.lblTotal.Text, efectivo1, vuelto1, tarjeta1, formaPago1, modoProd, "00.00", "");
                                          


                                            this.Facturador(Convert.ToInt32(rpta), frmSepararCuenta.f1.dgCuenta3);
                                            this.Limpiar();
                                        }

                                        this.btn3.Enabled = false;
                                        if (btn1.Enabled == false && btn2.Enabled == false && btn3.Enabled == false && btn4.Enabled == false && btn5.Enabled == false && btn6.Enabled == false)
                                        {
                                            rpta = NVenta.EliminarCS(Convert.ToInt32(this.lblIdVenta.Text));
                                            NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                                            frmModuloSalon.f3.limpiarMesas();
                                            frmModuloSalon.f3.mostrarSalones();
                                            this.Hide();
                                            frmVenta.f1.Hide();
                                            frmSepararCuenta.f1.Hide();
                                            frmModuloSalon.f3.tEstado.Enabled = true;

                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show(rpta);
                                    }


                                }
                                else
                                {
                                    MessageBox.Show(rpta);
                                }


                            }
                            else if (lblBanderaCuenta.Text == "4")
                            {
                                if (this.txtIdCliente.Text == string.Empty && this.lblBanderaComprobante.Text == "2")
                                {
                                    MessageBox.Show("Seleccione un cliente");
                                    return;
                                }
                                else if (this.lblBanderaComprobante.Text == "2" && this.txtDocumento.Text.Trim().Length != 11)
                                {
                                    MessageBox.Show("Ingrese un número de RUC válido");
                                    return;
                                }
                                else
                                {
                                    for (int i = 0; i < frmSepararCuenta.f1.dtDetalle4.Rows.Count; i++)
                                    {
                                        rpta = NDetalleVenta.Eliminar(Convert.ToInt32(frmSepararCuenta.f1.dtDetalle4.Rows[i]["idDetalleVenta"].ToString()));
                                    }

                                }

                                if (rpta == "OK")
                                {
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
                                        rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA",
                                            formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, tipoCompr, 1,
                                            Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), efectivo, tarjeta, 00.00m,
                                            frmSepararCuenta.f1.dtDetalle4, vuelto, frmVenta.f1.dtDetalleMenu, DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),"",
                                            "","","");

                                        this.button1.Enabled = false;
                                    }
                                    else if (this.lblBanderaComprobante.Text == "2")
                                    {
                                        if (this.txtIdCliente.Text.Trim() == string.Empty || this.txtDocumento.Text.Trim().Length != 11)
                                        {
                                            MessageBox.Show("Seleccione un cliente o ingrese un número de RUC válido");
                                            return;
                                        }
                                        else
                                        {
                                            rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA",
                                                formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, "FACTURA", 1,
                                                Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), efectivo, tarjeta, 00.00m,
                                                frmSepararCuenta.f1.dtDetalle4, vuelto, frmVenta.f1.dtDetalleMenu, DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),"",
                                                "","","");

                                            this.button1.Enabled = false;
                                        }
                                    }
                                    if (rpta != "")
                                    {
                                        if (insertarCaja() == true)
                                        {
                                            MessageBox.Show("Se registró correctamente");
                                            enviarFormaPago();
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

                                                NImprimir_Comprobante.imprimirCom(Convert.ToInt32(rpta), tipoCompr, this.txtNombre.Text.Trim(), this.txtDireccion.Text.Trim(),
                                                                   this.txtDocumento.Text.Trim(), frmSepararCuenta.f1.lblTrabajador.Text, frmSepararCuenta.f1.lblSalon.Text,
                                                                   frmSepararCuenta.f1.lblMesa.Text, frmSepararCuenta.f1.dgCuenta4, this.lblDescuento.Text, this.lblDctoGeneral.Text,
                                                                   this.lblSubTotal.Text, this.lblIgv.Text, this.lblTotal.Text, efectivo1, vuelto1, tarjeta1, formaPago1, modoProd, "00.00", "");
                                         

                                            this.Facturador(Convert.ToInt32(rpta), frmSepararCuenta.f1.dgCuenta4);
                                            this.Limpiar();
                                        }

                                        this.btn4.Enabled = false;
                                        if (btn1.Enabled == false && btn2.Enabled == false && btn3.Enabled == false && btn4.Enabled == false && btn5.Enabled == false && btn6.Enabled == false)
                                        {
                                            rpta = NVenta.EliminarCS(Convert.ToInt32(this.lblIdVenta.Text));
                                            NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                                            frmModuloSalon.f3.limpiarMesas();
                                            frmModuloSalon.f3.mostrarSalones();
                                            this.Hide();
                                            frmVenta.f1.Hide();
                                            frmSepararCuenta.f1.Hide();
                                            frmModuloSalon.f3.tEstado.Enabled = true;

                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show(rpta);
                                    }
                                }

                                else
                                {
                                    MessageBox.Show(rpta);
                                }

                            }
                            else if (lblBanderaCuenta.Text == "5")
                            {
                                if (this.txtIdCliente.Text == string.Empty && this.lblBanderaComprobante.Text == "2")
                                {
                                    MessageBox.Show("Seleccione un cliente");
                                    return;
                                }
                                else if (this.lblBanderaComprobante.Text == "2" && this.txtDocumento.Text.Trim().Length != 11)
                                {
                                    MessageBox.Show("Ingrese un número de RUC válido");
                                    return;
                                }
                                else
                                {
                                    for (int i = 0; i < frmSepararCuenta.f1.dtDetalle5.Rows.Count; i++)
                                    {
                                        rpta = NDetalleVenta.Eliminar(Convert.ToInt32(frmSepararCuenta.f1.dtDetalle5.Rows[i]["idDetalleVenta"].ToString()));
                                    }
                                }

                                if (rpta == "OK")
                                {
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
                                        rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA",
                                            formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, tipoCompr, 1,
                                            Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), efectivo, tarjeta, 00.00m,
                                            frmSepararCuenta.f1.dtDetalle5, vuelto, frmVenta.f1.dtDetalleMenu, DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),"",
                                            "","","");

                                        this.button1.Enabled = false;
                                    }
                                    else if (this.lblBanderaComprobante.Text == "2")
                                    {
                                        if (this.txtIdCliente.Text.Trim() == string.Empty || this.txtDocumento.Text.Trim().Length != 11)
                                        {
                                            MessageBox.Show("Seleccione un cliente o ingrese un número de RUC válido");
                                            return;
                                        }
                                        else
                                        {
                                            rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA",
                                                formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, "FACTURA", 1,
                                                Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), efectivo, tarjeta, 00.00m,
                                                frmSepararCuenta.f1.dtDetalle5, vuelto, frmVenta.f1.dtDetalleMenu, DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text), "",
                                                "", "","");

                                            this.button1.Enabled = false;
                                        }
                                    }
                                    if (rpta != "")
                                    {
                                        if (insertarCaja() == true)
                                        {
                                            MessageBox.Show("Se registró correctamente");
                                            enviarFormaPago();
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


                                                NImprimir_Comprobante.imprimirCom(Convert.ToInt32(rpta), tipoCompr, this.txtNombre.Text.Trim(), this.txtDireccion.Text.Trim(),
                                                                    this.txtDocumento.Text.Trim(), frmSepararCuenta.f1.lblTrabajador.Text, frmSepararCuenta.f1.lblSalon.Text,
                                                                    frmSepararCuenta.f1.lblMesa.Text, frmSepararCuenta.f1.dgCuenta5, this.lblDescuento.Text, this.lblDctoGeneral.Text,
                                                                    this.lblSubTotal.Text, this.lblIgv.Text, this.lblTotal.Text, efectivo1, vuelto1, tarjeta1, formaPago1, modoProd, "00.00", "");
                                            

                                            this.Facturador(Convert.ToInt32(rpta), frmSepararCuenta.f1.dgCuenta5);
                                            this.Limpiar();
                                        }

                                        this.btn5.Enabled = false;
                                        if (btn1.Enabled == false && btn2.Enabled == false && btn3.Enabled == false && btn4.Enabled == false && btn5.Enabled == false && btn6.Enabled == false)
                                        {
                                            NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                                            rpta = NVenta.EliminarCS(Convert.ToInt32(this.lblIdVenta.Text));
                                            frmModuloSalon.f3.limpiarMesas();
                                            frmModuloSalon.f3.mostrarSalones();
                                            this.Hide();
                                            frmVenta.f1.Hide();
                                            frmSepararCuenta.f1.Hide();
                                            frmModuloSalon.f3.tEstado.Enabled = true;

                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show(rpta);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(rpta);
                                }

                            }
                            else if (lblBanderaCuenta.Text == "6")
                            {
                                if (this.txtIdCliente.Text == string.Empty && this.lblBanderaComprobante.Text == "2")
                                {
                                    MessageBox.Show("Seleccione un cliente");
                                    return;
                                }
                                else if (this.lblBanderaComprobante.Text == "2" && this.txtDocumento.Text.Trim().Length != 11)
                                {
                                    MessageBox.Show("Ingrese un número de RUC válido");
                                    return;
                                }
                                else
                                {
                                    for (int i = 0; i < frmSepararCuenta.f1.dtDetalle6.Rows.Count; i++)
                                    {
                                        rpta = NDetalleVenta.Eliminar(Convert.ToInt32(frmSepararCuenta.f1.dtDetalle6.Rows[i]["idDetalleVenta"].ToString()));
                                    }
                                }

                                if (rpta == "OK")
                                {
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
                                        rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA",
                                            formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, tipoCompr, 1,
                                            Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), efectivo, tarjeta, 00.00m,
                                            frmSepararCuenta.f1.dtDetalle6, vuelto, frmVenta.f1.dtDetalleMenu, DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),"","",
                                            "","");

                                        this.button1.Enabled = false;
                                    }
                                    else if (this.lblBanderaComprobante.Text == "2")
                                    {
                                        if (this.txtIdCliente.Text.Trim() == string.Empty || this.txtDocumento.Text.Trim().Length != 11)
                                        {
                                            MessageBox.Show("Seleccione un cliente o ingrese un número de RUC válido");
                                            return;
                                        }
                                        else
                                        {
                                            rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA",
                                                formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, "FACTURA", 1,
                                                Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", Convert.ToDecimal(this.lblTotal.Text),
                                                efectivo, tarjeta, 00.00m, frmSepararCuenta.f1.dtDetalle6, vuelto, frmVenta.f1.dtDetalleMenu,
                                                DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),"","","","");

                                            this.button1.Enabled = false;
                                        }
                                    }
                                    if (rpta != "")
                                    {
                                        if (insertarCaja() == true)
                                        {
                                            MessageBox.Show("Se registró correctamente");
                                            enviarFormaPago();
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


                                                NImprimir_Comprobante.imprimirCom(Convert.ToInt32(rpta), tipoCompr, this.txtNombre.Text.Trim(), this.txtDireccion.Text.Trim(),
                                                            this.txtDocumento.Text.Trim(), frmSepararCuenta.f1.lblTrabajador.Text, frmSepararCuenta.f1.lblSalon.Text,
                                                            frmSepararCuenta.f1.lblMesa.Text, frmSepararCuenta.f1.dgCuenta6, this.lblDescuento.Text, this.lblDctoGeneral.Text,
                                                            this.lblSubTotal.Text, this.lblIgv.Text, this.lblTotal.Text, efectivo1, vuelto1, tarjeta1, formaPago1, modoProd, "00.00", "");
                                            

                                            this.Facturador(Convert.ToInt32(rpta), frmSepararCuenta.f1.dgCuenta6);
                                            this.Limpiar();
                                        }

                                        this.btn6.Enabled = false;
                                        if (btn1.Enabled == false && btn2.Enabled == false && btn3.Enabled == false && btn4.Enabled == false && btn5.Enabled == false && btn6.Enabled == false)
                                        {
                                            NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                                            rpta = NVenta.EliminarCS(Convert.ToInt32(this.lblIdVenta.Text));
                                            frmModuloSalon.f3.limpiarMesas();
                                            frmModuloSalon.f3.mostrarSalones();
                                            this.Hide();
                                            frmVenta.f1.Hide();
                                            frmSepararCuenta.f1.Hide();
                                            frmModuloSalon.f3.tEstado.Enabled = true;

                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show(rpta);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(rpta);
                                }

                            }
                            NVenta.EditarVentaCS(Convert.ToInt32(this.lblIdVenta.Text));

                        }

                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cobrar();
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
            decimal totalSubTotalText =(totalText  - Convert.ToDecimal(this.lblDctoGeneral.Text)) / 1.18m;

            this.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalSubTotalText));
            decimal totalIgvText = totalText - totalSubTotalText;
            this.lblIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalIgvText));
            this.dataListadoProducto.Select();
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            frmVistaClientePago_Separado form = new frmVistaClientePago_Separado();
            form.ShowDialog();
            this.dataListadoProducto.Select();
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
                    this.dataListadoProducto.Select();
                }
                else if (this.txtEfectivo.Text.Length != 0)
                {
                    this.txtEfectivo.Text = this.txtEfectivo.Text.Substring(0, this.txtEfectivo.Text.Length - 1);
                    this.dataListadoProducto.Select();

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

        private void txtEfectivo_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotales();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnDescuentoTotal_Click(object sender, EventArgs e)
        {
            frmDescuentoTotal form = new frmDescuentoTotal();
            form.lblIdBandera.Text = "1";
            form.ShowDialog();
            this.dataListadoProducto.Select();
        }

        private bool verMontosPago()
        {
            if (rbEfectivo.Checked == true)
            {
                efectivo = Convert.ToDecimal(this.lblTotal.Text);
                tarjeta = 00.00m;
                return true;
            }
            else if (rbTarjeta.Checked == true)
            {
                efectivo = 00.00m;
                tarjeta = Convert.ToDecimal(this.lblTotal.Text);
                return true;
            }
            else if (rbMixto.Checked == true)
            {
                if (this.txtEfectivo.Text.Trim().Equals(string.Empty) || this.txtTarjeta.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Complete el campo efectivo y/o tarjeta");
                    return false;
                }
                else
                {
                    if (Convert.ToDecimal(this.lblTotal.Text) > (Convert.ToDecimal(this.txtEfectivo.Text) + Convert.ToDecimal(this.txtTarjeta.Text)))
                    {
                        MessageBox.Show("Los monto son menores al total, complete los campos");
                        return false;
                    }
                    else
                    {
                        efectivo = Convert.ToDecimal(this.txtEfectivo.Text.Trim());
                        tarjeta = Convert.ToDecimal(this.txtTarjeta.Text.Trim());
                        return true;
                    }

                }
            }
            return true;
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

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                DataTable dtClienteVenta;
                dtClienteVenta = NCliente.mostrarClienteVenta(this.txtDocumento.Text.Trim());
                if (dtClienteVenta.Rows.Count <= 0)
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
            if (this.txtDocumento.Text.Length == 11)
            {
                if (this.txtNombre.Text.Trim() == "" || this.txtDireccion.Text.Trim() == "")
                {
                    MessageBox.Show("Complete el nombre y dirección");
                    this.dataListadoProducto.Select();
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

            }
            else if (this.txtDocumento.Text.Length == 8)
            {
                if (this.txtNombre.Text.Trim() == "" || this.txtDireccion.Text.Trim() == "")
                {
                    MessageBox.Show("Complete el nombre y dirección");
                }
                else
                {
                    rpta = NCliente.InsertarVenta(this.txtNombre.Text.Trim().ToUpper(), DateTime.MinValue, "DNI", this.txtDocumento.Text, this.txtDireccion.Text.Trim(), "", "");
                    this.txtIdCliente.Text = rpta;
                    this.txtNombre.ReadOnly = true;
                    this.txtDireccion.ReadOnly = true;
                }

            }
            else
            {
                MessageBox.Show("Ingrese un nro de Documento válido");
            }
        }

        private void rbConsumo_CheckedChanged(object sender, EventArgs e)
        {
            btnBoleta.Enabled = true;
            btnFactura.Enabled = true;
            btnTicket.Enabled = true;
            this.dataListadoProducto.Select();
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

        private void rbDetallado_CheckedChanged(object sender, EventArgs e)
        {
            btnBoleta.Enabled = true;
            btnFactura.Enabled = true;
            btnTicket.Enabled = true;
            this.dataListadoProducto.Select();
        }

        private void txtEfectivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                Cobrar();

            }
        }

        private void dataListadoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                Cobrar();

            }
        }

        private void rbEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEfectivo.Checked == true)
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

        private void rbMixto_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMixto.Checked == true)
            {
                this.txtEfectivo.ReadOnly = false;
                this.txtTarjeta.ReadOnly = true;
                this.txtVuelto.ReadOnly = true;
                this.txtEfectivo.Focus();
                mostrarTotales();
                this.dataListadoProducto.Select();
            }
        }

        private void txtEfectivo_Click(object sender, EventArgs e)
        {
            this.lblBanderaTexto.Text = "0";
        }

        private void txtTarjeta_Click(object sender, EventArgs e)
        {
            this.lblBanderaTexto.Text = "1";
        }

        private void rbTarjeta_CheckedChanged(object sender, EventArgs e)
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
    }
}
