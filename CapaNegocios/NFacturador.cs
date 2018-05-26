using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace CapaNegocios
{
    public class NFacturador
    {
        public static string ruc = "20304455463";
        public static void registrarComprobanteCabecera(string tipoOperacion, string fechaEmision, string codigoDomFiscal, int? tipoDoc, string nroDoc, string cliente, string tipoMoneda, string dctoGlobal,
            string sumatOtros, string totalDcto, string totalVentaG, string totalVentaI, string totalVentaE, string sumIgv, string sumIsc, string sumOtrosTr,string impTotalVenta,
            string tipoDocumento,int idVenta)
        {
            DataTable dtNroCompr;
            dtNroCompr = NComprobante.mostrarNroComprobante(idVenta,tipoDocumento);
            string nroComprobante = dtNroCompr.Rows[0][0].ToString();
            string nroImpr = "";
            for (int i = 0; i < 8 - nroComprobante.Length; i++)
            {
                nroImpr += "0";
            }
          
            string serie;
            string cabecera = "";

            if (tipoDocumento == "FACTURA")
            {
                serie = "F001";
                cabecera = ruc + "-"+"01" +"-" +serie + "-" + nroImpr + nroComprobante;
            }
            else
            {
                serie = "B001";
                cabecera = ruc + "-" + "03" +"-"+ serie + "-"+nroImpr + nroComprobante;
            }
                System.IO.StreamWriter Cabecera = new System.IO.StreamWriter(@"C:\data0\facturador\DATA\" + cabecera + ".CAB" , true);
            string cabec = tipoOperacion + "|" + fechaEmision + "|" + codigoDomFiscal + "|" + tipoDoc + "|" + nroDoc + "|" + cliente + "|" +
            tipoMoneda + "|" + dctoGlobal + "|" + sumatOtros + "|" + totalDcto + "|" + totalVentaG + "|" + totalVentaI + "|" + totalVentaE + "|" + sumIgv + "|" + sumIsc + "|" + 
            sumatOtros + "|" + impTotalVenta;
                Cabecera.WriteLine(cabec);
                Cabecera.Close();

        


        }

        public static void registrarComprobanteDetalle(string codUnidaMedida, string cantidad, string codProducto,string codProductoSunat, string descripcion, string valorUnitario, string dctoItem, string montoIgvItem, string afectacionIgvItem,
            string montoIsc, string tipoSistemaIsc, string precioVentaUnitarioItem, string valorVentaItem,string tipoDocumento,int idVenta)
        {
            DataTable dtNroCompr;
            dtNroCompr = NComprobante.mostrarNroComprobante(idVenta,tipoDocumento);
            string nroComprobante = dtNroCompr.Rows[0][0].ToString();
            string nroImpr = "";
            for (int i = 0; i < 8 - nroComprobante.Length; i++)
            {
                nroImpr += "0";
            }
           
            string serie;
            string cabecera = "";

            if (tipoDocumento == "FACTURA")
            {
                serie = "F001";
                cabecera = ruc + "-" + "01" + "-" + serie + "-" + nroImpr + nroComprobante;
            }
            else
            {
                serie = "B001";
                cabecera = ruc + "-" + "03" + "-" + serie + "-" + nroImpr + nroComprobante;
            }
            System.IO.StreamWriter Detalle = new System.IO.StreamWriter(@"C:\data0\facturador\DATA\" + cabecera + ".DET", true);
            string cabec= codUnidaMedida+ "|"+ cantidad+ "|"+ codProducto+ "|"+ codProductoSunat+ "|"+ descripcion+ "|"+ valorUnitario+ "|"+ dctoItem+"|"+ montoIgvItem+ "|"+
                            afectacionIgvItem+ "|"+ montoIsc+ "|"+ tipoSistemaIsc+ "|"+ precioVentaUnitarioItem+ "|"+ valorVentaItem;
            Detalle.WriteLine(cabec);
            Detalle.Close();
        }

        public static  void bajaComprobante(string comprobante,string fechaGeneracio, string fechaDocBaja, string tipoDocBaja, string nroDoc, string descripcion, string ccc)
        {
        
            string nroImpr = "", nroCeros="",nroMes="";
            for (int i = 0; i < 8 - nroDoc.Length; i++)
            {
                nroImpr += "0";
            }
            for (int i = 0; i < 3 - ccc.Length; i++)
            {
                nroCeros += "0";
            }
         
            string anio = DateTime.Now.Year.ToString();
            string mes = DateTime.Now.Month.ToString();
            for (int i = 0; i < 2 - mes.Length; i++)
            {
                nroMes += "0";
            }
            string dia = DateTime.Now.Day.ToString();
            string fecha;
            if (dia.Length == 1)
            {
                fecha = anio + nroMes + mes  +"0"+dia;
            }else
            {
                 fecha = anio + nroMes + mes + dia;
            }
            string cabecera = "";

            string tip = "";
            if(comprobante == "FACTURA")
            {
                tip = "F001";
            }else
            {
                tip = "B001";
            }

            cabecera = ruc + "-" +"RA" + "-" + fecha + "-" +nroCeros + ccc;

            System.IO.StreamWriter nombreArchivo = new System.IO.StreamWriter(@"C:\data0\facturador\DATA\" + cabecera + ".CBA", true);
            string det = fechaGeneracio + "|" + fechaDocBaja + "|" + tipoDocBaja + "|" + tip +"-"+ nroImpr + nroDoc + "|" + descripcion + "|";
            nombreArchivo.WriteLine(det);
            nombreArchivo.Close();
        }
    }
}
