using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DInsumo
    {
        private int _IdInsumo;
        private int _IdUnidadMedida;
        private string _Nombre;
        private decimal _Costo;
        private decimal _Stock;
        private decimal _StockMinimo;
        private string _Estado;
        private string _TextoBuscar;

        public int IdInsumo
        {
            get
            {
                return _IdInsumo;
            }

            set
            {
                _IdInsumo = value;
            }
        }

        public int IdUnidadMedida
        {
            get
            {
                return _IdUnidadMedida;
            }

            set
            {
                _IdUnidadMedida = value;
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

        public decimal Costo
        {
            get
            {
                return _Costo;
            }

            set
            {
                _Costo = value;
            }
        }

        public decimal Stock
        {
            get
            {
                return _Stock;
            }

            set
            {
                _Stock = value;
            }
        }

        public decimal StockMinimo
        {
            get
            {
                return _StockMinimo;
            }

            set
            {
                _StockMinimo = value;
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

        public DInsumo() { }

        public DInsumo(int idInsumo, int idUnidadMedida, string nombre, decimal costo, decimal stock, decimal stockMinimo, string estado, string textoBuscar)
        {
            this.IdInsumo = idInsumo;
            this.IdUnidadMedida = idUnidadMedida;
            this.Nombre = nombre;
            this.Costo = costo;
            this.Stock = stock;
            this.StockMinimo = stockMinimo;
            this.Estado = estado;
            this.TextoBuscar = textoBuscar;
        }

        public string Insertar(DInsumo Insumo)
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
                sqlCmd.CommandText = "sp_insertarInsumo";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdInsumo = new SqlParameter();
                ParIdInsumo.ParameterName = "@idInsumo";
                ParIdInsumo.SqlDbType = SqlDbType.Int;
                ParIdInsumo.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdInsumo);

                SqlParameter ParIdUnidadMedida = new SqlParameter();
                ParIdUnidadMedida.ParameterName = "@idUnidadMedida";
                ParIdUnidadMedida.SqlDbType = SqlDbType.Int;
                ParIdUnidadMedida.Value = Insumo.IdUnidadMedida;
                sqlCmd.Parameters.Add(ParIdUnidadMedida);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nomInsumo";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 200;
                ParNombre.Value = Insumo.Nombre;
                sqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParCosto = new SqlParameter();
                ParCosto.ParameterName = "@costo";
                ParCosto.SqlDbType = SqlDbType.Decimal;
                ParCosto.Precision = 8;
                ParCosto.Scale = 2;
                ParCosto.Value = Insumo.Costo;
                sqlCmd.Parameters.Add(ParCosto);

                SqlParameter ParStock = new SqlParameter();
                ParStock.ParameterName = "@stock";
                ParStock.SqlDbType = SqlDbType.Decimal;
                ParStock.Precision = 9;
                ParStock.Scale = 3;
                ParStock.Value = Insumo.Stock;
                sqlCmd.Parameters.Add(ParStock);

                SqlParameter ParStockMinimo = new SqlParameter();
                ParStockMinimo.ParameterName = "@stockMinimo";
                ParStockMinimo.SqlDbType = SqlDbType.Decimal;
                ParStockMinimo.Precision = 9;
                ParStockMinimo.Scale = 3;
                ParStockMinimo.Value = Insumo.StockMinimo;
                sqlCmd.Parameters.Add(ParStockMinimo);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estInsumo";
                ParEstado.SqlDbType = SqlDbType.Char;
                ParEstado.Size = 1;
                ParEstado.Value = Insumo.Estado;
                sqlCmd.Parameters.Add(ParEstado);

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

        public string Editar(DInsumo Insumo)
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
                sqlCmd.CommandText = "sp_editarInsumo";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdInsumo = new SqlParameter();
                ParIdInsumo.ParameterName = "@idInsumo";
                ParIdInsumo.SqlDbType = SqlDbType.Int;
                ParIdInsumo.Value = Insumo.IdInsumo;
                sqlCmd.Parameters.Add(ParIdInsumo);

                SqlParameter ParIdUnidadMedida = new SqlParameter();
                ParIdUnidadMedida.ParameterName = "@idUnidadMedida";
                ParIdUnidadMedida.SqlDbType = SqlDbType.Int;
                ParIdUnidadMedida.Value = Insumo.IdUnidadMedida;
                sqlCmd.Parameters.Add(ParIdUnidadMedida);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nomInsumo";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 200;
                ParNombre.Value = Insumo.Nombre;
                sqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParCosto = new SqlParameter();
                ParCosto.ParameterName = "@costo";
                ParCosto.SqlDbType = SqlDbType.Decimal;
                ParCosto.Precision = 8;
                ParCosto.Scale = 2;
                ParCosto.Value = Insumo.Costo;
                sqlCmd.Parameters.Add(ParCosto);

                SqlParameter ParStock = new SqlParameter();
                ParStock.ParameterName = "@stock";
                ParStock.SqlDbType = SqlDbType.Decimal;
                ParStock.Precision = 9;
                ParStock.Scale = 3;
                ParStock.Value = Insumo.Stock;
                sqlCmd.Parameters.Add(ParStock);

                SqlParameter ParStockMinimo = new SqlParameter();
                ParStockMinimo.ParameterName = "@stockMinimo";
                ParStockMinimo.SqlDbType = SqlDbType.Decimal;
                ParStockMinimo.Precision = 9;
                ParStockMinimo.Scale = 3;
                ParStockMinimo.Value = Insumo.StockMinimo;
                sqlCmd.Parameters.Add(ParStockMinimo);

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

        public string Eliminar(DInsumo Insumo)
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
                sqlCmd.CommandText = "sp_eliminarInsumo";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idInsumo";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Insumo.IdInsumo;
                sqlCmd.Parameters.Add(ParIdProveedor);

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

        public DataTable Mostrar()
        {
            DataTable dtResultado = new DataTable("Insumo");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarInsumo";
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

        public DataTable Buscar(DInsumo Insumo)
        {
            DataTable dtResultado = new DataTable("Insumo");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarInsumo";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Insumo.TextoBuscar;

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

        public string EditarStock(int idInsumo, decimal cantidad)
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
                sqlCmd.CommandText = "sp_editarStockInsumo";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdInsumo = new SqlParameter();
                ParIdInsumo.ParameterName = "@idInsumo";
                ParIdInsumo.SqlDbType = SqlDbType.Int;
                ParIdInsumo.Value = idInsumo;
                sqlCmd.Parameters.Add(ParIdInsumo);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Decimal;
                ParCantidad.Precision = 9;
                ParCantidad.Scale = 3;
                ParCantidad.Value = cantidad;
                sqlCmd.Parameters.Add(ParCantidad);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se editó el Stock Insumos";
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

        public DataTable MostrarStockInsumosAlmacen()
        {
            DataTable dtResultado = new DataTable("Insumo");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarStockInsumo_Almacen";
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
        public DataTable BuscarInsumo_Almacen(DInsumo Insumo)
        {
            DataTable dtResultado = new DataTable("Insumo");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarInsumo_Almacen";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Insumo.TextoBuscar;

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

