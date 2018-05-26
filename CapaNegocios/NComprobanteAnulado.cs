using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NComprobanteAnulado
    {
        public static string Insertar(int idComprobante,DateTime fechaAnulacion, string serie, string numero, string estado, string descripcion)
        {
            DComprobanteAnulado Obj = new DComprobanteAnulado();
            Obj.IdComprobante = idComprobante;
            Obj.FechaAnulacion = fechaAnulacion;
            Obj.Serie = serie;
            Obj.Numero = numero;
            Obj.Estado = estado;
            Obj.Descripcion = descripcion;
            return Obj.Insertar(Obj);
        }

        public static DataTable mostrarComprobanteAnulado()
        {
            return new DComprobanteAnulado().mostrarComprobanteAnulado();
        }

        public static DataTable mostrarCorrelativo(DateTime fecha)
        {
            DComprobanteAnulado Obj = new DComprobanteAnulado();
            Obj.FechaAnulacion = fecha;
            return Obj.mostrarCorrelativo(Obj);
        }
    }
}
