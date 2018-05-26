using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmCompra : Form
    {
        public int idUsuario;
        private bool isNuevo;
        private DataTable dtDetalle;
        private decimal subTotal;
        private decimal totalIgv = 0;
        private decimal totalPagado = 0;
        private decimal totalSubTotal = 0;
        public static frmCompra f1;

        private static frmCompra _instancia;

        public static frmCompra GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new frmCompra();
            }
            return _instancia;

        }

        public void setProveedor(string idProveedor, string razonSocial, string direccion)
        {
            this.txtIdProveedor.Text = idProveedor;
            this.txtProveedor.Text = razonSocial;
            this.txtDireccion.Text = direccion;
        }

        public void setProducto(string idProducto, string nombreProducto, string precioVenta)
        {
            this.txtIdArticulo.Text = idProducto;
            this.txtProducto.Text = nombreProducto;
            this.txtPrecioVenta.Text = precioVenta;
        }

       

        public frmCompra()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtProveedor, "Seleccione el proveedor");
            this.ttMensaje.SetToolTip(this.txtSerie, "Ingrese la serie del comprobante");
            this.ttMensaje.SetToolTip(this.txtCorrelativo, "Seleccione el número del comprobante");
            this.ttMensaje.SetToolTip(this.txtCantidad, "Ingrese la Cantidad de compra");
            this.ttMensaje.SetToolTip(this.txtProducto, "Seleccione el Producto de compra");
            this.txtIdProveedor.ReadOnly = true;

            frmCompra.f1 = this;

        }

        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar
        private void Limpiar()
        {
            this.txtIdProveedor.Text = string.Empty;
            this.txtProveedor.Text = string.Empty;
            this.txtSerie.Text = string.Empty;
            this.txtCorrelativo.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
           
            this.txtTotalPagado.Text = "00.00";
            this.txtSubTotal.Text = "00.00";
            this.txtIgv.Text = "00.00";
            this.txtDireccion.Text = string.Empty;
            this.cbTipoComprobante.SelectedIndex = -1;
            this.cbMoneda.SelectedIndex = -1;
            this.cbFormaPago.SelectedIndex = -1;
            this.crearTabla();

        }

        private void limpiarDetalle()
        {
            this.txtIdArticulo.Text = string.Empty;
            this.txtProducto.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtPrecioCompra.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
            this.txtUnidad.Text = string.Empty;
            this.txtImporte.Text = string.Empty;
        }

        //Habilitar Controles
        private void Habilitar(bool valor)
        {
            this.txtSerie.Enabled = valor;
            this.txtCorrelativo.ReadOnly = !valor;
            this.dtFecha.Enabled = valor;
            this.cbTipoComprobante.Enabled = valor;
            this.txtCantidad.ReadOnly = !valor;
            this.txtPrecioCompra.ReadOnly = !valor;
            this.txtPrecioVenta.ReadOnly = !valor;
            this.txtImporte.ReadOnly = !valor;
            cbCaja.Enabled = valor;

            this.btnBuscarArticulo.Enabled = valor;
            this.btnVistaInsumo.Enabled = valor;
            this.btnBuscarProveedor.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
           

            this.errorIcono.Clear();
        }

        //Habilitar Botones
        private void Botones()
        {
            if (this.isNuevo)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
                
                // this.rbPlato.Checked = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }


        private void crearTabla()
        {

            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("Codigo", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Producto", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Cantidad", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Precio_Unitario", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Precio_Venta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Importe", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Tipo", System.Type.GetType("System.String"));
            this.dataListadoDetalle.DataSource = this.dtDetalle;
        }


        private void formatoTabla()
        {
            this.dataListadoDetalle.Columns[6].Visible = false;
            // DataGridView1.Columns(1).Width = 150
            this.dataListadoDetalle.Columns[0].Width = 80;
            this.dataListadoDetalle.Columns[1].Width = 360;
            this.dataListadoDetalle.Columns[2].Width = 120;
            this.dataListadoDetalle.Columns[3].Width = 165;
            this.dataListadoDetalle.Columns[4].Width = 165;
            this.dataListadoDetalle.Columns[5].Width = 165;

            this.dataListadoDetalle.ClearSelection();
            this.dataListadoDetalle.ColumnHeadersDefaultCellStyle.Font = new Font(dataListadoDetalle.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListadoDetalle.GridColor = SystemColors.ActiveBorder;
            this.dataListadoDetalle.Font = new Font("Roboto", 8);
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.isNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtProveedor.Focus();
            this.limpiarDetalle();
            this.lblBander.Text = "1";
            this.cbTipoComprobante.SelectedIndex = 0;
            this.cbFormaPago.SelectedIndex = 0;
            this.cbMoneda.SelectedIndex = 0;
        }

        private void frmIngresoAlmacen_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Habilitar(false);
            this.Botones();

            this.crearTabla();
            this.formatoTabla();
            
        }

        private void frmIngresoAlmacen_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            frmVistaProveedorIngreso vistaProveedor = new frmVistaProveedorIngreso();
            vistaProveedor.ShowDialog();
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            frmVistaProductoIngreso vistaArticulo = new frmVistaProductoIngreso();
            vistaArticulo.lblBanderaCierre.Text = "0";
            vistaArticulo.ShowDialog();
            this.txtCantidad.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.isNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.limpiarDetalle();
            this.lblBander.Text = "0";
            this.cbTipoComprobante.SelectedIndex = -1;
        }

        private void mostrarTotales()
        {
            decimal subtotalM, igv, total=00.00m;
            for(int i = 0; i < dataListadoDetalle.Rows.Count; i++)
            {
                total = total + Convert.ToDecimal(this.dataListadoDetalle.Rows[i].Cells[5].Value.ToString());
            }
            subtotalM = total / 1.18m;
            this.txtSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(subtotalM));
            decimal subtotal1 = Convert.ToDecimal(txtSubTotal.Text);
            igv = total - subtotal1;
            txtTotalPagado.Text = total.ToString();
            txtIgv.Text = igv.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.dataListadoDetalle.Rows.Count == 0)
            {
                MensajeError("No hay productos en la lista");
            }
            else
            {
                try
                {
                    string rpta = "";
                    string igv = "";

                    if (this.txtIdProveedor.Text == string.Empty)
                    {
                        MensajeError("Seleccione un proveedor");
                        errorIcono.SetError(txtProveedor, "Seleccione un valor");
                    }

                    else if (this.txtSerie.Text.Trim() == string.Empty)
                    {
                        MensajeError("Ingrese el número de serie");
                        errorIcono.SetError(txtSerie, "Ingrese un valor");
                    }
                    else if (this.txtCorrelativo.Text.Trim() == string.Empty)
                    {
                        MensajeError("Ingrese el número documento");
                        errorIcono.SetError(txtCorrelativo, "Ingrese un valor");
                    }

                    else if (this.txtIgv.Text.Trim() == string.Empty && this.cbTipoComprobante.SelectedItem.ToString().Equals("FACTURA"))
                    {
                        MensajeError("Ingrese el IGV");
                        errorIcono.SetError(txtIgv, "Ingrese un valor");

                    }

                    else
                    {

                        if (this.isNuevo)
                        {
                            if (this.cbTipoComprobante.SelectedItem.ToString().Equals("FACTURA"))
                            {
                                igv = this.txtIgv.Text.Trim();
                            }
                            else if (!this.cbTipoComprobante.SelectedItem.ToString().Equals("FACTURA"))
                            {
                                igv = "00.00";
                            }

                            rpta = NCompra.Insertar(Convert.ToInt32(this.lblIdUsuario.Text), Convert.ToInt32(this.txtIdProveedor.Text), dtFecha.Value, cbTipoComprobante.Text, this.txtSerie.Text, this.txtCorrelativo.Text,
                                                     Convert.ToDecimal(igv), this.cbFormaPago.SelectedItem.ToString(),this.cbMoneda.SelectedItem.ToString(), "EMITIDO",
                                                     Convert.ToDecimal(this.txtTotalPagado.Text),dtDetalle);
                        }
                        if (rpta.Equals("OK"))
                        {
                            if (this.isNuevo)
                            {
                                if(cbCaja.Checked == true)
                                {
                                    rpta = NCaja.Insertar(Convert.ToInt32(this.lblIdUsuario.Text), "1", "EGRESO",Convert.ToDecimal(this.txtTotalPagado.Text), "COMPRA", "EFECTIVO");

                                }
                                this.MensajeOK("Se insertó correctamente");
                            }
                        }
                        else
                        {
                            this.MensajeError(rpta);
                        }

                        this.isNuevo = false;
                        this.Botones();
                        this.Limpiar();
                        this.limpiarDetalle();
                        this.txtCantidad.ReadOnly = true;
                        subTotal = 0;
                        totalPagado = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
            

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string sTexto = "";

                if (this.txtIdArticulo.Text == string.Empty)
                {
                    MensajeError("Seleccione un producto");
                    errorIcono.SetError(txtProducto, "Seleccione un valor");
                }

                else if (this.txtCantidad.Text.Trim() == string.Empty)
                {
                    MensajeError("Ingrese la cantidad");
                    errorIcono.SetError(txtCantidad, "Ingrese un valor");
                }
                else if (this.txtPrecioCompra.Text.Trim() == string.Empty)
                {
                    MensajeError("Ingrese el precio de compra");
                    errorIcono.SetError(txtPrecioCompra, "Ingrese un valor");
                }
                else if (this.txtImporte.Text.Trim() == string.Empty)
                {
                    MensajeError("Ingrese el importe");
                    errorIcono.SetError(txtImporte, "Ingrese un valor");
                }

                else if (this.txtPrecioVenta.Text.Trim() == string.Empty && this.lblBandera.Text == "P")
                {
                    MensajeError("Ingrese el precio de venta");
                    errorIcono.SetError(txtPrecioVenta, "Ingrese un valor");
                }

                else if (this.txtPrecioCompra.Text.Trim() != string.Empty)
                {
                    sTexto = this.txtPrecioCompra.Text.Substring(0, 1);
                    decimal precioVenta = 00.00m;
                    decimal precioCompra = Convert.ToDecimal(this.txtPrecioCompra.Text.Trim());
                    if(this.lblBandera.Text == "P")
                    {
                        precioVenta = Convert.ToDecimal(this.txtPrecioVenta.Text.Trim());
                    }
                   
                    if (precioCompra <= 0)
                    {
                        MensajeError("Ingrese un precio de compra mayor a cero");
                    }
                    else if(precioVenta <= 0 && this.lblBandera.Text == "P")
                    {
                        MensajeError("Ingrese un precio de venta mayor a cero");
                        this.txtPrecioVenta.Focus();
                    }

                    else if (sTexto == ".")
                    {
                        MensajeError("Ingrese un precio de compra válido");
                        errorIcono.SetError(txtPrecioCompra, "Precio de Compra válido");
                    }
                    else
                    {
                        bool registrar = true;
                        foreach (DataRow row in dtDetalle.Rows)
                        {
                            if (Convert.ToInt32(row["Codigo"]) == Convert.ToInt32(this.txtIdArticulo.Text) && row["Tipo"].ToString() ==this.lblBandera.Text)
                            {
                                registrar = false;
                                this.MensajeError("El producto ya se encuentra agregado");
                            }
                        }

                        if (registrar)
                        {
                            if(this.lblBandera.Text == "P" && this.txtPrecioVenta.Text.Trim() != "")
                            {
                                precioVenta = Convert.ToDecimal(this.txtPrecioVenta.Text);
                            }else
                            {
                                precioVenta = 00.00m;
                            }
                           


                          /*  decimal subTotal = Convert.ToDecimal(this.txtCantidad.Text) * Convert.ToDecimal(this.txtPrecioCompra.Text);
                            totalPagado = totalPagado + subTotal;
                            this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");
                            if (this.cbTipoComprobante.SelectedItem.ToString().Equals("FACTURA"))
                            {
                                totalSubTotal = totalPagado / 1.18m;
                                this.txtSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalSubTotal));
                                totalIgv = totalPagado - totalSubTotal;

                                this.txtIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalIgv));
                            }
                            else
                            {
                                this.txtSubTotal.Text = this.txtTotalPagado.Text;
                            }

                   */


                            DataRow row = this.dtDetalle.NewRow();
                            row["Codigo"] = Convert.ToInt32(this.txtIdArticulo.Text);
                            row["Producto"] = this.txtProducto.Text;
                            row["Cantidad"] = Convert.ToDecimal(this.txtCantidad.Text.Trim());
                            row["Precio_Unitario"] = Convert.ToDecimal(this.txtPrecioCompra.Text.Trim());
                            row["Precio_Venta"] = precioVenta;
                            row["Importe"] = Convert.ToDecimal(this.txtImporte.Text.Trim());
                            row["Tipo"] = this.lblBandera.Text;
                            this.dtDetalle.Rows.Add(row);
                            mostrarTotales();
                            this.limpiarDetalle();
                        }
                    }
                    this.dataListadoDetalle.ClearSelection();
                    this.txtProducto.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataListadoDetalle.Rows.Count <= 0)
                {
                    MensajeError("No existen filas en la tabla");
                }
                else if (this.dataListadoDetalle.SelectedRows.Count > 0)
                {
                    int indiceFila = this.dataListadoDetalle.CurrentRow.Index;
                    DataRow row = this.dtDetalle.Rows[indiceFila];
/*
                    this.totalPagado = this.totalPagado - Convert.ToDecimal(row["Importe"].ToString());

                    this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");

                    if (this.cbTipoComprobante.SelectedItem.ToString().Equals("FACTURA"))
                    {
                        totalSubTotal = totalPagado / 1.18m;

                        //txtSubTotal.Text = totalSubTotal.ToString("#0.00#");
                        txtSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalSubTotal));
                        totalIgv = totalPagado - totalSubTotal;

                        txtIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalIgv));
                    }
                    else
                    {
                        this.txtSubTotal.Text = this.txtTotalPagado.Text;
                    }
                    */
                    this.dtDetalle.Rows.Remove(row);
                    mostrarTotales();
                    this.dataListadoDetalle.ClearSelection();
                }
                else
                {
                    MensajeError("Seleccione una fila");
                }


            }
            catch (Exception ex)
            {
                MensajeError("No hay filas para remover");
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(this.lblBandera.Text == "P")
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }else
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

                for (int i = 0; i < txtCantidad.Text.Length; i++)
                {
                    if (txtCantidad.Text[i] == '.')
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
         
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txtPrecioCompra.Text.Length; i++)
            {
                if (txtPrecioCompra.Text[i] == '.')
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

        private void dataListadoDetalle_DoubleClick(object sender, EventArgs e)
        {
            if (this.lblBander.Text.Equals("1") && (this.btnGuardar.Enabled == true) && (this.dataListadoDetalle.Rows.Count > 0))
            {
                this.txtIdArticulo.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Codigo"].Value);
                this.txtProducto.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Producto"].Value);
                this.txtCantidad.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Cantidad"].Value);
                this.txtPrecioCompra.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Precio_Unitario"].Value);
                this.txtPrecioVenta.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Precio_Venta"].Value);
                this.txtImporte.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Importe"].Value);
                //subTotal = Convert.ToDecimal(this.dataListadoDetalle.CurrentRow.Cells["Importe"].Value);
                this.btnAgregar.Enabled = false;
                this.btnQuitar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.txtCantidad.Focus();
                this.lblPosic.Text = dataListadoDetalle.CurrentRow.Index.ToString();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(this.txtIdArticulo.Text == string.Empty)
            {
                MensajeError("Seleccione un producto");
                errorIcono.SetError(txtProducto, "Seleccione un valor");
            }

            else if (this.txtCantidad.Text.Trim() == string.Empty)
            {
                MensajeError("Ingrese la cantidad");
                errorIcono.SetError(txtCantidad, "Ingrese un valor");
            }
            else if (this.txtPrecioCompra.Text.Trim() == string.Empty)
            {
                MensajeError("Ingrese el precio de compra");
                errorIcono.SetError(txtPrecioCompra, "Ingrese un valor");
            }
            else if (this.txtImporte.Text.Trim() == string.Empty)
            {
                MensajeError("Ingrese el importe");
                errorIcono.SetError(txtImporte, "Ingrese un valor");
            }
            else if (this.txtPrecioVenta.Text.Trim() == string.Empty)
            {
                MensajeError("Ingrese el precio de venta");
                errorIcono.SetError(txtPrecioVenta, "Ingrese un valor");
            }

            else if (this.txtPrecioCompra.Text.Trim() != string.Empty)
            {
                bool registrar = true;
                if (registrar)
                {
                    totalPagado = totalPagado - subTotal;
                    this.dataListadoDetalle[4, Convert.ToInt32(this.lblPosic.Text)].Value = this.txtPrecioVenta.Text;
                    this.dataListadoDetalle[2, Convert.ToInt32(this.lblPosic.Text)].Value = this.txtCantidad.Text;
                    this.dataListadoDetalle[3, Convert.ToInt32(this.lblPosic.Text)].Value = this.txtPrecioCompra.Text;
                    decimal subTotal1 = Convert.ToDecimal(this.txtCantidad.Text) * Convert.ToDecimal(this.txtPrecioCompra.Text);
                    this.dataListadoDetalle[5, Convert.ToInt32(this.lblPosic.Text)].Value = subTotal1;

                    /*
                    totalPagado = totalPagado + subTotal1;
                    this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");

                    if (this.cbTipoComprobante.SelectedItem.ToString().Equals("FACTURA"))
                    {
                        totalSubTotal = totalPagado / 1.18m;
                        //this.redondear(totalSubTotal);

                        //txtSubTotal.Text = totalSubTotal.ToString("#0.00#");
                        txtSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalSubTotal));
                        totalIgv = totalPagado - totalSubTotal;

                        txtIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalIgv));

                    }
                    else
                    {
                        this.txtSubTotal.Text = this.txtTotalPagado.Text;
                    }*/
                    mostrarTotales();
                    this.dataListadoDetalle.ClearSelection();
                    this.limpiarDetalle();
                    this.btnEditar.Enabled = false;
                    this.btnAgregar.Enabled = true;
                    this.btnQuitar.Enabled = true;
                }

            }
        }

        private void cbTipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoComprobante.SelectedIndex == 1)
            {
                if(this.txtTotalPagado.Text != string.Empty)
                {
                    decimal totalText = Convert.ToDecimal(this.txtTotalPagado.Text);
                    decimal totalSubTotalText = totalText / 1.18m;
                    //this.redondear(totalSubTotal);

                    //txtSubTotal.Text = totalSubTotal.ToString("#0.00#");
                    txtSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalSubTotalText));
                    decimal totalIgvText = totalText - totalSubTotalText;

                    txtIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalIgvText));
                }
         
            }
            else
            {

                string totalText1 = this.txtTotalPagado.Text;
                this.txtIgv.Text = "00.00";
                this.txtSubTotal.Text = totalText1;
            }
        }

        private void txtIgv_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txtPrecioVenta.Text.Length; i++)
            {
                if (txtPrecioVenta.Text[i] == '.')
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

        private void mostrarImporte()
        {
            decimal importe;
            decimal cantidad;
            decimal precioCompra;
            if(txtCantidad.Text.Trim() != "" && txtPrecioCompra.Text.Trim() != "")
            {
                cantidad = Convert.ToDecimal(this.txtCantidad.Text);
                precioCompra = Convert.ToDecimal(this.txtPrecioCompra.Text);
                importe = cantidad * precioCompra;
                this.txtImporte.Text = importe.ToString();
            }
            if (txtCantidad.Text.Trim() =="" || txtPrecioCompra.Text.Trim() == "")
            {
                txtImporte.Text = string.Empty;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmVistaInsumo_Ingreso form = new frmVistaInsumo_Ingreso();
            form.lblBanderaCierre.Text = "0";
            form.ShowDialog();
            this.txtCantidad.Select();
        }

        private void txtPrecioCompra_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarImporte();
        }

        private void txtCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarImporte();
        }

        private void cbCaja_CheckedChanged(object sender, EventArgs e)
        {
            if(cbCaja.Checked == true)
            {
                if (frmPrincipal.f1.lblEstadoCaja.Text == "0")
                {
                    MessageBox.Show("Aperture la caja antes de realizar esta operación");
                    btnGuardar.Enabled = false;
                }
                else
                {
                    btnGuardar.Enabled = true;
                }
            }else
            {
                btnGuardar.Enabled = true;
            }

        }

        private void frmCompra_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }
    }
}
