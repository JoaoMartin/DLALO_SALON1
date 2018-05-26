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
    public partial class frmReceta : Form
    {
        private DataTable dtDetalle, dtDetalleReceta;
        private decimal subTotal, subTotalR;
        public static frmReceta f1;
        public frmReceta()
        {
            InitializeComponent();
            frmReceta.f1 = this;
        }
        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void limpiarDatatableR()
        {
            this.dtDetalleReceta.Clear();
            this.dataListadoDetalleR.DataSource = dtDetalleReceta;
            this.dataListadoDetalleR.Refresh();
            this.lblTotalR.Text = "00.00";
        }

        private void limpiarDetalleR()
        {
            this.lblIdInsumo.Text = "0";
            this.txtInsumo.Text = string.Empty;
            this.txtCantidadInsumo.Text = string.Empty;
            this.txtCosto.Text = string.Empty;
        }

        private void dataListadoDetalleR_DoubleClick(object sender, EventArgs e)
        {
            if (this.dataListadoDetalleR.Rows.Count > 0)
            {
                this.lblIdInsumo.Text = Convert.ToString(this.dataListadoDetalleR.CurrentRow.Cells["Codigo"].Value);
                this.txtInsumo.Text = Convert.ToString(this.dataListadoDetalleR.CurrentRow.Cells["Insumo"].Value);
                this.txtCantidadInsumo.Text = Convert.ToString(this.dataListadoDetalleR.CurrentRow.Cells["Cantidad"].Value);
                this.txtCosto.Text = Convert.ToString(this.dataListadoDetalleR.CurrentRow.Cells["Costo"].Value);
                subTotalR = Convert.ToDecimal(this.dataListadoDetalleR.CurrentRow.Cells["Importe"].Value);
                this.lblIdDetalleR.Text = this.dataListadoDetalleR.CurrentRow.Cells["idDetalleReceta"].Value.ToString();
                this.btnAgregarInsumo.Enabled = false;
                this.btnQuitarInsumo.Enabled = false;
                this.btnEditarInsumo.Enabled = true;
                this.txtCantidadInsumo.Focus();
                this.lblPosic.Text = dataListadoDetalleR.CurrentRow.Index.ToString();
                this.txtCantidadInsumo.ReadOnly = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmVistaInsumo_Receta form = new frmVistaInsumo_Receta();
            form.ShowDialog();
        }
        
        private void Agregar()
        {
            try
            {

                if (this.lblIdInsumo.Text == "0")
                {
                    MensajeError("Seleccione un insumo");
                    errorIcono.SetError(txtInsumo, "Seleccione un insumo");
                }

                else if (this.txtCantidadInsumo.Text.Trim() == string.Empty)
                {
                    MensajeError("Ingrese la cantidad");
                    errorIcono.SetError(txtCantidadInsumo, "Ingrese un valor");
                }

                else
                {
                    bool registrar = true;
                    foreach (DataRow row in dtDetalleReceta.Rows)
                    {
                        if (Convert.ToInt32(row["Codigo"]) == Convert.ToInt32(this.lblIdInsumo.Text))
                        {
                            registrar = false;
                            this.MensajeError("El insumo ya se encuentra agregado");
                        }
                    }

                    if (registrar)
                    {
                        decimal subTotalR = Convert.ToDecimal(this.txtCantidadInsumo.Text) * Convert.ToDecimal(this.txtCosto.Text);
                        DataRow row = this.dtDetalleReceta.NewRow();
                        row["Codigo"] = Convert.ToInt32(this.lblIdInsumo.Text);
                        row["Insumo"] = this.txtInsumo.Text;
                        row["Cantidad"] = Convert.ToDecimal(this.txtCantidadInsumo.Text);
                        row["costo"] = Convert.ToDecimal(this.txtCosto.Text);
                        row["Importe"] = subTotalR;
                        row["Unidad"] = this.txtUnidad.Text;
                        this.dtDetalleReceta.Rows.Add(row);
                        this.limpiarDetalleR();
                    }
                    this.lblIdInsumo.Text = "0";
                    this.dataListadoDetalleR.ClearSelection();
                    this.txtInsumo.Focus();
                    this.btnGuardarReceta.Enabled = true;
                    this.txtUnidad.Text = string.Empty;
                    decimal suma = 0;
                    for (int i = 0; i < dataListadoDetalleR.Rows.Count; i++)
                    {
                        suma = suma + Convert.ToDecimal(this.dataListadoDetalleR.Rows[i].Cells["Importe"].Value);
                    }
                    this.lblTotalR.Text = suma.ToString("#0.00#");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAgregarInsumo_Click(object sender, EventArgs e)
        {

            this.Agregar();
        }

        private void btnQuitarInsumo_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataListadoDetalleR.Rows.Count <= 0)
                {
                    MensajeError("No existen filas en la tabla");
                }
                else if (this.dataListadoDetalleR.SelectedRows.Count > 0)
                {
                    if (this.lblIdDetalleReceta.Text == "")
                    {
                        int indiceFila = this.dataListadoDetalleR.CurrentRow.Index;
                        DataRow row = this.dtDetalleReceta.Rows[indiceFila];

                        this.dtDetalleReceta.Rows.Remove(row);
                        this.dataListadoDetalleR.ClearSelection();
                        this.txtUnidad.Text = string.Empty;
                    }
                    else
                    {
                        DialogResult opcion;
                        string rpta = "";
                        int codigo, codDetalle;
                        opcion = MessageBox.Show("Está seguro de eliminar este insumo?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (opcion == DialogResult.OK)
                        {
                            int indiceFila = this.dataListadoDetalleR.CurrentRow.Index;
                            DataRow row = this.dtDetalleReceta.Rows[indiceFila];

                            codigo = Convert.ToInt32(row["Codigo"].ToString());
                            codDetalle = Convert.ToInt32(row["idDetalleReceta"].ToString());
                            rpta = NReceta.EliminarDetalle(codDetalle);
                            this.dtDetalleReceta.Rows.Remove(row);
                            this.dataListadoDetalleR.ClearSelection();
                            if (rpta == "OK")
                            {
                                MessageBox.Show("Se eliminó correctamente");
                                this.Hide();
                                frmPlato.f1.dataListado.ClearSelection();

                            }
                            else
                            {
                                MessageBox.Show(rpta);
                            }

                        }
                    }

                    if (this.dataListadoDetalleR.Rows.Count <= 0)
                    {
                        this.btnGuardarReceta.Enabled = false;
                    }

                    decimal suma = 0;
                    for (int i = 0; i < dataListadoDetalleR.Rows.Count; i++)
                    {
                        suma = suma + Convert.ToDecimal(this.dataListadoDetalleR.Rows[i].Cells["Importe"].Value);
                    }
                    this.lblTotalR.Text = suma.ToString("#0.00#");
                }
                else
                {
                    MensajeError("Seleccione una fila");
                }


            }
            catch (Exception ex)
            {
                MensajeError("No hay filas para remover" + ex);
            }
        }
        private void crearTablaReceta()
        {

            this.dtDetalleReceta = new DataTable("DetalleR");
            this.dtDetalleReceta.Columns.Add("Codigo", System.Type.GetType("System.Int32"));
            this.dtDetalleReceta.Columns.Add("Insumo", System.Type.GetType("System.String"));
            this.dtDetalleReceta.Columns.Add("Cantidad", System.Type.GetType("System.Decimal"));
            this.dtDetalleReceta.Columns.Add("Costo", System.Type.GetType("System.Decimal"));
            this.dtDetalleReceta.Columns.Add("Importe", System.Type.GetType("System.Decimal"));
            this.dtDetalleReceta.Columns.Add("Unidad", System.Type.GetType("System.String"));
            this.dataListadoDetalleR.DataSource = this.dtDetalleReceta;
            this.formatoTablaR();
        }

        private void formatoTablaR()
        {

            // DataGridView1.Columns(1).Width = 150
            this.dataListadoDetalleR.Columns[0].Width = 100;
            this.dataListadoDetalleR.Columns[1].Width = 390;
            this.dataListadoDetalleR.Columns[2].Width = 80;
            this.dataListadoDetalleR.Columns[3].Width = 80;
            this.dataListadoDetalleR.Columns[4].Width = 80;

            this.dataListadoDetalleR.ClearSelection();
            this.dataListadoDetalleR.ColumnHeadersDefaultCellStyle.Font = new Font(dataListadoDetalleR.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListadoDetalleR.GridColor = SystemColors.ActiveBorder;
        }


        public void mostrar()
        {
                decimal suma = 0;
                crearTablaReceta();
                this.lblNroFilaReceta.Text = Convert.ToString(this.dataListadoDetalleR.Rows.Count);

                dtDetalleReceta = NReceta.Mostrar(Convert.ToInt32(this.lblIdProdReceta.Text));
              
                //dataListado.DataSource = NProducto.MostrarDetalleProducto(Convert.ToInt32(this.txtIdProducto.Text));
                dataListadoDetalleR.DataSource = dtDetalleReceta;
                dataListadoDetalleR.ClearSelection();
                this.lblNroFilaReceta.Text = Convert.ToString(dataListadoDetalleR.Rows.Count);
                if (lblNroFilaReceta.Text != "0")
                {
                    for (int i = 0; i < Convert.ToInt32(this.lblNroFilaReceta.Text); i++)
                    {
                        suma = suma + Convert.ToDecimal(dataListadoDetalleR.Rows[i].Cells[4].Value.ToString());
                    }
                    this.lblTotalR.Text = suma.ToString("#0.00#");
             
                this.dataListadoDetalleR.Columns[6].Visible = false;
                    this.dataListadoDetalleR.Columns[7].Visible = false;
                lblIdReceta.Text = dtDetalleReceta.Rows[0][7].ToString();
                    //this.dataListadoDetalleR.Columns[5].Visible = false;

                }
                else
                {
              
                    this.dataListadoDetalleR.Columns[6].Visible = false;
                    this.dataListadoDetalleR.Columns[7].Visible = false;
                }
        }

        private void frmReceta_Load(object sender, EventArgs e)
        {
            this.mostrar();
        }

        private void dataListadoDetalleR_Click(object sender, EventArgs e)
        {
            this.lblIdDetalleReceta.Text = Convert.ToString(this.dataListadoDetalleR.CurrentRow.Cells[6].Value);
        }

        private void txtCantidadInsumo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.Agregar();
            }
        }

        private void btnEditarInsumo_Click(object sender, EventArgs e)
        {
            if (this.lblIdInsumo.Text == string.Empty)
            {
                MensajeError("Seleccione un insumo");
                errorIcono.SetError(txtInsumo, "Seleccione un valor");
            }

            else if (this.txtCantidadInsumo.Text.Trim() == string.Empty)
            {
                MensajeError("Ingrese la cantidad");
                errorIcono.SetError(txtCantidadInsumo, "Ingrese un valor");
            }
            else if (this.txtCosto.Text.Trim() == string.Empty)
            {
                MensajeError("Ingrese el costo");
                errorIcono.SetError(txtCosto, "Ingrese un valor");
            }

            else
            {
                if (this.lblIdDetalleR.Text == "")
                {
                    this.dataListadoDetalleR[3, Convert.ToInt32(this.lblPosic.Text)].Value = this.txtCosto.Text;
                    this.dataListadoDetalleR[2, Convert.ToInt32(this.lblPosic.Text)].Value = this.txtCantidadInsumo.Text;
                    decimal subTotal1 = Convert.ToDecimal(this.txtCantidadInsumo.Text) * Convert.ToDecimal(this.txtCosto.Text);
                    this.dataListadoDetalleR[4, Convert.ToInt32(this.lblPosic.Text)].Value = subTotal1;

                }
                else
                {
                    DialogResult opcion;
                    string rpta = "";
                    opcion = MessageBox.Show("Está seguro de editar este insumo?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (opcion == DialogResult.OK)
                    {
                        this.dataListadoDetalleR[3, Convert.ToInt32(this.lblPosic.Text)].Value = this.txtCosto.Text;
                        this.dataListadoDetalleR[2, Convert.ToInt32(this.lblPosic.Text)].Value = this.txtCantidadInsumo.Text;
                        decimal subTotal1 = Convert.ToDecimal(this.txtCantidadInsumo.Text) * Convert.ToDecimal(this.txtCosto.Text);
                        this.dataListadoDetalleR[4, Convert.ToInt32(this.lblPosic.Text)].Value = subTotal1;
                        rpta = NReceta.EditarDetalle(Convert.ToInt32(this.lblIdDetalleR.Text), Convert.ToDecimal(this.txtCantidadInsumo.Text));
                        if (rpta == "OK")
                        {
                            MessageBox.Show("Se editó correctamente");
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show(rpta);
                        }
                    }
                }

                this.dataListadoDetalleR.ClearSelection();
                this.limpiarDetalleR();
                this.btnEditarInsumo.Enabled = false;
                this.btnAgregarInsumo.Enabled = true;
                this.btnQuitarInsumo.Enabled = true;
                decimal suma = 0;
                for (int i = 0; i < dataListadoDetalleR.Rows.Count; i++)
                {
                    suma = suma + Convert.ToDecimal(this.dataListadoDetalleR.Rows[i].Cells["Importe"].Value);
                }
                this.lblTotalR.Text = suma.ToString("#0.00#");

            }
        }

        private void btnGuardarReceta_Click(object sender, EventArgs e)
        {
            string rpta = "";
            if (this.lblNroFilaReceta.Text == "0")
            {
                rpta = NReceta.Insertar(Convert.ToInt32(this.lblIdProdReceta.Text), "Receta " + this.lblPlato.Text, "A", dtDetalleReceta);
            }
            else
            {
                int nroFilaR = Convert.ToInt32(this.lblNroFilaReceta.Text);
                if (nroFilaR < dataListadoDetalleR.Rows.Count)
                {
                    int codigo, codReceta;
                    decimal costo, cantidad;
                    for (int i = nroFilaR; i < dataListadoDetalleR.Rows.Count; i++)
                    {
                        codigo = Convert.ToInt32(this.dataListadoDetalleR.Rows[i].Cells[0].Value.ToString());
                        cantidad = Convert.ToDecimal(this.dataListadoDetalleR.Rows[i].Cells["Cantidad"].Value.ToString());
                        costo = Convert.ToDecimal(this.dataListadoDetalleR.Rows[i].Cells[3].Value.ToString());
                        codReceta = Convert.ToInt32(this.dataListadoDetalleR.Rows[0].Cells[7].Value.ToString());
                        rpta = NReceta.InsertarAdicional(codReceta, codigo, cantidad, costo);
                    }
                    this.lblIdInsumo.Text = "0";
                }
            }

            if (rpta == "OK")
            {
                MensajeOK("Se guardó correctamente la receta");
                this.limpiarDatatableR();
                this.limpiarDetalleR();
                this.Hide();
            }
        }
    }
}
