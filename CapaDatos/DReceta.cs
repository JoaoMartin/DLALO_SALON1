using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DReceta
    {
        private int _IdReceta;
        private int _IdProducto;
        private string _Nombre;
        private string _Estado;

        public int IdReceta
        {
            get
            {
                return _IdReceta;
            }

            set
            {
                _IdReceta = value;
            }
        }

        public int IdProducto
        {
            get
            {
                return _IdProducto;
            }

            set
            {
                _IdProducto = value;
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

        public DReceta() { }

        public DReceta(int idReceta, int idProducto, string nombre, string estado)
        {
            this.IdReceta = idReceta;
            this.IdProducto = idProducto;
            this.Nombre = nombre;
            this.Estado = estado;
        }

        public string Insertar(DReceta Receta, List<DDetalleReceta> DetalleReceta)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                sqlCon.Open();

                SqlTransaction sqlTran = sqlCon.BeginTransaction();
                //Comandos
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.Transaction = sqlTran;
                sqlCmd.CommandText = "sp_insertarReceta";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdReceta = new SqlParameter();
                ParIdReceta.ParameterName = "@idReceta";
                ParIdReceta.SqlDbType = SqlDbType.Int;
                ParIdReceta.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdReceta);

                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@idProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Value = Receta.IdProducto;
                sqlCmd.Parameters.Add(ParIdProducto);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 200;
                ParNombre.Value = Receta.Nombre;
                sqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Char;
                ParEstado.Size = 1;
                ParEstado.Value = Receta.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";
                if (rpta.Equals("OK"))
                {
                    this.IdReceta = Convert.ToInt32(sqlCmd.Parameters["@idReceta"].Value);
                    foreach (DDetalleReceta det in DetalleReceta)
                    {
                        det.IdReceta = this.IdReceta;

                        rpta = det.Insertar(det, ref sqlCon, ref sqlTran);
                        if (!rpta.Equals("OK"))
                        {
                            break;

                        }
                    }
                }

                if (rpta.Equals("OK"))
                {
                    sqlTran.Commit();
                }
                else
                {
                    sqlTran.Rollback();
                }
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

        public string Eliminar(DReceta Receta)
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
                sqlCmd.CommandText = "sp_eliminarReceta";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdReceta = new SqlParameter();
                ParIdReceta.ParameterName = "@idReceta";
                ParIdReceta.SqlDbType = SqlDbType.Int;
                ParIdReceta.Value = Receta.IdReceta;
                sqlCmd.Parameters.Add(ParIdReceta);

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

        public DataTable Mostrar(DReceta Receta)
        {
            DataTable dtResultado = new DataTable("Receta");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarReceta";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@idProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Value = Receta.IdProducto;
                sqlCmd.Parameters.Add(ParIdProducto);

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
