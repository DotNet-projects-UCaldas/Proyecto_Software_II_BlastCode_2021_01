using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.DTOs
{
    public class MeseroDTO : PersonaDTO
    {
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public int Propina { get; set; }

        public MeseroDTO(string id, string nombre, string apellido, string cedula, string telefono, string correo, DateTime fechaIngreso, DateTime fechaSalida, int propina)
            : base(id, nombre, apellido, cedula, telefono, correo)
        {
            FechaRegistro = fechaIngreso;
            FechaSalida = fechaSalida;
            Propina = propina;
        }

        public MeseroDTO()
        {
        }
    }
}
