using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalleVentaMenu
    {
        private int _IdDetalleVentaMenu;
        private int _IdDetalleVenta;
        private int _IdProducto;
        private int _Cantidad;
        private string _Barra;
        public int IdDetalleVentaMenu
        {
            get
            {
                return _IdDetalleVentaMenu;
            }

            set
            {
                _IdDetalleVentaMenu = value;
            }
        }

        public int IdDetalleVenta
        {
            get
            {
                return _IdDetalleVenta;
            }

            set
            {
                _IdDetalleVenta = value;
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

        public string Barra
        {
            get
            {
                return _Barra;
            }

            set
            {
                _Barra = value;
            }
        }

        public DDetalleVentaMenu() { }

        public DDetalleVentaMenu(int idDetalleVentaMenu, int idDetalleVenta, int idProducto, int cantidad, string barra)
        {
            this.IdDetalleVentaMenu = IdDetalleVentaMenu;
            this.IdDetalleVenta = idDetalleVenta;
            this.IdProducto = idProducto;
            this.Cantidad = cantidad;
            this.Barra = barra;
        }

        public string Insertar(DDetalleVentaMenu DetalleVentaMenu, ref SqlConnection sqlCon, ref SqlTransaction sqlTran)
        {
            string rpta = "";
            try
            {
                //Comandos
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.Transaction = sqlTran;

                sqlCmd.CommandText = "sp_insertarDetalleVentaMenu";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDetalleVentaMenu = new SqlParameter();
                ParIdDetalleVentaMenu.ParameterName = "@idDetalleVentaMenu";
                ParIdDetalleVentaMenu.SqlDbType = SqlDbType.Int;
                ParIdDetalleVentaMenu.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdDetalleVentaMenu);

                SqlParameter ParIdDetalleVenta = new SqlParameter();
                ParIdDetalleVenta.ParameterName = "@idDetalleVenta";
                ParIdDetalleVenta.SqlDbType = SqlDbType.Int;
                ParIdDetalleVenta.Value = DetalleVentaMenu.IdDetalleVenta;
                sqlCmd.Parameters.Add(ParIdDetalleVenta);

                SqlParameter ParidProducto = new SqlParameter();
                ParidProducto.ParameterName = "@idProducto";
                ParidProducto.SqlDbType = SqlDbType.Int;
                ParidProducto.Value = DetalleVentaMenu.IdProducto;
                sqlCmd.Parameters.Add(ParidProducto);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = DetalleVentaMenu.Cantidad;
                sqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParBarra = new SqlParameter();
                ParBarra.ParameterName = "@barra";
                ParBarra.SqlDbType = SqlDbType.Char;
                ParBarra.Size = 2;
                ParBarra.Value = DetalleVentaMenu.Barra;
                sqlCmd.Parameters.Add(ParBarra);


                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";


                //sqlCmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }

        public string InsertarAdic(DDetalleVentaMenu DetalleVentaMenu)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;

                sqlCmd.CommandText = "sp_insertarDetalleVentaMenu";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDetalleVentaMenu = new SqlParameter();
                ParIdDetalleVentaMenu.ParameterName = "@idDetalleVentaMenu";
                ParIdDetalleVentaMenu.SqlDbType = SqlDbType.Int;
                ParIdDetalleVentaMenu.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdDetalleVentaMenu);

                SqlParameter ParIdDetalleVenta = new SqlParameter();
                ParIdDetalleVenta.ParameterName = "@idDetalleVenta";
                ParIdDetalleVenta.SqlDbType = SqlDbType.Int;
                ParIdDetalleVenta.Value = DetalleVentaMenu.IdDetalleVenta;
                sqlCmd.Parameters.Add(ParIdDetalleVenta);

                SqlParameter ParidProducto = new SqlParameter();
                ParidProducto.ParameterName = "@idProducto";
                ParidProducto.SqlDbType = SqlDbType.Int;
                ParidProducto.Value = DetalleVentaMenu.IdProducto;
                sqlCmd.Parameters.Add(ParidProducto);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = DetalleVentaMenu.Cantidad;
                sqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParBarra = new SqlParameter();
                ParBarra.ParameterName = "@barra";
                ParBarra.SqlDbType = SqlDbType.Char;
                ParBarra.Size = 2;
                ParBarra.Value = DetalleVentaMenu.Barra;
                sqlCmd.Parameters.Add(ParBarra);


                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";


                //sqlCmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }

        public DataTable mostrarDetalleVentaMenu(int idDetalleVenta)
        {
            DataTable dtResultado = new DataTable("DetalleVentaMenu");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarDetalleVentaMenu";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDetalleVenta = new SqlParameter();
                ParIdDetalleVenta.ParameterName = "@idDetalleVenta";
                ParIdDetalleVenta.SqlDbType = SqlDbType.Int;
                ParIdDetalleVenta.Value = idDetalleVenta;
                sqlCmd.Parameters.Add(ParIdDetalleVenta);

            
                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public string EliminarDetalleMenu(int idDetalleVenta)
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
                sqlCmd.CommandText = "sp_eliminarDetalleVentaMenu";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDetalleVenta = new SqlParameter();
                ParIdDetalleVenta.ParameterName = "@idDetalleVenta";
                ParIdDetalleVenta.SqlDbType = SqlDbType.Int;
                ParIdDetalleVenta.Value = idDetalleVenta;
                sqlCmd.Parameters.Add(ParIdDetalleVenta);

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
    }
}
