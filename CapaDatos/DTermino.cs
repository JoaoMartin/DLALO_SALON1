using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DTermino
    {
        private int _IdTermino;
        private string _Nombre;
        private string _Estado;
        private string _TextoBuscar;

        public int IdTermino
        {
            get
            {
                return _IdTermino;
            }

            set
            {
                _IdTermino = value;
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

        public DTermino() { }

        public DTermino(int idTermino, string nomTermino, string estTermino, string textoBuscar)
        {
            this.IdTermino = idTermino;
            this.Nombre = nomTermino;
            this.Estado = estTermino;
            this.TextoBuscar = textoBuscar;
        }

        public string Insertar(DTermino Termino)
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
                sqlCmd.CommandText = "sp_insertarTermino";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTermino = new SqlParameter();
                ParIdTermino.ParameterName = "@idTermino";
                ParIdTermino.SqlDbType = SqlDbType.Int;
                ParIdTermino.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdTermino);

                SqlParameter ParNomTermino= new SqlParameter();
                ParNomTermino.ParameterName = "@nomTermino";
                ParNomTermino.SqlDbType = SqlDbType.VarChar;
                ParNomTermino.Size = 50;
                ParNomTermino.Value = Termino.Nombre;
                sqlCmd.Parameters.Add(ParNomTermino);

                SqlParameter ParEstTermino = new SqlParameter();
                ParEstTermino.ParameterName = "@estTermino";
                ParEstTermino.SqlDbType = SqlDbType.Char;
                ParEstTermino.Size = 1;
                ParEstTermino.Value = Termino.Estado;
                sqlCmd.Parameters.Add(ParEstTermino);

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

        public string Editar(DTermino Termino)
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
                sqlCmd.CommandText = "sp_editarTermino";
                sqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParIdTermino = new SqlParameter();
                ParIdTermino.ParameterName = "@idTermino";
                ParIdTermino.SqlDbType = SqlDbType.Int;
                ParIdTermino.Value = Termino.IdTermino;
                sqlCmd.Parameters.Add(ParIdTermino);

                SqlParameter ParNomTermino = new SqlParameter();
                ParNomTermino.ParameterName = "@nomTermino";
                ParNomTermino.SqlDbType = SqlDbType.VarChar;
                ParNomTermino.Size = 50;
                ParNomTermino.Value = Termino.Nombre;
                sqlCmd.Parameters.Add(ParNomTermino);

                SqlParameter ParEstTermino = new SqlParameter();
                ParEstTermino.ParameterName = "@estTermino";
                ParEstTermino.SqlDbType = SqlDbType.Char;
                ParEstTermino.Size = 1;
                ParEstTermino.Value = Termino.Estado;
                sqlCmd.Parameters.Add(ParEstTermino);

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

        public string Eliminar(DTermino Termino)
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
                sqlCmd.CommandText = "sp_eliminarTermino";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTermino = new SqlParameter();
                ParIdTermino.ParameterName = "@idTermino";
                ParIdTermino.SqlDbType = SqlDbType.Int;
                ParIdTermino.Value = Termino.IdTermino;
                sqlCmd.Parameters.Add(ParIdTermino);

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
            DataTable dtResultado = new DataTable("Termino");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarTermino";
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

        public DataTable Buscar(DTermino Termino)
        {
            DataTable dtResultado = new DataTable("Termino");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarTermino";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Termino.TextoBuscar;

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
