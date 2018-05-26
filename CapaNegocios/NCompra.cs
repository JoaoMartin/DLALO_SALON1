using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NCompra
    {
        public static string Insertar(int idUsuario, int idProveedor, DateTime fechaIngreso, string tipoComprobante, string serie, string correlativo, decimal igv,string formaPago, string tipoMoneda ,string estado, decimal total, DataTable dtDetalle)
        {
            DCompra Obj = new DCompra();
            Obj.IdUsuario = idUsuario;
            Obj.IdProveedor = idProveedor;
            Obj.FechaIngreso = fechaIngreso;
            Obj.TipoComprobante = tipoComprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Igv = igv;
            Obj.FormaPago = formaPago;
            Obj.TipoMoneda = tipoMoneda;
            Obj.Estado = estado;
            Obj.Total = total;

            List<DDetalleCompra> detalles = new List<DDetalleCompra>();
            foreach(DataRow row in dtDetalle.Rows)
            {
                DDetalleCompra detalle = new DDetalleCompra();
                detalle.IdProducto = Convert.ToInt32(row["Codigo"].ToString());
                detalle.Cantidad = Convert.ToDecimal(row["Cantidad"].ToString());
                detalle.PrecioCompra = Convert.ToDecimal(row["Precio_Unitario"].ToString());
                detalle.PrecioVenta = Convert.ToDecimal(row["Precio_Venta"].ToString());
                detalle.Tipo = row["Tipo"].ToString();
                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj,detalles);
        }

        public static string Anular(int idIngreso)
        {
            DCompra Obj = new DCompra();
            Obj.IdIngreso = idIngreso;
            return Obj.Anular(Obj);
        }

        public static DataTable Mostrar(DateTime fechaInicio, DateTime fechaFin)
        {
            return new DCompra().Mostrar(fechaInicio,fechaFin);
        }

        public static DataTable BuscarFechas(string textoBuscar, string textoBuscar2)
        {
            DCompra Obj = new DCompra();
            return Obj.BuscarFecha(textoBuscar, textoBuscar2);
        }

        public static DataTable mostrarDetalleIngreso(int textoBuscar)
        {
            DCompra Obj = new DCompra();
            return Obj.MostrarDetalleIngreso(textoBuscar);
        }

        public static DataTable reporteCompraProducto(DateTime fechaInicio, DateTime fechaFin, int idProducto)
        {
            DCompra Obj = new DCompra();
            return Obj.reporteComprasProducto(fechaInicio, fechaFin, idProducto);
        }

        public static DataTable reporteCompraProveedor(DateTime fechaInicio, DateTime fechaFin, int idProveedor)
        {
            DCompra Obj = new DCompra();
            return Obj.reporteComprasProveedor(fechaInicio, fechaFin, idProveedor);
        }

        public static DataTable reporteCompraTrabajador(DateTime fechaInicio, DateTime fechaFin, int idTrabajador)
        {
            DCompra Obj = new DCompra();
            return Obj.reporteComprasTrabajador(fechaInicio, fechaFin, idTrabajador);
        }
    }
}
