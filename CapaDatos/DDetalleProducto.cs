using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalleProducto
    {
        private int _IdDetalleProducto;
        private int _IdProducto;
        private int _Cantidad;
        private decimal _PrecioVenta;
        private int _Codigo;
        private string _Nombre;
        private string _Tipo;

        public int IdDetalleProducto
        {
            get
            {
                return _IdDetalleProducto;
            }

            set
            {
                _IdDetalleProducto = value;
            }
        }

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

        public int Cantidad
        {
            get
            {
                return _Cantidad;
            }

            set
            {
                _Cantidad = value;
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

        public int Codigo
        {
            get
            {
                return _Codigo;
            }

            set
            {
                _Codigo = value;
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

        public DDetalleProducto() { }

        public DDetalleProducto(int idDetalleProducto, int idProducto, int cantidad, decimal precioVenta, int codigo, string nombre, string tipo)
        {
            this.IdDetalleProducto = idDetalleProducto;
            this.IdProducto = IdProducto;
            this.Cantidad = cantidad;
            this.PrecioVenta = precioVenta;
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Tipo = tipo;
        }

        public string Insertar(DDetalleProducto DetalleProducto, ref SqlConnection sqlCon, ref SqlTransaction sqlTran)
        {
            string rpta = "";
            try
            {
                //Comandos
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.Transaction = sqlTran;

                sqlCmd.CommandText = "sp_insertarDetalleProducto";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDetalleProducto = new SqlParameter();
                ParIdDetalleProducto.ParameterName = "@idDetalleProducto";
                ParIdDetalleProducto.SqlDbType = SqlDbType.Int;
                ParIdDetalleProducto.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdDetalleProducto);

                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@idProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Value = DetalleProducto.IdProducto;
                sqlCmd.Parameters.Add(ParIdProducto);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = DetalleProducto.Cantidad;
                sqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParPrecioVenta = new SqlParameter();
                ParPrecioVenta.ParameterName = "@precioVenta";
                ParPrecioVenta.SqlDbType = SqlDbType.Decimal;
                ParPrecioVenta.Precision = 8;
                ParPrecioVenta.Scale = 2;
                ParPrecioVenta.Value = DetalleProducto.PrecioVenta;
                sqlCmd.Parameters.Add(ParPrecioVenta);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.Int;
                ParCodigo.Value = DetalleProducto.Codigo;
                sqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = DetalleProducto.Nombre;
                sqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@tipo";
                ParTipo.SqlDbType = SqlDbType.Char;
                ParTipo.Size = 1;
                ParTipo.Value = DetalleProducto.Tipo;
                sqlCmd.Parameters.Add(ParTipo);

                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";
                //sqlCmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }

        public string Editar(DDetalleProducto DetalleProducto)
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

                sqlCmd.CommandText = "sp_insertarDetalleProducto";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDetalleProducto = new SqlParameter();
                ParIdDetalleProducto.ParameterName = "@idDetalleProducto";
                ParIdDetalleProducto.SqlDbType = SqlDbType.Int;
                ParIdDetalleProducto.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdDetalleProducto);

                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@idProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Value = DetalleProducto.IdProducto;
                sqlCmd.Parameters.Add(ParIdProducto);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = DetalleProducto.Cantidad;
                sqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParPrecioVenta = new SqlParameter();
                ParPrecioVenta.ParameterName = "@precioVenta";
                ParPrecioVenta.SqlDbType = SqlDbType.Decimal;
                ParPrecioVenta.Precision = 8;
                ParPrecioVenta.Scale = 2;
                ParPrecioVenta.Value = DetalleProducto.PrecioVenta;
                sqlCmd.Parameters.Add(ParPrecioVenta);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.Int;
                ParCodigo.Value = DetalleProducto.Codigo;
                sqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = DetalleProducto.Nombre;
                sqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@tipo";
                ParTipo.SqlDbType = SqlDbType.Char;
                ParTipo.Size = 1;
                ParTipo.Value = DetalleProducto.Tipo;
                sqlCmd.Parameters.Add(ParTipo);


                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";
                //sqlCmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }

        public string EditarCan(DDetalleProducto Producto)
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
                sqlCmd.CommandText = "sp_editarProductoDetalle";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDetalleProducto = new SqlParameter();
                ParIdDetalleProducto.ParameterName = "@idDetalleProducto";
                ParIdDetalleProducto.SqlDbType = SqlDbType.Int;
                ParIdDetalleProducto.Value = Producto.IdDetalleProducto;
                sqlCmd.Parameters.Add(ParIdDetalleProducto);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = Producto.Cantidad;
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

        public string Eliminar(DDetalleProducto Producto)
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
                sqlCmd.CommandText = "sp_eliminarDetalleProducto";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDetalleProducto = new SqlParameter();
                ParIdDetalleProducto.ParameterName = "@idDetalleProducto";
                ParIdDetalleProducto.SqlDbType = SqlDbType.Int;
                ParIdDetalleProducto.Value = Producto.IdDetalleProducto;
                sqlCmd.Parameters.Add(ParIdDetalleProducto);

                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se eliminó el Registro";
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


        public DataTable MostrarDetalleProductoVenta(DDetalleProducto DetalleProducto)
        {
            DataTable dtResultado = new DataTable("Marca");
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
                ParIdProducto.Value = DetalleProducto.IdProducto;
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

       
    }
}
