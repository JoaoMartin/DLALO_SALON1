using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DTurno
    {
        private int _IdTurno;
        private int _IdTrabajador;
        private DateTime _Fecha;
        private decimal _Monto;
        private string _Estado;
        private decimal _MontoTarjeta;
        private decimal _MontoEgreso;

        public int IdTurno
        {
            get
            {
                return _IdTurno;
            }

            set
            {
                _IdTurno = value;
            }
        }

        public int IdTrabajador
        {
            get
            {
                return _IdTrabajador;
            }

            set
            {
                _IdTrabajador = value;
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

        public decimal MontoTarjeta
        {
            get
            {
                return _MontoTarjeta;
            }

            set
            {
                _MontoTarjeta = value;
            }
        }

        public decimal MontoEgreso
        {
            get
            {
                return _MontoEgreso;
            }

            set
            {
                _MontoEgreso = value;
            }
        }

        public DTurno() { }

        public DTurno(int idTurno, int idTrabajador, DateTime fecha, decimal monto, string estado, decimal montoTarjeta, decimal montoEgreso)
        {
            this.IdTurno = idTurno;
            this.IdTrabajador = idTrabajador;
            this.Fecha = fecha;
            this.Monto = monto;
            this.Estado = estado;
            this.MontoTarjeta = montoTarjeta;
            this.MontoEgreso = montoEgreso;
        }

        public string Insertar(DTurno Turno)
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
                sqlCmd.CommandText = "sp_insertarTurno";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTurno = new SqlParameter();
                ParIdTurno.ParameterName = "@idTurno";
                ParIdTurno.SqlDbType = SqlDbType.Int;
                ParIdTurno.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdTurno);

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idTrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Turno.IdTrabajador;
                sqlCmd.Parameters.Add(ParIdTrabajador);


                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = Turno.Fecha;
                sqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParMonto = new SqlParameter();
                ParMonto.ParameterName = "@montoEfectivo";
                ParMonto.SqlDbType = SqlDbType.Decimal;
                ParMonto.Precision = 9;
                ParMonto.Size = 2;
                ParMonto.Value = Turno.Monto;
                sqlCmd.Parameters.Add(ParMonto);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 12;
                ParEstado.Value = Turno.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParMontoTarjeta = new SqlParameter();
                ParMontoTarjeta.ParameterName = "@montoTarjeta";
                ParMontoTarjeta.SqlDbType = SqlDbType.Decimal;
                ParMontoTarjeta.Precision = 9;
                ParMontoTarjeta.Size = 2;
                ParMontoTarjeta.Value = Turno.MontoTarjeta;
                sqlCmd.Parameters.Add(ParMontoTarjeta);

                SqlParameter ParMontoEgreso = new SqlParameter();
                ParMontoEgreso.ParameterName = "@montoEgreso";
                ParMontoEgreso.SqlDbType = SqlDbType.Decimal;
                ParMontoEgreso.Precision = 9;
                ParMontoEgreso.Size = 2;
                ParMontoEgreso.Value = Turno.MontoEgreso;
                sqlCmd.Parameters.Add(ParMontoEgreso);

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

        public DataTable MostrarMontoApertura(DTurno Turno)
        {
            DataTable dtResultado = new DataTable("Turno");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarMontoAperturaTurno";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idTrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Turno.IdTrabajador;
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

        public DataTable MostrarEstadoTurno(DTurno Turno)
        {
            DataTable dtResultado = new DataTable("Turno");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarEstadoTurno";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@nro";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Turno.IdTrabajador;
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

        public DataTable MostrarIngresosEfectivoTurno(int nroCaja, DateTime fechaApertura, DateTime fechaHoy)
        {
            DataTable dtResultado = new DataTable("Turno");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_listarIngresosEfectivoTurno";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@nrocaja";
                ParNroCaja.SqlDbType = SqlDbType.Int;
                ParNroCaja.Value = nroCaja;
                sqlCmd.Parameters.Add(ParNroCaja);

                SqlParameter ParFechaApertura = new SqlParameter();
                ParFechaApertura.ParameterName = "@fechaApertura";
                ParFechaApertura.SqlDbType = SqlDbType.DateTime;
                ParFechaApertura.Value = fechaApertura;
                sqlCmd.Parameters.Add(ParFechaApertura);

                SqlParameter ParFechaHoy = new SqlParameter();
                ParFechaHoy.ParameterName = "@fechaHoy";
                ParFechaHoy.SqlDbType = SqlDbType.DateTime;
                ParFechaHoy.Value = fechaHoy;
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

        public DataTable MostrarIngresosTarjetaTurno(int nroCaja, DateTime fechaApertura, DateTime fechaHoy)
        {
            DataTable dtResultado = new DataTable("Turno");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_listarIngresosTarjetaTurno";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@nrocaja";
                ParNroCaja.SqlDbType = SqlDbType.Int;
                ParNroCaja.Value = nroCaja;
                sqlCmd.Parameters.Add(ParNroCaja);

                SqlParameter ParFechaApertura = new SqlParameter();
                ParFechaApertura.ParameterName = "@fechaApertura";
                ParFechaApertura.SqlDbType = SqlDbType.DateTime;
                ParFechaApertura.Value = fechaApertura;
                sqlCmd.Parameters.Add(ParFechaApertura);

                SqlParameter ParFechaHoy = new SqlParameter();
                ParFechaHoy.ParameterName = "@fechaHoy";
                ParFechaHoy.SqlDbType = SqlDbType.DateTime;
                ParFechaHoy.Value = fechaHoy;
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

        public DataTable MostrarEgresosTurno(int nroCaja, DateTime fechaApertura, DateTime fechaHoy)
        {
            DataTable dtResultado = new DataTable("Turno");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_listarEgresosTurno";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@nrocaja";
                ParNroCaja.SqlDbType = SqlDbType.Int;
                ParNroCaja.Value = nroCaja;
                sqlCmd.Parameters.Add(ParNroCaja);

                SqlParameter ParFechaApertura = new SqlParameter();
                ParFechaApertura.ParameterName = "@fechaApertura";
                ParFechaApertura.SqlDbType = SqlDbType.DateTime;
                ParFechaApertura.Value = fechaApertura;
                sqlCmd.Parameters.Add(ParFechaApertura);

                SqlParameter ParFechaHoy = new SqlParameter();
                ParFechaHoy.ParameterName = "@fechaHoy";
                ParFechaHoy.SqlDbType = SqlDbType.DateTime;
                ParFechaHoy.Value = fechaHoy;
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

        public DataTable MostrarVentasTurno(DateTime fechaApertura, DateTime fechaHoy)
        {
            DataTable dtResultado = new DataTable("Turno");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarVentaTurno";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParFechaApertura = new SqlParameter();
                ParFechaApertura.ParameterName = "@fechaApertura";
                ParFechaApertura.SqlDbType = SqlDbType.DateTime;
                ParFechaApertura.Value = fechaApertura;
                sqlCmd.Parameters.Add(ParFechaApertura);

                SqlParameter ParFechaHoy = new SqlParameter();
                ParFechaHoy.ParameterName = "@fechaHoy";
                ParFechaHoy.SqlDbType = SqlDbType.DateTime;
                ParFechaHoy.Value = fechaHoy;
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
