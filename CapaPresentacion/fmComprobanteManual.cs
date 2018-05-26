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
    public partial class fmComprobanteManual : Form
    {
        public static fmComprobanteManual f1;
        public fmComprobanteManual()
        {
            InitializeComponent();
            fmComprobanteManual.f1 = this;
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            frmVistaClientePagoVenta form = new frmVistaClientePagoVenta();
            form.lblBandera.Text = "3";
            form.ShowDialog();
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
                }
                else
                {
                    rpta = NCliente.InsertarVenta(this.txtNombre.Text.Trim().ToUpper(), DateTime.MinValue, "RUC", this.txtDocumento.Text, this.txtDireccion.Text.Trim(), "", "");
                    this.txtIdCliente.Text = rpta;
                    this.txtNombre.ReadOnly = true;
                    this.txtDireccion.ReadOnly = true;
                    this.btnGuardar.Enabled = false;
                    this.btnNuevo.Enabled = false;
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
                  
                }
                else
                {
                    
                }
            }
            else if (rbTarjeta.Checked)
            {
                this.txtEfectivo.Text = string.Empty;
                this.txtTarjeta.Text = string.Empty;
            }
            else if (rbMixto.Checked)
            {
                if (this.txtEfectivo.Text != "")
                {
                    efectivo = Convert.ToDecimal(this.txtEfectivo.Text);
                    tarjeta = total - efectivo;
                    this.txtTarjeta.Text = tarjeta.ToString();
                   
                }
                else
                {
                    this.txtTarjeta.Text = string.Empty;
                }

            }

        }

        decimal efectivo = 00.00m;
        decimal tarjeta = 00.00m;
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
                    MessageBox.Show("Complete el campo efectivo");
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
                    }

                }

            }
            return true;
        }

        string formaPago = "";
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

        string efectivo1 = "";
        string tarjeta1 = "";
        string vuelto1="";
        string formaPago1 = "";
        string modoProd = "";
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
                vuelto1 = "00.00";
                formaPago1 = "EFECTIVO";
            }
            else if (rbMixto.Checked)
            {
                efectivo1 = this.txtEfectivo.Text.Trim();
                tarjeta1 = this.txtTarjeta.Text.Trim();
                vuelto1 = "00.00";
                formaPago1 = "MIXTO";
            }

                modoProd = "Detallado";
    
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
        private void rbEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            txtEfectivo.Enabled = false;
            txtTarjeta.Enabled = false;
            txtEfectivo.Text = this.lblTotal.Text;
            txtTarjeta.Text = string.Empty;
        }

        private void rbTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            txtEfectivo.Enabled = false;
            txtTarjeta.Enabled = false;
            txtTarjeta.Text = this.lblTotal.Text;
            txtEfectivo.Text = string.Empty;
        }

        private void rbMixto_CheckedChanged(object sender, EventArgs e)
        {
            txtEfectivo.Enabled = true;
            txtTarjeta.Enabled = false;
            txtEfectivo.Text = string.Empty;
            txtTarjeta.Text = string.Empty;
            txtEfectivo.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtEfectivo_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotales();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int? idCliente = null;
            decimal vuelto = 00.00m;
            if (this.txtIdCliente.Text != string.Empty)
            {
                idCliente = Convert.ToInt32(this.txtIdCliente.Text);
            }
            else
            {
                idCliente = null;
            }

            if(txtSerie.Text.Trim() == string.Empty || txtNroCompr.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Ingrese los datos del Comprobante");
                return;
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
                                        NDetalleVenta.InsertarAdicPedido(Convert.ToInt32(frmVenta.f1.lblIdVenta.Text), idProducto, cantidad, prVenta, desc,
                                            frmVenta.f1.dataListadoDetalle.Rows[i].Cells[6].Value.ToString(),tipo,barra,frmVenta.f1.dtDetalleMenu,"Pedido");
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

                                rpta = NVenta.EditarVentaCancelada(Convert.ToInt32(this.lblIdVenta.Text), Convert.ToDecimal("00.00"), formaPago,"");
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
                                    if (this.lblBanderaComprobante.Text == "0" || this.lblBanderaComprobante.Text == "1")
                                    {
                                        tipoCompr = "BOLETA MANUAL";
                                    }

                                    else
                                    {
                                        tipoCompr = "FACTURA MANUAL";
                                    }

                                    rpta1 = NComprobante.InsertarManual(tipoCompr, Convert.ToInt32(txtSerie.Text.Trim()), Convert.ToInt32(txtNroCompr.Text.Trim()), Convert.ToDecimal(this.lblIgv.Text), DateTime.Now, Convert.ToInt32(this.lblIdVenta.Text), "EMITIDA", idCliente,
                                                    Convert.ToDecimal(this.lblTotal.Text), pagoEfectivo, pagoTarjeta, 00.00m, formaPago, vuelto);
                                    if (rpta1 == "OK")
                                    {
                                        if (insertarCaja() == true)
                                        {
                                            MessageBox.Show("Se registró correctamente");
                                            NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                                            frmModuloSalon.f3.limpiarMesas();
                                            frmModuloSalon.f3.mostrarSalones();

                                            this.enviarFormaPago();
                                            // this.imprimir(Convert.ToInt32(this.lblIdVenta.Text));
                                            NImprimir_Comprobante.imprimirComManual(Convert.ToInt32(this.lblIdVenta.Text), tipoCompr, this.txtNombre.Text.Trim(),txtSerie.Text.Trim(),
                                                txtNroCompr.Text.Trim(),this.txtDireccion.Text.Trim(),
                                                                              this.txtDocumento.Text.Trim(), frmVenta.f1.lblMesero.Text, frmVenta.f1.lblSalon.Text, frmVenta.f1.lblMesa.Text,
                                                                              frmVenta.f1.dataListadoDetalle, this.lblDescuento.Text, "00.00", this.lblSubTotal.Text,
                                                                              this.lblIgv.Text, this.lblTotal.Text, efectivo1, vuelto1, tarjeta1, formaPago1, modoProd, "00.00", "");
                                        

                                            this.Hide();
                                            frmVenta.f1.Close();
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
                                            string tipo = frmVenta.f1.dataListadoDetalle.Rows[i].Cells[8].Value.ToString();
                                            string barra = frmVenta.f1.dataListadoDetalle.Rows[i].Cells["Barra"].Value.ToString();
                                            
                                            NDetalleVenta.InsertarAdicPedido(Convert.ToInt32(frmVenta.f1.lblIdVenta.Text), idProducto, cantidad, prVenta, desc, 
                                                frmVenta.f1.dataListadoDetalle.Rows[i].Cells[6].Value.ToString(),tipo,barra, frmVenta.f1.dtDetalleMenu,"Pedido");

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
                                    rpta = NVenta.EditarVentaCancelada(Convert.ToInt32(this.lblIdVenta.Text), Convert.ToDecimal("00.00"), formaPago,"");
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
                                        rpta1 = NComprobante.InsertarManual("FACTURA MANUAL", Convert.ToInt32(txtSerie.Text.Trim()),Convert.ToInt32(txtNroCompr.Text.Trim()), Convert.ToDecimal(this.lblIgv.Text), DateTime.Now, Convert.ToInt32(this.lblIdVenta.Text),
                                            "EMITIDA", Convert.ToInt32(this.txtIdCliente.Text), Convert.ToDecimal(this.lblTotal.Text), pagoEfectivo, pagoTarjeta, 00.00m, formaPago, vuelto);
                                        if (rpta1 == "OK")
                                        {
                                            if (insertarCaja() == true)
                                            {

                                                MessageBox.Show("Se registró correctamente");
                                                NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                                                frmModuloSalon.f3.limpiarMesas();
                                                frmModuloSalon.f3.mostrarSalones();
                                                enviarFormaPago();
                                                // this.imprimir(Convert.ToInt32(this.lblIdVenta.Text));
                                                NImprimir_Comprobante.imprimirComManual(Convert.ToInt32(this.lblIdVenta.Text), "FACTURA MANUAL", this.txtNombre.Text.Trim(),txtSerie.Text.Trim(),
                                                    txtNroCompr.Text.Trim(),this.txtDireccion.Text.Trim(),
                                                                                  this.txtDocumento.Text.Trim(), frmVenta.f1.lblMesero.Text, frmVenta.f1.lblSalon.Text, frmVenta.f1.lblMesa.Text,
                                                                                  frmVenta.f1.dataListadoDetalle, this.lblDescuento.Text, "00.00", this.lblSubTotal.Text,
                                                                                  this.lblIgv.Text, this.lblTotal.Text, efectivo1, vuelto1, tarjeta1, formaPago1, modoProd, "00.00", "");
                                                //this.imprimir(Convert.ToInt32(this.lblIdVenta.Text));


                                                this.Close();
                                                frmVenta.f1.Close();
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
                                if (this.lblBanderaComprobante.Text == "0" || this.lblBanderaComprobante.Text == "1")
                                {
                                    tipoCompr = "BOLETA MANUAL";
                                }
                                else
                                {
                                    tipoCompr = "FACTURA MANUAL";
                                }
                                string rpta = "";
                                rpta = NVenta.InsertarPedidoPagadoManual(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA", formaPago, Convert.ToDecimal(00.00m)
                                                                            , Convert.ToInt32(this.lblIdUsuario.Text), "CU", 1, tipoCompr, Convert.ToInt32(txtSerie.Text.Trim()),
                                                                            Convert.ToInt32(txtNroCompr.Text.Trim()), Convert.ToDecimal(this.lblIgv.Text), "EMITIDA",
                                                                            Convert.ToDecimal(this.lblTotal.Text), pagoEfectivo, pagoTarjeta,
                                                                            00.00m, frmVenta.f1.dtDetalle, vuelto, frmVenta.f1.dtDetalleMenu,
                                                                            DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text), "", "", "","");
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
                                        MessageBox.Show("Se registró correctamente");
                                        NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                                        frmModuloSalon.f3.limpiarMesas();
                                        frmModuloSalon.f3.mostrarSalones();

                                        enviarFormaPago();
                                        // this.imprimir(Convert.ToInt32(this.lblIdVenta.Text));
                                        NImprimir_Comprobante.imprimirComManual(Convert.ToInt32(rpta), tipoCompr, this.txtNombre.Text.Trim(),txtSerie.Text.Trim(),txtNroCompr.Text.Trim(),
                                            this.txtDireccion.Text.Trim(),
                                                                          this.txtDocumento.Text.Trim(), frmVenta.f1.lblMesero.Text, frmVenta.f1.lblSalon.Text, frmVenta.f1.lblMesa.Text,
                                                                          frmVenta.f1.dataListadoDetalle, this.lblDescuento.Text, "00.00", this.lblSubTotal.Text,
                                                                          this.lblIgv.Text, this.lblTotal.Text, efectivo1, vuelto1, tarjeta1, formaPago1, modoProd, "00.00", "");

                                        //this.imprimir(Convert.ToInt32(rpta));
                        
                                        this.Hide();
                                        frmVenta.f1.Hide();
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
                                    rpta = NVenta.InsertarPedidoPagadoManual(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA", formaPago, Convert.ToDecimal(00.00m)
                                                                            , Convert.ToInt32(this.lblIdUsuario.Text), "CU", 1, "FACTURA MANUAL",Convert.ToInt32(txtSerie.Text.Trim()),Convert.ToInt32(txtNroCompr.Text.Trim()),
                                                                            Convert.ToDecimal(this.lblIgv.Text),
                                                                            "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), pagoEfectivo, 
                                                                            pagoTarjeta, 00.00m, frmVenta.f1.dtDetalle, vuelto, 
                                                                            frmVenta.f1.dtDetalleMenu, DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),"","","","");
                                    if (rpta != "")
                                    {
                                        if (insertarCaja() == true)
                                        {
                                            MessageBox.Show("Se registró correctamente");
                                            NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                                            frmModuloSalon.f3.limpiarMesas();
                                            frmModuloSalon.f3.mostrarSalones();
                                            //this.imprimir(Convert.ToInt32(rpta));
                                            enviarFormaPago();
                                            // this.imprimir(Convert.ToInt32(this.lblIdVenta.Text));
                                            NImprimir_Comprobante.imprimirComManual(Convert.ToInt32(rpta), "FACTURA MANUAL", this.txtNombre.Text.Trim(), txtSerie.Text.Trim(), txtNroCompr.Text.Trim(), this.txtDireccion.Text.Trim(),
                                                                              this.txtDocumento.Text.Trim(), frmVenta.f1.lblMesero.Text, frmVenta.f1.lblSalon.Text, frmVenta.f1.lblMesa.Text,
                                                                              frmVenta.f1.dataListadoDetalle, this.lblDescuento.Text, "00.00", this.lblSubTotal.Text,
                                                                              this.lblIgv.Text, this.lblTotal.Text, efectivo1, vuelto1, tarjeta1, formaPago1, modoProd, "00.00", "");
                                            

                                            this.Hide();
                                            frmVenta.f1.Hide();
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

        private void rbFactura_CheckedChanged(object sender, EventArgs e)
        {
            lblBanderaComprobante.Text = "2";
        }

        private void rbBoleta_CheckedChanged(object sender, EventArgs e)
        {
            lblBanderaComprobante.Text = "0";
        }

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNroCompr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
