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
    public partial class frmStockActual : Form
    {
        public static frmStockActual f1;
        public frmStockActual()
        {
            InitializeComponent();
            frmStockActual.f1 = this;
        }

        private void BuscarProducto_Almacen()
        {
            this.dataListado.DataSource = NProducto.BuscarProducto_Almacen(this.txtBuscar.Text.Trim());
            this.formatoColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarInsumo_Almacen()
        {
            this.dataListado.DataSource = NInsumo.BuscarInsumo_Almacen(this.txtBuscar.Text.Trim());
            this.formatoColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void MostrarProductos()
        {
            this.dataListado.DataSource = NProducto.MostrarStockProductoAlmacen();

            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
            }
            else
            {
                this.dataListado.Visible = true;
                this.formatoColumnas();
                stockMinimo();
                this.dataListado.ClearSelection();
                
            }
        }

        private void MostrarInsumos()
        {
            this.dataListado.DataSource = NInsumo.MostrarStockInsumoAlmacen();

            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
            }
            else
            {
                this.dataListado.Visible = true;
                this.formatoColumnas();
                stockMinimoI();
            }
        }


        private void stockMinimoI()
        {
            decimal stock = 00.00m;
            decimal stockMin = 00.00m;
            for (int i = 0; i < dataListado.Rows.Count; i++)
            {
                stock = Convert.ToDecimal(dataListado.Rows[i].Cells[4].Value);
                stockMin = Convert.ToDecimal(dataListado.Rows[i].Cells[5].Value);

                if (stock <= stockMin)
                {
                    dataListado.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
        private void stockMinimo()
        {
            if(dataListado.Rows.Count > 0)
            {
                decimal stock = 00.00m;
                decimal stockMin = 00.00m;
                for (int i = 0; i < dataListado.Rows.Count; i++)
                {
                    stock = Convert.ToDecimal(dataListado.Rows[i].Cells[4].Value);
                    stockMin = Convert.ToDecimal(dataListado.Rows[i].Cells[5].Value);

                    if (stock <= stockMin)
                    {
                        dataListado.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }

        }
        private void formatoColumnas()
        {

            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[1].Width = 130;
            this.dataListado.Columns[2].Width = 365;
            this.dataListado.Columns[3].Width = 160;
            this.dataListado.Columns[4].Width = 100;
           

            // this.dataListado.Columns[7].Width = 120;

            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.DefaultCellStyle.Font = new Font("Roboto", 8);
          //  this.dataListado.RowsDefaultCellStyle.BackColor = Color.White;
            //this.dataListado.GridColor = SystemColors.ActiveBorder;
            

        }
        private void frmStockActual_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            
            //this.MostrarProductos();
           
           this.rbTodos.Checked = true;

        }

        private void rbInusmos_CheckedChanged(object sender, EventArgs e)
        {
            this.MostrarInsumos();
        }

        private void rbProductos_CheckedChanged(object sender, EventArgs e)
        {
            this.MostrarProductos();
            this.txtBuscar.Select();
            rbNombre.Checked = true;
        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbProductos.Checked == true)
            {
                this.MostrarProductos();
            } else if (rbInusmos.Checked == true)
            {
                this.MostrarInsumos();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if(this.rbInusmos.Checked == true && this.rbNombre.Checked== true)
            {
                this.BuscarInsumo_Almacen();
                stockMinimoI();
            }else if(this.rbProductos.Checked == true && this.rbNombre.Checked == true)
            {
                this.BuscarProducto_Almacen();
                stockMinimo();
            }




        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if(rbProductos.Checked== true)
            {
                frmRProductoStock frm = new frmRProductoStock();
                frm.ShowDialog();
            }else
            {
                frmRInsumoStock frm = new frmRInsumoStock();
                frm.ShowDialog();
            }
        }

        private void frmStockActual_FormClosed(object sender, FormClosedEventArgs e)
        {
    
        }
    }
}
