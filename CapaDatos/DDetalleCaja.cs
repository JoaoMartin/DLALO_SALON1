using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalleCaja
    {
        private int _IdDetalleCaja;
        private int _IdCaja;
        private int _CantDiezCen;
        private int _CantVeinteCen;
        private int _CantCincuentaCen;
        private int _CantUnSol;
        private int _CantDosSoles;
        private int _CantCincoSoles;
        private int _CantDiezSoles;
        private int _CantVeinteSoles;
        private int _CantCincuentaSoles;
        private int _CantCienSoles;
        private int _CantDoscientosSoles;

        public int IdDetalleCaja
        {
            get
            {
                return _IdDetalleCaja;
            }

            set
            {
                _IdDetalleCaja = value;
            }
        }

        public int IdCaja
        {
            get
            {
                return _IdCaja;
            }

            set
            {
                _IdCaja = value;
            }
        }

        public int CantDiezCen
        {
            get
            {
                return _CantDiezCen;
            }

            set
            {
                _CantDiezCen = value;
            }
        }

        public int CantVeinteCen
        {
            get
            {
                return _CantVeinteCen;
            }

            set
            {
                _CantVeinteCen = value;
            }
        }

        public int CantCincuentaCen
        {
            get
            {
                return _CantCincuentaCen;
            }

            set
            {
                _CantCincuentaCen = value;
            }
        }

        public int CantUnSol
        {
            get
            {
                return _CantUnSol;
            }

            set
            {
                _CantUnSol = value;
            }
        }

        public int CantDosSoles
        {
            get
            {
                return _CantDosSoles;
            }

            set
            {
                _CantDosSoles = value;
            }
        }

        public int CantCincoSoles
        {
            get
            {
                return _CantCincoSoles;
            }

            set
            {
                _CantCincoSoles = value;
            }
        }

        public int CantDiezSoles
        {
            get
            {
                return _CantDiezSoles;
            }

            set
            {
                _CantDiezSoles = value;
            }
        }

        public int CantVeinteSoles
        {
            get
            {
                return _CantVeinteSoles;
            }

            set
            {
                _CantVeinteSoles = value;
            }
        }

        public int CantCincuentaSoles
        {
            get
            {
                return _CantCincuentaSoles;
            }

            set
            {
                _CantCincuentaSoles = value;
            }
        }

        public int CantCienSoles
        {
            get
            {
                return _CantCienSoles;
            }

            set
            {
                _CantCienSoles = value;
            }
        }

        public int CantDoscientosSoles
        {
            get
            {
                return _CantDoscientosSoles;
            }

            set
            {
                _CantDoscientosSoles = value;
            }
        }

        public DDetalleCaja() { }

        public DDetalleCaja(int idDetalleCaja, int idCaja, int cantDiezCen, int cantVeinteCen, int cantCincuentaCen, int cantUnSol,
            int cantDosSoles, int cantCincoSoles, int cantDiezSoles, int cantVeinteSoles, int cantCincuentaSoles, int cantCienSoles,
            int cantDoscientosSoles)
        {
            this.IdDetalleCaja = idDetalleCaja;
            this.IdCaja = idCaja;
            this.CantDiezCen = cantDiezCen;
            this.CantVeinteCen = cantVeinteCen;
            this.CantCincuentaCen = cantCincuentaCen;
            this.CantUnSol = cantUnSol;
            this.CantDosSoles = cantDosSoles;
            this.CantCincoSoles = cantCincoSoles;
            this.CantDiezSoles = cantDiezSoles;
            this.CantVeinteSoles = cantVeinteSoles;
            this.CantCincoSoles = cantCincuentaSoles;
            this.CantCienSoles = cantCienSoles;
            this.CantDoscientosSoles = cantDoscientosSoles;
        }

        public string Insertar(DDetalleCaja DetalleCaja)
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
                sqlCmd.CommandText = "sp_insertarDetalleCaja";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDetalleCaja = new SqlParameter();
                ParIdDetalleCaja.ParameterName = "@idDetalleCaja";
                ParIdDetalleCaja.SqlDbType = SqlDbType.Int;
                ParIdDetalleCaja.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdDetalleCaja);

                SqlParameter ParIdCaja = new SqlParameter();
                ParIdCaja.ParameterName = "@idCaja";
                ParIdCaja.SqlDbType = SqlDbType.Int;
                ParIdCaja.Value = DetalleCaja.IdCaja;
                sqlCmd.Parameters.Add(ParIdCaja);

                SqlParameter ParDiezCen = new SqlParameter();
                ParDiezCen.ParameterName = "@cantDiezCen";
                ParDiezCen.SqlDbType = SqlDbType.Int;
                ParDiezCen.Value = DetalleCaja.CantDiezCen;
                sqlCmd.Parameters.Add(ParDiezCen);

                SqlParameter ParVeinteCen = new SqlParameter();
                ParVeinteCen.ParameterName = "@cantVeinteCen";
                ParVeinteCen.SqlDbType = SqlDbType.Int;
                ParVeinteCen.Value = DetalleCaja.CantVeinteCen;
                sqlCmd.Parameters.Add(ParVeinteCen);

                SqlParameter ParCincuenaCen = new SqlParameter();
                ParCincuenaCen.ParameterName = "@cantCincuentaCen";
                ParCincuenaCen.SqlDbType = SqlDbType.Int;
                ParCincuenaCen.Value = DetalleCaja.CantCincuentaCen;
                sqlCmd.Parameters.Add(ParCincuenaCen);

                SqlParameter ParUnSol = new SqlParameter();
                ParUnSol.ParameterName = "@cantUnSol";
                ParUnSol.SqlDbType = SqlDbType.Int;
                ParUnSol.Value = DetalleCaja.CantUnSol;
                sqlCmd.Parameters.Add(ParUnSol);

                SqlParameter ParDosSoles = new SqlParameter();
                ParDosSoles.ParameterName = "@cantDosSoles";
                ParDosSoles.SqlDbType = SqlDbType.Int;
                ParDosSoles.Value = DetalleCaja.CantDosSoles;
                sqlCmd.Parameters.Add(ParDosSoles);

                SqlParameter ParCincoSoles = new SqlParameter();
                ParCincoSoles.ParameterName = "@cantCincoSoles";
                ParCincoSoles.SqlDbType = SqlDbType.Int;
                ParCincoSoles.Value = DetalleCaja.CantCincoSoles;
                sqlCmd.Parameters.Add(ParCincoSoles);

                SqlParameter ParDiesZoles = new SqlParameter();
                ParDiesZoles.ParameterName = "@cantDiezSoles";
                ParDiesZoles.SqlDbType = SqlDbType.Int;
                ParDiesZoles.Value = DetalleCaja.CantDiezSoles;
                sqlCmd.Parameters.Add(ParDiesZoles);

                SqlParameter ParVeinteSoles = new SqlParameter();
                ParVeinteSoles.ParameterName = "@cantVeinteSoles";
                ParVeinteSoles.SqlDbType = SqlDbType.Int;
                ParVeinteSoles.Value = DetalleCaja.CantVeinteSoles;
                sqlCmd.Parameters.Add(ParVeinteSoles);

                SqlParameter ParCincuentaSoles = new SqlParameter();
                ParCincuentaSoles.ParameterName = "@cantCincuentaSoles";
                ParCincuentaSoles.SqlDbType = SqlDbType.Int;
                ParCincuentaSoles.Value = DetalleCaja.CantCincuentaSoles;
                sqlCmd.Parameters.Add(ParCincuentaSoles);

                SqlParameter ParCienSoles = new SqlParameter();
                ParCienSoles.ParameterName = "@cantCienSoles";
                ParCienSoles.SqlDbType = SqlDbType.Int;
                ParCienSoles.Value = DetalleCaja.CantCienSoles;
                sqlCmd.Parameters.Add(ParCienSoles);

                SqlParameter ParDoscSoles = new SqlParameter();
                ParDoscSoles.ParameterName = "@cantDoscientosSoles";
                ParDoscSoles.SqlDbType = SqlDbType.Int;
                ParDoscSoles.Value = DetalleCaja.CantDoscientosSoles;
                sqlCmd.Parameters.Add(ParDoscSoles);

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
    }
}
