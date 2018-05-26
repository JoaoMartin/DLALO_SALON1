using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NMarca
    {
        public static string Insertar(string nombre, string estado)
        {
            DMarca Obj = new DMarca();
            Obj.Nombre = nombre;
            Obj.Estado = estado;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idMarca, string nombre, string estado)
        {
            DMarca Obj = new DMarca();
            Obj.IdMarca= idMarca;
            Obj.Nombre = nombre;
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idMarca)
        {
            DMarca Obj = new DMarca();
            Obj.IdMarca = idMarca;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DMarca().Mostrar();
        }

        public static DataTable Buscar(string textoBuscar)
        {
            DMarca Obj = new DMarca();
            Obj.TextoBuscar = textoBuscar;
            return Obj.Buscar(Obj);
        }
    }
}
