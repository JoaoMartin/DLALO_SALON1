using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NDelivery
    {
        public static DataTable Mostrar()
        {
            return new DDelivery().mostrarDeliveryCobrar();
        }

        public static string Editar(int idVenta, string estado)
        {
            DDelivery Obj = new DDelivery();
            Obj.IdVenta = idVenta;
            Obj.Estado = estado;
            return Obj.EditarEstadoDelivery(Obj);
        }

        public static string Eliminar(int idVenta)
        {
            DDelivery Obj = new DDelivery();
            Obj.IdVenta = idVenta;
            return Obj.EliminarVentaDelivery(Obj);
        }
    }
}
