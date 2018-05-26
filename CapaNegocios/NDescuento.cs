using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NDescuento
    {
        public static string Insertar(int idProducto, string tipo, decimal porcentaje, string estado)
        {
            DDescuento Obj = new DDescuento();
            Obj.IdProducto = idProducto;
            Obj.Tipo = tipo;
            Obj.Porcentaje = porcentaje;
            Obj.Estado = estado;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idDescuento, int idProducto, decimal porcentaje, string estado)
        {
            DDescuento Obj = new DDescuento();
            Obj.IdDescuento = idDescuento;
            Obj.IdProducto = idProducto;
            Obj.Porcentaje = porcentaje;
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }

        public static DataTable MostrarDescuentoCategoria()
        {
            return new DDescuento().MostrarDescuentoCategoria();
        }

        public static DataTable MostrarDescuentoProducto()
        {
            return new DDescuento().MostrarDescuentoProducto();
        }

        public static string Eliminar(int idDescuento)
        {
            DDescuento Obj = new DDescuento();
            Obj.IdDescuento = idDescuento;
            return Obj.Eliminar(Obj);
        }
    }
}
