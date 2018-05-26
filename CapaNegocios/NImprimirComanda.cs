using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace CapaNegocios
{
    public class NImprimirComanda
    {
        public static void imprimirCom(string mesero, string salon, string mesa, DataGridView dgGeneral, string adic)
        {

            NTicket ticket = new NTicket();
            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

            //Datos de la cabecera del Ticket.
            ticket.TextoCentro("D'LALO");
            ticket.TextoIzquierda("COMANDA: LOCAL PRINCIPAL");
            if (adic != string.Empty)
            {
                ticket.TextoIzquierda("NOTA:" + adic);
            }

            ticket.TextoIzquierda("");


            //Sub cabecera.
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("ATENDIO:" + mesero);

            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("Salon: " + salon + " Mesa: " + mesa);
            ticket.TextoIzquierda("");
            ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
            ticket.lineasAsteriscos();

            //Articulos a vender.
            ticket.EncabezadoComanda();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
            ticket.lineasAsteriscos();
            //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.

            foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
            {
                if(fila.Cells[2].Value.ToString() == "M" || fila.Cells[2].Value.ToString() == "D")
                {
                    ticket.AgregaArticuloComanda(Convert.ToInt32(fila.Cells[1].Value.ToString()), "   " + fila.Cells[0].Value.ToString(), "");
                    //ticket.AgregaArticuloComanda(0, "", fila.Cells[2].Value.ToString());
                    ticket.TextoIzquierda(fila.Cells[2].Value.ToString());
                   
                }else
                {
                    ticket.AgregaArticuloComanda(Convert.ToInt32(fila.Cells[1].Value.ToString()), "   " + fila.Cells[0].Value.ToString(), fila.Cells[2].Value.ToString());
                }
               
            }
            ticket.CortaTicket1();
            // ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera
            //  ticket.ImprimirTicket("EPSON TM-U220 Receipt");
            // ticket.ImprimirTicket("COCINA_LALOS");//Nombre de la impresora ticketera
            ticket.ImprimirTicket("Microsoft XPS Document Writer");
        }


        public static void imprimirReserva(DataGridView dgGeneral, string fechaEntrega, string obs, string idVenta,string total,
            string adelanto, string saldo,string atendio, string cliente, string telefono, string motivo)
        {

            NTicket ticket = new NTicket();
            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

            //Datos de la cabecera del Ticket.
            ticket.TextoCentro("D'LALO");
            ticket.TextoCentro("Dulces y Salados");
            ticket.TextoCentro("Inversiones Lalos S.R.L");
            //  ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
            ticket.TextoCentro("AV. MARISCAL CACERES 1243 - Ayacucho");
            ticket.TextoCentro("RUC: 20304455463");
            ticket.TextoIzquierda("");

            ticket.TextoExtremos("CODIGO: " + idVenta, " ");
            ticket.TextoIzquierda("ATENDIO: " + atendio);

            ticket.TextoIzquierda("CLIENTE: " + cliente);
            ticket.TextoIzquierda("TEL.: " + telefono);
            ticket.TextoIzquierda("MOTIVO: " + motivo);
            ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
            ticket.TextoIzquierda("FECHA ENTREGA: " + fechaEntrega );
            ticket.lineasAsteriscos();

            //Articulos a vender.
            ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
            ticket.lineasAsteriscos();
            //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.


            foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
            {
                ticket.AgregaArticuloReserva(Convert.ToInt32(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[5].Value.ToString()),obs);
                //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
                // decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
            }
            ticket.lineasAsteriscos();
            ticket.TextoDerecha("TOTAL: " + total);
            ticket.TextoDerecha("Adelanto: " + adelanto +".00");
            ticket.TextoDerecha("Saldo: " + saldo);
            ticket.CortaTicket1();
             ticket.ImprimirTicket("CAJA");//Nombre de la impresora ticketera
            //  ticket.ImprimirTicket("EPSON TM-U220 Receipt");
            // ticket.ImprimirTicket("COCINA_LALOS");//Nombre de la impresora ticketera
            //ticket.ImprimirTicket("Microsoft XPS Document Writer");
        }
    }
}
