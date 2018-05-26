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
    public partial class frmSalidaAlmacen : Form
    {
        private bool isNuevo;
        private DataTable dtDetalle;
        public static frmSalidaAlmacen f1;
        public frmSalidaAlmacen()
        {
            InitializeComponent();
            frmSalidaAlmacen.f1 = this;
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
            this.txtEntregado.Text = string.Empty;
            this.cbTipoIngreso.SelectedIndex = -1;
            this.cbAlmacen.SelectedIndex = -1;
            this.cbDestino.SelectedIndex = -1;
            this.crearTabla();

        }

        private void limpiarDetalle()
        {
            this.txtIdArticulo.Text = string.Empty;
            this.txtProducto.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtUnidad.Text = string.Empty;
        }

        private void Habilitar(bool valor)
        {
            if(this.cbAlmacen.Items.Count > 0)
            {
                this.cbAlmacen.SelectedIndex = 0;
            }else
            {
                MensajeError("Ingrese al menos UN ALMACÉN");
                return;
            }

            if(this.cbTipoIngreso.Items.Count > 0)
            {
                this.cbTipoIngreso.SelectedIndex = 0;
            }else
            {
                MensajeError("Ingrese los TIPOS DE SALIDA");
                return;
            }

            this.dtFecha.Enabled = valor;
            this.cbAlmacen.Enabled = valor;
            this.cbTipoIngreso.Enabled = valor;
            this.cbDestino.Enabled = valor;
            this.cbDestino.SelectedIndex = 0;
            this.txtCantidad.ReadOnly = !valor;
            this.btnBuscarArticulo.Enabled = valor;
            this.btnVistaInsumo.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
            this.txtEntregado.ReadOnly = !valor;
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


        private void crearTabla()
        {

            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("Codigo", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Producto", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Cantidad", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("TipoProducto", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("TipoMov", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("StockActual", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Lugar", System.Type.GetType("System.String"));
            this.dataListadoDetalle.DataSource = this.dtDetalle;
        }


        private void formatoTabla()
        {
            this.dataListadoDetalle.Columns[3].Visible = false;
            this.dataListadoDetalle.Columns[4].Visible = false;
            this.dataListadoDetalle.Columns[5].Visible = false;
            this.dataListadoDetalle.Columns[6].Visible = false;
            // DataGridView1.Columns(1).Width = 150
            this.dataListadoDetalle.Columns[0].Width = 166;
            this.dataListadoDetalle.Columns[1].Width = 600;


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

        private void cargarTipoSalida()
        {
            cbTipoIngreso.DataSource = NTipoMovAlmacen.MostrarTipoMovSalida();
            cbTipoIngreso.ValueMember = "Codigo";
            cbTipoIngreso.DisplayMember = "Tipo_Movimiento";
            cbTipoIngreso.SelectedIndex = -1;
            //lblPrueba.Text = cbCategoria.SelectedValue.ToString();

        }

        private void frmSalidaAlmacen_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.crearTabla();
            this.formatoTabla();
            this.cargarAlmacen();
            this.cargarTipoSalida();
            this.Habilitar(false);
            this.Botones();


        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            frmVistaProductoIngreso form = new frmVistaProductoIngreso();
            form.lblBanderaCierre.Text = "2";
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
                    decimal stockActual = Convert.ToDecimal(this.lblStockActual.Text);
                    decimal cantidadAc = Convert.ToDecimal(this.txtCantidad.Text.Trim());

                    if (cantidadAc > stockActual)
                    {
                        MessageBox.Show("La cantidad supera el stock actual");
                    }else
                    {
                        bool registrar = true;
                        string lugarSalir = "";//0=tienda, 1=fuera 
                        if(cbDestino.SelectedIndex == 0)
                        {
                            lugarSalir = "0";
                        }else
                        {
                            lugarSalir = "1";
                        }
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
                            row["TipoMov"] = "S";
                            row["StockActual"] = Convert.ToDecimal(this.lblStockActual.Text);
                            row["Lugar"] = lugarSalir;
                            this.dtDetalle.Rows.Add(row);
                            this.limpiarDetalle();
                        }

                        this.dataListadoDetalle.ClearSelection();
                        this.txtProducto.Focus();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Agregar();
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
                decimal stockAc = Convert.ToDecimal(this.lblStockActual.Text);
                decimal cantA = Convert.ToDecimal(this.txtCantidad.Text.Trim());
                if (cantA > stockAc)
                {
                    MessageBox.Show("La cantidad supera el stock actual");
                }
                else
                {
                    bool registrar = true;
                    if (registrar)
                    {

                        this.dataListadoDetalle[2, Convert.ToInt32(this.lblPosic.Text)].Value = this.txtCantidad.Text;
                        this.dataListadoDetalle.ClearSelection();
                        this.limpiarDetalle();
                        this.btnEditar.Enabled = false;
                        this.btnAgregar.Enabled = true;
                        this.btnQuitar.Enabled = true;
                    }
                }


            }
        }

        private void btnVistaInsumo_Click(object sender, EventArgs e)
        {
            frmVistaInsumo_Ingreso form = new frmVistaInsumo_Ingreso();
            form.lblBanderaCierre.Text = "2";
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

                }
            }
            else
            {
                if (e.KeyChar == 8 )
                {
                    e.Handled = false;
                   return;
                }
                if(e.KeyChar == 13)
                {
                 
                        this.Agregar();

    
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
                    }else if(cbTipoIngreso.SelectedIndex == -1)
                    {
                        MensajeError("Seleccioe el tipo de salida");
                    }
                    else if(this.txtEntregado.Text.Trim() == string.Empty)
                    {
                        MensajeError("Ingrese el nombre al que entregerá los productos");
                    }
                    else{
                        string rpta = "";
                        if (this.isNuevo)
                        {

                            rpta = NMovimientoAlmacen.Insertar(Convert.ToInt32(this.cbAlmacen.SelectedValue.ToString()), Convert.ToInt32(this.cbTipoIngreso.SelectedValue.ToString()), Convert.ToInt32(this.lblIdUsuario.Text),txtEntregado.Text.Trim().ToUpper(), dtFecha.Value, "REGISTRADO","SALIDA", dtDetalle);
                        }
                        if (rpta.Equals("OK"))
                        {
                            if (this.isNuevo)
                            {
                                this.MensajeOK("Se insertó correctamente");
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
                this.lblStockActual.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["StockActual"].Value);
                this.btnAgregar.Enabled = false;
                this.btnQuitar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.txtCantidad.Focus();
                this.lblPosic.Text = dataListadoDetalle.CurrentRow.Index.ToString();
            }
        }

        private void cbDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(dataListadoDetalle.Rows.Count > 0)
            {
                for(int i=0; i<dataListadoDetalle.Rows.Count; i++)
                {
                    if (cbDestino.SelectedIndex == 0)
                    {
                        this.dataListadoDetalle[6, i].Value = "1";
                        this.dataListadoDetalle.ClearSelection();
                    }
                    else
                    {
                        this.dataListadoDetalle[6, i].Value = "2";
                        this.dataListadoDetalle.ClearSelection();
                    }
                }
            }
        }

        private void frmSalidaAlmacen_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
