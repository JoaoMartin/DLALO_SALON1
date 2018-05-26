using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DAlmacen
    {
        private int _IdAlmacen;
        private string _Nombre;
        private string _Estado;

        public int IdAlmacen
        {
            get
            {
                return _IdAlmacen;
            }

            set
            {
                _IdAlmacen = value;
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

        public DAlmacen() { }

        public DAlmacen(int idAlmacen, string nombre, string estado)
        {
            this.IdAlmacen = idAlmacen;
            this.Nombre = nombre;
            this.Estado = estado;
        }

        public string Insertar(DAlmacen Almacen)
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
                sqlCmd.CommandText = "sp_insertarAlmacen";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdAlmacen = new SqlParameter();
                ParIdAlmacen.ParameterName = "@idAlmacen";
                ParIdAlmacen.SqlDbType = SqlDbType.Int;
                ParIdAlmacen.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdAlmacen);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Almacen.Nombre;
                sqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Char;
                ParEstado.Size = 1;
                ParEstado.Value = Almacen.Estado;
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

        public string Editar(DAlmacen Almacen)
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
                sqlCmd.CommandText = "sp_editarAlmacen";
                sqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParIdAlmacen = new SqlParameter();
                ParIdAlmacen.ParameterName = "@idAlmacen";
                ParIdAlmacen.SqlDbType = SqlDbType.Int;
                ParIdAlmacen.Value = Almacen.IdAlmacen;
                sqlCmd.Parameters.Add(ParIdAlmacen);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Almacen.Nombre;
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

        public DataTable Mostrar()
        {
            DataTable dtResultado = new DataTable("Almacen");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarAlmacen";
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
