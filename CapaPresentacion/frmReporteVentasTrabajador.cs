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
    public partial class frmReporteVentasTrabajador : Form
    {
        public static frmReporteVentasTrabajador f1;
        public frmReporteVentasTrabajador()
        {
            InitializeComponent();
            frmReporteVentasTrabajador.f1 = this;
        }
        private void cargarTrabajador()
        {
            cbProducto.DataSource = NTrabajador.Mostrar();
            cbProducto.ValueMember = "Codigo";
            cbProducto.DisplayMember = "Nombre";
            cbProducto.SelectedIndex = -1;
            //lblPrueba.Text = cbCategoria.SelectedValue.ToString();

        }

        private void Mostrar()
        {
            if (cbProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un trabajador de la lista");
            }
            else
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

                this.dataListado.DataSource = NVenta.reporteVentaTrabajador(Convert.ToDateTime(fechaInicio + " 00:00:00"), Convert.ToDateTime(fechaFin + " 23:59:59"), Convert.ToInt32(cbProducto.SelectedValue));
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
            this.dataListado.Columns[2].Width = 320;
            this.dataListado.Columns[3].Width = 220;
            this.dataListado.Columns[4].Width = 150;
            this.dataListado.Columns[5].Width = 90;
            this.dataListado.Columns[6].Width = 135;
            this.dataListado.RowTemplate.Height = 28;
            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListado.Font = new Font("Roboto", 9);
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void frmReporteVentasTrabajador_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            cargarTrabajador();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmReporteDetalleVenta form = new frmReporteDetalleVenta();
            form.lblIdVenta.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo_Venta"].Value);
            form.lblTipo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Tipo"].Value);
            form.ShowDialog();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmRVentaTrabajador frm = new frmRVentaTrabajador();
            frm.ShowDialog();
        }

        private void frmReporteVentasTrabajador_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
