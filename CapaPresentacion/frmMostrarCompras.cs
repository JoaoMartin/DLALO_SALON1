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
    public partial class frmMostrarCompras : Form
    {
        public static frmMostrarCompras f1;
        public frmMostrarCompras()
        {
            InitializeComponent();
            frmMostrarCompras.f1 = this;

        }


        private void Mostrar()
        {
            string fechaInicio = dtpFechaInicio.Value.ToString("yyyy-MM-dd");
            string fechaFin = dtpFechaFin.Value.ToString("yyyy-MM-dd");

            this.dataListado.DataSource = NCompra.Mostrar(Convert.ToDateTime(fechaInicio + " 00:00:00"), Convert.ToDateTime(fechaFin + " 23:59:59"));
            this.lblTotal.Text = "Total de Registros: " + this.dataListado.Rows.Count;
            this.dataListado.ClearSelection();
        }

        private void ocultarColumnas()
        {
            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[0].Width = 80;
            this.dataListado.Columns[1].Width = 340;
            this.dataListado.Columns[2].Width = 190;
            this.dataListado.Columns[3].Width = 150;
            this.dataListado.Columns[4].Width = 235;
            this.dataListado.Columns[5].Width = 140;
            this.dataListado.Columns[6].Width = 180;

            this.dataListado.RowTemplate.Height = 28;
            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListado.Font = new Font("Roboto", 9);
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mostrar();
            ocultarColumnas();
            btnImprimir.Enabled = true;
        }

        private void frmMostrarCompras_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmDetalleCompra form = new frmDetalleCompra();
            form.lblIdVenta.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            form.ShowDialog();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmRMostrarCompras frm = new frmRMostrarCompras();
            frm.ShowDialog();
        }

        private void frmMostrarCompras_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
