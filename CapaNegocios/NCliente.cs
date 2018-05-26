using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;


namespace CapaNegocios
{
    public class NCliente
    {
        public static string Insertar(string nombre, DateTime fechaNac, string tipoDoc, string nroDoc, string direccion, string email, string telefono)
        {
            DCliente Obj = new DCliente();
            Obj.Nombre = nombre;
            Obj.FechaNac = fechaNac;
            Obj.TipoDoc = tipoDoc;
            Obj.NroDoc = nroDoc;
            Obj.Direccion = direccion;
            Obj.Email = email;
            Obj.Telefono = telefono;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idCliente, string nombre, DateTime fechaNac, string tipoDoc, string nroDoc, string direccion, string email, string telefono)
        {
            DCliente Obj = new DCliente();
            Obj.IdCliente = idCliente;
            Obj.Nombre = nombre;
            Obj.FechaNac = fechaNac;
            Obj.TipoDoc = tipoDoc;
            Obj.NroDoc = nroDoc;
            Obj.Direccion = direccion;
            Obj.Email = email;
            Obj.Telefono = telefono;
            return Obj.Editar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();
        }

        public static DataTable Buscar(string textoBuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textoBuscar;
            return Obj.Buscar(Obj);
        }

        public static DataTable BuscarDni(string textoBuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarDni(Obj);
        }

        public static DataTable mostrarClienteVenta(string nroDoc)
        {
            DCliente Obj = new DCliente();
            Obj.NroDoc = nroDoc;
            return Obj.mostrarClienteVenta(Obj);
        }

        public static string InsertarVenta(string nombre, DateTime fechaNac, string tipoDoc, string nroDoc, string direccion, string email, string telefono)
        {
            DCliente Obj = new DCliente();
            Obj.Nombre = nombre;
            Obj.FechaNac = fechaNac;
            Obj.TipoDoc = tipoDoc;
            Obj.NroDoc = nroDoc;
            Obj.Direccion = direccion;
            Obj.Email = email;
            Obj.Telefono = telefono;
            return Obj.InsertarVenta(Obj);
        }
    }
}
