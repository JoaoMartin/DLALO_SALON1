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
    public partial class frmVistaProductoCompuesto : Form
    {
        public static frmVistaProductoCompuesto f1;
        public frmVistaProductoCompuesto()
        {
            InitializeComponent();
            frmVistaProductoCompuesto.f1 = this;
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
            this.dataListado.DataSource = NProducto.MostrarTodos();
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
            }
            else
            {
                this.dataListado.Visible = true;
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


        private void frmVistaProductoCompuesto_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.rbNombre.Checked = true;
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

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
      
            frmProducto.f1.txtProductoCompuesto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            frmProducto.f1.txtPrecioVentaCompues.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Precio_Venta"].Value);
            frmProducto.f1.lblIdProdIns.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            frmProducto.f1.lblTipoProducto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Tipo"].Value);
            frmProducto.f1.txtCantidad.Text = string.Empty;
            frmProducto.f1.txtCantidad.ReadOnly = false;
            frmProducto.f1.txtCantidad.Focus();
            this.Hide();
        }
    }
}
