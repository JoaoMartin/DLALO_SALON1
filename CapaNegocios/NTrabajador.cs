using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NTrabajador
    {
        public static string Insertar(string nombre, string apellidos, string tipoDoc, string numDoc, string sexo, DateTime fechaNac, string direccion, string telefono,
            string email, string estado,  int idTipoTrabajador,string usuario, string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.TipoDoc = tipoDoc;
            Obj.NumDoc = numDoc;
            Obj.Sexo = sexo;
            Obj.FechaNac = fechaNac;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Estado = estado;
            Obj.IdTipoTrabajador = idTipoTrabajador;
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idTrabajador, string nombre, string apellidos, string tipoDoc, string numDoc, string sexo, DateTime fechaNac, string direccion, string telefono,
            string email, string estado, int idTipoTrabajador, string usuario, string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.IdTrabajador = idTrabajador;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.TipoDoc = tipoDoc;
            Obj.NumDoc = numDoc;
            Obj.Sexo = sexo;
            Obj.FechaNac = fechaNac;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Estado = estado;
            Obj.IdTipoTrabajador = idTipoTrabajador;
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idTrabajador)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.IdTrabajador = idTrabajador;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DTrabajador().Mostrar();
        }

        public static DataTable MostrarMesero()
        {
            return new DTrabajador().MostrarMesero();
        }

        public static DataTable BuscarNombre(string textoBuscar)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNombre(Obj);
        }

        public static DataTable BuscarApellido(string textoBuscar)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarApellidos(Obj);
        }

        public static DataTable BuscarDni(string textoBuscar)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarDni(Obj);
        }

        public static DataTable BuscarSexo(string textoBuscar)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarSexo(Obj);
        }

        public static DataTable BuscarTipoTrabajador(string textoBuscar)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarTipoTrabajador(Obj);
        }

        public static DataTable Login(string usuario, string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Login(Obj);
        }

        public static DataTable LoginMesero(string password)
        {
            DTrabajador Obj = new DTrabajador();
           
            Obj.Password = password;
            return Obj.LoginMesero(Obj);
        }

        public static string cambiarPass(int idUsuario, string usuario, string pass)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.IdTrabajador = idUsuario;
            Obj.Usuario = usuario;
            Obj.Password = pass;
            return Obj.cambiarPass(Obj);
        }
    }
}
