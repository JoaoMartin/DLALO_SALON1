using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalleCompra
    {
        private int _IdDetalleIngreso;
        private int _IdIngreso;
        private int _IdProducto;
        private decimal _PrecioVenta;
        private decimal _PrecioCompra;
        private decimal _Cantidad;
        private string _Tipo;
        public int IdDetalleIngreso
        {
            get
            {
                return _IdDetalleIngreso;
            }

            set
            {
                _IdDetalleIngreso = value;
            }
        }

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

        public decimal PrecioVenta
        {
            get
            {
                return _PrecioVenta;
            }

            set
            {
                _PrecioVenta = value;
            }
        }

        public decimal PrecioCompra
        {
            get
            {
                return _PrecioCompra;
            }

            set
            {
                _PrecioCompra = value;
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

        public string Tipo
        {
            get
            {
                return _Tipo;
            }

            set
            {
                _Tipo = value;
            }
        }

        public DDetalleCompra() { }

        public DDetalleCompra(int idDetalleIngreso, int idIngreso, int idProducto, decimal precioVenta ,decimal precioCompra, decimal cantidad, string tipo)
        {
            this.IdDetalleIngreso = idDetalleIngreso;
            this.IdIngreso = idIngreso;
            this.IdProducto = idProducto;
            this.PrecioVenta = precioVenta;
            this.PrecioCompra = precioCompra;
            this.Cantidad = cantidad;
            this.Tipo = tipo;
        }

        public string Insertar(DDetalleCompra DetalleIngreso, ref SqlConnection sqlCon, ref SqlTransaction sqlTran)
        {
            string rpta = "";
            try
            {
                //Comandos
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.Transaction = sqlTran;

                sqlCmd.CommandText = "sp_insertarDetalleCompra";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDetalleIngreso = new SqlParameter();
                ParIdDetalleIngreso.ParameterName = "@idDetalleIngreso";
                ParIdDetalleIngreso.SqlDbType = SqlDbType.Int;
                ParIdDetalleIngreso.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdDetalleIngreso);

                SqlParameter ParIdIngreso = new SqlParameter();
                ParIdIngreso.ParameterName = "@idIngreso";
                ParIdIngreso.SqlDbType = SqlDbType.Int;
                ParIdIngreso.Value = DetalleIngreso.IdIngreso;
                sqlCmd.Parameters.Add(ParIdIngreso);

                SqlParameter ParidProducto = new SqlParameter();
                ParidProducto.ParameterName = "@idProducto";
                ParidProducto.SqlDbType = SqlDbType.Int;
                ParidProducto.Value = DetalleIngreso.IdProducto;
                sqlCmd.Parameters.Add(ParidProducto);

                SqlParameter ParPrecioCompra = new SqlParameter();
                ParPrecioCompra.ParameterName = "@precioCompra";
                ParPrecioCompra.SqlDbType = SqlDbType.Money;
                ParPrecioCompra.Value = DetalleIngreso.PrecioCompra;
                sqlCmd.Parameters.Add(ParPrecioCompra);

                SqlParameter ParPrecioVenta = new SqlParameter();
                ParPrecioVenta.ParameterName = "@precioVenta";
                ParPrecioVenta.SqlDbType = SqlDbType.Money;
                ParPrecioVenta.Value = DetalleIngreso.PrecioVenta;
                sqlCmd.Parameters.Add(ParPrecioVenta);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Decimal;
                ParCantidad.Precision = 9;
                ParCantidad.Scale = 3;
                ParCantidad.Value = DetalleIngreso.Cantidad;
                sqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@tipo";
                ParTipo.SqlDbType = SqlDbType.Char;
                ParTipo.Size = 1;
                ParTipo.Value = DetalleIngreso.Tipo;
                sqlCmd.Parameters.Add(ParTipo);

                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";
                //sqlCmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }
    }
}
