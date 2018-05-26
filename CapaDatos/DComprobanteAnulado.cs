using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DComprobanteAnulado
    {
        private int _IdComprobanteAnulado;
        private int _IdComprobante;
        private DateTime _FechaAnulacion;
        private string _Serie;
        private string _Numero;
        private string _Estado;
        private string _Descripcion;

        public int IdComprobanteAnulado
        {
            get
            {
                return _IdComprobanteAnulado;
            }

            set
            {
                _IdComprobanteAnulado = value;
            }
        }

        public int IdComprobante
        {
            get
            {
                return _IdComprobante;
            }

            set
            {
                _IdComprobante = value;
            }
        }

        public DateTime FechaAnulacion
        {
            get
            {
                return _FechaAnulacion;
            }

            set
            {
                _FechaAnulacion = value;
            }
        }

        public string Serie
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

        public string Numero
        {
            get
            {
                return _Numero;
            }

            set
            {
                _Numero = value;
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

        public DComprobanteAnulado() { }

        public DComprobanteAnulado(int idComprobanteAnulado, int idComprobante,  DateTime fechaAnulacion, string serie, string numero, string estado, string descripcion)
        {
            this.IdComprobanteAnulado = idComprobanteAnulado;
            this.IdComprobante = idComprobante;

            this.FechaAnulacion = fechaAnulacion;
            this.Serie = serie;
            this.Numero = numero;
            this.Estado = estado;
            this.Descripcion = descripcion;
        }

        public string Insertar(DComprobanteAnulado Comprobante)
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
                sqlCmd.CommandText = "sp_insertarComprobanteAnulado";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdComprAnulado = new SqlParameter();
                ParIdComprAnulado.ParameterName = "@idComprobanteAnulado";
                ParIdComprAnulado.SqlDbType = SqlDbType.Int;
                ParIdComprAnulado.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdComprAnulado);

                SqlParameter ParIdCompr = new SqlParameter();
                ParIdCompr.ParameterName = "@idComprobante";
                ParIdCompr.SqlDbType = SqlDbType.Int;
                ParIdCompr.Value = Comprobante.IdComprobante;
                sqlCmd.Parameters.Add(ParIdCompr);


                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fechaAnulacion";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Comprobante.FechaAnulacion;
                sqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@serie";
                ParSerie.SqlDbType = SqlDbType.VarChar;
                ParSerie.Size = 10;
                ParSerie.Value = Comprobante.Serie;
                sqlCmd.Parameters.Add(ParSerie);


                SqlParameter ParNumero = new SqlParameter();
                ParNumero.ParameterName = "@numero";
                ParNumero.SqlDbType = SqlDbType.VarChar;
                ParNumero.Size = 10;
                ParNumero.Value = Comprobante.Numero;
                sqlCmd.Parameters.Add(ParNumero);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = Comprobante.Estado;
                sqlCmd.Parameters.Add(ParEstado);


                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Comprobante.Descripcion;
                sqlCmd.Parameters.Add(ParDescripcion);

            

                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";
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

        public DataTable mostrarComprobanteAnulado()
        {
            DataTable dtResultado = new DataTable("ComprobanteAnulado");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarComprobanteAnulado";
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

        public DataTable mostrarCorrelativo(DComprobanteAnulado Comprobante)
        {
            DataTable dtResultado = new DataTable("ComprobanteAnulado");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarCorrelativo";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = Comprobante.FechaAnulacion;
                sqlCmd.Parameters.Add(ParFecha);

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
