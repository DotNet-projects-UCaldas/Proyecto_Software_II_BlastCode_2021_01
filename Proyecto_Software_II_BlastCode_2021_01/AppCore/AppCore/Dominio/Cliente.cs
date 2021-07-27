using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Dominio
{
    public class Cliente : Persona
    {
        public DateTime FechaRegistro { get; set; }
        public int Puntos { get; set; }
        public List<Venta> Ventas { get; set; }

        public Cliente(string nombre, string apellido, string cedula, string telefono, string correo, int puntos, Venta venta)
            : base(nombre, apellido, cedula, telefono, correo)
        {
            FechaRegistro = DateTime.Now;
            Puntos = puntos;
            Ventas.Add(venta);
        }
    }
}
