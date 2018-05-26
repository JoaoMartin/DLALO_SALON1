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
    public partial class frmDescuentoProducto : Form
    {
        public frmDescuentoProducto()
        {
            InitializeComponent();
        }

        private void btnUno_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "1";
        }

        private void btnDos2_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.txtNumero.Text += ".";
        }

        private void btnRetroceso_Click(object sender, EventArgs e)
        {
            if (this.txtNumero.Text.Length == 1)
            {
                this.txtNumero.Text = string.Empty;
            }
            else if (this.txtNumero.Text.Length != 0)
            {
                this.txtNumero.Text = this.txtNumero.Text.Substring(0, this.txtNumero.Text.Length - 1);
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter && this.txtNumero.Text != string.Empty)
            {
                if (this.txtNumero.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Ingrese una cantidad");
                }
                else
                {
                    decimal precioVenta = 00.00m, subtotal = 00.00m, total = 00.00m, importeVenta = 00.00m;
                    int cantidad = 0;

                    importeVenta = Convert.ToDecimal(frmVenta.f1.lblImporte.Text);

                    if (Convert.ToDecimal(this.txtNumero.Text.Trim()) > importeVenta)
                    {
                        MessageBox.Show("Ingrese un monto menor al importe de venta");
                    }
                    else
                    {
                        precioVenta = Convert.ToDecimal(frmVenta.f1.dataListadoDetalle[3, Convert.ToInt32(frmVenta.f1.lblPosicion.Text)].Value);
                        cantidad = Convert.ToInt32(frmVenta.f1.dataListadoDetalle[2, Convert.ToInt32(frmVenta.f1.lblPosicion.Text)].Value);
                        subtotal = precioVenta * cantidad;
                        total = subtotal - Convert.ToDecimal(this.txtNumero.Text.Trim());
                        frmVenta.f1.dataListadoDetalle[4, Convert.ToInt32(frmVenta.f1.lblPosicion.Text)].Value = Convert.ToDecimal(this.txtNumero.Text.Trim());
                        frmVenta.f1.dataListadoDetalle[4, Convert.ToInt32(frmVenta.f1.lblPosicion.Text)].Value = string.Format(" {0:#,##0.00}", Convert.ToDouble(this.txtNumero.Text));
                        frmVenta.f1.dataListadoDetalle[5, Convert.ToInt32(frmVenta.f1.lblPosicion.Text)].Value = total;
                        decimal sumaTotal = 0, sumaDescuento = 0;
                        foreach (DataGridViewRow row in frmVenta.f1.dataListadoDetalle.Rows)
                        {
                            sumaTotal += (decimal)row.Cells[5].Value;
                            sumaDescuento += (decimal)row.Cells[4].Value;
                        }
                        frmVenta.f1.txtTotalPagado.Text = sumaTotal.ToString();
                        frmVenta.f1.dataListadoDetalle.ClearSelection();
                        frmVenta.f1.lblBandera.Text = "0";
                        frmVenta.f1.txtDescuento.Text = sumaDescuento.ToString();
                        frmVenta.f1.totalPagado = frmVenta.f1.totalPagado - Convert.ToDecimal(this.txtNumero.Text.Trim());
                        this.Hide();
                    }

                }
            }

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

            for (int i = 0; i < txtNumero.Text.Length; i++)
            {
                if (txtNumero.Text[i] == '.')
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.txtNumero.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Ingrese una cantidad");
            }
            else
            {
                decimal precioVenta = 00.00m, subtotal = 00.00m, total = 00.00m, importeVenta = 00.00m;
                int cantidad = 0;

                importeVenta = Convert.ToDecimal(frmVenta.f1.lblImporte.Text);

                if (Convert.ToDecimal(this.txtNumero.Text.Trim()) > importeVenta)
                {
                    MessageBox.Show("Ingrese un monto menor al importe de venta");
                }
                else
                {
                    precioVenta = Convert.ToDecimal(frmVenta.f1.dataListadoDetalle[3, Convert.ToInt32(frmVenta.f1.lblPosicion.Text)].Value);
                    cantidad = Convert.ToInt32(frmVenta.f1.dataListadoDetalle[2, Convert.ToInt32(frmVenta.f1.lblPosicion.Text)].Value);
                    subtotal = precioVenta * cantidad;
                    total = subtotal - Convert.ToDecimal(this.txtNumero.Text.Trim());
                    frmVenta.f1.dataListadoDetalle[4, Convert.ToInt32(frmVenta.f1.lblPosicion.Text)].Value = Convert.ToDecimal(this.txtNumero.Text.Trim());
                    frmVenta.f1.dataListadoDetalle[4, Convert.ToInt32(frmVenta.f1.lblPosicion.Text)].Value = string.Format(" {0:#,##0.00}", Convert.ToDouble(this.txtNumero.Text));
                    frmVenta.f1.dataListadoDetalle[5, Convert.ToInt32(frmVenta.f1.lblPosicion.Text)].Value = total;
                   
                    decimal sumaTotal = 0, sumaDescuento = 0;
                    foreach (DataGridViewRow row in frmVenta.f1.dataListadoDetalle.Rows)
                    {
                        sumaTotal += (decimal)row.Cells[5].Value;
                        sumaDescuento += (decimal)row.Cells[4].Value;
                    }
                    frmVenta.f1.txtSubTotal.Text = (sumaTotal + sumaDescuento).ToString();
                    // frmVenta.f1.txtTotalPagado.Text = sumaTotal.ToString();
                    frmVenta.f1.txtTotalPagado.Text = (sumaTotal).ToString();
                    frmVenta.f1.dataListadoDetalle.ClearSelection();
                    frmVenta.f1.lblBandera.Text = "0";
                    frmVenta.f1.txtDescuento.Text = sumaDescuento.ToString();
                    frmVenta.f1.totalPagado = frmVenta.f1.totalPagado - Convert.ToDecimal(this.txtNumero.Text.Trim());
                    if(frmVenta.f1.lblIdVenta.Text == "0" && frmVenta.f1.dataListadoDetalle.Rows.Count <=0)
                    {
                            frmVenta.f1.dtDetalle.Rows[Convert.ToInt32(frmVenta.f1.lblPosicion.Text)][4] = Convert.ToDecimal(this.txtNumero.Text);
                            frmVenta.f1.dtDetalle.Rows[Convert.ToInt32(frmVenta.f1.lblPosicion.Text)][5] = total;

                    }
                    else if (frmVenta.f1.lblIdVenta.Text != "0" && frmVenta.f1.dataListadoDetalle.Rows.Count <= 0)
                    {
                        frmVenta.f1.dtDetalleVenta.Rows[Convert.ToInt32(frmVenta.f1.lblPosicion.Text)][4] = Convert.ToDecimal(this.txtNumero.Text);
                        frmVenta.f1.dtDetalleVenta.Rows[Convert.ToInt32(frmVenta.f1.lblPosicion.Text)][5] = total;
                    }
                    else if(frmVenta.f1.lblIdVenta.Text != "0" && frmVenta.f1.lblBanderaDatatable.Text == "1")
                    {
                        frmVenta.f1.dtDetalle.Rows[Convert.ToInt32(frmVenta.f1.lblPosicion.Text)][4] = Convert.ToDecimal(this.txtNumero.Text);
                        frmVenta.f1.dtDetalle.Rows[Convert.ToInt32(frmVenta.f1.lblPosicion.Text)][5] = total;
                        //frmVenta.f1.dtDetalle.Rows[Convert.ToInt32(frmVenta.f1.lblPosicion.Text)][4] = string.Format(" {0:#,##0.00}");
                    }
                    else if (frmVenta.f1.lblIdVenta.Text != "0" && frmVenta.f1.lblBanderaDatatable.Text == "0")
                    {
                        frmVenta.f1.dtDetalleVenta.Rows[Convert.ToInt32(frmVenta.f1.lblPosicion.Text)][4] = Convert.ToDecimal(this.txtNumero.Text);
                        frmVenta.f1.dtDetalleVenta.Rows[Convert.ToInt32(frmVenta.f1.lblPosicion.Text)][5] = total;
                    }
                    frmVenta.f1.lblBanderaDescuento.Text = "1";
                    this.Close();
                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
