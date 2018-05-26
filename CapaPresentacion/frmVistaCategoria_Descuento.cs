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
    public partial class frmVistaCategoria_Descuento : Form
    {
        public frmVistaCategoria_Descuento()
        {
            InitializeComponent();
        }

        private void ocultarColumnas()
        {

            this.dataListado.Columns[3].Visible = false;

            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[0].Width = 70;
            this.dataListado.Columns[1].Width = 220;
            this.dataListado.Columns[2].Width = 385;

            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }
        private void Mostrar()
        {
            this.dataListado.DataSource = NCategoria.Mostrar();

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
            this.dataListado.DataSource = NCategoria.Buscar(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void frmVistaCategoria_Descuento_Load(object sender, EventArgs e)
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
