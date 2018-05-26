using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NInsumo
    {
        public static string Insertar(int idUnidadMedida, string nombre, decimal costo, decimal stock, decimal stockMinimo, string estado)
        {
            DInsumo Obj = new DInsumo();
            Obj.IdUnidadMedida = idUnidadMedida;
            Obj.Nombre = nombre;
            Obj.Costo = costo;
            Obj.Stock = stock;
            Obj.StockMinimo = stockMinimo;
            Obj.Estado = estado;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idInsumo, int idUnidadMedida, string nombre, decimal costo, decimal stock, decimal stockMinimo, string estado)
        {
            DInsumo Obj = new DInsumo();
            Obj.IdInsumo = idInsumo;
            Obj.IdUnidadMedida = idUnidadMedida;
            Obj.Nombre = nombre;
            Obj.Costo = costo;
            Obj.Stock = stock;
            Obj.StockMinimo = stockMinimo;
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }

        public static string EditarStock(int idInsumo, decimal cantidad)
        {
            DInsumo Obj = new DInsumo();
            return Obj.EditarStock(idInsumo, cantidad);
        }

        public static string Eliminar(int idInsumo)
        {
            DInsumo Obj = new DInsumo();
            Obj.IdInsumo = idInsumo;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DInsumo().Mostrar();
        }


        public static DataTable Buscar(string textoBuscar)
        {
            DInsumo Obj = new DInsumo();
            Obj.TextoBuscar = textoBuscar;
            return Obj.Buscar(Obj);
        }

        public static DataTable MostrarStockInsumoAlmacen()
        {
            return new DInsumo().MostrarStockInsumosAlmacen();
        }

        public static DataTable BuscarInsumo_Almacen(string textoBuscar)
        {
            DInsumo Obj = new DInsumo();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarInsumo_Almacen(Obj);
        }
    }
}
