using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalleVenta
    {
        private int _IdDetalleVenta;
        private int _IdVenta;
        private int _IdProducto;
        private int _Cantidad;
        private decimal _PrecioVenta;
        private decimal _Descuento;
        private string _Nota;
        private string _Barra;
        private string _Tipo;
        private string _Estado;

        public int IdDetalleVenta
        {
            get
            {
                return _IdDetalleVenta;
            }

            set
            {
                _IdDetalleVenta = value;
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

        public int Cantidad
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

        public string Nota
        {
            get
            {
                return _Nota;
            }

            set
            {
                _Nota = value;
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

        public string Barra
        {
            get
            {
                return _Barra;
            }

            set
            {
                _Barra = value;
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

        public DDetalleVenta() { }

        public DDetalleVenta(int idDetalleVenta, int idVenta, int idProducto, decimal precioVenta, decimal descuento,int cantidad ,string nota, string Tipo, string barra, string estado)
        {
            this.IdDetalleVenta = idDetalleVenta;
            this.IdVenta = idVenta;
            this.IdProducto = idProducto;
            this.PrecioVenta = precioVenta;
            this.Descuento = descuento;
            this.Cantidad = cantidad;
            this.Nota = nota;
            this.Barra = barra;
            this.Tipo = Tipo;
            this.Estado = estado;
        }

        public string Insertar(DDetalleVenta DetalleVenta, ref SqlConnection sqlCon, ref SqlTransaction sqlTran, List<DDetalleVentaMenu> DetalleVentaMenu)
        {
            string rpta = "";
            try
            {
                //Comandos
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.Transaction = sqlTran;

                sqlCmd.CommandText = "sp_insertarDetalleVenta";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDetalleVenta = new SqlParameter();
                ParIdDetalleVenta.ParameterName = "@idDetalleVenta";
                ParIdDetalleVenta.SqlDbType = SqlDbType.Int;
                ParIdDetalleVenta.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdDetalleVenta);

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = DetalleVenta.IdVenta;
                sqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParidProducto = new SqlParameter();
                ParidProducto.ParameterName = "@idProducto";
                ParidProducto.SqlDbType = SqlDbType.Int;
                ParidProducto.Value = DetalleVenta.IdProducto;
                sqlCmd.Parameters.Add(ParidProducto);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = DetalleVenta.Cantidad;
                sqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParPrecioVenta = new SqlParameter();
                ParPrecioVenta.ParameterName = "@precioVenta";
                ParPrecioVenta.SqlDbType = SqlDbType.Decimal;
                ParPrecioVenta.Precision = 8;
                ParPrecioVenta.Scale = 2;
                ParPrecioVenta.Value = DetalleVenta.PrecioVenta;
                sqlCmd.Parameters.Add(ParPrecioVenta);

                SqlParameter ParDescuento = new SqlParameter();
                ParDescuento.ParameterName = "@descuento";
                ParDescuento.SqlDbType = SqlDbType.Decimal;
                ParDescuento.Precision = 8;
                ParDescuento.Scale = 2;
                ParDescuento.Value = DetalleVenta.Descuento;
                sqlCmd.Parameters.Add(ParDescuento);

                SqlParameter ParNota = new SqlParameter();
                ParNota.ParameterName = "@nota";
                ParNota.SqlDbType = SqlDbType.VarChar;
                ParNota.Size = 250;
                ParNota.Value = DetalleVenta.Nota;
                sqlCmd.Parameters.Add(ParNota);

                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@tipo";
                ParTipo.SqlDbType = SqlDbType.Char;
                ParTipo.Size = 1;
                ParTipo.Value = DetalleVenta.Tipo;
                sqlCmd.Parameters.Add(ParTipo);

                SqlParameter ParBarra = new SqlParameter();
                ParBarra.ParameterName = "@barra";
                ParBarra.SqlDbType = SqlDbType.Char;
                ParBarra.Size = 2;
                ParBarra.Value = DetalleVenta.Barra;
                sqlCmd.Parameters.Add(ParBarra);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = DetalleVenta.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";
                if (rpta.Equals("OK"))
                {
                    if (DetalleVenta.Tipo == "M")
                    {
                        this.IdDetalleVenta = Convert.ToInt32(sqlCmd.Parameters["@idDetalleVenta"].Value);
                        foreach (DDetalleVentaMenu det in DetalleVentaMenu)
                        {
                            det.IdDetalleVenta = this.IdDetalleVenta;
                            if(DetalleVenta.Barra == det.Barra)
                            {
                                rpta = det.Insertar(det, ref sqlCon, ref sqlTran);
                                if (!rpta.Equals("OK"))
                                {
                                    break;

                                }
                            }
                            
                        }
                    }

                }

                //sqlCmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }

        public string InsertarPrueba(DDetalleVenta DetalleVenta, ref SqlConnection sqlCon, ref SqlTransaction sqlTran, List<DDetalleVentaMenu> DetalleVentaMenu)
        {
            string rpta = "";
            try
            {
                //Comandos
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.Transaction = sqlTran;

                sqlCmd.CommandText = "sp_insertarDetalleVentaPrueba";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDetalleVenta = new SqlParameter();
                ParIdDetalleVenta.ParameterName = "@idDetalleVenta";
                ParIdDetalleVenta.SqlDbType = SqlDbType.Int;
                ParIdDetalleVenta.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdDetalleVenta);

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = DetalleVenta.IdVenta;
                sqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParidProducto = new SqlParameter();
                ParidProducto.ParameterName = "@idProducto";
                ParidProducto.SqlDbType = SqlDbType.Int;
                ParidProducto.Value = DetalleVenta.IdProducto;
                sqlCmd.Parameters.Add(ParidProducto);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = DetalleVenta.Cantidad;
                sqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParPrecioVenta = new SqlParameter();
                ParPrecioVenta.ParameterName = "@precioVenta";
                ParPrecioVenta.SqlDbType = SqlDbType.Decimal;
                ParPrecioVenta.Precision = 8;
                ParPrecioVenta.Scale = 2;
                ParPrecioVenta.Value = DetalleVenta.PrecioVenta;
                sqlCmd.Parameters.Add(ParPrecioVenta);

                SqlParameter ParDescuento = new SqlParameter();
                ParDescuento.ParameterName = "@descuento";
                ParDescuento.SqlDbType = SqlDbType.Decimal;
                ParDescuento.Precision = 8;
                ParDescuento.Scale = 2;
                ParDescuento.Value = DetalleVenta.Descuento;
                sqlCmd.Parameters.Add(ParDescuento);

                SqlParameter ParNota = new SqlParameter();
                ParNota.ParameterName = "@nota";
                ParNota.SqlDbType = SqlDbType.VarChar;
                ParNota.Size = 250;
                ParNota.Value = DetalleVenta.Nota;
                sqlCmd.Parameters.Add(ParNota);

                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@tipo";
                ParTipo.SqlDbType = SqlDbType.Char;
                ParTipo.Size = 1;
                ParTipo.Value = DetalleVenta.Tipo;
                sqlCmd.Parameters.Add(ParTipo);

                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";
                if (rpta.Equals("OK"))
                {
                    if(DetalleVenta.Tipo == "M")
                    {
                        this.IdDetalleVenta = Convert.ToInt32(sqlCmd.Parameters["@idDetalleVenta"].Value);
                        foreach (DDetalleVentaMenu det in DetalleVentaMenu)
                        {
                            det.IdDetalleVenta = this.IdDetalleVenta;

                            rpta = det.Insertar(det, ref sqlCon, ref sqlTran);
                            if (!rpta.Equals("OK"))
                            {
                                break;

                            }
                        }
                    }
                    
                }



                //sqlCmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }


        public string InsertarAdic(DDetalleVenta DetalleVenta, List<DDetalleVentaMenu> DetalleVentaMenu)
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
                sqlCmd.CommandText = "sp_insertarDetalleVenta";
                sqlCmd.CommandType = CommandType.StoredProcedure;

              

                SqlParameter ParIdDetalleVenta = new SqlParameter();
                ParIdDetalleVenta.ParameterName = "@idDetalleVenta";
                ParIdDetalleVenta.SqlDbType = SqlDbType.Int;
                ParIdDetalleVenta.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdDetalleVenta);

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = DetalleVenta.IdVenta;
                sqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParidProducto = new SqlParameter();
                ParidProducto.ParameterName = "@idProducto";
                ParidProducto.SqlDbType = SqlDbType.Int;
                ParidProducto.Value = DetalleVenta.IdProducto;
                sqlCmd.Parameters.Add(ParidProducto);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = DetalleVenta.Cantidad;
                sqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParPrecioVenta = new SqlParameter();
                ParPrecioVenta.ParameterName = "@precioVenta";
                ParPrecioVenta.SqlDbType = SqlDbType.Decimal;
                ParPrecioVenta.Precision = 8;
                ParPrecioVenta.Scale = 2;
                ParPrecioVenta.Value = DetalleVenta.PrecioVenta;
                sqlCmd.Parameters.Add(ParPrecioVenta);

                SqlParameter ParDescuento = new SqlParameter();
                ParDescuento.ParameterName = "@descuento";
                ParDescuento.SqlDbType = SqlDbType.Decimal;
                ParDescuento.Precision = 8;
                ParDescuento.Scale = 2;
                ParDescuento.Value = DetalleVenta.Descuento;
                sqlCmd.Parameters.Add(ParDescuento);

                SqlParameter ParNota = new SqlParameter();
                ParNota.ParameterName = "@nota";
                ParNota.SqlDbType = SqlDbType.VarChar;
                ParNota.Size = 250;
                ParNota.Value = DetalleVenta.Nota;
                sqlCmd.Parameters.Add(ParNota);

                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@tipo";
                ParTipo.SqlDbType = SqlDbType.Char;
                ParTipo.Value = DetalleVenta.Tipo;
                sqlCmd.Parameters.Add(ParTipo);

                SqlParameter ParBarra = new SqlParameter();
                ParBarra.ParameterName = "@barra";
                ParBarra.SqlDbType = SqlDbType.Char;
                ParBarra.Size = 2;
                ParBarra.Value = DetalleVenta.Barra;
                sqlCmd.Parameters.Add(ParBarra);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = DetalleVenta.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";
                if (rpta.Equals("OK"))
                {
                    if (DetalleVenta.Tipo == "M")
                    {
                        this.IdDetalleVenta = Convert.ToInt32(sqlCmd.Parameters["@idDetalleVenta"].Value);
                        foreach (DDetalleVentaMenu det in DetalleVentaMenu)
                        {
                            det.IdDetalleVenta = this.IdDetalleVenta;

                            rpta = det.InsertarAdic(det);
                            if (!rpta.Equals("OK"))
                            {
                                break;

                            }
                        }
                    }

                }
                //sqlCmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }

        public string EditarNota(DDetalleVenta DDetalle)
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
                sqlCmd.CommandText = "sp_editarNotaPedido";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParidDetalle = new SqlParameter();
                ParidDetalle.ParameterName = "@idDetalle";
                ParidDetalle.SqlDbType = SqlDbType.Int;
                ParidDetalle.Value = DDetalle.IdDetalleVenta;
                sqlCmd.Parameters.Add(ParidDetalle);
            
                SqlParameter ParNota = new SqlParameter();
                ParNota.ParameterName = "@nota";
                ParNota.SqlDbType = SqlDbType.VarChar;
                ParNota.Size = 250;
                ParNota.Value = DDetalle.Nota;
                sqlCmd.Parameters.Add(ParNota);

                SqlParameter ParDescuento = new SqlParameter();
                ParDescuento.ParameterName = "@descuento";
                ParDescuento.SqlDbType = SqlDbType.Decimal;
                ParDescuento.Precision = 8;
                ParDescuento.Scale = 2;
                ParDescuento.Value = DDetalle.Descuento;
                sqlCmd.Parameters.Add(ParDescuento);

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

        public string Eliminar(DDetalleVenta DDetalle)
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
                sqlCmd.CommandText = "sp_eliminarDetalleVenta";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDetalle = new SqlParameter();
                ParIdDetalle.ParameterName = "@idDetalleVenta";
                ParIdDetalle.SqlDbType = SqlDbType.Int;
                ParIdDetalle.Value = DDetalle.IdDetalleVenta;
                sqlCmd.Parameters.Add(ParIdDetalle);

                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se eliminó el Registro";
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

        public string EditarDetalleVenta(DDetalleVenta DDetalle)
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
                sqlCmd.CommandText = "sp_editarDetalleVenta";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParidDetalle = new SqlParameter();
                ParidDetalle.ParameterName = "@idDetalle";
                ParidDetalle.SqlDbType = SqlDbType.Int;
                ParidDetalle.Value = DDetalle.IdDetalleVenta;
                sqlCmd.Parameters.Add(ParidDetalle);

                SqlParameter ParDescuento = new SqlParameter();
                ParDescuento.ParameterName = "@descuento";
                ParDescuento.SqlDbType = SqlDbType.Decimal;
                ParDescuento.Precision = 8;
                ParDescuento.Scale = 2;
                ParDescuento.Value = DDetalle.Descuento;
                sqlCmd.Parameters.Add(ParDescuento);

                SqlParameter ParImporte = new SqlParameter();
                ParImporte.ParameterName = "@importe";
                ParImporte.SqlDbType = SqlDbType.Decimal;
                ParImporte.Precision = 8;
                ParImporte.Scale = 2;
                ParImporte.Value = DDetalle.PrecioVenta;
                sqlCmd.Parameters.Add(ParImporte);


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

        public string EditarCantidadDetalleVenta(DDetalleVenta DDetalle)
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
                sqlCmd.CommandText = "sp_editarStockDetalleVenta";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParidDetalle = new SqlParameter();
                ParidDetalle.ParameterName = "@idDetalleVenta";
                ParidDetalle.SqlDbType = SqlDbType.Int;
                ParidDetalle.Value = DDetalle.IdDetalleVenta;
                sqlCmd.Parameters.Add(ParidDetalle);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = DDetalle.Cantidad;
                sqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@idProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Value = DDetalle.IdProducto;
                sqlCmd.Parameters.Add(ParIdProducto);


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


        public string InsertarDetalle_Compuesto(DDetalleVenta DetalleVenta, ref SqlConnection sqlCon, ref SqlTransaction sqlTran, DProducto Producto)
        {
            string rpta = "";
            try
            {
                //Comandos
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.Transaction = sqlTran;

                sqlCmd.CommandText = "sp_insertarDetalleVenta";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDetalleVenta = new SqlParameter();
                ParIdDetalleVenta.ParameterName = "@idDetalleVenta";
                ParIdDetalleVenta.SqlDbType = SqlDbType.Int;
                ParIdDetalleVenta.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdDetalleVenta);

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = DetalleVenta.IdVenta;
                sqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParidProducto = new SqlParameter();
                ParidProducto.ParameterName = "@idProducto";
                ParidProducto.SqlDbType = SqlDbType.Int;
                ParidProducto.Value = DetalleVenta.IdProducto;
                sqlCmd.Parameters.Add(ParidProducto);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = DetalleVenta.Cantidad;
                sqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParPrecioVenta = new SqlParameter();
                ParPrecioVenta.ParameterName = "@precioVenta";
                ParPrecioVenta.SqlDbType = SqlDbType.Decimal;
                ParPrecioVenta.Precision = 8;
                ParPrecioVenta.Scale = 2;
                ParPrecioVenta.Value = DetalleVenta.PrecioVenta;
                sqlCmd.Parameters.Add(ParPrecioVenta);

                SqlParameter ParDescuento = new SqlParameter();
                ParDescuento.ParameterName = "@descuento";
                ParDescuento.SqlDbType = SqlDbType.Decimal;
                ParDescuento.Precision = 8;
                ParDescuento.Scale = 2;
                ParDescuento.Value = DetalleVenta.Descuento;
                sqlCmd.Parameters.Add(ParDescuento);

                SqlParameter ParNota = new SqlParameter();
                ParNota.ParameterName = "@nota";
                ParNota.SqlDbType = SqlDbType.VarChar;
                ParNota.Size = 250;
                ParNota.Value = DetalleVenta.Nota;
                sqlCmd.Parameters.Add(ParNota);

                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@tipo";
                ParTipo.SqlDbType = SqlDbType.Char;
                ParCantidad.Value = "C";
                sqlCmd.Parameters.Add(ParTipo);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = DetalleVenta.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";

                if(rpta == "OK")
                {
                    rpta = Producto.EditarStock(Producto);
                }

                if (rpta.Equals("OK"))
                {
                    sqlTran.Commit();
                }
                else
                {
                    sqlTran.Rollback();
                }

                //sqlCmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }
        public string ActualizarStockProd_Anulada(DDetalleVenta DetalleVenta)
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
                sqlCmd.CommandText = "sp_actualizarStockProd_Anulado";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDetalleVenta = new SqlParameter();
                ParIdDetalleVenta.ParameterName = "@idDetalleVenta";
                ParIdDetalleVenta.SqlDbType = SqlDbType.Int;
                ParIdDetalleVenta.Value = DetalleVenta.IdDetalleVenta;
                sqlCmd.Parameters.Add(ParIdDetalleVenta);

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

        public DataTable mostrarIdDetalleVenta(int idVenta)
        {
            DataTable dtResultado = new DataTable("Venta");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarIdDetalleVenta";
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

        public string EditarStockProductoR(DDetalleVenta Venta)
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
                sqlCmd.CommandText = "sp_editarStockProductoR";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = Venta.Cantidad;
                sqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@idProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Value = Venta.IdProducto;
                sqlCmd.Parameters.Add(ParIdProducto);

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
