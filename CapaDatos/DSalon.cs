using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DSalon
    {
        private int _IdSalon;
        private string _Nombre;
        private string _Estado;
        private string _TextoBuscar;

        public int IdSalon
        {
            get
            {
                return _IdSalon;
            }

            set
            {
                _IdSalon = value;
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

        public DSalon() { }

        public DSalon(int idSalon, string nombreSalon, string estado, string textoBuscar)
        {
            this.IdSalon = idSalon;
            this.Nombre = nombreSalon;
            this.Estado = estado;
            this.TextoBuscar = textoBuscar;
        }

        public string Insertar(DSalon Salon)
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
                sqlCmd.CommandText = "sp_insertarSalon";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdSalon = new SqlParameter();
                ParIdSalon.ParameterName = "@idSalon";
                ParIdSalon.SqlDbType = SqlDbType.Int;
                ParIdSalon.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdSalon);

                SqlParameter ParNomSalon = new SqlParameter();
                ParNomSalon.ParameterName = "@nomSalon";
                ParNomSalon.SqlDbType = SqlDbType.VarChar;
                ParNomSalon.Size = 20;
                ParNomSalon.Value = Salon.Nombre;
                sqlCmd.Parameters.Add(ParNomSalon);

                SqlParameter ParEstSalon = new SqlParameter();
                ParEstSalon.ParameterName = "@estSalon";
                ParEstSalon.SqlDbType = SqlDbType.Char;
                ParEstSalon.Size = 1;
                ParEstSalon.Value = Salon.Estado;
                sqlCmd.Parameters.Add(ParEstSalon);

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

        public string Editar(DSalon Salon)
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
                sqlCmd.CommandText = "sp_editarSalon";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdSalon = new SqlParameter();
                ParIdSalon.ParameterName = "@idSalon";
                ParIdSalon.SqlDbType = SqlDbType.Int;
                ParIdSalon.Value = Salon.IdSalon;
                sqlCmd.Parameters.Add(ParIdSalon);

                SqlParameter ParNomSalon = new SqlParameter();
                ParNomSalon.ParameterName = "@nomSalon";
                ParNomSalon.SqlDbType = SqlDbType.VarChar;
                ParNomSalon.Size = 20;
                ParNomSalon.Value = Salon.Nombre;
                sqlCmd.Parameters.Add(ParNomSalon);

                SqlParameter ParEstSalon = new SqlParameter();
                ParEstSalon.ParameterName = "@estSalon";
                ParEstSalon.SqlDbType = SqlDbType.Char;
                ParEstSalon.Size = 1;
                ParEstSalon.Value = Salon.Estado;
                sqlCmd.Parameters.Add(ParEstSalon);

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

        public string Eliminar(DSalon Salon)
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
                sqlCmd.CommandText = "sp_eliminarSalon";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdSalon = new SqlParameter();
                ParIdSalon.ParameterName = "@idSalon";
                ParIdSalon.SqlDbType = SqlDbType.Int;
                ParIdSalon.Value = Salon.IdSalon;
                sqlCmd.Parameters.Add(ParIdSalon);

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
            DataTable dtResultado = new DataTable("Salon");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarSalon";
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

        public DataTable Buscar(DSalon Salon)
        {
            DataTable dtResultado = new DataTable("Salon");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarSalon";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Salon.TextoBuscar;

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
    }
}
