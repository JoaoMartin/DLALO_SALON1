using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCliente
    {
        private int _IdCliente;
        private string _Nombre;
        private DateTime _FechaNac;
        private string _TipoDoc;
        private string _NroDoc;
        private string _Direccion;
        private string _Email;
        private string _Telefono;
        private string _TextoBuscar;

        public int IdCliente
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

        public DateTime FechaNac
        {
            get
            {
                return _FechaNac;
            }

            set
            {
                _FechaNac = value;
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

        public string NroDoc
        {
            get
            {
                return _NroDoc;
            }

            set
            {
                _NroDoc = value;
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

        public DCliente() { }

        public DCliente(int idCliente, string nombre, DateTime fechaNac, string tipoDoc, string nroDoc, string direccion, string email, string telefono, string textoBuscar)
        {
            this.IdCliente = idCliente;
            this.Nombre = nombre;
            this.FechaNac = fechaNac;
            this.TipoDoc = tipoDoc;
            this.NroDoc = nroDoc;
            this.Direccion = direccion;
            this.Email = email;
            this.Telefono = telefono;
            this.TextoBuscar = textoBuscar;
        }

        public string Insertar(DCliente Cliente)
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
                sqlCmd.CommandText = "sp_insertarCliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idCliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 100;
                ParNombre.Value = Cliente.Nombre;
                sqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParFechaNac = new SqlParameter();
                ParFechaNac.ParameterName = "@fechaNac";
                ParFechaNac.SqlDbType = SqlDbType.Date;
                ParFechaNac.Value = Cliente.FechaNac;
                sqlCmd.Parameters.Add(ParFechaNac);

                SqlParameter ParTipoDoc = new SqlParameter();
                ParTipoDoc.ParameterName = "@tipoDoc";
                ParTipoDoc.SqlDbType = SqlDbType.VarChar;
                ParTipoDoc.Size = 10;
                ParTipoDoc.Value = Cliente.TipoDoc;
                sqlCmd.Parameters.Add(ParTipoDoc);

                SqlParameter ParNumDoc = new SqlParameter();
                ParNumDoc.ParameterName = "@nroDoc";
                ParNumDoc.SqlDbType = SqlDbType.VarChar;
                ParNumDoc.Size = 11;
                ParNumDoc.Value = Cliente.NroDoc;
                sqlCmd.Parameters.Add(ParNumDoc);

                SqlParameter ParDir = new SqlParameter();
                ParDir.ParameterName = "@direccion";
                ParDir.SqlDbType = SqlDbType.VarChar;
                ParDir.Size = 100;
                ParDir.Value = Cliente.Direccion;
                sqlCmd.Parameters.Add(ParDir);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Cliente.Email;
                sqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 30;
                ParTelefono.Value = Cliente.Telefono;
                sqlCmd.Parameters.Add(ParTelefono);

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

        public string Editar(DCliente Cliente)
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
                sqlCmd.CommandText = "sp_editarCliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idCliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Cliente.IdCliente;
                sqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 100;
                ParNombre.Value = Cliente.Nombre;
                sqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParFechaNac = new SqlParameter();
                ParFechaNac.ParameterName = "@fechaNac";
                ParFechaNac.SqlDbType = SqlDbType.Date;
                ParFechaNac.Value = Cliente.FechaNac;
                sqlCmd.Parameters.Add(ParFechaNac);

                SqlParameter ParTipoDoc = new SqlParameter();
                ParTipoDoc.ParameterName = "@tipoDoc";
                ParTipoDoc.SqlDbType = SqlDbType.VarChar;
                ParTipoDoc.Size = 10;
                ParTipoDoc.Value = Cliente.TipoDoc;
                sqlCmd.Parameters.Add(ParTipoDoc);

                SqlParameter ParNumDoc = new SqlParameter();
                ParNumDoc.ParameterName = "@nroDoc";
                ParNumDoc.SqlDbType = SqlDbType.VarChar;
                ParNumDoc.Size = 11;
                ParNumDoc.Value = Cliente.NroDoc;
                sqlCmd.Parameters.Add(ParNumDoc);

                SqlParameter ParDir = new SqlParameter();
                ParDir.ParameterName = "@direccion";
                ParDir.SqlDbType = SqlDbType.VarChar;
                ParDir.Size = 100;
                ParDir.Value = Cliente.Direccion;
                sqlCmd.Parameters.Add(ParDir);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Cliente.Email;
                sqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 30;
                ParTelefono.Value = Cliente.Telefono;
                sqlCmd.Parameters.Add(ParTelefono);

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

        public DataTable Mostrar()
        {
            DataTable dtResultado = new DataTable("Cliente");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarCliente";
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

        public DataTable Buscar(DCliente Cliente)
        {
            DataTable dtResultado = new DataTable("Cliente");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarCliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Cliente.TextoBuscar;

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


        public DataTable BuscarDni(DCliente Cliente)
        {
            DataTable dtResultado = new DataTable("Cliente");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarClienteDni";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Cliente.TextoBuscar;

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

        public DataTable mostrarClienteVenta(DCliente Cliente)
        {
            DataTable dtResultado = new DataTable("Cliente");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarClienteVenta";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNroDoc = new SqlParameter();
                ParNroDoc.ParameterName = "@nroDcto";
                ParNroDoc.SqlDbType = SqlDbType.VarChar;
                ParNroDoc.Size = 11;
                ParNroDoc.Value = Cliente.NroDoc;
                sqlCmd.Parameters.Add(ParNroDoc);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public string InsertarVenta(DCliente Cliente)
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
                sqlCmd.CommandText = "sp_insertarCliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idCliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 100;
                ParNombre.Value = Cliente.Nombre;
                sqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParFechaNac = new SqlParameter();
                ParFechaNac.ParameterName = "@fechaNac";
                ParFechaNac.SqlDbType = SqlDbType.Date;
                ParFechaNac.Value = Cliente.FechaNac;
                sqlCmd.Parameters.Add(ParFechaNac);

                SqlParameter ParTipoDoc = new SqlParameter();
                ParTipoDoc.ParameterName = "@tipoDoc";
                ParTipoDoc.SqlDbType = SqlDbType.VarChar;
                ParTipoDoc.Size = 10;
                ParTipoDoc.Value = Cliente.TipoDoc;
                sqlCmd.Parameters.Add(ParTipoDoc);

                SqlParameter ParNumDoc = new SqlParameter();
                ParNumDoc.ParameterName = "@nroDoc";
                ParNumDoc.SqlDbType = SqlDbType.VarChar;
                ParNumDoc.Size = 11;
                ParNumDoc.Value = Cliente.NroDoc;
                sqlCmd.Parameters.Add(ParNumDoc);

                SqlParameter ParDir = new SqlParameter();
                ParDir.ParameterName = "@direccion";
                ParDir.SqlDbType = SqlDbType.VarChar;
                ParDir.Size = 100;
                ParDir.Value = Cliente.Direccion;
                sqlCmd.Parameters.Add(ParDir);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Cliente.Email;
                sqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 30;
                ParTelefono.Value = Cliente.Telefono;
                sqlCmd.Parameters.Add(ParTelefono);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingresó el Registro";
                if(rpta == "OK")
                {
                    this.IdCliente = Convert.ToInt32(sqlCmd.Parameters["@idCliente"].Value);
                    rpta = IdCliente.ToString();
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
    }
}

