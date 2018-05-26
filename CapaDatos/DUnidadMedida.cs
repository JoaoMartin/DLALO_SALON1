using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DUnidadMedida
    {
        private int _IdUnidad;
        private string _Nombre;
        private string _Estado;
        private string _TextoBuscar;

        public int IdUnidad
        {
            get
            {
                return _IdUnidad;
            }

            set
            {
                _IdUnidad = value;
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

        public DUnidadMedida() { }

        public DUnidadMedida(int idUnidad, string nombreUnidadMedida, string estUnidadMedida, string textoBuscar)
        {
            this.IdUnidad = idUnidad;
            this.Nombre = nombreUnidadMedida;
            this.Estado = estUnidadMedida;
            this.TextoBuscar = textoBuscar;
        }

        public string Insertar(DUnidadMedida Unidad)
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
                sqlCmd.CommandText = "sp_insertarUnidadMedida";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdUnidad = new SqlParameter();
                ParIdUnidad.ParameterName = "@idUnidad";
                ParIdUnidad.SqlDbType = SqlDbType.Int;
                ParIdUnidad.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdUnidad);

                SqlParameter ParNomUnidad = new SqlParameter();
                ParNomUnidad.ParameterName = "@nomUnidad";
                ParNomUnidad.SqlDbType = SqlDbType.VarChar;
                ParNomUnidad.Size = 50;
                ParNomUnidad.Value = Unidad.Nombre;
                sqlCmd.Parameters.Add(ParNomUnidad);

                SqlParameter ParEstUnidad = new SqlParameter();
                ParEstUnidad.ParameterName = "@estUnidad";
                ParEstUnidad.SqlDbType = SqlDbType.Char;
                ParEstUnidad.Size = 1;
                ParEstUnidad.Value = Unidad.Estado;
                sqlCmd.Parameters.Add(ParEstUnidad);

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

        public string Editar(DUnidadMedida Unidad)
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
                sqlCmd.CommandText = "sp_editarUnidadMedida";
                sqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParIdUnidad = new SqlParameter();
                ParIdUnidad.ParameterName = "@idUnidad";
                ParIdUnidad.SqlDbType = SqlDbType.Int;
                ParIdUnidad.Value = Unidad.IdUnidad;
                sqlCmd.Parameters.Add(ParIdUnidad);

                SqlParameter ParNomUnidad = new SqlParameter();
                ParNomUnidad.ParameterName = "@nomUnidad";
                ParNomUnidad.SqlDbType = SqlDbType.VarChar;
                ParNomUnidad.Size = 50;
                ParNomUnidad.Value = Unidad.Nombre;
                sqlCmd.Parameters.Add(ParNomUnidad);

                SqlParameter ParEstUnidad = new SqlParameter();
                ParEstUnidad.ParameterName = "@estUnidad";
                ParEstUnidad.SqlDbType = SqlDbType.Char;
                ParEstUnidad.Size = 1;
                ParEstUnidad.Value = Unidad.Estado;
                sqlCmd.Parameters.Add(ParEstUnidad);

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

        public string Eliminar(DUnidadMedida Unidad)
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
                sqlCmd.CommandText = "sp_eliminarUnidadMedida";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdUnidad = new SqlParameter();
                ParIdUnidad.ParameterName = "@idUnidad";
                ParIdUnidad.SqlDbType = SqlDbType.Int;
                ParIdUnidad.Value = Unidad.IdUnidad;
                sqlCmd.Parameters.Add(ParIdUnidad);

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
            DataTable dtResultado = new DataTable("UnidadMedida");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarUnidadMedida";
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

        public DataTable Buscar(DUnidadMedida UnidadMedida)
        {
            DataTable dtResultado = new DataTable("UnidadMedida");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarUnidadMedida";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = UnidadMedida.TextoBuscar;

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
