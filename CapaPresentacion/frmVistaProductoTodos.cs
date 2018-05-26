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
    public partial class frmVistaProductoTodos : Form
    {
        public frmVistaProductoTodos()
        {
            InitializeComponent();
        }

        private void ocultarColumnas()
        {

            this.dataListado.Columns[1].Visible = false;
            this.dataListado.Columns[4].Visible = false;
            this.dataListado.Columns[5].Visible = false;
            this.dataListado.Columns[6].Visible = false;
            this.dataListado.Columns[7].Visible = false;
            this.dataListado.Columns[8].Visible = false;
            this.dataListado.Columns[9].Visible = false;
            this.dataListado.Columns[10].Visible = false;
            this.dataListado.Columns[11].Visible = false;
            this.dataListado.Columns[12].Visible = false;
            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[0].Width = 70;
            this.dataListado.Columns[1].Width = 220;
            this.dataListado.Columns[2].Width = 385;
            this.dataListado.Columns[3].Width = 385;

            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }
        private void Mostrar()
        {
            this.dataListado.DataSource = NProducto.MostrarTodos();

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
            this.dataListado.DataSource = NProducto.BuscarNombeProductoTodos(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void frmVistaProductoTodos_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
       
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
