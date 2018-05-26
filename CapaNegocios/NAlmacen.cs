using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;


namespace CapaNegocios
{
    public class NAlmacen
    {
        public static string Insertar(string nombre, string estado)
        {
            DAlmacen Obj = new DAlmacen();
            Obj.Nombre = nombre;
            Obj.Estado = estado;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idAlmacen, string nombre, string estado)
        {
            DAlmacen Obj = new DAlmacen();
            Obj.IdAlmacen = idAlmacen;
            Obj.Nombre = nombre;
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DAlmacen().Mostrar();
        }

    }
}
