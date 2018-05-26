using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class DTipoTrabajador
    {
        private int _IdTipo;
        private string _Nombre;
        private string _Descripcion;
        private string _Estado;
        private string _TextoBuscar;

        public int IdTipo
        {
            get
            {
                return _IdTipo;
            }

            set
            {
                _IdTipo = value;
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

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }

            set
            {
                _Descripcion = value;
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

        public DTipoTrabajador() { }

        public DTipoTrabajador(int idTipo, string nombreTipoTrabajador, string descrTipoTrabajador, string estTipoTrabajador, string textoBuscar)
        {
            this.IdTipo = idTipo;
            this.Nombre = nombreTipoTrabajador;
            this.Descripcion = descrTipoTrabajador;
            this.Estado = estTipoTrabajador;
            this.TextoBuscar = textoBuscar;
        }

        public string Insertar(DTipoTrabajador TipoTrabajador)
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
                sqlCmd.CommandText = "sp_insertarTipoTrabajador";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTipo = new SqlParameter();
                ParIdTipo.ParameterName = "@idTipo";
                ParIdTipo.SqlDbType = SqlDbType.Int;
                ParIdTipo.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdTipo);

                SqlParameter ParNomTipo = new SqlParameter();
                ParNomTipo.ParameterName = "@nomTipo";
                ParNomTipo.SqlDbType = SqlDbType.VarChar;
                ParNomTipo.Size = 50;
                ParNomTipo.Value = TipoTrabajador.Nombre;
                sqlCmd.Parameters.Add(ParNomTipo);

                SqlParameter ParDescTipo = new SqlParameter();
                ParDescTipo.ParameterName = "@descrTipo";
                ParDescTipo.SqlDbType = SqlDbType.VarChar;
                ParDescTipo.Size = 512;
                ParDescTipo.Value = TipoTrabajador.Descripcion;
                sqlCmd.Parameters.Add(ParDescTipo);

                SqlParameter ParEstTipo = new SqlParameter();
                ParEstTipo.ParameterName = "@estTipo";
                ParEstTipo.SqlDbType = SqlDbType.Char;
                ParEstTipo.Size = 1;
                ParEstTipo.Value = TipoTrabajador.Estado;
                sqlCmd.Parameters.Add(ParEstTipo);

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

        public string Editar(DTipoTrabajador TipoTrabajador)
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
                sqlCmd.CommandText = "sp_editarTipoTrabajador";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTipo = new SqlParameter();
                ParIdTipo.ParameterName = "@idTipo";
                ParIdTipo.SqlDbType = SqlDbType.Int;
                ParIdTipo.Value = TipoTrabajador.IdTipo;
                sqlCmd.Parameters.Add(ParIdTipo);


                SqlParameter ParNomTipo = new SqlParameter();
                ParNomTipo.ParameterName = "@nomTipo";
                ParNomTipo.SqlDbType = SqlDbType.VarChar;
                ParNomTipo.Size = 50;
                ParNomTipo.Value = TipoTrabajador.Nombre;
                sqlCmd.Parameters.Add(ParNomTipo);

                SqlParameter ParDescTipo = new SqlParameter();
                ParDescTipo.ParameterName = "@descrTipo";
                ParDescTipo.SqlDbType = SqlDbType.VarChar;
                ParDescTipo.Size = 512;
                ParDescTipo.Value = TipoTrabajador.Descripcion;
                sqlCmd.Parameters.Add(ParDescTipo);

                SqlParameter ParEstTipo = new SqlParameter();
                ParEstTipo.ParameterName = "@estTipo";
                ParEstTipo.SqlDbType = SqlDbType.Char;
                ParEstTipo.Size = 1;
                ParEstTipo.Value = TipoTrabajador.Estado;
                sqlCmd.Parameters.Add(ParEstTipo);

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

        public string Eliminar(DTipoTrabajador TipoTrabajador)
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
                sqlCmd.CommandText = "sp_eliminarTipoTrabajador";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idTipo";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = TipoTrabajador.IdTipo;
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
            DataTable dtResultado = new DataTable("TipoTrabajador");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarTipoTrabajador";
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

        public DataTable Buscar(DTipoTrabajador TipoTrabahador)
        {
            DataTable dtResultado = new DataTable("TipoTrabajador");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarTipoTrabajador";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TipoTrabahador.TextoBuscar;

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

        public DataTable MostrarTipoTrabajador_Nivel()
        {
            DataTable dtResultado = new DataTable("TipoTrabajador");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarTipoTrabajador_Niveles";
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

        public DataTable MostrarIdTipoTrabajador(int idTrabajador)
        {
            DataTable dtResultado = new DataTable("TipoTrabajador");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarIdTipoTrabajador";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idTrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = idTrabajador;
                sqlCmd.Parameters.Add(ParIdTrabajador);

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
