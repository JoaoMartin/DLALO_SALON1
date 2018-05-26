using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NDetalleVenta
    {
        public static string InsertarAdicPedido(int idVenta, int idProducto, int cantidad, decimal precioVenta, decimal descuento, string nota,string tipo, string barra,
            DataTable dtDetalleMenu, string estado)
        {
            DDetalleVenta Obj = new DDetalleVenta();
            Obj.IdVenta = idVenta;
            Obj.IdProducto = idProducto;
            Obj.Cantidad = cantidad;
            Obj.PrecioVenta = precioVenta;
            Obj.Descuento = descuento;
            Obj.Nota = nota;
            Obj.Barra = barra;
            Obj.Tipo = tipo;
            Obj.Estado = estado;

            List<DDetalleVentaMenu> detallesMenu = new List<DDetalleVentaMenu>();
            foreach (DataRow row in dtDetalleMenu.Rows)
            {
                DDetalleVentaMenu detalleM = new DDetalleVentaMenu();
                detalleM.IdProducto = Convert.ToInt32(row["Cod"].ToString());
                detalleM.Cantidad = Convert.ToInt32(row["Cant"].ToString());
                detalleM.Barra = row["Barra"].ToString();
                detallesMenu.Add(detalleM);
            }
            return Obj.InsertarAdic(Obj,detallesMenu);
        }

        public static string EditarNotaPedido(int idDetalle, string nota, decimal descuento)
        {
            DDetalleVenta Obj = new DDetalleVenta();
            Obj.IdDetalleVenta = idDetalle;
            Obj.Nota = nota;
            Obj.Descuento = descuento;
            return Obj.EditarNota(Obj);
        }

        public static string Eliminar(int idDetalle)
        {
            DDetalleVenta Obj = new DDetalleVenta();
            Obj.IdDetalleVenta = idDetalle;
            return Obj.Eliminar(Obj);
        }

        public static string EditarDetalleVenta(int idDetalle, decimal descuento, decimal importe)
        {
            DDetalleVenta Obj = new DDetalleVenta();
            Obj.IdDetalleVenta = idDetalle;
            Obj.Descuento = descuento;
            Obj.PrecioVenta = importe;
            return Obj.EditarDetalleVenta(Obj);
        }

        public static string EditarCantidadDetalleVenta(int idDetalle, int cantidad, int idProducto)
        {
            DDetalleVenta Obj = new DDetalleVenta();
            Obj.IdDetalleVenta = idDetalle;
            Obj.Cantidad = cantidad;
            Obj.IdProducto = idProducto;
            return Obj.EditarCantidadDetalleVenta(Obj);
        }

        public static DataTable mostrarDetalleVentaMenu(int idDetalleVenta)
        {
            DDetalleVentaMenu Obj = new DDetalleVentaMenu();
            return Obj.mostrarDetalleVentaMenu(idDetalleVenta);
        }

        public static string EliminarDetalleVentaMenu(int idDetalleVenta)
        {
            DDetalleVentaMenu Obj = new DDetalleVentaMenu();
            return Obj.EliminarDetalleMenu(idDetalleVenta);
        }

        public static DataTable mostrarIDDetalleVenra(int idVenta)
        {
            DDetalleVenta Obj = new DDetalleVenta();
            return Obj.mostrarIdDetalleVenta(idVenta);
        }

        public static string ActualizarStockProd_Anulada(int idDetalleVenta)
        {
            DDetalleVenta Obj = new DDetalleVenta();
            Obj.IdDetalleVenta = idDetalleVenta;
            return Obj.ActualizarStockProd_Anulada(Obj);
        }

        public static string EditarStockProductoR( int cantidad, int idProducto)
        {
            DDetalleVenta Obj = new DDetalleVenta();
            Obj.Cantidad = cantidad;
            Obj.IdProducto = idProducto;

            return Obj.EditarStockProductoR(Obj);
        }

      
    }
}
