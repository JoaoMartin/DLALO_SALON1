using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DMarca
    {
        private int _IdMarca;
        private string _Nombre;
        private string _Estado;
        private string _TextoBuscar;

        public int IdMarca
        {
            get
            {
                return _IdMarca;
            }

            set
            {
                _IdMarca = value;
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

        public DMarca() { }

        public DMarca(int idMarca, string nombreCategoria, string estado, string textoBuscar)
        {
            this.IdMarca = idMarca;
            this.Nombre = nombreCategoria;
            this.Estado = estado;
            this.TextoBuscar = textoBuscar;
        }

        public string Insertar(DMarca Marca)
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
                sqlCmd.CommandText = "sp_insertarMarca";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdMarca = new SqlParameter();
                ParIdMarca.ParameterName = "@idMarca";
                ParIdMarca.SqlDbType = SqlDbType.Int;
                ParIdMarca.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdMarca);

                SqlParameter ParNomMarca = new SqlParameter();
                ParNomMarca.ParameterName = "@nomMarca";
                ParNomMarca.SqlDbType = SqlDbType.VarChar;
                ParNomMarca.Size = 50;
                ParNomMarca.Value = Marca.Nombre;
                sqlCmd.Parameters.Add(ParNomMarca);

                SqlParameter ParEstMarca = new SqlParameter();
                ParEstMarca.ParameterName = "@estMarca";
                ParEstMarca.SqlDbType = SqlDbType.Char;
                ParEstMarca.Size = 1;
                ParEstMarca.Value = Marca.Estado;
                sqlCmd.Parameters.Add(ParEstMarca);

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

        public string Editar(DMarca Marca)
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
                sqlCmd.CommandText = "sp_editarMarca";
                sqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParIdMarca = new SqlParameter();
                ParIdMarca.ParameterName = "@idMarca";
                ParIdMarca.SqlDbType = SqlDbType.Int;
                ParIdMarca.Value = Marca.IdMarca;
                sqlCmd.Parameters.Add(ParIdMarca);

                SqlParameter ParNomMarca = new SqlParameter();
                ParNomMarca.ParameterName = "@nomMarca";
                ParNomMarca.SqlDbType = SqlDbType.VarChar;
                ParNomMarca.Size = 50;
                ParNomMarca.Value = Marca.Nombre;
                sqlCmd.Parameters.Add(ParNomMarca);

                SqlParameter ParEstMarca = new SqlParameter();
                ParEstMarca.ParameterName = "@estMarca";
                ParEstMarca.SqlDbType = SqlDbType.Char;
                ParEstMarca.Size = 1;
                ParEstMarca.Value = Marca.Estado;
                sqlCmd.Parameters.Add(ParEstMarca);

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

        public string Eliminar(DMarca Marca)
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
                sqlCmd.CommandText = "sp_eliminarMarca";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idMarca";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Marca.IdMarca;
                sqlCmd.Parameters.Add(ParIdCategoria);

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
            DataTable dtResultado = new DataTable("Marca");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarMarca";
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

        public DataTable Buscar(DMarca Marca)
        {
            DataTable dtResultado = new DataTable("Marca");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarMarca";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Marca.TextoBuscar;

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
