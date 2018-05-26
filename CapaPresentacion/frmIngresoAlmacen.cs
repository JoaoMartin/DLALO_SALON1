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
    public partial class frmIngresoAlmacen : Form
    {
        private bool isNuevo;
        private DataTable dtDetalle;
        public static frmIngresoAlmacen f1;
        private static frmIngresoAlmacen _instancia;

        public static frmIngresoAlmacen GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new frmIngresoAlmacen();
            }
            return _instancia;

        }
        public frmIngresoAlmacen()
        {
            InitializeComponent();
            frmIngresoAlmacen.f1 = this;
        }

        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Limpiar()
        {
          
            this.txtCantidad.Text = string.Empty;

            this.cbTipoIngreso.SelectedIndex = -1;
            this.cbAlmacen.SelectedIndex = -1;
            this.crearTabla();

        }

        private void limpiarDetalle()
        {
            this.txtIdArticulo.Text = string.Empty;
            this.txtProducto.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtUnidad.Text = string.Empty;
            this.txtMonto.Text = string.Empty;
            this.txtPrecioUnitario.Text = string.Empty;
        }

        private void Habilitar(bool valor)
        {
           


            if (this.cbAlmacen.Items.Count > 0)
            {
                this.cbAlmacen.SelectedIndex = 0;
            }else
            {
                MensajeError("Ingrese al menos UN ALMACÉN");
                return;
            }

            if (this.cbTipoIngreso.Items.Count > 0)
            {
                this.cbTipoIngreso.SelectedIndex = 0;
            }
            else
            {
                MensajeError("Ingrese los TIPOS DE SALIDA");
                return;
            }
            this.dtFecha.Enabled = valor;
            this.cbAlmacen.Enabled = valor;
            this.cbTipoIngreso.Enabled = valor;
            //this.cbTipoIngreso.SelectedIndex = 0;
            //this.cbAlmacen.SelectedIndex = 0;
            this.txtCantidad.ReadOnly = !valor;
            this.txtMonto.ReadOnly = !valor;
            this.txtPrecioUnitario.ReadOnly = !valor;
            cbCaja.Enabled = valor;

            this.btnBuscarArticulo.Enabled = valor;
            this.btnVistaInsumo.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
            this.errorIcono.Clear();
        }

        //Habilitar Botones
        private void Botones()
        {
            if (this.isNuevo)
            {
                //this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;

                // this.rbPlato.Checked = true;
            }
            else
            {
                //this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }


        private void Agregar()
        {
            try
            {


                if (this.txtIdArticulo.Text == string.Empty)
                {
                    MensajeError("Seleccione un producto");
                    errorIcono.SetError(txtProducto, "Seleccione un valor");
                }

                else if (this.txtCantidad.Text.Trim() == string.Empty)
                {
                    MensajeError("Ingrese la cantidad");
                    errorIcono.SetError(txtCantidad, "Ingrese un valor");
                }

                else
                {

                    bool registrar = true;
                    string lugarSalir = "0";//0=tienda, 1=fuera 
   
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["Codigo"]) == Convert.ToInt32(this.txtIdArticulo.Text) && row["TipoProducto"].ToString() == this.lblBandera.Text)
                        {
                            registrar = false;
                            this.MensajeError("El producto ya se encuentra agregado");
                        }
                    }

                    if (registrar)
                    {


                        DataRow row = this.dtDetalle.NewRow();
                        row["Codigo"] = Convert.ToInt32(this.txtIdArticulo.Text);
                        row["Producto"] = this.txtProducto.Text;
                        row["Cantidad"] = Convert.ToDecimal(this.txtCantidad.Text);
                        row["TipoProducto"] = this.lblBandera.Text;
                        row["TipoMov"] = "I";
                        row["Lugar"] = lugarSalir;
                        decimal monto = 00.00m, precioUnitario = 00.00m;
                        if(txtMonto.Text.Trim() == string.Empty)
                        {
                            monto = 00.00m;
                        }
                        else
                        {
                           monto= Convert.ToDecimal(this.txtMonto.Text.Trim());
                        }
                        row["Monto"] = monto;
                        if(txtPrecioUnitario.Text.Trim() == string.Empty || txtPrecioUnitario.Text == "00.00")
                        {
                            precioUnitario = 00.00m;
                        }else
                        {
                            precioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text);
                        }
                        row["PrecioUnitario"] = precioUnitario;
                        this.dtDetalle.Rows.Add(row);
                        this.limpiarDetalle();
                    }

                    this.dataListadoDetalle.ClearSelection();
                    this.txtProducto.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void crearTabla()
        {

            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("Codigo", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Producto", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Cantidad", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("TipoProducto", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("TipoMov", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Lugar", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Monto", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("PrecioUnitario", System.Type.GetType("System.Decimal"));
            this.dataListadoDetalle.DataSource = this.dtDetalle;
        }


        private void formatoTabla()
        {
            this.dataListadoDetalle.Columns[3].Visible = false;
            this.dataListadoDetalle.Columns[4].Visible = false;
            this.dataListadoDetalle.Columns[5].Visible = false;
            // DataGridView1.Columns(1).Width = 150
            this.dataListadoDetalle.Columns[0].Width = 130;
            this.dataListadoDetalle.Columns[1].Width = 590;
            this.dataListadoDetalle.Columns[2].Width = 120;

            this.dataListadoDetalle.ClearSelection();
            this.dataListadoDetalle.ColumnHeadersDefaultCellStyle.Font = new Font(dataListadoDetalle.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListadoDetalle.GridColor = SystemColors.ActiveBorder;
        }
        private void cargarAlmacen()
        {
            cbAlmacen.DataSource = NAlmacen.Mostrar();
            cbAlmacen.ValueMember = "Codigo";
            cbAlmacen.DisplayMember = "Nombre";
            cbAlmacen.SelectedIndex = -1;
            //lblPrueba.Text = cbCategoria.SelectedValue.ToString();

        }

        private void cargarTipoIngreso()
        {
            cbTipoIngreso.DataSource = NTipoMovAlmacen.MostrarTipoMovIngreso();
            cbTipoIngreso.ValueMember = "Codigo";
            cbTipoIngreso.DisplayMember = "Tipo_Movimiento";
            cbTipoIngreso.SelectedIndex = -1;
            //lblPrueba.Text = cbCategoria.SelectedValue.ToString();

        }


        private void frmIngresoAlmacen_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
           // this.Habilitar(false);
            this.Botones();
            this.Habilitar(false);
            this.crearTabla();
            this.formatoTabla();
            this.cargarAlmacen();
            this.cargarTipoIngreso();
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            frmVistaProductoIngreso form = new frmVistaProductoIngreso();
            form.lblBanderaCierre.Text = "1";
            form.ShowDialog();
            this.txtCantidad.Select();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.isNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.limpiarDetalle();
            this.lblBander.Text = "1";
        }
        private void Total()
        {
            decimal total = 00.00m;
            for(int i = 0; i < dataListadoDetalle.Rows.Count; i++)
            {
                total = total + Convert.ToDecimal(dataListadoDetalle.Rows[i].Cells[6].Value.ToString());
            }
            txtTotalPagado.Text = total.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Agregar();
            this.Total();
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
                    int indiceFila = this.dataListadoDetalle.CurrentRow.Index;
                    DataRow row = this.dtDetalle.Rows[indiceFila];

                    this.dtDetalle.Rows.Remove(row);
                    this.dataListadoDetalle.ClearSelection();
                    this.Total();
                }
                else
                {
                    MensajeError("Seleccione una fila");
                }


            }
            catch (Exception ex)
            {
                MensajeError("No hay filas para remover");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.txtIdArticulo.Text == string.Empty)
            {
                MensajeError("Seleccione un producto");
                errorIcono.SetError(txtProducto, "Seleccione un valor");
            }

            else if (this.txtCantidad.Text.Trim() == string.Empty)
            {
                MensajeError("Ingrese la cantidad");
                errorIcono.SetError(txtCantidad, "Ingrese un valor");
            }
         

            else
            {
                bool registrar = true;
                if (registrar)
                {

                    this.dataListadoDetalle[2, Convert.ToInt32(this.lblPosic.Text)].Value = this.txtCantidad.Text;
                    if(txtMonto.Text.Trim() == string.Empty)
                    {
                        this.dataListadoDetalle[6, Convert.ToInt32(this.lblPosic.Text)].Value = "00.00";
                    }else
                    {
                        this.dataListadoDetalle[6, Convert.ToInt32(this.lblPosic.Text)].Value = this.txtMonto.Text.Trim();
                    }
                    this.dataListadoDetalle.ClearSelection();
                    this.Total();
                    this.limpiarDetalle();
                    this.btnEditar.Enabled = false;
                    this.btnAgregar.Enabled = true;
                    this.btnQuitar.Enabled = true;
                }

            }
        }

        private void btnVistaInsumo_Click(object sender, EventArgs e)
        {
            frmVistaInsumo_Ingreso form = new frmVistaInsumo_Ingreso();
            form.lblBanderaCierre.Text = "1";
            form.ShowDialog();
            this.txtCantidad.Select();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.lblBandera.Text == "P")
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
                {
                    MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }

                if ((int)e.KeyChar == (int)Keys.Enter)
                {
                    this.Agregar();
                    Total();

                }
            }
            else
            {
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }
                if (e.KeyChar == 13)
                {

                    this.Agregar();
                    Total();

                }

                if (!(char.IsNumber(e.KeyChar)) && !(e.KeyChar == '.'))
                {
                    e.Handled = true;
                    return;
                }
                bool IsDec = false;
                int nroDec = 0;

                for (int i = 0; i < txtCantidad.Text.Length; i++)
                {
                    if (txtCantidad.Text[i] == '.')
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
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.isNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.limpiarDetalle();
            this.lblBander.Text = "0";
            this.txtTotalPagado.Text = string.Empty;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.dataListadoDetalle.Rows.Count == 0)
            {
                MensajeError("No hay productos en la lista");
            }
            else
            {
                try
                {
                    if (cbAlmacen.SelectedIndex == -1)
                    {
                        MensajeError("Seleccione el almacén de salida");
                    }
                    else if (cbTipoIngreso.SelectedIndex == -1)
                    {
                        MensajeError("Seleccioe el tipo de salida");
                    }
                    else
                    {

                        string rpta = "";
                        if (this.isNuevo)
                        {

                            rpta = NMovimientoAlmacen.Insertar(Convert.ToInt32(this.cbAlmacen.SelectedValue.ToString()), Convert.ToInt32(this.cbTipoIngreso.SelectedValue.ToString()), Convert.ToInt32(this.lblIdUsuario.Text), "", dtFecha.Value, "REGISTRADO","INGRESO", dtDetalle);


                        }
                        if (rpta.Equals("OK"))
                        {
                           
                            if (this.isNuevo)
                            {
                                for(int i = 0; i < dataListadoDetalle.Rows.Count;i++)
                                {
                                    decimal precioUnitario = Convert.ToDecimal(dataListadoDetalle.Rows[i].Cells["PrecioUnitario"].Value.ToString());
                                    if(precioUnitario > 0)
                                    {
                                        rpta = NProducto.EditarCostoInsumo(Convert.ToInt32(dataListadoDetalle.Rows[i].Cells[0].Value.ToString()), precioUnitario);
                                    }
                                }
                                if (cbCaja.Checked == true)
                                {
                                    rpta = NCaja.Insertar(Convert.ToInt32(this.lblIdUsuario.Text), "1", "EGRESO", Convert.ToDecimal(this.txtTotalPagado.Text), "COMPRA", "EFECTIVO");

                                }
                                this.MensajeOK("Se insertó correctamente");
                                txtTotalPagado.Text = string.Empty;
                            }
                        }
                        else
                        {
                            this.MensajeError(rpta);
                        }

                        this.isNuevo = false;
                        this.Botones();
                        this.Limpiar();
                        this.limpiarDetalle();
                        this.txtCantidad.ReadOnly = true;
                        this.txtMonto.ReadOnly = true;
                        cbCaja.Enabled = false;
                    }


                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }


        }

        private void dataListadoDetalle_DoubleClick(object sender, EventArgs e)
        {
            if (this.lblBander.Text.Equals("1") && (this.btnGuardar.Enabled == true) && (this.dataListadoDetalle.Rows.Count > 0))
            {
                this.txtIdArticulo.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Codigo"].Value);
                this.txtProducto.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Producto"].Value);
                this.txtCantidad.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Cantidad"].Value);
                this.txtMonto.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Monto"].Value);

                this.btnAgregar.Enabled = false;
                this.btnQuitar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.txtCantidad.Focus();
                this.lblPosic.Text = dataListadoDetalle.CurrentRow.Index.ToString();
            }
        }

        private void frmIngresoAlmacen_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmIngresoAlmacen_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.lblBandera.Text == "P")
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
                {
                    MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }

                if ((int)e.KeyChar == (int)Keys.Enter)
                {
                    this.Agregar();
                    Total();

                }
            }
            else
            {
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }
                if (e.KeyChar == 13)
                {

                    this.Agregar();
                    Total();

                }

                if (!(char.IsNumber(e.KeyChar)) && !(e.KeyChar == '.'))
                {
                    e.Handled = true;
                    return;
                }
                bool IsDec = false;
                int nroDec = 0;

                for (int i = 0; i < txtMonto.Text.Length; i++)
                {
                    if (txtMonto.Text[i] == '.')
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
            
        }

        private void txtMonto_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void txtPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txtPrecioUnitario.Text.Length; i++)
            {
                if (txtPrecioUnitario.Text[i] == '.')
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

        private void txtCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMonto.Text.Trim() != "")
            {
                decimal cantidad = Convert.ToDecimal(txtCantidad.Text.Trim());
                decimal monto = Convert.ToDecimal(txtMonto.Text.Trim());
                decimal precioUn = monto / cantidad;
                //txtPrecioUnitario.Text = precioUn.ToString("#0.00#");
            }
            else
            {
                txtMonto.Text = "00.00";
            }
        }

        private void txtPrecioUnitario_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtCantidad.Text.Trim() != "" && txtPrecioUnitario.Text.Trim() != "")
            {
                decimal cantidad = Convert.ToDecimal(txtCantidad.Text.Trim());
                decimal precioUn = Convert.ToDecimal(txtPrecioUnitario.Text.Trim());
                decimal monto = precioUn * cantidad;
                txtMonto.Text = monto.ToString("#0.00#");
            }
            else
            {
                txtMonto.Text = "00.00";
            }
        }

        private void txtMonto_Layout(object sender, LayoutEventArgs e)
        {

        }
    }
}
