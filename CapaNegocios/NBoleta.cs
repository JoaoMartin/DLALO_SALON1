using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NBoleta
    {
        public static string Insertar(int serie, DateTime fecha, int idVenta, string estado, int? idCliente)
        {
            DBoleta Obj = new DBoleta();
            Obj.Serie = serie;
            Obj.Fecha = fecha;
            Obj.IdVenta = idVenta;
            Obj.Estado = estado;
            Obj.IdCliente = idCliente;
            return Obj.Insertar(Obj);
        }
    }
}
