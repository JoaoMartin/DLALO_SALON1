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
    public partial class frmConsultaCierreCaja : Form
    {
        public frmConsultaCierreCaja()
        {
            InitializeComponent();
        }
        private void ocultarColumnas()
        {

            this.dataListado.Columns[10].Visible = false;

            this.dataListado.Columns[0].Width = 85;
            this.dataListado.Columns[1].Width = 335;
            this.dataListado.Columns[2].Width = 135;

            
            this.dataListado.RowTemplate.Height = 28;
            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListado.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            this.dataListado.GridColor = SystemColors.ActiveBorder;
   

        }
        private void Mostrar()
        {
            this.dataListado.DataSource = NCaja_A.MostrarFechaCierre(1);
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

                //this.dataListado.CurrentCell = null;
              

            }
        }

        private void frmConsultaCierreCaja_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmRConsultaCierre frm = new frmRConsultaCierre();
            frm.ShowDialog();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmDetalleCierreCaja frm = new frmDetalleCierreCaja();
            int posicion = dataListado.CurrentRow.Index;
            if (posicion == 0)
            {
                frm.lblFechaInicio.Text = this.lblFechaInicio.Text;
                frm.lblFechaCorte.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Fecha"].Value);
            }
            else
            {
                frm.lblFechaInicio.Text = dataListado.Rows[posicion - 1].Cells["Fecha"].Value.ToString();
                frm.lblFechaCorte.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Fecha"].Value);
            }
            frm.ShowDialog();
        }
    }
}
