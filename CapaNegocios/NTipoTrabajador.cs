using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NTipoTrabajador
    {
        public static string Insertar(string nombre, string descripcion, string estado)
        {
            DTipoTrabajador Obj = new DTipoTrabajador();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Estado = estado;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idTipoTrabajador, string nombre, string descripcion, string estado)
        {
            DTipoTrabajador Obj = new DTipoTrabajador();
            Obj.IdTipo = idTipoTrabajador;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idTipoTrabajador)
        {
            DTipoTrabajador Obj = new DTipoTrabajador();
            Obj.IdTipo = idTipoTrabajador;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DTipoTrabajador().Mostrar();
        }

        public static DataTable Buscar(string textoBuscar)
        {
            DTipoTrabajador Obj = new DTipoTrabajador();
            Obj.TextoBuscar = textoBuscar;
            return Obj.Buscar(Obj);
        }

        public static DataTable MostrarTipoTrabajador_Nivel()
        {
            return new DTipoTrabajador().MostrarTipoTrabajador_Nivel();
        }

        public static DataTable MostrarIdTipoUsuario(int idTrabajador)
        {
            return new DTipoTrabajador().MostrarIdTipoTrabajador(idTrabajador);
        }
    }
}
