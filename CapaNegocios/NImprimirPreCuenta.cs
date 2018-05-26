using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace CapaNegocios
{
    public class NImprimirPreCuenta
    {
        public static void imprimirCom(int idVenta,  string mesero, string salon, string mesa, DataGridView dgGeneral, string dctoInd,  string subTotal, string total)
        {
     
            NTicket ticket = new NTicket();
            ticket.AbreCajon();


            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

            //Datos de la cabecera del Ticket.
            ticket.TextoCentro("D'LALO");
            ticket.TextoCentro("Inversiones Lalos S.R.L");
            //  ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
            ticket.TextoCentro("AV. MARISCAL CACERES 1243 - Ayacucho");
            ticket.TextoCentro("RUC: 20304455463");
            ticket.TextoIzquierda("      PRECUENTA");

            ticket.TextoIzquierda("");

            ticket.lineasAsteriscos();

            //Sub cabecera.
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("ATENDIO:" + mesero);
           

            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("Salon: " + salon + " Mesa: " + mesa);
            ticket.TextoIzquierda("");
            ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
            ticket.lineasAsteriscos();

            //Articulos a vender.
            ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
            ticket.lineasAsteriscos();
            //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.

                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    ticket.AgregaArticulo(Convert.ToInt32(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[5].Value.ToString()));
                    //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
                    // decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
                }

            /*
            ticket.AgregaArticulo("Articulo A", 2, 20, 40);
            ticket.AgregaArticulo("Articulo B", 1, 10, 10);
            ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);*/
            ticket.lineasIgual();

            //Resumen de la venta. Sólo son ejemplos
            ticket.AgregarTotales("         SUBTOTAL......S/", Convert.ToDecimal(subTotal));

            if (dctoInd != "00.00")
            {
                ticket.AgregarTotales("         DSCTO IND.....S/ ", Convert.ToDecimal(dctoInd));
            }
          
            ticket.AgregarTotales("         TOTAL.........S/", Convert.ToDecimal(total));
            ticket.TextoIzquierda("");

            //Texto final del Ticket.
            ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: 3");
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("NOMBRE/RAZON SOCIAL:");
            ticket.TextoIzquierda("DNI/RUC:");
            ticket.TextoIzquierda("DIRECCION:");
            ticket.CortaTicket();
            // ticket.ImprimirTicket("COCINA_LALOS");//Nombre de la impresora ticketera
            ticket.ImprimirTicket("Microsoft XPS Document Writer");
            // ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera
        }
    }
}
