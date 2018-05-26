using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NCategoria
    {
        public static string Insertar(string nombre, string descripcion, string estado, int orden)
        {
            DCategoria Obj = new DCategoria();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Estado = estado;
            Obj.Orden = orden;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idCategoria,string nombre, string descripcion, string estado)
        {
            DCategoria Obj = new DCategoria();
            Obj.IdCategoria = idCategoria;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idCategoria)
        {
            DCategoria Obj = new DCategoria();
            Obj.IdCategoria = idCategoria;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DCategoria().Mostrar();
        }

        public static DataTable MostrarCatVenta()
        {
            return new DCategoria().MostrarVenta();
        }

        public static DataTable Buscar(string textoBuscar)
        {
            DCategoria Obj = new DCategoria();
            Obj.TextoBuscar = textoBuscar;
            return Obj.Buscar(Obj);
        }

        public static DataTable MostrarCategoriaCompuesto()
        {
            return new DCategoria().mostrarCategoriaCompuesto();
        }

        public static DataTable MostrarCategoriaProducto(int idProducto)
        {
            DCategoria Obj = new DCategoria();
            Obj.IdProducto = idProducto;
            return Obj.mostrarCategoriaProducto(Obj);
        }

        public static DataTable MostrarOrdenCategoria()
        {
            return new DCategoria().MostrarOrdenCat();
        }

    }
}
