using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DTipoMovAlmacen
    {
        private int _IdTipoMovAlmacen;
        private string _Nombre;
        private string _Tipo;
        private string _Estado;

        public int IdTipoMovAlmacen
        {
            get
            {
                return _IdTipoMovAlmacen;
            }

            set
            {
                _IdTipoMovAlmacen = value;
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

        public DTipoMovAlmacen() { }

        public DTipoMovAlmacen(int idTipoMov, string nombre, string tipo, string estado)
        {
            this.IdTipoMovAlmacen = IdTipoMovAlmacen;
            this.Nombre = nombre;
            this.Tipo = tipo;
            this.Estado = estado;
        }

        public string Insertar(DTipoMovAlmacen TipoMov)
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
                sqlCmd.CommandText = "sp_insertarTipoMovAlmacen";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTipoMiv = new SqlParameter();
                ParIdTipoMiv.ParameterName = "@idTipoMov";
                ParIdTipoMiv.SqlDbType = SqlDbType.Int;
                ParIdTipoMiv.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdTipoMiv);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 100;
                ParNombre.Value = TipoMov.Nombre;
                sqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@tipo";
                ParTipo.SqlDbType = SqlDbType.Char;
                ParTipo.Size = 1;
                ParTipo.Value = TipoMov.Tipo;
                sqlCmd.Parameters.Add(ParTipo);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Char;
                ParEstado.Size = 1;
                ParEstado.Value = TipoMov.Estado;
                sqlCmd.Parameters.Add(ParEstado);

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

        public string Editar(DTipoMovAlmacen TipoMov)
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
                sqlCmd.CommandText = "sp_editarTipoMovAlmacen";
                sqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParIdTipoMiv = new SqlParameter();
                ParIdTipoMiv.ParameterName = "@idTipoMov";
                ParIdTipoMiv.SqlDbType = SqlDbType.Int;
                ParIdTipoMiv.Value = TipoMov.IdTipoMovAlmacen;
                sqlCmd.Parameters.Add(ParIdTipoMiv);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 100;
                ParNombre.Value = TipoMov.Nombre;
                sqlCmd.Parameters.Add(ParNombre);

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

        public string Eliminar(DTipoMovAlmacen TipoMov)
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
                sqlCmd.CommandText = "sp_eliminarTipoMovAlmacen";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTipoMov = new SqlParameter();
                ParIdTipoMov.ParameterName = "@idTipoMov";
                ParIdTipoMov.SqlDbType = SqlDbType.Int;
                ParIdTipoMov.Value = TipoMov.IdTipoMovAlmacen;
                sqlCmd.Parameters.Add(ParIdTipoMov);

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

        public DataTable MostrarTipoMovIngreso()
        {
            DataTable dtResultado = new DataTable("TipoMovimiento");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarTipoMovAlmacen_Ingreso";
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

        public DataTable MostrarTipoMovSalida()
        {
            DataTable dtResultado = new DataTable("TipoMovimiento");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarTipoMovAlmacen_Salida";
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
