using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DProducto
    {
        private int _IdProducto;
        private string _Nombre;
        private string _Descripcion;
        private decimal _Stock;
        private decimal _PrecioVenta;
        private string _Tipo;
        private string _Estado;
        private int _IdCategoria;
        private string _TextoBuscar;
        private string _Imprimir;
        private decimal _StockMinimo;
        private decimal _Costo;
        private int _IdUnidadMedida;
        private decimal _StockTienda;
        public int IdProducto
        {
            get
            {
                return _IdProducto;
            }

            set
            {
                _IdProducto = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }

            set
            {
                _Descripcion = value;
            }
        }

        public decimal Stock
        {
            get
            {
                return _Stock;
            }

            set
            {
                _Stock = value;
            }
        }

        public decimal PrecioVenta
        {
            get
            {
                return _PrecioVenta;
            }

            set
            {
                _PrecioVenta = value;
            }
        }

        public string Tipo
        {
            get
            {
                return _Tipo;
            }

            set
            {
                _Tipo = value;
            }
        }

        public string Estado
        {
            get
            {
                return _Estado;
            }

            set
            {
                _Estado = value;
            }
        }

        public int IdCategoria
        {
            get
            {
                return _IdCategoria;
            }

            set
            {
                _IdCategoria = value;
            }
        }

        public string TextoBuscar
        {
            get
            {
                return _TextoBuscar;
            }

            set
            {
                _TextoBuscar = value;
            }
        }

        public string Imprimir
        {
            get
            {
                return _Imprimir;
            }

            set
            {
                _Imprimir = value;
            }
        }

        public decimal StockMinimo
        {
            get
            {
                return _StockMinimo;
            }

            set
            {
                _StockMinimo = value;
            }
        }

        public decimal Costo
        {
            get
            {
                return _Costo;
            }

            set
            {
                _Costo = value;
            }
        }

        public int IdUnidadMedida
        {
            get
            {
                return _IdUnidadMedida;
            }

            set
            {
                _IdUnidadMedida = value;
            }
        }

        public decimal StockTienda
        {
            get
            {
                return _StockTienda;
            }

            set
            {
                _StockTienda = value;
            }
        }

        public DProducto() { }

        public DProducto(int idProducto, string nombre, string descripcion, decimal stock, decimal precioVenta, string tipo, string estado, int idCategoria, string textoBuscar, string imprimir, decimal stockMinimo, decimal costo, int idUnidadMedida, decimal stockTienda)
        {
            this.IdProducto = idProducto;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Stock = stock;
            this.PrecioVenta = precioVenta;
            this.Tipo = tipo;
            this.Estado = estado;
            this.IdCategoria = idCategoria;
            this.TextoBuscar = textoBuscar;
            this.Imprimir = imprimir;
            this.StockMinimo = stockMinimo;
            this.Costo = costo;
            this.IdUnidadMedida = idUnidadMedida;
            this.StockTienda = stockTienda;
        }

        public string Insertar(DProducto Producto)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                sqlCon.Open();
                //Comandos
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_insertarProducto";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@idProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdProducto);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Producto.Nombre;
                sqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 250;
                ParDescripcion.Value = Producto.Descripcion;
                sqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParStock = new SqlParameter();
                ParStock.ParameterName = "@stock";
                ParStock.SqlDbType = SqlDbType.Decimal;
                ParStock.Precision = 8;
                ParStock.Scale = 3;
                ParStock.Value = Producto.Stock;
                sqlCmd.Parameters.Add(ParStock);

                SqlParameter ParPrcioVenta = new SqlParameter();
                ParPrcioVenta.ParameterName = "@precioVenta";
                ParPrcioVenta.SqlDbType = SqlDbType.Decimal;
                ParPrcioVenta.Precision = 8;
                ParPrcioVenta.Scale = 2;
                ParPrcioVenta.Value = Producto.PrecioVenta;
                sqlCmd.Parameters.Add(ParPrcioVenta);

                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@tipo";
                ParTipo.SqlDbType = SqlDbType.Char;
                ParTipo.Size = 1;
                ParTipo.Value = Producto.Tipo;
                sqlCmd.Parameters.Add(ParTipo);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Char;
                ParEstado.Size = 1;
                ParEstado.Value = Producto.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idCategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Producto.IdCategoria;
                sqlCmd.Parameters.Add(ParIdCategoria);


                SqlParameter ParImprimir = new SqlParameter();
                ParImprimir.ParameterName = "@imprimir";
                ParImprimir.SqlDbType = SqlDbType.VarChar;
                ParImprimir.Size = 50;
                ParImprimir.Value = Producto.Imprimir;
                sqlCmd.Parameters.Add(ParImprimir);

                SqlParameter ParStockMinimo = new SqlParameter();
                ParStockMinimo.ParameterName = "@stockMinimo";
                ParStockMinimo.SqlDbType = SqlDbType.Decimal;
                ParStockMinimo.Precision = 8;
                ParStockMinimo.Scale = 3;
                ParStockMinimo.Value = Producto.StockMinimo;
                sqlCmd.Parameters.Add(ParStockMinimo);

                SqlParameter ParCosto = new SqlParameter();
                ParCosto.ParameterName = "@costo";
                ParCosto.SqlDbType = SqlDbType.Decimal;
                ParCosto.Precision = 8;
                ParCosto.Scale = 2;
                ParCosto.Value = Producto.Costo;
                sqlCmd.Parameters.Add(ParCosto);

                SqlParameter ParIdUnidadMedida = new SqlParameter();
                ParIdUnidadMedida.ParameterName = "@idUnidadMedida";
                ParIdUnidadMedida.SqlDbType = SqlDbType.Int;
                ParIdUnidadMedida.Value = Producto.IdUnidadMedida;
                sqlCmd.Parameters.Add(ParIdUnidadMedida);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingresó el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return rpta;
        }

        public string Editar(DProducto Producto)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                sqlCon.Open();
                //Comandos
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_editarProducto";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idProducto";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Producto.IdProducto;
                sqlCmd.Parameters.Add(ParIdProveedor);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Producto.Nombre;
                sqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 250;
                ParDescripcion.Value = Producto.Descripcion;
                sqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParStock = new SqlParameter();
                ParStock.ParameterName = "@stock";
                ParStock.SqlDbType = SqlDbType.Decimal;
                ParStock.Precision = 8;
                ParStock.Scale = 3;
                ParStock.Value = Producto.Stock;
                sqlCmd.Parameters.Add(ParStock);

                SqlParameter ParPrcioVenta = new SqlParameter();
                ParPrcioVenta.ParameterName = "@precioVenta";
                ParPrcioVenta.SqlDbType = SqlDbType.Decimal;
                ParPrcioVenta.Precision = 8;
                ParPrcioVenta.Scale = 2;
                ParPrcioVenta.Value = Producto.PrecioVenta;
                sqlCmd.Parameters.Add(ParPrcioVenta);

                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@tipo";
                ParTipo.SqlDbType = SqlDbType.Char;
                ParTipo.Size = 1;
                ParTipo.Value = Producto.Tipo;
                sqlCmd.Parameters.Add(ParTipo);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Char;
                ParEstado.Size = 1;
                ParEstado.Value = Producto.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idCategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Producto.IdCategoria;
                sqlCmd.Parameters.Add(ParIdCategoria);

                SqlParameter ParImprimir = new SqlParameter();
                ParImprimir.ParameterName = "@imprimir";
                ParImprimir.SqlDbType = SqlDbType.VarChar;
                ParImprimir.Size = 50;
                ParImprimir.Value = Producto.Imprimir;
                sqlCmd.Parameters.Add(ParImprimir);

                SqlParameter ParStockMinimo = new SqlParameter();
                ParStockMinimo.ParameterName = "@stockMinimo";
                ParStockMinimo.SqlDbType = SqlDbType.Decimal;
                ParStockMinimo.Precision = 8;
                ParStockMinimo.Scale = 3;
                ParStockMinimo.Value = Producto.StockMinimo;
                sqlCmd.Parameters.Add(ParStockMinimo);

                SqlParameter ParCosto = new SqlParameter();
                ParCosto.ParameterName = "@costo";
                ParCosto.SqlDbType = SqlDbType.Decimal;
                ParCosto.Precision = 8;
                ParCosto.Scale = 2;
                ParCosto.Value = Producto.Costo;
                sqlCmd.Parameters.Add(ParCosto);

                SqlParameter ParIdUnidadMedida = new SqlParameter();
                ParIdUnidadMedida.ParameterName = "@idUnidadMedida";
                ParIdUnidadMedida.SqlDbType = SqlDbType.Int;
                ParIdUnidadMedida.Value = Producto.IdUnidadMedida;
                sqlCmd.Parameters.Add(ParIdUnidadMedida);


                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se editó el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return rpta;
        }

        public string EditarDescuento(int idCategoria,decimal porcentaje, string bandera)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                sqlCon.Open();
                //Comandos
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_DescuentoCategoria";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idCategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = idCategoria;
                sqlCmd.Parameters.Add(ParIdCategoria);

                SqlParameter ParPorcentaje = new SqlParameter();
                ParPorcentaje.ParameterName = "@porcentaje";
                ParPorcentaje.SqlDbType = SqlDbType.Decimal;
                ParPorcentaje.Precision = 8;
                ParPorcentaje.Scale = 2;
                ParPorcentaje.Value = porcentaje;
                sqlCmd.Parameters.Add(ParPorcentaje);

                SqlParameter ParBandera = new SqlParameter();
                ParBandera.ParameterName = "@bandera";
                ParBandera.SqlDbType = SqlDbType.Char;
                ParBandera.Size = 1;
                ParBandera.Value = bandera;
                sqlCmd.Parameters.Add(ParBandera);
 
                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se registró el descuento";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return rpta;
        }

        public string Eliminar(DProducto Producto)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                sqlCon.Open();
                //Comandos
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_eliminarProducto";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idProducto";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Producto.IdProducto;
                sqlCmd.Parameters.Add(ParIdProveedor);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se eliminó el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return rpta;
        }

        public DataTable Mostrar()
        {
            DataTable dtResultado = new DataTable("Producto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarProducto";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable MostrarArticuloReporte()
        {
            DataTable dtResultado = new DataTable("Producto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarProductoReporte";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }
        public DataTable MostrarPlato()
        {
            DataTable dtResultado = new DataTable("Producto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarProductoPlato";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable MostrarTodos()
        {
            DataTable dtResultado = new DataTable("Producto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarProductoTodos";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable MostrarPlatosMenu()
        {
            DataTable dtResultado = new DataTable("Producto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarPlatosMenu";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable MostrarArticulo()
        {
            DataTable dtResultado = new DataTable("Producto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarProductoArticulos";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable MostrarInsumos_Articulo()
        {
            DataTable dtResultado = new DataTable("Producto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarProductoInsumo";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable MostrarProductoCategoria(DProducto Producto)
        {
            DataTable dtResultado = new DataTable("Producto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarProductosCategoria";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idCategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Producto.IdCategoria;
                sqlCmd.Parameters.Add(ParIdCategoria);


                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable MostrarDetallePlato(DProducto Producto)
        {
            DataTable dtResultado = new DataTable("Producto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarDetallePlato";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@idProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Value = Producto.IdProducto;
                sqlCmd.Parameters.Add(ParIdProducto);


                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable BuscarCategoriaProducto(DProducto Producto)
        {
            DataTable dtResultado = new DataTable("Producto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarCategoriaProducto";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Producto.TextoBuscar;

                sqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable BuscarCategoriaProductoPlato(DProducto Producto)
        {
            DataTable dtResultado = new DataTable("Producto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarCategoriaProductoPlato";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Producto.TextoBuscar;

                sqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable BuscarNombeProducto(DProducto Producto)
        {
            DataTable dtResultado = new DataTable("Producto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarNombreProducto";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Producto.TextoBuscar;

                sqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable BuscarNombeProductoPlato(DProducto Producto)
        {
            DataTable dtResultado = new DataTable("Producto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarNombreProductoPlato";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Producto.TextoBuscar;

                sqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable BuscarNombeProductoTodos(DProducto Producto)
        {
            DataTable dtResultado = new DataTable("Producto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarNombreProductoTodos";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Producto.TextoBuscar;

                sqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable BuscarDescripcionProducto(DProducto Producto)
        {
            DataTable dtResultado = new DataTable("Producto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarDescripcionProducto";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Producto.TextoBuscar;

                sqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable BuscarCodigoProducto(DProducto Producto)
        {
            DataTable dtResultado = new DataTable("Producto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarCodigoProducto";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Producto.TextoBuscar;

                sqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }
        public DataTable BuscarCategoriaProductoArticulo(DProducto Producto)
        {
            DataTable dtResultado = new DataTable("Producto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarCategoriaProductoArticulo";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Producto.TextoBuscar;

                sqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable BuscarNombeProductoArticulo(DProducto Producto)
        {
            DataTable dtResultado = new DataTable("Producto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarNombreProductoArticulo";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Producto.TextoBuscar;

                sqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public string InsertarProductoCompuesto(DProducto Producto, List<DDetalleProducto> DetalleProducto)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                sqlCon.Open();

                SqlTransaction sqlTran = sqlCon.BeginTransaction();
                //Comandos
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.Transaction = sqlTran;
                sqlCmd.CommandText = "sp_insertarProducto";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@idProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdProducto);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Producto.Nombre;
                sqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 250;
                ParDescripcion.Value = Producto.Descripcion;
                sqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParStock = new SqlParameter();
                ParStock.ParameterName = "@stock";
                ParStock.SqlDbType = SqlDbType.Decimal;
                ParStock.Precision = 8;
                ParStock.Scale = 3;
                ParStock.Value = Producto.Stock;
                sqlCmd.Parameters.Add(ParStock);

                SqlParameter ParPrcioVenta = new SqlParameter();
                ParPrcioVenta.ParameterName = "@precioVenta";
                ParPrcioVenta.SqlDbType = SqlDbType.Decimal;
                ParPrcioVenta.Precision = 8;
                ParPrcioVenta.Scale = 2;
                ParPrcioVenta.Value = Producto.PrecioVenta;
                sqlCmd.Parameters.Add(ParPrcioVenta);

                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@tipo";
                ParTipo.SqlDbType = SqlDbType.Char;
                ParTipo.Size = 1;
                ParTipo.Value = Producto.Tipo;
                sqlCmd.Parameters.Add(ParTipo);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Char;
                ParEstado.Size = 1;
                ParEstado.Value = Producto.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idCategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Producto.IdCategoria;
                sqlCmd.Parameters.Add(ParIdCategoria);


                SqlParameter ParImprimir = new SqlParameter();
                ParImprimir.ParameterName = "@imprimir";
                ParImprimir.SqlDbType = SqlDbType.VarChar;
                ParImprimir.Size = 50;
                ParImprimir.Value = Producto.Imprimir;
                sqlCmd.Parameters.Add(ParImprimir);

                SqlParameter ParStockMinimo = new SqlParameter();
                ParStockMinimo.ParameterName = "@stockMinimo";
                ParStockMinimo.SqlDbType = SqlDbType.Decimal;
                ParStockMinimo.Precision = 8;
                ParStockMinimo.Scale = 3;
                ParStockMinimo.Value = Producto.StockMinimo;
                sqlCmd.Parameters.Add(ParStockMinimo);

                SqlParameter ParCosto = new SqlParameter();
                ParCosto.ParameterName = "@costo";
                ParCosto.SqlDbType = SqlDbType.Decimal;
                ParCosto.Precision = 8;
                ParCosto.Scale = 2;
                ParCosto.Value = Producto.Costo;
                sqlCmd.Parameters.Add(ParCosto);

                SqlParameter ParIdUnidadMedida = new SqlParameter();
                ParIdUnidadMedida.ParameterName = "@idUnidadMedida";
                ParIdUnidadMedida.SqlDbType = SqlDbType.Int;
                ParIdUnidadMedida.Value = Producto.IdUnidadMedida;
                sqlCmd.Parameters.Add(ParIdUnidadMedida);

                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";
                if (rpta.Equals("OK"))
                {
                    this.IdProducto = Convert.ToInt32(sqlCmd.Parameters["@idProducto"].Value);
                    foreach (DDetalleProducto det in DetalleProducto)
                    {
                        det.IdProducto = this.IdProducto;

                        rpta = det.Insertar(det, ref sqlCon, ref sqlTran);
                        if (!rpta.Equals("OK"))
                        {
                            break;

                        }
                    }
                }

                if (rpta.Equals("OK"))
                {
                    sqlTran.Commit();
                }
                else
                {
                    sqlTran.Rollback();
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return rpta;
        }

        public DataTable MostrarStockProduto(DProducto Producto)
        {
            DataTable dtResultado = new DataTable("Producto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarStockProducto";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@idProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Value = Producto.IdProducto;
                sqlCmd.Parameters.Add(ParIdProducto);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }
        public DataTable MostrarDetalleProducto(DProducto Producto)
        {
            DataTable dtResultado = new DataTable("DetalleProducto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarDetalleProducto";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@idProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Value = Producto.IdProducto;
                sqlCmd.Parameters.Add(ParIdProducto);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable MostrarDetalleProducto_Venta(DProducto Producto)
        {
            DataTable dtResultado = new DataTable("DetalleProducto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarDetalleProducto_Venta";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@idProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Value = Producto.IdProducto;
                sqlCmd.Parameters.Add(ParIdProducto);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable MostrarStockMinimo()
        {
            DataTable dtResultado = new DataTable("Producto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarStockMinimo";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public string EditarStock(DProducto Producto)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                sqlCon.Open();
                //Comandos
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_editarStockCompuesto";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@idProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Value = Producto.IdProducto;
                sqlCmd.Parameters.Add(ParIdProducto);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = Producto.Stock;
                sqlCmd.Parameters.Add(ParCantidad);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se editó el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return rpta;
        }

       
        public DataTable MostrarStockProductosAlmacen()
        {
            DataTable dtResultado = new DataTable("Producto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarStockProducto_Almacen";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable BuscarProducto_Almacen(DProducto Producto)
        {
            DataTable dtResultado = new DataTable("Producto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarProducto_Almacen";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Producto.TextoBuscar;

                sqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public string EditarCostoInsumo(DProducto Producto)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                sqlCon.Open();
                //Comandos
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_editarCostoInsumo";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idProducto";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Producto.IdProducto;
                sqlCmd.Parameters.Add(ParIdProveedor);

                SqlParameter ParCosto = new SqlParameter();
                ParCosto.ParameterName = "@costo";
                ParCosto.SqlDbType = SqlDbType.Decimal;
                ParCosto.Precision = 8;
                ParCosto.Scale = 2;
                ParCosto.Value = Producto.Costo;
                sqlCmd.Parameters.Add(ParCosto);


                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se editó el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return rpta;
        }

        public DataTable MostrarProductoDescuento()
        {
            DataTable dtResultado = new DataTable("Producto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarProductoDescuento";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

    }
}
