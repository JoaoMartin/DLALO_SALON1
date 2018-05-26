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
    public partial class frmVistaProveedorIngreso : Form
    {
        public static frmVistaProveedorIngreso f1;

        public frmVistaProveedorIngreso()
        {
            InitializeComponent();
            frmVistaProveedorIngreso.f1 = this;

        }

        private void ocultarColumnas()
        {
            
            this.dataListado.Columns[4].Visible = false;
            this.dataListado.Columns[5].Visible = false;
            this.dataListado.Columns[6].Visible = false;

            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[0].Width = 70;
            this.dataListado.Columns[1].Width = 280;

            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }

        public void Mostrar()
        {
            this.dataListado.DataSource = NProveedor.Mostrar();
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

        private void BuscarRazonSocial()
        {
            this.dataListado.DataSource = NProveedor.BuscarRazonSocial(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarRuc()
        {
            this.dataListado.DataSource = NProveedor.BuscarRuc(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void frmVistaProveedorIngreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.rbNombre.Checked = true;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (this.rbNombre.Checked)
            {
                this.BuscarRazonSocial();
            }
            else
            {
                this.BuscarRuc();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmCompra form = frmCompra.GetInstancia();
            string par1, par2,par3;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["Razon_Social"].Value);
            par3 = Convert.ToString(this.dataListado.CurrentRow.Cells["Direccion"].Value);
            form.setProveedor(par1, par2,par3);
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmProveedorRapido form = new frmProveedorRapido();
            form.ShowDialog();
   
        }

        private void frmVistaProveedorIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
