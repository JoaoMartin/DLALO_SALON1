using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace CapaNegocios
{
    public class NImprimir_Comprobante
    {
        
        public static void imprimirCom(int idVenta, string tipoCompr,string cliente, string direccion, string nroDoc ,string mesero,string salon, string mesa, DataGridView dgGeneral, string dctoInd, string dctoGral, string subTotal, string igv, string total, string efectivo, string vuelto, string tarjeta, string formaPago, string modoProducto, string redondeo,string telefono)
        {
            DataTable dtNroCompr;
            NTicket ticket = new NTicket();
            ticket.AbreCajon();

            dtNroCompr = NComprobante.mostrarNroComprobante(idVenta,tipoCompr);
            string nroComprobante = dtNroCompr.Rows[0][0].ToString();
            string nroImpr = "";
            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

            //Datos de la cabecera del Ticket.
            ticket.TextoCentro("D'LALO");
            ticket.TextoCentro("Dulces y Salados");
            ticket.TextoCentro("Inversiones Lalos S.R.L");
            //  ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
            ticket.TextoCentro("AV. MARISCAL CACERES 1243 - Ayacucho");
            ticket.TextoCentro("RUC: 20304455463");
            //ticket.TextoIzquierda("RAZON SOCIAL: JUAN CARLOS RIVERA MEZA");
            //ticket.TextoIzquierda("TELEF: 066 30 3567");
            //ticket.TextoIzquierda("RUC: 10106813731");
            // ticket.TextoIzquierda("EMAIL: jmsolorzano19@gmail.com");//Es el mio por si me quieren contactar ...
            // ticket.TextoIzquierda("");
            for (int i = 0; i < 7 - nroComprobante.Length; i++)
            {
                nroImpr += "0";
            }
            ticket.TextoExtremos("Caja 1", tipoCompr + " 001-" + nroImpr + nroComprobante);
            ticket.lineasAsteriscos();

            //Sub cabecera.
           // ticket.TextoIzquierda("");
           if(tipoCompr != "TICKET")
            {
               // ticket.TextoIzquierda("ATENDIO:" + mesero);
            }
            ticket.TextoIzquierda("ATENDIO:" + mesero);
            if (tipoCompr == "FACTURA")
            {
                ticket.TextoIzquierda("Nro RUC: " + nroDoc);
                ticket.TextoIzquierda("CLIENTE: " + cliente);
                ticket.TextoIzquierda("Dir.: " + direccion);
                if(telefono != "")
                {
                    ticket.TextoIzquierda("Tel: " + telefono);
                }
                ticket.TextoIzquierda("");
            }
            else if(tipoCompr == "BOLETA")
            {
                if (cliente == "")
                {
                    //ticket.TextoIzquierda("CLIENTE: PUBLICO GENERAL ");
                }
                else
                {
                    ticket.TextoIzquierda("CLIENTE: " + cliente);
                    if (direccion != "")
                    {
                        ticket.TextoIzquierda("Dir: " + direccion);
                    }
                    if(telefono != "")
                    {
                        ticket.TextoIzquierda("Tel: " + telefono);
                    }
                    ticket.TextoIzquierda("");
                }
                
            }
            
           // ticket.TextoIzquierda("");
           if(tipoCompr != "TICKET")
            {
                //ticket.TextoIzquierda("Salón: " + salon + " Mesa: " + mesa);
            }
            //ticket.TextoIzquierda("Salón: " + salon + " Mesa: " + mesa);
            //ticket.TextoIzquierda("");
            ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
            ticket.lineasAsteriscos();

            //Articulos a vender.
            ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
            ticket.lineasAsteriscos();
            //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
            if(modoProducto == "Detallado")
            {
                
                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    ticket.AgregaArticulo(Convert.ToInt32(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[5].Value.ToString()));
                    //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
                    // decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
                }
            }
            else if (modoProducto == "Detallados")
            {
                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    ticket.AgregaArticulo(Convert.ToInt32(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[6].Value.ToString()));
             
                }
            }
            else if (modoProducto == "Por Consumos")
            {
                ticket.AgregaArticulo(1, "POR CONSUMO", Convert.ToDecimal(total));
            }
            else if(modoProducto == "Por Consumo")
            {
                ticket.AgregaArticulo(1, "POR CONSUMO", Convert.ToDecimal(total));
            }

            /*
            ticket.AgregaArticulo("Articulo A", 2, 20, 40);
            ticket.AgregaArticulo("Articulo B", 1, 10, 10);
            ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);*/
            ticket.lineasIgual();

            //Resumen de la venta. Sólo son ejemplos
            if(tipoCompr != "TICKET")
            {
                ticket.AgregarTotales("         SUBTOTAL......S/", Convert.ToDecimal(subTotal));

                if (dctoInd != "00.00")
                {
                    ticket.AgregarTotales("         DSCTO IND.....S/ ", Convert.ToDecimal(dctoInd));
                }
                if (dctoGral != "00.00")
                {
                    ticket.AgregarTotales("         DSCTO GENERAL.S/ ", Convert.ToDecimal(dctoGral));
                }
                if (redondeo != "00.00")
                {
                    ticket.AgregarTotales("         REDONDEO......S/ ", Convert.ToDecimal(redondeo));
                }
                ticket.AgregarTotales("         IGV...........S/", Convert.ToDecimal(igv));//La M indica que es un decimal en C#
               
            }

            ticket.AgregarTotales("         TOTAL.........S/", Convert.ToDecimal(total));
            ticket.TextoIzquierda("");


            if (formaPago == "EFECTIVO")
            {
                ticket.AgregarTotales("         EFECTIVO......S/", Convert.ToDecimal(efectivo));
                ticket.AgregarTotales("         VUELTO........S/", Convert.ToDecimal(vuelto));
            }else if(formaPago == "TARJETA")
            {
                ticket.TextoIzquierda("         PAGA CON TARJETA");
                ticket.AgregarTotales("         VUELTO........S/", Convert.ToDecimal(vuelto));
            }else if(formaPago == "MIXTO")
            {
                ticket.AgregarTotales("         EFECTIVO......S/", Convert.ToDecimal(efectivo));
                ticket.AgregarTotales("         TARJETA.......S/", Convert.ToDecimal(tarjeta));
            }


            //Texto final del Ticket.
           // ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: 3");
            ticket.TextoIzquierda("");
            ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
            if (tipoCompr == "TICKET")
            {
                ticket.TextoIzquierda("Este documento no es un comprobante fiscal");
                ticket.TextoIzquierda("Canjee este documento por una boleta/factura");
            }
            ticket.CortaTicket();
            /*
            if(tipoCompr == "TICKET")
            {
                //ticket.ImprimirTicket("COCINA");//Nombre de la impresora ticketera
                ticket.ImprimirTicket("Microsoft XPS Document Writer");

            }
            else
            {
               // ticket.ImprimirTicket("EPSON TM-U220 Receipt");//Nombre de la impresora ticketera
                ticket.ImprimirTicket("Microsoft XPS Document Writer");

            }*/
         //ticket.ImprimirTicket("Microsoft XPS Document Writer");
            ticket.ImprimirTicket("CAJA");
            //  ticket.ImprimirTicket("EPSON TM-U220 Receipt");//Nombre de la impresora ticketera
        }


        public static void imprimirComRepetido(string nroComprobante, string tipoCompr, string cliente, string direccion, string nroDoc, 
            string salon, string mesa, DataGridView dgGeneral, string dctoInd, string dctoGral, string subTotal, string igv, string total, string efectivo,  string tarjeta,
            string formaPago, string modoProducto, string redondeo, string telefono, string vuelto,string fecha,string mesero)
        {
            
            NTicket ticket = new NTicket();
            ticket.AbreCajon();

            string nroImpr = "";
            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

            //Datos de la cabecera del Ticket.
            ticket.TextoCentro("D'LALO");
            ticket.TextoCentro("Dulces y Salados");
            ticket.TextoCentro("Inversiones Lalos S.R.L");
            //  ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
            ticket.TextoCentro("AV. MARISCAL CACERES 1243 - Ayacucho");
            ticket.TextoCentro("RUC: 20304455463");
            //ticket.TextoIzquierda("RAZON SOCIAL: JUAN CARLOS RIVERA MEZA");
            //ticket.TextoIzquierda("TELEF: 066 30 3567");
            //ticket.TextoIzquierda("RUC: 10106813731");
            // ticket.TextoIzquierda("EMAIL: jmsolorzano19@gmail.com");//Es el mio por si me quieren contactar ...
            // ticket.TextoIzquierda("");
            for (int i = 0; i < 7 - nroComprobante.Length; i++)
            {
                nroImpr += "0";
            }
            ticket.TextoExtremos("Caja 1", tipoCompr + " 001-" + nroImpr + nroComprobante);
            ticket.lineasAsteriscos();

            //Sub cabecera.
            //ticket.TextoIzquierda("");
            ticket.TextoIzquierda("ATENDIO:" + mesero);
            if (tipoCompr == "FACTURA")
            {
                ticket.TextoIzquierda("Nro RUC: " + nroDoc);
                ticket.TextoIzquierda("CLIENTE: " + cliente);
                ticket.TextoIzquierda("Dir.: " + direccion);
                if (telefono != "")
                {
                    ticket.TextoIzquierda("Tel: " + telefono);
                }
                ticket.TextoIzquierda("");
            }
            else if(tipoCompr=="BOLETA")
            {
                if (cliente == "")
                {
                   // ticket.TextoIzquierda("CLIENTE: PUBLICO GENERAL ");
                }
                else
                {
                    ticket.TextoIzquierda("CLIENTE: " + cliente);
                    if (direccion != "")
                    {
                        ticket.TextoIzquierda("Dir: " + direccion);
                    }
                    if (telefono != "")
                    {
                        ticket.TextoIzquierda("Tel: " + telefono);
                    }
                    ticket.TextoIzquierda("");
                }

            }

           // ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("Salón: " + salon + " Mesa: " + mesa);
            //ticket.TextoIzquierda("");
            ticket.TextoExtremos("FECHA: " , fecha);
            ticket.lineasAsteriscos();

            //Articulos a vender.
            ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
            ticket.lineasAsteriscos();
            //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
            if (modoProducto == "Detallado")
            {

                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    ticket.AgregaArticulo(Convert.ToInt32(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[5].Value.ToString()));
                    //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
                    // decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
                }
            }
            else if (modoProducto == "Detallados")
            {
                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    ticket.AgregaArticulo(Convert.ToInt32(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[6].Value.ToString()));

                }
            }
            else if (modoProducto == "Por Consumos")
            {
                ticket.AgregaArticulo(1, "POR CONSUMO", Convert.ToDecimal(total));
            }
            else if (modoProducto == "Por Consumo")
            {
                ticket.AgregaArticulo(1, "POR CONSUMO", Convert.ToDecimal(total));
            }

            /*
            ticket.AgregaArticulo("Articulo A", 2, 20, 40);
            ticket.AgregaArticulo("Articulo B", 1, 10, 10);
            ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);*/
            ticket.lineasIgual();

            //Resumen de la venta. Sólo son ejemplos
            if(tipoCompr != "TICKET")
            {
                ticket.AgregarTotales("         SUBTOTAL......S/", Convert.ToDecimal(subTotal));

                if (dctoInd != "0.00")
                {
                    ticket.AgregarTotales("         DSCTO IND.....S/ ", Convert.ToDecimal(dctoInd));
                }
                if (dctoGral != "0.00")
                {
                    ticket.AgregarTotales("         DSCTO GENERAL.S/ ", Convert.ToDecimal(dctoGral));
                }
                if (redondeo != "0.00")
                {
                    ticket.AgregarTotales("         REDONDEO......S/ ", Convert.ToDecimal(redondeo));
                }
                ticket.AgregarTotales("         IGV...........S/", Convert.ToDecimal(igv));//La M indica que es un decimal en C#
            }


            ticket.AgregarTotales("         TOTAL.........S/", Convert.ToDecimal(total));
           // ticket.TextoIzquierda("");


            if (formaPago == "EFECTIVO")
            {
                ticket.AgregarTotales("         EFECTIVO......S/", Convert.ToDecimal(efectivo));
                ticket.AgregarTotales("         VUELTO........S/", Convert.ToDecimal(vuelto));
            }
            else if (formaPago == "TARJETA")
            {
                ticket.TextoIzquierda("         PAGA CON TARJETA");
                ticket.AgregarTotales("         VUELTO........S/", Convert.ToDecimal(vuelto));
            }
            else if (formaPago == "MIXTO")
            {
                ticket.AgregarTotales("         EFECTIVO......S/", Convert.ToDecimal(efectivo));
                ticket.AgregarTotales("         TARJETA.......S/", Convert.ToDecimal(tarjeta));
            }


            //Texto final del Ticket.
            //ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: 3");
            ticket.TextoIzquierda("");
            ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
            if (tipoCompr == "TICKET")
            {
                ticket.TextoIzquierda("Este documento no es un comprobante fiscal");
                ticket.TextoIzquierda("Canjee este documento por una boleta/factura");
            }
            ticket.CortaTicket();
            /*
            if(tipoCompr == "TICKET")
            {
                //ticket.ImprimirTicket("COCINA");//Nombre de la impresora ticketera
                ticket.ImprimirTicket("Microsoft XPS Document Writer");

            }
            else
            {
               // ticket.ImprimirTicket("EPSON TM-U220 Receipt");//Nombre de la impresora ticketera
                ticket.ImprimirTicket("Microsoft XPS Document Writer");

            }*/
             ticket.ImprimirTicket("CAJA");
            //ticket.ImprimirTicket("CAJA1");
            //ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera
            //ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera
        }

        public static void imprimirCambioCompr(int idVenta, string tipoCompr, string cliente, string direccion, string nroDoc, string salon, string mesa, DataGridView dgGeneral, string dctoInd, string dctoGral, string subTotal, string igv, string total, string efectivo, string vuelto, string tarjeta, string formaPago, string modoProducto, string redondeo, string telefono)
        {
            DataTable dtNroCompr;
            NTicket ticket = new NTicket();
            ticket.AbreCajon();

            dtNroCompr = NComprobante.mostrarNroComprobante(idVenta, tipoCompr);
            string nroComprobante = dtNroCompr.Rows[0][0].ToString();
            string nroImpr = "";
            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

            //Datos de la cabecera del Ticket.
            ticket.TextoCentro("D'LALO");
            ticket.TextoCentro("Dulces y Salados");
            ticket.TextoCentro("Inversiones Lalos S.R.L");
            //  ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
            ticket.TextoCentro("AV. MARISCAL CACERES 1243 - Ayacucho");
            ticket.TextoCentro("RUC: 20304455463");
            //ticket.TextoIzquierda("RAZON SOCIAL: JUAN CARLOS RIVERA MEZA");
            //ticket.TextoIzquierda("TELEF: 066 30 3567");
            //ticket.TextoIzquierda("RUC: 10106813731");
            // ticket.TextoIzquierda("EMAIL: jmsolorzano19@gmail.com");//Es el mio por si me quieren contactar ...
            //ticket.TextoIzquierda("");
            for (int i = 0; i < 7 - nroComprobante.Length; i++)
            {
                nroImpr += "0";
            }
            ticket.TextoExtremos("Caja 1", tipoCompr + " 001-" + nroImpr + nroComprobante);
            ticket.lineasAsteriscos();

            //Sub cabecera.
            ticket.TextoIzquierda("");
            if (tipoCompr == "FACTURA")
            {
                ticket.TextoIzquierda("Nro RUC: " + nroDoc);
                ticket.TextoIzquierda("CLIENTE: " + cliente);
                ticket.TextoIzquierda("Dir.: " + direccion);
                if (telefono != "")
                {
                    ticket.TextoIzquierda("Tel: " + telefono);
                }
                ticket.TextoIzquierda("");
            }
            else if(tipoCompr == "BOLETA")
            {
                if (cliente == "")
                {
                    //ticket.TextoIzquierda("CLIENTE: PUBLICO GENERAL ");
                }
                else
                {
                    ticket.TextoIzquierda("CLIENTE: " + cliente);
                    if (direccion != "")
                    {
                        ticket.TextoIzquierda("Dir: " + direccion);
                    }
                    if (telefono != "")
                    {
                        ticket.TextoIzquierda("Tel: " + telefono);
                    }
                    ticket.TextoIzquierda("");
                }

            }

           // ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("Salón: " + salon + " Mesa: " + mesa);
            //ticket.TextoIzquierda("");
            ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
            ticket.lineasAsteriscos();

            //Articulos a vender.
            ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
            ticket.lineasAsteriscos();
            //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
            if (modoProducto == "Detallado")
            {

                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    ticket.AgregaArticulo(Convert.ToInt32(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[5].Value.ToString()));
                    //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
                    // decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
                }
            }
            else if (modoProducto == "Detallados")
            {
                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    ticket.AgregaArticulo(Convert.ToInt32(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[6].Value.ToString()));

                }
            }
            else if (modoProducto == "Por Consumos")
            {
                ticket.AgregaArticulo(1, "POR CONSUMO", Convert.ToDecimal(total));
            }
            else if (modoProducto == "Por Consumo")
            {
                ticket.AgregaArticulo(1, "POR CONSUMO", Convert.ToDecimal(total));
            }

            /*
            ticket.AgregaArticulo("Articulo A", 2, 20, 40);
            ticket.AgregaArticulo("Articulo B", 1, 10, 10);
            ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);*/
            ticket.lineasIgual();

            if(tipoCompr != "TICKET")
            {
                //Resumen de la venta. Sólo son ejemplos
                ticket.AgregarTotales("         SUBTOTAL......S/", Convert.ToDecimal(subTotal));

                if (dctoInd != "00.00")
                {
                    ticket.AgregarTotales("         DSCTO IND.....S/ ", Convert.ToDecimal(dctoInd));
                }
                if (dctoGral != "00.00")
                {
                    ticket.AgregarTotales("         DSCTO GENERAL.S/ ", Convert.ToDecimal(dctoGral));
                }
                if (redondeo != "00.00")
                {
                    ticket.AgregarTotales("         REDONDEO......S/ ", Convert.ToDecimal(redondeo));
                }
                ticket.AgregarTotales("         IGV...........S/", Convert.ToDecimal(igv));//La M indica que es un decimal en C#
            }

            ticket.AgregarTotales("         TOTAL.........S/", Convert.ToDecimal(total));
            ticket.TextoIzquierda("");


            if (formaPago == "EFECTIVO")
            {
                ticket.AgregarTotales("         EFECTIVO......S/", Convert.ToDecimal(efectivo));
                ticket.AgregarTotales("         VUELTO........S/", Convert.ToDecimal(vuelto));
            }
            else if (formaPago == "TARJETA")
            {
                ticket.TextoIzquierda("         PAGA CON TARJETA");
                ticket.AgregarTotales("         VUELTO........S/", Convert.ToDecimal(vuelto));
            }
            else if (formaPago == "MIXTO")
            {
                ticket.AgregarTotales("         EFECTIVO......S/", Convert.ToDecimal(efectivo));
                ticket.AgregarTotales("         TARJETA.......S/", Convert.ToDecimal(tarjeta));
            }


            //Texto final del Ticket.
           // ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: 3");
            ticket.TextoIzquierda("");
            ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
            if (tipoCompr == "TICKET")
            {
                ticket.TextoIzquierda("Este documento no es un comprobante fiscal");
                ticket.TextoIzquierda("Canjee este documento por una boleta/factura");
            }
            ticket.CortaTicket();
            /*
                      if(tipoCompr == "TICKET")
                      {
                          //ticket.ImprimirTicket("COCINA");//Nombre de la impresora ticketera
                          ticket.ImprimirTicket("Microsoft XPS Document Writer");

                      }
                      else
                      {
                         // ticket.ImprimirTicket("EPSON TM-U220 Receipt");//Nombre de la impresora ticketera
                          ticket.ImprimirTicket("Microsoft XPS Document Writer");

                      }*/
            ticket.ImprimirTicket("CAJA");
           // ticket.ImprimirTicket("CAJA1");
          //   ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera
            //ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera
        }

        public static void imprimirComManual(int idVenta, string tipoCompr, string cliente, string serie, string nroCom, string direccion, string nroDoc, string mesero, string salon, string mesa, DataGridView dgGeneral, string dctoInd, string dctoGral, string subTotal, string igv, string total, string efectivo, string vuelto, string tarjeta, string formaPago, string modoProducto, string redondeo, string telefono)
        {

            NTicket ticket = new NTicket();
            ticket.AbreCajon();


            string nroImpr = "";
            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

            //Datos de la cabecera del Ticket.
            ticket.TextoCentro("D'LALO");
            ticket.TextoCentro("Dulces y Salados");
            ticket.TextoCentro("Inversiones Lalos S.R.L");
            //  ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
            ticket.TextoCentro("AV. MARISCAL CACERES 1243 - Ayacucho");
            ticket.TextoCentro("RUC: 20304455463");
            //ticket.TextoIzquierda("RAZON SOCIAL: JUAN CARLOS RIVERA MEZA");
            //ticket.TextoIzquierda("TELEF: 066 30 3567");
            //ticket.TextoIzquierda("RUC: 10106813731");
            // ticket.TextoIzquierda("EMAIL: jmsolorzano19@gmail.com");//Es el mio por si me quieren contactar ...
            // ticket.TextoIzquierda("");
            for (int i = 0; i < 7 - nroCom.Length; i++)
            {
                nroImpr += "0";
            }
            ticket.TextoExtremos("Caja 1", tipoCompr +" "+ serie +"-" + nroCom);
            ticket.lineasAsteriscos();

            //Sub cabecera.
            ticket.TextoIzquierda("");
           // ticket.TextoIzquierda("ATENDIO:" + mesero);
            if (tipoCompr == "FACTURA MANUAL")
            {
                ticket.TextoIzquierda("Nro RUC: " + nroDoc);
                ticket.TextoIzquierda("CLIENTE: " + cliente);
                ticket.TextoIzquierda("Dir.: " + direccion);
                if (telefono != "")
                {
                    ticket.TextoIzquierda("Tel: " + telefono);
                }
                ticket.TextoIzquierda("");
            }
            else if(tipoCompr =="TICKET")
            {
                if (cliente == "")
                {
                    //ticket.TextoIzquierda("CLIENTE: PUBLICO GENERAL ");
                }
                else
                {
                    ticket.TextoIzquierda("CLIENTE: " + cliente);
                    if (direccion != "")
                    {
                        ticket.TextoIzquierda("Dir: " + direccion);
                    }
                    if (telefono != "")
                    {
                        ticket.TextoIzquierda("Tel: " + telefono);
                    }
                    ticket.TextoIzquierda("");
                }

            }

            //ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("Salón: " + salon + " Mesa: " + mesa);
            //ticket.TextoIzquierda("");
            ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
            ticket.lineasAsteriscos();

            //Articulos a vender.
            ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
            ticket.lineasAsteriscos();
            //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
            if (modoProducto == "Detallado")
            {

                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    ticket.AgregaArticulo(Convert.ToInt32(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[5].Value.ToString()));
                    //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
                    // decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
                }
            }
            else if (modoProducto == "Detallados")
            {
                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    ticket.AgregaArticulo(Convert.ToInt32(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[6].Value.ToString()));

                }
            }
            else if (modoProducto == "Por Consumos")
            {
                ticket.AgregaArticulo(1, "POR CONSUMO", Convert.ToDecimal(total));
            }
            else if (modoProducto == "Por Consumo")
            {
                ticket.AgregaArticulo(1, "POR CONSUMO", Convert.ToDecimal(total));
            }

            /*
            ticket.AgregaArticulo("Articulo A", 2, 20, 40);
            ticket.AgregaArticulo("Articulo B", 1, 10, 10);
            ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);*/
            ticket.lineasIgual();

            //Resumen de la venta. Sólo son ejemplos
            if(tipoCompr != "TICKET")
            {
                ticket.AgregarTotales("         SUBTOTAL......S/", Convert.ToDecimal(subTotal));

                if (dctoInd != "00.00")
                {
                    ticket.AgregarTotales("         DSCTO IND.....S/ ", Convert.ToDecimal(dctoInd));
                }
                if (dctoGral != "00.00")
                {
                    ticket.AgregarTotales("         DSCTO GENERAL.S/ ", Convert.ToDecimal(dctoGral));
                }
                if (redondeo != "00.00")
                {
                    ticket.AgregarTotales("         REDONDEO......S/ ", Convert.ToDecimal(redondeo));
                }
                ticket.AgregarTotales("         IGV...........S/", Convert.ToDecimal(igv));//La M indica que es un decimal en C#
            }

            ticket.AgregarTotales("         TOTAL.........S/", Convert.ToDecimal(total));
            ticket.TextoIzquierda("");


            if (formaPago == "EFECTIVO")
            {
                ticket.AgregarTotales("         EFECTIVO......S/", Convert.ToDecimal(efectivo));
                ticket.AgregarTotales("         VUELTO........S/", Convert.ToDecimal(vuelto));
            }
            else if (formaPago == "TARJETA")
            {
                ticket.TextoIzquierda("         PAGA CON TARJETA");
                ticket.AgregarTotales("         VUELTO........S/", Convert.ToDecimal(vuelto));
            }
            else if (formaPago == "MIXTO")
            {
                ticket.AgregarTotales("         EFECTIVO......S/", Convert.ToDecimal(efectivo));
                ticket.AgregarTotales("         TARJETA.......S/", Convert.ToDecimal(tarjeta));
            }


            //Texto final del Ticket.
            //ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: 3");
            ticket.TextoIzquierda("");
            ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
            if (tipoCompr == "TICKET")
            {
                ticket.TextoIzquierda("Este documento no es un comprobante fiscal");
                ticket.TextoIzquierda("Canjee este documento por una boleta/factura");
            }
            ticket.CortaTicket();
            /*
                   if(tipoCompr == "TICKET")
                   {
                       //ticket.ImprimirTicket("COCINA");//Nombre de la impresora ticketera
                       ticket.ImprimirTicket("Microsoft XPS Document Writer");

                   }
                   else
                   {
                      // ticket.ImprimirTicket("EPSON TM-U220 Receipt");//Nombre de la impresora ticketera
                       ticket.ImprimirTicket("Microsoft XPS Document Writer");

                   }*/
            //ticket.ImprimirTicket("Microsoft XPS Document Writer");
            ticket.ImprimirTicket("CAJA");
           //  ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera
            // ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera
        }


        public static void imprimirComRepetidoManual(string serie,string nroComprobante, string tipoCompr, string cliente, string direccion, string nroDoc, string salon, string mesa, DataGridView dgGeneral, string dctoInd, string dctoGral, string subTotal, string igv, string total, string efectivo, string tarjeta, string formaPago, string modoProducto, string redondeo, string telefono, string vuelto, string fecha)
        {

            NTicket ticket = new NTicket();
            ticket.AbreCajon();

            string nroImpr = "";
            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

            //Datos de la cabecera del Ticket.
            ticket.TextoCentro("D'LALO");
            ticket.TextoCentro("Dulces y Salados");
            ticket.TextoCentro("Inversiones Lalos S.R.L");
            //  ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
            ticket.TextoCentro("AV. MARISCAL CACERES 1243 - Ayacucho");
            ticket.TextoCentro("RUC: 20304455463");
            //ticket.TextoIzquierda("RAZON SOCIAL: JUAN CARLOS RIVERA MEZA");
            //ticket.TextoIzquierda("TELEF: 066 30 3567");
            //ticket.TextoIzquierda("RUC: 10106813731");
            // ticket.TextoIzquierda("EMAIL: jmsolorzano19@gmail.com");//Es el mio por si me quieren contactar ...
            // ticket.TextoIzquierda("");
            for (int i = 0; i < 7 - nroComprobante.Length; i++)
            {
                nroImpr += "0";
            }
            ticket.TextoExtremos("Caja 1", tipoCompr + " "+ serie+ "-"  + nroComprobante);
            ticket.lineasAsteriscos();

            //Sub cabecera.
            //ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("ATENDIO:" + mesero);
            if (tipoCompr == "FACTURA MANUAL")
            {
                ticket.TextoIzquierda("Nro RUC: " + nroDoc);
                ticket.TextoIzquierda("CLIENTE: " + cliente);
                ticket.TextoIzquierda("Dir.: " + direccion);
                if (telefono != "")
                {
                    ticket.TextoIzquierda("Tel: " + telefono);
                }
                ticket.TextoIzquierda("");
            }
            else if(tipoCompr == "BOLETA")
            {
                if (cliente == "")
                {
                    ticket.TextoIzquierda("CLIENTE: PUBLICO GENERAL ");
                }
                else
                {
                    ticket.TextoIzquierda("CLIENTE: " + cliente);
                    if (direccion != "")
                    {
                        ticket.TextoIzquierda("Dir: " + direccion);
                    }
                    if (telefono != "")
                    {
                        ticket.TextoIzquierda("Tel: " + telefono);
                    }
                    ticket.TextoIzquierda("");
                }

            }

           // ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("Salón: " + salon + " Mesa: " + mesa);
            //ticket.TextoIzquierda("");
            ticket.TextoExtremos("FECHA: " , fecha);
            ticket.lineasAsteriscos();

            //Articulos a vender.
            ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
            ticket.lineasAsteriscos();
            //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
            if (modoProducto == "Detallado")
            {

                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    ticket.AgregaArticulo(Convert.ToInt32(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[5].Value.ToString()));
                    //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
                    // decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
                }
            }
            else if (modoProducto == "Detallados")
            {
                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    ticket.AgregaArticulo(Convert.ToInt32(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[6].Value.ToString()));

                }
            }
            else if (modoProducto == "Por Consumos")
            {
                ticket.AgregaArticulo(1, "POR CONSUMO", Convert.ToDecimal(total));
            }
            else if (modoProducto == "Por Consumo")
            {
                ticket.AgregaArticulo(1, "POR CONSUMO", Convert.ToDecimal(total));
            }

            /*
            ticket.AgregaArticulo("Articulo A", 2, 20, 40);
            ticket.AgregaArticulo("Articulo B", 1, 10, 10);
            ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);*/
            ticket.lineasIgual();

            //Resumen de la venta. Sólo son ejemplos
            if(tipoCompr != "TICKET")
            {
                ticket.AgregarTotales("         SUBTOTAL......S/", Convert.ToDecimal(subTotal));

                if (dctoInd != "0.00")
                {
                    ticket.AgregarTotales("         DSCTO IND.....S/ ", Convert.ToDecimal(dctoInd));
                }
                if (dctoGral != "0.00")
                {
                    ticket.AgregarTotales("         DSCTO GENERAL.S/ ", Convert.ToDecimal(dctoGral));
                }
                if (redondeo != "0.00")
                {
                    ticket.AgregarTotales("         REDONDEO......S/ ", Convert.ToDecimal(redondeo));
                }
                ticket.AgregarTotales("         IGV...........S/", Convert.ToDecimal(igv));//La M indica que es un decimal en C#
            }


            ticket.AgregarTotales("         TOTAL.........S/", Convert.ToDecimal(total));
            ticket.TextoIzquierda("");


            if (formaPago == "EFECTIVO")
            {
                ticket.AgregarTotales("         EFECTIVO......S/", Convert.ToDecimal(efectivo));
                ticket.AgregarTotales("         VUELTO........S/", Convert.ToDecimal(vuelto));
            }
            else if (formaPago == "TARJETA")
            {
                ticket.TextoIzquierda("         PAGA CON TARJETA");
                ticket.AgregarTotales("         VUELTO........S/", Convert.ToDecimal(vuelto));
            }
            else if (formaPago == "MIXTO")
            {
                ticket.AgregarTotales("         EFECTIVO......S/", Convert.ToDecimal(efectivo));
                ticket.AgregarTotales("         TARJETA.......S/", Convert.ToDecimal(tarjeta));
            }


            //Texto final del Ticket.
           // ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: 3");
            ticket.TextoIzquierda("");
            ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
            if (tipoCompr == "TICKET")
            {
                ticket.TextoIzquierda("Este documento no es un comprobante fiscal");
                ticket.TextoIzquierda("Canjee este documento por una boleta/factura");
            }
            ticket.CortaTicket();
            /*
                      if(tipoCompr == "TICKET")
                      {
                          //ticket.ImprimirTicket("COCINA");//Nombre de la impresora ticketera
                          ticket.ImprimirTicket("Microsoft XPS Document Writer");

                      }
                      else
                      {
                         // ticket.ImprimirTicket("EPSON TM-U220 Receipt");//Nombre de la impresora ticketera
                          ticket.ImprimirTicket("Microsoft XPS Document Writer");

                      }*/
            //
           //  ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera
            ticket.ImprimirTicket("CAJA");//Nombre de la impresora ticketera
           // ticket.ImprimirTicket("CAJA1");

        }


        public static void imprimirComR(int idVenta, string tipoCompr, string cliente, string direccion, string nroDoc,  DataGridView dgGeneral, string dctoInd, string dctoGral, string subTotal, string igv, string total, 
            string efectivo, string vuelto, string tarjeta, string formaPago, string modoProducto, string redondeo, string telefono,string adelanto, string mesero)
        {
            DataTable dtNroCompr;
            NTicket ticket = new NTicket();
            ticket.AbreCajon();

            dtNroCompr = NComprobante.mostrarNroComprobante(idVenta, tipoCompr);
            string nroComprobante = dtNroCompr.Rows[0][0].ToString();
            string nroImpr = "";
            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

            //Datos de la cabecera del Ticket.
            ticket.TextoCentro("D'LALO");
            ticket.TextoCentro("Dulces y Salados");
            ticket.TextoCentro("Inversiones Lalos S.R.L");
            //  ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
            ticket.TextoCentro("AV. MARISCAL CACERES 1243 - Ayacucho");
            ticket.TextoCentro("RUC: 20304455463");
            //ticket.TextoIzquierda("RAZON SOCIAL: JUAN CARLOS RIVERA MEZA");
            //ticket.TextoIzquierda("TELEF: 066 30 3567");
            //ticket.TextoIzquierda("RUC: 10106813731");
            // ticket.TextoIzquierda("EMAIL: jmsolorzano19@gmail.com");//Es el mio por si me quieren contactar ...
            // ticket.TextoIzquierda("");
            for (int i = 0; i < 7 - nroComprobante.Length; i++)
            {
                nroImpr += "0";
            }
            ticket.TextoExtremos("Caja 1", tipoCompr + " 001-" + nroImpr + nroComprobante);
            ticket.lineasAsteriscos();

            //Sub cabecera.
            // ticket.TextoIzquierda("");
            ticket.TextoIzquierda("ATENDIO:" + mesero);
            if (tipoCompr != "TICKET")
            {
                // ticket.TextoIzquierda("ATENDIO:" + mesero);
            }

            if (tipoCompr == "FACTURA")
            {
                ticket.TextoIzquierda("Nro RUC: " + nroDoc);
                ticket.TextoIzquierda("CLIENTE: " + cliente);
                ticket.TextoIzquierda("Dir.: " + direccion);
                if (telefono != "")
                {
                    ticket.TextoIzquierda("Tel: " + telefono);
                }
                ticket.TextoIzquierda("");
            }
            else if (tipoCompr == "BOLETA")
            {
                if (cliente == "")
                {
                    //ticket.TextoIzquierda("CLIENTE: PUBLICO GENERAL ");
                }
                else
                {
                    ticket.TextoIzquierda("CLIENTE: " + cliente);
                    if (direccion != "")
                    {
                        ticket.TextoIzquierda("Dir: " + direccion);
                    }
                    if (telefono != "")
                    {
                        ticket.TextoIzquierda("Tel: " + telefono);
                    }
                    ticket.TextoIzquierda("");
                }

            }

            // ticket.TextoIzquierda("");
            if (tipoCompr != "TICKET")
            {
                //ticket.TextoIzquierda("Salón: " + salon + " Mesa: " + mesa);
            }
            //ticket.TextoIzquierda("Salón: " + salon + " Mesa: " + mesa);
            //ticket.TextoIzquierda("");
            ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
            ticket.lineasAsteriscos();

            //Articulos a vender.
            ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
            ticket.lineasAsteriscos();
            //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
            if (modoProducto == "Detallado")
            {

                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    ticket.AgregaArticulo(Convert.ToInt32(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[5].Value.ToString()));
                    //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
                    // decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
                }
            }
            else if (modoProducto == "Detallados")
            {
                foreach (DataGridViewRow fila in dgGeneral.Rows)//dgvLista es el nombre del datagridview
                {
                    ticket.AgregaArticulo(Convert.ToInt32(fila.Cells[2].Value.ToString()), fila.Cells[1].Value.ToString(), Convert.ToDecimal(fila.Cells[6].Value.ToString()));

                }
            }
            else if (modoProducto == "Por Consumos")
            {
                ticket.AgregaArticulo(1, "POR CONSUMO", Convert.ToDecimal(total));
            }
            else if (modoProducto == "Por Consumo")
            {
                ticket.AgregaArticulo(1, "POR CONSUMO", Convert.ToDecimal(total));
            }

            /*
            ticket.AgregaArticulo("Articulo A", 2, 20, 40);
            ticket.AgregaArticulo("Articulo B", 1, 10, 10);
            ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);*/
            ticket.lineasIgual();

            //Resumen de la venta. Sólo son ejemplos
            if (tipoCompr != "TICKET")
            {
                ticket.AgregarTotales("         SUBTOTAL......S/", Convert.ToDecimal(subTotal));

                if (dctoInd != "00.00")
                {
                    ticket.AgregarTotales("         DSCTO IND.....S/ ", Convert.ToDecimal(dctoInd));
                }
                if (dctoGral != "00.00")
                {
                    ticket.AgregarTotales("         DSCTO GENERAL.S/ ", Convert.ToDecimal(dctoGral));
                }
                if (redondeo != "00.00")
                {
                    ticket.AgregarTotales("         REDONDEO......S/ ", Convert.ToDecimal(redondeo));
                }

          
               
                
                ticket.AgregarTotales("         IGV...........S/", Convert.ToDecimal(igv));//La M indica que es un decimal en C#

            }
            ticket.AgregarTotales("         ADELANTO......S/ ", Convert.ToDecimal(adelanto));
            ticket.AgregarTotales("         TOTAL.........S/", Convert.ToDecimal(total));
            ticket.TextoIzquierda("");


            if (formaPago == "EFECTIVO")
            {
                ticket.AgregarTotales("         EFECTIVO......S/", Convert.ToDecimal(efectivo));
                ticket.AgregarTotales("         VUELTO........S/", Convert.ToDecimal(vuelto));
            }
            else if (formaPago == "TARJETA")
            {
                ticket.TextoIzquierda("         PAGA CON TARJETA");
                ticket.AgregarTotales("         VUELTO........S/", Convert.ToDecimal(vuelto));
            }
            else if (formaPago == "MIXTO")
            {
                ticket.AgregarTotales("         EFECTIVO......S/", Convert.ToDecimal(efectivo));
                ticket.AgregarTotales("         TARJETA.......S/", Convert.ToDecimal(tarjeta));
            }


            //Texto final del Ticket.
            // ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: 3");
            ticket.TextoIzquierda("");
            ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
            if (tipoCompr == "TICKET")
            {
                ticket.TextoIzquierda("Este documento no es un comprobante fiscal");
                ticket.TextoIzquierda("Canjee este documento por una boleta/factura");
            }
            ticket.CortaTicket();
            /*
            if(tipoCompr == "TICKET")
            {
                //ticket.ImprimirTicket("COCINA");//Nombre de la impresora ticketera
                ticket.ImprimirTicket("Microsoft XPS Document Writer");

            }
            else
            {
               // ticket.ImprimirTicket("EPSON TM-U220 Receipt");//Nombre de la impresora ticketera
                ticket.ImprimirTicket("Microsoft XPS Document Writer");

            }*/
            ticket.ImprimirTicket("Microsoft XPS Document Writer");
            //ticket.ImprimirTicket("CAJA");
            //  ticket.ImprimirTicket("EPSON TM-U220 Receipt");//Nombre de la impresora ticketera
        }
    }
}
