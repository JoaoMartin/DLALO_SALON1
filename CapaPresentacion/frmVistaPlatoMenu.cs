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
    public partial class frmVistaPlatoMenu : Form
    {
        public frmVistaPlatoMenu()
        {
            InitializeComponent();
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
            this.dataListado.DataSource = NProducto.MostrarPlatosMenu();
            this.ocultarColumnas();


            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
            }
            else
            {
                this.dataListado.Visible = true;
            }
        }

        private void BuscarCategoria()
        {
            this.dataListado.DataSource = NProducto.BuscarCategoriaProductoPlato(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();

        }

        private void BuscarNombre()
        {
            this.dataListado.DataSource = NProducto.BuscarNombeProductoPlato(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();

        }


        private void frmVistaPlatoMenu_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            rbNombre.Checked = true;
            txtBuscar.Focus();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (this.rbNombre.Checked == true)
            {
                this.BuscarNombre();
            }
            else if (this.rbCategoria.Checked == true)
            {
                this.BuscarCategoria();
            }
            else if (this.rbTodos.Checked == true)
            {
                this.BuscarNombre();
            }
        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodos.Checked == true)
            {
                this.Mostrar();
                this.txtBuscar.Text = string.Empty;
            }
        }

        string IdProducto;
        string precioVenta;
        string nombreProd;
        string tipoProd;
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {

            bool registrar = true;
            nombreProd = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            precioVenta = Convert.ToString(this.dataListado.CurrentRow.Cells["Precio_Venta"].Value);
            IdProducto = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            tipoProd = Convert.ToString(this.dataListado.CurrentRow.Cells["Tipo"].Value);
            foreach (DataRow row in frmPlato.f1.dtDetalle.Rows)
            {
                if (Convert.ToInt32(row["Codigo"]) == Convert.ToInt32(IdProducto))
                {
                    registrar = false;
                    MessageBox.Show("Ya registraste este plato");
                }
            }

            if (registrar)
            {
                decimal subTotal = Convert.ToDecimal(1) * Convert.ToDecimal(precioVenta);
                DataRow row = frmPlato.f1.dtDetalle.NewRow();
                row["Codigo"] = Convert.ToInt32(IdProducto);
                row["Producto"] = nombreProd;
                row["Cantidad"] = Convert.ToInt32(1);
                row["Precio_Venta"] = Convert.ToDecimal(precioVenta);
                row["Importe"] = subTotal;
                row["Tipo"] = tipoProd;

                frmPlato.f1.dtDetalle.Rows.Add(row);

            }

            decimal suma = 0;
            for (int i = 0; i < frmPlato.f1.dataListadoDetalle.Rows.Count; i++)
            {
                suma = suma + Convert.ToDecimal(frmPlato.f1.dataListadoDetalle.Rows[i].Cells["Importe"].Value);
            }
            frmPlato.f1.lblTotalVenta.Text = suma.ToString("#0.00#");
            frmPlato.f1.dataListado.ClearSelection();
            frmPlato.f1.dataListado.Columns[0].Visible = false;
        }
    
    }
}
