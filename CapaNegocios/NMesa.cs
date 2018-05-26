using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;


namespace CapaNegocios
{
    public class NMesa
    {
        public static string Insertar(string nombre, string estadoTipo, int idSalon, string estadoMesa)
        {
            DMesa Obj = new DMesa();
            Obj.Nombre = nombre;
            Obj.EstadoTipo = estadoTipo;
            Obj.IdSalon = idSalon;
            Obj.EstadoMesa = estadoMesa;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idMesa, string nombre, string estadoTipo, int idSalon,  string estadoMesa)
        {
            DMesa Obj = new DMesa();
            Obj.IdMesa = idMesa;
            Obj.Nombre = nombre;
            Obj.EstadoTipo = estadoTipo;
            Obj.IdSalon = idSalon;
            Obj.EstadoMesa = estadoMesa;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idMesa)
        {
            DMesa Obj = new DMesa();
            Obj.IdMesa = idMesa;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar(int idSalon)
        {
            DMesa Obj = new DMesa();
            Obj.IdSalon = idSalon;
            return new DMesa().Mostrar(Obj);
        }

        public static DataTable MostrarLibre(int idSalon)
        {
            DMesa Obj = new DMesa();
            Obj.IdSalon = idSalon;
            return new DMesa().MostrarLibre(Obj);
        }

        public static DataTable MostrarEstado(int idSalon)
        {
            DMesa Obj = new DMesa();
            Obj.IdSalon = idSalon;
            return new DMesa().MostrarEstadoMesa(Obj);
        }
        public static DataTable mostrarIdVentaMesa(int idMesa)
        {
            DMesa Obj = new DMesa();
            return Obj.MostrarIdVentaMesa(idMesa);
        }

        public static string EditarEstadoMesa(int idMesa, string estado)
        {
            DMesa Obj = new DMesa();
            Obj.IdMesa = idMesa;
            Obj.EstadoTipo = estado;
            return Obj.EditarEstadoMesa(Obj);
        }
    }
}
