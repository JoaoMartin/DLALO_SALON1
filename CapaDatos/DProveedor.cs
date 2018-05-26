using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DProveedor
    {
        private int _IdProveedor;
        private string _RazonSocial;
        private string _TipoDoc;
        private string _NumDoc;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Estado;
        private string _TextoBuscar;

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

        public string RazonSocial
        {
            get
            {
                return _RazonSocial;
            }

            set
            {
                _RazonSocial = value;
            }
        }

        public string TipoDoc
        {
            get
            {
                return _TipoDoc;
            }

            set
            {
                _TipoDoc = value;
            }
        }

        public string NumDoc
        {
            get
            {
                return _NumDoc;
            }

            set
            {
                _NumDoc = value;
            }
        }

        public string Direccion
        {
            get
            {
                return _Direccion;
            }

            set
            {
                _Direccion = value;
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

        public string Email
        {
            get
            {
                return _Email;
            }

            set
            {
                _Email = value;
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

        public DProveedor() { }

        public DProveedor(int idProveedor, string razonSocial, string tipoDoc, string numDoc, string direccion, string telefono, string email, string estado, string textoBuscar)
        {
            this.IdProveedor = idProveedor;
            this.RazonSocial = razonSocial;
            this.TipoDoc = tipoDoc;
            this.NumDoc = numDoc;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Estado = estado;
            this.TextoBuscar = textoBuscar;
        }

        public string Insertar(DProveedor Proveedor)
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
                sqlCmd.CommandText = "sp_insertarProveedor";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idProveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdProveedor);

                SqlParameter ParRazonSocial = new SqlParameter();
                ParRazonSocial.ParameterName = "@razonSocial";
                ParRazonSocial.SqlDbType = SqlDbType.VarChar;
                ParRazonSocial.Size = 150;
                ParRazonSocial.Value = Proveedor.RazonSocial;
                sqlCmd.Parameters.Add(ParRazonSocial);

                SqlParameter ParTipoDoc = new SqlParameter();
                ParTipoDoc.ParameterName = "@tipoDoc";
                ParTipoDoc.SqlDbType = SqlDbType.VarChar;
                ParTipoDoc.Size = 9;
                ParTipoDoc.Value = Proveedor.TipoDoc;
                sqlCmd.Parameters.Add(ParTipoDoc);

                SqlParameter ParNumDoc = new SqlParameter();
                ParNumDoc.ParameterName = "@numDoc";
                ParNumDoc.SqlDbType = SqlDbType.VarChar;
                ParNumDoc.Size = 11;
                ParNumDoc.Value = Proveedor.NumDoc;
                sqlCmd.Parameters.Add(ParNumDoc);

                SqlParameter ParDir = new SqlParameter();
                ParDir.ParameterName = "@dirProv";
                ParDir.SqlDbType = SqlDbType.VarChar;
                ParDir.Size = 100;
                ParDir.Value = Proveedor.Direccion;
                sqlCmd.Parameters.Add(ParDir);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telProv";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 30;
                ParTelefono.Value = Proveedor.Telefono;
                sqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@emailProv";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Proveedor.Email;
                sqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParEstProveedor = new SqlParameter();
                ParEstProveedor.ParameterName = "@estProv";
                ParEstProveedor.SqlDbType = SqlDbType.Char;
                ParEstProveedor.Size = 1;
                ParEstProveedor.Value = Proveedor.Estado;
                sqlCmd.Parameters.Add(ParEstProveedor);

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

        public string Editar(DProveedor Proveedor)
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
                sqlCmd.CommandText = "sp_editarProveedor";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idProveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Proveedor.IdProveedor;
                sqlCmd.Parameters.Add(ParIdProveedor);

                SqlParameter ParRazonSocial = new SqlParameter();
                ParRazonSocial.ParameterName = "@razonSocial";
                ParRazonSocial.SqlDbType = SqlDbType.VarChar;
                ParRazonSocial.Size = 150;
                ParRazonSocial.Value = Proveedor.RazonSocial;
                sqlCmd.Parameters.Add(ParRazonSocial);

                SqlParameter ParTipoDoc = new SqlParameter();
                ParTipoDoc.ParameterName = "@tipoDoc";
                ParTipoDoc.SqlDbType = SqlDbType.VarChar;
                ParTipoDoc.Size = 9;
                ParTipoDoc.Value = Proveedor.TipoDoc;
                sqlCmd.Parameters.Add(ParTipoDoc);

                SqlParameter ParNumDoc = new SqlParameter();
                ParNumDoc.ParameterName = "@numDoc";
                ParNumDoc.SqlDbType = SqlDbType.VarChar;
                ParNumDoc.Size = 11;
                ParNumDoc.Value = Proveedor.NumDoc;
                sqlCmd.Parameters.Add(ParNumDoc);

                SqlParameter ParDir = new SqlParameter();
                ParDir.ParameterName = "@dirProv";
                ParDir.SqlDbType = SqlDbType.VarChar;
                ParDir.Size = 100;
                ParDir.Value = Proveedor.Direccion;
                sqlCmd.Parameters.Add(ParDir);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telProv";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 30;
                ParTelefono.Value = Proveedor.Telefono;
                sqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@emailProv";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Proveedor.Email;
                sqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParEstProveedor = new SqlParameter();
                ParEstProveedor.ParameterName = "@estProv";
                ParEstProveedor.SqlDbType = SqlDbType.Char;
                ParEstProveedor.Size = 1;
                ParEstProveedor.Value = Proveedor.Estado;
                sqlCmd.Parameters.Add(ParEstProveedor);

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

        public string Eliminar(DProveedor Proveedor)
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
                sqlCmd.CommandText = "sp_eliminarProveedor";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProveedor= new SqlParameter();
                ParIdProveedor.ParameterName = "@idProveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Proveedor.IdProveedor;
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
            DataTable dtResultado = new DataTable("Proveedor");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarProveedor";
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

        public DataTable BuscarRazonSocial(DProveedor Proveedor)
        {
            DataTable dtResultado = new DataTable("Proveedor");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarProveedorRazonSocial";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Proveedor.TextoBuscar;

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

        public DataTable BuscarRuc(DProveedor Proveedor)
        {
            DataTable dtResultado = new DataTable("Proveedor");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarProveedorRuc";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Proveedor.TextoBuscar;

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

        public DataTable BuscarCodigo(DProveedor Proveedor)
        {
            DataTable dtResultado = new DataTable("Proveedor");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarProveedorCodigo";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Proveedor.TextoBuscar;

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
