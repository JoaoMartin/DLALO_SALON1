using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NMovimientoAlmacen
    {
        public static string Insertar( int almacenDestino, int idTipoMov, int idTrabajador,  string entregado, DateTime fecha, string estado,string tipo, DataTable dtDetalle)
        {
            DMovimientoAlmacen Obj = new DMovimientoAlmacen();
            Obj.AlmacenDestino = almacenDestino;
            Obj.IdTipoMov = idTipoMov;
            Obj.IdTrabajador = idTrabajador;
            Obj.Entregado = entregado;
            Obj.Fecha = fecha;
            Obj.Estado = estado;
            Obj.Tipo = tipo;

            List<DDetalleMovimientoAlmacen> detalles = new List<DDetalleMovimientoAlmacen>();
            foreach (DataRow row in dtDetalle.Rows)
            {
                DDetalleMovimientoAlmacen detalle = new DDetalleMovimientoAlmacen();
                detalle.IdProducto = Convert.ToInt32(row["Codigo"].ToString());
                detalle.Cantidad = Convert.ToDecimal(row["Cantidad"].ToString());
                detalle.TipoProducto = row["TipoProducto"].ToString();
                detalle.TipoMov = row["TipoMov"].ToString();
                detalle.LugarSalida= row["Lugar"].ToString();
                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj, detalles);
        }

        public static DataTable mostrarMovimientoAlmacen(DateTime fechaInicio, DateTime fechaFin)
        {
            DMovimientoAlmacen Obj = new DMovimientoAlmacen();
            return Obj.mostrarMovimientoAlmacen(fechaInicio, fechaFin);
        }

        public static DataTable mostrarDetalleMovimiento(int idMovimiento)
        {
            DMovimientoAlmacen Obj = new DMovimientoAlmacen();
            return Obj.mostrarDetalleMovimiento(idMovimiento);
        }

        public static DataTable mostrarMovAlmacenProducto(int idProducto, string tipo)
        {
            DDetalleMovimientoAlmacen Obj = new DDetalleMovimientoAlmacen();
            return Obj.mostrarMovAlmacenProductos(idProducto, tipo);
        }
    }
}
