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
    public partial class frmMovimientoCaja : Form
    {
        public static frmMovimientoCaja f1;
        public frmMovimientoCaja()
        {
            InitializeComponent();
            frmMovimientoCaja.f1 = this;
        }

        private void frmMovimientoCaja_Load(object sender, EventArgs e)
        {
            this.lblFechaHoy.Text = DateTime.Now.ToString();
            dataListado.DataSource = NCaja.mostrarMovimientoCaja(Convert.ToDateTime(this.lblFechaApertura.Text),Convert.ToDateTime(this.lblFechaHoy.Text));
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
            }
            else
            {
                this.dataListado.Visible = true;


                // DataGridView1.Columns(1).Width = 150
                this.dataListado.Columns[0].Width = 70;
                this.dataListado.Columns[1].Width = 250;
                this.dataListado.Columns[2].Width = 120;
                this.dataListado.Columns[3].Width = 285;
                this.dataListado.Columns[4].Width = 305;
                this.dataListado.Columns[5].Width = 105;
                this.dataListado.Columns[6].Width = 175;

                this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                this.dataListado.DefaultCellStyle.Font = new Font("Roboto", 9);
                this.dataListado.RowsDefaultCellStyle.BackColor = Color.White;
                this.dataListado.GridColor = SystemColors.ActiveBorder;
                this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
                this.dataListado.ClearSelection();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmRMovimientoCaja frm = new frmRMovimientoCaja();
            frm.ShowDialog();
        }
    }
}
