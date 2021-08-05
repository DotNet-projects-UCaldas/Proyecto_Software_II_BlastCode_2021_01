using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Dominio
{
    public class Mesero : Persona
    {
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public int Propina { get; set; }

        public Mesero(string nombre, string apellido, string cedula, string telefono, string correo, 
                      DateTime fechaIngreso, DateTime fechaSalida, int propina)
            : base(nombre, apellido, cedula, telefono, correo)
        {
            FechaIngreso = fechaIngreso;
            FechaSalida = fechaSalida;
            Propina = propina;
        }
    }
}
