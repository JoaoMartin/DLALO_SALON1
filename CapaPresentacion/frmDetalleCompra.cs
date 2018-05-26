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
    public partial class frmDetalleCompra : Form
    {
        public frmDetalleCompra()
        {
            InitializeComponent();
        }

        private void Formato()
        {


            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[0].Width = 80;
            this.dataListado.Columns[1].Width = 420;
            this.dataListado.Columns[2].Width = 120;
            this.dataListado.Columns[4].Width = 120;
            this.dataListado.Columns[5].Width = 120;

            this.dataListado.RowTemplate.Height = 28;
            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListado.Font = new Font("Roboto", 9);
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NCompra.mostrarDetalleIngreso(Convert.ToInt32(this.lblIdVenta.Text));
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
            }
            else
            {

                this.dataListado.Visible = true;
                Formato();
            }
        }
        private void frmDetalleCompra_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }
    }
}
