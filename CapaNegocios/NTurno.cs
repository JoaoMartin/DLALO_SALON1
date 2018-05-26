using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NTurno
    {
        public static string Insertar(int idTrabajador, DateTime fecha, decimal monto, string estado, decimal montoTarjeta, decimal montoEgreso)
        {
            DTurno Obj = new DTurno();
            Obj.IdTrabajador = idTrabajador;
            Obj.Fecha = fecha;
            Obj.Monto = monto;
            Obj.Estado = estado;
            Obj.MontoTarjeta = montoTarjeta;
            Obj.MontoEgreso = montoEgreso;
            return Obj.Insertar(Obj);
        }
        public static DataTable MostrarEstadoTurno(int idTrabajador)
        {
            DTurno Obj = new DTurno();
            Obj.IdTrabajador = idTrabajador;
            return Obj.MostrarEstadoTurno(Obj);
        }

        public static DataTable MostrarMontoApertura(int idTrabajador)
        {
            DTurno Obj = new DTurno();
            Obj.IdTrabajador = idTrabajador;
            return Obj.MostrarMontoApertura(Obj);
        }

        public static DataTable MostrarIngresosEfectivoTurno(int nroCaja, DateTime fechaApertura, DateTime fechaHoy)
        {
            return new DTurno().MostrarIngresosEfectivoTurno(nroCaja, fechaApertura, fechaHoy);
        }

        public static DataTable MostrarIngresosTarjetaTurno(int nroCaja, DateTime fechaApertura, DateTime fechaHoy)
        {
            return new DTurno().MostrarIngresosTarjetaTurno(nroCaja, fechaApertura, fechaHoy);
        }

        public static DataTable MostrarEgresosTurno(int nroCaja, DateTime fechaApertura, DateTime fechaHoy)
        {
            return new DTurno().MostrarEgresosTurno(nroCaja, fechaApertura, fechaHoy);
        }

        public static DataTable MostrarVentasTurno( DateTime fechaApertura, DateTime fechaHoy)
        {
            return new DTurno().MostrarVentasTurno( fechaApertura, fechaHoy);
        }
    }
}
