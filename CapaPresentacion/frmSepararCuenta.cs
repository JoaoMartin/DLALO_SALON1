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
    public partial class frmSepararCuenta : Form
    {
        public DataTable dtDetalle,dtDetalle2,dtDetalle3,dtDetalle4,dtDetalle5,dtDetalle6;
        private DataTable dtDetalleCuenta;
        private DataTable dtCuenta, dtDetallePorPagar;
        public DataRow row1, row2, row3, row4, row5, row6;
        public decimal suma = 0, totalDescuento=0;
        public static frmSepararCuenta f1;


        private void button2_Click(object sender, EventArgs e)
        {
            if (this.lblBandera.Text.Equals("1"))
            {

                int indiceFila = this.dataListado.CurrentRow.Index;
                DataRow row = this.dtDetalleCuenta.Rows[indiceFila];

                row2 = this.dtDetalle2.NewRow();

                row2["Cod"] = Convert.ToInt32(this.lblCod.Text);
                row2["Descripcion"] = this.lblDesc.Text;
                row2["Cant"] = Convert.ToInt32(this.lblCant.Text);
                row2["Precio_Un"] = Convert.ToDecimal(this.lblPrecio.Text);
                row2["Importe"] = Convert.ToDecimal(this.lblImporte.Text);
                row2["Descuento"] = Convert.ToDecimal(this.lblDescuento.Text);
                row2["Nota"] = this.lblNota.Text;
                row2["idDetalleVenta"] = this.lblIdDetalle.Text;
                row2["Barra"] = "1";
                row2["Tipo"] = lblTipo.Text;
                row2["Estado"] = "Pedido";
                this.dtDetalle2.Rows.Add(row2);
    
                // this.dgCuenta1.Rows.Add(this.dtDetalleCuenta.Rows[indiceFila]);
                this.dtDetalleCuenta.Rows.Remove(row);
                this.dataListado.DataSource = dtDetalleCuenta;
          
                this.dataListado.ClearSelection();
                this.lblBandera.Text = "0";
                this.dgCuenta2.ClearSelection();

                for (int i = 0; i < dgCuenta2.Rows.Count; i++)
                {
                    suma = suma + Convert.ToDecimal(dgCuenta2.Rows[i].Cells[5].Value);
                    totalDescuento = totalDescuento + Convert.ToDecimal(dgCuenta2.Rows[i].Cells[4].Value);
                }

                this.lblTotalC2.Text = suma.ToString();
                this.tdC2.Text = totalDescuento.ToString();
                suma = 00.00m;
                totalDescuento = 00.00m;
                this.HabilitarPago();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.lblBandera.Text.Equals("1"))
            {

                int indiceFila = this.dataListado.CurrentRow.Index;
                DataRow row = this.dtDetalleCuenta.Rows[indiceFila];

                row3 = this.dtDetalle3.NewRow();

                row3["Cod"] = Convert.ToInt32(this.lblCod.Text);
                row3["Descripcion"] = this.lblDesc.Text;
                row3["Cant"] = Convert.ToInt32(this.lblCant.Text);
                row3["Precio_Un"] = Convert.ToDecimal(this.lblPrecio.Text);
                row3["Importe"] = Convert.ToDecimal(this.lblImporte.Text);
                row3["Descuento"] = Convert.ToDecimal(this.lblDescuento.Text);
                row3["Nota"] = this.lblNota.Text;
                row3["idDetalleVenta"] = this.lblIdDetalle.Text;
                row3["Barra"] = "1";
                row3["Tipo"] = lblTipo.Text;
                row3["Estado"] = "Pedido";
                this.dtDetalle3.Rows.Add(row3);

                // this.dgCuenta1.Rows.Add(this.dtDetalleCuenta.Rows[indiceFila]);
                this.dtDetalleCuenta.Rows.Remove(row);
                this.dataListado.DataSource = dtDetalleCuenta;
                this.dataListado.ClearSelection();
                this.lblBandera.Text = "0";
                this.dgCuenta3.ClearSelection();

                for (int i = 0; i < dgCuenta3.Rows.Count; i++)
                {
                    suma = suma + Convert.ToDecimal(dgCuenta3.Rows[i].Cells[5].Value);
                    totalDescuento = totalDescuento + Convert.ToDecimal(dgCuenta3.Rows[i].Cells[4].Value);
                }

                this.lblTotalC3.Text = suma.ToString();
                this.tdC3.Text = totalDescuento.ToString();
                suma = 00.00m;
                totalDescuento = 00.00m;
                this.HabilitarPago();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.lblBandera.Text.Equals("1"))
            {

                int indiceFila = this.dataListado.CurrentRow.Index;
                DataRow row = this.dtDetalleCuenta.Rows[indiceFila];

                row4 = this.dtDetalle4.NewRow();

                row4["Cod"] = Convert.ToInt32(this.lblCod.Text);
                row4["Descripcion"] = this.lblDesc.Text;
                row4["Cant"] = Convert.ToInt32(this.lblCant.Text);
                row4["Precio_Un"] = Convert.ToDecimal(this.lblPrecio.Text);
                row4["Importe"] = Convert.ToDecimal(this.lblImporte.Text);
                row4["Descuento"] = Convert.ToDecimal(this.lblDescuento.Text);
                row4["Nota"] = this.lblNota.Text;
                row4["idDetalleVenta"] = this.lblIdDetalle.Text;
                row4["Barra"] = "1";
                row4["Tipo"] = lblTipo.Text;
                row4["Estado"] = "Pedido";
                this.dtDetalle4.Rows.Add(row4);
       
                // this.dgCuenta1.Rows.Add(this.dtDetalleCuenta.Rows[indiceFila]);
                this.dtDetalleCuenta.Rows.Remove(row);
                this.dataListado.DataSource = dtDetalleCuenta;
                this.dataListado.ClearSelection();
                this.lblBandera.Text = "0";
                this.dgCuenta4.ClearSelection();

                for (int i = 0; i < dgCuenta4.Rows.Count; i++)
                {
                    suma = suma + Convert.ToDecimal(dgCuenta4.Rows[i].Cells[5].Value);
                    totalDescuento = totalDescuento + Convert.ToDecimal(dgCuenta4.Rows[i].Cells[4].Value);
                }

                this.lblTotalC4.Text = suma.ToString();
                this.tdC4.Text = totalDescuento.ToString();
                suma = 00.00m;
                totalDescuento = 00.00m;
                this.HabilitarPago();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.lblBandera.Text.Equals("1"))
            {

                int indiceFila = this.dataListado.CurrentRow.Index;
                DataRow row = this.dtDetalleCuenta.Rows[indiceFila];

                row5 = this.dtDetalle5.NewRow();

                row5["Cod"] = Convert.ToInt32(this.lblCod.Text);
                row5["Descripcion"] = this.lblDesc.Text;
                row5["Cant"] = Convert.ToInt32(this.lblCant.Text);
                row5["Precio_Un"] = Convert.ToDecimal(this.lblPrecio.Text);
                row5["Importe"] = Convert.ToDecimal(this.lblImporte.Text);
                row5["Descuento"] = Convert.ToDecimal(this.lblDescuento.Text);
                row5["Nota"] = this.lblNota.Text;
                row5["idDetalleVenta"] = this.lblIdDetalle.Text;
                row5["Barra"] = "1";
                row5["Tipo"] = lblTipo.Text;
                row5["Estado"] = "Pedido";
                this.dtDetalle5.Rows.Add(row5);

                // this.dgCuenta1.Rows.Add(this.dtDetalleCuenta.Rows[indiceFila]);
                this.dtDetalleCuenta.Rows.Remove(row);
                this.dataListado.DataSource = dtDetalleCuenta;
                this.dataListado.ClearSelection();
                this.lblBandera.Text = "0";
                this.dgCuenta5.ClearSelection();

                for (int i = 0; i < dgCuenta5.Rows.Count; i++)
                {
                    suma = suma + Convert.ToDecimal(dgCuenta5.Rows[i].Cells[5].Value);
                    totalDescuento = totalDescuento + Convert.ToDecimal(dgCuenta5.Rows[i].Cells[4].Value);
                }

                this.lblTotalC5.Text = suma.ToString();
                this.tdC5.Text = totalDescuento.ToString();
                suma = 00.00m;
                totalDescuento = 00.00m;
                this.HabilitarPago();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (this.lblBandera.Text.Equals("1"))
            {

                int indiceFila = this.dgCuenta1.CurrentRow.Index;
                DataRow row = this.dtDetalle.Rows[indiceFila];


                row1 = this.dtDetalleCuenta.NewRow();

                row1["Cod"] = Convert.ToInt32(this.lblCod.Text);
                row1["Descripcion"] = this.lblDesc.Text;
                row1["Cant"] = Convert.ToInt32(this.lblCant.Text);
                row1["Precio_Un"] = Convert.ToDecimal(this.lblPrecio.Text);
                row1["Importe"] = Convert.ToDecimal(this.lblImporte.Text);
                row1["Descuento"] = Convert.ToDecimal(this.lblDescuento.Text);
                row1["Nota"] = this.lblNota.Text;
                //row1["idDetalleVenta"] = this.lblIdDetalle.Text;
                this.dtDetalleCuenta.Rows.Add(row1);

                // this.dgCuenta1.Rows.Add(this.dtDetalleCuenta.Rows[indiceFila]);
                this.dtDetalle.Rows.Remove(row);
                this.dataListado.DataSource = dtDetalleCuenta;
                this.dataListado.ClearSelection();
                this.lblBandera.Text = "0";
                this.dgCuenta1.ClearSelection();

                for (int i = 0; i < dgCuenta1.Rows.Count; i++)
                {
                    suma = suma + Convert.ToDecimal(dgCuenta1.Rows[i].Cells[5].Value);
                    totalDescuento = totalDescuento + Convert.ToDecimal(dgCuenta1.Rows[i].Cells[4].Value);
                }

                this.lblTotalC1.Text = suma.ToString();
                this.tdC1.Text = totalDescuento.ToString();
                suma = 00.00m;
                totalDescuento = 00.00m;
                this.HabilitarPago();
            }
        }

        private void dgCuenta1_Click(object sender, EventArgs e)
        {
            if (dgCuenta1.Rows.Count > 0)
            {
                this.lblCod.Text = Convert.ToString(this.dgCuenta1.CurrentRow.Cells["Cod"].Value);
                this.lblCant.Text = Convert.ToString(this.dgCuenta1.CurrentRow.Cells["Cant"].Value);
                this.lblDesc.Text = Convert.ToString(this.dgCuenta1.CurrentRow.Cells["Descripcion"].Value);
                this.lblPrecio.Text = Convert.ToString(this.dgCuenta1.CurrentRow.Cells["Precio_Un"].Value);
                this.lblImporte.Text = Convert.ToString(this.dgCuenta1.CurrentRow.Cells["Importe"].Value);
                this.lblDescuento.Text = Convert.ToString(this.dgCuenta1.CurrentRow.Cells["Descuento"].Value);
                this.lblBandera.Text = "1";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (this.lblBandera.Text.Equals("1"))
            {

                int indiceFila = this.dgCuenta2.CurrentRow.Index;
                DataRow row = this.dtDetalle2.Rows[indiceFila];


                row2 = this.dtDetalleCuenta.NewRow();

                row2["Cod"] = Convert.ToInt32(this.lblCod.Text);
                row2["Descripcion"] = this.lblDesc.Text;
                row2["Cant"] = Convert.ToInt32(this.lblCant.Text);
                row2["Precio_Un"] = Convert.ToDecimal(this.lblPrecio.Text);
                row2["Importe"] = Convert.ToDecimal(this.lblImporte.Text);
                row2["Descuento"] = Convert.ToDecimal(this.lblDescuento.Text);
                row2["Nota"] = this.lblNota.Text;
                //row2["idDetalleVenta"] = this.lblIdDetalle.Text;
                this.dtDetalleCuenta.Rows.Add(row2);

                // this.dgCuenta1.Rows.Add(this.dtDetalleCuenta.Rows[indiceFila]);
                this.dtDetalle2.Rows.Remove(row);
                this.dataListado.DataSource = dtDetalleCuenta;
                this.dataListado.ClearSelection();
                this.lblBandera.Text = "0";
                this.dgCuenta2.ClearSelection();

                for (int i = 0; i < dgCuenta2.Rows.Count; i++)
                {
                    suma = suma + Convert.ToDecimal(dgCuenta2.Rows[i].Cells[5].Value);
                    totalDescuento = totalDescuento + Convert.ToDecimal(dgCuenta2.Rows[i].Cells[4].Value);
                }

                this.lblTotalC2.Text = suma.ToString();
                this.tdC2.Text = totalDescuento.ToString();
                suma = 00.00m;
                totalDescuento = 00.00m;
                this.HabilitarPago();
            }
        }

        private void dgCuenta2_Click(object sender, EventArgs e)
        {
            if (dgCuenta2.Rows.Count > 0)
            {
                this.lblCod.Text = Convert.ToString(this.dgCuenta2.CurrentRow.Cells["Cod"].Value);
                this.lblCant.Text = Convert.ToString(this.dgCuenta2.CurrentRow.Cells["Cant"].Value);
                this.lblDesc.Text = Convert.ToString(this.dgCuenta2.CurrentRow.Cells["Descripcion"].Value);
                this.lblPrecio.Text = Convert.ToString(this.dgCuenta2.CurrentRow.Cells["Precio_Un"].Value);
                this.lblImporte.Text = Convert.ToString(this.dgCuenta2.CurrentRow.Cells["Importe"].Value);
                this.lblDescuento.Text = Convert.ToString(this.dgCuenta2.CurrentRow.Cells["Descuento"].Value);
                this.lblBandera.Text = "1";
            }
        }

        private void dgCuenta3_Click(object sender, EventArgs e)
        {
            if (dgCuenta3.Rows.Count > 0)
            {
                this.lblCod.Text = Convert.ToString(this.dgCuenta3.CurrentRow.Cells["Cod"].Value);
                this.lblCant.Text = Convert.ToString(this.dgCuenta3.CurrentRow.Cells["Cant"].Value);
                this.lblDesc.Text = Convert.ToString(this.dgCuenta3.CurrentRow.Cells["Descripcion"].Value);
                this.lblPrecio.Text = Convert.ToString(this.dgCuenta3.CurrentRow.Cells["Precio_Un"].Value);
                this.lblImporte.Text = Convert.ToString(this.dgCuenta3.CurrentRow.Cells["Importe"].Value);
                this.lblDescuento.Text = Convert.ToString(this.dgCuenta3.CurrentRow.Cells["Descuento"].Value);
                this.lblBandera.Text = "1";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (this.lblBandera.Text.Equals("1"))
            {

                int indiceFila = this.dgCuenta3.CurrentRow.Index;
                DataRow row = this.dtDetalle3.Rows[indiceFila];


                row3 = this.dtDetalleCuenta.NewRow();

                row3["Cod"] = Convert.ToInt32(this.lblCod.Text);
                row3["Descripcion"] = this.lblDesc.Text;
                row3["Cant"] = Convert.ToInt32(this.lblCant.Text);
                row3["Precio_Un"] = Convert.ToDecimal(this.lblPrecio.Text);
                row3["Importe"] = Convert.ToDecimal(this.lblImporte.Text);
                row3["Descuento"] = Convert.ToDecimal(this.lblDescuento.Text);
                row3["Nota"] = this.lblNota.Text;
                //row3["idDetalleVenta"] = this.lblIdDetalle.Text;
                this.dtDetalleCuenta.Rows.Add(row3);

                // this.dgCuenta1.Rows.Add(this.dtDetalleCuenta.Rows[indiceFila]);
                this.dtDetalle3.Rows.Remove(row);
                this.dataListado.DataSource = dtDetalleCuenta;
                this.dataListado.ClearSelection();
                this.lblBandera.Text = "0";
                this.dgCuenta3.ClearSelection();

                for (int i = 0; i < dgCuenta3.Rows.Count; i++)
                {
                    suma = suma + Convert.ToDecimal(dgCuenta3.Rows[i].Cells[5].Value);
                    totalDescuento = totalDescuento + Convert.ToDecimal(dgCuenta3.Rows[i].Cells[4].Value);
                }

                this.lblTotalC3.Text = suma.ToString();
                this.tdC3.Text = totalDescuento.ToString();
                suma = 00.00m;
                totalDescuento = 00.00m;
                this.HabilitarPago();
            }
        }

        private void dgCuenta4_Click(object sender, EventArgs e)
        {
            if (dgCuenta4.Rows.Count > 0)
            {
                this.lblCod.Text = Convert.ToString(this.dgCuenta4.CurrentRow.Cells["Cod"].Value);
                this.lblCant.Text = Convert.ToString(this.dgCuenta4.CurrentRow.Cells["Cant"].Value);
                this.lblDesc.Text = Convert.ToString(this.dgCuenta4.CurrentRow.Cells["Descripcion"].Value);
                this.lblPrecio.Text = Convert.ToString(this.dgCuenta4.CurrentRow.Cells["Precio_Un"].Value);
                this.lblImporte.Text = Convert.ToString(this.dgCuenta4.CurrentRow.Cells["Importe"].Value);
                this.lblDescuento.Text = Convert.ToString(this.dgCuenta4.CurrentRow.Cells["Descuento"].Value);
                this.lblBandera.Text = "1";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (this.lblBandera.Text.Equals("1"))
            {

                int indiceFila = this.dgCuenta4.CurrentRow.Index;
                DataRow row = this.dtDetalle4.Rows[indiceFila];


                row4 = this.dtDetalleCuenta.NewRow();

                row4["Cod"] = Convert.ToInt32(this.lblCod.Text);
                row4["Descripcion"] = this.lblDesc.Text;
                row4["Cant"] = Convert.ToInt32(this.lblCant.Text);
                row4["Precio_Un"] = Convert.ToDecimal(this.lblPrecio.Text);
                row4["Importe"] = Convert.ToDecimal(this.lblImporte.Text);
                row4["Descuento"] = Convert.ToDecimal(this.lblDescuento.Text);
                row4["Nota"] = this.lblNota.Text;
               // row4["idDetalleVenta"] = this.lblIdDetalle.Text;
                this.dtDetalleCuenta.Rows.Add(row4);

                // this.dgCuenta1.Rows.Add(this.dtDetalleCuenta.Rows[indiceFila]);
                this.dtDetalle4.Rows.Remove(row);
                this.dataListado.DataSource = dtDetalleCuenta;
                this.dataListado.ClearSelection();
                this.lblBandera.Text = "0";
                this.dgCuenta4.ClearSelection();

                for (int i = 0; i < dgCuenta4.Rows.Count; i++)
                {
                    suma = suma + Convert.ToDecimal(dgCuenta4.Rows[i].Cells[5].Value);
                    totalDescuento = totalDescuento + Convert.ToDecimal(dgCuenta4.Rows[i].Cells[4].Value);
                }

                this.lblTotalC4.Text = suma.ToString();
                this.tdC4.Text = totalDescuento.ToString();
                suma = 00.00m;
                totalDescuento = 00.00m;
                this.HabilitarPago();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (this.lblBandera.Text.Equals("1"))
            {

                int indiceFila = this.dgCuenta5.CurrentRow.Index;
                DataRow row = this.dtDetalle5.Rows[indiceFila];


                row5 = this.dtDetalleCuenta.NewRow();

                row5["Cod"] = Convert.ToInt32(this.lblCod.Text);
                row5["Descripcion"] = this.lblDesc.Text;
                row5["Cant"] = Convert.ToInt32(this.lblCant.Text);
                row5["Precio_Un"] = Convert.ToDecimal(this.lblPrecio.Text);
                row5["Importe"] = Convert.ToDecimal(this.lblImporte.Text);
                row5["Descuento"] = Convert.ToDecimal(this.lblDescuento.Text);
                row5["Nota"] = this.lblNota.Text;
               // row5["idDetalleVenta"] = this.lblIdDetalle.Text;
                this.dtDetalleCuenta.Rows.Add(row5);

                // this.dgCuenta1.Rows.Add(this.dtDetalleCuenta.Rows[indiceFila]);
                this.dtDetalle5.Rows.Remove(row);
                this.dataListado.DataSource = dtDetalleCuenta;
                this.dataListado.ClearSelection();
                this.lblBandera.Text = "0";
                this.dgCuenta5.ClearSelection();

                for (int i = 0; i < dgCuenta5.Rows.Count; i++)
                {
                    suma = suma + Convert.ToDecimal(dgCuenta5.Rows[i].Cells[5].Value);
                    totalDescuento = totalDescuento + Convert.ToDecimal(dgCuenta5.Rows[i].Cells[4].Value);
                }

                this.lblTotalC5.Text = suma.ToString();
                this.tdC5.Text = totalDescuento.ToString();
                suma = 00.00m;
                totalDescuento = 00.00m;
                this.HabilitarPago();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (this.lblBandera.Text.Equals("1"))
            {

                int indiceFila = this.dgCuenta6.CurrentRow.Index;
                DataRow row = this.dtDetalle6.Rows[indiceFila];


                row6 = this.dtDetalleCuenta.NewRow();

                row6["Cod"] = Convert.ToInt32(this.lblCod.Text);
                row6["Descripcion"] = this.lblDesc.Text;
                row6["Cant"] = Convert.ToInt32(this.lblCant.Text);
                row6["Precio_Un"] = Convert.ToDecimal(this.lblPrecio.Text);
                row6["Importe"] = Convert.ToDecimal(this.lblImporte.Text);
                row6["Descuento"] = Convert.ToDecimal(this.lblDescuento.Text);
                row6["Nota"] = this.lblNota.Text;
                //row6["idDetalleVenta"] = this.lblIdDetalle.Text;

                this.dtDetalleCuenta.Rows.Add(row6);

                // this.dgCuenta1.Rows.Add(this.dtDetalleCuenta.Rows[indiceFila]);
                this.dtDetalle6.Rows.Remove(row);
                this.dataListado.DataSource = dtDetalleCuenta;
                this.dataListado.ClearSelection();
                this.lblBandera.Text = "0";
                this.dgCuenta6.ClearSelection();

                for (int i = 0; i < dgCuenta6.Rows.Count; i++)
                {
                    suma = suma + Convert.ToDecimal(dgCuenta6.Rows[i].Cells[5].Value);
                    totalDescuento = totalDescuento + Convert.ToDecimal(dgCuenta6.Rows[i].Cells[4].Value);
                }

                this.lblTotalC6.Text = suma.ToString();
                this.tdC6.Text = totalDescuento.ToString();
                suma = 00.00m;
                totalDescuento = 00.00m;
                this.HabilitarPago();
            }
        }

        private void dgCuenta5_Click(object sender, EventArgs e)
        {
            if (dgCuenta5.Rows.Count > 0)
            {
                this.lblCod.Text = Convert.ToString(this.dgCuenta5.CurrentRow.Cells["Cod"].Value);
                this.lblCant.Text = Convert.ToString(this.dgCuenta5.CurrentRow.Cells["Cant"].Value);
                this.lblDesc.Text = Convert.ToString(this.dgCuenta5.CurrentRow.Cells["Descripcion"].Value);
                this.lblPrecio.Text = Convert.ToString(this.dgCuenta5.CurrentRow.Cells["Precio_Un"].Value);
                this.lblImporte.Text = Convert.ToString(this.dgCuenta5.CurrentRow.Cells["Importe"].Value);
                this.lblDescuento.Text = Convert.ToString(this.dgCuenta5.CurrentRow.Cells["Descuento"].Value);
                this.lblBandera.Text = "1";
            }
        }

        private void dgCuenta6_Click(object sender, EventArgs e)
        {
            if (dgCuenta6.Rows.Count > 0)
            {
                this.lblCod.Text = Convert.ToString(this.dgCuenta6.CurrentRow.Cells["Cod"].Value);
                this.lblCant.Text = Convert.ToString(this.dgCuenta6.CurrentRow.Cells["Cant"].Value);
                this.lblDesc.Text = Convert.ToString(this.dgCuenta6.CurrentRow.Cells["Descripcion"].Value);
                this.lblPrecio.Text = Convert.ToString(this.dgCuenta6.CurrentRow.Cells["Precio_Un"].Value);
                this.lblImporte.Text = Convert.ToString(this.dgCuenta6.CurrentRow.Cells["Importe"].Value);
                this.lblDescuento.Text = Convert.ToString(this.dgCuenta6.CurrentRow.Cells["Descuento"].Value);
                this.lblBandera.Text = "1";
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            decimal suma = 0;
            frmPagarSeparada form = new frmPagarSeparada();
            if (dgCuenta1.Rows.Count > 0)
            {
                form.btn1.Enabled = true;
            }
            if (dgCuenta2.Rows.Count > 0)
            {
                form.btn2.Enabled = true;
            }
            if (dgCuenta3.Rows.Count > 0)
            {
                form.btn3.Enabled = true;
            }
            if (dgCuenta4.Rows.Count > 0)
            {
                form.btn4.Enabled = true;
            }
             if (dgCuenta5.Rows.Count > 0)
            {
                form.btn5.Enabled = true;
            }
            if (dgCuenta6.Rows.Count > 0)
            {
                form.btn6.Enabled = true;
            }/*
            suma = Convert.ToDecimal(this.lblTotalC1.Text) + Convert.ToDecimal(this.lblTotalC2.Text) + Convert.ToDecimal(this.lblTotalC3.Text)
                + Convert.ToDecimal(this.lblTotalC4.Text) + Convert.ToDecimal(this.lblTotalC5.Text) + Convert.ToDecimal(this.lblTotalC6.Text);*/
            form.lblIdMesa.Text = this.lblIdMesa.Text;
            form.lblIdVenta.Text = this.lblIdVenta.Text;
            form.lblIdTrabajador.Text = this.lblIdTrabajador.Text;
            form.lblSubTotal.Text = suma.ToString();
            form.lblIdUsuario.Text = this.lblIdUsuario.Text;
            /*
            descuento = Convert.ToDecimal(this.lblDescuento_Ind.Text);
            form.lblDescuento.Text = this.lblDescuento_Ind.Text;
            total = suma - descuento;
            form.lblTotal.Text = total.ToString();*/
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.lblBandera.Text.Equals("1"))
            {

                int indiceFila = this.dataListado.CurrentRow.Index;
                DataRow row = this.dtDetalleCuenta.Rows[indiceFila];

                row6 = this.dtDetalle6.NewRow();

                row6["Cod"] = Convert.ToInt32(this.lblCod.Text);
                row6["Descripcion"] = this.lblDesc.Text;
                row6["Cant"] = Convert.ToInt32(this.lblCant.Text);
                row6["Precio_Un"] = Convert.ToDecimal(this.lblPrecio.Text);
                row6["Importe"] = Convert.ToDecimal(this.lblImporte.Text);
                row6["Descuento"] = Convert.ToDecimal(this.lblDescuento.Text);
                row6["Nota"] = this.lblNota.Text;
                row6["idDetalleVenta"] = this.lblIdDetalle.Text;
                row6["Barra"] = "1";
                row6["Tipo"] = lblTipo.Text;
                row6["Estado"] = "Pedido";
                this.dtDetalle6.Rows.Add(row6);

                // this.dgCuenta1.Rows.Add(this.dtDetalleCuenta.Rows[indiceFila]);
                this.dtDetalleCuenta.Rows.Remove(row);
                this.dataListado.DataSource = dtDetalleCuenta;
                this.dataListado.ClearSelection();
                this.lblBandera.Text = "0";
                this.dgCuenta6.ClearSelection();

                for (int i = 0; i < dgCuenta6.Rows.Count; i++)
                {
                    suma = suma + Convert.ToDecimal(dgCuenta6.Rows[i].Cells[5].Value);
                    totalDescuento = totalDescuento + Convert.ToDecimal(dgCuenta6.Rows[i].Cells[4].Value);
                }

                this.lblTotalC6.Text = suma.ToString();
                this.tdC6.Text = totalDescuento.ToString();
                suma = 00.00m;
                totalDescuento = 00.00m;
                this.HabilitarPago();
            }
        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            frmModuloSalon.f3.limpiarMesas();
            frmModuloSalon.f3.mostrarSalones();
            this.Hide();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            

        }

        public frmSepararCuenta()
        {
            InitializeComponent();
            frmSepararCuenta.f1 = this;
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void mostrarDetalleVenta()
        {
            this.dataListado.DataSource = NVenta.mostrarDetalleVenta_SepararCuenta(Convert.ToInt32(frmVenta.f1.lblIdVenta.Text));
            this.dtDetalleCuenta = NVenta.mostrarDetalleVenta_SepararCuenta(Convert.ToInt32(frmVenta.f1.lblIdVenta.Text));
            this.formatoTabla();
        }

        public void mostrarDetalleVentaPorPedir(string codigo)
        {/*
            this.dtDetallePorPagar = frmVenta.f1.dtDetalle;
            this.dataListado.DataSource = this.dtDetallePorPagar;
            this.dtDetalleCuenta = this.dtDetallePorPagar;
            this.dtCuenta = dtDetalleCuenta;
            this.formatoTabla();
            */
            this.dataListado.DataSource = NVenta.mostrarDetalleVenta_SepararCuenta(Convert.ToInt32(codigo));
            this.dtDetalleCuenta = NVenta.mostrarDetalleVenta_SepararCuenta(Convert.ToInt32(codigo));
            this.formatoTabla();
            /*
            this.dataListado.DataSource = frmVenta.f1.dtDetalle;
            this.dtDetalleCuenta = frmVenta.f1.dtDetalle;
            this.formatoTabla();
            */
        }

        private void formatoTabla()
        {

            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[4].Visible = false;
            this.dataListado.Columns[6].Visible = false;
            this.dataListado.Columns[7].Visible = false;
            this.dataListado.Columns[8].Visible = false;
            this.dataListado.Columns[9].Visible = false;
            //this.dataListado.Columns[6].Visible = false;
            //this.dataListadoDetalle.Columns[7].Visible = false;
            // DataGridView1.Columns(1).Width = 150
            //this.dataListadoDetalle.Columns[0].Width = 50;
            this.dataListado.Columns[1].Width = 200;
            this.dataListado.Columns[2].Width = 35;
            this.dataListado.Columns[3].Width = 65;
            this.dataListado.Columns[5].Width = 65;

            

            this.dataListado.RowTemplate.Height = 33;
            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListado.Font = new Font("Roboto", 8);
            this.dataListado.GridColor = SystemColors.ActiveBorder;
        }

        private void HabilitarPago()
        {
            if (dtDetalleCuenta.Rows.Count > 0)
            {
                this.btnPagar.Enabled = false;
            }
            else
            {
                this.btnPagar.Enabled = true;
            }
        }

        private void frmSepararCuenta_Load(object sender, EventArgs e)
        {/*
            if(this.lblIdVenta.Text == "0")
            {
                mostrarDetalleVentaPorPedir(this.lblIdVenta.Text);
            }
            else
            {
                mostrarDetalleVenta();
            }
            */
            //mostrarDetalleVentaPorPedir(this.lblIdVenta.Text);
            //mostrarDetalleVentaPorPedir();
            crearTabla();
            this.HabilitarPago();
            this.formatoTabla();
            this.Formato();
        }

        private void Formato()
        { 
           // this.dgCuenta1.Columns[0].Visible = false;
            this.dgCuenta1.ClearSelection();
            this.dgCuenta1.ColumnHeadersDefaultCellStyle.Font = new Font(dgCuenta1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dgCuenta1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dgCuenta1.Font = new Font("Roboto", 7);
            this.dgCuenta1.GridColor = SystemColors.ActiveBorder;

            this.dgCuenta1.Columns[1].Width = 170;
            this.dgCuenta1.Columns[2].Width = 45;
            this.dgCuenta1.Columns[3].Width = 45;
            this.dgCuenta1.Columns[4].Width = 70;
            this.dgCuenta1.Columns[5].Visible = false;
            this.dgCuenta1.Columns[6].Visible = false;
            this.dgCuenta1.Columns[7].Visible = false;

            //2
            this.dgCuenta2.Columns[0].Visible = false;
            this.dgCuenta2.ClearSelection();
            this.dgCuenta2.ColumnHeadersDefaultCellStyle.Font = new Font(dgCuenta2.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dgCuenta2.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dgCuenta2.Font = new Font("Roboto", 8);
            this.dgCuenta2.GridColor = SystemColors.ActiveBorder;

            this.dgCuenta2.Columns[1].Width = 200;
            this.dgCuenta2.Columns[2].Width = 60;
            this.dgCuenta2.Columns[3].Width = 60;
            this.dgCuenta2.Columns[4].Width = 80;
            this.dgCuenta2.Columns[5].Width = 80;
            this.dgCuenta2.Columns[6].Visible = false;
            this.dgCuenta2.Columns[7].Visible = false;

            //3
            this.dgCuenta3.Columns[0].Visible = false;
            this.dgCuenta3.ClearSelection();
            this.dgCuenta3.ColumnHeadersDefaultCellStyle.Font = new Font(dgCuenta3.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dgCuenta3.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dgCuenta3.Font = new Font("Roboto", 8);
            this.dgCuenta3.GridColor = SystemColors.ActiveBorder;

            this.dgCuenta3.Columns[1].Width = 200;
            this.dgCuenta3.Columns[2].Width = 60;
            this.dgCuenta3.Columns[3].Width = 60;
            this.dgCuenta3.Columns[4].Width = 80;
            this.dgCuenta3.Columns[5].Width = 80;
            this.dgCuenta3.Columns[6].Visible = false;
            this.dgCuenta3.Columns[7].Visible = false;

            //4
            this.dgCuenta4.Columns[0].Visible = false;
            this.dgCuenta4.ClearSelection();
            this.dgCuenta4.ColumnHeadersDefaultCellStyle.Font = new Font(dgCuenta4.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dgCuenta4.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dgCuenta4.Font = new Font("Roboto", 8);
            this.dgCuenta4.GridColor = SystemColors.ActiveBorder;

            this.dgCuenta4.Columns[1].Width = 200;
            this.dgCuenta4.Columns[2].Width = 60;
            this.dgCuenta4.Columns[3].Width = 60;
            this.dgCuenta4.Columns[4].Width = 80;
            this.dgCuenta4.Columns[5].Width = 80;
            this.dgCuenta4.Columns[6].Visible = false;
            this.dgCuenta4.Columns[7].Visible = false;

            //5
            this.dgCuenta5.Columns[0].Visible = false;
            this.dgCuenta5.ClearSelection();
            this.dgCuenta5.ColumnHeadersDefaultCellStyle.Font = new Font(dgCuenta5.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dgCuenta5.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dgCuenta5.Font = new Font("Roboto", 8);
            this.dgCuenta5.GridColor = SystemColors.ActiveBorder;

            this.dgCuenta5.Columns[1].Width = 200;
            this.dgCuenta5.Columns[2].Width = 60;
            this.dgCuenta5.Columns[3].Width = 60;
            this.dgCuenta5.Columns[4].Width = 80;
            this.dgCuenta5.Columns[5].Width = 80;
            this.dgCuenta5.Columns[6].Visible = false;
            this.dgCuenta5.Columns[7].Visible = false;

            this.dgCuenta6.Columns[0].Visible = false;
            this.dgCuenta6.ClearSelection();
            this.dgCuenta6.ColumnHeadersDefaultCellStyle.Font = new Font(dgCuenta6.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dgCuenta6.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dgCuenta6.Font = new Font("Roboto", 8);
            this.dgCuenta6.GridColor = SystemColors.ActiveBorder;

            this.dgCuenta6.Columns[1].Width = 200;
            this.dgCuenta6.Columns[2].Width = 60;
            this.dgCuenta6.Columns[3].Width = 60;
            this.dgCuenta6.Columns[4].Width = 80;
            this.dgCuenta6.Columns[5].Width = 80;
            this.dgCuenta6.Columns[6].Visible = false;
            this.dgCuenta6.Columns[7].Visible = false;
        }

        private void crearTabla()
        {

            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle2 = new DataTable("Detalle2");
            this.dtDetalle3 = new DataTable("Detalle3");
            this.dtDetalle4 = new DataTable("Detalle4");
            this.dtDetalle5 = new DataTable("Detalle5");
            this.dtDetalle6 = new DataTable("Detalle6");

            this.dtDetalle.Columns.Add("Cod", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Descripcion", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Cant", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Precio_Un", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Descuento", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Importe", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Nota", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("idDetalleVenta", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Barra", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Tipo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Estado", System.Type.GetType("System.String"));

            this.dtDetalle2.Columns.Add("Cod", System.Type.GetType("System.Int32"));
            this.dtDetalle2.Columns.Add("Descripcion", System.Type.GetType("System.String"));
            this.dtDetalle2.Columns.Add("Cant", System.Type.GetType("System.Int32"));
            this.dtDetalle2.Columns.Add("Precio_Un", System.Type.GetType("System.Decimal"));
            this.dtDetalle2.Columns.Add("Descuento", System.Type.GetType("System.Decimal"));
            this.dtDetalle2.Columns.Add("Importe", System.Type.GetType("System.Decimal"));
            this.dtDetalle2.Columns.Add("Nota", System.Type.GetType("System.String"));
            this.dtDetalle2.Columns.Add("idDetalleVenta", System.Type.GetType("System.String"));
            this.dtDetalle2.Columns.Add("Barra", System.Type.GetType("System.String"));
            this.dtDetalle2.Columns.Add("Tipo", System.Type.GetType("System.String"));
            this.dtDetalle2.Columns.Add("Estado", System.Type.GetType("System.String"));

            this.dtDetalle3.Columns.Add("Cod", System.Type.GetType("System.Int32"));
            this.dtDetalle3.Columns.Add("Descripcion", System.Type.GetType("System.String"));
            this.dtDetalle3.Columns.Add("Cant", System.Type.GetType("System.Int32"));
            this.dtDetalle3.Columns.Add("Precio_Un", System.Type.GetType("System.Decimal"));
            this.dtDetalle3.Columns.Add("Descuento", System.Type.GetType("System.Decimal"));
            this.dtDetalle3.Columns.Add("Importe", System.Type.GetType("System.Decimal"));
            this.dtDetalle3.Columns.Add("Nota", System.Type.GetType("System.String"));
            this.dtDetalle3.Columns.Add("idDetalleVenta", System.Type.GetType("System.String"));
            this.dtDetalle3.Columns.Add("Barra", System.Type.GetType("System.String"));
            this.dtDetalle3.Columns.Add("Tipo", System.Type.GetType("System.String"));
            this.dtDetalle3.Columns.Add("Estado", System.Type.GetType("System.String"));

            this.dtDetalle4.Columns.Add("Cod", System.Type.GetType("System.Int32"));
            this.dtDetalle4.Columns.Add("Descripcion", System.Type.GetType("System.String"));
            this.dtDetalle4.Columns.Add("Cant", System.Type.GetType("System.Int32"));
            this.dtDetalle4.Columns.Add("Precio_Un", System.Type.GetType("System.Decimal"));
            this.dtDetalle4.Columns.Add("Descuento", System.Type.GetType("System.Decimal"));
            this.dtDetalle4.Columns.Add("Importe", System.Type.GetType("System.Decimal"));
            this.dtDetalle4.Columns.Add("Nota", System.Type.GetType("System.String"));
            this.dtDetalle4.Columns.Add("idDetalleVenta", System.Type.GetType("System.String"));
            this.dtDetalle4.Columns.Add("Barra", System.Type.GetType("System.String"));
            this.dtDetalle4.Columns.Add("Tipo", System.Type.GetType("System.String"));
            this.dtDetalle4.Columns.Add("Estado", System.Type.GetType("System.String"));

            this.dtDetalle5.Columns.Add("Cod", System.Type.GetType("System.Int32"));
            this.dtDetalle5.Columns.Add("Descripcion", System.Type.GetType("System.String"));
            this.dtDetalle5.Columns.Add("Cant", System.Type.GetType("System.Int32"));
            this.dtDetalle5.Columns.Add("Precio_Un", System.Type.GetType("System.Decimal"));
            this.dtDetalle5.Columns.Add("Descuento", System.Type.GetType("System.Decimal"));
            this.dtDetalle5.Columns.Add("Importe", System.Type.GetType("System.Decimal"));
            this.dtDetalle5.Columns.Add("Nota", System.Type.GetType("System.String"));
            this.dtDetalle5.Columns.Add("idDetalleVenta", System.Type.GetType("System.String"));
            this.dtDetalle5.Columns.Add("Barra", System.Type.GetType("System.String"));
            this.dtDetalle5.Columns.Add("Tipo", System.Type.GetType("System.String"));
            this.dtDetalle5.Columns.Add("Estado", System.Type.GetType("System.String"));

            this.dtDetalle6.Columns.Add("Cod", System.Type.GetType("System.Int32"));
            this.dtDetalle6.Columns.Add("Descripcion", System.Type.GetType("System.String"));
            this.dtDetalle6.Columns.Add("Cant", System.Type.GetType("System.Int32"));
            this.dtDetalle6.Columns.Add("Precio_Un", System.Type.GetType("System.Decimal"));
            this.dtDetalle6.Columns.Add("Descuento", System.Type.GetType("System.Decimal"));
            this.dtDetalle6.Columns.Add("Importe", System.Type.GetType("System.Decimal"));
            this.dtDetalle6.Columns.Add("Nota", System.Type.GetType("System.String"));
            this.dtDetalle6.Columns.Add("idDetalleVenta", System.Type.GetType("System.String"));
            this.dtDetalle6.Columns.Add("Barra", System.Type.GetType("System.String"));
            this.dtDetalle6.Columns.Add("Tipo", System.Type.GetType("System.String"));
            this.dtDetalle6.Columns.Add("Estado", System.Type.GetType("System.String"));


            this.dgCuenta1.DataSource = this.dtDetalle;
            this.dgCuenta2.DataSource = this.dtDetalle2;
            this.dgCuenta3.DataSource = this.dtDetalle3;
            this.dgCuenta4.DataSource = this.dtDetalle4;
            this.dgCuenta5.DataSource = this.dtDetalle5;
            this.dgCuenta6.DataSource = this.dtDetalle6;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.lblBandera.Text.Equals("1"))
            {
                
                int indiceFila = this.dataListado.CurrentRow.Index;
                DataRow row = this.dtDetalleCuenta.Rows[indiceFila];

                row1 = this.dtDetalle.NewRow();
               

                row1["Cod"] = Convert.ToInt32(this.lblCod.Text);
                row1["Descripcion"] = this.lblDesc.Text;
                row1["Cant"] = Convert.ToInt32(this.lblCant.Text);
                row1["Precio_Un"] = Convert.ToDecimal(this.lblPrecio.Text);
                row1["Importe"] = Convert.ToDecimal(this.lblImporte.Text);
                row1["Descuento"] = Convert.ToDecimal(this.lblDescuento.Text);
                row1["Nota"] = this.lblNota.Text;
                row1["idDetalleVenta"] = this.lblIdDetalle.Text;
                row1["Barra"] = "1";
                row1["Tipo"] = lblTipo.Text;
                row1["Estado"] = "Pedido";
                this.dtDetalle.Rows.Add(row1);
                // this.dgCuenta1.Rows.Add(this.dtDetalleCuenta.Rows[indiceFila]);
                this.dtDetalleCuenta.Rows.Remove(row);
                this.dataListado.DataSource = dtDetalleCuenta;
                this.dataListado.ClearSelection();
                this.lblBandera.Text = "0";
                this.dgCuenta1.ClearSelection();

                for(int i=0; i < dgCuenta1.Rows.Count; i++)
                {
                    suma = suma + Convert.ToDecimal(dgCuenta1.Rows[i].Cells[5].Value);
                    totalDescuento = totalDescuento + Convert.ToDecimal(dgCuenta1.Rows[i].Cells[4].Value);
                }

                this.lblTotalC1.Text = suma.ToString();
                this.tdC1.Text = totalDescuento.ToString();
                suma = 0;
                totalDescuento = 0;
                this.HabilitarPago();
            }

        }

        private void dataListado_Click(object sender, EventArgs e)
        {
            if (dataListado.Rows.Count > 0)
            {
                this.lblCod.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Cod"].Value);
                this.lblCant.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Cant"].Value);
                this.lblDesc.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Descripcion"].Value);
                this.lblPrecio.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Precio_Un"].Value);
                this.lblImporte.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Importe"].Value);
                this.lblDescuento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Descuento"].Value);
                this.lblDescuento_Actual.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Descuento"].Value);
                this.lblNota.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nota"].Value);
                if(this.lblIdVenta.Text != "0")
                {
                    this.lblIdDetalle.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idDetalleVenta"].Value);
                }
                
                this.lblBandera.Text = "1";
                lblTipo.Text = this.dataListado.CurrentRow.Cells["Tipo"].Value.ToString();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
