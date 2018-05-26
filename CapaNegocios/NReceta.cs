using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NReceta
    {
        public static string Insertar(int idProducto, string nombre, string estado, DataTable dtDetalle)
        {
            DReceta Obj = new DReceta();
            Obj.IdProducto = idProducto;
            Obj.Nombre = nombre;
            Obj.Estado = estado;

            List<DDetalleReceta> detalles = new List<DDetalleReceta>();
            foreach (DataRow row in dtDetalle.Rows)
            {
                DDetalleReceta detalle = new DDetalleReceta();
                detalle.IdInsumo = Convert.ToInt32(row["Codigo"].ToString());
                detalle.Cantidad = Convert.ToDecimal(row["Cantidad"].ToString());
                detalle.Costo = Convert.ToDecimal(row["Costo"].ToString());
                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj, detalles);
        }
        public static string Eliminar(int idReceta)
        {
            DReceta Obj = new DReceta();
            Obj.IdReceta = idReceta;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar(int idProducto)
        {
            DReceta Obj = new DReceta();
            Obj.IdProducto = idProducto;
            return Obj.Mostrar(Obj);
        }

        public static string EditarDetalle(int idDetalleReceta,decimal cantidad)
        {
            DDetalleReceta Obj = new DDetalleReceta();
            Obj.IdDetalleReceta = idDetalleReceta;
            Obj.Cantidad = cantidad;
            return Obj.Editar(Obj);
        }

        public static string InsertarAdicional(int idReceta, int idInsumo, decimal cantidad, decimal costo)
        {
            DDetalleReceta Obj = new DDetalleReceta();
            Obj.IdReceta = idReceta;
            Obj.IdInsumo = idInsumo;
            Obj.Cantidad = cantidad;
            Obj.Costo = costo;
            return Obj.InsertarAdicional(Obj);
        }

        public static string EliminarDetalle(int idDetalleReceta)
        {
            DDetalleReceta Obj = new DDetalleReceta();
            Obj.IdDetalleReceta = idDetalleReceta;
            return Obj.Eliminar(Obj);
        }
    }
}
