using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class NRedondeo
    {
        public static decimal dec;
        public static decimal resultado;
        public static void setValues(decimal a)
        {
            dec = a;
        }
        public static decimal getResultado()
        {
            return resultado;
        }
        public static void redondeo()
        {
            //resultado = Math.Ceiling(a);
            resultado = Math.Round(dec, 2);
        }

        public static decimal redondearUp(decimal numero1)
        {
            decimal resta, dec, total1, total2;
            resta = 00.00m;
            total1 = 00.00m;
            total2 = 00.00m;
            int numero2 = (int)numero1;
            dec = numero1 - numero2;
            if (dec >= 0.01m && dec <= 0.09m)
            {
                resta = 0.1m - dec;
                total1 = dec + resta;
                total2 = numero2 + total1;
            }
            else if (dec >= 0.11m && dec <= 0.19m)
            {
                resta = 0.2m - dec;
                total1 = dec + resta;
                total2 = numero2 + total1;
            }
            else if (dec >= 0.21m && dec <= 0.29m)
            {
                resta = 0.3m - dec;
                total1 = dec + resta;
                total2 = numero2 + total1;
            }
            else if (dec >= 0.31m && dec <= 0.39m)
            {
                resta = 0.4m - dec;
                total1 = dec + resta;
                total2 = numero2 + total1;
            }
            else if (dec >= 0.41m && dec <= 0.49m)
            {
                resta = 0.5m - dec;
                total1 = dec + resta;
                total2 = numero2 + total1;
            }
            else if (dec >= 0.51m && dec <= 0.59m)
            {
                resta = 0.6m - dec;
                total1 = dec + resta;
                total2 = numero2 + total1;
            }
            else if (dec >= 0.61m && dec <= 0.69m)
            {
                resta = 0.7m - dec;
                total1 = dec + resta;
                total2 = numero2 + total1;
            }

            else if (dec >= 0.71m && dec <= 0.79m)
            {
                resta = 0.8m - dec;
                total1 = dec + resta;
                total2 = numero2 + total1;
            }
            else if (dec >= 0.81m && dec <= 0.89m)
            {
                resta = 0.9m - dec;
                total1 = dec + resta;
                total2 = numero2 + total1;
            }
            else if (dec >= 0.91m && dec <= 0.99m)
            {
                resta = 1 - dec;
                total1 = dec + resta;
                total2 = numero2 + total1;
            }
            else
            {
                total2 = Math.Round(numero1, 2);
            }

            return total2;
        }
    }
}
