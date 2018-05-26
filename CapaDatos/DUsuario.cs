using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DUsuario
    {
        private int _IdUsuario;
        private string _Trabajador;
        private string _Usuario;
        private string _Pass;
        private string _Estado;
        private int _IdTipoTrabajador;
        private string _TextoBuscar;

        public int IdUsuario
        {
            get
            {
                return _IdUsuario;
            }

            set
            {
                _IdUsuario = value;
            }
        }

        public string Trabajador
        {
            get
            {
                return _Trabajador;
            }

            set
            {
                _Trabajador = value;
            }
        }

        public string Usuario
        {
            get
            {
                return _Usuario;
            }

            set
            {
                _Usuario = value;
            }
        }

        public string Pass
        {
            get
            {
                return _Pass;
            }

            set
            {
                _Pass = value;
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

        public DUsuario() { }

        public DUsuario(int idUsuario, string trabajador, string usuario, string pass, string estado, int idTipoTrabajador, string textoBuscar)
        {
            this.IdUsuario = idUsuario;
            this.Trabajador = trabajador;
            this.Usuario = usuario;
            this.Pass = pass;
            this.Estado = estado;
            this.IdTipoTrabajador = idTipoTrabajador;
            this.TextoBuscar = textoBuscar;
        }

        public string Insertar(DUsuario Usuario)
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
                sqlCmd.CommandText = "sp_insertarUsuario";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idUsuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdUsuario);

                SqlParameter ParTrabajador = new SqlParameter();
                ParTrabajador.ParameterName = "@trabajador";
                ParTrabajador.SqlDbType = SqlDbType.VarChar;
                ParTrabajador.Size = 150;
                ParTrabajador.Value = Usuario.Trabajador;
                sqlCmd.Parameters.Add(ParTrabajador);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Usuario.Usuario;
                sqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPass = new SqlParameter();
                ParPass.ParameterName = "@pass";
                ParPass.SqlDbType = SqlDbType.VarChar;
                ParPass.Size = 20;
                ParPass.Value = Usuario.Pass;
                sqlCmd.Parameters.Add(ParPass);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Char;
                ParEstado.Size = 1;
                ParEstado.Value = Usuario.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParIdTipoTrabajado = new SqlParameter();
                ParIdTipoTrabajado.ParameterName = "@idTipoTrabajador";
                ParIdTipoTrabajado.SqlDbType = SqlDbType.Int;
                ParIdTipoTrabajado.Value = Usuario.IdTipoTrabajador;
                sqlCmd.Parameters.Add(ParIdTipoTrabajado);

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

        public string Editar(DUsuario Usuario)
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
                sqlCmd.CommandText = "sp_editarUsuario";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idUsuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Usuario.IdUsuario;
                sqlCmd.Parameters.Add(ParIdUsuario);

                SqlParameter ParTrabajador = new SqlParameter();
                ParTrabajador.ParameterName = "@trabajador";
                ParTrabajador.SqlDbType = SqlDbType.VarChar;
                ParTrabajador.Size = 150;
                ParTrabajador.Value = Usuario.Trabajador;
                sqlCmd.Parameters.Add(ParTrabajador);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Usuario.Usuario;
                sqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPass = new SqlParameter();
                ParPass.ParameterName = "@pass";
                ParPass.SqlDbType = SqlDbType.VarChar;
                ParPass.Size = 20;
                ParPass.Value = Usuario.Pass;
                sqlCmd.Parameters.Add(ParPass);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Char;
                ParEstado.Size = 1;
                ParEstado.Value = Usuario.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParIdTipoTrabajado = new SqlParameter();
                ParIdTipoTrabajado.ParameterName = "@idTipoTrabajador";
                ParIdTipoTrabajado.SqlDbType = SqlDbType.Int;
                ParIdTipoTrabajado.Value = Usuario.IdTipoTrabajador;
                sqlCmd.Parameters.Add(ParIdTipoTrabajado);


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

        public string Eliminar(DUsuario Usuario)
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
                sqlCmd.CommandText = "sp_eliminarUsuario";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idUsuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Usuario.IdUsuario;
                sqlCmd.Parameters.Add(ParIdUsuario);


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
            DataTable dtResultado = new DataTable("Usuario");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarUsuario";
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

        public DataTable Buscar(DUsuario Usuario)
        {
            DataTable dtResultado = new DataTable("Usuario");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarUsuario";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Usuario.TextoBuscar;

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
