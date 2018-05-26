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
    public partial class frmDelivery : Form
    {
        public string idMesa, nroMesa, idSalon, nombreSalon, idMesero, nombreMesero;

        Button[] btnCategoria, btnProducto;
        DataTable dtCategoria, dtProducto, dtProdCom;
        public DataTable dtDetalle, dtDetalleVenta, dtDetalleMenu;
        public DataTable dtDetallePedido;
        private bool isNuevo = true;
        public DataRow row;
        int nroCategoria;
        private int loc = 0;

        private void actStockTem()
        {
            if (this.lblTipo.Text == "C")
            {
                DataTable dtDetProdTemp = NProducto.MostrarDetalleProducto(Convert.ToInt32(this.lblIdProductoCom.Text));
                if (dtStock.Rows.Count > 0 && dtDetProdTemp.Rows.Count > 0)
                {
                    for (int i = 0; i < dtDetProdTemp.Rows.Count; i++)
                    {
                        decimal cantReq = Convert.ToDecimal(dtDetProdTemp.Rows[i]["cantidad"].ToString());
                        for (int j = 0; j < dtStock.Rows.Count; j++)
                        {
                            if (dtStock.Rows[j].Cells["Codigo"].Value.ToString() == dtDetProdTemp.Rows[i]["Codigo"].ToString())
                            {
                                decimal cant = Convert.ToDecimal(dtStock.Rows[j].Cells["StockQueda"].Value);
                                decimal cantComp = Convert.ToDecimal(this.lblCantidadCom.Text);
                                if (this.lblBanderaStock.Text == "0")
                                {
                                    this.dtStock[1, j].Value = cant - cantReq;
                                }
                                else if (this.lblBanderaStock.Text == "1")
                                {
                                    this.dtStock[1, j].Value = cant + cantReq;
                                }
                                else if (this.lblBanderaStock.Text == "2")
                                {
                                    this.dtStock[1, j].Value = cant + (cantComp * cantReq);
                                }
                                else if (this.lblBanderaStock.Text == "3")
                                {
                                    decimal cantAct = Convert.ToDecimal(this.txtCantidad.Text.Trim());
                                    decimal cantTot;
                                    if (cantAct > cantComp)
                                    {
                                        cantTot = cantAct - cantComp;
                                        this.dtStock[1, j].Value = cant - (cantTot * cantReq);
                                    }
                                    else
                                    {
                                        cantTot = cantComp - cantAct;
                                        this.dtStock[1, j].Value = cant + (cantTot * cantReq);
                                    }

                                }
                            }
                        }
                    }
                }
            }
            else if (this.lblTipo.Text == "A")
            {
                for (int j = 0; j < dtStock.Rows.Count; j++)
                {
                    if (dtStock.Rows[j].Cells["Codigo"].Value.ToString() == this.lblIdProductoCom.Text)
                    {
                        decimal cant = Convert.ToDecimal(dtStock.Rows[j].Cells["StockQueda"].Value);
                        decimal cantComp = Convert.ToDecimal(this.lblCantidadCom.Text);
                        if (this.lblBanderaStock.Text == "0")
                        {
                            this.dtStock[1, j].Value = cant - 1;
                        }
                        else if (this.lblBanderaStock.Text == "1")
                        {
                            this.dtStock[1, j].Value = cant + 1;
                        }
                        else if (this.lblBanderaStock.Text == "2")
                        {
                            this.dtStock[1, j].Value = cant + cantComp;
                        }
                        else if (this.lblBanderaStock.Text == "3")
                        {
                            decimal cantAct = Convert.ToDecimal(this.txtCantidad.Text.Trim());
                            decimal cantTot;
                            if (cantAct > cantComp)
                            {
                                cantTot = cantAct - cantComp;
                                this.dtStock[1, j].Value = cant - cantTot;
                            }
                            else
                            {
                                cantTot = cantComp - cantAct;
                                this.dtStock[1, j].Value = cant + cantTot;
                            }

                        }
                    }
                }
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (lblBandera.Text.Equals("1"))
            {
                this.lblBanderaStock.Text = "0";
                decimal descuentoIndividual = 0;
                int cantidad = Convert.ToInt32(this.dataListadoDetalle[2, Convert.ToInt32(this.lblPosicion.Text)].Value);
                descuentoIndividual = Convert.ToDecimal(this.dataListadoDetalle[4, Convert.ToInt32(this.lblPosicion.Text)].Value);
                decimal subTotal = (cantidad + 1) * Convert.ToDecimal(this.lblPrecioUnitario.Text);
                decimal descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                decimal importeActual = Convert.ToDecimal(this.lblImporte.Text);
                decimal nuevoDesc = Convert.ToDecimal(lblDescuento.Text) + (Convert.ToDecimal(lblDescuento.Text) / Convert.ToDecimal(lblCantidadCom.Text));
                this.dataListadoDetalle[2, Convert.ToInt32(this.lblPosicion.Text)].Value = (cantidad + 1).ToString();
                this.dataListadoDetalle[4, Convert.ToInt32(this.lblPosicion.Text)].Value = nuevoDesc;
                this.dataListadoDetalle[5, Convert.ToInt32(this.lblPosicion.Text)].Value = subTotal - nuevoDesc;
                /*
                totalPagado = totalPagado + subTotal - importeActual;
                this.txtSubTotal.Text = totalPagado.ToString("#0.00#");
                this.txtTotalPagado.Text = (totalPagado - descuentoTotal).ToString("#0.00#");
                //this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");*/
                decimal dctoTotProm = 0, subTotal20 = 0, total20 = 0;
                int cantidad20 = 0;

                for (int p = 0; p < dataListadoDetalle.Rows.Count; p++)
                {
                    dctoTotProm = dctoTotProm + Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Descuento"].Value.ToString());
                    cantidad20 = Convert.ToInt32(dataListadoDetalle.Rows[p].Cells["Cant"].Value.ToString());
                    subTotal20 = subTotal20 + (cantidad20 * Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Precio_Un"].Value.ToString()));
                }
                this.txtDescuento.Text = dctoTotProm.ToString();
                descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                this.txtSubTotal.Text = subTotal20.ToString("#0.00#");
                this.txtTotalPagado.Text = (subTotal20 - descuentoTotal).ToString("#0.00#");

                this.lblPosicion.Text = string.Empty;
                this.lblBandera.Text = "0";
                this.dataListadoDetalle.ClearSelection();
                this.actStockTem();
                this.lblBandera.Focus();
            }
            else
            {
                MessageBox.Show("Seleccione un producto de la lista");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lblIdVenta.Text != "0")
                {

                    if (this.dataListadoDetalle.Rows.Count <= 0)
                    {
                        MensajeError("No existen filas en la tabla");
                        HabilitarUno();
                    }
                    else if (this.dataListadoDetalle.SelectedRows.Count > 0 && this.lblBandera.Text == "1")
                    {

                        DialogResult opcion;
                        string rpta = "";
                        opcion = MessageBox.Show("Está seguro de anular el pedido?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        int filasData = dtDetalleVenta.Rows.Count;
                        int filasDataA = dataListadoDetalle.Rows.Count;
                        int filaSel = Convert.ToInt32(this.lblPosicion.Text);
                        if (opcion == DialogResult.OK && lblidDetalle.Text != "")
                        //if (opcion == DialogResult.OK && filaSel <= filasData)
                        {
                            if (this.lblIdVenta.Text != "0" && this.lblBanderaDatatable.Text == "1")
                            {
                                decimal descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                                decimal subTotal = Convert.ToDecimal(this.txtSubTotal.Text);
                                int indiceFila = this.dataListadoDetalle.CurrentRow.Index;

                                DataRow row = this.dtDetalle.Rows[indiceFila];
                                dataCocina.Rows.Add(lblDescrProducto.Text, lblCantidadCom.Text,
                                  dataListadoDetalle.Rows[Convert.ToInt32(lblPosicion.Text)].Cells[6].Value.ToString(),
                                  dataListadoDetalle.Rows[Convert.ToInt32(lblPosicion.Text)].Cells["Tipo"].Value.ToString());
                                this.totalPagado = subTotal - Convert.ToDecimal(row["Importe"].ToString());

                                this.txtSubTotal.Text = totalPagado.ToString("#0.00#");
                                this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");
                                this.txtDescuento.Text = (descuentoTotal - Convert.ToDecimal(row["Descuento"].ToString())).ToString();


                                this.dtDetalle.Rows.Remove(row);
                                this.dataListadoDetalle.DataSource = dtDetalle;


                                this.lblBandera.Text = "0";
                                this.dataListadoDetalle.ClearSelection();

                                if (this.lblidDetalle.Text != string.Empty || this.lblidDetalle.Text != "0")
                                {
                                    rpta = NDetalleVenta.Eliminar(Convert.ToInt32(this.lblidDetalle.Text));
                                    if (this.lblTipo.Text == "C")
                                    {
                                        DataTable dtDetalleProducto = new DataTable();
                                        dtDetalleProducto = NProducto.mostrarDetalleProducto_Venta(Convert.ToInt32(this.lblIdProductoCom.Text));

                                        for (int j = 0; j < dtDetalleProducto.Rows.Count; j++)
                                        {
                                            int idProducto_Com = Convert.ToInt32(dtDetalleProducto.Rows[j][0].ToString());
                                            int cantRequerida = Convert.ToInt32(dtDetalleProducto.Rows[j][1].ToString());

                                            rpta = NProducto.EditarStock(idProducto_Com, ((cantRequerida * Convert.ToInt32(this.lblCantidadCom.Text) * -1)));
                                        }
                                    }

                                    DataTable dtReceta = NReceta.Mostrar(Convert.ToInt32(this.lblIdProductoCom.Text));

                                    if (dtReceta.Rows.Count > 0)
                                    {
                                        int cantInsumo = Convert.ToInt32(this.lblCantidadCom.Text);
                                        decimal cantTotal;
                                        for (int k = 0; k < dtReceta.Rows.Count; k++)
                                        {
                                            cantTotal = cantInsumo * Convert.ToDecimal(dtReceta.Rows[k][3].ToString());
                                            NInsumo.EditarStock(Convert.ToInt32(dtReceta.Rows[k][0].ToString()), ((-1) * cantTotal));
                                        }

                                    }
                                    /*DataTable dtDetalleVentaMenu = NVenta.mostrarDetalleVentaMenu(Convert.ToInt32(this.lblIdProductoCom.Text));
                                    for (int kl = 0; kl < dtDetalleVentaMenu.Rows.Count; kl++)
                                    {
                                        DataTable dtRecetaMenu = NReceta.Mostrar(Convert.ToInt32(dgvBanderaMenu.Rows[kl].Cells[0].Value.ToString()));
                                        decimal cantTotalMenu;
                                        if (dtRecetaMenu.Rows.Count > 0)
                                        {
                                            int cantInsumoMenu = Convert.ToInt32(dgvBanderaMenu.Rows[kl].Cells[2].Value.ToString());
                                            for (int rec = 0; rec < dtRecetaMenu.Rows.Count; rec++)
                                            {

                                                cantTotalMenu = cantInsumoMenu * Convert.ToDecimal(dtRecetaMenu.Rows[rec][3].ToString());
                                                rpta = NInsumo.EditarStock(Convert.ToInt32(dtRecetaMenu.Rows[rec][0].ToString()), ((-1) * cantTotalMenu));
                                            }

                                        }

                                    }*/
                                }
                                else
                                {
                                    rpta = "OK";
                                }

                                if (rpta.Equals("OK"))
                                {
                                    this.MensajeOK("Se anuló correctamente el registro");
                                    //dataCocina.Rows.Add(lblDescrProducto.Text, lblCantidadCom.Text, "","");

                                    NImprimirComanda.imprimirCom(this.lblMesero.Text, this.lblSalon.Text, this.lblMesa.Text, dataCocina, "COMANDA ANULACION");
                                    if (this.dataListadoDetalle.Rows.Count == 0)
                                    {
                                        NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                                        frmModuloSalon.f3.limpiarMesas();
                                        frmModuloSalon.f3.mostrarSalones();
                                        this.Hide();
                                    }

                                    actStockTem();

                                }
                                else
                                {
                                    this.MensajeError(rpta);
                                }
                                if (dataListadoDetalle.Rows.Count <= 0)
                                {
                                    HabilitarUno();
                                }
                            }
                            //CAQUI
                            else
                            {
                                decimal descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                                decimal subTotal = Convert.ToDecimal(this.txtSubTotal.Text);
                                int indiceFila = this.dataListadoDetalle.CurrentRow.Index;

                                DataRow row = this.dtDetalleVenta.Rows[indiceFila];

                                dataCocina.Rows.Add(lblDescrProducto.Text, lblCantidadCom.Text,
                                       dataListadoDetalle.Rows[Convert.ToInt32(lblPosicion.Text)].Cells["Nota"].Value.ToString(),
                                       dataListadoDetalle.Rows[Convert.ToInt32(lblPosicion.Text)].Cells["Tipo"].Value.ToString());

                                this.totalPagado = subTotal - Convert.ToDecimal(row["Importe"].ToString());

                                this.txtSubTotal.Text = totalPagado.ToString("#0.00#");
                                this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");
                                this.txtDescuento.Text = (descuentoTotal - Convert.ToDecimal(row["Descuento"].ToString())).ToString();


                                this.dtDetalleVenta.Rows.Remove(row);
                                this.dataListadoDetalle.DataSource = dtDetalleVenta;


                                this.lblBandera.Text = "0";
                                this.dataListadoDetalle.ClearSelection();

                                if (this.lblidDetalle.Text != string.Empty)
                                {

                                    rpta = NDetalleVenta.Eliminar(Convert.ToInt32(this.lblidDetalle.Text));
                                    if (this.lblTipo.Text == "C")
                                    {
                                        DataTable dtDetalleProducto = new DataTable();
                                        dtDetalleProducto = NProducto.mostrarDetalleProducto_Venta(Convert.ToInt32(this.lblIdProductoCom.Text));

                                        for (int j = 0; j < dtDetalleProducto.Rows.Count; j++)
                                        {
                                            int idProducto_Com = Convert.ToInt32(dtDetalleProducto.Rows[j][0].ToString());
                                            int cantRequerida = Convert.ToInt32(dtDetalleProducto.Rows[j][1].ToString());

                                            rpta = NProducto.EditarStock(idProducto_Com, ((cantRequerida * Convert.ToInt32(this.lblCantidadCom.Text) * -1)));
                                        }
                                    }


                                    DataTable dtReceta = NReceta.Mostrar(Convert.ToInt32(this.lblIdProductoCom.Text));

                                    if (dtReceta.Rows.Count > 0)
                                    {
                                        int cantInsumo = Convert.ToInt32(this.lblCantidadCom.Text);
                                        decimal cantTotal;
                                        for (int k = 0; k < dtReceta.Rows.Count; k++)
                                        {
                                            cantTotal = cantInsumo * Convert.ToDecimal(dtReceta.Rows[k][3].ToString());
                                            NInsumo.EditarStock(Convert.ToInt32(dtReceta.Rows[k][0].ToString()), ((-1) * cantTotal));
                                        }

                                    }

                                    if (lblTipo.Text == "M" || lblTipo.Text == "D")
                                    {
                                        for (int kl = 0; kl < dgvDetalleVentaMenu.Rows.Count; kl++)
                                        {
                                            DataTable dtRecetaMenu = NReceta.Mostrar(Convert.ToInt32(dgvDetalleVentaMenu.Rows[kl].Cells[0].Value.ToString()));
                                            decimal cantTotalMenu;
                                            if (dtRecetaMenu.Rows.Count > 0)
                                            {
                                                int cantInsumoMenu = Convert.ToInt32(dgvDetalleVentaMenu.Rows[kl].Cells[1].Value.ToString());
                                                for (int rec = 0; rec < dtRecetaMenu.Rows.Count; rec++)
                                                {

                                                    cantTotalMenu = cantInsumoMenu * Convert.ToDecimal(dtRecetaMenu.Rows[rec][3].ToString());
                                                    rpta = NInsumo.EditarStock(Convert.ToInt32(dtRecetaMenu.Rows[rec][0].ToString()), ((-1) * cantTotalMenu));
                                                }

                                            }


                                        }
                                        rpta = NDetalleVenta.EliminarDetalleVentaMenu(Convert.ToInt32(lblidDetalle.Text));
                                    }
                                }
                                else
                                {
                                    rpta = "OK";
                                }

                                if (rpta.Equals("OK"))
                                {
                                    this.MensajeOK("Se anuló correctamente el registro");

                                    NImprimirComanda.imprimirCom(this.lblMesero.Text, this.lblSalon.Text, this.lblMesa.Text, dataCocina, "COMANDA ANULACION");
                                    if (this.dataListadoDetalle.Rows.Count == 0)
                                    {

                                        NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                                        frmModuloSalon.f3.limpiarMesas();
                                        frmModuloSalon.f3.mostrarSalones();
                                        this.Hide();
                                    }
                                    this.Hide();

                                }
                                else
                                {
                                    this.MensajeError(rpta);
                                }
                                if (dataListadoDetalle.Rows.Count <= 0)
                                {
                                    HabilitarUno();
                                }
                            }

                        }
                        else if (opcion == DialogResult.OK && lblidDetalle.Text == "")
                        {
                            if (this.dataListadoDetalle.Rows.Count <= 0)
                            {
                                MensajeError("No existen filas en la tabla");
                            }
                            else if (this.dataListadoDetalle.SelectedRows.Count > 0)
                            {
                                decimal descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                                this.lblBanderaStock.Text = "2";
                                int indiceFila = this.dataListadoDetalle.CurrentRow.Index;
                                DataRow row = this.dtDetalleVenta.Rows[indiceFila];

                                /* this.totalPagado = this.totalPagado - Convert.ToDecimal(row["Importe"].ToString());
                                 this.txtSubTotal.Text = totalPagado.ToString("#0.00#");
                                 this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");
                                 this.txtDescuento.Text = (descuentoTotal - Convert.ToDecimal(row["Descuento"].ToString())).ToString();
         */


                                string tipo1 = dataListadoDetalle.Rows[indiceFila].Cells["Tipo"].Value.ToString();
                                string bandMen = dataListadoDetalle.Rows[indiceFila].Cells["Barra"].Value.ToString();
                                this.dtDetalleVenta.Rows.Remove(row);
                                this.dataListadoDetalle.ClearSelection();
                                this.lblBandera.Text = "0";
                                decimal dctoTotProm = 0, subTotal20 = 0, total20 = 0;
                                int cantidad20 = 0;
                                string tipo;
                                for (int p = 0; p < dataListadoDetalle.Rows.Count; p++)
                                {
                                    dctoTotProm = dctoTotProm + Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Descuento"].Value.ToString());
                                    cantidad20 = Convert.ToInt32(dataListadoDetalle.Rows[p].Cells["Cant"].Value.ToString());
                                    subTotal20 = subTotal20 + (cantidad20 * Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Precio_Un"].Value.ToString()));
                                }
                                this.txtDescuento.Text = dctoTotProm.ToString();
                                descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                                this.txtSubTotal.Text = subTotal20.ToString("#0.00#");
                                this.txtTotalPagado.Text = (subTotal20 - descuentoTotal).ToString("#0.00#");
                                if (dataListadoDetalle.Rows.Count <= 0)
                                {
                                    HabilitarUno();
                                }
                             
                                actStockTem();
                                if (dataListadoDetalle.Rows.Count == 0)
                                {
                                    this.dtStock.Rows.Clear();
                                }
                                cantidadAcumulada = 0;

                                if (tipo1 == "M" || tipo1 == "D")
                                {
                                    int contador = 0;

                                    for (int y = 0; y < dgvBanderaMenu.Rows.Count; y++)
                                    {
                                        if (bandMen == dgvBanderaMenu.Rows[y].Cells[1].Value.ToString())
                                        {
                                            dgvBanderaMenu.Rows.RemoveAt(y);
                                            y = -1;
                                        }
                                    }

                                    for (int y = 0; y < dtDetalleMenu.Rows.Count; y++)
                                    {
                                        if (bandMen == dtDetalleMenu.Rows[y][2].ToString())
                                        {
                                            dtDetalleMenu.Rows.RemoveAt(y);
                                            y = -1;
                                        }
                                    }

                                    /* while(bandMen == dgvBanderaMenu.Rows[contador].Cells[1].Value.ToString())
                                     {
                                         dgvBanderaMenu.Rows.RemoveAt(contador);
                                         contador++;
                                     }*/
                                }
                            }
                            else
                            {
                                MensajeError("Seleccione una fila");
                            }
                        }

                    }
                    else
                    {
                        MensajeError("Seleccione una fila");
                    }
                }
                else
                {
                    if (this.dataListadoDetalle.Rows.Count <= 0)
                    {
                        MensajeError("No existen filas en la tabla");
                    }
                    else if (this.dataListadoDetalle.SelectedRows.Count > 0)
                    {
                        decimal descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                        this.lblBanderaStock.Text = "2";
                        int indiceFila = this.dataListadoDetalle.CurrentRow.Index;
                        DataRow row = this.dtDetalle.Rows[indiceFila];

                        /* this.totalPagado = this.totalPagado - Convert.ToDecimal(row["Importe"].ToString());
                         this.txtSubTotal.Text = totalPagado.ToString("#0.00#");
                         this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");
                         this.txtDescuento.Text = (descuentoTotal - Convert.ToDecimal(row["Descuento"].ToString())).ToString();
 */


                        string tipo1 = dataListadoDetalle.Rows[indiceFila].Cells["Tipo"].Value.ToString();
                        string bandMen = dataListadoDetalle.Rows[indiceFila].Cells["Barra"].Value.ToString();
                        this.dtDetalle.Rows.Remove(row);
                        this.dataListadoDetalle.ClearSelection();
                        this.lblBandera.Text = "0";
                        decimal dctoTotProm = 0, subTotal20 = 0, total20 = 0;
                        int cantidad20 = 0;
                        string tipo;
                        for (int p = 0; p < dataListadoDetalle.Rows.Count; p++)
                        {
                            dctoTotProm = dctoTotProm + Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Descuento"].Value.ToString());
                            cantidad20 = Convert.ToInt32(dataListadoDetalle.Rows[p].Cells["Cant"].Value.ToString());
                            subTotal20 = subTotal20 + (cantidad20 * Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Precio_Un"].Value.ToString()));
                        }
                        this.txtDescuento.Text = dctoTotProm.ToString();
                        descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                        this.txtSubTotal.Text = subTotal20.ToString("#0.00#");
                        this.txtTotalPagado.Text = (subTotal20 - descuentoTotal).ToString("#0.00#");
                        if (dataListadoDetalle.Rows.Count <= 0)
                        {
                            HabilitarUno();
                        }
                   
                        actStockTem();
                        if (dataListadoDetalle.Rows.Count == 0)
                        {
                            this.dtStock.Rows.Clear();
                        }
                        cantidadAcumulada = 0;

                        if (tipo1 == "M" || tipo1 == "D")
                        {
                            int contador = 0;

                            for (int y = 0; y < dgvBanderaMenu.Rows.Count; y++)
                            {
                                if (bandMen == dgvBanderaMenu.Rows[y].Cells[1].Value.ToString())
                                {
                                    dgvBanderaMenu.Rows.RemoveAt(y);
                                    y = -1;
                                }
                            }

                            for (int y = 0; y < dtDetalleMenu.Rows.Count; y++)
                            {
                                if (bandMen == dtDetalleMenu.Rows[y][2].ToString())
                                {
                                    dtDetalleMenu.Rows.RemoveAt(y);
                                    y = -1;
                                }
                            }

                            /* while(bandMen == dgvBanderaMenu.Rows[contador].Cells[1].Value.ToString())
                             {
                                 dgvBanderaMenu.Rows.RemoveAt(contador);
                                 contador++;
                             }*/
                        }
                    }
                    else
                    {
                        MensajeError("Seleccione una fila");
                    }
                }




            }
            catch (Exception ex)
            {
                MensajeError("No hay filas para remover");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lblBandera.Text.Equals("1"))
            {
                if (this.lblIdVenta.Text == "0")
                {
                    this.lblBanderaStock.Text = "1";
                    decimal descuentoIndividual = 0;
                    int cantidad = Convert.ToInt32(this.dataListadoDetalle[2, Convert.ToInt32(this.lblPosicion.Text)].Value);
                    if (cantidad > 1)
                    {
                        descuentoIndividual = Convert.ToDecimal(this.dataListadoDetalle[4, Convert.ToInt32(this.lblPosicion.Text)].Value);
                        decimal subTotal = (cantidad - 1) * Convert.ToDecimal(this.lblPrecioUnitario.Text);
                        decimal descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                        decimal importeActual = Convert.ToDecimal(this.lblImporte.Text);
                        decimal nuevoDesc = Convert.ToDecimal(lblDescuento.Text) - (Convert.ToDecimal(lblDescuento.Text) / Convert.ToDecimal(lblCantidadCom.Text));
                        this.dataListadoDetalle[2, Convert.ToInt32(this.lblPosicion.Text)].Value = (cantidad - 1).ToString();
                        this.dataListadoDetalle[4, Convert.ToInt32(this.lblPosicion.Text)].Value = nuevoDesc;
                        this.dataListadoDetalle[5, Convert.ToInt32(this.lblPosicion.Text)].Value = subTotal - nuevoDesc;
                        /*
                        totalPagado = totalPagado + subTotal - importeActual;
                        this.txtSubTotal.Text = totalPagado.ToString("#0.00#");
                        this.txtTotalPagado.Text = (totalPagado - descuentoTotal).ToString("#0.00#");
                        //this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");*/
                        decimal dctoTotProm = 0, subTotal20 = 0, total20 = 0;
                        int cantidad20 = 0;

                        for (int p = 0; p < dataListadoDetalle.Rows.Count; p++)
                        {
                            dctoTotProm = dctoTotProm + Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Descuento"].Value.ToString());
                            cantidad20 = Convert.ToInt32(dataListadoDetalle.Rows[p].Cells["Cant"].Value.ToString());
                            subTotal20 = subTotal20 + (cantidad20 * Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Precio_Un"].Value.ToString()));
                        }
                        this.txtDescuento.Text = dctoTotProm.ToString();
                        descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                        this.txtSubTotal.Text = subTotal20.ToString("#0.00#");
                        this.txtTotalPagado.Text = (subTotal20 - descuentoTotal).ToString("#0.00#");
                        //this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");
                        this.lblPosicion.Text = string.Empty;
                        this.lblBandera.Text = "0";
                        this.dataListadoDetalle.ClearSelection();

                        this.actStockTem();
                        this.lblBandera.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Presione el botón QUITAR");
                    }

                }
                else
                {
                    if (this.txtCantidad.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Ingrese la cantidad a disminuir");
                    }
                    else
                    {
                        decimal cantDism = Convert.ToDecimal(this.txtCantidad.Text);
                        decimal cantPedi = Convert.ToDecimal(this.lblCantidadCom.Text);
                        if (cantDism > cantPedi)
                        {
                            MessageBox.Show("Ingrese una cantidad menor al pedido");
                        }
                        else if (dataListadoDetalle.Rows.Count == 1 && cantPedi == cantDism)
                        {
                            MessageBox.Show("Presione el botón Quitar");
                        }
                        else
                        {
                            DialogResult opcion;
                            string rpta = "";
                            opcion = MessageBox.Show("Está seguro de disminuir el pedido en " + txtCantidad.Text + "?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                            if (opcion == DialogResult.OK)
                            {
                                int indice = Convert.ToInt32(this.lblIndice.Text);
                                string producto = dataListadoDetalle.Rows[indice].Cells["Descripcion"].Value.ToString();
                                int cantidad1 = Convert.ToInt32(this.txtCantidad.Text);
                                string nota = dataListadoDetalle.Rows[indice].Cells["Nota"].Value.ToString();
                                dataCocina.Rows.Add(producto, cantidad1, nota);

                                this.lblBanderaStock.Text = "1";
                                decimal descuentoIndividual = 0;
                                int cantidad = Convert.ToInt32(this.dataListadoDetalle[2, Convert.ToInt32(this.lblPosicion.Text)].Value);
                                int cantDism1 = Convert.ToInt32(this.txtCantidad.Text.Trim());
                                if (cantidad > 1)
                                {
                                    descuentoIndividual = Convert.ToDecimal(this.dataListadoDetalle[4, Convert.ToInt32(this.lblPosicion.Text)].Value);
                                    decimal subTotal = (cantidad - cantDism1) * Convert.ToDecimal(this.lblPrecioUnitario.Text);
                                    decimal descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                                    decimal importeActual = Convert.ToDecimal(this.lblImporte.Text);
                                    decimal nuevoDesc = Convert.ToDecimal(lblDescuento.Text) - (Convert.ToDecimal(lblDescuento.Text) / Convert.ToDecimal(lblCantidadCom.Text));
                                    this.dataListadoDetalle[2, Convert.ToInt32(this.lblPosicion.Text)].Value = (cantidad - cantDism1).ToString();
                                    this.dataListadoDetalle[4, Convert.ToInt32(this.lblPosicion.Text)].Value = nuevoDesc;
                                    this.dataListadoDetalle[5, Convert.ToInt32(this.lblPosicion.Text)].Value = subTotal - nuevoDesc;
                                    /*
                                    totalPagado = totalPagado + subTotal - importeActual;
                                    this.txtSubTotal.Text = totalPagado.ToString("#0.00#");
                                    this.txtTotalPagado.Text = (totalPagado - descuentoTotal).ToString("#0.00#");
                                    //this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");*/
                                    decimal dctoTotProm = 0, subTotal20 = 0, total20 = 0;
                                    int cantidad20 = 0;

                                    for (int p = 0; p < dataListadoDetalle.Rows.Count; p++)
                                    {
                                        dctoTotProm = dctoTotProm + Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Descuento"].Value.ToString());
                                        cantidad20 = Convert.ToInt32(dataListadoDetalle.Rows[p].Cells["Cant"].Value.ToString());
                                        subTotal20 = subTotal20 + (cantidad20 * Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Precio_Un"].Value.ToString()));
                                    }
                                    this.txtDescuento.Text = dctoTotProm.ToString();
                                    descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                                    this.txtSubTotal.Text = subTotal20.ToString("#0.00#");
                                    this.txtTotalPagado.Text = (subTotal20 - descuentoTotal).ToString("#0.00#");
                                    //this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");
                                    this.lblPosicion.Text = string.Empty;
                                    this.lblBandera.Text = "0";
                                    this.dataListadoDetalle.ClearSelection();
                                    if (this.lblidDetalle.Text != string.Empty)
                                    {
                                        //rpta = NDetalleVenta.Eliminar(Convert.ToInt32(this.lblidDetalle.Text));
                                        if (this.lblTipo.Text == "C")
                                        {
                                            DataTable dtDetalleProducto = new DataTable();
                                            dtDetalleProducto = NProducto.mostrarDetalleProducto_Venta(Convert.ToInt32(this.lblIdProductoCom.Text));

                                            for (int j = 0; j < dtDetalleProducto.Rows.Count; j++)
                                            {
                                                int idProducto_Com = Convert.ToInt32(dtDetalleProducto.Rows[j][0].ToString());
                                                int cantRequerida = Convert.ToInt32(dtDetalleProducto.Rows[j][1].ToString());

                                                rpta = NProducto.EditarStock(idProducto_Com, ((cantRequerida * Convert.ToInt32(this.txtCantidad.Text.Trim()) * -1)));
                                            }
                                        }

                                        DataTable dtReceta = NReceta.Mostrar(Convert.ToInt32(this.lblIdProductoCom.Text));

                                        if (dtReceta.Rows.Count > 0)
                                        {
                                            int cantInsumo = Convert.ToInt32(this.txtCantidad.Text.Trim());
                                            decimal cantTotal;
                                            for (int k = 0; k < dtReceta.Rows.Count; k++)
                                            {
                                                cantTotal = cantInsumo * Convert.ToDecimal(dtReceta.Rows[k][3].ToString());
                                                NInsumo.EditarStock(Convert.ToInt32(dtReceta.Rows[k][0].ToString()), ((-1) * cantTotal));
                                            }

                                        }
                                    }
                                    else
                                    {
                                        rpta = "OK";
                                    }
                                    NDetalleVenta.EditarCantidadDetalleVenta(Convert.ToInt32(this.lblidDetalle.Text), Convert.ToInt32(this.txtCantidad.Text.Trim()), Convert.ToInt32(this.lblIdProductoCom.Text));
                                    this.actStockTem();
                                    this.lblBandera.Focus();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Presione el botón QUITAR");
                                }
                                NImprimirComanda.imprimirCom(this.lblMesero.Text, this.lblSalon.Text, this.lblMesa.Text, dataCocina, "COMANDA ANULACIÓN");
                            }
                        }

                    }

                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto de la lista");
            }
        }

        private void btnTermino_Click(object sender, EventArgs e)
        {
            if (this.lblBandera.Text.Equals("1"))
            {
                frmNota form = new frmNota();
                form.posicion = this.lblPosicion.Text;
                form.TxtNota.Text = this.lblNota.Text;
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un producto de la lista");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.txtCantidad.Text += "1";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.txtCantidad.Text += "2";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.txtCantidad.Text += "3";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.txtCantidad.Text += "4";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.txtCantidad.Text += "5";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.txtCantidad.Text += "6";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.txtCantidad.Text += "7";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.txtCantidad.Text += "8";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.txtCantidad.Text += "9";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.txtCantidad.Text += "0";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (this.txtCantidad.Text.Length == 1)
            {
                this.txtCantidad.Text = string.Empty;
            }
            else if (this.txtCantidad.Text.Length != 0)
            {
                this.txtCantidad.Text = this.txtCantidad.Text.Substring(0, this.txtCantidad.Text.Length - 1);
            }
        }

        private void mostrarCategorias()
        {
            dtCategoria = NCategoria.Mostrar();
            nroCategoria = dtCategoria.Rows.Count;
            int y = 30;
            int x = 25;
            btnCategoria = new Button[nroCategoria];

            for (int i = 0; i < nroCategoria; i++)
            {
                if (i == 8)
                {
                    y = 100;
                    x = 25;
                }
                else if (i == 16)
                {
                    y = 170;
                    x = 25;
                }
                else if (i == 24)
                {
                    y = 240;
                    x = 25;
                }
                else if (i == 32)
                {
                    y = 310;
                    x = 25;
                }
                if (i == 40)
                {
                    y = 380;
                    x = 25;
                }
                else if (i == 48)
                {
                    y = 450;
                    x = 25;
                }
                else if (i == 56)
                {
                    y = 520;
                    x = 25;
                }
                else if (i == 64)
                {
                    y = 590;
                    x = 25;
                }
                else if (i == 72)
                {
                    y = 660;
                    x = 25;
                }
                DataRow row = dtCategoria.Rows[i];
                if (i == 0)
                {
                    this.lblIdCategoriaPrimera.Text = String.Concat(row[0].ToString());
                    this.mostrarProductos(this.lblIdCategoriaPrimera.Text);
                }
                btnCategoria[i] = new Button();
                btnCategoria[i].Location = new Point(x, y);
                btnCategoria[i].Name = string.Concat("btnCategoria", i.ToString());
                btnCategoria[i].Size = new Size(100, 67);
                btnCategoria[i].TabIndex = i;
                btnCategoria[i].Font = new Font("Roboto", 7f, FontStyle.Bold);
                btnCategoria[i].Text = row[1].ToString();
                btnCategoria[i].BackColor = Color.FromArgb(250, 250, 250);
                btnCategoria[i].ForeColor = Color.Black;
                btnCategoria[i].FlatAppearance.BorderColor = Color.Black;
                btnCategoria[i].FlatAppearance.BorderSize = 4;
                btnCategoria[i].Visible = true;
                btnCategoria[i].Tag = i;
                btnCategoria[i].Click += new EventHandler((sender, e) =>
                {
                    limpiarProductos();
                    this.mostrarProductos(row[0].ToString());
                });
                //this.Controls.Add(this.btnSalon[i]);
                x += 106;

                // gbCategoria.Controls.Add(btnCategoria[i]);
                plCategorias.Controls.Add(btnCategoria[i]);
            }

        }
        private void mostrarProductos(string idCategoria)
        {
            lblNroProducto.Text = "0";
            int nroProductos;
            dtProducto = NProducto.MostrarProductoCategoria(Convert.ToInt32(idCategoria));
            nroProductos = dtProducto.Rows.Count;

            int y1 = 20;
            int x1 = 1;


            btnProducto = new Button[nroProductos];

            for (int i = 0; i < nroProductos; i++)
            {

                if (i == 7)
                {
                    y1 = 120;
                    x1 = 1;
                }
                else if (i == 14)
                {
                    y1 = 220;
                    x1 = 1;
                }
                else if (i == 21)
                {
                    y1 = 320;
                    x1 = 1;
                }
                else if (i == 28)
                {
                    y1 = 420;
                    x1 = 1;
                }
                else if (i == 35)
                {
                    y1 = 520;
                    x1 = 1;
                }
                else if (i == 42)
                {
                    y1 = 620;
                    x1 = 1;
                }
                else if (i == 49)
                {
                    y1 = 720;
                    x1 = 1;
                }

                else if (i == 56)
                {
                    y1 = 820;
                    x1 = 1;
                }

                else if (i == 63)
                {
                    y1 = 920;
                    x1 = 1;
                }
                else if (i == 70)
                {
                    y1 = 1020;
                    x1 = 1;
                }
                DataRow rowProducto = dtProducto.Rows[i];
                btnProducto[i] = new Button();
                btnProducto[i].Location = new Point(x1, y1);
                btnProducto[i].Name = string.Concat("btnProducto", i.ToString());
                //String mesa = row[0].ToString();
                //btnMesa[i].Name = string.Concat("btnMesa",mesa);
                btnProducto[i].Size = new Size(104, 75);
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
                lblNroProducto.Text = nroProductos.ToString();
                x1 += 107;

                plProductos.Controls.Add(btnProducto[i]);

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
                        decimal descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text.Trim());
                        if (this.txtCantidad.Text.Equals("0"))
                        {
                            MessageBox.Show("Ingrese un número mayor a 0");
                        }
                        else
                        {
                            bool registrar = true;
                            this.lblBandera.Text = "0";
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
                                            row["Barra"] = "1";
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
                                            this.txtDescuento.Text = dctoTotProm.ToString();
                                            descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                                            this.txtSubTotal.Text = subTotal20.ToString("#0.00#");
                                            this.txtTotalPagado.Text = (subTotal20 - descuentoTotal).ToString("#0.00#");
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
                                            this.txtSubTotal.Text = totalPagado.ToString("#0.00#");
                                            this.txtTotalPagado.Text = (totalPagado - descuentoTotal).ToString("#0.00#");
                                            row["Imprimir"] = rowProducto[4].ToString();
                                            row["Barra"] = "1";
                                            decimal dctoTotProm = 0;
                                            for (int p = 0; p < dataListadoDetalle.Rows.Count; p++)
                                            {
                                                dctoTotProm = dctoTotProm + Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Descuento"].Value.ToString());
                                            }
                                            this.txtDescuento.Text = dctoTotProm.ToString();
                                            descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                                            this.txtTotalPagado.Text = (totalPagado - descuentoTotal).ToString("#0.00#");
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
                                        this.txtSubTotal.Text = totalPagado.ToString("#0.00#");

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
                                        row["Barra"] = "1";
                                        this.dtDetalle.Rows.Add(row);
                                        this.dataListadoDetalle.ClearSelection();
                                        this.txtCantidad.Text = "";
                                        decimal dctoTotProm = 0, subTotal20 = 0, total20 = 0;
                                        int cantidad20 = 0;

                                        for (int p = 0; p < dataListadoDetalle.Rows.Count; p++)
                                        {
                                            dctoTotProm = dctoTotProm + Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Descuento"].Value.ToString());
                                            cantidad20 = Convert.ToInt32(dataListadoDetalle.Rows[p].Cells["Cant"].Value.ToString());
                                            subTotal20 = subTotal20 + (cantidad20 * Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Precio_Un"].Value.ToString()));
                                        }
                                        this.txtDescuento.Text = dctoTotProm.ToString();
                                        descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                                        this.txtSubTotal.Text = subTotal20.ToString("#0.00#");
                                        this.txtTotalPagado.Text = (subTotal20 - descuentoTotal).ToString("#0.00#");



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

                        this.btnPedido.Enabled = true;

                        this.txtCantidad.Text = string.Empty;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + ex.StackTrace);
                    }
                });

            }

        }

        private void limpiarProductos()
        {

            if (lblNroProducto.Text != "")
            {
                int nro = Convert.ToInt32(lblNroProducto.Text);
                for (int j = 0; j < nro; j++)
                {
                    plProductos.Controls.Remove(btnProducto[j]);
                }
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
            this.dtDetalle.Columns.Add("Barra", System.Type.GetType("System.String"));
            this.dataListadoDetalle.DataSource = this.dtDetalle;
        }

        private void crearTablaMenu()
        {
            /*
            this.dtDetalleMenu = new DataTable("DetalleMenu");
            this.dtDetalleMenu.Columns.Add("Cod", System.Type.GetType("System.Int32"));
            this.dtDetalleMenu.Columns.Add("Cant", System.Type.GetType("System.Int32"));

            this.dgvDetalleMenu.DataSource = this.dtDetalleMenu;

            ¨*/
            this.dtDetalleMenu = new DataTable("DetalleMenu");
            this.dtDetalleMenu.Columns.Add("Cod", System.Type.GetType("System.Int32"));
            this.dtDetalleMenu.Columns.Add("Cant", System.Type.GetType("System.Int32"));
            this.dtDetalleMenu.Columns.Add("Barra", System.Type.GetType("System.String"));
            this.dgvDetalleMenu.DataSource = this.dtDetalleMenu;
        }
        private void formatoTabla()
        {

            this.dataListadoDetalle.Columns[0].Visible = false;
            // this.dataListadoDetalle.Columns[4].Visible = false;
            this.dataListadoDetalle.Columns[6].Visible = false;
            this.dataListadoDetalle.Columns[7].Visible = false;
            this.dataListadoDetalle.Columns[8].Visible = false;
            this.dataListadoDetalle.Columns[9].Visible = false;

            //this.dataListadoDetalle.Columns[7].Visible = false;
            // DataGridView1.Columns(1).Width = 150
            //this.dataListadoDetalle.Columns[0].Width = 50;
            this.dataListadoDetalle.Columns[1].Width = 300;
            this.dataListadoDetalle.Columns[2].Width = 40;
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

        private void HabilitarUno()
        {
            this.btnPedido.Enabled = false;
            this.btnGuardar.Enabled = false;
        }

        private void frmDelivery_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.lblMesa.Text = nroMesa;
            this.lblMesero.Text = nombreMesero;
            this.lblSalon.Text = nombreSalon;
            this.mostrarCategorias();
            this.crearTabla();
            this.crearTablaMenu();
            this.formatoTabla();
            this.plCategorias.AutoScroll = false;
            this.plProductos.AutoScroll = false;
            HabilitarUno();

        }

        private void dataListadoDetalle_Click(object sender, EventArgs e)
        {
            if (dataListadoDetalle.Rows.Count > 0)
            {
                this.lblPrecioUnitario.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Precio_Un"].Value);
                this.lblImporte.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Importe"].Value);
                this.lblNota.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Nota"].Value);
                this.lblDescuento.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Descuento"].Value);
                this.lblTipo.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Tipo"].Value);
                this.lblCantidadCom.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Cant"].Value);
                this.lblIdProductoCom.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Cod"].Value);
                if (this.lblIdVenta.Text != "0" && this.dataListadoDetalle.Columns.Count == 10)
                {
                    this.lblidDetalle.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["idDetalleVenta"].Value);
                }

                this.lblTotalActual.Text = this.txtTotalPagado.Text;
                this.lblPosicion.Text = dataListadoDetalle.CurrentRow.Index.ToString();
                this.lblBandera.Text = "1";

            }

        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            if ((int)e.KeyChar == (int)Keys.Enter && this.txtCantidad.Text != string.Empty && this.lblBandera.Text.Equals("1") && this.lblIdVenta.Text == "0")
            {
                actualizarProducto();
            }
            if ((int)e.KeyChar == (int)Keys.Escape)
            {
                this.txtCantidad.Text = "";
                this.dataListadoDetalle.ClearSelection();
                this.lblBandera.Focus();
            }
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            frmVistaClientePagoVenta form = new frmVistaClientePagoVenta();
            form.lblBandera.Text = "1";
            form.ShowDialog();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.btnGuardarCliente.Enabled = true;
            this.txtNombre.ReadOnly = false;
            this.txtDireccion.ReadOnly = false;
            this.txtTelefono.ReadOnly = false;
            this.txtNombre.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtDocumento.Text = string.Empty;
            this.txtIdCliente.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtDocumento.Focus();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string rpta = "";
            if (this.txtDocumento.Text.Length == 11)
            {
                if (this.txtNombre.Text.Trim() == "" || this.txtDireccion.Text.Trim() == "" || this.txtTelefono.Text.Trim() == "")
                {
                    MessageBox.Show("Complete el nombre, dirección y telefono");
                }
                else
                {
                    rpta = NCliente.InsertarVenta(this.txtNombre.Text.Trim().ToUpper(), DateTime.MinValue, "RUC", this.txtDocumento.Text, this.txtDireccion.Text.Trim(),"", this.txtTelefono.Text.Trim());
                    this.txtIdCliente.Text = rpta;
                    this.txtNombre.ReadOnly = true;
                    this.txtDireccion.ReadOnly = true;
                    this.txtTelefono.ReadOnly = true;
                    this.btnGuardarCliente.Enabled = false;
                }

            }
            else if (this.txtDocumento.Text.Length == 8)
            {
                if (this.txtNombre.Text.Trim() == "" || this.txtDireccion.Text.Trim() == "" || this.txtTelefono.Text.Trim() == "")
                {
                    MessageBox.Show("Complete el nombre, dirección y telefono");
                }
                else
                {
                    rpta = NCliente.InsertarVenta(this.txtNombre.Text.Trim().ToUpper(), DateTime.MinValue, "DNI", this.txtDocumento.Text, this.txtDireccion.Text.Trim(), "", this.txtTelefono.Text.Trim());
                    this.txtIdCliente.Text = rpta;
                    this.txtNombre.ReadOnly = true;
                    this.txtDireccion.ReadOnly = true;
                    this.txtTelefono.ReadOnly = true;
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
                    this.txtTelefono.Text = dtClienteVenta.Rows[0][4].ToString();
                }
            }
        }

        private void btnDownProductos_Click(object sender, EventArgs e)
        {
            if (locProducto + 110 < plProductos.VerticalScroll.Maximum)
            {
                locProducto += 110;
                plProductos.VerticalScroll.Value = locProducto;
            }
            else
            {

                locProducto = plProductos.VerticalScroll.Maximum;
                plProductos.AutoScrollPosition = new Point(0, locProducto);

            }
        }

        private void btnUpProductos_Click(object sender, EventArgs e)
        {
            if (locProducto - 150 > 0)
            {
                locProducto -= 206;
                plProductos.VerticalScroll.Value = locProducto;
            }
            else
            {
                locProducto = 0;
                plProductos.AutoScrollPosition = new Point(0, locProducto);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (loc + 150 < plCategorias.VerticalScroll.Maximum)
            {
                loc += 150;
                plCategorias.VerticalScroll.Value = loc;
            }
            else
            {

                loc = plCategorias.VerticalScroll.Maximum;
                plCategorias.AutoScrollPosition = new Point(0, loc);

            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (loc - 250 > 0)
            {
                loc -= 276;
                plCategorias.VerticalScroll.Value = loc;
            }
            else
            {
                loc = 0;
                plCategorias.AutoScrollPosition = new Point(0, loc);
            }
        }

        private void mostrarTotales()
        {
            decimal total = Convert.ToDecimal(this.txtTotalPagado.Text);
            decimal efectivo = 0;

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

        private void txtEfectivo_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotales();
        }

        private void btnPedido_Click(object sender, EventArgs e)
        {
            if (this.dataListadoDetalle.Rows.Count == 0)
            {
                MensajeError("No hay productos en la lista");
            }else if(txtIdCliente.Text == string.Empty)
            {
                MensajeError("Seleccione un cliente");
            }else if(txtEfectivo.Text.Trim() == string.Empty)
            {
                MensajeError("Ingrese el monto a pagar");
            }
            else
            {
                decimal totalCobrar = Convert.ToDecimal(this.txtTotalPagado.Text);
                decimal totalEfec = Convert.ToDecimal(this.txtEfectivo.Text);
                if(totalEfec < totalCobrar)
                {
                    MensajeError("El monto es insuficiente");
                }else
                {
                    try
                    {
                        string rpta = "";

                        if (this.isNuevo)
                        {
                            string tipoCompr;
                            if(rbBoleta.Checked == true)
                            {
                                tipoCompr = "Boleta";
                            }
                            else
                            {
                                tipoCompr = "Factura";
                            }
                            rpta = NVenta.InsertarPedidoDelivery(Convert.ToInt32(txtIdCliente.Text), null, DateTime.Now, "Pedido Delivery","EFECTIVO", Convert.ToDecimal(this.txtDescuento.Text), 
                                Convert.ToInt32(this.lblIdUsuario.Text), "", 1,tipoCompr,Convert.ToDecimal(this.txtVuelto.Text),"P",dtDetalle, Convert.ToDecimal(this.txtTotalPagado.Text),
                                Convert.ToDecimal(this.txtEfectivo.Text.Trim()),this.lblMesero.Text,Convert.ToDecimal(this.txtDescuento.Text),
                                dtDetalleMenu, DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),"","","","");
                            if (rpta != "")
                            {

                                for (int i = 0; i < this.dataListadoDetalle.Rows.Count; i++)
                                {
                                    if (dataListadoDetalle.Rows[i].Cells["Tipo"].Value.ToString() == "C")
                                    {

                                        DataTable dtDetalleProducto = new DataTable();
                                        dtDetalleProducto = NProducto.mostrarDetalleProducto_Venta(Convert.ToInt32(this.dataListadoDetalle.Rows[i].Cells["Cod"].Value.ToString()));
                                        int cantPedido = Convert.ToInt32(this.dataListadoDetalle.Rows[i].Cells["Cant"].Value.ToString());
                                        for (int j = 0; j < dtDetalleProducto.Rows.Count; j++)
                                        {
                                            int idProducto_Com = Convert.ToInt32(dtDetalleProducto.Rows[j][0].ToString());
                                            int cantRequerida = Convert.ToInt32(dtDetalleProducto.Rows[j][1].ToString());

                                            rpta = NProducto.EditarStock(idProducto_Com, cantRequerida * cantPedido);
                                        }

                                    }

                                    if (dataListadoDetalle.Rows[i].Cells["Imprimir"].Value.ToString() == "Cocina")
                                    {
                                        string producto = dataListadoDetalle.Rows[i].Cells["Descripcion"].Value.ToString();
                                        int cantidad1 = Convert.ToInt32(dataListadoDetalle.Rows[i].Cells["Cant"].Value.ToString());
                                        string nota = dataListadoDetalle.Rows[i].Cells["Nota"].Value.ToString();
                                        string tipo = dataListadoDetalle.Rows[i].Cells["Tipo"].Value.ToString();
                                        dataCocina.Rows.Add(producto, cantidad1, nota,tipo);
                                    }
                                    else if (dataListadoDetalle.Rows[i].Cells["Imprimir"].Value.ToString() == "Bar")
                                    {
                                        string producto = dataListadoDetalle.Rows[i].Cells["Descripcion"].Value.ToString();
                                        int cantidad1 = Convert.ToInt32(dataListadoDetalle.Rows[i].Cells["Cant"].Value.ToString());
                                        string nota = dataListadoDetalle.Rows[i].Cells["Nota"].Value.ToString();
                                        string tipo = dataListadoDetalle.Rows[i].Cells["Tipo"].Value.ToString();
                                        dataBar.Rows.Add(producto, cantidad1, nota,tipo);
                                    }

                                    DataTable dtReceta = NReceta.Mostrar(Convert.ToInt32(dataListadoDetalle.Rows[i].Cells["Cod"].Value.ToString()));

                                    if (dtReceta.Rows.Count > 0)
                                    {
                                        int cantInsumo = Convert.ToInt32(dataListadoDetalle.Rows[i].Cells["Cant"].Value.ToString());
                                        decimal cantTotal;
                                        for (int k = 0; k < dtReceta.Rows.Count; k++)
                                        {
                                            cantTotal = cantInsumo * Convert.ToDecimal(dtReceta.Rows[k][3].ToString());
                                            rpta = NInsumo.EditarStock(Convert.ToInt32(dtReceta.Rows[k][0].ToString()), cantTotal);
                                        }

                                    }
                                }
                                if (dataCocina.Rows.Count > 0)
                                {
                                    //NImprimirComanda.imprimirComDelivery(this.lblMesero.Text, this.lblSalon.Text, this.lblMesa.Text, dataCocina, "");
                                }
                                if (dataBar.Rows.Count > 0)
                                {
                               //     NImprimirComanda.imprimirComDelivery(this.lblMesero.Text, this.lblSalon.Text, this.lblMesa.Text, dataBar, "");
                                }


                            }

                            //rpta = NVenta.InsertarPedido(null, 1,12, DateTime.Now, "Pedido", "", Convert.ToDecimal(this.txtDescuento.Text), dtDetalle);
                        }

                        if (rpta != "")
                        {
                            if (this.isNuevo)
                            {
                                this.MensajeOK("Se insertó correctamente");
                                this.Hide();

                            }
                        }
                        else
                        {
                            this.MensajeError(rpta);
                        }

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message + ex.StackTrace);
                    }
                }

            }
        }

        private void frmDelivery_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgvDetalleMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmDelivery_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private int locProducto = 0;
        public decimal totalPagado = 0, subTotal = 0;
        int cantidadAcumulada = 0;
        public static frmDelivery f1;
        public frmDelivery()
        {
            InitializeComponent();
            frmDelivery.f1 = this;
        }

        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void actualizarProducto()
        {
            if (this.txtCantidad.Text.Equals("0") || (this.txtCantidad.Text.Trim() == string.Empty))
            {
                MessageBox.Show("Ingrese una cantidad mayor a cero");
            }
            else
            {
                decimal descuentoIndividual = 0;
                this.lblBanderaStock.Text = "3";
                int cantidad = Convert.ToInt32(this.txtCantidad.Text.Trim());
                descuentoIndividual = Convert.ToDecimal(this.dataListadoDetalle[4, Convert.ToInt32(this.lblPosicion.Text)].Value);
                decimal subTotal = cantidad * Convert.ToDecimal(this.lblPrecioUnitario.Text);
                decimal descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                decimal importeActual = Convert.ToDecimal(this.lblImporte.Text);
                decimal nuevoDesc = Convert.ToDecimal(lblDescuento.Text) + (Convert.ToDecimal(lblDescuento.Text) / Convert.ToDecimal(lblCantidadCom.Text));
                this.dataListadoDetalle[2, Convert.ToInt32(this.lblPosicion.Text)].Value = this.txtCantidad.Text.Trim();
                this.dataListadoDetalle[4, Convert.ToInt32(this.lblPosicion.Text)].Value = nuevoDesc;
                this.dataListadoDetalle[5, Convert.ToInt32(this.lblPosicion.Text)].Value = subTotal - nuevoDesc;
                /*
                totalPagado = totalPagado + subTotal - importeActual;
                this.txtSubTotal.Text = totalPagado.ToString("#0.00#");
                this.txtTotalPagado.Text = (totalPagado - descuentoTotal).ToString("#0.00#");
                //this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");*/
                decimal dctoTotProm = 0, subTotal20 = 0, total20 = 0;
                int cantidad20 = 0;

                for (int p = 0; p < dataListadoDetalle.Rows.Count; p++)
                {
                    dctoTotProm = dctoTotProm + Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Descuento"].Value.ToString());
                    cantidad20 = Convert.ToInt32(dataListadoDetalle.Rows[p].Cells["Cant"].Value.ToString());
                    subTotal20 = subTotal20 + (cantidad20 * Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Precio_Un"].Value.ToString()));
                }
                this.txtDescuento.Text = dctoTotProm.ToString();
                descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                this.txtSubTotal.Text = subTotal20.ToString("#0.00#");
                this.txtTotalPagado.Text = (subTotal20 - descuentoTotal).ToString("#0.00#");
                //this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");
                //this.txtCantidad.Text = "1";
                this.lblPosicion.Text = string.Empty;
                this.lblBandera.Text = "0";
                this.dataListadoDetalle.ClearSelection();
                this.lblBandera.Focus();
                this.actStockTem();
                this.txtCantidad.Text = "";
                //this.txtCantidad.Text = "1";
            }

        }

        private void btnActualizarCantidad_Click(object sender, EventArgs e)
        {
            if (this.txtCantidad.Text != string.Empty && this.lblBandera.Text.Equals("1"))
            {
                if (this.lblIdVenta.Text != "0")
                {

                }
                else
                {
                    actualizarProducto();
                }

            }
            else
            {
                MessageBox.Show("Seleccione un producto de la lista e ingrese una cantidad válida");
            }
        }
    }
}
