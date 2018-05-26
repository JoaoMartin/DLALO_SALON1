using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalleReceta
    {
        private int _IdDetalleReceta;
        private int _IdReceta;
        private int _IdInsumo;
        private decimal _Cantidad;
        private decimal _Costo;

        public int IdDetalleReceta
        {
            get
            {
                return _IdDetalleReceta;
            }

            set
            {
                _IdDetalleReceta = value;
            }
        }

        public int IdReceta
        {
            get
            {
                return _IdReceta;
            }

            set
            {
                _IdReceta = value;
            }
        }

        public int IdInsumo
        {
            get
            {
                return _IdInsumo;
            }

            set
            {
                _IdInsumo = value;
            }
        }

        public decimal Cantidad
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

        public DDetalleReceta() { }

        public DDetalleReceta(int idDetalleReceta, int idReceta, int idInsumo, decimal cantidad, decimal costo)
        {
            this.IdDetalleReceta = idDetalleReceta;
            this.IdReceta = idReceta;
            this.IdInsumo = idInsumo;
            this.Cantidad = cantidad;
            this.Costo = costo;
        }

        public string Insertar(DDetalleReceta DetalleReceta, ref SqlConnection sqlCon, ref SqlTransaction sqlTran)
        {
            string rpta = "";
            try
            {
                //Comandos
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.Transaction = sqlTran;

                sqlCmd.CommandText = "sp_insertarDetalleReceta";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDetalleReceta = new SqlParameter();
                ParIdDetalleReceta.ParameterName = "@idDetalleReceta";
                ParIdDetalleReceta.SqlDbType = SqlDbType.Int;
                ParIdDetalleReceta.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdDetalleReceta);

                SqlParameter ParIdReceta = new SqlParameter();
                ParIdReceta.ParameterName = "@idReceta";
                ParIdReceta.SqlDbType = SqlDbType.Int;
                ParIdReceta.Value = DetalleReceta.IdReceta;
                sqlCmd.Parameters.Add(ParIdReceta);

                SqlParameter ParIdInsumo = new SqlParameter();
                ParIdInsumo.ParameterName = "@idInsumo";
                ParIdInsumo.SqlDbType = SqlDbType.Int;
                ParIdInsumo.Value = DetalleReceta.IdInsumo;
                sqlCmd.Parameters.Add(ParIdInsumo);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Decimal;
                ParCantidad.Precision = 9;
                ParCantidad.Scale = 3;
                ParCantidad.Value = DetalleReceta.Cantidad;
                sqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParCosto = new SqlParameter();
                ParCosto.ParameterName = "@costo";
                ParCosto.SqlDbType = SqlDbType.Decimal;
                ParCosto.Precision = 8;
                ParCosto.Scale = 2;
                ParCosto.Value = DetalleReceta.Costo;
                sqlCmd.Parameters.Add(ParCosto);


                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";
                //sqlCmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }

        public string Editar(DDetalleReceta DDetalle)
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
                sqlCmd.CommandText = "sp_editarDetalleReceta";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParidDetalle = new SqlParameter();
                ParidDetalle.ParameterName = "@idDetalleReceta";
                ParidDetalle.SqlDbType = SqlDbType.Int;
                ParidDetalle.Value = DDetalle.IdDetalleReceta;
                sqlCmd.Parameters.Add(ParidDetalle);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Decimal;
                ParCantidad.Precision = 9;
                ParCantidad.Scale = 3;
                ParCantidad.Value = DDetalle.Cantidad;
                sqlCmd.Parameters.Add(ParCantidad);

                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se editó el Registro";
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

        public string InsertarAdicional(DDetalleReceta DetalleReceta)
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
                sqlCmd.CommandText = "sp_insertarDetalleReceta";
                sqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParIdDetalleReceta = new SqlParameter();
                ParIdDetalleReceta.ParameterName = "@idDetalleReceta";
                ParIdDetalleReceta.SqlDbType = SqlDbType.Int;
                ParIdDetalleReceta.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdDetalleReceta);

                SqlParameter ParIdReceta = new SqlParameter();
                ParIdReceta.ParameterName = "@idReceta";
                ParIdReceta.SqlDbType = SqlDbType.Int;
                ParIdReceta.Value = DetalleReceta.IdReceta;
                sqlCmd.Parameters.Add(ParIdReceta);

                SqlParameter ParIdInsumo = new SqlParameter();
                ParIdInsumo.ParameterName = "@idInsumo";
                ParIdInsumo.SqlDbType = SqlDbType.Int;
                ParIdInsumo.Value = DetalleReceta.IdInsumo;
                sqlCmd.Parameters.Add(ParIdInsumo);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Decimal;
                ParCantidad.Precision = 9;
                ParCantidad.Scale = 3;
                ParCantidad.Value = DetalleReceta.Cantidad;
                sqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParCosto = new SqlParameter();
                ParCosto.ParameterName = "@costo";
                ParCosto.SqlDbType = SqlDbType.Decimal;
                ParCosto.Precision = 8;
                ParCosto.Scale = 2;
                ParCosto.Value = DetalleReceta.Costo;
                sqlCmd.Parameters.Add(ParCosto);

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

        public string Eliminar(DDetalleReceta DDetalle)
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
                sqlCmd.CommandText = "sp_eliminarDetalleReceta";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParidDetalle = new SqlParameter();
                ParidDetalle.ParameterName = "@idDetalleReceta";
                ParidDetalle.SqlDbType = SqlDbType.Int;
                ParidDetalle.Value = DDetalle.IdDetalleReceta;
                sqlCmd.Parameters.Add(ParidDetalle);

                

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
