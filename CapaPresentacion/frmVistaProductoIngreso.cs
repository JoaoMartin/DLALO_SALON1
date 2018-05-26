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
    public partial class frmVistaProductoIngreso : Form
    {
        public static frmVistaProductoIngreso f1;
        public frmVistaProductoIngreso()
        {
            InitializeComponent();
            frmVistaProductoIngreso.f1 = this;
        }

        private void ocultarColumnas()
        {
            this.dataListado.Columns[3].Visible = false;
            this.dataListado.Columns[6].Visible = false;
            this.dataListado.Columns[7].Visible = false;

            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[0].Width = 70;
            this.dataListado.Columns[1].Width = 200;
            this.dataListado.Columns[2].Width = 345;
            this.dataListado.Columns[4].Width = 105;
            this.dataListado.Columns[5].Width = 110;
            // this.dataListado.Columns[7].Width = 120;

            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            this.dataListado.RowsDefaultCellStyle.BackColor = Color.White;
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }

        public void Mostrar()
        {
            this.dataListado.DataSource = NProducto.MostrarArticulo();
            
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

        private void BuscarCategoriaArticulo()
        {
            this.dataListado.DataSource = NProducto.BuscarCategoriaProductoArticulo(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarNombreArticulo()
        {
            this.dataListado.DataSource = NProducto.BuscarNombeProductoArticulo(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void frmVistaProductoIngreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.rbNombre.Checked = true;
            this.txtBuscar.Select();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (rbNombre.Checked)
            {
                this.BuscarNombreArticulo();
            }
            else
            {
                this.BuscarCategoriaArticulo();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
        }

        private void añadir()
        {
            if (this.lblBanderaCierre.Text == "0")
            {
                frmCompra form = frmCompra.GetInstancia();
                string par1, par2, par3;
                par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
                par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
                par3 = Convert.ToString(this.dataListado.CurrentRow.Cells["Precio_Venta"].Value);
                frmCompra.f1.lblBandera.Text = "P";
                frmCompra.f1.txtUnidad.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Unidad"].Value);
                form.txtCantidad.Focus();
                form.btnAgregar.Enabled = true;
                form.btnQuitar.Enabled = true;
                form.btnEditar.Enabled = false;
                form.setProducto(par1, par2, par3);
                form.txtCantidad.Select();
                this.Hide();
            }
            else if (this.lblBanderaCierre.Text == "1")
            {
                frmIngresoAlmacen.f1.txtIdArticulo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
                frmIngresoAlmacen.f1.txtUnidad.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Unidad"].Value);
                frmIngresoAlmacen.f1.txtProducto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
                frmIngresoAlmacen.f1.lblBandera.Text = "A";
                frmIngresoAlmacen.f1.txtCantidad.Focus();
                frmIngresoAlmacen.f1.btnAgregar.Enabled = true;
                frmIngresoAlmacen.f1.btnQuitar.Enabled = true;
                frmIngresoAlmacen.f1.btnEditar.Enabled = false;
                frmIngresoAlmacen.f1.txtCantidad.Select();
                this.Hide();

            }
            else if (this.lblBanderaCierre.Text == "2")
            {
                frmSalidaAlmacen.f1.txtIdArticulo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
                frmSalidaAlmacen.f1.txtUnidad.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Unidad"].Value);
                frmSalidaAlmacen.f1.txtProducto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
                frmSalidaAlmacen.f1.lblStockActual.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Stock"].Value);
                frmSalidaAlmacen.f1.lblBandera.Text = "A";
                frmSalidaAlmacen.f1.txtCantidad.Focus();
                frmSalidaAlmacen.f1.btnAgregar.Enabled = true;
                frmSalidaAlmacen.f1.btnQuitar.Enabled = true;
                frmSalidaAlmacen.f1.btnEditar.Enabled = false;
                frmSalidaAlmacen.f1.txtCantidad.Select();
                this.Hide();

            }
        }
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            añadir();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmProductoRapido form = new frmProductoRapido();
            form.ShowDialog();
        }

        private void dataListado_Click(object sender, EventArgs e)
        {
            añadir();
        }
    }
}
