using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDescuento
    {
        private int _IdDescuento;
        private int _IdProducto;
        private string _Tipo;
        private decimal _Porcentaje;
        private string _Estado;

        public int IdDescuento
        {
            get
            {
                return _IdDescuento;
            }

            set
            {
                _IdDescuento = value;
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

        public decimal Porcentaje
        {
            get
            {
                return _Porcentaje;
            }

            set
            {
                _Porcentaje = value;
            }
        }

        public DDescuento() { }
        public DDescuento(int idDescuento, int idProducto, string tipo, decimal porcentaje, string estado)
        {
            this.IdDescuento = idDescuento;
            this.IdProducto = idProducto;
            this.Tipo = tipo;
            this.Porcentaje = porcentaje;
            this.Estado = estado;

        }

        public string Insertar(DDescuento Descuento)
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
                sqlCmd.CommandText = "sp_insertarDescuento";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDescuento = new SqlParameter();
                ParIdDescuento.ParameterName = "@idDescuento";
                ParIdDescuento.SqlDbType = SqlDbType.Int;
                ParIdDescuento.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdDescuento);

                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@idProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Value = Descuento.IdProducto;
                sqlCmd.Parameters.Add(ParIdProducto);

                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@tipo";
                ParTipo.SqlDbType = SqlDbType.Char;
                ParTipo.Size = 1;
                ParTipo.Value = Descuento.Tipo;
                sqlCmd.Parameters.Add(ParTipo);

                SqlParameter ParPorcentaje = new SqlParameter();
                ParPorcentaje.ParameterName = "@porcentaje";
                ParPorcentaje.SqlDbType = SqlDbType.Decimal;
                ParPorcentaje.Precision = 8;
                ParPorcentaje.Scale = 2;
                ParPorcentaje.Value = Descuento.Porcentaje;
                sqlCmd.Parameters.Add(ParPorcentaje);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Char;
                ParEstado.Size = 1;
                ParEstado.Value = Descuento.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";
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

        public string Editar(DDescuento Descuento)
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
                sqlCmd.CommandText = "sp_editarDescuento";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idDescuento";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Descuento.IdDescuento;
                sqlCmd.Parameters.Add(ParIdCategoria);

                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@idProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Value = Descuento.IdProducto;
                sqlCmd.Parameters.Add(ParIdProducto);

                SqlParameter ParPorcentaje = new SqlParameter();
                ParPorcentaje.ParameterName = "@porcentaje";
                ParPorcentaje.SqlDbType = SqlDbType.Decimal;
                ParPorcentaje.Precision = 8;
                ParPorcentaje.Scale = 2;
                ParPorcentaje.Value = Descuento.Porcentaje;
                sqlCmd.Parameters.Add(ParPorcentaje);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Char;
                ParEstado.Size = 1;
                ParEstado.Value = Descuento.Estado;
                sqlCmd.Parameters.Add(ParEstado);

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
        public DataTable MostrarDescuentoCategoria()
        {
            DataTable dtResultado = new DataTable("Descuento");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarDescuentoCategoria";
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

        public DataTable MostrarDescuentoProducto()
        {
            DataTable dtResultado = new DataTable("Descuento");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarDescuentoProducto";
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

        public string Eliminar(DDescuento Descuento)
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
                sqlCmd.CommandText = "sp_eliminarDescuento";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idDescuento";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Descuento.IdDescuento;
                sqlCmd.Parameters.Add(ParIdCategoria);


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
    }
}
