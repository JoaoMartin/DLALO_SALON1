using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NTipoMovAlmacen
    {
        public static string Insertar(string nombre, string tipo, string estado)
        {
            DTipoMovAlmacen Obj = new DTipoMovAlmacen();
            Obj.Nombre = nombre;
            Obj.Tipo = tipo;
            Obj.Estado = estado;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idTipoMov, string nombre)
        {
            DTipoMovAlmacen Obj = new DTipoMovAlmacen();
            Obj.IdTipoMovAlmacen = idTipoMov;
            Obj.Nombre = nombre;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idTipoMov)
        {
            DTipoMovAlmacen Obj = new DTipoMovAlmacen();
            Obj.IdTipoMovAlmacen = idTipoMov;
            return Obj.Eliminar(Obj);
        }

        public static DataTable MostrarTipoMovIngreso()
        {
            return new DTipoMovAlmacen().MostrarTipoMovIngreso();
        }

        public static DataTable MostrarTipoMovSalida()
        {
            return new DTipoMovAlmacen().MostrarTipoMovSalida();
        }


    }
}
