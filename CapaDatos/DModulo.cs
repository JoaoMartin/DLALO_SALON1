using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DModulo
    {
        private int _IdModulo;
        private string _Nombre;
        private string _Estado;

        public int IdModulo
        {
            get
            {
                return _IdModulo;
            }

            set
            {
                _IdModulo = value;
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

        public DModulo() { }

        public DModulo(int idModulo, string nombre, string estado)
        {
            this.IdModulo = idModulo;
            this.Nombre = nombre;
            this.Estado = estado;
        }

        public DataTable Mostrar()
        {
            DataTable dtResultado = new DataTable("Modulo");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarModulo";
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

    }
}
