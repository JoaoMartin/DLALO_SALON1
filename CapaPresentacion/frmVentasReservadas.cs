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
    public partial class frmVentasReservadas : Form
    {
        public static frmVentasReservadas f1;
        public frmVentasReservadas()
        {
            InitializeComponent();
            frmVentasReservadas.f1 = this;
        }


        private void Buscar()
        {
            this.dataListado.DataSource = NVenta.Buscar(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarCliente()
        {
            this.dataListado.DataSource = NVenta.BuscarCliente(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void ocultarColumnas()
        {
            this.dataListado.Columns[11].Visible = false;
            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[0].Width = 60;
            this.dataListado.Columns[1].Width = 180;
            this.dataListado.Columns[2].Width = 180;
            this.dataListado.Columns[3].Width = 90;
            this.dataListado.Columns[4].Width = 200;
            this.dataListado.Columns[5].Width = 105;
            this.dataListado.Columns[6].Width = 90;
            this.dataListado.Columns[7].Width = 90;
            this.dataListado.Columns[8].Width = 90;
            this.dataListado.Columns[9].Width = 90;
            this.dataListado.Columns[10].Width = 300;

            this.dataListado.RowTemplate.Height = 28;
            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListado.Font = new Font("Roboto", 9);
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }
        public void Mostrar()
        {
            this.dataListado.DataSource = NVenta.MostrarPedidosPendientes();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
                //ocultarColumnas();
            }
            else
            {
                this.dataListado.Visible = true;
                ocultarColumnas();
            }
        }
        private void frmVentasReservadas_Load(object sender, EventArgs e)
        {
            this.Left = 0;
            this.Top = 0;
            Mostrar();
            this.txtBuscar.Select();
            this.btnRecoger.Enabled = false;
            this.btnCobrar.Enabled = false;
            this.btnAnular.Enabled = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if(txtBuscar.Text.Trim().Length == 0)
            {
                Mostrar();
            }

            if(rbCodigo.Checked == true)
            {
                this.Mostrar();
                this.Buscar();
            }
            else
            {
                this.Mostrar();
                this.BuscarCliente();
            }
           
        }

        private void dataListado_Click(object sender, EventArgs e)
        {
            this.lblEstado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Estado"].Value);
            this.lblIdVenta.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            this.lblAdelanto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Adelanto"].Value);
            this.lblTotal.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Total"].Value);
            this.lblSaldo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Saldo"].Value);
            if (lblEstado.Text == "PAGADA-R")
            {
                btnRecoger.Enabled = true;
                btnCobrar.Enabled = false;
                btnAnular.Enabled = true;
            }else
            {
                btnRecoger.Enabled = false;
                btnCobrar.Enabled = true;
                btnAnular.Enabled = true;
            }
        }

        private void btnRecoger_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("Está seguro de realizar esta operación?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcion == DialogResult.OK)
            {
                string rpta = "";
                rpta = NVenta.EditarEstadoVentaRecogida(Convert.ToInt32(lblIdVenta.Text));
                if(rpta == "OK")
                {
                    MessageBox.Show("Se completó la operación");
                    Mostrar();
                    this.txtBuscar.Select();
                }
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmReporteDetalleVenta form = new frmReporteDetalleVenta();
            form.lblIdVenta.Text = this.lblIdVenta.Text;
            form.ShowDialog();
            this.txtBuscar.Select();
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            frmPagar frm = new frmPagar();
            frm.lblBanderaCobro.Text = "3";//cobro de reserva
            frm.lblIdVenta.Text = this.lblIdVenta.Text;
            frm.lblIdUsuario.Text = this.lblIdUsuario.Text;
            frm.lblMontoAdelanto.Text = this.lblAdelanto.Text;
            frm.ShowDialog();
        }

        private void rbNombre_CheckedChanged(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void rbCodigo_CheckedChanged(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            frmAnularPedido frm = new frmAnularPedido();
            decimal saldo = Convert.ToDecimal(this.lblSaldo.Text);
            if(saldo <= 0)
            {
                frm.lblEfectivo.Text = lblTotal.Text;
            }
            else
            {
                frm.lblEfectivo.Text = lblAdelanto.Text;
            }
            frm.ShowDialog();
        }
    }
}
