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
    public partial class frmDividirCuenta : Form
    {
        private DataTable dtDetalleD;
        public static frmDividirCuenta f1;
        public frmDividirCuenta()
        {
            InitializeComponent();
            frmDividirCuenta.f1 = this;
        }

        private void Limpiar()
        {
            this.dgSepara1.Rows.Clear();
            this.dgSepara1.Refresh();
        }

        private void Divide()
        {
            if (this.txtNumeroDiv.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese un número de divisiones", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNumeroDiv.Focus();
            }
            else
            {
                int cantidad = Convert.ToInt32(this.txtNumeroDiv.Text.Trim());
                if (cantidad > 6)
                {
                    MessageBox.Show("Se permiten hasta 6 divisiones", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (cantidad == 0)
                {
                    MessageBox.Show("Ingrese una cantidad mayor a cero", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Limpiar();
                    if (this.txtNumeroDiv.Text.Trim() != "")
                    {
                        decimal subTotal = 0, descInd = 0, total = 0, totalR;
                        decimal importeR, descuentoR;
                        int numeroDiv = Convert.ToInt32(this.txtNumeroDiv.Text.Trim());
                        string producto, cantidad1, cod, barra, tipo;
                        decimal descuento, precioVenta, importe;

                        if (this.lblIdVenta.Text == "0")
                        {
                            for (int i = 0; i < frmVenta.f1.dtDetalle.Rows.Count; i++)
                            {
                                cod= frmVenta.f1.dtDetalle.Rows[i][0].ToString();
                                producto = frmVenta.f1.dtDetalle.Rows[i][1].ToString();
                                cantidad1 = frmVenta.f1.dtDetalle.Rows[i][2].ToString();
                                precioVenta = Convert.ToDecimal(frmVenta.f1.dtDetalle.Rows[i][3].ToString());
                                descuento = Convert.ToDecimal(frmVenta.f1.dtDetalle.Rows[i][4].ToString());
                                importe = Convert.ToDecimal(frmVenta.f1.dtDetalle.Rows[i][5].ToString());
                                barra = frmVenta.f1.dtDetalle.Rows[i]["Barra"].ToString();
                                tipo = frmVenta.f1.dtDetalle.Rows[i]["Tipo"].ToString();

                                NRedondeo.setValues(importe / numeroDiv);
                                NRedondeo.redondeo();
                                importeR = NRedondeo.getResultado();

                                NRedondeo.setValues(descuento / numeroDiv);
                                NRedondeo.redondeo();
                                descuentoR = NRedondeo.getResultado();


                                subTotal = subTotal + Convert.ToDecimal(importeR);
                                descInd = descInd + Convert.ToDecimal(descuentoR);
                                total = total + Convert.ToDecimal(importeR) - descuentoR;

                                dgSepara1.Rows.Add(cod,producto, cantidad1, precioVenta, descuentoR, importe, importeR,barra,tipo);
                            }

                            this.lblSubTotal.Text = subTotal.ToString();
                            if (descInd == 0)
                            {
                                this.lblDescuento.Text = "00.00";
                            }
                            else
                            {
                                this.lblDescuento.Text = descInd.ToString();
                            }

                            totalR = NRedondeo.redondearUp(total);
                            decimal redondeo = totalR - total;
                            if (redondeo == 0)
                            {
                                this.lblRedondeo.Text = "00.00";
                            }
                            else
                            {
                                this.lblRedondeo.Text = redondeo.ToString();
                            }

                            this.lblTotal.Text = totalR.ToString();
                        }
                        else
                        {
                            for (int i = 0; i < frmVenta.f1.dtDetalleVenta.Rows.Count; i++)
                            {
                                cod = frmVenta.f1.dtDetalleVenta.Rows[i][0].ToString();
                                producto = frmVenta.f1.dtDetalleVenta.Rows[i][1].ToString();
                                cantidad1 = frmVenta.f1.dtDetalleVenta.Rows[i][2].ToString();
                                precioVenta = Convert.ToDecimal(frmVenta.f1.dtDetalleVenta.Rows[i][3].ToString());
                                descuento = Convert.ToDecimal(frmVenta.f1.dtDetalleVenta.Rows[i][4].ToString());
                                importe = Convert.ToDecimal(frmVenta.f1.dtDetalleVenta.Rows[i][5].ToString());
                                barra = frmVenta.f1.dtDetalleVenta.Rows[i]["Barra"].ToString();
                                tipo = frmVenta.f1.dtDetalleVenta.Rows[i]["Tipo"].ToString();
                                NRedondeo.setValues(importe / numeroDiv);
                                NRedondeo.redondeo();
                                importeR = NRedondeo.getResultado();

                                NRedondeo.setValues(descuento / numeroDiv);
                                NRedondeo.redondeo();
                                descuentoR = NRedondeo.getResultado();

                                descInd = descInd + Convert.ToDecimal(descuentoR);
                                subTotal = subTotal + Convert.ToDecimal(importeR) + descuentoR;
                                total = total + Convert.ToDecimal(importeR);

                                dgSepara1.Rows.Add(cod,producto, cantidad1, precioVenta, descuentoR, importe, importeR,barra,tipo);
                            }


                            this.lblSubTotal.Text = subTotal.ToString();
                            if (descInd == 0)
                            {
                                this.lblDescuento.Text = "00.00";
                            }
                            else
                            {
                                this.lblDescuento.Text = descInd.ToString();
                            }

                            totalR = NRedondeo.redondearUp(total);
                            decimal redondeo = totalR - total;
                            if (redondeo == 0)
                            {
                                this.lblRedondeo.Text = "00.00";
                            }
                            else
                            {
                                this.lblRedondeo.Text = redondeo.ToString();
                            }

                            this.lblTotal.Text = totalR.ToString();

                        }

                    }
                    if (dgSepara1.Rows.Count > 0)
                    {
                        btnPagar.Enabled = true;
                    }
                }

            }
        }
        private void button20_Click(object sender, EventArgs e)
        {
            Divide();

        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("Está seguro de dividir las cuentas?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            string rpta = "";
            if (opcion == DialogResult.OK)
            {
                frmPagarDividida form = new frmPagarDividida();
                if (this.lblIdVenta.Text == "0")
                {

                    /* rpta = NVenta.InsertarPedidoSeparado(null,  Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "Pedido DV", "",
                                                         Convert.ToDecimal(this.lblDescuento.Text), Convert.ToInt32(this.lblIdUsuario.Text), "CS", frmVenta.f1.dtDetalle);
                                                         */
                    rpta = NVenta.InsertarPedidoSeparado(null, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "Pedido DV", "",
                    Convert.ToDecimal(this.lblDescuento.Text), Convert.ToInt32(this.lblIdUsuario.Text), "CD",1, frmVenta.f1.dtDetalle,
                    frmVenta.f1.dtDetalleMenu,DateTime.Now,00.00m, Convert.ToInt32(this.lblIdUsuario.Text),"","","","");
                    if (rpta != "")
                    {
                        for (int i = 0; i < frmVenta.f1.dataListadoDetalle.Rows.Count; i++)
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

                    this.lblIdVenta.Text = rpta;
                }
                else
                {
                    int cont = Convert.ToInt32(frmVenta.f1.lblNroFilas.Text);
                    for (int i =cont; i < frmVenta.f1.dataListadoDetalle.Rows.Count; i++)
                    {
                        int idProducto = Convert.ToInt32(frmVenta.f1.dataListadoDetalle.Rows[i].Cells[0].Value.ToString());
                        int cantidad = Convert.ToInt32(frmVenta.f1.dataListadoDetalle.Rows[i].Cells[2].Value.ToString());
                        decimal prVenta = Convert.ToDecimal(frmVenta.f1.dataListadoDetalle.Rows[i].Cells[3].Value.ToString());
                        decimal desc = Convert.ToDecimal(frmVenta.f1.dataListadoDetalle.Rows[i].Cells[4].Value.ToString());
                        string barra = frmVenta.f1.dataListadoDetalle.Rows[i].Cells["Barra"].Value.ToString();
                        string tipo = frmVenta.f1.dataListadoDetalle.Rows[i].Cells["Tipo"].Value.ToString();
                       
                        rpta = NDetalleVenta.InsertarAdicPedido(Convert.ToInt32(this.lblIdVenta.Text), idProducto, cantidad, prVenta, desc,
                            frmVenta.f1.dataListadoDetalle.Rows[i].Cells[6].Value.ToString(),tipo,barra,frmVenta.f1.dtDetalleMenu,"Pedido");
                        if (rpta == "OK")
                        {
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
                }


                if (this.txtNumeroDiv.Text.Trim().Equals("1"))
                {
                    form.btn1.Enabled = true;
                }
                else if (this.txtNumeroDiv.Text.Trim().Equals("2"))
                {
                    form.btn1.Enabled = true;
                    form.btn2.Enabled = true;
                }
                else if (this.txtNumeroDiv.Text.Trim().Equals("3"))
                {
                    form.btn1.Enabled = true;
                    form.btn2.Enabled = true;
                    form.btn3.Enabled = true;
                }
                else if (this.txtNumeroDiv.Text.Trim().Equals("4"))
                {
                    form.btn1.Enabled = true;
                    form.btn2.Enabled = true;
                    form.btn3.Enabled = true;
                    form.btn4.Enabled = true;
                }
                else if (this.txtNumeroDiv.Text.Trim().Equals("5"))
                {
                    form.btn1.Enabled = true;
                    form.btn2.Enabled = true;
                    form.btn3.Enabled = true;
                    form.btn4.Enabled = true;
                    form.btn5.Enabled = true;
                }
                else if (this.txtNumeroDiv.Text.Trim().Equals("6"))
                {
                    form.btn1.Enabled = true;
                    form.btn2.Enabled = true;
                    form.btn3.Enabled = true;
                    form.btn4.Enabled = true;
                    form.btn5.Enabled = true;
                    form.btn6.Enabled = true;
                }

                form.lblIdMesa.Text = this.lblIdMesa.Text;
                form.lblIdVenta.Text = this.lblIdVenta.Text;
                form.lblIdTrabajador.Text = this.lblIdTrabajador.Text;
                form.lblRedondeo.Text = this.lblRedondeo.Text;
                form.lblIdUsuario.Text = this.lblIdUsuario.Text;
                /*
                descuento = Convert.ToDecimal(this.lblDescuento_Ind.Text);
                form.lblDescuento.Text = this.lblDescuento_Ind.Text;
                total = suma - descuento;
                form.lblTotal.Text = total.ToString();*/
                form.Show();
            }
        }

        private void txtNumeroDiv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

            if ((int)e.KeyChar == (int)Keys.Enter && this.txtNumeroDiv.Text != string.Empty)
            {
                Divide();
            }
        }

        private void frmDividirCuenta_Load(object sender, EventArgs e)
        {
            this.txtNumeroDiv.Focus();
            
            this.dgSepara1.ColumnHeadersDefaultCellStyle.Font = new Font(dgSepara1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dgSepara1.GridColor = SystemColors.ActiveBorder;
            this.dgSepara1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dgSepara1.Font = new Font("Robot", 10);
            this.dgSepara1.GridColor = SystemColors.ActiveBorder;
            this.dgSepara1.ClearSelection();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
