using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DBoleta
    {
        private int _NroBoleta;
        private int _Serie;
        private DateTime _Fecha;
        private int _IdVenta;
        private string _Estado;
        private int? _IdCliente;

        public int NroBoleta
        {
            get
            {
                return _NroBoleta;
            }

            set
            {
                _NroBoleta = value;
            }
        }

        public int Serie
        {
            get
            {
                return _Serie;
            }

            set
            {
                _Serie = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return _Fecha;
            }

            set
            {
                _Fecha = value;
            }
        }

        public int IdVenta
        {
            get
            {
                return _IdVenta;
            }

            set
            {
                _IdVenta = value;
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

        public int? IdCliente
        {
            get
            {
                return _IdCliente;
            }

            set
            {
                _IdCliente = value;
            }
        }

        public DBoleta() { }

        public DBoleta(int nroBoleta, int serie, DateTime fecha, int idVenta, string estado, int idCliente)
        {
            this.NroBoleta = nroBoleta;
            this.Serie = serie;
            this.Fecha = fecha;
            this.IdVenta = idVenta;
            this.Estado = estado;
            this.IdCliente = IdCliente;
        }

        public string Insertar(DBoleta Boleta)
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
                sqlCmd.CommandText = "sp_insertarBoleta";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNroBoleta = new SqlParameter();
                ParNroBoleta.ParameterName = "@nroBoleta";
                ParNroBoleta.SqlDbType = SqlDbType.Int;
                ParNroBoleta.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParNroBoleta);

                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@serie";
                ParSerie.SqlDbType = SqlDbType.Int;
                ParSerie.Value = Boleta.Serie;
                sqlCmd.Parameters.Add(ParSerie);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = Boleta.Fecha;
                sqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = Boleta.IdVenta;
                sqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = Boleta.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idCliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Boleta.IdCliente;
                sqlCmd.Parameters.Add(ParIdCliente);

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
    }
}
