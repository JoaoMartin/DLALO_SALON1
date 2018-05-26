using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalleMovimientoAlmacen
    {
        private int _IdDetalleMov;
        private int _IdMovimiento;
        private int _IdProducto;
        private decimal _Cantidad;
        private string _TipoProducto;
        private string _TipoMov;
        private string _LugarSalida;

        public int IdDetalleMov
        {
            get
            {
                return _IdDetalleMov;
            }

            set
            {
                _IdDetalleMov = value;
            }
        }

        public int IdMovimiento
        {
            get
            {
                return _IdMovimiento;
            }

            set
            {
                _IdMovimiento = value;
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

        public decimal Cantidad
        {
            get
            {
                return _Cantidad;
            }

            set
            {
                _Cantidad = value;
            }
        }

        public string TipoProducto
        {
            get
            {
                return _TipoProducto;
            }

            set
            {
                _TipoProducto = value;
            }
        }

        public string TipoMov
        {
            get
            {
                return _TipoMov;
            }

            set
            {
                _TipoMov = value;
            }
        }

        public string LugarSalida
        {
            get
            {
                return _LugarSalida;
            }

            set
            {
                _LugarSalida = value;
            }
        }

        public DDetalleMovimientoAlmacen() { }

        public DDetalleMovimientoAlmacen(int idDetalleMov, int idMovimiento, int idProducto, decimal cantidad, string tipoProducto, string tipoMov, string lugarSalida)
        {
            this.IdDetalleMov = idDetalleMov;
            this.IdMovimiento = idMovimiento;
            this.IdProducto = idProducto;
            this.Cantidad = cantidad;
            this.TipoProducto = tipoProducto;
            this.TipoMov = tipoMov;
            this.LugarSalida = lugarSalida;
        }

        public string Insertar(DDetalleMovimientoAlmacen DetalleMovimiento, ref SqlConnection sqlCon, ref SqlTransaction sqlTran)
        {
            string rpta = "";
            try
            {
                //Comandos
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.Transaction = sqlTran;

                sqlCmd.CommandText = "sp_insertarDetalleMovimientoAlmacen";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDetalleMov = new SqlParameter();
                ParIdDetalleMov.ParameterName = "@idDetalleMov";
                ParIdDetalleMov.SqlDbType = SqlDbType.Int;
                ParIdDetalleMov.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdDetalleMov);

                SqlParameter ParIdMovimiento = new SqlParameter();
                ParIdMovimiento.ParameterName = "@idMovimiento";
                ParIdMovimiento.SqlDbType = SqlDbType.Int;
                ParIdMovimiento.Value = DetalleMovimiento.IdMovimiento;
                sqlCmd.Parameters.Add(ParIdMovimiento);

                SqlParameter ParidProducto = new SqlParameter();
                ParidProducto.ParameterName = "@idProducto";
                ParidProducto.SqlDbType = SqlDbType.Int;
                ParidProducto.Value = DetalleMovimiento.IdProducto;
                sqlCmd.Parameters.Add(ParidProducto);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Decimal;
                ParCantidad.Precision = 9;
                ParCantidad.Scale = 3;
                ParCantidad.Value = DetalleMovimiento.Cantidad;
                sqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParTipoProducto = new SqlParameter();
                ParTipoProducto.ParameterName = "@tipoProducto";
                ParTipoProducto.SqlDbType = SqlDbType.Char;
                ParTipoProducto.Size = 1;
                ParTipoProducto.Value = DetalleMovimiento.TipoProducto;
                sqlCmd.Parameters.Add(ParTipoProducto);

                SqlParameter ParTipoMovimiento = new SqlParameter();
                ParTipoMovimiento.ParameterName = "@tipoMov";
                ParTipoMovimiento.SqlDbType = SqlDbType.Char;
                ParTipoMovimiento.Size = 1;
                ParTipoMovimiento.Value = DetalleMovimiento.TipoMov;
                sqlCmd.Parameters.Add(ParTipoMovimiento);

                SqlParameter ParLugarSalida = new SqlParameter();
                ParLugarSalida.ParameterName = "@lugarSalida";
                ParLugarSalida.SqlDbType = SqlDbType.Char;
                ParLugarSalida.Size = 1;
                ParLugarSalida.Value = DetalleMovimiento.LugarSalida;
                sqlCmd.Parameters.Add(ParLugarSalida);


                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";
                //sqlCmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }


        public DataTable mostrarMovAlmacenProductos(int idProducto, string tipo)
        {
            DataTable dtResultado = new DataTable("Venta");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarMovProductosAlmacen";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@idProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Value = idProducto;
                sqlCmd.Parameters.Add(ParIdProducto);

                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@tipo";
                ParTipo.SqlDbType = SqlDbType.VarChar;
                ParTipo.Size = 10;
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
    }
}
