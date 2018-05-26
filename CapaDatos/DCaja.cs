using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCaja
    {
        private int _IdMovCaja;
        private int _IdUsuario;
        private string _NroCaja;
        private string _TipoMovCaja;
        private decimal _Monto;
        private DateTime _Fecha;
        private string _Descripcion;
        private string _TipoMonto;

        public int IdMovCaja
        {
            get
            {
                return _IdMovCaja;
            }

            set
            {
                _IdMovCaja = value;
            }
        }

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

        public string NroCaja
        {
            get
            {
                return _NroCaja;
            }

            set
            {
                _NroCaja = value;
            }
        }

        public string TipoMovCaja
        {
            get
            {
                return _TipoMovCaja;
            }

            set
            {
                _TipoMovCaja = value;
            }
        }

        public decimal Monto
        {
            get
            {
                return _Monto;
            }

            set
            {
                _Monto = value;
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

        public string TipoMonto
        {
            get
            {
                return _TipoMonto;
            }

            set
            {
                _TipoMonto = value;
            }
        }

        public DCaja() { }

        public DCaja(int idMovCaja, int idUsuario, string nroCaja, string tipoMov, decimal monto, DateTime fecha, string descripcion, string tipoMonto)
        {
            this.IdMovCaja = idMovCaja;
            this.IdUsuario = idUsuario;
            this.NroCaja = nroCaja;
            this.TipoMovCaja = tipoMov;
            this.Monto = monto;
            this.Fecha = fecha;
            this.Descripcion = descripcion;
            this.TipoMonto = tipoMonto;
        }

        public string Insertar(DCaja Caja)
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
                sqlCmd.CommandText = "sp_insertarCaja";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdMovCaja = new SqlParameter();
                ParIdMovCaja.ParameterName = "@idMovCaja";
                ParIdMovCaja.SqlDbType = SqlDbType.Int;
                ParIdMovCaja.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdMovCaja);

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idUsuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Caja.IdUsuario;
                sqlCmd.Parameters.Add(ParIdUsuario);

                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@nroCaja";
                ParNroCaja.SqlDbType = SqlDbType.VarChar;
                ParNroCaja.Size = 12;
                ParNroCaja.Value = Caja.NroCaja;
                sqlCmd.Parameters.Add(ParNroCaja);

                SqlParameter ParTipoMovCaja = new SqlParameter();
                ParTipoMovCaja.ParameterName = "@tipoMovCaja";
                ParTipoMovCaja.SqlDbType = SqlDbType.VarChar;
                ParTipoMovCaja.Size = 20;
                ParTipoMovCaja.Value = Caja.TipoMovCaja;
                sqlCmd.Parameters.Add(ParTipoMovCaja);

                SqlParameter ParMonto = new SqlParameter();
                ParMonto.ParameterName = "@montoMovCaja";
                ParMonto.SqlDbType = SqlDbType.Decimal;
                ParMonto.Precision = 6;
                ParMonto.Size = 2;
                ParMonto.Value = Caja.Monto;
                sqlCmd.Parameters.Add(ParMonto);

                SqlParameter ParDescr = new SqlParameter();
                ParDescr.ParameterName = "@descr";
                ParDescr.SqlDbType = SqlDbType.VarChar;
                ParDescr.Size = 100;
                ParDescr.Value = Caja.Descripcion;
                sqlCmd.Parameters.Add(ParDescr);

                SqlParameter ParTipoMonto = new SqlParameter();
                ParTipoMonto.ParameterName = "@tipoMonto";
                ParTipoMonto.SqlDbType = SqlDbType.VarChar;
                ParTipoMonto.Size = 20;
                ParTipoMonto.Value = Caja.TipoMonto;
                sqlCmd.Parameters.Add(ParTipoMonto);

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

        public DataTable movimientoCaja(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dtResultado = new DataTable("Movimiento Caja");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarMovimientoCaja";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParFechaApertura = new SqlParameter();
                ParFechaApertura.ParameterName = "@fechaApertura";
                ParFechaApertura.SqlDbType = SqlDbType.DateTime;
                ParFechaApertura.Value = fechaInicio;
                sqlCmd.Parameters.Add(ParFechaApertura);

                SqlParameter ParFechaHoy = new SqlParameter();
                ParFechaHoy.ParameterName = "@fechaHoy";
                ParFechaHoy.SqlDbType = SqlDbType.DateTime;
                ParFechaHoy.Value = fechaFin;
                sqlCmd.Parameters.Add(ParFechaHoy);

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
