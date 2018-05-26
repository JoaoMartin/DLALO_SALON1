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
    public partial class frmReporteComprasProveedor : Form
    {
        public static frmReporteComprasProveedor f1;
        public frmReporteComprasProveedor()
        {
            InitializeComponent();
            frmReporteComprasProveedor.f1 = this;
        }
        private void Mostrar()
        {
            if (cbProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un proveedor de la lista");
            }
            else
            {
                string fechaInicio = dtpFechaInicio.Value.ToString("yyyy-MM-dd");
                string fechaFin = dtpFechaFin.Value.ToString("yyyy-MM-dd");

                this.dataListado.DataSource = NCompra.reporteCompraProveedor(Convert.ToDateTime(fechaInicio + " 00:00:00"), Convert.ToDateTime(fechaFin + " 23:59:59"), Convert.ToInt32(cbProducto.SelectedValue));
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
                }
            }

        }

        private void ocultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;

            //DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[1].Width = 110;
            this.dataListado.Columns[2].Width = 300;
            this.dataListado.Columns[3].Width = 250;
            this.dataListado.Columns[4].Width = 120;
            this.dataListado.Columns[5].Width = 150;
            this.dataListado.Columns[6].Width = 180;
            this.dataListado.Columns[7].Width = 150;

            this.dataListado.RowTemplate.Height = 28;
            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListado.Font = new Font("Roboto", 9);
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }

        private void cargarProveedor()
        {
            cbProducto.DataSource = NProveedor.Mostrar();
            cbProducto.ValueMember = "Codigo";
            cbProducto.DisplayMember = "Razon_Social";
            cbProducto.SelectedIndex = -1;
            //lblPrueba.Text = cbCategoria.SelectedValue.ToString();

        }
        private void frmReporteComprasProveedor_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            cargarProveedor();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmDetalleCompra form = new frmDetalleCompra();
            form.lblIdVenta.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo_Compra"].Value);
            form.ShowDialog();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmRComprasProveedor frm = new frmRComprasProveedor();
            frm.ShowDialog();
        }

        private void frmReporteComprasProveedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
