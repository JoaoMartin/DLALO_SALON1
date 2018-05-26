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
    public partial class frmMostrarVentas : Form
    {
        public static frmMostrarVentas f1;
        public frmMostrarVentas()
        {
            InitializeComponent();
            frmMostrarVentas.f1 = this;
        }
        public void MostrarTodo()
        {
            string fechaInicio = dtpFechaInicio.Value.ToString("yyyy-MM-dd");
            string fechaFin = dtpFechaFin.Value.ToString("yyyy-MM-dd");

            this.dataListado.DataSource = NVenta.reporteVentaFechas(Convert.ToDateTime(fechaInicio + " 00:00:00"), Convert.ToDateTime(fechaFin + " 23:59:59"));
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
            }
            else
            {
                
                this.dataListado.Visible = true;
                decimal total = 0;
                for (int i = 0; i < this.dataListado.Rows.Count; i++)
                {
                    total = total + Convert.ToDecimal(this.dataListado.Rows[i].Cells["Monto"].Value.ToString());
                }
                this.lblSumaTotal.Text = total.ToString();
                ocultarColumnas();
            }
        }

        private void Mostrar()
        {
            
                string fechaInicio = "";
                string fechaFin = "";
                int totalCan = 0;
                if (rbAperturaCaja.Checked == true)
                {
                    //fecIn = Convert.ToDateTime(frmPrincipal.f1.lblFechaApertura.Text);
                    //fechaInicio = fecIn.ToString("yyyy-MM-dd hh:mm:ss");
                    fechaInicio = frmPrincipal.f1.lblFechaApertura.Text;
                    // fechaFin = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    fechaFin = DateTime.Now.ToString();
                }
                else if (rbElegir.Checked == true)
                {
                    fechaInicio = dtpFechaInicio.Value.ToString("yyyy-MM-dd" + " 00:00:00");
                    fechaFin = dtpFechaFin.Value.ToString("yyyy-MM-dd" + " 23:59:59");
                }

                //this.lblCaja.Text = "0";
                this.dataListado.DataSource = NVenta.reporteVentaFechas(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin));
                for (int i = 0; i < dataListado.Rows.Count; i++)
                {
                    totalCan = totalCan + Convert.ToInt32(dataListado.Rows[i].Cells[6].Value.ToString());
                }
                //lblCant.Text = totalCan.ToString();
                lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

                if (this.dataListado.Rows.Count == 0)
                {
                    this.dataListado.Visible = false;
                   
                    btnImprimir.Enabled = false;
                    //ocultarColumnas();
                }
                else
                {

                    this.dataListado.Visible = true;
                    btnImprimir.Enabled = true;
                    ocultarColumnas();
                    decimal totalVentas = 00.00m;
                    for (int i = 0; i < dataListado.Rows.Count; i++)
                    {
                    totalVentas = totalVentas + Convert.ToDecimal(dataListado.Rows[i].Cells[13].Value.ToString());
                    }
                        lblSumaTotal.Text = totalVentas.ToString();
                }

         
            

        }


        private void ocultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[14].Visible = false;
            this.dataListado.Columns[15].Visible = false;
            this.dataListado.Columns[16].Visible = false;
            this.dataListado.Columns[17].Visible = false;
            this.dataListado.Columns[18].Visible = false;
            //  this.dataListado.Columns[1].Visible = false;

            //DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[1].Width = 80;
            this.dataListado.Columns[2].Width = 170;
            this.dataListado.Columns[3].Width = 80;
            this.dataListado.Columns[4].Width = 180;
            this.dataListado.Columns[5].Width = 100;
            this.dataListado.Columns[6].Width = 120;
            this.dataListado.Columns[7].Width = 200;
            this.dataListado.Columns[9].Width = 200;
            this.dataListado.Columns[10].Width = 200;

            this.dataListado.RowTemplate.Height = 28;
            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListado.Font = new Font("Roboto", 9);
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }

        public void botones(bool valor)
        {

            //this.btnEliminar.Enabled = valor;
            this.btnCancelar.Enabled = valor;
            this.btnImprCompr.Enabled = valor;
            this.btnCambioComprobante.Enabled = valor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MostrarTodo();
            Mostrar();
              
        }

        private void frmReporteVentaFechas_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            botones(false);
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void cbEliminar_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Está seguro de anular el comprobante?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (opcion == DialogResult.OK)
                {
                    if(this.lblComprobante.Text == "TICKETS")
                    {
                        string rpta = "";
                        rpta = NComprobante.AnularComprobante(Convert.ToInt32(this.lblIdComprobante.Text));
                        if (rpta.Equals("OK"))
                        {
                            MessageBox.Show("Se anuló correctamente");
                            this.MostrarTodo();
                            this.btnEliminar.Enabled = false;
                            this.btnCancelar.Enabled = false;
                        }
                    }
                    else
                    {
                        frmAnularComprobante frm = new frmAnularComprobante();
                        frm.lblBandera.Text = "0";
                        frm.ShowDialog();
                    }
                 
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void btnCancelar_Click(object sender, EventArgs e)
        {
            botones(false);
            
            MostrarTodo();
            dataListado.ClearSelection();
         
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmReporteDetalleVenta form = new frmReporteDetalleVenta();
            form.lblIdVenta.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Cod"].Value);
            form.lblTipo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Estado_Venta"].Value);
            form.ShowDialog();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

                frmRMostrarVentas frm = new frmRMostrarVentas();
                frm.ShowDialog();

           
        }

        private void dataListado_Click(object sender, EventArgs e)
        {
            this.lblIdComprobante.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idComprobante"].Value);
            this.lblSerie.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Serie"].Value);
            this.lblNumero.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["NroCompr"].Value);
            this.lblComprobante.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Comprobante"].Value);
            this.lblFechaGene.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Fecha"].Value);
            this.lblIdVenta.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Cod"].Value);
            this.lblDcto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Dcto"].Value);
            this.lblIgv.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["IGV"].Value);
            this.lblTotalVenta.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Monto"].Value);
            this.lblVuelto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["vuelto"].Value);
            this.lblEfectivo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["efectivo"].Value);
            this.lblTarjeta.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tarjeta"].Value);
            this.lblForma.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["formaPago"].Value);
            this.lblRedondeo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["redondeo"].Value);
            this.btnEliminar.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.btnImprCompr.Enabled = true;


            if(this.lblComprobante.Text == "BOLETA MANUAL" || this.lblComprobante.Text == "FACTURA MANUAL")
            {
                btnCambioComprobante.Enabled = false;
                btnEliminar.Enabled = false;
                
            }else
            {
                btnCambioComprobante.Enabled = false;
               // btnEliminar.Enabled = false;
            }
            if (this.lblComprobante.Text == "TICKET")
            {
                this.btnCambioComprobante.Enabled = true;
                this.btnEliminar.Enabled = true;
            }
            else
            {
                this.btnCambioComprobante.Enabled = false;
            }

            if(lblComprobante.Text == "BOLETA")
            {
                this.btnEliminar.Enabled = false;
            }else
            {
                this.btnEliminar.Enabled = true;
            }
        }

        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        public void Imprimir()
        {
            DataTable dtCliente = NVenta.mostrarClienteVenta(Convert.ToInt32(this.lblIdVenta.Text));
            string cliente = "";
            string direccion = "";
            string nroDoc = "";
            string mesa = "";
            string salon = "";
            string tel = "";
            string fecha = "";
            decimal totalDcto = 00.00m;
            if (dtCliente.Rows.Count == 1)
            {
                cliente = "PUBLICO GENERAL";
                mesa = dtCliente.Rows[0][0].ToString();
                salon = dtCliente.Rows[0][1].ToString();
                fecha = dtCliente.Rows[0][2].ToString();
            }
            else
            {
                cliente = dtCliente.Rows[0][0].ToString();
                direccion = dtCliente.Rows[0][1].ToString();
                nroDoc = dtCliente.Rows[0][2].ToString();
                tel = dtCliente.Rows[0][3].ToString();
                mesa = dtCliente.Rows[1][0].ToString();
                salon = dtCliente.Rows[1][1].ToString();
                fecha = dtCliente.Rows[1][4].ToString();
            }

            this.dataDetalle.DataSource = NVenta.reporteDetalleVenta(Convert.ToInt32(this.lblIdVenta.Text));
            for (int i = 0; i < dataDetalle.Rows.Count; i++)
            {
                totalDcto = totalDcto + Convert.ToInt32(dataDetalle.Rows[i].Cells[4].Value);
            }

            decimal subTotal = Convert.ToDecimal(this.lblTotalVenta.Text) - Convert.ToDecimal(this.lblIgv.Text);
            decimal efectivo1 = 00.00m;
            if (this.lblForma.Text == "EFECTIVO")
            {
                efectivo1 = Convert.ToDecimal(this.lblTotalVenta.Text) + Convert.ToDecimal(this.lblVuelto.Text);
            }
            else if (this.lblForma.Text == "TARJETA")
            {
                efectivo1 = 00.00m;
            }
            else if (this.lblForma.Text == "MIXTO")
            {
                efectivo1 = Convert.ToDecimal(this.lblEfectivo.Text);
            }
           
            if(lblComprobante.Text =="FACTURA MANUAL" || lblComprobante.Text == "BOLETA MANUAL")
            {
                NImprimir_Comprobante.imprimirComRepetidoManual(this.lblSerie.Text, this.lblNumero.Text, this.lblComprobante.Text, cliente, direccion, nroDoc, salon, mesa, dataDetalle, totalDcto.ToString(), this.lblDcto.Text,
            subTotal.ToString(), this.lblIgv.Text, this.lblTotalVenta.Text, efectivo1.ToString(),
            this.lblTarjeta.Text, this.lblForma.Text, "Detallado", this.lblRedondeo.Text, tel, lblVuelto.Text,DateTime.Now.ToString());
                this.dataListado.ClearSelection();
            }else
            {
                NImprimir_Comprobante.imprimirComRepetido(this.lblNumero.Text, this.lblComprobante.Text, cliente, direccion, nroDoc, salon, mesa, dataDetalle, totalDcto.ToString(), this.lblDcto.Text,
            subTotal.ToString(), this.lblIgv.Text, this.lblTotalVenta.Text, efectivo1.ToString(),
            this.lblTarjeta.Text, this.lblForma.Text, "Detallado", this.lblRedondeo.Text, tel, lblVuelto.Text, DateTime.Now.ToString(),frmPrincipal.f1.lblUsuario.Text + frmPrincipal.f1.lblApellidos.Text);
                this.dataListado.ClearSelection();
            }
        
        }
        private void btnImprCompr_Click(object sender, EventArgs e)
        {
            try
            {
                // NImprimir_Comprobante.imprimirCom(Convert.ToInt32(this.lblid))

                this.Imprimir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se completó la operación");
            }
        }

        private void btnCambioComprobante_Click(object sender, EventArgs e)
        {
            frmCambioComprobante frm = new frmCambioComprobante();
            frm.ShowDialog();
        }

        private void frmMostrarVentas_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void frmMostrarVentas_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

        private void rbElegir_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAperturaCaja.Checked == true)
            {
                groupBox1.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = true;
            }
        }

        private void rbAperturaCaja_CheckedChanged(object sender, EventArgs e)
        {
            if(rbAperturaCaja.Checked == true)
            {
                groupBox1.Enabled = false;
            }else
            {
                groupBox1.Enabled = true;
            }
        }
    }
}
