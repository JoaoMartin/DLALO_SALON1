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
    public partial class frmVistaClientePago_Dividido : Form
    {
        public frmVistaClientePago_Dividido()
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

        private void Mostrar()
        {
            this.dataListado.DataSource = NCliente.Mostrar();
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

        private void BuscarDni()
        {
            this.dataListado.DataSource = NCliente.BuscarDni(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            this.lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void Buscar()
        {
            this.dataListado.DataSource = NCliente.Buscar(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            this.lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void frmVistaClientePago_Dividido_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (this.rbTipoDoc.Checked == true)
            {
                this.BuscarDni();
            }
            else if (this.rbNombre.Checked == true || this.rbTodos.Checked == true)
            {
                this.Buscar();
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmPagarDividida.f1.txtIdCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            frmPagarDividida.f1.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Cliente"].Value);
            frmPagarDividida.f1.txtDocumento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nro_Doc"].Value);
            frmPagarDividida.f1.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["DIreccion"].Value);
            this.Close();
        }
    }
}
