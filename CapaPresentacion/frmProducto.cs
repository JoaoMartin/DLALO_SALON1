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
using System.Globalization;

namespace CapaPresentacion
{
    public partial class frmProducto : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public static frmProducto f1;
        private DataTable dtDetalle, dtDetalleReceta;
        private decimal subTotal,subTotalR;
        private decimal totalPagado = 0, totalPagadoR;
        private decimal totalSubTotal = 0, totalSubTotalR=0;


        public frmProducto()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Producto");
            this.ttMensaje.SetToolTip(this.txtPrecioVenta, "Ingrese el Precio de Venta");
            this.ttMensaje.SetToolTip(this.cbCategoria, "Seleccione la categoría");
            frmProducto.f1 = this;
        }

        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar
        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtStockMinimo.Text = string.Empty;
            this.txtIdProducto.Text = string.Empty;

            this.cbEliminar.Checked = false;
            this.cbCategoria.SelectedIndex = -1;
            this.cbImprimir.SelectedIndex = -1;
            this.cbUnidad.SelectedIndex = -1;
        }

        //Habilitar Controles
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.cbCategoria.Enabled = valor;
            this.cbUnidad.Enabled = valor;
            this.txtPrecioVenta.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.txtStockMinimo.ReadOnly = !valor;
            this.cbImprimir.Enabled = valor;
            this.rbProducto.Enabled = valor;
            this.rbCompuesto.Enabled = valor;
            this.errorIcono.Clear();
        }

        //Habilitar Botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
                this.btnEliminar.Enabled = false;
               // this.rbPlato.Checked = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.btnEliminar.Enabled = false;
            }
        }


        private void limpiarDetalle()
        {
            this.lblIdProducto.Text = "0";
            this.lblIdDetalleCom.Text = "0";
            this.txtProductoCompuesto.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtPrecioVentaCompues.Text = string.Empty;
        }

        private void limpiarDatatable()
        {
            this.dtDetalle.Clear();
            this.dataListado.DataSource = dtDetalle;
            this.dataListado.Refresh();
            this.lblTotalVenta.Text = "00.00";
        }


        private void crearTabla()
        {

            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("Codigo", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Producto", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Cantidad", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Precio_Venta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Importe", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Tipo", System.Type.GetType("System.String"));
            this.dataListadoDetalle.DataSource = this.dtDetalle;
            this.formatoTabla();
        }

        private void crearTablaReceta()
        {

            this.dtDetalleReceta = new DataTable("DetalleR");
            this.dtDetalleReceta.Columns.Add("Codigo", System.Type.GetType("System.Int32"));
            this.dtDetalleReceta.Columns.Add("Insumo", System.Type.GetType("System.String"));
            this.dtDetalleReceta.Columns.Add("Cantidad", System.Type.GetType("System.Decimal"));
            this.dtDetalleReceta.Columns.Add("Costo", System.Type.GetType("System.Decimal"));
            this.dtDetalleReceta.Columns.Add("Importe", System.Type.GetType("System.Decimal"));
        }


        private void formatoTabla()
        {

            // DataGridView1.Columns(1).Width = 150
            this.dataListadoDetalle.Columns[0].Width = 100;
            this.dataListadoDetalle.Columns[1].Width = 390;
            this.dataListadoDetalle.Columns[2].Width = 80;
            this.dataListadoDetalle.Columns[3].Width = 80;
            this.dataListadoDetalle.Columns[4].Width = 80;
           
            this.dataListadoDetalle.ClearSelection();
            this.dataListadoDetalle.ColumnHeadersDefaultCellStyle.Font = new Font(dataListadoDetalle.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListadoDetalle.GridColor = SystemColors.ActiveBorder;
        }


        private void ocultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            //this.dataListado.Columns[].Visible = false;
            this.dataListado.Columns[8].Visible = false;
            this.dataListado.Columns[9].Visible = false;
            this.dataListado.Columns[10].Visible = false;
            this.dataListado.Columns[12].Visible = false;
            this.dataListado.Columns[13].Visible = false;
            //this.dataListado.Columns[14].Visible = false;


            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[1].Width = 100;
            this.dataListado.Columns[3].Width = 414;
            this.dataListado.Columns[4].Width = 465;
            this.dataListado.Columns[2].Width = 182;
  
           // this.dataListado.Columns[7].Width = 120;

            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.DefaultCellStyle.Font = new Font("Roboto", 8);
            this.dataListado.RowsDefaultCellStyle.BackColor = Color.White;
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NProducto.Mostrar();
           
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

        private void BuscarCategoria()
        {
            this.dataListado.DataSource = NProducto.BuscarCategoriaProducto(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarNombre()
        {
            this.dataListado.DataSource = NProducto.BuscarNombeProducto(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarDescripcion()
        {
            this.dataListado.DataSource = NProducto.BuscarDescripcionProducto(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarCodigo()
        {
            this.dataListado.DataSource = NProducto.BuscarCodigoProducto(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void cargarCategoria()
        {
            cbCategoria.DataSource = NCategoria.Mostrar();
            cbCategoria.ValueMember = "Codigo";
            cbCategoria.DisplayMember = "Categoria";
            cbCategoria.SelectedIndex = -1;
            //lblPrueba.Text = cbCategoria.SelectedValue.ToString();

        }

        private void cargarUnidad()
        {
            cbUnidad.DataSource = NUnidadMedida.Mostrar();
            cbUnidad.ValueMember = "Codigo";
            cbUnidad.DisplayMember = "Unidad_Medida";
            cbUnidad.SelectedIndex = -1;
            //lblPrueba.Text = cbCategoria.SelectedValue.ToString();

        }

        private void Guardar()
        {
            try
            {
                string rpta = "";
                string tipo = "";
                int idCategoria, idUnidad;
                int stock = 0;
                decimal stockMinimo = 00.00m;
                string sTexto = "";
                string imprimir = "";

                if (this.cbCategoria.SelectedIndex == -1 && rbCompuesto.Checked == false)
                {
                    MensajeError("Seleccione una categoría");
                    errorIcono.SetError(cbCategoria, "Seleccione una categoría");
                }
                else if (this.cbUnidad.SelectedIndex == -1 )
                {
                    MensajeError("Seleccione una tipo de medida");
                    errorIcono.SetError(cbCategoria, "Seleccione una medida");
                }

                else if (this.txtPrecioVenta.Text.Trim() == string.Empty)
                {
                    MensajeError("Ingrese el precio de venta");
                    errorIcono.SetError(txtPrecioVenta, "Ingrese precio de venta");

                }
                else if (this.txtPrecioVenta.Text.Trim() != string.Empty)
                {
                    sTexto = this.txtPrecioVenta.Text.Substring(0, 1);
                    if (sTexto == ".")
                    {
                        MensajeError("Ingrese un precio de venta válido");
                        errorIcono.SetError(txtPrecioVenta, "Precio de Venta válido");
                    }
                    else
                    {
                        
                        if(this.cbImprimir.SelectedIndex == -1)
                        {
                            imprimir = "";
                        }
                        else
                        {
                            imprimir = this.cbImprimir.SelectedItem.ToString();
                        }
                       
                        if(rbProducto.Checked == true)
                        {
                            tipo = "A";
                            idCategoria = Convert.ToInt32(this.cbCategoria.SelectedValue.ToString());
                            idUnidad = Convert.ToInt32(this.cbUnidad.SelectedValue.ToString());
                        }
                        else 
                        {
                            tipo = "C";
                            idCategoria = Convert.ToInt32(this.lblIdCategoria.Text);
                            idUnidad = Convert.ToInt32(this.cbUnidad.SelectedValue.ToString());
                        }

                        if(this.txtStockMinimo.Text.Trim() != "")
                        {
                            stockMinimo = Convert.ToDecimal(this.txtStockMinimo.Text.Trim());
                        }
                        else
                        {
                            stockMinimo = 0;
                        }


                        if (this.IsNuevo)
                        {
                            if(rbCompuesto.Checked == true)
                            {
                                rpta = NProducto.InsertarProductoCompuesto(this.txtNombre.Text.Trim().ToUpper(), txtDescripcion.Text.Trim(), stock,
                                                  Convert.ToDecimal(this.txtPrecioVenta.Text.Trim()), tipo,"A", idCategoria, imprimir, stockMinimo,00.00m, dtDetalle,idUnidad);
                                limpiarDetalle();
                                limpiarDatatable();
                                this.lblIdProductoCom.Text = "0";
                                this.lblTotalVenta.Text = "00.00";
                                this.rbProducto.Checked = true;
                                this.btnNuevo.Enabled = true;
                            }
                            else
                            {
                                rpta = NProducto.Insertar(this.txtNombre.Text.Trim().ToUpper(), txtDescripcion.Text.Trim(), stock,
                                                  Convert.ToDecimal(this.txtPrecioVenta.Text.Trim()), tipo, "A", idCategoria, imprimir, stockMinimo,00.00m,idUnidad);
                                this.lblIdProductoCom.Text = "0";
                                this.lblTotalVenta.Text = "00.00";
                                this.rbProducto.Checked = true;
                                this.btnNuevo.Enabled = true;
                            }
                        
                        }
                        else
                        {
                            if(rbCompuesto.Checked == true)
                            {
                                int nroFilas = Convert.ToInt32(this.lblNroFilas.Text);

                                rpta = NProducto.Editar(Convert.ToInt32(this.txtIdProducto.Text), this.txtNombre.Text.Trim().ToUpper(), txtDescripcion.Text.Trim(), stock,
                                   Convert.ToDecimal(this.txtPrecioVenta.Text.Trim()), tipo, "A", idCategoria, imprimir,stockMinimo,00.00m,idUnidad);
                                if(nroFilas < dataListadoDetalle.Rows.Count && rpta =="OK")
                                {
                                    int cantidad, codigo;
                                    decimal precioVenta;
                                    string nombre;
                                    
                                    for (int i = nroFilas; i < dataListadoDetalle.Rows.Count; i++)
                                    {
                                        codigo = Convert.ToInt32(this.dataListadoDetalle.Rows[i].Cells[0].Value.ToString());
                                        cantidad = Convert.ToInt32(this.dataListadoDetalle.Rows[i].Cells[2].Value.ToString());
                                        precioVenta = Convert.ToDecimal(this.dataListadoDetalle.Rows[i].Cells[3].Value.ToString());
                                        nombre = this.dataListadoDetalle.Rows[i].Cells[1].Value.ToString();
                                        tipo = this.dataListadoDetalle.Rows[i].Cells[6].Value.ToString();
                                        rpta = NProducto.EditarProductoCompuesto(Convert.ToInt32(this.txtIdProducto.Text), cantidad, precioVenta, codigo, nombre,tipo);
                                    }
                                    this.lblIdProductoCom.Text = "0";
                                }
                                
                            }
                            else
                            {
                                rpta = NProducto.Editar(Convert.ToInt32(this.txtIdProducto.Text), this.txtNombre.Text.Trim().ToUpper(), txtDescripcion.Text.Trim(), stock,
                                     Convert.ToDecimal(this.txtPrecioVenta.Text.Trim()), tipo, "A", idCategoria, imprimir, stockMinimo,00.00m,idUnidad);
                                this.lblIdProductoCom.Text = "0";
                            }
           
                        }

                        if (rpta.Equals("OK"))
                        {
                            if (this.IsNuevo)
                            {
                                this.MensajeOK("Se insertó correctamente");
                                this.groupBox2.Visible = false;
                            }
                            else
                            {
                                this.MensajeOK("Se actualizó correctamente");
                                this.groupBox2.Visible = false;
                            }
                        }
                        else
                        {
                            this.MensajeError(rpta);
                        }

                        this.IsNuevo = false;
                        this.IsEditar = false;
                        this.Botones();
                        this.Limpiar();
                        this.Mostrar();
                        this.tabControl2.SelectedIndex = 0;
                        this.lblIdProductoCom.Text = "0";
                        this.lblTotalVenta.Text = "00.00";
                        this.rbProducto.Checked = true;
                        this.btnNuevo.Enabled = true;
                        txtPrecioVenta.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.cargarCategoria();
            this.cargarUnidad();
            this.rbTodos.Checked = true;
           
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.cbCategoria.Focus();
            this.dataListado.ClearSelection();
            this.tabControl2.SelectedIndex = 1;
            this.groupBox2.Visible = false;
            this.rbProducto.Checked = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.Guardar();
        }

        private void dataListado_Click(object sender, EventArgs e)
        {
            string tipo;
            string idCategoria, idUnidad;
            if (this.IsNuevo)
            {
                this.Habilitar(false);
                
                this.btnGuardar.Enabled = false;
            }
            this.btnEditar.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.txtIdProducto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            this.lblIdProductoCom.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Descripcion"].Value);
            this.txtStockMinimo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["stockMinimo"].Value);

            //this.cbCategoria.SelectedItem = Convert.ToString(this.dataListado.CurrentRow.Cells["Categoria"].Value);
            this.txtPrecioVenta.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Precio_Venta"].Value);
            idCategoria = Convert.ToString(this.dataListado.CurrentRow.Cells["idCategoria"].Value);
            idUnidad = Convert.ToString(this.dataListado.CurrentRow.Cells["idUnidadMedida"].Value);

            tipo = Convert.ToString(this.dataListado.CurrentRow.Cells["Tipo"].Value);
            if(tipo=="A")
            {
                rbProducto.Checked = true;
                this.txtStockMinimo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["stockMinimo"].Value);
            }
            else if (tipo == "C")
            {
                rbCompuesto.Checked = true;
                this.txtStockMinimo.Text = "";
                this.lblTipo.Text = "C";
            }

            cbCategoria.SelectedValue = idCategoria;
            cbUnidad.SelectedValue = idUnidad;
            cbImprimir.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["Imprimir_En"].Value);
            this.lblTipo.Text = tipo;
           // this.btnReceta.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdProducto.Text.Equals(""))
            {
                this.tabControl2.SelectedIndex = 1;
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
                this.txtNombre.Focus();

                if (rbProducto.Checked == true)
                {
                    this.txtStockMinimo.ReadOnly = false;
                }else if(rbCompuesto.Checked == true)
                {
                    groupBox2.Visible = true;
                    decimal suma = 0;
                    this.txtStockMinimo.ReadOnly = true;
                    //crearTabla();
                    dtDetalle = NProducto.MostrarDetalleProducto(Convert.ToInt32(this.txtIdProducto.Text));
                    //dataListado.DataSource = NProducto.MostrarDetalleProducto(Convert.ToInt32(this.txtIdProducto.Text));
                    dataListadoDetalle.DataSource = dtDetalle;
                    dataListadoDetalle.ClearSelection();
                    this.lblNroFilas.Text = Convert.ToString(dataListadoDetalle.Rows.Count);
                    if(lblNroFilas.Text != "0")
                    {
                        for (int i = 0; i < Convert.ToInt32(this.lblNroFilas.Text); i++)
                        {
                            suma = suma + Convert.ToDecimal(dataListadoDetalle.Rows[i].Cells[4].Value.ToString());
                            this.dataListadoDetalle.Columns[5].Visible = false;
                        }
                        this.lblTotalVenta.Text = suma.ToString();
                    }
                  
                }
            }
            else
            {
                this.MensajeError("Seleccione un registro");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Mostrar();
            this.Habilitar(false);
            this.dataListado.ClearSelection();
            this.rbProducto.Checked = false;
            this.tabControl2.SelectedIndex = 0;
            //this.dataListadoDetalle.Rows.Clear();
            this.groupBox2.Visible = false;
        }

        private void cbEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.btnEliminar.Enabled = false;
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                this.btnEliminar.Enabled = true;
                this.btnCancelar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnNuevo.Enabled = false;
                DataGridViewCheckBoxCell cbEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                cbEliminar.Value = !Convert.ToBoolean(cbEliminar.Value);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Está seguro de eliminar los registros?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (opcion == DialogResult.OK)
                {
                    string codigo;
                    string rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToString(row.Cells[1].Value);
                            rpta = NProducto.Eliminar(Convert.ToInt32(codigo));
                        }

                    }

                    if (rpta.Equals("OK"))
                    {
                        this.MensajeOK("Se eliminó correctamente el registro");
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.Mostrar();
                    this.Limpiar();
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
  
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if(this.rbNombre.Checked == true)
            {
                this.BuscarNombre();
            }else if(this.rbCategoria.Checked == true)
            {
                this.BuscarCategoria();
            }else if(this.rbTodos.Checked == true)
            {
                this.BuscarNombre();
            }
        }

        private void rbPlato_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }
                if (!(char.IsNumber(e.KeyChar)) && !(e.KeyChar == '.'))
                {
                    e.Handled = true;
                    return;
                }
                bool IsDec = false;
                int nroDec = 0;

                for (int i = 0; i < txtPrecioVenta.Text.Length; i++)
                {
                    if (txtPrecioVenta.Text[i] == '.')
                        IsDec = true;

                    if (IsDec && nroDec++ >= 2)
                    {
                        e.Handled = true;
                        return;
                    }


                }

                if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    e.Handled = false;
                else if (e.KeyChar == 46)
                    e.Handled = (IsDec) ? true : false;
                else
                    e.Handled = true;
         }

        private void txtPrecioVenta_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rbProducto_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox2.Visible = false;
            cbCategoria.Enabled = true;
        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if(rbTodos.Checked == true)
            {
                this.Mostrar();
                this.txtBuscar.Text = string.Empty;
            }
        }

        private void rbCompuesto_CheckedChanged(object sender, EventArgs e)
        {
            if(rbCompuesto.Checked == true)
            {
                DataTable dtCat = new DataTable();
                cbCategoria.Enabled = false;
                dtCat = NCategoria.MostrarCategoriaCompuesto();
                this.txtStockMinimo.ReadOnly = true;
               
                if(dtCat.Rows.Count > 0)
                {
                    groupBox2.Visible = true;
                    this.lblIdCategoria.Text = dtCat.Rows[0][0].ToString();
                    crearTabla();
                }
                else
                {
                    MessageBox.Show("Cree la categoria COMBO");
                }
            }
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            frmVistaProductoCompuesto form = new frmVistaProductoCompuesto();
            form.lblBandera.Text = "0";
            form.ShowDialog();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.txtProductoCompuesto.Text == string.Empty)
                {
                    MensajeError("Seleccione un producto");
                    errorIcono.SetError(txtProductoCompuesto, "Ingrese un valor");
                }
             else  if (this.txtCantidad.Text.Trim() == string.Empty)
                {
                    MensajeError("Ingrese la cantidad");
                    errorIcono.SetError(txtCantidad, "Ingrese un valor");
                }

                else 
                {
                        bool registrar = true;
                        foreach (DataRow row in dtDetalle.Rows)
                        {
                            if (Convert.ToInt32(row["Codigo"]) == Convert.ToInt32(this.lblIdProductoCom.Text))
                            {
                                registrar = false;
                                this.MensajeError("El producto ya se encuentra agregado");
                            }
                        }

                        if (registrar)
                        {
                            decimal subTotal = Convert.ToDecimal(this.txtCantidad.Text) * Convert.ToDecimal(this.txtPrecioVentaCompues.Text);
                            DataRow row = this.dtDetalle.NewRow();
                            row["Codigo"] = Convert.ToInt32(this.lblIdProdIns.Text);
                            row["Producto"] = this.txtProductoCompuesto.Text;
                            row["Cantidad"] = Convert.ToInt32(this.txtCantidad.Text);
                            row["Precio_Venta"] = Convert.ToDecimal(this.txtPrecioVentaCompues.Text);
                            row["Importe"] = subTotal;
                        row["Tipo"] = this.lblTipoProducto.Text;

                        this.dtDetalle.Rows.Add(row);
                            this.limpiarDetalle();
                        }
                    this.lblIdProductoCom.Text = "0";
                    this.dataListadoDetalle.ClearSelection();
                    this.txtProductoCompuesto.Focus();
                    decimal suma = 0;
                    for (int i = 0; i < dataListadoDetalle.Rows.Count; i++)
                    {
                        suma = suma + Convert.ToDecimal(this.dataListadoDetalle.Rows[i].Cells["Importe"].Value);
                    }
                    this.lblTotalVenta.Text = suma.ToString("#0.00#");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void DeshBotonesReceta(bool valor)
        {
            this.btnNuevo.Enabled = valor;
            this.btnEditar.Enabled = valor;
            this.btnEliminar.Enabled = valor;
            this.btnImprimir.Enabled = valor;
            this.btnGuardar.Enabled = valor;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }

        private void dataListadoDetalleR_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void btnEditarInsumo_Click(object sender, EventArgs e)
        {
           
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataListadoDetalle.Rows.Count <= 0)
                {
                    MensajeError("No existen filas en la tabla");
                }
                else if (this.dataListadoDetalle.SelectedRows.Count > 0)
                {
                    if (this.lblIdDetalleCom.Text == "0")
                    {
                        int indiceFila = this.dataListadoDetalle.CurrentRow.Index;
                        DataRow row = this.dtDetalle.Rows[indiceFila];

                        this.totalPagado = this.totalPagado - Convert.ToDecimal(row["Importe"].ToString());

                        this.lblTotalVenta.Text = totalPagado.ToString("#0.00#");

                        this.dtDetalle.Rows.Remove(row);
                        this.dataListadoDetalle.ClearSelection();
                        this.lblIdDetalleCom.Text = "0";
                    }
                    else
                    {
                        DialogResult opcion;
                        string rpta = "";
                        int  codDetalle;
                        opcion = MessageBox.Show("Está seguro de eliminar este producto?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (opcion == DialogResult.OK)
                        {
                            int indiceFila = this.dataListadoDetalle.CurrentRow.Index;
                            DataRow row = this.dtDetalle.Rows[indiceFila];

                            codDetalle = Convert.ToInt32(this.lblIdDetalleCom.Text);
                            rpta = NProducto.EliminarDetalleProducto(codDetalle);
                            if (rpta == "OK")
                            {
                                this.dtDetalle.Rows.Remove(row);
                                this.dataListadoDetalle.ClearSelection();
                                MessageBox.Show("Se eliminó correctamente");
                              this.limpiarDetalle();
                              this.limpiarDatatable();
                              this.Limpiar();
                              this.Botones();
                              this.btnGuardar.Enabled = false;
                              this.tabControl2.SelectedIndex = 0;
                              this.btnNuevo.Enabled = true;
                              this.btnCancelar.Enabled = false;
                              this.Mostrar();
                           }
                           else
                           {
                             MessageBox.Show(rpta);
                           }
                        }
                    }
                    decimal suma = 0;
                    for (int i = 0; i < dataListadoDetalle.Rows.Count; i++)
                    {
                        suma = suma + Convert.ToDecimal(this.dataListadoDetalle.Rows[i].Cells["Importe"].Value);
                    }
                    this.lblTotalVenta.Text = suma.ToString("#0.00#");
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

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataListadoDetalleR_Click(object sender, EventArgs e)
        {
        }

        private void lblPlato_Click(object sender, EventArgs e)
        {

        }

        private void dataListadoDetalle_Click(object sender, EventArgs e)
        {
            if(this.lblIdProductoCom.Text != "0")
            {
                this.lblIdDetalleCom.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["idDetalleProducto"].Value);

            }
        }

        private void rbNombre_CheckedChanged(object sender, EventArgs e)
        {
            this.Mostrar();
            this.txtBuscar.Text = string.Empty;
        }

        private void rbCategoria_CheckedChanged(object sender, EventArgs e)
        {
            this.Mostrar();
            this.txtBuscar.Text = string.Empty;
        }

        private void rbDescripcion_CheckedChanged(object sender, EventArgs e)
        {
            this.Mostrar();
            this.txtBuscar.Text = string.Empty;
        }

        private void rbCodigo_CheckedChanged(object sender, EventArgs e)
        {
            this.Mostrar();
            this.txtBuscar.Text = string.Empty;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmRProducto frm = new frmRProducto();
            frm.ShowDialog();
        }

        private void frmProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void dataListadoDetalle_DoubleClick(object sender, EventArgs e)
        {
            if ((this.btnGuardar.Enabled == true) && (this.dataListadoDetalle.Rows.Count > 0))
            {
                this.lblIdProducto.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Codigo"].Value);
                this.txtProductoCompuesto.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Producto"].Value);
                this.txtCantidad.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Cantidad"].Value);
                this.txtPrecioVentaCompues.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Precio_Venta"].Value);
                subTotal = Convert.ToDecimal(this.dataListadoDetalle.CurrentRow.Cells["Importe"].Value);
                this.btnAgregar.Enabled = false;
                this.btnQuitar.Enabled = false;
                this.btnEditarComp.Enabled = true;
                this.txtCantidad.Focus();
                this.lblPosic.Text = dataListadoDetalle.CurrentRow.Index.ToString();
                this.txtCantidad.ReadOnly = false;
            }
        }

        private void btnEditarComp_Click(object sender, EventArgs e)
        {
            if (this.lblIdProducto.Text == string.Empty)
            {
                MensajeError("Seleccione un producto");
                errorIcono.SetError(txtProductoCompuesto, "Seleccione un valor");
            }

            else if (this.txtCantidad.Text.Trim() == string.Empty)
            {
                MensajeError("Ingrese la cantidad");
                errorIcono.SetError(txtCantidad, "Ingrese un valor");
            }
            else if (this.txtPrecioVentaCompues.Text.Trim() == string.Empty)
            {
                MensajeError("Ingrese el precio de venta");
                errorIcono.SetError(txtPrecioVentaCompues, "Ingrese un valor");
            }

            else 
            {
               
                if (this.lblIdDetalleCom.Text == "0" )
                {
                    this.dataListadoDetalle[3, Convert.ToInt32(this.lblPosic.Text)].Value = this.txtPrecioVentaCompues.Text;
                    this.dataListadoDetalle[2, Convert.ToInt32(this.lblPosic.Text)].Value = this.txtCantidad.Text;
                    decimal subTotal1 = Convert.ToDecimal(this.txtCantidad.Text) * Convert.ToDecimal(this.txtPrecioVentaCompues.Text);
                    this.dataListadoDetalle[4, Convert.ToInt32(this.lblPosic.Text)].Value = subTotal1;
                    this.limpiarDetalle();
                    this.btnEditarComp.Enabled = false;
                    this.btnAgregar.Enabled = true;
                    this.btnQuitar.Enabled = true;
                    this.dataListadoDetalle.ClearSelection();

                }
                else
                {
                    string rpta = "";
                    this.dataListadoDetalle[3, Convert.ToInt32(this.lblPosic.Text)].Value = this.txtPrecioVentaCompues.Text;
                    this.dataListadoDetalle[2, Convert.ToInt32(this.lblPosic.Text)].Value = this.txtCantidad.Text;
                    decimal subTotal1 = Convert.ToDecimal(this.txtCantidad.Text) * Convert.ToDecimal(this.txtPrecioVentaCompues.Text);
                    this.dataListadoDetalle[4, Convert.ToInt32(this.lblPosic.Text)].Value = subTotal1;
                    rpta = NProducto.EditarDetalle(Convert.ToInt32(this.lblIdDetalleCom.Text), Convert.ToInt32(this.txtCantidad.Text));
                    if (rpta == "OK")
                    {
                        MessageBox.Show("Se editó correctamente");
                        this.dataListadoDetalle.ClearSelection();
                        this.limpiarDetalle();
                        this.btnEditarComp.Enabled = false;
                        this.btnAgregar.Enabled = true;
                        this.btnQuitar.Enabled = true;
                        this.tabControl2.SelectedIndex = 0;
                        this.dataListado.ClearSelection();
                    }
                    else
                    {
                        MessageBox.Show(rpta);
                    }
                }

        
                decimal suma = 0;
                for (int i = 0; i < dataListadoDetalle.Rows.Count; i++)
                {
                    suma = suma + Convert.ToDecimal(this.dataListadoDetalle.Rows[i].Cells["Importe"].Value);
                }
                this.lblTotalVenta.Text = suma.ToString("#0.00#");
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
        }
    }
}
