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
    public partial class frmMenu_Desayunos : Form
    {
        Button[] btnCategoria, btnProducto;
        DataTable dtCategoria, dtProducto, dtProdCom;
        public DataTable dtDetalle, dtDetalleVenta;
        public DataTable dtDetallePedido;
        private bool isNuevo = true;
        public DataRow row, row2;
        int nroCategoria;
        private int loc = 0;
        private int locProducto = 0;
        public decimal totalPagado = 0, subTotal = 0;
        int cantidadAcumulada = 0;
        public static frmMenu_Desayunos f1;
       

        private void btnPedido_Click(object sender, EventArgs e)
        {
            if(dataListadoDetalle.Rows.Count <= 0)
            {
                MessageBox.Show("Agregue productos a la lista");
            }else
            {
                int posicion = 0;
                if(lblNroFilasDataMenu.Text == "0")
                {
                    posicion = 0;
                }else
                {
                    posicion =  Convert.ToInt32(lblNroFilasDataMenu.Text);
                }
                for(int i = 0; i < dataListadoDetalle.Rows.Count; i++)
                {
                    //frmVenta.f1.dgvBanderaMenu.Rows.Insert(dataListadoDetalle.Rows[i].Cells[0].Value.ToString(), dataListadoDetalle.Rows[i].Cells[2].Value.ToString());7

                    frmVenta.f1.dgvBanderaMenu.Rows.Insert(posicion, dataListadoDetalle.Rows[i].Cells[0].Value.ToString(), dataListadoDetalle.Rows[i].Cells["Bandera"].Value.ToString(),
                        dataListadoDetalle.Rows[i].Cells["Cant"].Value.ToString());

                    posicion++;
                }
                if(frmVenta.f1.lblIdVenta.Text != "0")
                {
                    row =frmVenta.f1.dtDetalleVenta.NewRow();
                    decimal importe = Convert.ToDecimal(txtCantidad.Text) * Convert.ToDecimal(lblPrecioUnitario.Text) - Convert.ToDecimal(txtCantidad.Text) * Convert.ToDecimal(lblDescuento.Text);
                    row["Cod"] = lblIdPlato.Text;
                    row["Descripcion"] = lblDescripcion.Text;
                    row["Cant"] = Convert.ToInt32(txtCantidad.Text);
                    row["Precio_Un"] = Convert.ToDecimal(lblPrecioUnitario.Text);
                    row["Importe"] = importe;
                    row["Nota"] = "";
                    row["Descuento"] = Convert.ToDecimal(Convert.ToInt32(txtCantidad.Text) * Convert.ToDecimal(lblDescuento.Text));
                    row["Tipo"] = "M";
                    row["Imprimir"] = "Cocina";
                    row["barra"] = dataListadoDetalle.Rows[0].Cells["Bandera"].Value.ToString();


                    for (int i = 0; i < dataListadoDetalle.Rows.Count; i++)
                    {
                        row2 = frmVenta.f1.dtDetalleMenu.NewRow();
                        row2["Cod"] = Convert.ToInt32(dataListadoDetalle.Rows[i].Cells[0].Value.ToString());

                        row2["Cant"] = Convert.ToInt32(txtCantidad.Text);
                        row2["Barra"] = dataListadoDetalle.Rows[0].Cells["Bandera"].Value.ToString();
                        frmVenta.f1.dtDetalleMenu.Rows.Add(row2);
                    }
                    frmVenta.f1.dtDetalleVenta.Rows.Add(row);
                    frmVenta.f1.Refresh();
                    frmVenta.f1.dataListadoDetalle.Refresh();
                    frmVenta.f1.dataListadoDetalle.DataSource =frmVenta.f1.dtDetalleVenta;
                }
                else
                {
                    row = frmVenta.f1.dtDetalle.NewRow();
                 
                    decimal importe = Convert.ToDecimal(txtCantidad.Text) * Convert.ToDecimal(lblPrecioUnitario.Text) - Convert.ToDecimal(txtCantidad.Text) * Convert.ToDecimal(lblDescuento.Text);
                    row["Cod"] = lblIdPlato.Text;
                    row["Descripcion"] = lblDescripcion.Text;
                    row["Cant"] = Convert.ToInt32(txtCantidad.Text);
                    row["Precio_Un"] = Convert.ToDecimal(lblPrecioUnitario.Text);
                    row["Importe"] = importe;
                    row["Nota"] = "";
                    row["Descuento"] = Convert.ToDecimal(Convert.ToInt32(txtCantidad.Text) * Convert.ToDecimal(lblDescuento.Text));
                    row["Tipo"] = "M";
                    row["Imprimir"] = "Cocina";
                    row["Barra"] = dataListadoDetalle.Rows[0].Cells["Bandera"].Value.ToString();
                    frmVenta.f1.dtDetalle.Rows.Add(row);

                   
                    for(int i = 0; i < dataListadoDetalle.Rows.Count; i++)
                    {
                        row2 = frmVenta.f1.dtDetalleMenu.NewRow();
                        row2["Cod"] = Convert.ToInt32(dataListadoDetalle.Rows[i].Cells[0].Value.ToString());
                   
                        row2["Cant"] = Convert.ToInt32(txtCantidad.Text);
                        row2["Barra"] = dataListadoDetalle.Rows[0].Cells["Bandera"].Value.ToString();
                        frmVenta.f1.dtDetalleMenu.Rows.Add(row2);
                    }
                   
                }


                frmVenta.f1.sumaTotal();
                frmVenta.f1.dataListadoDetalle.ClearSelection();
                frmVenta.f1.btnPedido.Enabled = true;
                frmVenta.f1.btnCobrar.Enabled = true;
                frmVenta.f1.btnImprimirPreCuenta.Enabled = true;
                frmVenta.f1.btnManual.Enabled = true;
                frmVenta.f1.btnDividir.Enabled = true;
                frmVenta.f1.btnDctoProducto.Enabled = true;
                if (frmVenta.f1.dataListadoDetalle.Rows.Count > 1)
                {
                    frmVenta.f1.btnSeparar.Enabled = true;
                }
                int nroFilas = frmVenta.f1.dataListadoDetalle.Rows.Count;
                string imprimir = "";
                for(int b = 0; b < dataListadoDetalle.Rows.Count; b++)
                {
                    
                    imprimir = imprimir + dataListadoDetalle.Rows[b].Cells[1].Value.ToString() + ",";
                }
                frmVenta.f1.dataListadoDetalle[6, nroFilas-1].Value = imprimir;
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.dataListadoDetalle.Rows.Count <= 0)
            {
               MessageBox.Show("No existen filas en la tabla");
            }
            else if (this.dataListadoDetalle.SelectedRows.Count > 0)
            {
             
                int indiceFila = this.dataListadoDetalle.CurrentRow.Index;
                DataRow row = this.dtDetalle.Rows[indiceFila];

                /* this.totalPagado = this.totalPagado - Convert.ToDecimal(row["Importe"].ToString());
                 this.txtSubTotal.Text = totalPagado.ToString("#0.00#");
                 this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");
                 this.txtDescuento.Text = (descuentoTotal - Convert.ToDecimal(row["Descuento"].ToString())).ToString();
*/


             
                this.dtDetalle.Rows.Remove(row);
                this.dataListadoDetalle.ClearSelection();
                btnQuitar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
        }

        private void dataListadoDetalle_Click(object sender, EventArgs e)
        {
            btnQuitar.Enabled = true;
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public frmMenu_Desayunos()
        {
            InitializeComponent();
            frmMenu_Desayunos.f1 = this;
        }



        private void mostrarProductos()
        {

            int nroProductos;
            dtProducto = NProducto.MostrarDetallePlato(Convert.ToInt32(lblIdPlato.Text));
            nroProductos = dtProducto.Rows.Count;

            int y1 = 20;
            int x1 = 1;


            btnProducto = new Button[nroProductos];

            for (int i = 0; i < nroProductos; i++)
            {
                if (i == 6)
                {
                    y1 = 120;
                    x1 = 1;
                }
                else if (i == 12)
                {
                    y1 = 220;
                    x1 = 1;
                }
                else if (i == 18)
                {
                    y1 = 320;
                    x1 = 1;
                }
                else if (i == 24)
                {
                    y1 = 420;
                    x1 = 1;
                }
                else if (i == 30)
                {
                    y1 = 520;
                    x1 = 1;
                }
                else if (i == 36)
                {
                    y1 = 620;
                    x1 = 1;
                }
                else if (i == 42)
                {
                    y1 = 620;
                    x1 = 1;
                }

                else if (i == 48)
                {
                    y1 = 720;
                    x1 = 1;
                }

                else if (i == 54)
                {
                    y1 = 820;
                    x1 = 1;
                }
                else if (i == 60)
                {
                    y1 = 920;
                    x1 = 1;
                }
                DataRow rowProducto = dtProducto.Rows[i];
                btnProducto[i] = new Button();
                btnProducto[i].Location = new Point(x1, y1);
                btnProducto[i].Name = string.Concat("btnProducto", i.ToString());
                //String mesa = row[0].ToString();
                //btnMesa[i].Name = string.Concat("btnMesa",mesa);
                btnProducto[i].Size = new Size(115, 85);
                btnProducto[i].Font = new Font("Roboto", 7f, FontStyle.Regular);
                btnProducto[i].TabIndex = i;
                btnProducto[i].TextAlign = ContentAlignment.TopCenter;
                btnProducto[i].Text = rowProducto[1].ToString() + "\n \n" + rowProducto[2].ToString();
                btnProducto[i].Visible = true;
                btnProducto[i].BackColor = Color.FromArgb(240, 240, 240);
                btnProducto[i].ForeColor = Color.Black;
                btnProducto[i].FlatAppearance.BorderColor = Color.DarkBlue;
                btnProducto[i].FlatAppearance.BorderSize = 6;
                btnProducto[i].Tag = i;
                // lblNroProducto.Text = nroProductos.ToString();
                x1 += 120;
                gbMeseros.Controls.Add(btnProducto[i]);

                btnProducto[i].Click += new EventHandler((sender, e) =>
                {
                    try
                    {
                        int cantidad, cantidadActual;
                        int posicion = 0;
                        string codigoCom = "";
                        decimal stockComp = 0;
                        decimal cantReq = 0;
                        int siExiste = 0;
                        decimal stock = 0;
                        int bandera = 0;
                        bandera = 1 + Convert.ToInt32(lblBanderaMenu.Text);
                        if (this.txtCantidad.Text.Equals("0"))
                        {
                            MessageBox.Show("Ingrese un número mayor a 0");
                        }
                        else
                        {
                            bool registrar = true;

                            this.dataListadoDetalle.ClearSelection();
                            if (this.txtCantidad.Text.Equals(string.Empty))
                            {
                                cantidad = 1;
                            }
                            else
                            {
                                cantidad = Convert.ToInt32(this.txtCantidad.Text.Trim());
                            }
                            foreach (DataRow row in dtDetalle.Rows)
                            {
                                // = Convert.ToDecimal(rowProducto[5].ToString());

                                siExiste = 0;

                                string tipoPro = Convert.ToString(rowProducto[3].ToString());

                                if (tipoPro == "A")
                                {
                                    for (int t = 0; t < dtStock.Rows.Count; t++)
                                    {
                                        if (rowProducto[0].ToString() == dtStock.Rows[t].Cells["Codigo"].Value.ToString())
                                        {
                                            siExiste = 1;
                                            break;
                                        }

                                    }


                                    if (siExiste == 1)
                                    {
                                        for (int t = 0; t < dtStock.Rows.Count; t++)
                                        {
                                            if (rowProducto[0].ToString() == dtStock.Rows[t].Cells["Codigo"].Value.ToString())
                                            {
                                                stock = Convert.ToDecimal(dtStock.Rows[t].Cells["StockQueda"].Value);
                                                posicion = t;
                                                break;
                                            }

                                        }


                                    }
                                    else
                                    {
                                        stock = Convert.ToDecimal(rowProducto[5].ToString());
                                        break;
                                    }



                                }

                                if (tipoPro == "A" && stock < cantidad)
                                {
                                    MessageBox.Show("El stock es insuficiente");
                                    return;
                                }
                                else
                                {
                                    if ((Convert.ToInt32(row["Cod"]) == Convert.ToInt32(rowProducto[0].ToString())))
                                    {

                                        cantidadActual = Convert.ToInt32(row["Cant"]);
                                        /* if (((cantidadActual + cantidad) > stock) && tipoPro == "A")
                                         {
                                             MessageBox.Show("El stock es insuficiente");
                                             return;
                                         }*/
                                        if (tipoPro == "C")
                                        {

                                            DataTable dtCompuesto = NProducto.mostrarDetalleProducto_Venta(Convert.ToInt32(rowProducto[0]));
                                            for (int r = 0; r < dtCompuesto.Rows.Count; r++)
                                            {
                                                if (dtCompuesto.Rows[r]["tipo"].ToString() == "A")
                                                {
                                                    siExiste = 0;
                                                    for (int z = 0; z < dtStock.Rows.Count; z++)
                                                    {
                                                        if (dtCompuesto.Rows[r]["codigo"].ToString() == dtStock.Rows[z].Cells["Codigo"].Value.ToString())
                                                        {
                                                            siExiste = 1;
                                                            stockComp = Convert.ToDecimal(dtStock.Rows[z].Cells["StockQueda"].Value);
                                                            codigoCom = dtCompuesto.Rows[r]["codigo"].ToString();
                                                            cantReq = Convert.ToDecimal(dtCompuesto.Rows[r]["cantidad"].ToString());
                                                            posicion = z;
                                                            if (rowProducto[3].ToString() == "C")
                                                            {
                                                                this.dtStock[0, posicion].Value = codigoCom;
                                                                this.dtStock[1, posicion].Value = stockComp - (cantidad * cantReq);
                                                            }
                                                            else if (rowProducto[3].ToString() == "A")
                                                            {
                                                                this.dtStock[0, posicion].Value = rowProducto[0];
                                                                this.dtStock[1, posicion].Value = stock - cantidad;
                                                            }
                                                            break;
                                                        }
                                                    }

                                                    if (siExiste == 0)
                                                    {
                                                        dtProdCom = NProducto.MostrarProductoStock(Convert.ToInt32(dtCompuesto.Rows[r]["codigo"]));
                                                        stockComp = Convert.ToDecimal(dtProdCom.Rows[0]["Stock"].ToString());
                                                        cantReq = Convert.ToDecimal(dtCompuesto.Rows[r]["cantidad"].ToString());
                                                        codigoCom = dtCompuesto.Rows[r]["codigo"].ToString();
                                                    }

                                                    if (stockComp < cantidad)
                                                    {
                                                        MessageBox.Show("No hay stock suficiente");
                                                        return;
                                                    }
                                                }
                                            }
                                        }

                                        row["Cant"] = cantidadActual + cantidad;
                                        decimal subTotal = (cantidadActual + cantidad) * Convert.ToDecimal(rowProducto[2].ToString());
                                        decimal subTotalActual = Convert.ToDecimal(row["Importe"]);
                                        row["Importe"] = subTotal - ((cantidadActual + cantidad) * Convert.ToDecimal(rowProducto[6].ToString()));

                                        registrar = false;
                                        row["Descuento"] = (cantidadActual + cantidad) * Convert.ToDecimal(rowProducto[6].ToString());
                                        row["Tipo"] = rowProducto[3].ToString();

                                        totalPagado = totalPagado + subTotal - subTotalActual;
                                        row["Imprimir"] = rowProducto[4].ToString();
                                        row["Bandera"] = bandera.ToString();
                                        //totalPagado = totalPagado + subTotal- dctoProm;
                                        //this.txtSubTotal.Text = totalPagado.ToString("#0.00#");
                                        decimal dctoTotProm = 0, subTotal20 = 0, total20 = 0;
                                        int cantidad20 = 0;

                                        for (int p = 0; p < dataListadoDetalle.Rows.Count; p++)
                                        {
                                            dctoTotProm = dctoTotProm + Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Descuento"].Value.ToString());
                                            cantidad20 = Convert.ToInt32(dataListadoDetalle.Rows[p].Cells["Cant"].Value.ToString());
                                            subTotal20 = subTotal20 + (cantidad20 * Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Precio_Un"].Value.ToString()));
                                        }

                                        /*
                                         this.dtStock[0, posicion].Value = rowProducto[0];
                                         this.dtStock[1, posicion].Value = stock - cantidad;
                                         break;*/
                                        if (siExiste == 0)
                                        {
                                            int nroFilasStock = this.dtStock.Rows.Count;
                                            if (nroFilasStock == 0 && rowProducto[3].ToString() == "A")
                                            {
                                                this.dtStock.Rows.Insert(0, rowProducto[0].ToString(), stock - cantidad);
                                            }
                                            else if (nroFilasStock > 0 && rowProducto[3].ToString() == "A")
                                            {
                                                this.dtStock.Rows.Insert(nroFilasStock, rowProducto[0].ToString(), stock - cantidad);
                                            }
                                            else if (nroFilasStock == 0 && rowProducto[3].ToString() == "C")
                                            {
                                                this.dtStock.Rows.Insert(0, codigoCom, stockComp - (cantidad * cantReq));
                                            }
                                            else if (nroFilasStock > 0 && rowProducto[3].ToString() == "C")
                                            {
                                                this.dtStock.Rows.Insert(0, codigoCom, stockComp - (cantidad * cantReq));
                                            }
                                        }
                                        else
                                        {

                                            if (rowProducto[3].ToString() == "C")
                                            {
                                                this.dtStock[0, posicion].Value = codigoCom;
                                                this.dtStock[1, posicion].Value = stockComp - (cantidad * cantReq);
                                            }
                                            else if (rowProducto[3].ToString() == "A")
                                            {
                                                this.dtStock[0, posicion].Value = rowProducto[0];
                                                this.dtStock[1, posicion].Value = stock - cantidad;
                                            }

                                        }
                                        this.dataListadoDetalle.Refresh();
                                        //this.dtStock.Rows.Insert(posicion, rowProducto[0].ToString(), stock - cantidad);
                                        // this.txtCantidad.Text = "1";
                                    }

                                    else if ((Convert.ToInt32(row["Cod"]) == Convert.ToInt32(rowProducto[0].ToString())))
                                    {
                                        row["Cant"] = cantidad;
                                        if ((cantidad > stock) && tipoPro == "A")
                                        {
                                            MessageBox.Show("El stock es insuficiente");
                                            return;
                                        }
                                        if (tipoPro == "C")
                                        {
                                            DataTable dtCompuesto = NProducto.mostrarDetalleProducto_Venta(Convert.ToInt32(rowProducto[0]));
                                            for (int r = 0; r < dtCompuesto.Rows.Count; r++)
                                            {
                                                if (dtCompuesto.Rows[r]["tipo"].ToString() == "A")
                                                {
                                                    siExiste = 0;
                                                    for (int z = 0; z < dtStock.Rows.Count; z++)
                                                    {
                                                        if (dtCompuesto.Rows[r]["codigo"].ToString() == dtStock.Rows[z].Cells["Codigo"].Value.ToString())
                                                        {
                                                            siExiste = 1;
                                                            stockComp = Convert.ToDecimal(dtStock.Rows[z].Cells["StockQueda"].Value);
                                                            codigoCom = dtCompuesto.Rows[r]["codigo"].ToString();
                                                            posicion = z;
                                                            break;
                                                        }
                                                    }

                                                    if (siExiste == 0)
                                                    {
                                                        dtProdCom = NProducto.MostrarProductoStock(Convert.ToInt32(dtCompuesto.Rows[r]["codigo"]));
                                                        stockComp = Convert.ToDecimal(dtProdCom.Rows[0]["Stock"].ToString());
                                                        codigoCom = dtCompuesto.Rows[r]["codigo"].ToString();
                                                    }

                                                    if (stockComp < cantidad)
                                                    {
                                                        MessageBox.Show("No hay stock suficiente");
                                                        return;
                                                    }
                                                }
                                            }
                                        }
                                        decimal subTotal = cantidad * Convert.ToDecimal(rowProducto[2].ToString());
                                        decimal subTotalActual = Convert.ToDecimal(row["Importe"]);
                                        row["Importe"] = subTotal - cantidad * Convert.ToDecimal(rowProducto[6].ToString());
                                        registrar = false;
                                        totalPagado = totalPagado + subTotal - subTotalActual;
                                        row["Descuento"] = cantidad * Convert.ToDecimal(rowProducto[6].ToString());
                                        row["Tipo"] = rowProducto[3].ToString();

                                        row["Imprimir"] = rowProducto[4].ToString();
                                        row["Bandera"] = bandera.ToString();
                                        decimal dctoTotProm = 0;
                                        for (int p = 0; p < dataListadoDetalle.Rows.Count; p++)
                                        {
                                            dctoTotProm = dctoTotProm + Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Descuento"].Value.ToString());
                                        }

                                        if (siExiste == 0)
                                        {
                                            int nroFilasStock = this.dtStock.Rows.Count;
                                            if (nroFilasStock == 0 && rowProducto[3].ToString() == "A")
                                            {
                                                this.dtStock.Rows.Insert(0, rowProducto[0].ToString(), stock - cantidad);
                                            }
                                            else if (nroFilasStock > 0 && rowProducto[3].ToString() == "A")
                                            {
                                                this.dtStock.Rows.Insert(nroFilasStock, rowProducto[0].ToString(), stock - cantidad);
                                            }
                                            else if (nroFilasStock == 0 && rowProducto[3].ToString() == "C")
                                            {
                                                this.dtStock.Rows.Insert(0, codigoCom, stockComp - (cantidad * cantReq));
                                            }
                                            else if (nroFilasStock > 0 && rowProducto[3].ToString() == "C")
                                            {
                                                this.dtStock.Rows.Insert(0, codigoCom, stockComp - (cantidad * cantReq));
                                            }
                                        }
                                        else
                                        {

                                            if (rowProducto[3].ToString() == "C")
                                            {
                                                this.dtStock[0, posicion].Value = codigoCom;
                                                this.dtStock[1, posicion].Value = stockComp - (cantidad * cantReq);
                                            }
                                            else if (rowProducto[3].ToString() == "A")
                                            {
                                                this.dtStock[0, posicion].Value = rowProducto[0];
                                                this.dtStock[1, posicion].Value = stock - cantidad;
                                            }

                                        }

                                       /* row2 = frmVenta.f1.dTDetalleMenu.NewRow();
                                        row2["idProducto"] = rowProducto[0].ToString();
                                        row2["Cant"] = Convert.ToInt32(txtCantidad.Text);
                                       // his.dtDetalle.Rows.Add(row);
                                        frmVenta.f1.dTDetalleMenu.Rows.Add(row2);*/
                                        this.dataListadoDetalle.Refresh();
                                        //this.txtCantidad.Text = "1";
                                    }
                                }


                            }

                            if (registrar)
                            {

                                //decimal stock;
                                string tipoProd;

                                decimal subTotal = cantidad * Convert.ToDecimal(rowProducto[2].ToString());
                                tipoProd = rowProducto[3].ToString();
                                if (siExiste == 0)
                                {
                                    stock = Convert.ToDecimal(rowProducto[5].ToString());
                                }
                                //
                                if (tipoProd == "C")
                                {

                                    DataTable dtCompuesto = NProducto.mostrarDetalleProducto_Venta(Convert.ToInt32(rowProducto[0]));
                                    for (int r = 0; r < dtCompuesto.Rows.Count; r++)
                                    {
                                        if (dtCompuesto.Rows[r]["tipo"].ToString() == "A")
                                        {
                                            siExiste = 0;
                                            for (int z = 0; z < dtStock.Rows.Count; z++)
                                            {
                                                if (dtCompuesto.Rows[r]["codigo"].ToString() == dtStock.Rows[z].Cells["Codigo"].Value.ToString())
                                                {
                                                    siExiste = 1;
                                                    stockComp = Convert.ToDecimal(dtStock.Rows[z].Cells["StockQueda"].Value);
                                                    codigoCom = dtCompuesto.Rows[r]["codigo"].ToString();
                                                    cantReq = Convert.ToDecimal(dtCompuesto.Rows[r]["cantidad"].ToString());
                                                    posicion = z;
                                                    break;
                                                }
                                            }

                                            if (siExiste == 0)
                                            {
                                                dtProdCom = NProducto.MostrarProductoStock(Convert.ToInt32(dtCompuesto.Rows[r]["codigo"]));
                                                stockComp = Convert.ToDecimal(dtProdCom.Rows[0]["Stock"].ToString());
                                                cantReq = Convert.ToDecimal(dtCompuesto.Rows[r]["cantidad"].ToString());
                                                codigoCom = dtCompuesto.Rows[r]["codigo"].ToString();
                                            }

                                            if (stockComp < cantidad)
                                            {
                                                MessageBox.Show("No hay stock suficiente");
                                                return;
                                            }

                                            if (siExiste == 0)
                                            {
                                                int nroFilasStock = this.dtStock.Rows.Count;
                                                if (nroFilasStock == 0 && rowProducto[3].ToString() == "A")
                                                {
                                                    this.dtStock.Rows.Insert(0, rowProducto[0].ToString(), stock - cantidad);
                                                }
                                                else if (nroFilasStock > 0 && rowProducto[3].ToString() == "A")
                                                {
                                                    this.dtStock.Rows.Insert(nroFilasStock, rowProducto[0].ToString(), stock - cantidad);
                                                }
                                                else if (nroFilasStock == 0 && rowProducto[3].ToString() == "C")
                                                {
                                                    this.dtStock.Rows.Insert(0, codigoCom, stockComp - (cantidad * cantReq));
                                                }
                                                else if (nroFilasStock > 0 && rowProducto[3].ToString() == "C")
                                                {
                                                    this.dtStock.Rows.Insert(0, codigoCom, stockComp - (cantidad * cantReq));
                                                }
                                            }
                                            else
                                            {

                                                if (rowProducto[3].ToString() == "C")
                                                {
                                                    this.dtStock[0, posicion].Value = codigoCom;
                                                    this.dtStock[1, posicion].Value = stockComp - (cantidad * cantReq);
                                                }
                                                else if (rowProducto[3].ToString() == "A")
                                                {
                                                    this.dtStock[0, posicion].Value = rowProducto[0];
                                                    this.dtStock[1, posicion].Value = stock - cantidad;
                                                }

                                            }
                                            this.dataListadoDetalle.Refresh();
                                        }
                                    }

                                }
                                if (tipoProd == "A" && stock < cantidad)
                                {
                                    MessageBox.Show("El stock es insuficiente");
                                    return;
                                }
                                else
                                {
                                    totalPagado = totalPagado + subTotal;


                                    row = this.dtDetalle.NewRow();

                                    row["Cod"] = Convert.ToInt32(rowProducto[0].ToString());
                                    row["Descripcion"] = rowProducto[1].ToString();
                                    row["Cant"] = cantidad;
                                    row["Precio_Un"] = Convert.ToDecimal(rowProducto[2].ToString());
                                    row["Importe"] = subTotal - cantidad * Convert.ToDecimal(rowProducto[6].ToString());
                                    row["Nota"] = "";
                                    row["Descuento"] = cantidad * Convert.ToDecimal(rowProducto[6].ToString());
                                    row["Tipo"] = rowProducto[3].ToString();
                                    row["Imprimir"] = rowProducto[4].ToString();
                                    row["Bandera"] = bandera.ToString();
                                    this.dtDetalle.Rows.Add(row);
                                    this.dataListadoDetalle.ClearSelection();
                                    
                                    decimal dctoTotProm = 0, subTotal20 = 0, total20 = 0;
                                    int cantidad20 = 0;

                                    for (int p = 0; p < dataListadoDetalle.Rows.Count; p++)
                                    {
                                        dctoTotProm = dctoTotProm + Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Descuento"].Value.ToString());
                                        cantidad20 = Convert.ToInt32(dataListadoDetalle.Rows[p].Cells["Cant"].Value.ToString());
                                        subTotal20 = subTotal20 + (cantidad20 * Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Precio_Un"].Value.ToString()));
                                    }

                                    if (siExiste == 0)
                                    {
                                        int nroFilasStock = this.dtStock.Rows.Count;
                                        if (nroFilasStock == 0 && rowProducto[3].ToString() == "A")
                                        {
                                            this.dtStock.Rows.Insert(0, rowProducto[0].ToString(), stock - cantidad);
                                        }
                                        else if (nroFilasStock > 0 && rowProducto[3].ToString() == "A")
                                        {
                                            this.dtStock.Rows.Insert(nroFilasStock, rowProducto[0].ToString(), stock - cantidad);
                                        }
                                        else if (nroFilasStock == 0 && rowProducto[3].ToString() == "C")
                                        {
                                            this.dtStock.Rows.Insert(0, codigoCom, stockComp - (cantidad * cantReq));
                                        }
                                        else if (nroFilasStock > 0 && rowProducto[3].ToString() == "C")
                                        {
                                            this.dtStock.Rows.Insert(0, codigoCom, stockComp - (cantidad * cantReq));
                                        }
                                    }
                                    else
                                    {

                                        if (rowProducto[3].ToString() == "C")
                                        {
                                            this.dtStock[0, posicion].Value = codigoCom;
                                            this.dtStock[1, posicion].Value = stockComp - (cantidad * cantReq);
                                        }
                                        else if (rowProducto[3].ToString() == "A")
                                        {
                                            this.dtStock[0, posicion].Value = rowProducto[0];
                                            this.dtStock[1, posicion].Value = stock - cantidad;
                                        }

                                    }
                                    this.dataListadoDetalle.Refresh();

                                    // this.txtTotalPagado.Text = (totalPagado - descuentoTotal).ToString("#0.00#");

                                    //cantidadAcumulada = cantidadAcumulada + cantidad;
                                }



                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + ex.StackTrace);
                    }
                });

            }

        }
        private void crearTabla()
        {

            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("Cod", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Descripcion", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Cant", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Precio_Un", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Descuento", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Importe", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Nota", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("idDetalleVenta", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Tipo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Imprimir", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Bandera", System.Type.GetType("System.String"));
            this.dataListadoDetalle.DataSource = this.dtDetalle;
        }
        private void formatoTabla()
        {

            this.dataListadoDetalle.Columns[0].Visible = false;
            this.dataListadoDetalle.Columns[3].Visible = false;
            this.dataListadoDetalle.Columns[4].Visible = false;
            this.dataListadoDetalle.Columns[5].Visible = false;
            // this.dataListadoDetalle.Columns[4].Visible = false;
            this.dataListadoDetalle.Columns[6].Visible = false;
            this.dataListadoDetalle.Columns[7].Visible = false;
            this.dataListadoDetalle.Columns[8].Visible = false;
            this.dataListadoDetalle.Columns[9].Visible = false;
          //  this.dataListadoDetalle.Columns[10].Visible = false;

            //this.dataListadoDetalle.Columns[7].Visible = false;
            // DataGridView1.Columns(1).Width = 150
            //this.dataListadoDetalle.Columns[0].Width = 50;
            this.dataListadoDetalle.Columns[1].Width = 320;
            this.dataListadoDetalle.Columns[2].Width = 60;
            this.dataListadoDetalle.Columns[3].Width = 70;
            this.dataListadoDetalle.Columns[4].Width = 65;
            this.dataListadoDetalle.Columns[5].Width = 115;

            this.dataListadoDetalle.RowTemplate.Height = 37;
            this.dataListadoDetalle.ClearSelection();
            this.dataListadoDetalle.ColumnHeadersDefaultCellStyle.Font = new Font(dataListadoDetalle.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListadoDetalle.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListadoDetalle.Font = new Font("Roboto", 10);
            this.dataListadoDetalle.GridColor = SystemColors.ActiveBorder;
        }
        private void frmMenu_Desayunos_Load(object sender, EventArgs e)
        {

            crearTabla();
            formatoTabla();
            mostrarProductos();
        }
    }
}
