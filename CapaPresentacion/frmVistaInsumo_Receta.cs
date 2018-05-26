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
    public partial class frmVistaInsumo_Receta : Form
    {
        public frmVistaInsumo_Receta()
        {
            InitializeComponent();
        }

        public void Mostrar()
        {
            this.dataListado.DataSource = NInsumo.Mostrar();

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
            this.dataListado.DataSource = NInsumo.Buscar(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void ocultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
            this.dataListado.Columns[3].Visible = false;
            this.dataListado.Columns[6].Visible = false;
            this.dataListado.Columns[7].Visible = false;
            this.dataListado.Columns[8].Visible = false;
            this.dataListado.Columns[9].Visible = false;
            this.dataListado.Columns[10].Visible = false;
            this.dataListado.Columns[12].Visible = false;
            // DataGridView1.Columns(1).Width = 150

            this.dataListado.Columns[2].Width = 345;
            this.dataListado.Columns[4].Width = 105;
            // this.dataListado.Columns[7].Width = 120;

            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.DefaultCellStyle.Font = new Font("Roboto", 9);
            this.dataListado.RowsDefaultCellStyle.BackColor = Color.White;
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }

        private void frmVistaInsumo_Receta_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmReceta.f1.lblIdInsumo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            frmReceta.f1.txtInsumo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            frmReceta.f1.txtCosto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Costo"].Value);
            frmReceta.f1.txtUnidad.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Unidad"].Value);
            frmReceta.f1.txtCantidadInsumo.Focus();
            frmReceta.f1.txtCantidadInsumo.ReadOnly = false;
            this.Hide();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }
    }
}
