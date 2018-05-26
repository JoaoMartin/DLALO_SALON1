using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DTrabajador
    {
        private int _IdTrabajador;
        private string _Nombre;
        private string _Apellidos;
        private string _TipoDoc;
        private string _NumDoc;
        private string _Sexo;
        private DateTime _FechaNac;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Estado;
        private int _IdTipoTrabajador;
        private string usuario;
        private string password;
        private string _TextoBuscar;

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

        public string Apellidos
        {
            get
            {
                return _Apellidos;
            }

            set
            {
                _Apellidos = value;
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

        public string Sexo
        {
            get
            {
                return _Sexo;
            }

            set
            {
                _Sexo = value;
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

        public int IdTipoTrabajador
        {
            get
            {
                return _IdTipoTrabajador;
            }

            set
            {
                _IdTipoTrabajador = value;
            }
        }

        public string Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
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

        public DTrabajador() { }

        public DTrabajador(int idTrabajador, string nombre, string apellidos, string tipoDoc, string numDoc, string sexo, DateTime fechaNac, string direccion, string telefono,
            string email, string estado, int idTipoTrabajador, string usuario, string password, string textoBuscar)
        {
            this.IdTrabajador = idTrabajador;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.TipoDoc = tipoDoc;
            this.NumDoc = numDoc;
            this.Sexo = sexo;
            this.FechaNac = fechaNac;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Estado = estado;
            this.IdTipoTrabajador = idTipoTrabajador;
            this.Usuario = usuario;
            this.Password = password;
            this.TextoBuscar = textoBuscar;
        }

        public string Insertar(DTrabajador Trabajador)
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
                sqlCmd.CommandText = "sp_insertarTrabajador";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idTrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 25;
                ParNombre.Value = Trabajador.Nombre;
                sqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidos = new SqlParameter();
                ParApellidos.ParameterName = "@aps";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 60;
                ParApellidos.Value = Trabajador.Apellidos;
                sqlCmd.Parameters.Add(ParApellidos);

                SqlParameter ParTipoDoc = new SqlParameter();
                ParTipoDoc.ParameterName = "@tipoDoc";
                ParTipoDoc.SqlDbType = SqlDbType.VarChar;
                ParTipoDoc.Size = 24;
                ParTipoDoc.Value = Trabajador.TipoDoc;
                sqlCmd.Parameters.Add(ParTipoDoc);

                SqlParameter ParNumDoc = new SqlParameter();
                ParNumDoc.ParameterName = "@numDoc";
                ParNumDoc.SqlDbType = SqlDbType.VarChar;
                ParNumDoc.Size = 15;
                ParNumDoc.Value = Trabajador.NumDoc;
                sqlCmd.Parameters.Add(ParNumDoc);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.Char;
                ParSexo.Size = 1;
                ParSexo.Value = Trabajador.Sexo;
                sqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParFechaNac = new SqlParameter();
                ParFechaNac.ParameterName = "@fechNac";
                ParFechaNac.SqlDbType = SqlDbType.Date;
                ParFechaNac.Value = Trabajador.FechaNac;
                sqlCmd.Parameters.Add(ParFechaNac);

                SqlParameter ParDir = new SqlParameter();
                ParDir.ParameterName = "@direccion";
                ParDir.SqlDbType = SqlDbType.VarChar;
                ParDir.Size = 150;
                ParDir.Value = Trabajador.Direccion;
                sqlCmd.Parameters.Add(ParDir);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 50;
                ParTelefono.Value = Trabajador.Telefono;
                sqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 30;
                ParEmail.Value = Trabajador.Email;
                sqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Char;
                ParEstado.Size = 1;
                ParEstado.Value = Trabajador.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParIdTipo = new SqlParameter();
                ParIdTipo.ParameterName = "@idTipoTrabajador";
                ParIdTipo.SqlDbType = SqlDbType.Int;
                ParIdTipo.Value = Trabajador.IdTipoTrabajador;
                sqlCmd.Parameters.Add(ParIdTipo);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Trabajador.Usuario;
                sqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 20;
                ParPassword.Value = Trabajador.Password;
                sqlCmd.Parameters.Add(ParPassword);

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

        public string Editar(DTrabajador Trabajador)
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
                sqlCmd.CommandText = "sp_editarTrabajador";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idTrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Trabajador.IdTrabajador;
                sqlCmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 25;
                ParNombre.Value = Trabajador.Nombre;
                sqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidos = new SqlParameter();
                ParApellidos.ParameterName = "@aps";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 60;
                ParApellidos.Value = Trabajador.Apellidos;
                sqlCmd.Parameters.Add(ParApellidos);

                SqlParameter ParTipoDoc = new SqlParameter();
                ParTipoDoc.ParameterName = "@tipoDoc";
                ParTipoDoc.SqlDbType = SqlDbType.VarChar;
                ParTipoDoc.Size = 24;
                ParTipoDoc.Value = Trabajador.TipoDoc;
                sqlCmd.Parameters.Add(ParTipoDoc);

                SqlParameter ParNumDoc = new SqlParameter();
                ParNumDoc.ParameterName = "@numDoc";
                ParNumDoc.SqlDbType = SqlDbType.VarChar;
                ParNumDoc.Size = 15;
                ParNumDoc.Value = Trabajador.NumDoc;
                sqlCmd.Parameters.Add(ParNumDoc);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.Char;
                ParSexo.Size = 1;
                ParSexo.Value = Trabajador.Sexo;
                sqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParFechaNac = new SqlParameter();
                ParFechaNac.ParameterName = "@fechNac";
                ParFechaNac.SqlDbType = SqlDbType.Date;
                ParFechaNac.Value = Trabajador.FechaNac;
                sqlCmd.Parameters.Add(ParFechaNac);

                SqlParameter ParDir = new SqlParameter();
                ParDir.ParameterName = "@direccion";
                ParDir.SqlDbType = SqlDbType.VarChar;
                ParDir.Size = 150;
                ParDir.Value = Trabajador.Direccion;
                sqlCmd.Parameters.Add(ParDir);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 50;
                ParTelefono.Value = Trabajador.Telefono;
                sqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 30;
                ParEmail.Value = Trabajador.Email;
                sqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Char;
                ParEstado.Size = 1;
                ParEstado.Value = Trabajador.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParIdTipo = new SqlParameter();
                ParIdTipo.ParameterName = "@idTipoTrabajador";
                ParIdTipo.SqlDbType = SqlDbType.Int;
                ParIdTipo.Value = Trabajador.IdTipoTrabajador;
                sqlCmd.Parameters.Add(ParIdTipo);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Trabajador.Usuario;
                sqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 20;
                ParPassword.Value = Trabajador.Password;
                sqlCmd.Parameters.Add(ParPassword);

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

        public string Eliminar(DTrabajador Trabajador)
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
                sqlCmd.CommandText = "sp_eliminarTrabajador";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTermino = new SqlParameter();
                ParIdTermino.ParameterName = "@idTrabajador";
                ParIdTermino.SqlDbType = SqlDbType.Int;
                ParIdTermino.Value = Trabajador.IdTrabajador;
                sqlCmd.Parameters.Add(ParIdTermino);

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
            DataTable dtResultado = new DataTable("Trabajador");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarTrabajador";
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

        public DataTable MostrarMesero()
        {
            DataTable dtResultado = new DataTable("Trabajador");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarTrabajadorMesero";
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

        public DataTable BuscarNombre(DTrabajador Trabajador)
        {
            DataTable dtResultado = new DataTable("Trabajador");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarTrabajadorNombre";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Trabajador.TextoBuscar;

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

        public DataTable BuscarApellidos(DTrabajador Trabajador)
        {
            DataTable dtResultado = new DataTable("Trabajador");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarTrabajadorApellido";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Trabajador.TextoBuscar;

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

        public DataTable BuscarDni(DTrabajador Trabajador)
        {
            DataTable dtResultado = new DataTable("Trabajador");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarTrabajadorDni";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Trabajador.TextoBuscar;

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

        public DataTable BuscarSexo(DTrabajador Trabajador)
        {
            DataTable dtResultado = new DataTable("Trabajador");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarTrabajadorSexo";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Trabajador.TextoBuscar;

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

        public DataTable BuscarTipoTrabajador(DTrabajador Trabajador)
        {
            DataTable dtResultado = new DataTable("Trabajador");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarTrabajadorTipoTrabajador";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Trabajador.TextoBuscar;

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

        public DataTable Login(DTrabajador Trabajador)
        {
            DataTable dtResultado = new DataTable("Trabajador");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_Login";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Trabajador.Usuario;
                sqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPass = new SqlParameter();
                ParPass.ParameterName = "@password";
                ParPass.SqlDbType = SqlDbType.VarChar;
                ParPass.Size = 20;
                ParPass.Value = Trabajador.Password;
                sqlCmd.Parameters.Add(ParPass);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable LoginMesero(DTrabajador Trabajador)
        {
            DataTable dtResultado = new DataTable("Trabajador");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_LoginMesero";
                sqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParPass = new SqlParameter();
                ParPass.ParameterName = "@password";
                ParPass.SqlDbType = SqlDbType.VarChar;
                ParPass.Size = 20;
                ParPass.Value = Trabajador.Password;
                sqlCmd.Parameters.Add(ParPass);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public string cambiarPass(DTrabajador Trabajador)
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
                sqlCmd.CommandText = "sp_cambiarPass";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idTrabajador";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Trabajador.IdTrabajador;
                sqlCmd.Parameters.Add(ParIdUsuario);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Trabajador.Usuario;
                sqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPass = new SqlParameter();
                ParPass.ParameterName = "@password";
                ParPass.SqlDbType = SqlDbType.VarChar;
                ParPass.Size = 20;
                ParPass.Value = Trabajador.Password;
                sqlCmd.Parameters.Add(ParPass);

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
    }
}
