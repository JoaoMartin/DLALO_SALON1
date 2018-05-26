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
    public partial class frmVistaInsumo_Ingreso : Form
    {
        public static frmVistaInsumo_Ingreso f1;
        public frmVistaInsumo_Ingreso()
        {
            InitializeComponent();
            frmVistaInsumo_Ingreso.f1 = this;
        }

        public void Mostrar()
        {
            this.dataListado.DataSource = NInsumo.Mostrar();

            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
            }
            else
            {
                this.dataListado.Visible = true;
                this.ocultarColumnas();
            }
        }

        private void Buscar()
        {
            this.dataListado.DataSource = NInsumo.Buscar(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void ocultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;

            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[1].Width = 200;
            this.dataListado.Columns[2].Width = 345;
            this.dataListado.Columns[4].Width = 105;
            // this.dataListado.Columns[7].Width = 120;

            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.DefaultCellStyle.Font = new Font("Roboto", 9);
            this.dataListado.RowsDefaultCellStyle.BackColor = Color.White;
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }

        private void frmVistaInsumo_Ingreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            if(this.lblBanderaCierre.Text == "0")
            {
                this.btnNuevo.Visible = true;
            }else
            {
                this.btnNuevo.Visible = true;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            if(this.lblBanderaCierre.Text == "0")
            {
                frmCompra.f1.txtIdArticulo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
                frmCompra.f1.txtProducto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
                frmCompra.f1.txtUnidad.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Unidad"].Value);
                frmCompra.f1.txtPrecioVenta.Text = "";
                frmCompra.f1.lblBandera.Text = "I";
                this.Hide();
            }
            else if (this.lblBanderaCierre.Text == "1")
            {
                frmIngresoAlmacen.f1.txtIdArticulo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
                frmIngresoAlmacen.f1.txtProducto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
                frmIngresoAlmacen.f1.txtUnidad.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Unidad"].Value);
                frmIngresoAlmacen.f1.lblBandera.Text = "I";
                this.Hide();
            }
            else if (this.lblBanderaCierre.Text == "2")
            {
                frmSalidaAlmacen.f1.txtIdArticulo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
                frmSalidaAlmacen.f1.txtProducto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
                frmSalidaAlmacen.f1.txtUnidad.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Unidad"].Value);
                frmSalidaAlmacen.f1.lblStockActual.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Stock"].Value);
                frmSalidaAlmacen.f1.lblBandera.Text = "I";
                this.Hide();
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmInsumo_Rapido form = new frmInsumo_Rapido();
            form.ShowDialog();
        }
    }
}
