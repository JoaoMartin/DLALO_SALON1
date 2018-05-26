using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DVenta
    {
        private int _IdVenta;
        private int? _IdCliente;
        private int? _IdMesa;
        private DateTime _Fecha;
        private string _Estado;
        private string _FormaPago;
        private decimal _Descuento;
        private int _IdTrabajador;
        private string _Modo;
        private int _NroCaja;
        private DateTime _FechaEntrega;
        private decimal _Adelanto;
        private int _IdTrabajador_Cobro;
        private string _Obs;
        private string _TextoBuscar;
        private string _Motivo;
        private string _Cliente;
        private string _Telefono;

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

        public int? IdMesa
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

        public decimal Descuento
        {
            get
            {
                return _Descuento;
            }

            set
            {
                _Descuento = value;
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

        public string Modo
        {
            get
            {
                return _Modo;
            }

            set
            {
                _Modo = value;
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

        public DateTime FechaEntrega
        {
            get
            {
                return _FechaEntrega;
            }

            set
            {
                _FechaEntrega = value;
            }
        }

        public decimal Adelanto
        {
            get
            {
                return _Adelanto;
            }

            set
            {
                _Adelanto = value;
            }
        }

        public int IdTrabajador_Cobro
        {
            get
            {
                return _IdTrabajador_Cobro;
            }

            set
            {
                _IdTrabajador_Cobro = value;
            }
        }

        public string Obs
        {
            get
            {
                return _Obs;
            }

            set
            {
                _Obs = value;
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

        public string Motivo
        {
            get
            {
                return _Motivo;
            }

            set
            {
                _Motivo = value;
            }
        }

        public string Cliente
        {
            get
            {
                return _Cliente;
            }

            set
            {
                _Cliente = value;
            }
        }

        public string Telefono
        {
            get
            {
                return _Telefono;
            }

            set
            {
                _Telefono = value;
            }
        }

        public DVenta() { }

        public DVenta(int idVenta, int idCliente,  int idMesa, DateTime fecha, string estado, string formaPago, decimal descuento, int idTrabajador, 
            string modo, int nroCaja, DateTime fechaEntrega, decimal adelanto, int idTrabajador_Cobro, string obs, string textoBuscar,
            string motivo, string cliente, string telefono)
        {
            this.IdVenta = idVenta;
            this.IdCliente = idCliente;
            this.IdMesa = idMesa;
            this.Fecha = fecha;
            this.Estado = estado;
            this.FormaPago = formaPago;
            this.Descuento = descuento;
            this.IdTrabajador = idTrabajador;
            this.Modo = modo;
            this.NroCaja = nroCaja;
            this.FechaEntrega = fechaEntrega;
            this.Adelanto = adelanto;
            this.IdTrabajador_Cobro = idTrabajador_Cobro;
            this.Obs = obs;
            this.TextoBuscar = textoBuscar;
            this.Motivo = motivo;
            this.Cliente = cliente;
        }

        public string InsertarPedido(DVenta Venta, List<DDetalleVenta> DetalleVenta, List<DDetalleVentaMenu> DetalleVentaMenu)
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

                sqlCmd.CommandText = "sp_insertarVentaPedido";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idCliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Venta.IdCliente;
                sqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParIdMesa = new SqlParameter();
                ParIdMesa.ParameterName = "@idMesa";
                ParIdMesa.SqlDbType = SqlDbType.Int;
                ParIdMesa.Value = Venta.IdMesa;
                sqlCmd.Parameters.Add(ParIdMesa);

                SqlParameter ParFechaIngreso = new SqlParameter();
                ParFechaIngreso.ParameterName = "@fechaVenta";
                ParFechaIngreso.SqlDbType = SqlDbType.DateTime;
                ParFechaIngreso.Value = Venta.Fecha;
                sqlCmd.Parameters.Add(ParFechaIngreso);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = Venta.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParFormaPago = new SqlParameter();
                ParFormaPago.ParameterName = "@formaPago";
                ParFormaPago.SqlDbType = SqlDbType.VarChar;
                ParFormaPago.Size = 30;
                ParFormaPago.Value = Venta.FormaPago;
                sqlCmd.Parameters.Add(ParFormaPago);

                SqlParameter ParDescuento = new SqlParameter();
                ParDescuento.ParameterName = "@descuento";
                ParDescuento.SqlDbType = SqlDbType.Decimal;
                ParDescuento.Precision = 8;
                ParDescuento.Scale = 2;
                ParDescuento.Value = Venta.Descuento;
                sqlCmd.Parameters.Add(ParDescuento);

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idTrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Venta.IdTrabajador;
                sqlCmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParModo = new SqlParameter();
                ParModo.ParameterName = "@modo";
                ParModo.SqlDbType = SqlDbType.VarChar;
                ParModo.Size = 20;
                ParModo.Value = Venta.Modo;
                sqlCmd.Parameters.Add(ParModo);

                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@nroCaja";
                ParNroCaja.SqlDbType = SqlDbType.Int;
                ParNroCaja.Value = Venta.NroCaja;
                sqlCmd.Parameters.Add(ParNroCaja);

                SqlParameter ParFechaEntrega = new SqlParameter();
                ParFechaEntrega.ParameterName = "@fechaEntrega";
                ParFechaEntrega.SqlDbType = SqlDbType.DateTime;
                ParFechaEntrega.Value = Venta.FechaEntrega;
                sqlCmd.Parameters.Add(ParFechaEntrega);

                SqlParameter ParAdelanto = new SqlParameter();
                ParAdelanto.ParameterName = "@adelanto";
                ParAdelanto.SqlDbType = SqlDbType.Decimal;
                ParAdelanto.Precision = 8;
                ParAdelanto.Scale = 2;
                ParAdelanto.Value = Venta.Adelanto;
                sqlCmd.Parameters.Add(ParAdelanto);

                SqlParameter ParIdTrabajador_Cobro = new SqlParameter();
                ParIdTrabajador_Cobro.ParameterName = "@idTrabajador_Cobro";
                ParIdTrabajador_Cobro.SqlDbType = SqlDbType.Int;
                ParIdTrabajador_Cobro.Value = Venta.IdTrabajador_Cobro;
                sqlCmd.Parameters.Add(ParIdTrabajador_Cobro);

                SqlParameter ParObs = new SqlParameter();
                ParObs.ParameterName = "@obs";
                ParObs.SqlDbType = SqlDbType.VarChar;
                ParObs.Size = 300;
                ParObs.Value = Venta.Obs;
                sqlCmd.Parameters.Add(ParObs);

                SqlParameter ParMotivo = new SqlParameter();
                ParMotivo.ParameterName = "@motivo";
                ParMotivo.SqlDbType = SqlDbType.VarChar;
                ParMotivo.Size = 50;
                ParMotivo.Value = Venta.Motivo;
                sqlCmd.Parameters.Add(ParMotivo);

                SqlParameter ParCliente = new SqlParameter();
                ParCliente.ParameterName = "@cliente";
                ParCliente.SqlDbType = SqlDbType.VarChar;
                ParCliente.Size = 60;
                ParCliente.Value = Venta.Cliente;
                sqlCmd.Parameters.Add(ParCliente);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 40;
                ParTelefono.Value = Venta.Telefono;
                sqlCmd.Parameters.Add(ParTelefono);


                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";

                if (rpta.Equals("OK"))
                {
                    this.IdVenta = Convert.ToInt32(sqlCmd.Parameters["@idVenta"].Value);
                    foreach (DDetalleVenta det in DetalleVenta)
                    {
                        det.IdVenta = this.IdVenta;

                        rpta = det.Insertar(det, ref sqlCon, ref sqlTran,DetalleVentaMenu);
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

        public string InsertarPedidoPrueba(DVenta Venta, List<DDetalleVenta> DetalleVenta, List<DDetalleVentaMenu> DetalleVentaMenu)
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

                sqlCmd.CommandText = "sp_insertarVentaPedido";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idCliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Venta.IdCliente;
                sqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParIdMesa = new SqlParameter();
                ParIdMesa.ParameterName = "@idMesa";
                ParIdMesa.SqlDbType = SqlDbType.Int;
                ParIdMesa.Value = Venta.IdMesa;
                sqlCmd.Parameters.Add(ParIdMesa);

                SqlParameter ParFechaIngreso = new SqlParameter();
                ParFechaIngreso.ParameterName = "@fechaVenta";
                ParFechaIngreso.SqlDbType = SqlDbType.DateTime;
                ParFechaIngreso.Value = Venta.Fecha;
                sqlCmd.Parameters.Add(ParFechaIngreso);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = Venta.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParFormaPago = new SqlParameter();
                ParFormaPago.ParameterName = "@formaPago";
                ParFormaPago.SqlDbType = SqlDbType.VarChar;
                ParFormaPago.Size = 30;
                ParFormaPago.Value = Venta.FormaPago;
                sqlCmd.Parameters.Add(ParFormaPago);

                SqlParameter ParDescuento = new SqlParameter();
                ParDescuento.ParameterName = "@descuento";
                ParDescuento.SqlDbType = SqlDbType.Decimal;
                ParDescuento.Precision = 8;
                ParDescuento.Scale = 2;
                ParDescuento.Value = Venta.Descuento;
                sqlCmd.Parameters.Add(ParDescuento);

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idTrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Venta.IdTrabajador;
                sqlCmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParModo = new SqlParameter();
                ParModo.ParameterName = "@modo";
                ParModo.SqlDbType = SqlDbType.VarChar;
                ParModo.Size = 20;
                ParModo.Value = Venta.Modo;
                sqlCmd.Parameters.Add(ParModo);

                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@nroCaja";
                ParNroCaja.SqlDbType = SqlDbType.Int;
                ParNroCaja.Value = Venta.NroCaja;
                sqlCmd.Parameters.Add(ParNroCaja);

                SqlParameter ParFechaEntrega = new SqlParameter();
                ParFechaEntrega.ParameterName = "@fechaEntrega";
                ParFechaEntrega.SqlDbType = SqlDbType.DateTime;
                ParFechaEntrega.Value = Venta.FechaEntrega;
                sqlCmd.Parameters.Add(ParFechaEntrega);

                SqlParameter ParAdelanto = new SqlParameter();
                ParAdelanto.ParameterName = "@adelanto";
                ParAdelanto.SqlDbType = SqlDbType.Decimal;
                ParAdelanto.Precision = 8;
                ParAdelanto.Scale = 2;
                ParAdelanto.Value = Venta.Adelanto;
                sqlCmd.Parameters.Add(ParAdelanto);

                SqlParameter ParIdTrabajador_Cobro = new SqlParameter();
                ParIdTrabajador_Cobro.ParameterName = "@idTrabajador_Cobro";
                ParIdTrabajador_Cobro.SqlDbType = SqlDbType.Int;
                ParIdTrabajador_Cobro.Value = Venta.IdTrabajador_Cobro;

                sqlCmd.Parameters.Add(ParIdTrabajador_Cobro);
                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";

                if (rpta.Equals("OK"))
                {
                    this.IdVenta = Convert.ToInt32(sqlCmd.Parameters["@idVenta"].Value);
                    foreach (DDetalleVenta det in DetalleVenta)
                    {
                        det.IdVenta = this.IdVenta;

                        rpta = det.InsertarPrueba(det, ref sqlCon, ref sqlTran,DetalleVentaMenu);
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

        public string InsertarPedidoDelivery(DVenta Venta, List<DDetalleVenta> DetalleVenta, DDelivery Delivery, List<DDetalleVentaMenu> DetalleMenu)
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

                sqlCmd.CommandText = "sp_insertarVentaPedido";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idCliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Venta.IdCliente;
                sqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParIdMesa = new SqlParameter();
                ParIdMesa.ParameterName = "@idMesa";
                ParIdMesa.SqlDbType = SqlDbType.Int;
                ParIdMesa.Value = Venta.IdMesa;
                sqlCmd.Parameters.Add(ParIdMesa);

                SqlParameter ParFechaIngreso = new SqlParameter();
                ParFechaIngreso.ParameterName = "@fechaVenta";
                ParFechaIngreso.SqlDbType = SqlDbType.DateTime;
                ParFechaIngreso.Value = Venta.Fecha;
                sqlCmd.Parameters.Add(ParFechaIngreso);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = Venta.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParFormaPago = new SqlParameter();
                ParFormaPago.ParameterName = "@formaPago";
                ParFormaPago.SqlDbType = SqlDbType.VarChar;
                ParFormaPago.Size = 30;
                ParFormaPago.Value = Venta.FormaPago;
                sqlCmd.Parameters.Add(ParFormaPago);

                SqlParameter ParDescuento = new SqlParameter();
                ParDescuento.ParameterName = "@descuento";
                ParDescuento.SqlDbType = SqlDbType.Decimal;
                ParDescuento.Precision = 8;
                ParDescuento.Scale = 2;
                ParDescuento.Value = Venta.Descuento;
                sqlCmd.Parameters.Add(ParDescuento);

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idTrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Venta.IdTrabajador;
                sqlCmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParModo = new SqlParameter();
                ParModo.ParameterName = "@modo";
                ParModo.SqlDbType = SqlDbType.VarChar;
                ParModo.Size = 20;
                ParModo.Value = Venta.Modo;
                sqlCmd.Parameters.Add(ParModo);

                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@nroCaja";
                ParNroCaja.SqlDbType = SqlDbType.Int;
                ParNroCaja.Value = Venta.NroCaja;
                sqlCmd.Parameters.Add(ParNroCaja);

                SqlParameter ParFechaEntrega = new SqlParameter();
                ParFechaEntrega.ParameterName = "@fechaEntrega";
                ParFechaEntrega.SqlDbType = SqlDbType.DateTime;
                ParFechaEntrega.Value = Venta.FechaEntrega;
                sqlCmd.Parameters.Add(ParFechaEntrega);

                SqlParameter ParAdelanto = new SqlParameter();
                ParAdelanto.ParameterName = "@adelanto";
                ParAdelanto.SqlDbType = SqlDbType.Decimal;
                ParAdelanto.Precision = 8;
                ParAdelanto.Scale = 2;
                ParAdelanto.Value = Venta.Adelanto;
                sqlCmd.Parameters.Add(ParAdelanto);

                SqlParameter ParIdTrabajador_Cobro = new SqlParameter();
                ParIdTrabajador_Cobro.ParameterName = "@idTrabajador_Cobro";
                ParIdTrabajador_Cobro.SqlDbType = SqlDbType.Int;
                ParIdTrabajador_Cobro.Value = Venta.IdTrabajador_Cobro;
                sqlCmd.Parameters.Add(ParIdTrabajador_Cobro);

                SqlParameter ParObs = new SqlParameter();
                ParObs.ParameterName = "@obs";
                ParObs.SqlDbType = SqlDbType.VarChar;
                ParObs.Size = 300;
                ParObs.Value = Venta.Obs;
                sqlCmd.Parameters.Add(ParObs);

                SqlParameter ParMotivo = new SqlParameter();
                ParMotivo.ParameterName = "@motivo";
                ParMotivo.SqlDbType = SqlDbType.VarChar;
                ParMotivo.Size = 50;
                ParMotivo.Value = Venta.Motivo;
                sqlCmd.Parameters.Add(ParMotivo);

                SqlParameter ParCliente = new SqlParameter();
                ParCliente.ParameterName = "@cliente";
                ParCliente.SqlDbType = SqlDbType.VarChar;
                ParCliente.Size = 60;
                ParCliente.Value = Venta.Cliente;
                sqlCmd.Parameters.Add(ParCliente);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 40;
                ParTelefono.Value = Venta.Telefono;
                sqlCmd.Parameters.Add(ParTelefono);

                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";

                if (rpta.Equals("OK"))
                {
                    this.IdVenta = Convert.ToInt32(sqlCmd.Parameters["@idVenta"].Value);
                    foreach (DDetalleVenta det in DetalleVenta)
                    {
                        det.IdVenta = this.IdVenta;

                        rpta = det.Insertar(det, ref sqlCon, ref sqlTran, DetalleMenu);
                        if (!rpta.Equals("OK"))
                        {
                            break;

                        }
                      
                    }
                    Delivery.IdVenta = this.IdVenta;
                    rpta = Delivery.Insertar(Delivery, ref sqlCon, ref sqlTran);
                }

                if (rpta.Equals("OK"))
                {
                    sqlTran.Commit();
                }
                else
                {
                    sqlTran.Rollback();
                }
                rpta = Convert.ToString(this.IdVenta);
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

        public string InsertarPedido_Pagado(DVenta Venta, List<DDetalleVenta> DetalleVenta, DComprobante compr, List<DDetalleVentaMenu> DetalleVentaMenu)
        {
            string rpta = "";
            string nroCompr = "";
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

                sqlCmd.CommandText = "sp_insertarVentaPedido";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idCliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Venta.IdCliente;
                sqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParIdMesa = new SqlParameter();
                ParIdMesa.ParameterName = "@idMesa";
                ParIdMesa.SqlDbType = SqlDbType.Int;
                ParIdMesa.Value = Venta.IdMesa;
                sqlCmd.Parameters.Add(ParIdMesa);

                SqlParameter ParFechaIngreso = new SqlParameter();
                ParFechaIngreso.ParameterName = "@fechaVenta";
                ParFechaIngreso.SqlDbType = SqlDbType.DateTime;
                ParFechaIngreso.Value = Venta.Fecha;
                sqlCmd.Parameters.Add(ParFechaIngreso);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = Venta.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParFormaPago = new SqlParameter();
                ParFormaPago.ParameterName = "@formaPago";
                ParFormaPago.SqlDbType = SqlDbType.VarChar;
                ParFormaPago.Size = 30;
                ParFormaPago.Value = Venta.FormaPago;
                sqlCmd.Parameters.Add(ParFormaPago);

                SqlParameter ParDescuento = new SqlParameter();
                ParDescuento.ParameterName = "@descuento";
                ParDescuento.SqlDbType = SqlDbType.Decimal;
                ParDescuento.Precision = 8;
                ParDescuento.Scale = 2;
                ParDescuento.Value = Venta.Descuento;
                sqlCmd.Parameters.Add(ParDescuento);

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idTrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Venta.IdTrabajador;
                sqlCmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParModo = new SqlParameter();
                ParModo.ParameterName = "@modo";
                ParModo.SqlDbType = SqlDbType.VarChar;
                ParModo.Size = 20;
                ParModo.Value = Venta.Modo;
                sqlCmd.Parameters.Add(ParModo);

                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@nroCaja";
                ParNroCaja.SqlDbType = SqlDbType.Int;
                ParNroCaja.Value = Venta.NroCaja;
                sqlCmd.Parameters.Add(ParNroCaja);

                SqlParameter ParFechaEntrega = new SqlParameter();
                ParFechaEntrega.ParameterName = "@fechaEntrega";
                ParFechaEntrega.SqlDbType = SqlDbType.DateTime;
                ParFechaEntrega.Value = Venta.FechaEntrega;
                sqlCmd.Parameters.Add(ParFechaEntrega);

                SqlParameter ParAdelanto = new SqlParameter();
                ParAdelanto.ParameterName = "@adelanto";
                ParAdelanto.SqlDbType = SqlDbType.Decimal;
                ParAdelanto.Precision = 8;
                ParAdelanto.Scale = 2;
                ParAdelanto.Value = Venta.Adelanto;
                sqlCmd.Parameters.Add(ParAdelanto);

                SqlParameter ParIdTrabajador_Cobro = new SqlParameter();
                ParIdTrabajador_Cobro.ParameterName = "@idTrabajador_Cobro";
                ParIdTrabajador_Cobro.SqlDbType = SqlDbType.Int;
                ParIdTrabajador_Cobro.Value = Venta.IdTrabajador_Cobro;
                sqlCmd.Parameters.Add(ParIdTrabajador_Cobro);

                SqlParameter ParObs = new SqlParameter();
                ParObs.ParameterName = "@obs";
                ParObs.SqlDbType = SqlDbType.VarChar;
                ParObs.Size = 300;
                ParObs.Value = Venta.Obs;
                sqlCmd.Parameters.Add(ParObs);

                SqlParameter ParMotivo = new SqlParameter();
                ParMotivo.ParameterName = "@motivo";
                ParMotivo.SqlDbType = SqlDbType.VarChar;
                ParMotivo.Size = 50;
                ParMotivo.Value = Venta.Motivo;
                sqlCmd.Parameters.Add(ParMotivo);

                SqlParameter ParCliente = new SqlParameter();
                ParCliente.ParameterName = "@cliente";
                ParCliente.SqlDbType = SqlDbType.VarChar;
                ParCliente.Size = 60;
                ParCliente.Value = Venta.Cliente;
                sqlCmd.Parameters.Add(ParCliente);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 40;
                ParTelefono.Value = Venta.Telefono;
                sqlCmd.Parameters.Add(ParTelefono);

                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";

                if (rpta.Equals("OK"))
                {
                    this.IdVenta = Convert.ToInt32(sqlCmd.Parameters["@idVenta"].Value);
                    foreach (DDetalleVenta det in DetalleVenta)
                    {
                        det.IdVenta = this.IdVenta;

                        rpta = det.Insertar(det, ref sqlCon, ref sqlTran,DetalleVentaMenu);
                        if (!rpta.Equals("OK"))
                        {
                            break;

                        }
                    }

                    compr.IdVenta = this.IdVenta;
                    rpta = compr.InsertarVenta(compr, ref sqlCon, ref sqlTran);
                }

                if (rpta.Equals("OK"))
                {
                    sqlTran.Commit();
                }
                else
                {
                    sqlTran.Rollback();
                }
                rpta = Convert.ToString(this.IdVenta);
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

        public DataTable MostrarDetalleVenta(int idVenta)
        {
            DataTable dtResultado = new DataTable("DetalleVenta");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarDetalleVenta";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = idVenta;
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

        public DataTable MostrarDetallePedido(int idVenta)
        {
            DataTable dtResultado = new DataTable("Venta");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarDetallePedido";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = idVenta;
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

        public string EditarMesaVenta(DVenta Venta)
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
                sqlCmd.CommandText = "sp_editarMesaVenta";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = Venta.IdVenta;
                sqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParIdMesa = new SqlParameter();
                ParIdMesa.ParameterName = "@idMesa";
                ParIdMesa.SqlDbType = SqlDbType.Int;
                ParIdMesa.Value = Venta.IdMesa;
                sqlCmd.Parameters.Add(ParIdMesa);

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

        public DataTable MostrarDetalleVenta_SepararCuenta(int idVenta)
        {
            DataTable dtResultado = new DataTable("DetalleVenta");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarDetalleVenta";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = idVenta;
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

        public string EditarVentaCancelada(DVenta Venta)
        {
            string rpta = "";
            DataTable dtResultado = new DataTable("DetalleVenta");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                sqlCon.Open();
                //Comandos
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_editarVenta_Pagada";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = Venta.IdVenta;
                sqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParDescuento = new SqlParameter();
                ParDescuento.ParameterName = "@descuento";
                ParDescuento.SqlDbType = SqlDbType.Decimal;
                ParDescuento.Precision = 8;
                ParDescuento.Scale = 2;
                ParDescuento.Value = Venta.Descuento;
                sqlCmd.Parameters.Add(ParDescuento);

                SqlParameter ParFormaPago = new SqlParameter();
                ParFormaPago.ParameterName = "@formaPago";
                ParFormaPago.SqlDbType = SqlDbType.VarChar;
                ParFormaPago.Size = 30;
                ParFormaPago.Value = Venta.FormaPago;
                sqlCmd.Parameters.Add(ParFormaPago);

                SqlParameter ParObs = new SqlParameter();
                ParObs.ParameterName = "@obs";
                ParObs.SqlDbType = SqlDbType.VarChar;
                ParObs.Size = 250;
                ParObs.Value = Venta.Obs;
                sqlCmd.Parameters.Add(ParObs);

                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se editó el Registro";
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

        public string EditarVentaCanceladaR(DVenta Venta)
        {
            string rpta = "";
            DataTable dtResultado = new DataTable("DetalleVenta");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                sqlCon.Open();
                //Comandos
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_editarVenta_PagadaR";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = Venta.IdVenta;
                sqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = Venta.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se editó el Registro";
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



        public string EditarVentaCS(DVenta Venta)
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
                sqlCmd.CommandText = "sp_editarEstadoVenta_CS";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = Venta.IdVenta;
                sqlCmd.Parameters.Add(ParIdVenta);

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

        public string EditarVentaD(DVenta Venta)
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
                sqlCmd.CommandText = "sp_editarEstadoVenta_D";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = Venta.IdVenta;
                sqlCmd.Parameters.Add(ParIdVenta);

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

        public string InsertarPedido_Dividido(DVenta Venta, List<DDetalleVenta> DetalleVenta, List<DDetalleVentaMenu> DetalleVentaMenu)
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

                sqlCmd.CommandText = "sp_insertarVentaPedido";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idCliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Venta.IdCliente;
                sqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParIdMesa = new SqlParameter();
                ParIdMesa.ParameterName = "@idMesa";
                ParIdMesa.SqlDbType = SqlDbType.Int;
                ParIdMesa.Value = Venta.IdMesa;
                sqlCmd.Parameters.Add(ParIdMesa);

                SqlParameter ParFechaIngreso = new SqlParameter();
                ParFechaIngreso.ParameterName = "@fechaVenta";
                ParFechaIngreso.SqlDbType = SqlDbType.DateTime;
                ParFechaIngreso.Value = Venta.Fecha;
                sqlCmd.Parameters.Add(ParFechaIngreso);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = Venta.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParFormaPago = new SqlParameter();
                ParFormaPago.ParameterName = "@formaPago";
                ParFormaPago.SqlDbType = SqlDbType.VarChar;
                ParFormaPago.Size = 30;
                ParFormaPago.Value = Venta.FormaPago;
                sqlCmd.Parameters.Add(ParFormaPago);

                SqlParameter ParDescuento = new SqlParameter();
                ParDescuento.ParameterName = "@descuento";
                ParDescuento.SqlDbType = SqlDbType.Decimal;
                ParDescuento.Precision = 8;
                ParDescuento.Scale = 2;
                ParDescuento.Value = Venta.Descuento;
                sqlCmd.Parameters.Add(ParDescuento);

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idTrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Venta.IdTrabajador;
                sqlCmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParModo = new SqlParameter();
                ParModo.ParameterName = "@modo";
                ParModo.SqlDbType = SqlDbType.VarChar;
                ParModo.Size = 20;
                ParModo.Value = Venta.Modo;
                sqlCmd.Parameters.Add(ParModo);

                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@nroCaja";
                ParNroCaja.SqlDbType = SqlDbType.Int;
                ParNroCaja.Value = Venta.NroCaja;
                sqlCmd.Parameters.Add(ParNroCaja);
                SqlParameter ParFechaEntrega = new SqlParameter();
                ParFechaEntrega.ParameterName = "@fechaEntrega";
                ParFechaEntrega.SqlDbType = SqlDbType.DateTime;
                ParFechaEntrega.Value = Venta.FechaEntrega;
                sqlCmd.Parameters.Add(ParFechaEntrega);

                SqlParameter ParAdelanto = new SqlParameter();
                ParAdelanto.ParameterName = "@adelanto";
                ParAdelanto.SqlDbType = SqlDbType.Decimal;
                ParAdelanto.Precision = 8;
                ParAdelanto.Scale = 2;
                ParAdelanto.Value = Venta.Adelanto;
                sqlCmd.Parameters.Add(ParAdelanto);

                SqlParameter ParIdTrabajador_Cobro = new SqlParameter();
                ParIdTrabajador_Cobro.ParameterName = "@idTrabajador_Cobro";
                ParIdTrabajador_Cobro.SqlDbType = SqlDbType.Int;
                ParIdTrabajador_Cobro.Value = Venta.IdTrabajador_Cobro;
                sqlCmd.Parameters.Add(ParIdTrabajador_Cobro);

                SqlParameter ParObs = new SqlParameter();
                ParObs.ParameterName = "@obs";
                ParObs.SqlDbType = SqlDbType.VarChar;
                ParObs.Size = 300;
                ParObs.Value = Venta.Obs;
                sqlCmd.Parameters.Add(ParObs);

                SqlParameter ParMotivo = new SqlParameter();
                ParMotivo.ParameterName = "@motivo";
                ParMotivo.SqlDbType = SqlDbType.VarChar;
                ParMotivo.Size = 50;
                ParMotivo.Value = Venta.Motivo;
                sqlCmd.Parameters.Add(ParMotivo);

                SqlParameter ParCliente = new SqlParameter();
                ParCliente.ParameterName = "@cliente";
                ParCliente.SqlDbType = SqlDbType.VarChar;
                ParCliente.Size = 60;
                ParCliente.Value = Venta.Cliente;
                sqlCmd.Parameters.Add(ParCliente);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 40;
                ParTelefono.Value = Venta.Telefono;
                sqlCmd.Parameters.Add(ParTelefono);

                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";

                if (rpta.Equals("OK"))
                {
                    this.IdVenta = Convert.ToInt32(sqlCmd.Parameters["@idVenta"].Value);
                    foreach (DDetalleVenta det in DetalleVenta)
                    {
                        det.IdVenta = this.IdVenta;

                        rpta = det.Insertar(det, ref sqlCon, ref sqlTran, DetalleVentaMenu);
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
                rpta = Convert.ToString(this.IdVenta);
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


        public string Eliminar(DVenta Venta)
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
                sqlCmd.CommandText = "sp_eliminarVentaCS";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = Venta.IdVenta;
                sqlCmd.Parameters.Add(ParIdVenta);

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

        public DataTable mostrarClienteVenta(int idVenta)
        {
            DataTable dtResultado = new DataTable("Cliente");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarClienteVenta1";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = idVenta;
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


        //REPORTES
        public DataTable reporteVentasFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dtResultado = new DataTable("Venta");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_reporteVentasFecha";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParFechaInicio = new SqlParameter();
                ParFechaInicio.ParameterName = "@fechaInicio";
                ParFechaInicio.SqlDbType = SqlDbType.DateTime;
                ParFechaInicio.Value = fechaInicio;
                sqlCmd.Parameters.Add(ParFechaInicio);

                SqlParameter ParFechaFin= new SqlParameter();
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

        public DataTable reporteDetalleVenta(int idVenta)
        {
            DataTable dtResultado = new DataTable("DetalleVenta");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_reporteDetalleVenta";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = idVenta;
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

        public DataTable reporteVentasProducto(DateTime fechaInicio, DateTime fechaFin, int idProducto)
        {
            DataTable dtResultado = new DataTable("Venta");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_reporteVentasProducto";
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

        public DataTable reporteVentasProductoCaja(DateTime fechaInicio, DateTime fechaFin, int idProducto,int nroCaja)
        {
            DataTable dtResultado = new DataTable("Venta");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_reporteVentasProductoCaja";
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

                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@nroCaja";
                ParNroCaja.SqlDbType = SqlDbType.Int;
                ParNroCaja.Value = nroCaja;
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

        public DataTable reporteVentasInsumo(DateTime fechaInicio, DateTime fechaFin, int idProducto)
        {
            DataTable dtResultado = new DataTable("Venta");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_reporteVentasInsumo";
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

        public DataTable reporteVentasInsumoCaja(DateTime fechaInicio, DateTime fechaFin, int idProducto, int nroCaja)
        {
            DataTable dtResultado = new DataTable("Venta");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_reporteVentasInsumoCaja";
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

                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@nroCaja";
                ParNroCaja.SqlDbType = SqlDbType.Int;
                ParNroCaja.Value = nroCaja;
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

        public DataTable reporteVentasCliente(DateTime fechaInicio, DateTime fechaFin, int idCliente)
        {
            DataTable dtResultado = new DataTable("Venta");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_reporteVentasCliente";
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

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idCliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = idCliente;
                sqlCmd.Parameters.Add(ParIdCliente);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable reporteVentasUsuario(DateTime fechaInicio, DateTime fechaFin, int idTrabajador)
        {
            DataTable dtResultado = new DataTable("Venta");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_reporteVentasTrabajador";
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

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idTrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = idTrabajador;
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

        public DataTable reporteVentasCaja(DateTime fechaInicio, DateTime fechaFin, int nroCaja)
        {
            DataTable dtResultado = new DataTable("Venta");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_reporteVentasFechaCaja";
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

                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@nroCaja";
                ParNroCaja.SqlDbType = SqlDbType.Int;
                ParNroCaja.Value = nroCaja;
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

        public string InsertarPedido_PagadoManual(DVenta Venta, List<DDetalleVenta> DetalleVenta, DComprobante compr, List<DDetalleVentaMenu> DetalleVentaMenu)
        {
            string rpta = "";
            string nroCompr = "";
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

                sqlCmd.CommandText = "sp_insertarVentaPedido";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idCliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Venta.IdCliente;
                sqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParIdMesa = new SqlParameter();
                ParIdMesa.ParameterName = "@idMesa";
                ParIdMesa.SqlDbType = SqlDbType.Int;
                ParIdMesa.Value = Venta.IdMesa;
                sqlCmd.Parameters.Add(ParIdMesa);

                SqlParameter ParFechaIngreso = new SqlParameter();
                ParFechaIngreso.ParameterName = "@fechaVenta";
                ParFechaIngreso.SqlDbType = SqlDbType.DateTime;
                ParFechaIngreso.Value = Venta.Fecha;
                sqlCmd.Parameters.Add(ParFechaIngreso);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = Venta.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParFormaPago = new SqlParameter();
                ParFormaPago.ParameterName = "@formaPago";
                ParFormaPago.SqlDbType = SqlDbType.VarChar;
                ParFormaPago.Size = 30;
                ParFormaPago.Value = Venta.FormaPago;
                sqlCmd.Parameters.Add(ParFormaPago);

                SqlParameter ParDescuento = new SqlParameter();
                ParDescuento.ParameterName = "@descuento";
                ParDescuento.SqlDbType = SqlDbType.Decimal;
                ParDescuento.Precision = 8;
                ParDescuento.Scale = 2;
                ParDescuento.Value = Venta.Descuento;
                sqlCmd.Parameters.Add(ParDescuento);

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idTrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Venta.IdTrabajador;
                sqlCmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParModo = new SqlParameter();
                ParModo.ParameterName = "@modo";
                ParModo.SqlDbType = SqlDbType.VarChar;
                ParModo.Size = 20;
                ParModo.Value = Venta.Modo;
                sqlCmd.Parameters.Add(ParModo);

                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@nroCaja";
                ParNroCaja.SqlDbType = SqlDbType.Int;
                ParNroCaja.Value = Venta.NroCaja;
                sqlCmd.Parameters.Add(ParNroCaja);
                SqlParameter ParFechaEntrega = new SqlParameter();
                ParFechaEntrega.ParameterName = "@fechaEntrega";
                ParFechaEntrega.SqlDbType = SqlDbType.DateTime;
                ParFechaEntrega.Value = Venta.FechaEntrega;
                sqlCmd.Parameters.Add(ParFechaEntrega);

                SqlParameter ParAdelanto = new SqlParameter();
                ParAdelanto.ParameterName = "@adelanto";
                ParAdelanto.SqlDbType = SqlDbType.Decimal;
                ParAdelanto.Precision = 8;
                ParAdelanto.Scale = 2;
                ParAdelanto.Value = Venta.Adelanto;
                sqlCmd.Parameters.Add(ParAdelanto);

                SqlParameter ParIdTrabajador_Cobro = new SqlParameter();
                ParIdTrabajador_Cobro.ParameterName = "@idTrabajador_Cobro";
                ParIdTrabajador_Cobro.SqlDbType = SqlDbType.Int;
                ParIdTrabajador_Cobro.Value = Venta.IdTrabajador_Cobro;
                sqlCmd.Parameters.Add(ParIdTrabajador_Cobro);

                SqlParameter ParObs = new SqlParameter();
                ParObs.ParameterName = "@obs";
                ParObs.SqlDbType = SqlDbType.VarChar;
                ParObs.Size = 300;
                ParObs.Value = Venta.Obs;
                sqlCmd.Parameters.Add(ParObs);

                SqlParameter ParMotivo = new SqlParameter();
                ParMotivo.ParameterName = "@motivo";
                ParMotivo.SqlDbType = SqlDbType.VarChar;
                ParMotivo.Size = 50;
                ParMotivo.Value = Venta.Motivo;
                sqlCmd.Parameters.Add(ParMotivo);

                SqlParameter ParCliente = new SqlParameter();
                ParCliente.ParameterName = "@cliente";
                ParCliente.SqlDbType = SqlDbType.VarChar;
                ParCliente.Size = 60;
                ParCliente.Value = Venta.Cliente;
                sqlCmd.Parameters.Add(ParCliente);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 40;
                ParTelefono.Value = Venta.Telefono;
                sqlCmd.Parameters.Add(ParTelefono);

                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";

                if (rpta.Equals("OK"))
                {
                    this.IdVenta = Convert.ToInt32(sqlCmd.Parameters["@idVenta"].Value);
                    foreach (DDetalleVenta det in DetalleVenta)
                    {
                        det.IdVenta = this.IdVenta;

                        rpta = det.Insertar(det, ref sqlCon, ref sqlTran,DetalleVentaMenu);
                        if (!rpta.Equals("OK"))
                        {
                            break;

                        }
                    }

                    compr.IdVenta = this.IdVenta;
                    rpta = compr.InsertarVentaManual(compr, ref sqlCon, ref sqlTran);
                }

                if (rpta.Equals("OK"))
                {
                    sqlTran.Commit();
                }
                else
                {
                    sqlTran.Rollback();
                }
                rpta = Convert.ToString(this.IdVenta);
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

        public string InsertarPedidoPagadoR(DVenta Venta, List<DDetalleVenta> DetalleVenta, List<DDetalleVentaMenu> DetalleVentaMenu)
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

                sqlCmd.CommandText = "sp_insertarVentaPedido";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idCliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Venta.IdCliente;
                sqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParIdMesa = new SqlParameter();
                ParIdMesa.ParameterName = "@idMesa";
                ParIdMesa.SqlDbType = SqlDbType.Int;
                ParIdMesa.Value = Venta.IdMesa;
                sqlCmd.Parameters.Add(ParIdMesa);

                SqlParameter ParFechaIngreso = new SqlParameter();
                ParFechaIngreso.ParameterName = "@fechaVenta";
                ParFechaIngreso.SqlDbType = SqlDbType.DateTime;
                ParFechaIngreso.Value = Venta.Fecha;
                sqlCmd.Parameters.Add(ParFechaIngreso);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = Venta.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParFormaPago = new SqlParameter();
                ParFormaPago.ParameterName = "@formaPago";
                ParFormaPago.SqlDbType = SqlDbType.VarChar;
                ParFormaPago.Size = 30;
                ParFormaPago.Value = Venta.FormaPago;
                sqlCmd.Parameters.Add(ParFormaPago);

                SqlParameter ParDescuento = new SqlParameter();
                ParDescuento.ParameterName = "@descuento";
                ParDescuento.SqlDbType = SqlDbType.Decimal;
                ParDescuento.Precision = 8;
                ParDescuento.Scale = 2;
                ParDescuento.Value = Venta.Descuento;
                sqlCmd.Parameters.Add(ParDescuento);

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idTrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Venta.IdTrabajador;
                sqlCmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParModo = new SqlParameter();
                ParModo.ParameterName = "@modo";
                ParModo.SqlDbType = SqlDbType.VarChar;
                ParModo.Size = 20;
                ParModo.Value = Venta.Modo;
                sqlCmd.Parameters.Add(ParModo);

                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@nroCaja";
                ParNroCaja.SqlDbType = SqlDbType.Int;
                ParNroCaja.Value = Venta.NroCaja;
                sqlCmd.Parameters.Add(ParNroCaja);

                SqlParameter ParFechaEntrega = new SqlParameter();
                ParFechaEntrega.ParameterName = "@fechaEntrega";
                ParFechaEntrega.SqlDbType = SqlDbType.DateTime;
                ParFechaEntrega.Value = Venta.FechaEntrega;
                sqlCmd.Parameters.Add(ParFechaEntrega);

                SqlParameter ParAdelanto = new SqlParameter();
                ParAdelanto.ParameterName = "@adelanto";
                ParAdelanto.SqlDbType = SqlDbType.Decimal;
                ParAdelanto.Precision = 8;
                ParAdelanto.Scale = 2;
                ParAdelanto.Value = Venta.Adelanto;
                sqlCmd.Parameters.Add(ParAdelanto);

                SqlParameter ParIdTrabajador_Cobro = new SqlParameter();
                ParIdTrabajador_Cobro.ParameterName = "@idTrabajador_Cobro";
                ParIdTrabajador_Cobro.SqlDbType = SqlDbType.Int;
                ParIdTrabajador_Cobro.Value = Venta.IdTrabajador_Cobro;
                sqlCmd.Parameters.Add(ParIdTrabajador_Cobro);

                SqlParameter ParObs = new SqlParameter();
                ParObs.ParameterName = "@obs";
                ParObs.SqlDbType = SqlDbType.VarChar;
                ParObs.Size = 300;
                ParObs.Value = Venta.Obs;
                sqlCmd.Parameters.Add(ParObs);

                SqlParameter ParMotivo = new SqlParameter();
                ParMotivo.ParameterName = "@motivo";
                ParMotivo.SqlDbType = SqlDbType.VarChar;
                ParMotivo.Size = 50;
                ParMotivo.Value = Venta.Motivo;
                sqlCmd.Parameters.Add(ParMotivo);

                SqlParameter ParCliente = new SqlParameter();
                ParCliente.ParameterName = "@cliente";
                ParCliente.SqlDbType = SqlDbType.VarChar;
                ParCliente.Size = 60;
                ParCliente.Value = Venta.Cliente;
                sqlCmd.Parameters.Add(ParCliente);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 40;
                ParTelefono.Value = Venta.Telefono;
                sqlCmd.Parameters.Add(ParTelefono);


                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";

                if (rpta.Equals("OK"))
                {
                    this.IdVenta = Convert.ToInt32(sqlCmd.Parameters["@idVenta"].Value);
                    foreach (DDetalleVenta det in DetalleVenta)
                    {
                        det.IdVenta = this.IdVenta;

                        rpta = det.Insertar(det, ref sqlCon, ref sqlTran, DetalleVentaMenu);
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
            rpta = Convert.ToString(this.IdVenta);
            return rpta;

           
        }

        public DataTable mostrarPedidosPendientes()
        {
            DataTable dtResultado = new DataTable("Pedidos");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarPedidosPendientes";
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

        public DataTable BuscarPedidosPendientes(DVenta Venta)
        {
            DataTable dtResultado = new DataTable("Venta");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_BuscarPedidosPendientes";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Venta.TextoBuscar;

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

        public string EditarEstadoVentaReservada(DVenta Venta)
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
                sqlCmd.CommandText = "sp_editarEstadoVentaReservada";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = Venta.IdVenta;
                sqlCmd.Parameters.Add(ParIdVenta);

              
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

        public string EditarReservaCancelada(DVenta Venta)
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
                sqlCmd.CommandText = "sp_editarReservaCancelada";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = Venta.IdVenta;
                sqlCmd.Parameters.Add(ParIdVenta);


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

        public DataTable reporteVentasFecha_TipoComprobante(DateTime fechaInicio, DateTime fechaFin, string tipo)
        {
            DataTable dtResultado = new DataTable("Venta");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_reporteVentasFecha_TipoComprobante";
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

                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@tipo";
                ParTipo.SqlDbType = SqlDbType.VarChar;
                ParTipo.Size = 20;
                ParTipo.Value = tipo;
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

        public DataTable BuscarPedidosPendientesCliente(DVenta Venta)
        {
            DataTable dtResultado = new DataTable("Venta");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_BuscarPedidosPendientes_Cliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Venta.TextoBuscar;

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

    }
}
