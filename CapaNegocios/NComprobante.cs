using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;


namespace CapaNegocios
{
    public class NComprobante
    {
        public static string Insertar(string tipoComprobante, int serie,decimal igv, DateTime fecha, int idVenta, string estado, int? idCliente, decimal monto, decimal efectivo, decimal tarjeta, decimal redondeo, string formaPago, decimal vuelto)
        {
            DComprobante Obj = new DComprobante();
            Obj.TipoComprobante = tipoComprobante;
            Obj.Serie = serie;
            Obj.Igv = igv;
            Obj.Fecha = fecha;
            Obj.IdVenta = idVenta;
            Obj.Estado = estado;
            Obj.IdCliente = idCliente;
            Obj.Monto = monto;
            Obj.Efectivo = efectivo;
            Obj.Tarjeta = tarjeta;
            Obj.Redondeo = redondeo;
            Obj.FormaPago = formaPago;
            Obj.Vuelto = vuelto;
            return Obj.Insertar(Obj);
        }

        public static DataTable mostrarNroComprobante(int idVenta, string tipo)
        {
            DComprobante  Obj = new DComprobante();
            Obj.IdVenta = idVenta;
            Obj.TipoComprobante = tipo;
            return Obj.mostrarNroComprobante(Obj);
        }

        public static DataTable mostrarIdComprobante(int idVenta)
        {
            DComprobante Obj = new DComprobante();
            Obj.IdVenta = idVenta;
            return Obj.mostrarIdComprobante(Obj);
        }

        public static string EditarEstadoTicket(int idComprobante)
        {
            DComprobante Obj = new DComprobante();
            Obj.IdComprobante = idComprobante;
            return Obj.EditarEstadoTicket(Obj);
        }

        public static string AnularComprobante(int idComprobante)
        {
            DComprobante Obj = new DComprobante();
            Obj.IdComprobante = idComprobante;
            return Obj.AnularComprobante(Obj);
        }

        public static string InsertarManual(string tipoComprobante, int serie, int nroCom, decimal igv, DateTime fecha, int idVenta, string estado, int? idCliente, decimal monto, decimal efectivo, decimal tarjeta, decimal redondeo, string formaPago, decimal vuelto)
        {
            DComprobante Obj = new DComprobante();
            Obj.TipoComprobante = tipoComprobante;
            Obj.Serie = serie;
            Obj.Correlativo = nroCom;
            Obj.Igv = igv;
            Obj.Fecha = fecha;
            Obj.IdVenta = idVenta;
            Obj.Estado = estado;
            Obj.IdCliente = idCliente;
            Obj.Monto = monto;
            Obj.Efectivo = efectivo;
            Obj.Tarjeta = tarjeta;
            Obj.Redondeo = redondeo;
            Obj.FormaPago = formaPago;
            Obj.Vuelto = vuelto;
            return Obj.InsertarManual(Obj);
        }

        public static DataTable mostrarComprobantesAnulados(DateTime fechaInicio, DateTime fechaFin)
        {
            DComprobante Obj = new DComprobante();
            return Obj.mostrarComprobantesAnulados(fechaInicio, fechaFin);
        }
    }
}
