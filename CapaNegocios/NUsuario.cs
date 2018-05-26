using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NUsuario
    {
        public static string Insertar(string trabajador, string usuario, string pass, string estado, int idTipoTrabajador)
        {
            DUsuario Obj = new DUsuario();
            Obj.Trabajador = trabajador;
            Obj.Usuario = usuario;
            Obj.Pass = pass;
            Obj.Estado = estado;
            Obj.IdTipoTrabajador = idTipoTrabajador;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idUsuario, string trabajador, string usuario, string pass, string estado, int idTipoTrabajador)
        {
            DUsuario Obj = new DUsuario();
            Obj.IdUsuario = idUsuario;
            Obj.Trabajador = trabajador;
            Obj.Usuario = usuario;
            Obj.Pass = pass;
            Obj.Estado = estado;
            Obj.IdTipoTrabajador = idTipoTrabajador;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idUsuario)
        {
            DUsuario Obj = new DUsuario();
            Obj.IdUsuario = idUsuario;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DUsuario().Mostrar();
        }

        public static DataTable Buscar(string textoBuscar)
        {
            DUsuario Obj = new DUsuario();
            Obj.TextoBuscar = textoBuscar;
            return Obj.Buscar(Obj);
        }



    }
}
