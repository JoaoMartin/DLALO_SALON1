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
    public partial class frmCobroDelivery : Form
    {
        public static frmCobroDelivery f1;

        private DataTable dtDetalleVenta;
        public frmCobroDelivery()
        {
            InitializeComponent();
            frmCobroDelivery.f1 = this;
        }

        public void Facturador(int idVenta, DataTable dtDetalle)
        {
          
                int? tipoDoc;
                string cantidad, codigo, descr, valorUnitario, dcto, importe, nroDoc, nombre;
                decimal igvUn, afecIgv, valUn;

                if (this.lblNroDoc.Text.Length == 8)
                {
                    tipoDoc = 1;
                    nroDoc = this.lblNroDoc.Text.Trim();

                }
                else if (this.lblNroDoc.Text.Length == 11)
                {
                    tipoDoc = 6;
                    nroDoc = this.lblNroDoc.Text.Trim();
                }
                else
                {
                    tipoDoc = 1;
                    nroDoc = "0";
                }

                if (this.lblCliente.Text == string.Empty)
                {
                    nombre = "SIN DNI";
                }
                else
                {
                    nombre = this.lblCliente.Text.Trim();
                }


                string tipoCompr = "";
                if (this.lblTipoComprobante.Text == "Boleta")
                {
                    tipoCompr = "BOLETA";
                }
                else if (this.lblTipoComprobante.Text == "Factura")
                {
                    tipoCompr = "FACTURA";
                }
            decimal total = Convert.ToDecimal(this.lblTotal.Text);
            decimal igv = Decimal.Round(total/1.18m,2);
            decimal subTotal = total - igv;

                NFacturador.registrarComprobanteCabecera("01", DateTime.Now.ToString("yyyy-MM-dd"), "", tipoDoc, nroDoc, nombre, "PEN", "00.00",
                    "0.00", "00.00", subTotal.ToString(),"00.00", "0.00", igv.ToString(), "0.00", "0.00", this.lblTotal.Text, tipoCompr, idVenta);

                for (int i = 0; i < dtDetalle.Rows.Count; i++)
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
                    decimal mtoPrecioVentaItem = Decimal.Round((Convert.ToDecimal(importe) / 1.18m), 2);
                    decimal mtoIgvItem = Convert.ToDecimal(importe) - mtoPrecioVentaItem;
                    decimal mtoValorUnitario = mtoPrecioVentaItem / Convert.ToDecimal(cantidad);


                    NFacturador.registrarComprobanteDetalle("NIU", cantidad, codigo, "", descr, mtoValorUnitario.ToString("#0.00#"), mtoDsctoItem.ToString("#0.00#"), mtoIgvItem.ToString("#0.00#"), "10", "0.00", "",
                        mtoPrecioVentaItem.ToString("#0.00#"), importe, tipoCompr, idVenta);
                }

        }

        private void ocultarColumnas()
        {
            this.dataListado.Columns[8].Visible = false;
            this.dataListado.Columns[9].Visible = false;
            this.dataListado.Columns[10].Visible = false;
            this.dataListado.Columns[11].Visible = false;
            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[1].Width = 180;
            this.dataListado.Columns[2].Width = 200;
            this.dataListado.Columns[3].Width = 385;
            this.dataListado.Columns[7].Width = 145;

            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }
        private void Mostrar()
        {
            this.dataListado.DataSource = NDelivery.Mostrar();


            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
            }
            else
            {
                this.dataListado.Visible = true;
                ocultarColumnas();
            }
        }
        private void Deshabilitar()
        {
            this.btnEnviar.Enabled = false;
            this.btnConfirmar.Enabled = false;
            this.btnAnular.Enabled = false;
        }
        private void frmCobroDelivery_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            Mostrar();
            Deshabilitar();
        }

        private void dataListado_Click(object sender, EventArgs e)
        {
            this.lblIdVenta.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            this.lblEstado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Estado"].Value);
            this.lblVuelto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Vuelto"].Value);
            this.lblTotal.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Total"].Value);
            this.lblTipoComprobante.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Comprobante"].Value);
            this.lblIdCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idCliente"].Value);
            this.lblCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Cliente"].Value);
            this.lblDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Direccion"].Value);
            this.lblNroDoc.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Doc"].Value);
            this.lblRepartidos.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["repartidor"].Value);
            this.lblDctoInd.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["dctoInd"].Value);
            this.lblTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telCliente"].Value);

            if (lblEstado.Text == "Pedido Delivery")
            {
                btnEnviar.Enabled = true;
                btnAnular.Enabled = true;
                btnConfirmar.Enabled = false;
            }else if(lblEstado.Text == "Enviado")
            {
                btnEnviar.Enabled = false;
                btnAnular.Enabled = true;
                btnConfirmar.Enabled = true;
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                decimal vuelto = Convert.ToDecimal(this.lblVuelto.Text);
                if(vuelto > 0)
                {
                    rpta = NCaja.Insertar(Convert.ToInt32(this.lblIdUsuario.Text),"1", "EGRESO", vuelto, "Vuelto Delivery", "EFECTIVO");
                    if(rpta == "OK")
                    {
                        decimal total = Convert.ToDecimal(this.lblTotal.Text);
                        decimal subTotal =Decimal.Round(total / 1.18m,2);
                        decimal igv = total - subTotal;
                        rpta = NComprobante.Insertar(this.lblTipoComprobante.Text, 1, igv, DateTime.Now, Convert.ToInt32(this.lblIdVenta.Text), "EMITIDA", Convert.ToInt32(this.lblIdCliente.Text),
                            total, total, 00.00m, 00.00m, "EFECTIVO",vuelto);
                        if(rpta == "OK")
                        {
                            rpta = NDelivery.Editar(Convert.ToInt32(this.lblIdVenta.Text),"Enviado");
                            if(rpta == "OK")
                            {
                                this.dataDetalle.DataSource = NVenta.mostrarDetalleVenta(Convert.ToInt32(this.lblIdVenta.Text));
                                this.dtDetalleVenta = NVenta.mostrarDetalleVenta(Convert.ToInt32(this.lblIdVenta.Text));
                                NImprimir_Comprobante.imprimirCom(Convert.ToInt32(this.lblIdVenta.Text), this.lblTipoComprobante.Text, this.lblCliente.Text, this.lblDireccion.Text,
                                    this.lblNroDoc.Text, this.lblRepartidos.Text, "D", "DELIVERY",dataDetalle,this.lblDctoInd.Text, "00.00",subTotal.ToString(), igv.ToString(), total.ToString(), 
                                    total.ToString(), this.lblVuelto.Text, "00.00", "EFECTIVO", "Detallado","00.00",this.lblTelefono.Text);
                                this.Facturador(Convert.ToInt32(this.lblIdVenta.Text), dtDetalleVenta);
                                MessageBox.Show("Se registró correctamente");
                              
                                this.Hide();
                            }
                        }
                    }
                }else
                {
                    decimal total = Convert.ToDecimal(this.lblTotal.Text);
                    decimal subTotal = Decimal.Round(total / 1.18m, 2);
                    decimal igv = total - subTotal;
                    rpta = NComprobante.Insertar(this.lblTipoComprobante.Text, 1, igv, DateTime.Now, Convert.ToInt32(this.lblIdVenta.Text), "EMITIDA", Convert.ToInt32(this.lblIdCliente.Text),
                        total, total, 00.00m, 00.00m, "EFECTIVO",vuelto);
                    if (rpta == "OK")
                    {
                        rpta = NDelivery.Editar(Convert.ToInt32(this.lblIdVenta.Text),"Enviado");
                        if (rpta == "OK")
                        {
                            this.dataDetalle.DataSource = NVenta.mostrarDetalleVenta(Convert.ToInt32(this.lblIdVenta.Text));
                            this.dtDetalleVenta = NVenta.mostrarDetalleVenta(Convert.ToInt32(this.lblIdVenta.Text));
                            NImprimir_Comprobante.imprimirCom(Convert.ToInt32(this.lblIdVenta.Text), this.lblTipoComprobante.Text, this.lblCliente.Text, this.lblDireccion.Text,
                                   this.lblNroDoc.Text, this.lblRepartidos.Text, "D", "DELIVERY", dataDetalle, this.lblDctoInd.Text, "00.00", subTotal.ToString(), igv.ToString(), total.ToString(),
                                   total.ToString(), this.lblVuelto.Text, "00.00", "EFECTIVO", "Detallado", "00.00",this.lblTelefono.Text);
                            this.Facturador(Convert.ToInt32(this.lblIdVenta.Text), dtDetalleVenta);
                            MessageBox.Show("Se registró correctamente");
                          
                            this.Hide();
                        }
                    }
                }
               
            }catch(Exception ex)
            {
                MessageBox.Show("No se completó la operación");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                rpta = NCaja.Insertar(Convert.ToInt32(this.lblIdUsuario.Text), "1", "INGRESO", Convert.ToDecimal(this.lblTotal.Text), "Ingreso Delivery", "EFECTIVO");
                if (rpta == "OK")
                {
                    rpta = NCaja.Insertar(Convert.ToInt32(this.lblIdUsuario.Text), "1", "INGRESO", Convert.ToDecimal(this.lblVuelto.Text), "Ingreso Vuelto", "EFECTIVO");
                    if(rpta == "OK")
                    {
                        rpta = NDelivery.Editar(Convert.ToInt32(this.lblIdVenta.Text), "PAGADA");
                        if (rpta == "OK")
                        {
                            MessageBox.Show("Se registró correctamente");
                           
                            this.Hide();
                        }
                    }

                }
            }catch(Exception ex)
            {
                MessageBox.Show("No se completó la operación");
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.lblEstado.Text == "Pedido Delivery")
                {
                    this.dataDetalle.DataSource = NVenta.mostrarDetalleVenta(Convert.ToInt32(this.lblIdVenta.Text));
                    for (int i = 0; i < dataDetalle.Rows.Count; i++)
                    {
                        if (Convert.ToString(dataDetalle.Rows[i].Cells[8].Value) == "C")
                        {
                            DataTable dtDetalleProducto = new DataTable();
                            dtDetalleProducto = NProducto.mostrarDetalleProducto_Venta(Convert.ToInt32(Convert.ToInt32(dataDetalle.Rows[i].Cells[0].Value)));

                            for (int j = 0; j < dtDetalleProducto.Rows.Count; j++)
                            {
                                int idProducto_Com = Convert.ToInt32(dtDetalleProducto.Rows[j][0].ToString());
                                int cantRequerida = Convert.ToInt32(dtDetalleProducto.Rows[j][1].ToString());
                                
                                rpta = NProducto.EditarStock(idProducto_Com, ((cantRequerida * Convert.ToInt32(dataDetalle.Rows[i].Cells[2].Value) * -1)));
                            }
                        }
                        dataCocina.Rows.Add(dataDetalle.Rows[i].Cells[1].Value, dataDetalle.Rows[i].Cells[2].Value, "");
                        rpta = NDetalleVenta.Eliminar(Convert.ToInt32(dataDetalle.Rows[i].Cells[7].Value));

                    }
                    if(rpta == "OK")
                    {
                        rpta = NDelivery.Eliminar(Convert.ToInt32(this.lblIdVenta.Text));
                        if(rpta == "OK")
                        {
                            MessageBox.Show("Se anuló correctamente");
                            NImprimirComanda.imprimirCom(this.lblRepartidos.Text, "DELIVERY", "DELIVERY", dataCocina, "COMANDA ANULACION");
                            this.Hide();
                        }
                    }

                }
                else if (this.lblEstado.Text == "Enviado")
                {
                    this.dataDetalle.DataSource = NVenta.mostrarDetalleVenta(Convert.ToInt32(this.lblIdVenta.Text));
                    for (int i = 0; i < dataDetalle.Rows.Count; i++)
                    {
                        if (Convert.ToString(dataDetalle.Rows[i].Cells[8].Value) == "C")
                        {
                            DataTable dtDetalleProducto = new DataTable();
                            dtDetalleProducto = NProducto.mostrarDetalleProducto_Venta(Convert.ToInt32(Convert.ToInt32(dataDetalle.Rows[i].Cells[0].Value)));

                            for (int j = 0; j < dtDetalleProducto.Rows.Count; j++)
                            {
                                int idProducto_Com = Convert.ToInt32(dtDetalleProducto.Rows[j][0].ToString());
                                int cantRequerida = Convert.ToInt32(dtDetalleProducto.Rows[j][1].ToString());

                                rpta = NProducto.EditarStock(idProducto_Com, ((cantRequerida * Convert.ToInt32(dataDetalle.Rows[i].Cells[2].Value) * -1)));
                            }
                        }
                        dataCocina.Rows.Add(dataDetalle.Rows[i].Cells[1].Value, dataDetalle.Rows[i].Cells[2].Value, "");
                        rpta = NDetalleVenta.Eliminar(Convert.ToInt32(dataDetalle.Rows[i].Cells[7].Value));
                    }
                    if (rpta == "OK")
                    {
                       

                            DataTable dtIdCompr = new DataTable();
                            dtIdCompr = NComprobante.mostrarIdComprobante(Convert.ToInt32(this.lblIdVenta.Text));
                            frmAnularComprobante frm = new frmAnularComprobante();
                            frm.lblBandera.Text = "1";
                            frm.lblIdCompro.Text = dtIdCompr.Rows[0][0].ToString();
                            frm.lblSerie.Text = dtIdCompr.Rows[0][1].ToString();
                            frm.lblNro.Text = dtIdCompr.Rows[0][2].ToString();
                            frm.lblFecha.Text = dtIdCompr.Rows[0][3].ToString();
                            frm.lblComprobante.Text = this.lblTipoComprobante.Text;
                            frm.ShowDialog();
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se completó la operación");
            }
        }

        private void frmCobroDelivery_FormClosed(object sender, FormClosedEventArgs e)
        {
   
        }
    }
}
