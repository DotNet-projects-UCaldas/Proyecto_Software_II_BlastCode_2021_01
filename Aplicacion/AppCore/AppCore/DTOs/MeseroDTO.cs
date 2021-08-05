using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.DTOs
{
    /// <summary>
    /// Clase Data Transfer Object para el manejo de la información recibida en el front para el objeto Mesero
    /// </summary>
    
    public class MeseroDTO : PersonaDTO
    {
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public int Propina { get; set; }

        public MeseroDTO(string id, string nombre, string apellido, string cedula, string telefono, string correo, 
                         DateTime fechaIngreso, DateTime fechaSalida, int propina)
            : base(id, nombre, apellido, cedula, telefono, correo)
        {
            FechaIngreso = fechaIngreso;
            FechaSalida = fechaSalida;
            Propina = propina;
        }

        public MeseroDTO()
        {
        }
    }
}
