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
    public partial class frmCambioComprobante : Form
    {
        public static frmCambioComprobante f1;
        public frmCambioComprobante()
        {
            InitializeComponent();
            frmCambioComprobante.f1 = this;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            frmVistaClientePagoVenta form = new frmVistaClientePagoVenta();
            form.lblBandera.Text = "2";
            form.ShowDialog();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.btnGuardarCliente.Enabled = true;
            this.txtNombre.ReadOnly = false;
            this.txtDireccion.ReadOnly = false;
            this.txtNombre.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtDocumento.Text = string.Empty;
            this.txtIdCliente.Text = string.Empty;
            this.txtDocumento.Focus();
        }

        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            string rpta = "";
            if (this.txtDocumento.Text.Length == 11)
            {
                if (this.txtNombre.Text.Trim() == "" || this.txtDireccion.Text.Trim() == "" )
                {
                    MessageBox.Show("Complete el nombre, dirección ");
                }
                else
                {
                    rpta = NCliente.InsertarVenta(this.txtNombre.Text.Trim().ToUpper(), DateTime.MinValue, "RUC", this.txtDocumento.Text, this.txtDireccion.Text.Trim(), "", "");
                    this.txtIdCliente.Text = rpta;
                    this.txtNombre.ReadOnly = true;
                    this.txtDireccion.ReadOnly = true;
                    this.btnGuardarCliente.Enabled = false;
                }

            }
            else if (this.txtDocumento.Text.Length == 8)
            {
                if (this.txtNombre.Text.Trim() == "" || this.txtDireccion.Text.Trim() == "" )
                {
                    MessageBox.Show("Complete el nombre, dirección y telefono");
                }
                else
                {
                    rpta = NCliente.InsertarVenta(this.txtNombre.Text.Trim().ToUpper(), DateTime.MinValue, "DNI", this.txtDocumento.Text, this.txtDireccion.Text.Trim(), "", "");
                    this.txtIdCliente.Text = rpta;
                    this.txtNombre.ReadOnly = true;
                    this.txtDireccion.ReadOnly = true;
                    this.btnGuardarCliente.Enabled = false;
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

        public void Facturador(int idVenta, DataTable dtDetalle)
        { 
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
  
                if (this.rbBoleta.Checked == true)
                {
                    tipoCompr = "BOLETA";
              
                }
                else if (this.rbFactura.Checked == true)
                {
                    tipoCompr = "FACTURA";

            }



            decimal subTotal = Convert.ToDecimal(frmMostrarVentas.f1.lblTotalVenta.Text) - Convert.ToDecimal(frmMostrarVentas.f1.lblIgv.Text);

            NFacturador.registrarComprobanteCabecera("01", DateTime.Now.ToString("yyyy-MM-dd"), "", tipoDoc, nroDoc, nombre, "PEN",frmMostrarVentas.f1.lblDcto.Text,
                    "0.00", frmMostrarVentas.f1.lblDcto.Text,subTotal.ToString(), "0.00", "0.00", frmMostrarVentas.f1.lblIgv.Text, "0.00", "0.00", frmMostrarVentas.f1.lblTotalVenta.Text, tipoCompr, idVenta);

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtDetalle = new DataTable();
                if(rbFactura.Checked == true)
                {
                    if(txtIdCliente.Text == "")
                    {
                        MessageBox.Show("Seleccione o ingrese un cliente");
                    }else if(txtDocumento.Text.Length != 11)
                    {
                        MessageBox.Show("Ingrese un número de RUC válido");
                    }
                    else{
                        string rpta = "";
                        rpta = NComprobante.EditarEstadoTicket(Convert.ToInt32(frmMostrarVentas.f1.lblIdComprobante.Text));
                        if(rpta == "OK")
                        {

                            NComprobante.Insertar("FACTURA", 1, Convert.ToDecimal(frmMostrarVentas.f1.lblIgv.Text), DateTime.Now, Convert.ToInt32(frmMostrarVentas.f1.lblIdVenta.Text),
                                "EMITIDA", Convert.ToInt32(this.txtIdCliente.Text), Convert.ToDecimal(frmMostrarVentas.f1.lblTotalVenta.Text), Convert.ToDecimal(frmMostrarVentas.f1.lblEfectivo.Text),
                               Convert.ToDecimal(frmMostrarVentas.f1.lblTarjeta.Text), Convert.ToDecimal(frmMostrarVentas.f1.lblRedondeo.Text), frmMostrarVentas.f1.lblForma.Text,
                               Convert.ToDecimal(frmMostrarVentas.f1.lblVuelto.Text));
                            DataTable dtCliente = NVenta.mostrarClienteVenta(Convert.ToInt32(frmMostrarVentas.f1.lblIdVenta.Text));
                            string cliente = "";
                            string direccion = "";
                            string nroDoc = "";
                            string mesa = "";
                            string salon = "";
                            string tel = "";
                            decimal totalDcto = 00.00m;
                            if (dtCliente.Rows.Count == 1)
                            {
                                cliente = "PUBLICO GENERAL";
                                mesa = dtCliente.Rows[0][0].ToString();
                                salon = dtCliente.Rows[0][1].ToString();
                            }
                            else
                            {
                                cliente = dtCliente.Rows[0][0].ToString();
                                direccion = dtCliente.Rows[0][1].ToString();
                                nroDoc = dtCliente.Rows[0][2].ToString();
                                tel = dtCliente.Rows[0][3].ToString();
                                mesa = dtCliente.Rows[1][0].ToString();
                                salon = dtCliente.Rows[1][1].ToString();
                            }
                            this.dataDetalle.DataSource = NVenta.reporteDetalleVenta(Convert.ToInt32(frmMostrarVentas.f1.lblIdVenta.Text));
                            dtDetalle = NVenta.reporteDetalleVenta(Convert.ToInt32(frmMostrarVentas.f1.lblIdVenta.Text));
                            for (int i = 0; i < dataDetalle.Rows.Count; i++)
                            {
                                totalDcto = totalDcto + Convert.ToInt32(dataDetalle.Rows[i].Cells[4].Value);
                            }

                            decimal subTotal = Convert.ToDecimal(frmMostrarVentas.f1.lblTotalVenta.Text) - Convert.ToDecimal(frmMostrarVentas.f1.lblIgv.Text);
                            decimal efectivo1 = 00.00m;
                            if (frmMostrarVentas.f1.lblForma.Text == "EFECTIVO")
                            {
                                efectivo1 = Convert.ToDecimal(frmMostrarVentas.f1.lblTotalVenta.Text) + Convert.ToDecimal(frmMostrarVentas.f1.lblVuelto.Text);
                            }
                            else if (frmMostrarVentas.f1.lblForma.Text == "TARJETA")
                            {
                                efectivo1 = 00.00m;
                            }
                            else if (frmMostrarVentas.f1.lblForma.Text == "MIXTO")
                            {
                                efectivo1 = Convert.ToDecimal(frmMostrarVentas.f1.lblEfectivo.Text);
                            }
                            NImprimir_Comprobante.imprimirCambioCompr(Convert.ToInt32(frmMostrarVentas.f1.lblIdVenta.Text), "FACTURA", cliente, direccion, frmMostrarVentas.f1.lblNumero.Text,
                                salon, mesa, dataDetalle, totalDcto.ToString(), frmMostrarVentas.f1.lblDcto.Text, subTotal.ToString(), frmMostrarVentas.f1.lblIgv.Text,
                                frmMostrarVentas.f1.lblTotalVenta.Text, frmMostrarVentas.f1.lblEfectivo.Text, frmMostrarVentas.f1.lblVuelto.Text,
                                frmMostrarVentas.f1.lblTarjeta.Text, frmMostrarVentas.f1.lblForma.Text, "Detallado", frmMostrarVentas.f1.lblRedondeo.Text,
                                tel);
                            Facturador(Convert.ToInt32(frmMostrarVentas.f1.lblIdVenta.Text), dtDetalle);
                            MessageBox.Show("Se completó la operación");
                            
                            frmMostrarVentas.f1.MostrarTodo();
                            frmMostrarVentas.f1.dataListado.ClearSelection();
                            this.Hide();

                        }
                    }
                }else
                {
                    string rpta = "";
                    rpta = NComprobante.EditarEstadoTicket(Convert.ToInt32(frmMostrarVentas.f1.lblIdComprobante.Text));
                    if (rpta == "OK")
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
                        NComprobante.Insertar("BOLETA", 1, Convert.ToDecimal(frmMostrarVentas.f1.lblIgv.Text), DateTime.Now, Convert.ToInt32(frmMostrarVentas.f1.lblIdVenta.Text),
                            "EMITIDA",idCliente, Convert.ToDecimal(frmMostrarVentas.f1.lblTotalVenta.Text), Convert.ToDecimal(frmMostrarVentas.f1.lblEfectivo.Text),
                           Convert.ToDecimal(frmMostrarVentas.f1.lblTarjeta.Text), Convert.ToDecimal(frmMostrarVentas.f1.lblRedondeo.Text), frmMostrarVentas.f1.lblForma.Text,
                           Convert.ToDecimal(frmMostrarVentas.f1.lblVuelto.Text));
                        DataTable dtCliente = NVenta.mostrarClienteVenta(Convert.ToInt32(frmMostrarVentas.f1.lblIdVenta.Text));
                        string cliente = "";
                        string direccion = "";
                        string nroDoc = "";
                        string mesa = "";
                        string salon = "";
                        string tel = "";
                        decimal totalDcto = 00.00m;
                        if (dtCliente.Rows.Count == 1)
                        {
                            cliente = "PUBLICO GENERAL";
                            mesa = dtCliente.Rows[0][0].ToString();
                            salon = dtCliente.Rows[0][1].ToString();
                        }
                        else
                        {
                            cliente = dtCliente.Rows[0][0].ToString();
                            direccion = dtCliente.Rows[0][1].ToString();
                            nroDoc = dtCliente.Rows[0][2].ToString();
                            tel = dtCliente.Rows[0][3].ToString();
                            mesa = dtCliente.Rows[1][0].ToString();
                            salon = dtCliente.Rows[1][1].ToString();
                        }
                        this.dataDetalle.DataSource = NVenta.reporteDetalleVenta(Convert.ToInt32(frmMostrarVentas.f1.lblIdVenta.Text));
                        dtDetalle = NVenta.reporteDetalleVenta(Convert.ToInt32(frmMostrarVentas.f1.lblIdVenta.Text));
                        for (int i = 0; i < dataDetalle.Rows.Count; i++)
                        {
                            totalDcto = totalDcto + Convert.ToInt32(dataDetalle.Rows[i].Cells[4].Value);
                        }

                        decimal subTotal = Convert.ToDecimal(frmMostrarVentas.f1.lblTotalVenta.Text) - Convert.ToDecimal(frmMostrarVentas.f1.lblIgv.Text);
                        decimal efectivo1 = 00.00m;
                        if (frmMostrarVentas.f1.lblForma.Text == "EFECTIVO")
                        {
                            efectivo1 = Convert.ToDecimal(frmMostrarVentas.f1.lblTotalVenta.Text) + Convert.ToDecimal(frmMostrarVentas.f1.lblVuelto.Text);
                        }
                        else if (frmMostrarVentas.f1.lblForma.Text == "TARJETA")
                        {
                            efectivo1 = 00.00m;
                        }
                        else if (frmMostrarVentas.f1.lblForma.Text == "MIXTO")
                        {
                            efectivo1 = Convert.ToDecimal(frmMostrarVentas.f1.lblEfectivo.Text);
                        }
                        NImprimir_Comprobante.imprimirCambioCompr(Convert.ToInt32(frmMostrarVentas.f1.lblIdVenta.Text), "BOLETA", cliente, direccion, frmMostrarVentas.f1.lblNumero.Text,
                            salon, mesa, dataDetalle, totalDcto.ToString(), frmMostrarVentas.f1.lblDcto.Text, subTotal.ToString(), frmMostrarVentas.f1.lblIgv.Text,
                            frmMostrarVentas.f1.lblTotalVenta.Text, efectivo1.ToString(), frmMostrarVentas.f1.lblVuelto.Text,
                            frmMostrarVentas.f1.lblTarjeta.Text, frmMostrarVentas.f1.lblForma.Text, "Detallado", frmMostrarVentas.f1.lblRedondeo.Text,
                            tel);
                        Facturador(Convert.ToInt32(frmMostrarVentas.f1.lblIdVenta.Text),dtDetalle);
                        MessageBox.Show("Se completó la operación");
                        frmMostrarVentas.f1.MostrarTodo();
                        frmMostrarVentas.f1.dataListado.ClearSelection();
                        this.Hide();

                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("No se completó la operación");
            }
        }
    }
}
