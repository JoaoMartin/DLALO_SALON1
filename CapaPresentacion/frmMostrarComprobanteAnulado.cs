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
    public partial class frmMostrarComprobanteAnulado : Form
    {
        public static frmMostrarComprobanteAnulado f1;
        public frmMostrarComprobanteAnulado()
        {
            InitializeComponent();
            frmMostrarComprobanteAnulado.f1 = this;
        }
        private void ocultarColumnas()
        {

            this.dataListado.Columns[0].Visible = false;

            //DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[1].Width = 80;
            this.dataListado.Columns[2].Width = 170;
            this.dataListado.Columns[3].Width = 170;
            this.dataListado.Columns[4].Width = 180;
            this.dataListado.Columns[5].Width = 400;


            this.dataListado.RowTemplate.Height = 28;
            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListado.Font = new Font("Roboto", 9);
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }
        private void Mostrar()
        {

            string fechaInicio = "";
            string fechaFin = "";
            int totalCan = 0;
            if (rbAperturaCaja.Checked == true)
            {
                //fecIn = Convert.ToDateTime(frmPrincipal.f1.lblFechaApertura.Text);
                //fechaInicio = fecIn.ToString("yyyy-MM-dd hh:mm:ss");
                fechaInicio = frmPrincipal.f1.lblFechaApertura.Text;
                // fechaFin = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                fechaFin = DateTime.Now.ToString();
            }
            else if (rbElegir.Checked == true)
            {
                fechaInicio = dtpFechaInicio.Value.ToString("yyyy-MM-dd" + " 00:00:00");
                fechaFin = dtpFechaFin.Value.ToString("yyyy-MM-dd" + " 23:59:59");
            }

            //this.lblCaja.Text = "0";
         
            this.dataListado.DataSource = NComprobante.mostrarComprobantesAnulados(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin));
            for (int i = 0; i < dataListado.Rows.Count; i++)
            {
                totalCan = totalCan + Convert.ToInt32(dataListado.Rows[i].Cells[0].Value.ToString());
            }
            //lblCant.Text = totalCan.ToString();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;

                btnImprimir.Enabled = false;
                //ocultarColumnas();
            }
            else
            {

                this.dataListado.Visible = true;
                btnImprimir.Enabled = true;
                ocultarColumnas();
                decimal totalVentas = 00.00m;
                for (int i = 0; i < dataListado.Rows.Count; i++)
                {
                    totalVentas = totalVentas + Convert.ToDecimal(dataListado.Rows[i].Cells[6].Value.ToString());
                }
                lblSumaTotal.Text = totalVentas.ToString();
            }




        }
        private void frmMostrarComprobanteAnulado_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            if(frmPrincipal.f1.lblFechaApertura.Text == "0" || frmPrincipal.f1.lblFechaApertura.Text == "Cerrada")
            {
                rbElegir.Checked = true;
                rbAperturaCaja.Checked = false;
                rbAperturaCaja.Enabled = false;
                groupBox1.Enabled = true;
            }else
            {
                rbAperturaCaja.Checked = true;
                rbElegir.Checked = false;
                rbAperturaCaja.Enabled = true;
                groupBox1.Enabled = false;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void rbAperturaCaja_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAperturaCaja.Checked == true)
            {
                groupBox1.Enabled = false;
                this.lblBandera.Text = "0";
            }
            else if (rbElegir.Checked == true)
            {
                groupBox1.Enabled = true;
                this.lblBandera.Text = "1";
            }
        }

        private void rbElegir_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAperturaCaja.Checked == true)
            {
                groupBox1.Enabled = false;
                this.lblBandera.Text = "0";
            }
            else if (rbElegir.Checked == true)
            {
                groupBox1.Enabled = true;
                this.lblBandera.Text = "1";
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dataListado.Rows.Count > 0)
            {

                frmRComprobantesAnulados frm = new frmRComprobantesAnulados();
                frm.ShowDialog();

            }
        }
    }
}
