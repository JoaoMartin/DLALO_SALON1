using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDelivery
    {
        private int _IdDelivery;
        private int _IdVenta;
        private string _TipoCompr;
        private decimal _Vuelto;
        private string _Estado;
        private decimal _Total;
        private decimal _PagaCon;
        private string _Repartidor;
        private decimal _DctoInd;
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

        public string TipoCompr
        {
            get
            {
                return _TipoCompr;
            }

            set
            {
                _TipoCompr = value;
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

        public int IdDelivery
        {
            get
            {
                return _IdDelivery;
            }

            set
            {
                _IdDelivery = value;
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

        public decimal PagaCon
        {
            get
            {
                return _PagaCon;
            }

            set
            {
                _PagaCon = value;
            }
        }

        public string Repartidor
        {
            get
            {
                return _Repartidor;
            }

            set
            {
                _Repartidor = value;
            }
        }

        public decimal DctoInd
        {
            get
            {
                return _DctoInd;
            }

            set
            {
                _DctoInd = value;
            }
        }

        public DDelivery() { }

        public DDelivery(int idDelivery, int idVenta, string tipoCompr, decimal vuelto, string estado, decimal total, decimal pagaCon, string repartidor,decimal dctoInd)
        {
            this.IdDelivery = idDelivery;
            this.IdVenta = idVenta;
            this.TipoCompr = tipoCompr;
            this.Vuelto = vuelto;
            this.Estado = estado;
            this.Total = total;
            this.PagaCon = pagaCon;
            this.Repartidor = repartidor;
            this.DctoInd = dctoInd;
        }

        public string Insertar(DDelivery Delivery, ref SqlConnection sqlCon, ref SqlTransaction sqlTran)
        {
            string rpta = "";
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.Transaction = sqlTran;

                sqlCmd.CommandText = "sp_insertarDelivery";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDelivery = new SqlParameter();
                ParIdDelivery.ParameterName = "@idDelivery";
                ParIdDelivery.SqlDbType = SqlDbType.Int;
                ParIdDelivery.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdDelivery);

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = Delivery.IdVenta;
                sqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParTipoCompr = new SqlParameter();
                ParTipoCompr.ParameterName = "@tipoCompr";
                ParTipoCompr.SqlDbType = SqlDbType.VarChar;
                ParTipoCompr.Size = 12;
                ParTipoCompr.Value = Delivery.TipoCompr;
                sqlCmd.Parameters.Add(ParTipoCompr);

                SqlParameter ParVuelto = new SqlParameter();
                ParVuelto.ParameterName = "@vuelto";
                ParVuelto.SqlDbType = SqlDbType.Decimal;
                ParVuelto.Precision = 6;
                ParVuelto.Scale = 2;
                ParVuelto.Value = Delivery.Vuelto;
                sqlCmd.Parameters.Add(ParVuelto);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Char;
                ParEstado.Size = 1;
                ParEstado.Value = Delivery.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParTotal = new SqlParameter();
                ParTotal.ParameterName = "@total";
                ParTotal.SqlDbType = SqlDbType.Decimal;
                ParTotal.Precision = 6;
                ParTotal.Scale = 2;
                ParTotal.Value = Delivery.Total;
                sqlCmd.Parameters.Add(ParTotal);

                SqlParameter ParPagaCon = new SqlParameter();
                ParPagaCon.ParameterName = "@pagaCon";
                ParPagaCon.SqlDbType = SqlDbType.Decimal;
                ParPagaCon.Precision = 6;
                ParPagaCon.Scale = 2;
                ParPagaCon.Value = Delivery.PagaCon;
                sqlCmd.Parameters.Add(ParPagaCon);

                SqlParameter ParRepartidor = new SqlParameter();
                ParRepartidor.ParameterName = "@repartidor";
                ParRepartidor.SqlDbType = SqlDbType.VarChar;
                ParRepartidor.Size = 100;
                ParRepartidor.Value = Delivery.Repartidor;
                sqlCmd.Parameters.Add(ParRepartidor);

                SqlParameter ParDctoInd = new SqlParameter();
                ParDctoInd.ParameterName = "@dctoInd";
                ParDctoInd.SqlDbType = SqlDbType.Decimal;
                ParDctoInd.Precision = 6;
                ParDctoInd.Scale = 2;
                ParDctoInd.Value = Delivery.DctoInd;
                sqlCmd.Parameters.Add(ParDctoInd);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingresó el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;
        }

        public DataTable mostrarDeliveryCobrar()
        {
            DataTable dtResultado = new DataTable("Delivery");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarDeliveryCobrar";
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


        public string EditarEstadoDelivery(DDelivery Delivery)
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
                sqlCmd.CommandText = "sp_editarEstadoDelivery";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = Delivery.IdVenta;
                sqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = Delivery.Estado;
                sqlCmd.Parameters.Add(ParEstado);


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

        public string EliminarVentaDelivery(DDelivery Delivery)
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
                sqlCmd.CommandText = "sp_eliminarVentaDelivery";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = Delivery.IdVenta;
                sqlCmd.Parameters.Add(ParIdVenta);

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
    }
}
