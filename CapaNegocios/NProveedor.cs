using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NProveedor
    {
        public static string Insertar(string razonSocial, string tipoDoc, string numDoc, string direccion, string telefono, string email, string estado)
        {
            DProveedor Obj = new DProveedor();
            Obj.RazonSocial = razonSocial;
            Obj.TipoDoc = tipoDoc;
            Obj.NumDoc = numDoc;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Estado = estado;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idProveedor, string razonSocial, string tipoDoc, string numDoc, string direccion, string telefono, string email, string estado)
        {
            DProveedor Obj = new DProveedor();
            Obj.IdProveedor = idProveedor;
            Obj.RazonSocial = razonSocial;
            Obj.TipoDoc = tipoDoc;
            Obj.NumDoc = numDoc;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idProveedor)
        {
            DProveedor Obj = new DProveedor();
            Obj.IdProveedor = idProveedor;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DProveedor().Mostrar();
        }

        public static DataTable BuscarRazonSocial(string textoBuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarRazonSocial(Obj);
        }

        public static DataTable BuscarRuc(string textoBuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarRuc(Obj);
        }

        public static DataTable BuscarCodigo(string textoBuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarCodigo(Obj);
        }
    }
}
