using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;


namespace CapaNegocios
{
    public class NCaja_A
    {
        public static string Insertar(int idUsuario, string nombre, DateTime fecha, decimal monto, string estado, int nroCaja, decimal ventaTarjeta,  decimal montoEgreso, decimal montoOtros,
            decimal ventaEfectivo, decimal montoInicial, DateTime? fechaApertura)
        {
            DCaja_A Obj = new DCaja_A();
            Obj.IdUsuario = idUsuario;
            Obj.Nombre = nombre;
            Obj.Fecha = fecha;
            Obj.Monto = monto;
            Obj.Estado = estado;
            Obj.NroCaja = nroCaja;
            Obj.VentaTarjeta = ventaTarjeta;
            Obj.MontoEgreso = montoEgreso;
            Obj.MontoOtros = montoOtros;
            Obj.VentaEfectivo = ventaEfectivo;
            Obj.MontoInicial = montoInicial;
            Obj.FechaApertura = fechaApertura;
            return Obj.Insertar(Obj);
        }

        public static DataTable MostrarEstadoCaja(int nroCaja)
        {
            DCaja_A Obj = new DCaja_A();
            Obj.NroCaja = nroCaja;
            return Obj.MostrarEstado(Obj);
        }

        public static DataTable MostrarEstadoCajaMonto(int nroCaja)
        {
            DCaja_A Obj = new DCaja_A();
            Obj.NroCaja = nroCaja;
            return Obj.MostrarEstadoCajaMonto(Obj);
        }

        public static DataTable MostrarMontoCaja(int nroCaja)
        {
            DCaja_A Obj = new DCaja_A();
            Obj.NroCaja = nroCaja;
            return Obj.MostrarMonto(Obj);
        }

        public static DataTable MostrarCorteCaja(int nroCaja)
        {
            DCaja_A Obj = new DCaja_A();
            Obj.NroCaja = nroCaja;
            return Obj.MostrarCorteCaja(Obj);
        }

        public static DataTable MostrarIngresosEfectivo(int nroCaja, DateTime fechaApertura, DateTime fechaHoy)
        {
            DCaja_A Obj = new DCaja_A();
            Obj.NroCaja = nroCaja;
            return Obj.MostrarIngresosEfectivo(Obj,fechaApertura,fechaHoy);
        }

        public static DataTable MostrarIngresosTarjeta(int nroCaja, DateTime fechaApertura, DateTime fechaHoy)
        {
            DCaja_A Obj = new DCaja_A();
            Obj.NroCaja = nroCaja;
            return Obj.MostrarIngresosTarjeta(Obj, fechaApertura, fechaHoy);
        }

        public static DataTable MostrarEgresos(int nroCaja, DateTime fechaApertura, DateTime fechaHoy)
        {
            DCaja_A Obj = new DCaja_A();
            Obj.NroCaja = nroCaja;
            return Obj.MostrarEgresos(Obj, fechaApertura, fechaHoy);
        }

        public static DataTable MostrarVentasCaja(DateTime fechaApertura, DateTime fechaHoy)
        {
            return new DCaja_A().MostrarVentasCaja(fechaApertura, fechaHoy);
        }
        public static DataTable MostrarFechaCorte(int nroCaja)
        {
            DCaja_A Obj = new DCaja_A();
            Obj.NroCaja = nroCaja;
            return Obj.MostrarFechaCorte(Obj);
        }

        public static DataTable MostrarFechaCierre(int nroCaja)
        {
            DCaja_A Obj = new DCaja_A();
            Obj.NroCaja = nroCaja;
            return Obj.MostrarFechaCierreCaja(Obj);
        }

        public static DataTable reporteMovCaja(DateTime fechaInicio, DateTime fechaFin)
        {
            DCaja_A Obj = new DCaja_A();
            return Obj.reporteMovCaja(fechaInicio, fechaFin);
        }
    }
}
