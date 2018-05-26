using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace CapaNegocios
{
    public class NImprimirCierreTurno
    {
        public static void imprimirCom(string trabajador, string fechaApertura, DateTime fechaCierre, string montoApertura, string ventasEfectivo, string otrosIngresos,
            string salidasDinero, string efectivoCaja, string nroVentas, string ventasTarjeta, string totalParcial)
        {
           
            NTicket ticket = new NTicket();
            ticket.AbreCajon();

            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo
            ticket.TextoCentro("D'LALO");
            ticket.TextoCentro("CORTE PARCIAL");
            //Datos de la cabecera del Ticket.
            ticket.TextoExtremos("TRABAJADOR: ", trabajador);
            ticket.TextoExtremos("F. APERTURA:", fechaApertura);
            ticket.TextoExtremos("F. CIERRE:", fechaCierre.ToString());
            ticket.TextoExtremos("CAJA:", "1");

            ticket.TextoCentro("DINERO EN CAJA");
            ticket.lineasAsteriscos();
            
            ticket.TextoExtremos("Ventas Efectivo:+ ", ventasEfectivo);
            ticket.TextoExtremos("Otros Ingresos: +", otrosIngresos);
            ticket.TextoExtremos("Salidas : -", salidasDinero);
            ticket.lineasAsteriscos();
            ticket.TextoExtremos("Total Parcial: +",totalParcial);
            ticket.TextoExtremos("Monto Apertura: +", montoApertura);
            decimal ventasEfectivoD = Convert.ToDecimal(ventasEfectivo);
            //decimal otrosIngresosD = Convert.ToDecimal(otrosIngresos);
            //decimal egresosD = Convert.ToDecimal(salidasDinero);
            //decimal efectivoCaja
            ticket.TextoExtremos("EFECTIVO EN CAJA : ", efectivoCaja);

            ticket.TextoCentro("VENTAS");
            ticket.TextoExtremos("N° Ventas: ", nroVentas);
            ticket.lineasAsteriscos();
           
            ticket.TextoExtremos("En Efectivo: +", ventasEfectivo);
            ticket.TextoExtremos("Con Tarjeta: +", ventasTarjeta);
            ticket.lineasAsteriscos();
            
            decimal ventasTarjetaD = Convert.ToDecimal(ventasTarjeta);
            decimal total = ventasTarjetaD + ventasEfectivoD;
            ticket.TextoExtremos("TotalVentas: ", total.ToString());

            ticket.CortaTicket1();
            //ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera
            ticket.ImprimirTicket("CAJA");
          //  ticket.ImprimirTicket("COCINA_LALOS");//Nombre de la impresora ticketera
        }

        public static void imprimirCaja(string trabajador, string fechaApertura, DateTime fechaCierre, string montoApertura, string ventasEfectivo, string otrosIngresos,
            string salidasDinero, string efectivoCaja, string nroVentas, string ventasTarjeta,string nroTickets, string nroBoletas, string nroFacturas,string totalParcial)
        {

            NTicket ticket = new NTicket();
            ticket.AbreCajon();

            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo
            ticket.TextoCentro("D'LALO");
            ticket.TextoCentro("CIERRE DE CAJA");
            //Datos de la cabecera del Ticket.
            ticket.TextoExtremos("TRABAJADOR: ", trabajador);
            ticket.TextoExtremos("F. APERTURA:", fechaApertura);
            ticket.TextoExtremos("F. CIERRE:", fechaCierre.ToString());
            ticket.TextoExtremos("CAJA:", "1");

            ticket.TextoCentro("DINERO EN CAJA");
            ticket.lineasAsteriscos();
            
            ticket.TextoExtremos("Ventas Efectivo:+ ", ventasEfectivo);
            ticket.TextoExtremos("Otros Ingresos: +", otrosIngresos);
            ticket.TextoExtremos("Salidas : -", salidasDinero);
            ticket.lineasAsteriscos();
            decimal ventasEfectivoD = Convert.ToDecimal(ventasEfectivo);
            //decimal otrosIngresosD = Convert.ToDecimal(otrosIngresos);
            //decimal egresosD = Convert.ToDecimal(salidasDinero);
            //decimal efectivoCaja
            ticket.TextoExtremos("Total Parcial : ", totalParcial);
            ticket.TextoExtremos("Monto Apertura: +", montoApertura);
            ticket.TextoExtremos("EFECTIVO EN CAJA : ", efectivoCaja);

            ticket.TextoCentro("VENTAS");
            ticket.TextoExtremos("N° Ventas: ", nroVentas);
            ticket.lineasAsteriscos();

            ticket.TextoExtremos("En Efectivo: +", ventasEfectivo);
            ticket.TextoExtremos("Con Tarjeta: +", ventasTarjeta);
            ticket.lineasAsteriscos();

            decimal ventasTarjetaD = Convert.ToDecimal(ventasTarjeta);
            decimal total = ventasTarjetaD + ventasEfectivoD;
            ticket.TextoExtremos("TotalVentas: ", total.ToString());

            ticket.TextoCentro("COMPROBANTES");
            ticket.lineasAsteriscos();
            ticket.TextoExtremos("Nro TICKETS:", nroTickets);
            ticket.TextoExtremos("Nro BOLETAS:", nroBoletas);
            ticket.TextoExtremos("Nro FACTURAS:", nroFacturas);

            ticket.CortaTicket1();
             //ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera
              ticket.ImprimirTicket("CAJA");
           // ticket.ImprimirTicket("COCINA_LALOS");//Nombre de la impresora ticketera
        }
    }
}
