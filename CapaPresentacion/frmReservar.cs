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
    public partial class frmReservar : Form
    {
        public static frmReservar f1;
        public frmReservar()
        {
            InitializeComponent();
            frmReservar.f1 = this;
        }

 
        private void frmReservar_Load(object sender, EventArgs e)
        {
            dtpHora.Format = DateTimePickerFormat.Custom;
            dtpHora.CustomFormat = "hh:mm tt";
            dtpHora.ShowUpDown = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmPagar form = new frmPagar();
          
            form.lblTotal.Text = frmVenta.f1.txtTotalPagado.Text.Trim();
            form.lblIdVenta.Text = frmVenta.f1.lblIdVenta.Text;
            form.lblIdMesa.Text = frmVenta.f1.lblIdMesa.Text;
            form.lblDescuento.Text = frmVenta.f1.txtDescuento.Text;
            form.lblIdTrabajador.Text = frmVenta.f1.idMesero;
            form.lblIdUsuario.Text =frmVenta.f1.idMesero;
            decimal subtotal1 = 00.00m;
            subtotal1 = ((Convert.ToDecimal(frmVenta.f1.txtSubTotal.Text) - Convert.ToDecimal(frmVenta.f1.txtDescuento.Text)) / 1.18m);
            form.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(subtotal1));
            decimal igvC = (Convert.ToDecimal(frmVenta.f1.txtTotalPagado.Text) - subtotal1);
            form.lblIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(igvC));
            form.lblObs.Text = this.txtObs.Text;
            form.lblFechaEntrega.Text = dtpFecha.Value.ToShortDateString() + " " + dtpHora.Value.ToLongTimeString();
            if(rbAdelanto.Checked == true)
            {
                form.lblBanderaCobro.Text = "1";//ADELANTO
            }else 
            {
                form.lblBanderaCobro.Text = "0";//PAGO TOTAL
            }
            
            form.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
