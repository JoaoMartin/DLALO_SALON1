using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DNivel
    {
        private int _IdNivel;
        private int _IdTipoTrabajador;
        private int _IdModulo;

        public int IdNivel
        {
            get
            {
                return _IdNivel;
            }

            set
            {
                _IdNivel = value;
            }
        }

        public int IdTipoTrabajador
        {
            get
            {
                return _IdTipoTrabajador;
            }

            set
            {
                _IdTipoTrabajador = value;
            }
        }

        public int IdModulo
        {
            get
            {
                return _IdModulo;
            }

            set
            {
                _IdModulo = value;
            }
        }

        public DNivel() { }

        public DNivel(int idNivel, int idTipoTrabajador, int idModulo)
        {
            this.IdNivel = idNivel;
            this.IdTipoTrabajador = idTipoTrabajador;
            this.IdModulo = idModulo;
        }

        public string Insertar(DNivel Nivel)
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
                sqlCmd.CommandText = "sp_insertarNivel";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdNivel = new SqlParameter();
                ParIdNivel.ParameterName = "@idNivel";
                ParIdNivel.SqlDbType = SqlDbType.Int;
                ParIdNivel.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdNivel);

                SqlParameter ParIdModulo = new SqlParameter();
                ParIdModulo.ParameterName = "@idModulo";
                ParIdModulo.SqlDbType = SqlDbType.Int;
                ParIdModulo.Value = Nivel.IdModulo;
                sqlCmd.Parameters.Add(ParIdModulo);

                SqlParameter ParIdTipoTrabajador = new SqlParameter();
                ParIdTipoTrabajador.ParameterName = "@idTipoTrabajador";
                ParIdTipoTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTipoTrabajador.Value = Nivel.IdTipoTrabajador;
                sqlCmd.Parameters.Add(ParIdTipoTrabajador);

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

        public string Eliminar(DNivel Nivel)
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
                sqlCmd.CommandText = "sp_eliminarNivel";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdNivel = new SqlParameter();
                ParIdNivel.ParameterName = "@idNivel";
                ParIdNivel.SqlDbType = SqlDbType.Int;
                ParIdNivel.Value = Nivel.IdNivel;
                sqlCmd.Parameters.Add(ParIdNivel);

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

        public DataTable Mostrar(int idTipoTrabajador)
        {
            DataTable dtResultado = new DataTable("Nivel");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarNivel";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTipoTrabajador = new SqlParameter();
                ParIdTipoTrabajador.ParameterName = "@idTipoTrabajador";
                ParIdTipoTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTipoTrabajador.Value = idTipoTrabajador;
                sqlCmd.Parameters.Add(ParIdTipoTrabajador);

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
