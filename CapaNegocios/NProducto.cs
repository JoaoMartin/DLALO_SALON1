using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NProducto
    {
        public static string Insertar(string nombre, string descripcion, decimal stock, decimal precioVenta, string tipo, string estado, int idCategoria, string imprimir, decimal stockMinimo, decimal costo, int idUnidadMedida)
        {
            DProducto Obj = new DProducto();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Stock = stock;
            Obj.PrecioVenta = precioVenta;
            Obj.Tipo = tipo;
            Obj.Estado = estado;
            Obj.IdCategoria = idCategoria;
            Obj.Imprimir = imprimir;
            Obj.StockMinimo = stockMinimo;
            Obj.Costo = costo;
            Obj.IdUnidadMedida = idUnidadMedida;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idProducto, string nombre, string descripcion, decimal stock, decimal precioVenta, string tipo, string estado, int idCategoria, string imprimir, decimal stockMinimo, decimal costo, int idUnidadMedida)
        {
            DProducto Obj = new DProducto();
            Obj.IdProducto = idProducto;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Stock = stock;
            Obj.PrecioVenta = precioVenta;
            Obj.Tipo = tipo;
            Obj.Estado = estado;
            Obj.IdCategoria = idCategoria;
            Obj.Imprimir = imprimir;
            Obj.StockMinimo = stockMinimo;
            Obj.Costo = costo;
            Obj.IdUnidadMedida = idUnidadMedida;
            return Obj.Editar(Obj);
        }

        public static string EditarCostoInsumo(int idProducto, decimal costo)
        {
            DProducto Obj = new DProducto();
            Obj.IdProducto = idProducto;
            Obj.Costo = costo;
            return Obj.EditarCostoInsumo(Obj);
        }

        public static string EditarDescuento(int idCategoria,decimal porcentaje, string bandera)
        {
            return new DProducto().EditarDescuento(idCategoria, porcentaje, bandera);
        }

        public static string Eliminar(int idProducto)
        {
            DProducto Obj = new DProducto();
            Obj.IdProducto = idProducto;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DProducto().Mostrar();
        }

        public static DataTable MostrarPlato()
        {
            return new DProducto().MostrarPlato();
        }

        public static DataTable MostrarTodos()
        {
            return new DProducto().MostrarTodos();
        }

        public static DataTable MostrarPlatosMenu()
        {
            return new DProducto().MostrarPlatosMenu();
        }

        public static DataTable MostrarArticulo()
        {
            return new DProducto().MostrarArticulo();
        }

        public static DataTable MostrarArticuloReporte()
        {
            return new DProducto().MostrarArticuloReporte();
        }

        public static DataTable MostrarInsumo_Articulo()
        {
            return new DProducto().MostrarInsumos_Articulo();
        }

        public static DataTable MostrarProductoCategoria(int idCategoria)
        {
            DProducto Obj = new DProducto();
            Obj.IdCategoria = idCategoria;
            return new DProducto().MostrarProductoCategoria(Obj);
        }

        public static DataTable MostrarDetallePlato(int idProducto)
        {
            DProducto Obj = new DProducto();
            Obj.IdProducto = idProducto;
            return new DProducto().MostrarDetallePlato(Obj);
        }

        public static DataTable MostrarProductoStock(int idProducto)
        {
            DProducto Obj = new DProducto();
            Obj.IdProducto = idProducto;
            return new DProducto().MostrarStockProduto(Obj);
        }
        public static DataTable BuscarCategoriaProducto(string textoBuscar)
        {
            DProducto Obj = new DProducto();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarCategoriaProducto(Obj);
        }

        public static DataTable BuscarCategoriaProductoPlato(string textoBuscar)
        {
            DProducto Obj = new DProducto();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarCategoriaProductoPlato(Obj);
        }

        public static DataTable BuscarNombeProducto(string textoBuscar)
        {
            DProducto Obj = new DProducto();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNombeProducto(Obj);
        }

        public static DataTable BuscarNombeProductoPlato(string textoBuscar)
        {
            DProducto Obj = new DProducto();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNombeProductoPlato(Obj);
        }

        public static DataTable BuscarNombeProductoTodos(string textoBuscar)
        {
            DProducto Obj = new DProducto();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNombeProductoTodos(Obj);
        }

        public static DataTable BuscarDescripcionProducto(string textoBuscar)
        {
            DProducto Obj = new DProducto();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarDescripcionProducto(Obj);
        }

        public static DataTable BuscarCodigoProducto(string textoBuscar)
        {
            DProducto Obj = new DProducto();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarCodigoProducto(Obj);
        }

        public static DataTable BuscarCategoriaProductoArticulo(string textoBuscar)
        {
            DProducto Obj = new DProducto();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarCategoriaProductoArticulo(Obj);
        }

        public static DataTable BuscarNombeProductoArticulo(string textoBuscar)
        {
            DProducto Obj = new DProducto();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNombeProductoArticulo(Obj);
        }

        public static string InsertarProductoCompuesto(string nombre, string descripcion, decimal stock, decimal precioVenta, string tipo, string estado, int idCategoria, string imprimir, decimal stockMinimo, decimal costo, DataTable dtDetalle, int idUnidadMedida)
        {
            DProducto Obj = new DProducto();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Stock = stock;
            Obj.PrecioVenta = precioVenta;
            Obj.Tipo = tipo;
            Obj.Estado = estado;
            Obj.IdCategoria = idCategoria;
            Obj.Imprimir = imprimir;
            Obj.StockMinimo = stockMinimo;
            Obj.Costo = costo;
            Obj.IdUnidadMedida = idUnidadMedida;

            List<DDetalleProducto> detalles = new List<DDetalleProducto>();
            foreach (DataRow row in dtDetalle.Rows)
            {
                DDetalleProducto detalle = new DDetalleProducto();
                detalle.Codigo = Convert.ToInt32(row["Codigo"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["Cantidad"].ToString());
                detalle.PrecioVenta = Convert.ToDecimal(row["Precio_Venta"].ToString());
                detalle.Nombre = row["Producto"].ToString();
                detalle.Tipo = row["Tipo"].ToString();
                detalles.Add(detalle);
            }
            return Obj.InsertarProductoCompuesto(Obj, detalles);
        }

        public static DataTable MostrarDetalleProducto(int idProducto)
        {
            DProducto Obj = new DProducto();
            Obj.IdProducto = idProducto;
            return Obj.MostrarDetalleProducto(Obj);
        }

        public static string EliminarDetalleProducto(int idDetalleProducto)
        {
            DDetalleProducto Obj = new DDetalleProducto();
            Obj.IdDetalleProducto = idDetalleProducto;
            return Obj.Eliminar(Obj);
        }

        public static string EditarProductoCompuesto(int idProducto, int cantidad, decimal precioVenta, int codigo, string nombre, string tipo)
        {
            DDetalleProducto Obj = new DDetalleProducto();
            Obj.IdProducto = idProducto;
            Obj.Cantidad = cantidad;
            Obj.PrecioVenta = precioVenta;
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Tipo = tipo;
            return Obj.Editar(Obj);

        }

        public static string EditarStock(int idProducto, int cantidad)
        {
            DProducto Obj = new DProducto();
            Obj.IdProducto = idProducto;
            Obj.Stock = cantidad;
            return Obj.EditarStock(Obj);

        }

        public static DataTable mostrarDetalleProductoVenta(int idProducto)
        {
            DDetalleProducto Obj = new DDetalleProducto();
            Obj.IdProducto = idProducto;
            return Obj.MostrarDetalleProductoVenta(Obj);
        }

        public static DataTable mostrarStockMinimo()
        {
            return new DProducto().MostrarStockMinimo();
        }

        public static DataTable mostrarDetalleProducto_Venta(int idProducto)
        {
            DProducto Obj = new DProducto();
            Obj.IdProducto = idProducto;
            return Obj.MostrarDetalleProducto_Venta(Obj);
        }

        public static string EditarDetalle(int idDetalleProducto, int cantidad)
        {
            DDetalleProducto Obj = new DDetalleProducto();
            Obj.IdDetalleProducto = idDetalleProducto;
            Obj.Cantidad = cantidad;
            return Obj.EditarCan(Obj);

        }

        public static DataTable MostrarStockProductoAlmacen()
        {
            return new DProducto().MostrarStockProductosAlmacen();
        }

        public static DataTable BuscarProducto_Almacen(string textoBuscar)
        {
            DProducto Obj = new DProducto();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarProducto_Almacen(Obj);
        }

        public static DataTable MostrarProductoDescuento()
        {
            return new DProducto().MostrarProductoDescuento();
        }

    }
}
