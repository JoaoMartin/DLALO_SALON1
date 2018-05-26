using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DComprobante
    {
        private int _IdComprobante;
        private string _TipoComprobante;
        private int _Serie;
        private int _Correlativo;
        private decimal _Igv;
        private DateTime _Fecha;
        private int _IdVenta;
        private string _Estado;
        private int? _IdCliente;
        private decimal _Monto;
        private decimal _Efectivo;
        private decimal _Tarjeta;
        private decimal _Redondeo;
        private string _FormaPago;
        private decimal _Vuelto;
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

        public string TipoComprobante
        {
            get
            {
                return _TipoComprobante;
            }

            set
            {
                _TipoComprobante = value;
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

        public int Correlativo
        {
            get
            {
                return _Correlativo;
            }

            set
            {
                _Correlativo = value;
            }
        }

        public decimal Igv
        {
            get
            {
                return _Igv;
            }

            set
            {
                _Igv = value;
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

        public decimal Efectivo
        {
            get
            {
                return _Efectivo;
            }

            set
            {
                _Efectivo = value;
            }
        }

        public decimal Tarjeta
        {
            get
            {
                return _Tarjeta;
            }

            set
            {
                _Tarjeta = value;
            }
        }

        public decimal Redondeo
        {
            get
            {
                return _Redondeo;
            }

            set
            {
                _Redondeo = value;
            }
        }

        public string FormaPago
        {
            get
            {
                return _FormaPago;
            }

            set
            {
                _FormaPago = value;
            }
        }

        public decimal Vuelto
        {
            get
            {
                return _Vuelto;
            }

            set
            {
                _Vuelto = value;
            }
        }

        public DComprobante() { }

        public DComprobante(int idComprobante, string tipoComprobante, int serie, int correlativo, decimal igv, DateTime fecha, int idVenta, string estado, int idCliente, decimal monto, decimal efectivo, decimal tarjeta, decimal redondeo, string formaPago, decimal vuelto)
        {
            this.IdComprobante = idComprobante;
            this.TipoComprobante = tipoComprobante;
            this.Serie = serie;
            this.Correlativo = correlativo;
            this.Igv = igv;
            this.Fecha = fecha;
            this.IdVenta = idVenta;
            this.Estado = estado;
            this.IdCliente = idCliente;
            this.Monto = monto;
            this.Efectivo = efectivo;
            this.Tarjeta = tarjeta;
            this.Redondeo = redondeo;
            this.FormaPago = formaPago;
            this.Vuelto = vuelto;
        }

        public string Insertar(DComprobante Comprobante)
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
                sqlCmd.CommandText = "sp_insertarComprobate";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCompr = new SqlParameter();
                ParIdCompr.ParameterName = "@idComprobante";
                ParIdCompr.SqlDbType = SqlDbType.Int;
                ParIdCompr.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdCompr);

                SqlParameter ParTipoCompr = new SqlParameter();
                ParTipoCompr.ParameterName = "@tipoComprobante";
                ParTipoCompr.SqlDbType = SqlDbType.VarChar;
                ParTipoCompr.Size = 20;
                ParTipoCompr.Value = Comprobante.TipoComprobante;
                sqlCmd.Parameters.Add(ParTipoCompr);

                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@serie";
                ParSerie.SqlDbType = SqlDbType.Int;
                ParSerie.Value = Comprobante.Serie;
                sqlCmd.Parameters.Add(ParSerie);

                SqlParameter ParIgv = new SqlParameter();
                ParIgv.ParameterName = "@igv";
                ParIgv.SqlDbType = SqlDbType.Decimal;
                ParIgv.Precision = 8;
                ParIgv.Scale = 3;
                ParIgv.Value = Comprobante.Igv;
                sqlCmd.Parameters.Add(ParIgv);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = Comprobante.Fecha;
                sqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = Comprobante.IdVenta;
                sqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = Comprobante.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idCliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Comprobante.IdCliente;
                sqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParMonto = new SqlParameter();
                ParMonto.ParameterName = "@monto";
                ParMonto.SqlDbType = SqlDbType.Decimal;
                ParMonto.Precision = 6;
                ParMonto.Scale = 2;
                ParMonto.Value = Comprobante.Monto;
                sqlCmd.Parameters.Add(ParMonto);

                SqlParameter ParEfectivo = new SqlParameter();
                ParEfectivo.ParameterName = "@efectivo";
                ParEfectivo.SqlDbType = SqlDbType.Decimal;
                ParEfectivo.Precision = 6;
                ParEfectivo.Scale = 2;
                ParEfectivo.Value = Comprobante.Efectivo;
                sqlCmd.Parameters.Add(ParEfectivo);

                SqlParameter ParTarjeta = new SqlParameter();
                ParTarjeta.ParameterName = "@tarjeta";
                ParTarjeta.SqlDbType = SqlDbType.Decimal;
                ParTarjeta.Precision = 6;
                ParTarjeta.Scale = 2;
                ParTarjeta.Value = Comprobante.Tarjeta;
                sqlCmd.Parameters.Add(ParTarjeta);

                SqlParameter ParRedondeo = new SqlParameter();
                ParRedondeo.ParameterName = "@redondeo";
                ParRedondeo.SqlDbType = SqlDbType.Decimal;
                ParRedondeo.Precision = 6;
                ParRedondeo.Scale = 2;
                ParRedondeo.Value = Comprobante.Redondeo;
                sqlCmd.Parameters.Add(ParRedondeo);

                SqlParameter ParFormaPago = new SqlParameter();
                ParFormaPago.ParameterName = "@formaPago";
                ParFormaPago.SqlDbType = SqlDbType.VarChar;
                ParFormaPago.Size = 30;
                ParFormaPago.Value = Comprobante.FormaPago;
                sqlCmd.Parameters.Add(ParFormaPago);

                SqlParameter ParVuelto = new SqlParameter();
                ParVuelto.ParameterName = "@vuelto";
                ParVuelto.SqlDbType = SqlDbType.Decimal;
                ParVuelto.Precision = 6;
                ParVuelto.Scale = 2;
                ParVuelto.Value = Comprobante.Vuelto;
                sqlCmd.Parameters.Add(ParVuelto);

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

        public string InsertarVenta(DComprobante Comprobante, ref SqlConnection sqlCon, ref SqlTransaction sqlTran)
        {
            string rpta = "";
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.Transaction = sqlTran;

                sqlCmd.CommandText = "sp_insertarComprobate";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCompr = new SqlParameter();
                ParIdCompr.ParameterName = "@idComprobante";
                ParIdCompr.SqlDbType = SqlDbType.Int;
                ParIdCompr.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdCompr);

                SqlParameter ParTipoCompr = new SqlParameter();
                ParTipoCompr.ParameterName = "@tipoComprobante";
                ParTipoCompr.SqlDbType = SqlDbType.VarChar;
                ParTipoCompr.Size = 20;
                ParTipoCompr.Value = Comprobante.TipoComprobante;
                sqlCmd.Parameters.Add(ParTipoCompr);

                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@serie";
                ParSerie.SqlDbType = SqlDbType.Int;
                ParSerie.Value = Comprobante.Serie;
                sqlCmd.Parameters.Add(ParSerie);

                SqlParameter ParIgv = new SqlParameter();
                ParIgv.ParameterName = "@igv";
                ParIgv.SqlDbType = SqlDbType.Decimal;
                ParIgv.Precision = 8;
                ParIgv.Scale = 3;
                ParIgv.Value = Comprobante.Igv;
                sqlCmd.Parameters.Add(ParIgv);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = Comprobante.Fecha;
                sqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = Comprobante.IdVenta;
                sqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = Comprobante.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idCliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Comprobante.IdCliente;
                sqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParMonto = new SqlParameter();
                ParMonto.ParameterName = "@monto";
                ParMonto.SqlDbType = SqlDbType.Decimal;
                ParMonto.Precision = 6;
                ParMonto.Scale = 2;
                ParMonto.Value = Comprobante.Monto;
                sqlCmd.Parameters.Add(ParMonto);

                SqlParameter ParEfectivo = new SqlParameter();
                ParEfectivo.ParameterName = "@efectivo";
                ParEfectivo.SqlDbType = SqlDbType.Decimal;
                ParEfectivo.Precision = 6;
                ParEfectivo.Scale = 2;
                ParEfectivo.Value = Comprobante.Efectivo;
                sqlCmd.Parameters.Add(ParEfectivo);

                SqlParameter ParTarjeta = new SqlParameter();
                ParTarjeta.ParameterName = "@tarjeta";
                ParTarjeta.SqlDbType = SqlDbType.Decimal;
                ParTarjeta.Precision = 6;
                ParTarjeta.Scale = 2;
                ParTarjeta.Value = Comprobante.Tarjeta;
                sqlCmd.Parameters.Add(ParTarjeta);

                SqlParameter ParRedondeo = new SqlParameter();
                ParRedondeo.ParameterName = "@redondeo";
                ParRedondeo.SqlDbType = SqlDbType.Decimal;
                ParRedondeo.Precision = 6;
                ParRedondeo.Scale = 2;
                ParRedondeo.Value = Comprobante.Redondeo;
                sqlCmd.Parameters.Add(ParRedondeo);

                SqlParameter ParFormaPago = new SqlParameter();
                ParFormaPago.ParameterName = "@formaPago";
                ParFormaPago.SqlDbType = SqlDbType.VarChar;
                ParFormaPago.Size = 30;
                ParFormaPago.Value = Comprobante.FormaPago;
                sqlCmd.Parameters.Add(ParFormaPago);

                SqlParameter ParVuelto = new SqlParameter();
                ParVuelto.ParameterName = "@vuelto";
                ParVuelto.SqlDbType = SqlDbType.Decimal;
                ParVuelto.Precision = 6;
                ParVuelto.Scale = 2;
                ParVuelto.Value = Comprobante.Vuelto;
                sqlCmd.Parameters.Add(ParVuelto);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingresó el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;
        }

        public DataTable mostrarNroComprobante(DComprobante Comprobante)
        {
            DataTable dtResultado = new DataTable("Comprobante");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarNroComprobante";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = Comprobante.IdVenta;
                sqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@tipo";
                ParTipo.SqlDbType = SqlDbType.VarChar;
                ParTipo.Size = 20;
                ParTipo.Value = Comprobante.TipoComprobante;
                sqlCmd.Parameters.Add(ParTipo);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }


        public string EditarEstadoTicket(DComprobante Comprobante)
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
                sqlCmd.CommandText = "sp_cambiarEstadoTicket";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdComprobante = new SqlParameter();
                ParIdComprobante.ParameterName = "@idComprobante";
                ParIdComprobante.SqlDbType = SqlDbType.Int;
                ParIdComprobante.Value = Comprobante.IdComprobante;
                sqlCmd.Parameters.Add(ParIdComprobante);

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

        public DataTable mostrarIdComprobante(DComprobante Comprobante)
        {
            DataTable dtResultado = new DataTable("Comprobante");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarIdComprobante";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = Comprobante.IdVenta;
                sqlCmd.Parameters.Add(ParIdVenta);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }


        public string AnularComprobante(DComprobante Comprobante)
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
                sqlCmd.CommandText = "sp_AnularComprobante";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdComprobante = new SqlParameter();
                ParIdComprobante.ParameterName = "@idComprobante";
                ParIdComprobante.SqlDbType = SqlDbType.Int;
                ParIdComprobante.Value = Comprobante.IdComprobante;
                sqlCmd.Parameters.Add(ParIdComprobante);

                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se anuló el Registro";

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

        public string InsertarManual(DComprobante Comprobante)
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
                sqlCmd.CommandText = "sp_insertarComprobanteManual";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCompr = new SqlParameter();
                ParIdCompr.ParameterName = "@idComprobante";
                ParIdCompr.SqlDbType = SqlDbType.Int;
                ParIdCompr.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdCompr);

                SqlParameter ParTipoCompr = new SqlParameter();
                ParTipoCompr.ParameterName = "@tipoComprobante";
                ParTipoCompr.SqlDbType = SqlDbType.VarChar;
                ParTipoCompr.Size = 20;
                ParTipoCompr.Value = Comprobante.TipoComprobante;
                sqlCmd.Parameters.Add(ParTipoCompr);

                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@serie";
                ParSerie.SqlDbType = SqlDbType.Int;
                ParSerie.Value = Comprobante.Serie;
                sqlCmd.Parameters.Add(ParSerie);

                SqlParameter ParNroCom = new SqlParameter();
                ParNroCom.ParameterName = "@nroComprobante";
                ParNroCom.SqlDbType = SqlDbType.Int;
                ParNroCom.Value = Comprobante.Correlativo;
                sqlCmd.Parameters.Add(ParNroCom);

                SqlParameter ParIgv = new SqlParameter();
                ParIgv.ParameterName = "@igv";
                ParIgv.SqlDbType = SqlDbType.Decimal;
                ParIgv.Precision = 8;
                ParIgv.Scale = 3;
                ParIgv.Value = Comprobante.Igv;
                sqlCmd.Parameters.Add(ParIgv);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = Comprobante.Fecha;
                sqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = Comprobante.IdVenta;
                sqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = Comprobante.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idCliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Comprobante.IdCliente;
                sqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParMonto = new SqlParameter();
                ParMonto.ParameterName = "@monto";
                ParMonto.SqlDbType = SqlDbType.Decimal;
                ParMonto.Precision = 6;
                ParMonto.Scale = 2;
                ParMonto.Value = Comprobante.Monto;
                sqlCmd.Parameters.Add(ParMonto);

                SqlParameter ParEfectivo = new SqlParameter();
                ParEfectivo.ParameterName = "@efectivo";
                ParEfectivo.SqlDbType = SqlDbType.Decimal;
                ParEfectivo.Precision = 6;
                ParEfectivo.Scale = 2;
                ParEfectivo.Value = Comprobante.Efectivo;
                sqlCmd.Parameters.Add(ParEfectivo);

                SqlParameter ParTarjeta = new SqlParameter();
                ParTarjeta.ParameterName = "@tarjeta";
                ParTarjeta.SqlDbType = SqlDbType.Decimal;
                ParTarjeta.Precision = 6;
                ParTarjeta.Scale = 2;
                ParTarjeta.Value = Comprobante.Tarjeta;
                sqlCmd.Parameters.Add(ParTarjeta);

                SqlParameter ParRedondeo = new SqlParameter();
                ParRedondeo.ParameterName = "@redondeo";
                ParRedondeo.SqlDbType = SqlDbType.Decimal;
                ParRedondeo.Precision = 6;
                ParRedondeo.Scale = 2;
                ParRedondeo.Value = Comprobante.Redondeo;
                sqlCmd.Parameters.Add(ParRedondeo);

                SqlParameter ParFormaPago = new SqlParameter();
                ParFormaPago.ParameterName = "@formaPago";
                ParFormaPago.SqlDbType = SqlDbType.VarChar;
                ParFormaPago.Size = 30;
                ParFormaPago.Value = Comprobante.FormaPago;
                sqlCmd.Parameters.Add(ParFormaPago);

                SqlParameter ParVuelto = new SqlParameter();
                ParVuelto.ParameterName = "@vuelto";
                ParVuelto.SqlDbType = SqlDbType.Decimal;
                ParVuelto.Precision = 6;
                ParVuelto.Scale = 2;
                ParVuelto.Value = Comprobante.Vuelto;
                sqlCmd.Parameters.Add(ParVuelto);

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

        public string InsertarVentaManual(DComprobante Comprobante, ref SqlConnection sqlCon, ref SqlTransaction sqlTran)
        {
            string rpta = "";
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.Transaction = sqlTran;

                sqlCmd.CommandText = "sp_insertarComprobanteManual";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCompr = new SqlParameter();
                ParIdCompr.ParameterName = "@idComprobante";
                ParIdCompr.SqlDbType = SqlDbType.Int;
                ParIdCompr.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdCompr);

                SqlParameter ParTipoCompr = new SqlParameter();
                ParTipoCompr.ParameterName = "@tipoComprobante";
                ParTipoCompr.SqlDbType = SqlDbType.VarChar;
                ParTipoCompr.Size = 20;
                ParTipoCompr.Value = Comprobante.TipoComprobante;
                sqlCmd.Parameters.Add(ParTipoCompr);

                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@serie";
                ParSerie.SqlDbType = SqlDbType.Int;
                ParSerie.Value = Comprobante.Serie;
                sqlCmd.Parameters.Add(ParSerie);

                SqlParameter ParNroCom = new SqlParameter();
                ParNroCom.ParameterName = "@nroComprobante";
                ParNroCom.SqlDbType = SqlDbType.Int;
                ParNroCom.Value = Comprobante.Correlativo;
                sqlCmd.Parameters.Add(ParNroCom);

                SqlParameter ParIgv = new SqlParameter();
                ParIgv.ParameterName = "@igv";
                ParIgv.SqlDbType = SqlDbType.Decimal;
                ParIgv.Precision = 8;
                ParIgv.Scale = 3;
                ParIgv.Value = Comprobante.Igv;
                sqlCmd.Parameters.Add(ParIgv);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = Comprobante.Fecha;
                sqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = Comprobante.IdVenta;
                sqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = Comprobante.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idCliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Comprobante.IdCliente;
                sqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParMonto = new SqlParameter();
                ParMonto.ParameterName = "@monto";
                ParMonto.SqlDbType = SqlDbType.Decimal;
                ParMonto.Precision = 6;
                ParMonto.Scale = 2;
                ParMonto.Value = Comprobante.Monto;
                sqlCmd.Parameters.Add(ParMonto);

                SqlParameter ParEfectivo = new SqlParameter();
                ParEfectivo.ParameterName = "@efectivo";
                ParEfectivo.SqlDbType = SqlDbType.Decimal;
                ParEfectivo.Precision = 6;
                ParEfectivo.Scale = 2;
                ParEfectivo.Value = Comprobante.Efectivo;
                sqlCmd.Parameters.Add(ParEfectivo);

                SqlParameter ParTarjeta = new SqlParameter();
                ParTarjeta.ParameterName = "@tarjeta";
                ParTarjeta.SqlDbType = SqlDbType.Decimal;
                ParTarjeta.Precision = 6;
                ParTarjeta.Scale = 2;
                ParTarjeta.Value = Comprobante.Tarjeta;
                sqlCmd.Parameters.Add(ParTarjeta);

                SqlParameter ParRedondeo = new SqlParameter();
                ParRedondeo.ParameterName = "@redondeo";
                ParRedondeo.SqlDbType = SqlDbType.Decimal;
                ParRedondeo.Precision = 6;
                ParRedondeo.Scale = 2;
                ParRedondeo.Value = Comprobante.Redondeo;
                sqlCmd.Parameters.Add(ParRedondeo);

                SqlParameter ParFormaPago = new SqlParameter();
                ParFormaPago.ParameterName = "@formaPago";
                ParFormaPago.SqlDbType = SqlDbType.VarChar;
                ParFormaPago.Size = 30;
                ParFormaPago.Value = Comprobante.FormaPago;
                sqlCmd.Parameters.Add(ParFormaPago);

                SqlParameter ParVuelto = new SqlParameter();
                ParVuelto.ParameterName = "@vuelto";
                ParVuelto.SqlDbType = SqlDbType.Decimal;
                ParVuelto.Precision = 6;
                ParVuelto.Scale = 2;
                ParVuelto.Value = Comprobante.Vuelto;
                sqlCmd.Parameters.Add(ParVuelto);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingresó el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;
        }

        public DataTable mostrarComprobantesAnulados(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dtResultado = new DataTable("Comprobante");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarComprobantesAnulados";
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
