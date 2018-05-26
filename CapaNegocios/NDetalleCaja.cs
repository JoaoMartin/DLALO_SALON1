using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NDetalleCaja
    {
        public static string Insertar(int idCaja, int cantDiezCen, int cantVeinteCen, int cantCincuentaCen, int cantUnSol,
            int cantDosSoles, int cantCincoSoles, int cantDiezSoles, int cantVeinteSoles, int cantCincuentaSoles, int cantCienSoles,
            int cantDoscientosSoles)
        {
            DDetalleCaja Obj = new DDetalleCaja();
            Obj.IdCaja = idCaja;
            Obj.CantDiezCen = cantDiezCen;
            Obj.CantVeinteCen = cantVeinteCen;
            Obj.CantCincuentaCen = cantCincuentaCen;
            Obj.CantUnSol = cantUnSol;
            Obj.CantDosSoles = cantDosSoles;
            Obj.CantCincoSoles = cantCincoSoles;
            Obj.CantDiezSoles = cantDiezSoles;
            Obj.CantVeinteSoles = cantVeinteSoles;
            Obj.CantCincuentaSoles = cantCincuentaSoles;
            Obj.CantCienSoles = cantCienSoles;
            Obj.CantDoscientosSoles = cantDoscientosSoles;
            return Obj.Insertar(Obj);
        }
    }
}
