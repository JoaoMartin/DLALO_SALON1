using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace CapaNegocios
{
    public class NImprimirComandaBar
    {
        public static void imprimirCom(string mesero, string salon, string mesa, DataGridView dgGeneral,string adic)
        {

            NTicket ticket = new NTicket();
            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

            //Datos de la cabecera del Ticket.
            ticket.TextoCentro("NOMBRE DE LA EMPRESA");
            ticket.TextoIzquierda("COMANDA: LOCAL PRINCIPAL");
            if(adic != string.Empty)
            {
                ticket.TextoIzquierda("NOTA:" + adic);
            }
            
            ticket.TextoIzquierda("");


            //Sub cabecera.
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("ATENDIÓ:" + mesero);
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("Salón: " + salon + " Mesa: " + mesa);
            ticket.TextoIzquierda("");
            ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
            ticket.lineasAsteriscos();

            //Articulos a vender.
            ticket.EncabezadoComanda();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
            ticket.lineasAsteriscos();
            //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.

            foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
            {
                ticket.AgregaArticuloComanda(Convert.ToInt32(fila.Cells[1].Value.ToString()), fila.Cells[0].Value.ToString(), fila.Cells[2].Value.ToString());

            }

           
            /*
            ticket.AgregaArticulo("Articulo A", 2, 20, 40);
            ticket.AgregaArticulo("Articulo B", 1, 10, 10);
            ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);*/
            ticket.lineasIgual();

            //Resumen de la venta. Sólo son ejemplos


            //Texto final del Ticket.
            ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: 3");
            ticket.TextoIzquierda("");
            ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
            ticket.CortaTicket();
            ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera
        }
    }
}
