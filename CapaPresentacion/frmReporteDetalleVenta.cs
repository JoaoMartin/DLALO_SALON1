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
    public partial class frmReporteDetalleVenta : Form
    {
        public frmReporteDetalleVenta()
        {
            InitializeComponent();
        }

        private void Formato()
        {
            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[0].Width = 80;
            this.dataListado.Columns[1].Width = 350;
            this.dataListado.Columns[2].Width = 100;
            this.dataListado.Columns[3].Width = 170;
            this.dataListado.Columns[4].Width = 170;
            this.dataListado.Columns[4].Width = 170;

            this.dataListado.RowTemplate.Height = 47;
            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListado.Font = new Font("Microsoft Sans Serif", 8);
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NVenta.reporteDetalleVenta(Convert.ToInt32(this.lblIdVenta.Text));
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
            }
            else
            {
                decimal total = 00.00m;
                this.dataListado.Visible = true;
                Formato();
                for(int i = 0; i < dataListado.Rows.Count; i++)
                {
                    total = total + Convert.ToDecimal(dataListado.Rows[i].Cells[5].Value);
                }
                this.lblTot.Text = total.ToString();
                if(lblTipo.Text == "PAGADA-D")
                {
                    this.lblTipo.Text = "VENTA DIVIDIDA";
                }
            }
        }
        private void frmReporteDetalleVenta_Load(object sender, EventArgs e)
        {
            Mostrar();
        }
    }
}
