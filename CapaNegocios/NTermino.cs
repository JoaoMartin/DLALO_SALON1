using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NTermino
    {
        public static string Insertar(string nombre, string estado)
        {
            DTermino Obj = new DTermino();
            Obj.Nombre = nombre;
            Obj.Estado = estado;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idTermino, string nombre,  string estado)
        {
            DTermino Obj = new DTermino();
            Obj.IdTermino = idTermino;
            Obj.Nombre = nombre;
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idTermino)
        {
            DTermino Obj = new DTermino();
            Obj.IdTermino = idTermino;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DTermino().Mostrar();
        }

        public static DataTable Buscar(string textoBuscar)
        {
            DTermino Obj = new DTermino();
            Obj.TextoBuscar = textoBuscar;
            return Obj.Buscar(Obj);
        }
    }
}
