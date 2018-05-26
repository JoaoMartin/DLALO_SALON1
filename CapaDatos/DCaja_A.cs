using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCaja_A
    {
        private int _IdCaja;
        private int _IdUsuario;
        private string _Nombre;
        private DateTime _Fecha;
        private decimal _Monto;
        private string _Estado;
        private int _NroCaja;
        private decimal _VentaTarjeta;
        private decimal _MontoEgreso;
        private decimal _MontoOtros;
        private decimal _VentaEfectivo;
        private decimal _MontoInicial;
        private DateTime? _FechaApertura;
        public int IdCaja
        {
            get
            {
                return _IdCaja;
            }

            set
            {
                _IdCaja = value;
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

        public int NroCaja
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

        public decimal VentaTarjeta
        {
            get
            {
                return _VentaTarjeta;
            }

            set
            {
                _VentaTarjeta = value;
            }
        }

        public decimal MontoOtros
        {
            get
            {
                return _MontoOtros;
            }

            set
            {
                _MontoOtros = value;
            }
        }

        public decimal VentaEfectivo
        {
            get
            {
                return _VentaEfectivo;
            }

            set
            {
                _VentaEfectivo = value;
            }
        }

        public decimal MontoInicial
        {
            get
            {
                return _MontoInicial;
            }

            set
            {
                _MontoInicial = value;
            }
        }

        public DateTime? FechaApertura
        {
            get
            {
                return _FechaApertura;
            }

            set
            {
                _FechaApertura = value;
            }
        }

        public DCaja_A() { }

        public DCaja_A(int idCaja, int idUsuario, string nombre, DateTime fecha, decimal monto, string estado, int nroCaja, decimal ventaTarjeta, decimal montoEgreso, decimal montoOtros,
            decimal ventaEfectivo, decimal montoInicial, DateTime fechaApertura)
        {
            this.IdCaja = idCaja;
            this.IdUsuario = idUsuario;
            this.Nombre = nombre;
            this.Fecha = fecha;
            this.Monto = monto;
            this.Estado = estado;
            this.NroCaja = nroCaja;
            this.VentaTarjeta = ventaTarjeta;
            this.MontoEgreso = MontoEgreso;
            this.MontoOtros = montoOtros;
            this.VentaEfectivo = ventaEfectivo;
            this.MontoInicial = montoInicial;
            this.FechaApertura = fechaApertura;
        }

        public string Insertar(DCaja_A Caja)
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
                sqlCmd.CommandText = "sp_insertarCaja_A";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCaja = new SqlParameter();
                ParIdCaja.ParameterName = "@idCaja";
                ParIdCaja.SqlDbType = SqlDbType.Int;
                ParIdCaja.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdCaja);

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idUsuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Caja.IdUsuario;
                sqlCmd.Parameters.Add(ParIdUsuario);

                SqlParameter ParNomCaja = new SqlParameter();
                ParNomCaja.ParameterName = "@nomCaja";
                ParNomCaja.SqlDbType = SqlDbType.VarChar;
                ParNomCaja.Size = 20;
                ParNomCaja.Value = Caja.Nombre;
                sqlCmd.Parameters.Add(ParNomCaja);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = Caja.Fecha;
                sqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParMonto = new SqlParameter();
                ParMonto.ParameterName = "@monto";
                ParMonto.SqlDbType = SqlDbType.Decimal;
                ParMonto.Precision = 9;
                ParMonto.Size = 2;
                ParMonto.Value = Caja.Monto;
                sqlCmd.Parameters.Add(ParMonto);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 10;
                ParEstado.Value = Caja.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@nroCaja";
                ParNroCaja.SqlDbType = SqlDbType.Int;
                ParNroCaja.Value = Caja.NroCaja;
                sqlCmd.Parameters.Add(ParNroCaja);

                SqlParameter ParMontoTarjeta = new SqlParameter();
                ParMontoTarjeta.ParameterName = "@ventaTarjeta";
                ParMontoTarjeta.SqlDbType = SqlDbType.Decimal;
                ParMontoTarjeta.Precision = 9;
                ParMontoTarjeta.Size = 2;
                ParMontoTarjeta.Value = Caja.VentaTarjeta;
                sqlCmd.Parameters.Add(ParMontoTarjeta);

                SqlParameter ParMontoEgreso = new SqlParameter();
                ParMontoEgreso.ParameterName = "@montoEgreso";
                ParMontoEgreso.SqlDbType = SqlDbType.Decimal;
                ParMontoEgreso.Precision = 9;
                ParMontoEgreso.Size = 2;
                ParMontoEgreso.Value = Caja.MontoEgreso;
                sqlCmd.Parameters.Add(ParMontoEgreso);

                SqlParameter ParMontoOtros = new SqlParameter();
                ParMontoOtros.ParameterName = "@montoOtros";
                ParMontoOtros.SqlDbType = SqlDbType.Decimal;
                ParMontoOtros.Precision = 9;
                ParMontoOtros.Size = 2;
                ParMontoOtros.Value = Caja.MontoOtros;
                sqlCmd.Parameters.Add(ParMontoOtros);

                SqlParameter ParVentaEfectivo = new SqlParameter();
                ParVentaEfectivo.ParameterName = "@ventaEfectivo";
                ParVentaEfectivo.SqlDbType = SqlDbType.Decimal;
                ParVentaEfectivo.Precision = 9;
                ParVentaEfectivo.Size = 2;
                ParVentaEfectivo.Value = Caja.VentaEfectivo;
                sqlCmd.Parameters.Add(ParVentaEfectivo);

                SqlParameter ParMontoInicial = new SqlParameter();
                ParMontoInicial.ParameterName = "@montoInicial";
                ParMontoInicial.SqlDbType = SqlDbType.Decimal;
                ParMontoInicial.Precision = 9;
                ParMontoInicial.Size = 2;
                ParMontoInicial.Value = Caja.MontoInicial;
                sqlCmd.Parameters.Add(ParMontoInicial);

                SqlParameter ParFechaApertura = new SqlParameter();
                ParFechaApertura.ParameterName = "@fechaApertura";
                ParFechaApertura.SqlDbType = SqlDbType.DateTime;
                ParFechaApertura.Value = Caja.FechaApertura;
                sqlCmd.Parameters.Add(ParFechaApertura);


                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";

                if (rpta == "OK")
                {
                    this.IdCaja = Convert.ToInt32(sqlCmd.Parameters["@idCaja"].Value);
                    rpta = Convert.ToString(this.IdCaja);
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

        public DataTable MostrarEstado(DCaja_A Caja)
        {
            DataTable dtResultado = new DataTable("Caja");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarEstadoCaja";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@nro";
                ParNroCaja.SqlDbType = SqlDbType.Int;
                ParNroCaja.Value = Caja.NroCaja;
                sqlCmd.Parameters.Add(ParNroCaja);


                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable MostrarEstadoCajaMonto(DCaja_A Caja)
        {
            DataTable dtResultado = new DataTable("Caja");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarEstadoCajaMonto";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@nro";
                ParNroCaja.SqlDbType = SqlDbType.Int;
                ParNroCaja.Value = Caja.NroCaja;
                sqlCmd.Parameters.Add(ParNroCaja);


                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable MostrarMonto(DCaja_A Caja)
        {
            DataTable dtResultado = new DataTable("Caja");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarMontoCaja";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@nrocaja";
                ParNroCaja.SqlDbType = SqlDbType.Int;
                ParNroCaja.Value = Caja.NroCaja;
                sqlCmd.Parameters.Add(ParNroCaja);


                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable MostrarCorteCaja(DCaja_A Caja)
        {
            DataTable dtResultado = new DataTable("Caja");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarMontoCorteCaja";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@nrocaja";
                ParNroCaja.SqlDbType = SqlDbType.Int;
                ParNroCaja.Value = Caja.NroCaja;
                sqlCmd.Parameters.Add(ParNroCaja);


                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable MostrarIngresosEfectivo(DCaja_A Caja, DateTime fechaApertura,DateTime fechaHoy)
        {
            DataTable dtResultado = new DataTable("Caja");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_listarIngresosEfectivo";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@nrocaja";
                ParNroCaja.SqlDbType = SqlDbType.Int;
                ParNroCaja.Value = Caja.NroCaja;
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

        public DataTable MostrarIngresosTarjeta(DCaja_A Caja, DateTime fechaApertura, DateTime fechaHoy)
        {
            DataTable dtResultado = new DataTable("Caja");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_listarIngresosTarjeta";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@nrocaja";
                ParNroCaja.SqlDbType = SqlDbType.Int;
                ParNroCaja.Value = Caja.NroCaja;
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

        public DataTable MostrarEgresos(DCaja_A Caja, DateTime fechaApertura, DateTime fechaHoy)
        {
            DataTable dtResultado = new DataTable("Caja");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_listarEgresos";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@nrocaja";
                ParNroCaja.SqlDbType = SqlDbType.Int;
                ParNroCaja.Value = Caja.NroCaja;
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


        public DataTable MostrarVentasCaja(DateTime fechaApertura, DateTime fechaHoy)
        {
            DataTable dtResultado = new DataTable("Turno");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarVentaCaja";
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

        public DataTable MostrarFechaCorte(DCaja_A Caja)
        {
            DataTable dtResultado = new DataTable("Caja");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarFechaCorte";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@nro";
                ParNroCaja.SqlDbType = SqlDbType.Int;
                ParNroCaja.Value = Caja.NroCaja;
                sqlCmd.Parameters.Add(ParNroCaja);


                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable MostrarFechaCierreCaja(DCaja_A Caja)
        {
            DataTable dtResultado = new DataTable("Caja");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarFechaCierreCaja";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@nro";
                ParNroCaja.SqlDbType = SqlDbType.Int;
                ParNroCaja.Value = Caja.NroCaja;
                sqlCmd.Parameters.Add(ParNroCaja);


                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }


        public DataTable reporteMovCaja(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dtResultado = new DataTable("Caja");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_reporteCaja";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParFechaInicio = new SqlParameter();
                ParFechaInicio.ParameterName = "@fechaInicio";
                ParFechaInicio.SqlDbType = SqlDbType.DateTime;
                ParFechaInicio.Value = fechaInicio;
                sqlCmd.Parameters.Add(ParFechaInicio);

                SqlParameter ParFechaFin = new SqlParameter();
                ParFechaFin.ParameterName = "@fechaFin";
                ParFechaFin.SqlDbType = SqlDbType.DateTime;
                ParFechaFin.Value = fechaFin;
                sqlCmd.Parameters.Add(ParFechaFin);


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
