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
    public partial class frmDetalleCorteCaja : Form
    {
        public frmDetalleCorteCaja()
        {
            InitializeComponent();
        }

        private void ocultarColumnas()
        {


            this.dataListado.Columns[0].Width = 50;
            this.dataListado.Columns[1].Width = 300;
            this.dataListado.Columns[2].Width = 100;
            this.dataListado.Columns[3].Width = 130;
            this.dataListado.Columns[4].Width = 300;

            this.dataListado.RowTemplate.Height = 28;
            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListado.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }
        private void Mostrar()
        {
            this.dataListado.DataSource = NCaja.mostrarMovimientoCaja(Convert.ToDateTime(this.lblFechaInicio.Text), Convert.ToDateTime(this.lblFechaCorte.Text));
            lblTotal1.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
            }
            else
            {
                this.dataListado.Visible = true;
                this.ocultarColumnas();
                decimal totalEfectivo = 00.00m;
                decimal totalEgreso = 00.00m;
                decimal totalTarjeta = 00.00m;
                for(int i = 0; i < dataListado.Rows.Count; i++)
                {
                  

                    if (dataListado.Rows[i].Cells[2].Value.ToString() == "Ingreso" || dataListado.Rows[i].Cells[2].Value.ToString() == "INGRESO")
                    {
                        totalEfectivo = totalEfectivo + Convert.ToDecimal(dataListado.Rows[i].Cells[6].Value.ToString());
                    }

                    if (dataListado.Rows[i].Cells[2].Value.ToString() == "EGRESO" || dataListado.Rows[i].Cells[2].Value.ToString() == "Egreso")
                    {
                        totalEgreso = totalEgreso + Convert.ToDecimal(dataListado.Rows[i].Cells[6].Value.ToString());
                    }

                    if (dataListado.Rows[i].Cells[5].Value.ToString() == "TARJETA")
                    {
                        totalTarjeta = totalTarjeta + Convert.ToDecimal(dataListado.Rows[i].Cells[6].Value.ToString());
                    }

                }
                this.lblTotalEfecitov.Text = (totalEfectivo - totalTarjeta).ToString();
                this.lblTotalTarjeta.Text = totalTarjeta.ToString();
                this.lblTotalEgresos.Text = totalEgreso.ToString();

                this.lblTotalMovEfec.Text = (totalEfectivo - totalEgreso - totalTarjeta).ToString();

            }
        }

 
        private void frmDetalleCorteCaja_Load(object sender, EventArgs e)
        {
            Mostrar();
        }
    }
}
