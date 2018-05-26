using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NSalon
    {
        public static string Insertar(string nombre, string estado)
        {
            DSalon Obj = new DSalon();
            Obj.Nombre = nombre;
            Obj.Estado = estado;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idSalon, string nombre, string estado)
        {
            DSalon Obj = new DSalon();
            Obj.IdSalon = idSalon;
            Obj.Nombre = nombre;
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idSalon)
        {
            DSalon Obj = new DSalon();
            Obj.IdSalon = idSalon;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DSalon().Mostrar();
        }

        public static DataTable Buscar(string textoBuscar)
        {
            DSalon Obj = new DSalon();
            Obj.TextoBuscar = textoBuscar;
            return Obj.Buscar(Obj);
        }
    }
}
