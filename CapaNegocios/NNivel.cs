using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NNivel
    {
        public static string Insertar(int idModulo, int idTipoTrabajador)
        {
            DNivel Obj = new DNivel();
            Obj.IdModulo = idModulo;
            Obj.IdTipoTrabajador = idTipoTrabajador;
            return Obj.Insertar(Obj);
        }

        public static string Eliminar(int idNivel)
        {
            DNivel Obj = new DNivel();
            Obj.IdNivel = idNivel;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar(int idTipoTrabajador)
        {
            return new DNivel().Mostrar(idTipoTrabajador);
        }
    }
}
