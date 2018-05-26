using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NCaja
    {
        public static string Insertar(int idUsuario, string nroCaja, string tipoMov, decimal monto, string descripcion, string tipoMonto)
        {
            DCaja Obj = new DCaja();
            Obj.IdUsuario = idUsuario;
            Obj.NroCaja = nroCaja;
            Obj.TipoMovCaja = tipoMov;
            Obj.Monto = monto;
            Obj.Descripcion = descripcion;
            Obj.TipoMonto = tipoMonto;
            return Obj.Insertar(Obj);
        }

        public static DataTable mostrarMovimientoCaja(DateTime fechaInicio, DateTime fechaFin)
        {
            DCaja Obj = new DCaja();
            return Obj.movimientoCaja(fechaInicio, fechaFin);
        }
    }
}
