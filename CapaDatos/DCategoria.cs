using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCategoria
    {
        private int _IdCategoria;
        private string _Nombre;
        private string _Descripcion;
        private string _Estado;
        private string _TextoBuscar;
        private int _IdProducto;
        private int _Orden;
        public int IdCategoria
        {
            get
            {
                return _IdCategoria;
            }

            set
            {
                _IdCategoria = value;
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

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }

            set
            {
                _Descripcion = value;
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

        public int Orden
        {
            get
            {
                return _Orden;
            }

            set
            {
                _Orden = value;
            }
        }

        public DCategoria() { }

        public DCategoria(int idCategoria, string nombreCategoria, string descrCategoria, string estCategoria, string textoBuscar,int orden)
        {
            this.IdCategoria = idCategoria;
            this.Nombre = nombreCategoria;
            this.Descripcion = descrCategoria;
            this.Estado = estCategoria;
            this.TextoBuscar = textoBuscar;
            this.Orden = orden;
        }

        public string Insertar(DCategoria Categoria)
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
                sqlCmd.CommandText = "sp_insertarCategoria";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idCategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdCategoria);

                SqlParameter ParNomCategoria = new SqlParameter();
                ParNomCategoria.ParameterName = "@nomCategoria";
                ParNomCategoria.SqlDbType = SqlDbType.VarChar;
                ParNomCategoria.Size = 50;
                ParNomCategoria.Value = Categoria.Nombre;
                sqlCmd.Parameters.Add(ParNomCategoria);

                SqlParameter ParDescCategoria = new SqlParameter();
                ParDescCategoria.ParameterName = "@descrCategoria";
                ParDescCategoria.SqlDbType = SqlDbType.VarChar;
                ParDescCategoria.Size = 256;
                ParDescCategoria.Value = Categoria.Descripcion;
                sqlCmd.Parameters.Add(ParDescCategoria);

                SqlParameter ParEstCategoria = new SqlParameter();
                ParEstCategoria.ParameterName = "@estCategoria";
                ParEstCategoria.SqlDbType = SqlDbType.Char;
                ParEstCategoria.Size = 1;
                ParEstCategoria.Value = Categoria.Estado;
                sqlCmd.Parameters.Add(ParEstCategoria);

                SqlParameter ParOrden = new SqlParameter();
                ParOrden.ParameterName = "@orden";
                ParOrden.SqlDbType = SqlDbType.Int;
                ParOrden.Value = Categoria.Orden; ;
                sqlCmd.Parameters.Add(ParOrden);

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

        public string Editar(DCategoria Categoria)
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
                sqlCmd.CommandText = "sp_editarCategoria";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idCategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Categoria.IdCategoria;
                sqlCmd.Parameters.Add(ParIdCategoria);

                SqlParameter ParNomCategoria = new SqlParameter();
                ParNomCategoria.ParameterName = "@nomCategoria";
                ParNomCategoria.SqlDbType = SqlDbType.VarChar;
                ParNomCategoria.Size = 50;
                ParNomCategoria.Value = Categoria.Nombre;
                sqlCmd.Parameters.Add(ParNomCategoria);

                SqlParameter ParDescCategoria = new SqlParameter();
                ParDescCategoria.ParameterName = "@descrCategoria";
                ParDescCategoria.SqlDbType = SqlDbType.VarChar;
                ParDescCategoria.Size = 256;
                ParDescCategoria.Value = Categoria.Descripcion;
                sqlCmd.Parameters.Add(ParDescCategoria);

                SqlParameter ParEstCategoria = new SqlParameter();
                ParEstCategoria.ParameterName = "@estCategoria";
                ParEstCategoria.SqlDbType = SqlDbType.Char;
                ParEstCategoria.Size = 1;
                ParEstCategoria.Value = Categoria.Estado;
                sqlCmd.Parameters.Add(ParEstCategoria);

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

        public string Eliminar(DCategoria Categoria)
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
                sqlCmd.CommandText = "sp_eliminarCategoria";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idCategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Categoria.IdCategoria;
                sqlCmd.Parameters.Add(ParIdCategoria);

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
            DataTable dtResultado = new DataTable("Categoria");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarCategoria";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch(Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable MostrarVenta()
        {
            DataTable dtResultado = new DataTable("Categoria");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarCategoriaVenta";
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

        public DataTable MostrarOrdenCat()
        {
            DataTable dtResultado = new DataTable("Categoria");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarOrdenCategoria";
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

        public DataTable Buscar(DCategoria Categoria)
        {
            DataTable dtResultado = new DataTable("Categoria");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarCategoria";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Categoria.TextoBuscar;

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

        public DataTable mostrarCategoriaCompuesto()
        {
            DataTable dtResultado = new DataTable("Categoria");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarCategoriaCompuesto";
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

        public DataTable mostrarCategoriaProducto(DCategoria Categoria)
        {
            DataTable dtResultado = new DataTable("Categoria");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarCategoriaProducto";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@idProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Value = Categoria.IdProducto;

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

    }
}
