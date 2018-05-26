using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DMesa
    {
        private int _IdMesa;
        private string _Nombre;
        private string _EstadoTipo;
        private int _IdSalon;
        private string _EstadoMesa;
        private string _TextoBuscar;

        public int IdMesa
        {
            get
            {
                return _IdMesa;
            }

            set
            {
                _IdMesa = value;
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

        public string EstadoTipo
        {
            get
            {
                return _EstadoTipo;
            }

            set
            {
                _EstadoTipo = value;
            }
        }

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

        public string EstadoMesa
        {
            get
            {
                return _EstadoMesa;
            }

            set
            {
                _EstadoMesa = value;
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

        public DMesa() { }

        public DMesa(int idMesa, string nombreMesa, string estadoTipo, int idSalon, string estadoMesa ,string textoBuscar)
        {
            this.IdMesa = idMesa;
            this.Nombre = nombreMesa;
            this.EstadoTipo = estadoTipo;
            this.EstadoMesa = estadoMesa;
            this.IdSalon = idSalon;
            this.TextoBuscar = textoBuscar;
        }

        public string Insertar(DMesa Mesa)
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
                sqlCmd.CommandText = "sp_insertarMesa";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdMesa = new SqlParameter();
                ParIdMesa.ParameterName = "@idMesa";
                ParIdMesa.SqlDbType = SqlDbType.Int;
                ParIdMesa.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdMesa);

                SqlParameter ParNomMesa = new SqlParameter();
                ParNomMesa.ParameterName = "@nomMesa";
                ParNomMesa.SqlDbType = SqlDbType.VarChar;
                ParNomMesa.Size = 20;
                ParNomMesa.Value = Mesa.Nombre;
                sqlCmd.Parameters.Add(ParNomMesa);

                SqlParameter ParEstadoTipo = new SqlParameter();
                ParEstadoTipo.ParameterName = "@estTipo";
                ParEstadoTipo.SqlDbType = SqlDbType.VarChar;
                ParEstadoTipo.Size = 20;
                ParEstadoTipo.Value = Mesa.EstadoTipo;
                sqlCmd.Parameters.Add(ParEstadoTipo);

                SqlParameter ParIdSalon= new SqlParameter();
                ParIdSalon.ParameterName = "@idSalon";
                ParIdSalon.SqlDbType = SqlDbType.Int;
                ParIdSalon.Value = Mesa.IdSalon;
                sqlCmd.Parameters.Add(ParIdSalon);
                      
                SqlParameter ParEstMesa = new SqlParameter();
                ParEstMesa.ParameterName = "@estMesa";
                ParEstMesa.SqlDbType = SqlDbType.Char;
                ParEstMesa.Size = 1;
                ParEstMesa.Value = Mesa.EstadoMesa;
                sqlCmd.Parameters.Add(ParEstMesa);

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

        public string Editar(DMesa Mesa)
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
                sqlCmd.CommandText = "sp_editarMesa";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdMesa = new SqlParameter();
                ParIdMesa.ParameterName = "@idMesa";
                ParIdMesa.SqlDbType = SqlDbType.Int;
                ParIdMesa.Value = Mesa.IdMesa;
                sqlCmd.Parameters.Add(ParIdMesa);

                SqlParameter ParNomMesa = new SqlParameter();
                ParNomMesa.ParameterName = "@nomMesa";
                ParNomMesa.SqlDbType = SqlDbType.VarChar;
                ParNomMesa.Size = 20;
                ParNomMesa.Value = Mesa.Nombre;
                sqlCmd.Parameters.Add(ParNomMesa);

                SqlParameter ParEstadoTipo = new SqlParameter();
                ParEstadoTipo.ParameterName = "@estTipo";
                ParEstadoTipo.SqlDbType = SqlDbType.VarChar;
                ParEstadoTipo.Size = 20;
                ParEstadoTipo.Value = Mesa.EstadoTipo;
                sqlCmd.Parameters.Add(ParEstadoTipo);

                SqlParameter ParIdSalon = new SqlParameter();
                ParIdSalon.ParameterName = "@idSalon";
                ParIdSalon.SqlDbType = SqlDbType.Int;
                ParIdSalon.Value = Mesa.IdSalon;
                sqlCmd.Parameters.Add(ParIdSalon);

                SqlParameter ParEstMesa = new SqlParameter();
                ParEstMesa.ParameterName = "@estMesa";
                ParEstMesa.SqlDbType = SqlDbType.Char;
                ParEstMesa.Size = 1;
                ParEstMesa.Value = Mesa.EstadoMesa;
                sqlCmd.Parameters.Add(ParEstMesa);

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

        public string Eliminar(DMesa Mesa)
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
                sqlCmd.CommandText = "sp_eliminarMesa";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdMesa = new SqlParameter();
                ParIdMesa.ParameterName = "@idMesa";
                ParIdMesa.SqlDbType = SqlDbType.Int;
                ParIdMesa.Value = Mesa.IdMesa;
                sqlCmd.Parameters.Add(ParIdMesa);

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

        public DataTable Mostrar(DMesa Mesa)
        {
            DataTable dtResultado = new DataTable("Mesa");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarMesa";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdSalon = new SqlParameter();
                ParIdSalon.ParameterName = "@idSalon";
                ParIdSalon.SqlDbType = SqlDbType.Int;
                ParIdSalon.Value = Mesa.IdSalon;
                sqlCmd.Parameters.Add(ParIdSalon);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable MostrarIdVentaMesa(int idMesa)
        {
            DataTable dtResultado = new DataTable("Mesa");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarIdVentaPorMesa";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdMesa = new SqlParameter();
                ParIdMesa.ParameterName = "@idMesa";
                ParIdMesa.SqlDbType = SqlDbType.Int;
                ParIdMesa.Value = idMesa;
                sqlCmd.Parameters.Add(ParIdMesa);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable MostrarEstadoMesa(DMesa Mesa)
        {
            DataTable dtResultado = new DataTable("Mesa");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarEstadoMesa";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdSalon = new SqlParameter();
                ParIdSalon.ParameterName = "@idSalon";
                ParIdSalon.SqlDbType = SqlDbType.Int;
                ParIdSalon.Value = Mesa.IdSalon;
                sqlCmd.Parameters.Add(ParIdSalon);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable MostrarLibre(DMesa Mesa)
        {
            DataTable dtResultado = new DataTable("Mesa");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarMesaLibre";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdSalon = new SqlParameter();
                ParIdSalon.ParameterName = "@idSalon";
                ParIdSalon.SqlDbType = SqlDbType.Int;
                ParIdSalon.Value = Mesa.IdSalon;
                sqlCmd.Parameters.Add(ParIdSalon);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public string EditarEstadoMesa(DMesa Mesa)
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
                sqlCmd.CommandText = "sp_editarEstadoMesa";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdMesa = new SqlParameter();
                ParIdMesa.ParameterName = "@idMesa";
                ParIdMesa.SqlDbType = SqlDbType.Int;
                ParIdMesa.Value = Mesa.IdMesa;
                sqlCmd.Parameters.Add(ParIdMesa);

                SqlParameter ParEstadoTipo = new SqlParameter();
                ParEstadoTipo.ParameterName = "@estado";
                ParEstadoTipo.SqlDbType = SqlDbType.VarChar;
                ParEstadoTipo.Size = 20;
                ParEstadoTipo.Value = Mesa.EstadoTipo;
                sqlCmd.Parameters.Add(ParEstadoTipo);

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
    }
}
