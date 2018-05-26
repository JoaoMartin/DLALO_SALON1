using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DMovimientoAlmacen
    {
        private int _IdMovimiento;
        private int _AlmacenDestino;
        private int _IdTipoMov;
        private int _IdTrabajador;
        private string _Entregado;
        private DateTime _Fecha;
        private string _Estado;
        private string _Tipo;
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

        public int AlmacenDestino
        {
            get
            {
                return _AlmacenDestino;
            }

            set
            {
                _AlmacenDestino = value;
            }
        }

        public int IdTipoMov
        {
            get
            {
                return _IdTipoMov;
            }

            set
            {
                _IdTipoMov = value;
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

        public string Entregado
        {
            get
            {
                return _Entregado;
            }

            set
            {
                _Entregado = value;
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

        public DMovimientoAlmacen() { }

        public DMovimientoAlmacen(int idMovimiento, int almacenDestino, int idTipoMov, int idTrabajador, string entregado, DateTime fecha, string estado, string tipo)
        {
            this.IdMovimiento = idMovimiento;
            this.AlmacenDestino = almacenDestino;
            this.IdTipoMov = IdTipoMov;
            this.IdTrabajador = idTrabajador;
            this.Entregado = entregado;
            this.Fecha = fecha;
            this.Estado = estado;
            this.Tipo = tipo;
        }

        public string Insertar(DMovimientoAlmacen Movimiento, List<DDetalleMovimientoAlmacen> DetalleMovimiento)
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

                sqlCmd.CommandText = "sp_insertarMovimientoAlmacen";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdMovimiento = new SqlParameter();
                ParIdMovimiento.ParameterName = "@idMovimiento";
                ParIdMovimiento.SqlDbType = SqlDbType.Int;
                ParIdMovimiento.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdMovimiento);

                SqlParameter ParAlmacenDestino = new SqlParameter();
                ParAlmacenDestino.ParameterName = "@almacenDestino";
                ParAlmacenDestino.SqlDbType = SqlDbType.Int;
                ParAlmacenDestino.Value = Movimiento.AlmacenDestino;
                sqlCmd.Parameters.Add(ParAlmacenDestino);

                SqlParameter ParIdTipoMov = new SqlParameter();
                ParIdTipoMov.ParameterName = "@idTipoMov";
                ParIdTipoMov.SqlDbType = SqlDbType.Int;
                ParIdTipoMov.Value = Movimiento.IdTipoMov;
                sqlCmd.Parameters.Add(ParIdTipoMov);

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName ="@idTrabajador";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Movimiento.IdTrabajador;
                sqlCmd.Parameters.Add(ParIdUsuario);

                SqlParameter ParEntregado = new SqlParameter();
                ParEntregado.ParameterName = "@entregado";
                ParEntregado.SqlDbType = SqlDbType.VarChar;
                ParEntregado.Size = 200;
                ParEntregado.Value = Movimiento.Entregado;
                sqlCmd.Parameters.Add(ParEntregado);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = Movimiento.Fecha;
                sqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = Movimiento.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@tipo";
                ParTipo.SqlDbType = SqlDbType.VarChar;
                ParTipo.Size = 10;
                ParTipo.Value = Movimiento.Tipo;
                sqlCmd.Parameters.Add(ParTipo);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingresó el Registro";

                if (rpta.Equals("OK"))
                {
                    this.IdMovimiento = Convert.ToInt32(sqlCmd.Parameters["@idMovimiento"].Value);
                    foreach (DDetalleMovimientoAlmacen det in DetalleMovimiento)
                    {
                        det.IdMovimiento = this.IdMovimiento;

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

        public DataTable mostrarMovimientoAlmacen(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dtResultado = new DataTable("MovimientoAlmacen");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarMovimientoAlmacen";
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

        public DataTable mostrarDetalleMovimiento(int idMovimiento)
        {
            DataTable dtResultado = new DataTable("DetalleMovimientoAlmacen");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarDetalleMovimientoAlmacen";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdMovimiento = new SqlParameter();
                ParIdMovimiento.ParameterName = "@idMovimientoAlmacen";
                ParIdMovimiento.SqlDbType = SqlDbType.Int;
                ParIdMovimiento.Value = idMovimiento;
                sqlCmd.Parameters.Add(ParIdMovimiento);

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
