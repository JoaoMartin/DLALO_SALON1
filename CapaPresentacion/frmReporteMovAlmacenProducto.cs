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
    public partial class frmReporteMovAlmacenProducto : Form
    {
        public frmReporteMovAlmacenProducto()
        {
            InitializeComponent();
        }

        private void cargarProducto()
        {
            cbProducto.DataSource = NProducto.MostrarArticuloReporte();
            cbProducto.ValueMember = "Codigo";
            cbProducto.DisplayMember = "Nombre";
            cbProducto.SelectedIndex = -1;
            //lblPrueba.Text = cbCategoria.SelectedValue.ToString();

        }

        private void Mostrar()
        {
            if (cbProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un producto de la lista");
            }
            else
            {
               string tipo="";
                 if(rbIngreso.Checked == true)
                {
                    tipo = "INGRESO";
                }else
                {
                    tipo = "SALIDA";
                }

                this.lblCaja.Text = "0";
                this.dataListado.DataSource = NMovimientoAlmacen.mostrarMovAlmacenProducto(Convert.ToInt32(cbProducto.SelectedValue),tipo);
                decimal cant = 00.00m;
                for (int i = 0; i < dataListado.Rows.Count; i++)
                {
                    cant = cant + Convert.ToDecimal(dataListado.Rows[i].Cells[1].Value.ToString());
                   
                }
                lblCant.Text = cant.ToString();
                lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

                if (this.dataListado.Rows.Count == 0)
                {
                    this.dataListado.Visible = false;
                    lblCant.Text = "0";
                    btnImprimir.Enabled = false;
                    //ocultarColumnas();
                }
                else
                {

                    this.dataListado.Visible = true;
                    btnImprimir.Enabled = true;
                    ocultarColumnas();
                }
            }

        }

        private void ocultarColumnas()
        {
          

            //DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[0].Width = 350;
            this.dataListado.Columns[1].Width = 200;
            this.dataListado.Columns[2].Width = 320;

            this.dataListado.RowTemplate.Height = 28;
            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListado.Font = new Font("Roboto", 9);
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }
        private void frmReporteMovAlmacenProducto_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            cargarProducto();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mostrar();
        }
    }
}
