using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NVenta
    {
        public static string InsertarPedido(int? idCliente, int? idMesa, DateTime fecha, string estado, string formaPago, decimal descuento, 
            int idTrabajador, string modo,int nroCaja,DataTable dtDetalle,DataTable dtDetalleMenu, DateTime fechaEntrega, decimal adelanto,
            int idTrabajador_Cobro, string obs, string motivo, string cliente, string telefono)
        {
            DVenta Obj = new DVenta();
            Obj.IdCliente = idCliente;
            Obj.IdMesa = idMesa;
            Obj.Fecha = fecha;
            Obj.Estado = estado;
            Obj.FormaPago = formaPago;
            Obj.Descuento = descuento;
            Obj.IdTrabajador = idTrabajador;
            Obj.Modo = modo;
            Obj.NroCaja = nroCaja;
            Obj.FechaEntrega = fechaEntrega;
            Obj.Adelanto = adelanto;
            Obj.IdTrabajador_Cobro = idTrabajador_Cobro;
            Obj.Obs = obs;
            Obj.Motivo = motivo;
            Obj.Cliente = cliente;
            Obj.Telefono = telefono;

            List<DDetalleVenta> detalles = new List<DDetalleVenta>();
            foreach (DataRow row in dtDetalle.Rows)
            {
                DDetalleVenta detalle = new DDetalleVenta();
                detalle.IdProducto = Convert.ToInt32(row["Cod"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["Cant"].ToString());
                detalle.PrecioVenta = Convert.ToDecimal(row["Precio_Un"].ToString());
                detalle.Descuento = Convert.ToDecimal(row["Descuento"].ToString());
                detalle.Nota = row["Nota"].ToString();
                detalle.Tipo = row["Tipo"].ToString();
                detalle.Barra = row["Barra"].ToString();
                detalle.Estado = row["Estado"].ToString();
                detalles.Add(detalle);
            }


            List<DDetalleVentaMenu> detallesMenu = new List<DDetalleVentaMenu>();
            foreach (DataRow row in dtDetalleMenu.Rows)
            {
                DDetalleVentaMenu detalleM = new DDetalleVentaMenu();
                detalleM.IdProducto = Convert.ToInt32(row["Cod"].ToString());
                detalleM.Cantidad = Convert.ToInt32(row["Cant"].ToString());
                detalleM.Barra = row["Barra"].ToString();
                detallesMenu.Add(detalleM);
            }
            return Obj.InsertarPedido(Obj, detalles, detallesMenu);
        }

        public static string InsertarPedidoDelivery(int? idCliente, int? idMesa, DateTime fecha, string estado, string formaPago, decimal descuento, int idTrabajador, string modo, int nroCaja,
                                           string tipoCompr,decimal vuelto, string estadoD, DataTable dtDetalle, decimal total, decimal pagaCon,
                                           string repartidor, decimal dctoInd, DataTable dtDetalleMenu, DateTime fechaEntrega,decimal adelanto,
                                           int idTrabajador_Cobro, string obs, string motivo, string cliente, string telefono)
        {
            DVenta Obj = new DVenta();
            Obj.IdCliente = idCliente;
            Obj.IdMesa = idMesa;
            Obj.Fecha = fecha;
            Obj.Estado = estado;
            Obj.FormaPago = formaPago;
            Obj.Descuento = descuento;
            Obj.IdTrabajador = idTrabajador;
            Obj.Modo = modo;
            Obj.NroCaja = nroCaja;
            Obj.FechaEntrega = fechaEntrega;
            Obj.Adelanto = adelanto;
            Obj.IdTrabajador_Cobro = idTrabajador_Cobro;
            Obj.Obs = obs;
            Obj.Motivo = motivo;
            Obj.Cliente = cliente;
            Obj.Telefono = telefono;

            List<DDetalleVenta> detalles = new List<DDetalleVenta>();
            foreach (DataRow row in dtDetalle.Rows)
            {
                DDetalleVenta detalle = new DDetalleVenta();
                detalle.IdProducto = Convert.ToInt32(row["Cod"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["Cant"].ToString());
                detalle.PrecioVenta = Convert.ToDecimal(row["Precio_Un"].ToString());
                detalle.Descuento = Convert.ToDecimal(row["Descuento"].ToString());
                detalle.Nota = row["Nota"].ToString();
                detalle.Tipo = row["Tipo"].ToString();
                detalle.Barra = row["Barra"].ToString();
                detalle.Estado = row["Estado"].ToString();
                detalles.Add(detalle);
            }

            List<DDetalleVentaMenu> detallesMenu1 = new List<DDetalleVentaMenu>();
            foreach (DataRow row in dtDetalleMenu.Rows)
            {
                DDetalleVentaMenu detalleM = new DDetalleVentaMenu();
                detalleM.IdProducto = Convert.ToInt32(row["Cod"].ToString());
                detalleM.Cantidad = Convert.ToInt32(row["Cant"].ToString());
                detalleM.Barra = row["Barra"].ToString();

                detallesMenu1.Add(detalleM);
            }


            DDelivery Obj1 = new DDelivery();
            Obj1.TipoCompr = tipoCompr;
            Obj1.Vuelto = vuelto;
            Obj1.Estado = estadoD;
            Obj1.Total = total;
            Obj1.PagaCon = pagaCon;
            Obj1.Repartidor = repartidor;
            Obj1.DctoInd = dctoInd;

            return Obj.InsertarPedidoDelivery(Obj, detalles, Obj1,detallesMenu1);
        }

        public static string InsertarPedidoPagado(int? idCliente,  int? idMesa, DateTime fecha, string estado, string formaPago, decimal descuento, int idTrabajador, string modo, int nroCaja,
                                                   string tipoCompr,int serie,decimal igv,string estadoComp,decimal monto, decimal efectivo, decimal tarjeta, decimal redondeo,
                                                   DataTable dtDetalle, decimal vuelto,DataTable dtDetalleMenu, DateTime fechaEntrega, decimal adelanto,
                                                   int idTrabajador_Cobro, string obs, string motivo, string cliente, string telefono)
        {
            DVenta Obj = new DVenta();
            Obj.IdCliente = idCliente;
            Obj.IdMesa = idMesa;
            Obj.Fecha = fecha;
            Obj.Estado = estado;
            Obj.FormaPago = formaPago;
            Obj.Descuento = descuento;
            Obj.IdTrabajador = idTrabajador;
            Obj.Modo = modo;
            Obj.NroCaja = nroCaja;
            Obj.FechaEntrega = fechaEntrega;
            Obj.Adelanto = adelanto;
            Obj.IdTrabajador_Cobro = idTrabajador_Cobro;
            Obj.Obs = obs;
            Obj.Motivo = motivo;
            Obj.Cliente = cliente;
            Obj.Telefono = telefono;

            List<DDetalleVenta> detalles = new List<DDetalleVenta>();
            foreach (DataRow row in dtDetalle.Rows)
            {
                DDetalleVenta detalle = new DDetalleVenta();
                detalle.IdProducto = Convert.ToInt32(row["Cod"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["Cant"].ToString());
                detalle.PrecioVenta = Convert.ToDecimal(row["Precio_Un"].ToString());
                detalle.Descuento = Convert.ToDecimal(row["Descuento"].ToString());
                detalle.Nota = row["Nota"].ToString();
                detalle.Tipo = row["Tipo"].ToString();
                detalle.Barra = row["Barra"].ToString();
                detalle.Estado = row["Estado"].ToString();

                detalles.Add(detalle);
            }

            List<DDetalleVentaMenu> detallesMenu = new List<DDetalleVentaMenu>();
            foreach (DataRow row in dtDetalleMenu.Rows)
            {
                DDetalleVentaMenu detalleM = new DDetalleVentaMenu();
                detalleM.IdProducto = Convert.ToInt32(row["Cod"].ToString());
                detalleM.Cantidad = Convert.ToInt32(row["Cant"].ToString());
                detalleM.Barra = row["Barra"].ToString();
                detallesMenu.Add(detalleM);
            }

            DComprobante Obj1 = new DComprobante();
            Obj1.TipoComprobante = tipoCompr;
            Obj1.Serie = serie;
            Obj1.Igv = igv;
            Obj1.Fecha = fecha;
            Obj1.Estado = estadoComp;
            Obj1.IdCliente = idCliente;
            Obj1.Monto = monto;
            Obj1.Efectivo = efectivo;
            Obj1.Tarjeta = tarjeta;
            Obj1.Redondeo = redondeo;
            Obj1.FormaPago = formaPago;
            Obj1.Vuelto = vuelto;

            return Obj.InsertarPedido_Pagado(Obj, detalles,Obj1,detallesMenu);
        }

        public static DataTable mostrarClienteVenta(int idVenta)
        {
            DVenta Obj = new DVenta();
            return Obj.mostrarClienteVenta(idVenta);
        }
        public static DataTable mostrarDetalleVenta(int idVenta)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarDetalleVenta(idVenta);
        }

        public static DataTable mostrarDetallePedido(int idVenta)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarDetallePedido(idVenta);
        }

       


        public static string EditarMesaVenta(int idVenta, int idMesa)
        {
            DVenta Obj = new DVenta();
            Obj.IdVenta = idVenta;
            Obj.IdMesa = idMesa;
            return Obj.EditarMesaVenta(Obj);
        }


        public static DataTable mostrarDetalleVenta_SepararCuenta(int idVenta)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarDetalleVenta_SepararCuenta(idVenta);
        }

        public static string EditarVentaCancelada(int idVenta, decimal descuento, string formaPago, string obs)
        {
            DVenta Obj = new DVenta();
            Obj.IdVenta = idVenta;
            Obj.Descuento = descuento;
            Obj.FormaPago = formaPago;
            Obj.Obs = obs;
            return Obj.EditarVentaCancelada(Obj);
        }

        public static string EditarVentaCanceladaR(int idVenta, string estado)
        {
            DVenta Obj = new DVenta();
            Obj.IdVenta = idVenta;
            Obj.Estado = estado;
          
            return Obj.EditarVentaCanceladaR(Obj);
        }

        public static string EditarReservaCancelada(int idVenta)
        {
            DVenta Obj = new DVenta();
            Obj.IdVenta = idVenta;
           

            return Obj.EditarReservaCancelada(Obj);
        }



        public static string EditarVentaCS(int idVenta)
        {
            DVenta Obj = new DVenta();
            Obj.IdVenta = idVenta;
            return Obj.EditarVentaCS(Obj);
        }


        public static string EditarVentaD(int idVenta)
        {
            DVenta Obj = new DVenta();
            Obj.IdVenta = idVenta;
            return Obj.EditarVentaD(Obj);
        }

        public static string EliminarCS(int idVenta)
        {
            DVenta Obj = new DVenta();
            Obj.IdVenta = idVenta;
            return Obj.Eliminar(Obj);
        }

        public static string InsertarPedidoSeparado(int? idCliente,  int? idMesa, DateTime fecha, string estado, string formaPago, decimal descuento, int idTrabajador,
            string modo, int nroCaja, DataTable dtDetalle,DataTable dtDetalleMenu, DateTime fechaEntrega, decimal adelanto, int idTrabajador_Cobro, string obs,
            string motivo, string cliente, string telefono)
        {
            DVenta Obj = new DVenta();
            Obj.IdCliente = idCliente;
            Obj.IdMesa = idMesa;
            Obj.Fecha = fecha;
            Obj.Estado = estado;
            Obj.FormaPago = formaPago;
            Obj.Descuento = descuento;
            Obj.IdTrabajador = idTrabajador;
            Obj.Modo = modo;
            Obj.NroCaja = nroCaja;
            Obj.FechaEntrega = fechaEntrega;
            Obj.Adelanto = adelanto;
            Obj.IdTrabajador_Cobro = idTrabajador_Cobro;
            Obj.Obs = obs;
            Obj.Motivo = motivo;
            Obj.Cliente = cliente;
            Obj.Telefono = telefono;

            List<DDetalleVenta> detalles = new List<DDetalleVenta>();
            foreach (DataRow row in dtDetalle.Rows)
            {
                DDetalleVenta detalle = new DDetalleVenta();
                detalle.IdProducto = Convert.ToInt32(row["Cod"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["Cant"].ToString());
                detalle.PrecioVenta = Convert.ToDecimal(row["Precio_Un"].ToString());
                detalle.Descuento = Convert.ToDecimal(row["Descuento"].ToString());
                detalle.Nota = row["Nota"].ToString();
                detalle.Tipo = row["Tipo"].ToString();
                detalle.Barra = row["Barra"].ToString();
                detalle.Estado = row["Estado"].ToString();
                detalles.Add(detalle);
            }

            List<DDetalleVentaMenu> detallesMenu = new List<DDetalleVentaMenu>();
            foreach (DataRow row in dtDetalleMenu.Rows)
            {
                DDetalleVentaMenu detalleM = new DDetalleVentaMenu();
                detalleM.IdProducto = Convert.ToInt32(row["Cod"].ToString());
                detalleM.Cantidad = Convert.ToInt32(row["Cant"].ToString());
                detalleM.Barra = row["Barra"].ToString();
                detallesMenu.Add(detalleM);
            }
            return Obj.InsertarPedido_Dividido(Obj, detalles,detallesMenu);
        }

        public static string InsertarPedidoDividido(int? idCliente, int? idMesa, DateTime fecha, string estado, string formaPago,
            decimal descuento, int idTrabajador, string modo, int nroCaja, DataTable dtDetalle, DataTable dtDetalleMenu, DateTime fechaEntrega,
            decimal adelanto, int idTrabajador_Cobro, string obs, string motivo, string cliente, string telefono)
        {
            DVenta Obj = new DVenta();
            Obj.IdCliente = idCliente;
            Obj.IdMesa = idMesa;
            Obj.Fecha = fecha;
            Obj.Estado = estado;
            Obj.FormaPago = formaPago;
            Obj.Descuento = descuento;
            Obj.IdTrabajador = idTrabajador;
            Obj.Modo = modo;
            Obj.NroCaja = nroCaja;
            Obj.FechaEntrega = fechaEntrega;
            Obj.Adelanto = adelanto;
            Obj.IdTrabajador_Cobro = idTrabajador_Cobro;
            Obj.Obs = obs;
            Obj.Motivo = motivo;
            Obj.Cliente = cliente;
            Obj.Telefono = telefono;

            List<DDetalleVenta> detalles = new List<DDetalleVenta>();
            foreach (DataRow row in dtDetalle.Rows)
            {
                DDetalleVenta detalle = new DDetalleVenta();
                detalle.IdProducto = Convert.ToInt32(row["Cod"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["Cant"].ToString());
                detalle.PrecioVenta = Convert.ToDecimal(row["Precio_Un"].ToString());
                detalle.Descuento = Convert.ToDecimal(row["Descuento"].ToString());
                detalle.Nota = row["Nota"].ToString();
                detalle.Tipo = row["Tipo"].ToString();
                detalle.Estado = row["Estado"].ToString();
                detalles.Add(detalle);
            }

            List<DDetalleVentaMenu> detallesMenu = new List<DDetalleVentaMenu>();
            foreach (DataRow row in dtDetalleMenu.Rows)
            {
                DDetalleVentaMenu detalleM = new DDetalleVentaMenu();
                detalleM.IdProducto = Convert.ToInt32(row["Cod"].ToString());
                detalleM.Cantidad = Convert.ToInt32(row["Cant"].ToString());
                detallesMenu.Add(detalleM);
            }
            return Obj.InsertarPedido(Obj, detalles,detallesMenu);
        }

        //REPORTES

        public static DataTable reporteVentaFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            DVenta Obj = new DVenta();
            return Obj.reporteVentasFecha(fechaInicio, fechaFin);
        }

        public static DataTable reporteDetalleVenta(int idVenta)
        {
            DVenta Obj = new DVenta();
            return Obj.reporteDetalleVenta(idVenta);
        }

        public static DataTable reporteVentaProducto(DateTime fechaInicio, DateTime fechaFin, int idProducto)
        {
            DVenta Obj = new DVenta();
            return Obj.reporteVentasProducto(fechaInicio, fechaFin, idProducto);
        }

        public static DataTable reporteVentaProductoCaja(DateTime fechaInicio, DateTime fechaFin, int idProducto, int nroCaja)
        {
            DVenta Obj = new DVenta();
            return Obj.reporteVentasProductoCaja(fechaInicio, fechaFin, idProducto, nroCaja);
        }
        public static DataTable reporteVentaInsumo(DateTime fechaInicio, DateTime fechaFin, int idProducto)
        {
            DVenta Obj = new DVenta();
            return Obj.reporteVentasInsumo(fechaInicio, fechaFin, idProducto);
        }

        public static DataTable reporteVentaInsumoCaja(DateTime fechaInicio, DateTime fechaFin, int idProducto, int nroCaja)
        {
            DVenta Obj = new DVenta();
            return Obj.reporteVentasInsumoCaja(fechaInicio, fechaFin, idProducto, nroCaja);
        }

        public static DataTable reporteVentaCliente(DateTime fechaInicio, DateTime fechaFin, int idCliente)
        {
            DVenta Obj = new DVenta();
            return Obj.reporteVentasCliente(fechaInicio, fechaFin, idCliente);
        }

        public static DataTable reporteVentaTrabajador(DateTime fechaInicio, DateTime fechaFin, int idTrabajador)
        {
            DVenta Obj = new DVenta();
            return Obj.reporteVentasUsuario(fechaInicio, fechaFin, idTrabajador);
        }

        public static DataTable reporteVentaCaja(DateTime fechaInicio, DateTime fechaFin, int nroCaja)
        {
            DVenta Obj = new DVenta();
            return Obj.reporteVentasCaja(fechaInicio, fechaFin, nroCaja);
        }

        public static string InsertarPedidoPagadoManual(int? idCliente, int? idMesa, DateTime fecha, string estado, string formaPago, decimal descuento, int idTrabajador, string modo, int nroCaja,
                                                 string tipoCompr, int serie, int nroCom, decimal igv, string estadoComp, decimal monto, decimal efectivo, decimal tarjeta, 
                                                 decimal redondeo, DataTable dtDetalle, decimal vuelto,DataTable dtDetalleMenu,
                                                 DateTime fechaEntrega, decimal adelanto, int idTrabajador_Cobro, string obs, string motivo, string cliente, string telefono)
        {
            DVenta Obj = new DVenta();
            Obj.IdCliente = idCliente;
            Obj.IdMesa = idMesa;
            Obj.Fecha = fecha;
            Obj.Estado = estado;
            Obj.FormaPago = formaPago;
            Obj.Descuento = descuento;
            Obj.IdTrabajador = idTrabajador;
            Obj.Modo = modo;
            Obj.NroCaja = nroCaja;
            Obj.FechaEntrega = fechaEntrega;
            Obj.Adelanto = adelanto;
            Obj.IdTrabajador_Cobro = idTrabajador_Cobro;
            Obj.Obs = obs;
            Obj.Motivo = motivo;
            Obj.Cliente = cliente;
            Obj.Telefono = telefono;

            List<DDetalleVenta> detalles = new List<DDetalleVenta>();
            foreach (DataRow row in dtDetalle.Rows)
            {
                DDetalleVenta detalle = new DDetalleVenta();
                detalle.IdProducto = Convert.ToInt32(row["Cod"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["Cant"].ToString());
                detalle.PrecioVenta = Convert.ToDecimal(row["Precio_Un"].ToString());
                detalle.Descuento = Convert.ToDecimal(row["Descuento"].ToString());
                detalle.Nota = row["Nota"].ToString();
                detalle.Tipo = row["Tipo"].ToString();
                detalle.Estado = row["Estado"].ToString();
                detalles.Add(detalle);
            }

            List<DDetalleVentaMenu> detallesMenu = new List<DDetalleVentaMenu>();
            foreach (DataRow row in dtDetalleMenu.Rows)
            {
                DDetalleVentaMenu detalleM = new DDetalleVentaMenu();
                detalleM.IdProducto = Convert.ToInt32(row["Cod"].ToString());
                detalleM.Cantidad = Convert.ToInt32(row["Cant"].ToString());
                detallesMenu.Add(detalleM);
            }

            DComprobante Obj1 = new DComprobante();
            Obj1.TipoComprobante = tipoCompr;
            Obj1.Serie = serie;
            Obj1.Correlativo = nroCom;
            Obj1.Igv = igv;
            Obj1.Fecha = fecha;
            Obj1.Estado = estadoComp;
            Obj1.IdCliente = idCliente;
            Obj1.Monto = monto;
            Obj1.Efectivo = efectivo;
            Obj1.Tarjeta = tarjeta;
            Obj1.Redondeo = redondeo;
            Obj1.FormaPago = formaPago;
            Obj1.Vuelto = vuelto;

            return Obj.InsertarPedido_PagadoManual(Obj, detalles, Obj1,detallesMenu);
        }

        public static string InsertarPedidoPagadoR(int? idCliente, int? idMesa, DateTime fecha, string estado, string formaPago, decimal descuento,
     int idTrabajador, string modo, int nroCaja, DataTable dtDetalle, DataTable dtDetalleMenu, DateTime fechaEntrega, decimal adelanto,
     int idTrabajador_Cobro, string obs, string motivo, string cliente, string telefono)
        {
            DVenta Obj = new DVenta();
            Obj.IdCliente = idCliente;
            Obj.IdMesa = idMesa;
            Obj.Fecha = fecha;
            Obj.Estado = estado;
            Obj.FormaPago = formaPago;
            Obj.Descuento = descuento;
            Obj.IdTrabajador = idTrabajador;
            Obj.Modo = modo;
            Obj.NroCaja = nroCaja;
            Obj.FechaEntrega = fechaEntrega;
            Obj.Adelanto = adelanto;
            Obj.IdTrabajador_Cobro = idTrabajador_Cobro;
            Obj.Obs = obs;
            Obj.Motivo = motivo;
            Obj.Cliente = cliente;
            Obj.Telefono = telefono;

            List<DDetalleVenta> detalles = new List<DDetalleVenta>();
            foreach (DataRow row in dtDetalle.Rows)
            {
                DDetalleVenta detalle = new DDetalleVenta();
                detalle.IdProducto = Convert.ToInt32(row["Cod"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["Cant"].ToString());
                detalle.PrecioVenta = Convert.ToDecimal(row["Precio_Un"].ToString());
                detalle.Descuento = Convert.ToDecimal(row["Descuento"].ToString());
                detalle.Nota = row["Nota"].ToString();
                detalle.Tipo = row["Tipo"].ToString();
                detalle.Barra = row["Barra"].ToString();
                detalle.Estado = "Reservada";
                detalles.Add(detalle);
            }


            List<DDetalleVentaMenu> detallesMenu = new List<DDetalleVentaMenu>();
            foreach (DataRow row in dtDetalleMenu.Rows)
            {
                DDetalleVentaMenu detalleM = new DDetalleVentaMenu();
                detalleM.IdProducto = Convert.ToInt32(row["Cod"].ToString());
                detalleM.Cantidad = Convert.ToInt32(row["Cant"].ToString());
                detalleM.Barra = row["Barra"].ToString();
                detallesMenu.Add(detalleM);
            }
            return Obj.InsertarPedidoPagadoR(Obj, detalles, detallesMenu);
        }

        public static DataTable MostrarPedidosPendientes()
        {
            return new DVenta().mostrarPedidosPendientes();
        }

        public static DataTable Buscar(string textoBuscar)
        {
            DVenta Obj = new DVenta();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarPedidosPendientes(Obj);
        }

        public static DataTable BuscarCliente(string textoBuscar)
        {
            DVenta Obj = new DVenta();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarPedidosPendientesCliente(Obj);
        }

        public static string EditarEstadoVentaRecogida(int idVenta)
        {
            DVenta Obj = new DVenta();
            Obj.IdVenta = idVenta;
            return Obj.EditarEstadoVentaReservada(Obj);
        }

        public static string InsertarPedidoPagadoR(int? idCliente, int? idMesa, DateTime fecha, string estado, string formaPago, decimal descuento, int idTrabajador, string modo, int nroCaja,
                                                  string tipoCompr, int serie, decimal igv, string estadoComp, decimal monto, decimal efectivo, decimal tarjeta, decimal redondeo,
                                                  DataTable dtDetalle, decimal vuelto, DataTable dtDetalleMenu, DateTime fechaEntrega, decimal adelanto,
                                                  int idTrabajador_Cobro, string obs, string motivo, string cliente, string telefono)
        {
            DVenta Obj = new DVenta();
            Obj.IdCliente = idCliente;
            Obj.IdMesa = idMesa;
            Obj.Fecha = fecha;
            Obj.Estado = estado;
            Obj.FormaPago = formaPago;
            Obj.Descuento = descuento;
            Obj.IdTrabajador = idTrabajador;
            Obj.Modo = modo;
            Obj.NroCaja = nroCaja;
            Obj.FechaEntrega = fechaEntrega;
            Obj.Adelanto = adelanto;
            Obj.IdTrabajador_Cobro = idTrabajador_Cobro;
            Obj.Obs = obs;
            Obj.Motivo = motivo;
            Obj.Cliente = cliente;
            Obj.Telefono = telefono;

            List<DDetalleVenta> detalles = new List<DDetalleVenta>();
            foreach (DataRow row in dtDetalle.Rows)
            {
                DDetalleVenta detalle = new DDetalleVenta();
                detalle.IdProducto = Convert.ToInt32(row["Cod"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["Cant"].ToString());
                detalle.PrecioVenta = Convert.ToDecimal(row["Precio_Un"].ToString());
                detalle.Descuento = Convert.ToDecimal(row["Descuento"].ToString());
                detalle.Nota = row["Nota"].ToString();
                detalle.Tipo = row["Tipo"].ToString();
                detalle.Barra = row["Barra"].ToString();
                detalle.Estado = "Reservada";

                detalles.Add(detalle);
            }

            List<DDetalleVentaMenu> detallesMenu = new List<DDetalleVentaMenu>();
            foreach (DataRow row in dtDetalleMenu.Rows)
            {
                DDetalleVentaMenu detalleM = new DDetalleVentaMenu();
                detalleM.IdProducto = Convert.ToInt32(row["Cod"].ToString());
                detalleM.Cantidad = Convert.ToInt32(row["Cant"].ToString());
                detalleM.Barra = row["Barra"].ToString();
                detallesMenu.Add(detalleM);
            }

            DComprobante Obj1 = new DComprobante();
            Obj1.TipoComprobante = tipoCompr;
            Obj1.Serie = serie;
            Obj1.Igv = igv;
            Obj1.Fecha = fecha;
            Obj1.Estado = estadoComp;
            Obj1.IdCliente = idCliente;
            Obj1.Monto = monto;
            Obj1.Efectivo = efectivo;
            Obj1.Tarjeta = tarjeta;
            Obj1.Redondeo = redondeo;
            Obj1.FormaPago = formaPago;
            Obj1.Vuelto = vuelto;

            return Obj.InsertarPedido_Pagado(Obj, detalles, Obj1, detallesMenu);
        }
        public static DataTable reporteVentaFechas_TipoComprobante(DateTime fechaInicio, DateTime fechaFin, string tipo)
        {
            DVenta Obj = new DVenta();
            return Obj.reporteVentasFecha_TipoComprobante(fechaInicio, fechaFin, tipo);
        }
    }
}
