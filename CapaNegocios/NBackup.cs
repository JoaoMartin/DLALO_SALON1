using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NBackup
    {
        public static string realizarBackup()
        {
            return new DBackup().realizarBackup();
        }
    }
}
