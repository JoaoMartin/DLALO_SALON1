using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCompra
    {
        private int _IdIngreso;
        private int _IdUsuario;
        private int _IdProveedor;
        private DateTime _FechaIngreso;
        private string _TipoComprobante;
        private string _Serie;
        private string _Correlativo;
        private decimal _Igv;
        private string _FormaPago;
        private string _TipoMoneda;
        private string _Estado;
        private decimal _Total;
        public int IdIngreso
        {
            get
            {
                return _IdIngreso;
            }

            set
            {
                _IdIngreso = value;
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

        public int IdProveedor
        {
            get
            {
                return _IdProveedor;
            }

            set
            {
                _IdProveedor = value;
            }
        }

        public DateTime FechaIngreso
        {
            get
            {
                return _FechaIngreso;
            }

            set
            {
                _FechaIngreso = value;
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

        public string Correlativo
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

        public string TipoMoneda
        {
            get
            {
                return _TipoMoneda;
            }

            set
            {
                _TipoMoneda = value;
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

        public decimal Total
        {
            get
            {
                return _Total;
            }

            set
            {
                _Total = value;
            }
        }

        public DCompra() { }

        public DCompra(int idIngreso, int idUsuario, int idProveedor, DateTime fechaIngreso, string tipoComprobante, string serie, string correlativo, decimal igv, string formaPago, string tipoMoneda ,string estado, decimal total)
        {
            this.IdIngreso = idIngreso;
            this.IdUsuario = idUsuario;
            this.IdProveedor = idProveedor;
            this.FechaIngreso = fechaIngreso;
            this.TipoComprobante = tipoComprobante;
            this.Serie = serie;
            this.Correlativo = correlativo;
            this.Igv = igv;
            this.FormaPago = formaPago;
            this.TipoMoneda = tipoMoneda;
            this.Estado = estado;
            this.Total = total;
        }

        public string Insertar(DCompra Ingreso, List<DDetalleCompra> DetalleIngreso)
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

                sqlCmd.CommandText = "sp_insertarCompra";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdIngreso = new SqlParameter();
                ParIdIngreso.ParameterName = "@idIngreso";
                ParIdIngreso.SqlDbType = SqlDbType.Int;
                ParIdIngreso.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdIngreso);

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idUsuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Ingreso.IdUsuario;
                sqlCmd.Parameters.Add(ParIdUsuario);

                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idProveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Ingreso.IdProveedor;
                sqlCmd.Parameters.Add(ParIdProveedor);

                SqlParameter ParFechaIngreso = new SqlParameter();
                ParFechaIngreso.ParameterName = "@fechaIngreso";
                ParFechaIngreso.SqlDbType = SqlDbType.Date;
                ParFechaIngreso.Value = Ingreso.FechaIngreso;
                sqlCmd.Parameters.Add(ParFechaIngreso);

                SqlParameter ParTipoCompr = new SqlParameter();
                ParTipoCompr.ParameterName = "@tipoComprobante";
                ParTipoCompr.SqlDbType = SqlDbType.VarChar;
                ParTipoCompr.Size = 20;
                ParTipoCompr.Value = Ingreso.TipoComprobante;
                sqlCmd.Parameters.Add(ParTipoCompr);

                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@serie";
                ParSerie.SqlDbType = SqlDbType.VarChar;
                ParSerie.Size = 4;
                ParSerie.Value = Ingreso.Serie;
                sqlCmd.Parameters.Add(ParSerie);

                SqlParameter ParCorrelativo = new SqlParameter();
                ParCorrelativo.ParameterName = "@correlativo";
                ParCorrelativo.SqlDbType = SqlDbType.VarChar;
                ParCorrelativo.Size = 7;
                ParCorrelativo.Value = Ingreso.Correlativo;
                sqlCmd.Parameters.Add(ParCorrelativo);

                SqlParameter ParIgv = new SqlParameter();
                ParIgv.ParameterName = "@igv";
                ParIgv.SqlDbType = SqlDbType.Decimal;
                ParIgv.Precision = 8;
                ParIgv.Scale = 2;
                ParIgv.Value = Ingreso.Igv;
                sqlCmd.Parameters.Add(ParIgv);

                SqlParameter ParFormaPago = new SqlParameter();
                ParFormaPago.ParameterName = "@formaPago";
                ParFormaPago.SqlDbType = SqlDbType.VarChar;
                ParFormaPago.Size = 20;
                ParFormaPago.Value = Ingreso.FormaPago;
                sqlCmd.Parameters.Add(ParFormaPago);

                SqlParameter ParTipoMoneda = new SqlParameter();
                ParTipoMoneda.ParameterName = "@tipoMoneda";
                ParTipoMoneda.SqlDbType = SqlDbType.VarChar;
                ParTipoMoneda.Size = 20;
                ParTipoMoneda.Value = Ingreso.TipoMoneda;
                sqlCmd.Parameters.Add(ParTipoMoneda);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 7;
                ParEstado.Value = Ingreso.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParTotal = new SqlParameter();
                ParTotal.ParameterName = "@total";
                ParTotal.SqlDbType = SqlDbType.Decimal;
                ParTotal.Precision = 8;
                ParTotal.Scale = 2;
                ParTotal.Value = Ingreso.Total;
                sqlCmd.Parameters.Add(ParTotal);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingresó el Registro";

                if (rpta.Equals("OK"))
                {
                    this.IdIngreso = Convert.ToInt32(sqlCmd.Parameters["@idIngreso"].Value);
                    foreach(DDetalleCompra det in DetalleIngreso)
                    {
                        det.IdIngreso = this.IdIngreso;

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

        public string Anular(DCompra Ingreso)
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
                sqlCmd.CommandText = "sp_anularCompra";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdIngreso = new SqlParameter();
                ParIdIngreso.ParameterName = "@idIngreso";
                ParIdIngreso.SqlDbType = SqlDbType.Int;
                ParIdIngreso.Value = Ingreso.IdIngreso;
                sqlCmd.Parameters.Add(ParIdIngreso);
                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se anuló el Registro";
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

        public DataTable Mostrar(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dtResultado = new DataTable("Compra");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarCompra";
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

        public DataTable BuscarFecha(String textoBuscar, String textoBuscar2)
        {
            DataTable dtResultado = new DataTable("Compra");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarCompraFecha";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = textoBuscar;
                sqlCmd.Parameters.Add(ParTextoBuscar);

                SqlParameter ParTextoBuscar2 = new SqlParameter();
                ParTextoBuscar2.ParameterName = "@textoBuscar2";
                ParTextoBuscar2.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar2.Size = 50;
                ParTextoBuscar2.Value = textoBuscar2;
                sqlCmd.Parameters.Add(ParTextoBuscar2);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable MostrarDetalleIngreso(int textoBuscar)
        {
            DataTable dtResultado = new DataTable("DetalleCompra");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarDetalleCompra";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.Int;
                ParTextoBuscar.Value = textoBuscar;
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

        public DataTable reporteComprasProducto(DateTime fechaInicio, DateTime fechaFin, int idProducto)
        {
            DataTable dtResultado = new DataTable("Venta");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_reporteComprasProducto";
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

                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@idProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Value = idProducto;
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

        public DataTable reporteComprasProveedor(DateTime fechaInicio, DateTime fechaFin, int idProveedor)
        {
            DataTable dtResultado = new DataTable("Venta");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_reporteComprasProveedor";
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

                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idProveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = idProveedor;
                sqlCmd.Parameters.Add(ParIdProveedor);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable reporteComprasTrabajador(DateTime fechaInicio, DateTime fechaFin, int idTrabajador)
        {
            DataTable dtResultado = new DataTable("Venta");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_reporteComprasTrabajador";
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

                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idTrabajador";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = idTrabajador;
                sqlCmd.Parameters.Add(ParIdProveedor);

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
