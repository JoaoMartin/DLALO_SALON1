using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NUnidadMedida
    {
        public static string Insertar(string nombre, string estado)
        {
            DUnidadMedida Obj = new DUnidadMedida();
            Obj.Nombre = nombre;
            Obj.Estado = estado;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idUnidad, string nombre, string estado)
        {
            DUnidadMedida Obj = new DUnidadMedida();
            Obj.IdUnidad = idUnidad;
            Obj.Nombre = nombre;
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idUnidad)
        {
            DUnidadMedida Obj = new DUnidadMedida();
            Obj.IdUnidad = idUnidad;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DUnidadMedida().Mostrar();
        }

        public static DataTable Buscar(string textoBuscar)
        {
            DUnidadMedida Obj = new DUnidadMedida();
            Obj.TextoBuscar = textoBuscar;
            return Obj.Buscar(Obj);
        }
    }
}
