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
    public partial class frmMostrarCortes : Form
    {
        public frmMostrarCortes()
        {
            InitializeComponent();
        }


        private void ocultarColumnas()
        {


            this.dataListado.Columns[0].Width = 85;
            this.dataListado.Columns[1].Width = 350;
            this.dataListado.Columns[2].Width = 150;


            this.dataListado.RowTemplate.Height = 28;
            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListado.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }
        private void Mostrar()
        {
            this.dataListado.DataSource = NCaja_A.MostrarFechaCorte(1);
            lblTotal1.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
            }
            else
            {
                this.dataListado.Visible = true;
                this.ocultarColumnas();
                DataTable dtFecha = NCaja_A.MostrarMontoCaja(1);
                lblFechaInicio.Text = dtFecha.Rows[0]["fecha"].ToString();

            }
        }
        private void frmMostrarCortes_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();

        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmDetalleCorteCaja frm = new frmDetalleCorteCaja();
            int posicion = dataListado.CurrentRow.Index;
            if(posicion == 0)
            {
                frm.lblFechaInicio.Text = this.lblFechaInicio.Text;
                frm.lblFechaCorte.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Fecha"].Value);
            }else
            {
                frm.lblFechaInicio.Text = dataListado.Rows[posicion - 1].Cells["Fecha"].Value.ToString();
                frm.lblFechaCorte.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Fecha"].Value);
            }
            frm.ShowDialog();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmRMostrarCortes frm = new frmRMostrarCortes();
            frm.ShowDialog();
        }
    }
}
