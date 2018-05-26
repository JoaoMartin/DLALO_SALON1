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
    public partial class frmPrincipal : Form
    {
        private int childFormNumber = 0;
        public string idTrabajador = "";
        public string nombre = "";
        public string tipoTrabajador = "";
        public static frmPrincipal f1;
        public frmPrincipal()
        {
            InitializeComponent();
            frmPrincipal.f1 = this;
        }

        public void ValidarControlesC()
        {
            String ahora = DateTime.Now.ToShortDateString();

            DataTable dtEstado = NCaja_A.MostrarEstadoCaja(1);

            string estado;
            DateTime fecha_estado;

            if (dtEstado.Rows.Count > 0)
            {
                estado = dtEstado.Rows[0]["Estado"].ToString();
            }
            else
            {
                estado = "0";
            }

            if (estado == "0" || estado == "Cerrada")
            {
                
                lblFechaCaja.Text = "";
                lblEstadoCaja.Text = "0";
               
                lblMontoApertura.Text = "0";
                lblFechaApertura.Text = "0";
 
            }
            else
            {
                DataTable dtMonto = NCaja_A.MostrarMontoCaja(1);
                
                lblEstadoCaja.Text = dtEstado.Rows[0]["Estado"].ToString();
                fecha_estado = Convert.ToDateTime(dtEstado.Rows[0]["Fecha"].ToString());
                lblFechaCaja.Text = fecha_estado.ToShortDateString();
               
                lblIdUsuario.Text = lblIdUsuario.Text;
                lblMontoApertura.Text = dtMonto.Rows[0]["monto"].ToString();
                lblFechaApertura.Text = dtMonto.Rows[0]["fecha"].ToString();
                lblMontoCorteCaja.Text = dtMonto.Rows[0]["monto"].ToString();
                lblFechaCorteCaja.Text = dtMonto.Rows[0]["fecha"].ToString();
            }



            if (lblEstadoCaja.Text == "Abierta")
            {

                mnuAperturaCaja.Enabled = false;
                mnuCerrarCaja.Enabled = true;
                mnuIngresoDinero.Enabled = true;
                mnuSalidaDinero.Enabled = true;
                mnuPuntoVenta.Enabled = true;
                mnuPorCobrar.Enabled = true;
                //mnuDelivery.Enabled = true;
                mnuCorteParcial.Enabled = true;
              

            }
            else if (lblEstadoCaja.Text == "Cerrada" || lblEstadoCaja.Text == "0")
            {
                mnuAperturaCaja.Enabled = true;
                mnuCerrarCaja.Enabled = false;
                mnuIngresoDinero.Enabled = false;
                mnuSalidaDinero.Enabled = false;
                mnuPuntoVenta.Enabled = false;
                mnuPorCobrar.Enabled = false;
               // mnuDelivery.Enabled = false;
                mnuCorteParcial.Enabled = true;
                
            }
        }

        public void ValidarControlesR()
        {
            String ahora = DateTime.Now.ToShortDateString();

            if (lblEstadoCaja.Text == "Abierta")
            {
               
                    mnuAperturaCaja.Enabled = false;
                    mnuCerrarCaja.Enabled = true;
                    mnuIngresoDinero.Enabled = true;
                    mnuSalidaDinero.Enabled = true;
                    mnuPuntoVenta.Enabled = true;
                    mnuPorCobrar.Enabled = true;
                    //mnuDelivery.Enabled = true;
             

            }
            else if (lblEstadoCaja.Text == "Cerrada" || lblEstadoCaja.Text == "0")
            {
                mnuAperturaCaja.Enabled = true;
                mnuCerrarCaja.Enabled = false;
                mnuIngresoDinero.Enabled = false;
                mnuSalidaDinero.Enabled = false;
                mnuPuntoVenta.Enabled = false;
                mnuPorCobrar.Enabled = false;
               // mnuDelivery.Enabled = false;
               
            }
        }

        public void ValidarControles()
        {
            String ahora = DateTime.Now.ToShortDateString();
            /*

            if (lblEstadoCaja.Text == "0" || (lblEstadoCaja.Text == "Cerrada" && ahora != this.lblFechaCaja.Text))
            {
                mnuAperturaCaja.Enabled = true;
                mnuCerrarCaja.Enabled = false;
                mnuIngresoDinero.Enabled = false;
                mnuSalidaDinero.Enabled = false;
                mnuPuntoVenta.Enabled = false;

            }
            else if (lblEstadoCaja.Text == "Abierta")
            {
                mnuAperturaCaja.Enabled = false;
                mnuCerrarCaja.Enabled = true;
                mnuIngresoDinero.Enabled = true;
                mnuSalidaDinero.Enabled = true;
                mnuPuntoVenta.Enabled = true;
            }
            else if ((lblEstadoCaja.Text == "Cerrada") && (ahora == this.lblFechaCaja.Text))
            {
                mnuAperturaCaja.Enabled = false;
                mnuCerrarCaja.Enabled = false;
                mnuIngresoDinero.Enabled = true;
                mnuSalidaDinero.Enabled = true;
                mnuPuntoVenta.Enabled = true;
            }*/
            
             if (lblEstadoCaja.Text == "Abierta")
            {
              
                    mnuAperturaCaja.Enabled = false;
                    mnuCerrarCaja.Enabled = true;
                    mnuIngresoDinero.Enabled = true;
                    mnuSalidaDinero.Enabled = true;
                    mnuPuntoVenta.Enabled = true;
                    mnuPorCobrar.Enabled = true;
                    //mnuDelivery.Enabled = true;
                  
                    mnuCorteParcial.Enabled = true;
                

            }
            else if (lblEstadoCaja.Text == "Cerrada" || lblEstadoCaja.Text =="0")
            {
                mnuAperturaCaja.Enabled = true;
                mnuCerrarCaja.Enabled = false;
                mnuIngresoDinero.Enabled = false;
                mnuSalidaDinero.Enabled = false;
                mnuPuntoVenta.Enabled = false;
                mnuPorCobrar.Enabled = false;
               // mnuDelivery.Enabled = false;
                mnuCorteParcial.Enabled = false;
               
            }
        }



        private void Deshabilitado()
        {
            this.mnuAperturaCaja.Enabled = false;
            this.mnuCerrarCaja.Enabled = false;
            this.mnuIngresoDinero.Enabled = false;
            this.mnuSalidaDinero.Enabled = false;
            this.mnuIngresos.Enabled = false;
            this.mnuPuntoVenta.Enabled = false;
            this.mnuCategoria.Enabled = false;
            this.mnuCliente.Enabled = false;
            this.mnuMesas.Enabled = false;
            this.mnuProductos.Enabled = false;
            this.mnuProveedor.Enabled = false;
            this.mnuSalones.Enabled = false;
            this.mnuTermino.Enabled = false;
            this.mnuTipoTrabajador.Enabled = false;
            this.mnuTrabajador.Enabled = false;
            this.mnuReportes.Enabled = false;
            this.mnuNiveles.Enabled = false;
        }
        public void ValidarAcceso()
        {
            this.Deshabilitado();
            DataTable dtIdTipoTrabajador = NTipoTrabajador.MostrarIdTipoUsuario(Convert.ToInt32(this.lblIdUsuario.Text));
            DataTable dtNivel = NNivel.Mostrar(Convert.ToInt32(dtIdTipoTrabajador.Rows[0][0].ToString()));
            for (int i = 0; i < dtNivel.Rows.Count; i++)
            {
                if (dtNivel.Rows[i][2].ToString() == "Nota Ingreso")
                {
                    this.mnuNotaIngreso.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "Nota Salida")
                {
                    this.mnuNotaSalida.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "Consulta_Stock")
                {
                    this.mnuStock.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "Ver Movimientos_Almacen")
                {
                    this.mnuVerMovAlmacen.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "Comprobante_Anulados")
                {
                    this.mnuComprobantesAnulados.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "Aperturar Caja" && lblEstadoCaja.Text == "Abierta")
                {
                    this.mnuAperturaCaja.Enabled = false;
                }

                if (dtNivel.Rows[i][2].ToString() == "Aperturar Caja" && (lblEstadoCaja.Text == "Cerrada" || lblEstadoCaja.Text == "0"))
                {
                    this.mnuAperturaCaja.Enabled = true;
                }

                if (dtNivel.Rows[i][2].ToString() == "Cerrar Caja" && lblEstadoCaja.Text == "Abierta")
                {
                    this.mnuCerrarCaja.Enabled = true;
                }

                if (dtNivel.Rows[i][2].ToString() == "Cerrar Caja" && (lblEstadoCaja.Text == "Cerrada" || lblEstadoCaja.Text == "0"))
                {
                    this.mnuCerrarCaja.Enabled = false;
                }

                if (dtNivel.Rows[i][2].ToString() == "Ingreso Dinero" && lblEstadoCaja.Text == "Abierta")
                {
                    this.mnuIngresoDinero.Enabled = true;
                }

                if (dtNivel.Rows[i][2].ToString() == "Ingreso Dinero" && (lblEstadoCaja.Text == "Cerrada" || lblEstadoCaja.Text == "0"))
                {
                    this.mnuIngresoDinero.Enabled = false;
                }

                if (dtNivel.Rows[i][2].ToString() == "Salida Dinero" && lblEstadoCaja.Text == "Abierta")
                {
                    this.mnuSalidaDinero.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "Salida Dinero" && (lblEstadoCaja.Text == "Cerrada" || lblEstadoCaja.Text == "0"))
                {
                    this.mnuSalidaDinero.Enabled = false;
                }


                if (dtNivel.Rows[i][2].ToString() == "Compras_Ingresos")
                {
                    this.mnuIngresos.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "Ver Compras")
                {
                    this.mnuVerCompras.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "Punto de Venta" && lblEstadoCaja.Text == "Abierta")
                {
                    this.mnuPuntoVenta.Enabled = true;
                  
                }
                if (dtNivel.Rows[i][2].ToString() == "Punto de Venta" && (lblEstadoCaja.Text == "Cerrada" || lblEstadoCaja.Text == "0"))
                {
                    this.mnuPuntoVenta.Enabled = false;
                   
                }

                if (dtNivel.Rows[i][2].ToString() == "Ver Ventas")
                {
                    this.mnuVerVentas.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "M_AlmacenGestion")
                {
                    this.mnuGestionAlmacen.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "M_Categoria")
                {
                    this.mnuCategoria.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "M_Clientes")
                {
                    this.mnuCliente.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "M_Insumos")
                {
                    this.mnuInsumos.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "M_Mesas")
                {
                    this.mnuMesas.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "M_Productos")
                {
                    this.mnuProductos.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "M_Proveedor")
                {
                    this.mnuProveedor.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "M_Platos")
                {
                    this.mnuPlatos.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "M_Salones")
                {
                    this.mnuSalones.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "M_Termino")
                {
                    this.mnuTermino.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "M_TipoTrabajador")
                {
                    this.mnuTipoTrabajador.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "M_Trabajador")
                {
                    this.mnuTrabajador.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "Reportes")
                {
                    this.mnuReportes.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "M_Niveles")
                {
                    this.mnuNiveles.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "M_UnidadMedida")
                {
                    this.mnuUnidadMedida.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "Backup")
                {
                    this.mnuBackup.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "Cambio_Contrasena")
                {
                    this.mnuCambio.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "TipoIngresoAlmacen")
                {
                    this.mnuTipoMovIngreso.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "TipoSalidaAlmacen")
                {
                    this.mnuTipoMovSalida.Enabled = true;
                }

                if (dtNivel.Rows[i][2].ToString() == "Descuento")
                {
                    this.mnuDescuento.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "Descuento")
                {
                    this.mnuDescuento.Enabled = true;
                }

                if (dtNivel.Rows[i][2].ToString() == "Por Cobrar")
                {
                    this.mnuPorCobrar.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "Control Caja" && lblEstadoCaja.Text == "Abierta")
                {
                    this.mnuConsultaCaja.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "Control Caja" && (lblEstadoCaja.Text == "Cerrada" || lblEstadoCaja.Text == "0"))
                {
                    this.mnuConsultaCaja.Enabled = false;
                }
                if (dtNivel.Rows[i][2].ToString() == "Corte Parcial" && lblEstadoCaja.Text == "Abierta")
                {
                    this.mnuCorteParcial.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "Corte Parcial" && (lblEstadoCaja.Text == "Cerrada" || lblEstadoCaja.Text == "0"))
                {
                    this.mnuCorteParcial.Enabled = false;
                }
                if (dtNivel.Rows[i][2].ToString() == "Consulta_Cortes")
                {
                    this.mnuCortes.Enabled = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "Consulta_Cierre")
                {
                    this.mnuConsultaCierre.Enabled = true;
                }
            }



        }
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompra frm = frmCompra.GetInstancia();
            frm.MdiParent = this;
    
            frm.Show();
            frm.lblIdUsuario.Text = this.lblIdUsuario.Text;
        }

        private void puntoVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModuloSalon frm = new frmModuloSalon();
            frm.MdiParent = this;
            frm.lblIdUsuario.Text = this.lblIdUsuario.Text;
            frm.lblUsuario.Text = this.lblUsuario.Text + " " + lblApellidos.Text;
            frm.Show();
        }

  
        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.ValidarAcceso();
            this.ValidarControles();
           
        }

        private void mnuAperturaCaja_Click(object sender, EventArgs e)
        {
            frmAperturaCaja frm = new frmAperturaCaja();
            frm.MdiParent = this;
        
            frm.Show();
        }

        private void mnuCategoria_Click(object sender, EventArgs e)
        {
            frmCategoria form = new frmCategoria();
            form.MdiParent = this;
        
            form.Show();
            form.dataListado.ClearSelection();
        }

        private void mnuCliente_Click(object sender, EventArgs e)
        {
            frmCliente form = new frmCliente();
            form.MdiParent = this;
          
            form.Show();
            form.dataListado.ClearSelection();
        }

        private void mnuMesas_Click(object sender, EventArgs e)
        {
            frmMesa form = new frmMesa();
       
            form.MdiParent = this;
            form.Show();
        }

        private void mnuProductos_Click(object sender, EventArgs e)
        {
            frmProducto form = new frmProducto();
            form.MdiParent = this;
          
            form.Show();
            form.dataListado.ClearSelection();
        }

        private void mnuProveedor_Click(object sender, EventArgs e)
        {
            frmProveedor form = new frmProveedor();
            form.MdiParent = this;
            
            form.Show();
            form.dataListado.ClearSelection();
        }

        private void mnuSalones_Click(object sender, EventArgs e)
        {
            frmSalon form = new frmSalon();
            form.MdiParent = this;
          
            form.Show();
            form.dataListado.ClearSelection();
        }

        private void mnuTermino_Click(object sender, EventArgs e)
        {
            frmTermino form = new frmTermino();
            form.MdiParent = this;
    
            form.Show();
            form.dataListado.ClearSelection();
        }

        private void mnuTipoTrabajador_Click(object sender, EventArgs e)
        {
            frmTipoTrabajador form = new frmTipoTrabajador();
            form.MdiParent = this;
      
            form.Show();
            form.dataListado.ClearSelection();
        }

        private void mnuTrabajador_Click(object sender, EventArgs e)
        {
            frmTrabajador form = new frmTrabajador();
            form.MdiParent = this;
           
            form.Show();
            form.dataListado.ClearSelection();
        }

        private void mnuCerrarCaja_Click(object sender, EventArgs e)
        {
            frmCierreCaja frm = new frmCierreCaja();
            frm.MdiParent = this;
            frm.lblMontoInicial.Text = this.lblMontoApertura.Text;
            frm.lblidUsuario.Text = this.lblIdUsuario.Text;
            frm.lblEstado.Text = this.lblEstadoCaja.Text;
            frm.lblFechaCaja.Text = this.lblFechaCaja.Text;
            frm.lblfechaApert.Text = this.lblFechaApertura.Text;
            frm.lblTrabajador.Text = this.lblUsuario.Text + " " + this.lblApellidos.Text;
            
            frm.Show();
        }

        private void mnuIngresoDinero_Click(object sender, EventArgs e)
        {
            frmIngresoCaja frm = new frmIngresoCaja();
            frm.MdiParent = this;
            frm.lblIdUsuario.Text = this.lblIdUsuario.Text;
        
            frm.Show();
        }

        private void mnuSalidaDinero_Click(object sender, EventArgs e)
        {
            frmEgresos frm = new frmEgresos();
            frm.lblIdUsuario.Text = this.lblIdUsuario.Text;
       
            frm.MdiParent = this;
            frm.Show();
        }

        private void deVentaFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMostrarVentas frm = new frmMostrarVentas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void nivelesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNivel frm = new frmNivel();
            frm.MdiParent = this;
           
            frm.Show();
            frm.dataListado.ClearSelection();
        }

        private void insumosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInsumo frm = new frmInsumo();
            frm.MdiParent = this;
           
            frm.Show();
            frm.dataListado.ClearSelection();
        }

        private void ingresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIngresoAlmacen frm = frmIngresoAlmacen.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
         
            frm.lblIdUsuario.Text = this.lblIdUsuario.Text;
        }

        private void salidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalidaAlmacen frm = new frmSalidaAlmacen();
            frm.MdiParent = this;
   
            frm.Show();
            frm.lblIdUsuario.Text = this.lblIdUsuario.Text;
        }

        private void almacenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
  
        }

        private void gestionarAlmacénToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAlmacen frm = new frmAlmacen();
            frm.MdiParent = this;
            
            frm.Show();
        }

        private void tipoMovimentoIngresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipoMovAlmacen_Ingreso frm = new frmTipoMovAlmacen_Ingreso();
            frm.MdiParent = this;
        
            frm.Show();
        }

        private void tipoMovimientoSalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipoMovAlmacen_Salida frm = new frmTipoMovAlmacen_Salida();
            frm.MdiParent = this;
     
            frm.Show();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockActual frm = new frmStockActual();
            frm.MdiParent = this;
          
            frm.Show();
            frm.dataListado.ClearSelection();
        }

        private void verMovimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMostrarMovimientoAlmacen frm = new frmMostrarMovimientoAlmacen();
            frm.MdiParent = this;
          
            frm.Show();
        }

        private void verVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMostrarVentas frm = new frmMostrarVentas();
            frm.MdiParent = this;
          
            frm.Show();
        }

        private void verComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMostrarCompras frm = new frmMostrarCompras();
            frm.MdiParent = this;
          
            frm.Show();
        }

        private void porProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteVentasProducto frm = new frmReporteVentasProducto();
            frm.MdiParent = this;
        
            frm.Show();
        }

        private void porClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteVentaCliente frm = new frmReporteVentaCliente();
            frm.MdiParent = this;
           
            frm.Show();
        }

        private void porUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteVentasTrabajador frm = new frmReporteVentasTrabajador();
            frm.MdiParent = this;
            frm.Show();
        }

        private void porProductoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmReporteComprasProducto frm = new frmReporteComprasProducto();
            frm.MdiParent = this;
            
            frm.Show();
        }

        private void porProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteComprasProveedor frm = new frmReporteComprasProveedor();
            frm.MdiParent = this;
          
            frm.Show();
        }

        private void porUsuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmReporteComprasTrabajador frm = new frmReporteComprasTrabajador();
            frm.MdiParent = this;
       
            frm.Show();
        }

        private void unidadMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUnidadMedida frm = new frmUnidadMedida();
            frm.MdiParent = this;
           
            frm.Show();
            frm.dataListado.ClearSelection();
        }

        private void cambioContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCambioPass frm = new frmCambioPass();
            frm.MdiParent = this;
            frm.lblIdTrabajador.Text = this.lblIdUsuario.Text;
            frm.lblUsuario.Text = this.lblUsuarioSis.Text;
            frm.lblPassword.Text = this.lblPass.Text;
         
            frm.Show();
        }

        private void platosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPlato frm = new frmPlato();
            frm.MdiParent = this;
       
            frm.Show();
            frm.dataListado.ClearSelection();
        }

        private void mnuBackup_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                rpta = NBackup.realizarBackup();
                if (rpta == "OK")
                {
                    MessageBox.Show("Se realizó el backup con éxito");

                }
                else
                {
                    MessageBox.Show(rpta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tBackup_Tick(object sender, EventArgs e)
        {
            NBackup.realizarBackup();
        }

        private void mnuMovimientoBarra_Click(object sender, EventArgs e)
        {
           
        }

        private void mnuVerMovBarra_Click(object sender, EventArgs e)
        {
           
        }

        private void mnuDescuento_Click(object sender, EventArgs e)
        {
            frmDescuento frm = new frmDescuento();
            frm.MdiParent = this;
            
            frm.Show();
        }

        private void porInsumoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteVentaInsumo frm = new frmReporteVentaInsumo();
            frm.MdiParent = this;
            
            frm.Show();
        }

        private void deliveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMesero frm = new frmMesero();
            frm.MdiParent = this;
            frm.lblBandera.Text = "1";
            frm.lblIdUsuario.Text = this.lblIdUsuario.Text;
        
            frm.Show();
        }

        private void porCobrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVentasReservadas frm = new frmVentasReservadas();
            frm.MdiParent = this;
            frm.lblIdUsuario.Text = this.lblIdUsuario.Text;
        
            frm.Show();
            frm.dataListado.ClearSelection();
        }

        private void mnuAbrirTurno_Click(object sender, EventArgs e)
        {
            frmAperturaTurno frm = new frmAperturaTurno();
            frm.MdiParent = this;
        
            frm.lblIdUsuario.Text = this.lblIdUsuario.Text;
            frm.Show();
        }

        private void mnuCerrarTurno_Click(object sender, EventArgs e)
        {
            
        }

        private void reporteDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void controlCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void corteParcialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCorteParcial frm = new frmCorteParcial();
            frm.MdiParent = this;
            DataTable dtEstado = NCaja_A.MostrarEstadoCajaMonto(1);
            if(dtEstado.Rows[0]["Estado"].ToString() =="Corte Caja")
            {
                frm.lblfechaApert.Text = dtEstado.Rows[0]["Fecha"].ToString();
                frm.lblMontoInicial.Text = dtEstado.Rows[0]["monto"].ToString();
            }else
            {
                frm.lblfechaApert.Text = this.lblFechaCorteCaja.Text;
                frm.lblMontoInicial.Text = this.lblMontoCorteCaja.Text;
            }
            
            frm.lblidUsuario.Text = this.lblIdUsuario.Text;
            frm.lblEstado.Text = this.lblEstadoCaja.Text;
            frm.lblFechaCaja.Text = this.lblFechaCaja.Text;
            frm.lblTrabajador.Text = this.lblUsuario.Text + " " + this.lblApellidos.Text;
           
            frm.Show();
        }

        private void consultaDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmControlCaja frm = new frmControlCaja();
            frm.MdiParent = this;

            frm.lblFechaApertura.Text = this.lblFechaApertura.Text;
            frm.txtMontoApertura.Text = this.lblMontoApertura.Text;
            
            frm.Show();
        }

        private void cortesParcialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMostrarCortes frm = new frmMostrarCortes();
            frm.MdiParent = this;
           
            frm.Show();
            frm.dataListado.ClearSelection();
        }

        private void mnuStock_Click(object sender, EventArgs e)
        {
            frmStockActual frm = new frmStockActual();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuStock_Click_1(object sender, EventArgs e)
        {
            frmStockActual frm = new frmStockActual();
            frm.MdiParent = this;
            frm.Show();
            frm.dataListado.ClearSelection();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMostrarVentas frm = new frmMostrarVentas();
            frm.lblIdUsuario.Text = this.lblIdUsuario.Text;
            frm.MdiParent = this;

            frm.Show();
        }

        private void mnuConsultaCierre_Click(object sender, EventArgs e)
        {
            frmConsultaCierreCaja frm = new frmConsultaCierreCaja();
            frm.MdiParent = this;
            frm.Show();
            frm.dataListado.ClearSelection();
        }

        private void reporteDeMovCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteMovCaja frm = new frmReporteMovCaja();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuComprobantesAnulados_Click(object sender, EventArgs e)
        {
            frmMostrarComprobanteAnulado frm = new frmMostrarComprobanteAnulado();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmModuloSalon frm = new frmModuloSalon();
            frm.MdiParent = this;
            frm.lblIdUsuario.Text = this.lblIdUsuario.Text;

            frm.Show();
        }

        private void reporteDeMovProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteMovAlmacenProducto frm = new frmReporteMovAlmacenProducto();
            frm.MdiParent = this;
            frm.Show();
        }

        private void porTipoComprobanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteVentasTipoComprobante frm = new frmReporteVentasTipoComprobante();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
