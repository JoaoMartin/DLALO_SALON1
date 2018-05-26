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
    public partial class frmReporteMovCaja : Form
    {
        public static frmReporteMovCaja f1;
        public frmReporteMovCaja()
        {
            InitializeComponent();
            frmReporteMovCaja.f1 = this;
        }

        private void ocultarColumnas()
        {
            //this.dataListado.Columns[0].Visible = false;

            //DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[1].Width = 110;
            this.dataListado.Columns[2].Width = 160;
            this.dataListado.Columns[3].Width = 320;
            this.dataListado.Columns[4].Width = 150;
            this.dataListado.Columns[5].Width = 180;
            //this.dataListado.Columns[6].Width = 135;
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


                this.dataListado.DataSource = NCaja_A.reporteMovCaja(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin));
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
                decimal total = 00.00m;
                for(int i = 0; i < dataListado.Rows.Count; i++)
                {
                    total = total + Convert.ToDecimal(this.dataListado.Rows[i].Cells[5].Value.ToString());
                }
                lblTotal1.Text = total.ToString();
            }
       

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if(rbElegir.Checked == true)
            {
                lblBandera.Text = "1";
            }else
            {
                lblBandera.Text = "0";
            }
            frmRMovCaja frm = new frmRMovCaja();
            frm.ShowDialog();
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
    }
}
