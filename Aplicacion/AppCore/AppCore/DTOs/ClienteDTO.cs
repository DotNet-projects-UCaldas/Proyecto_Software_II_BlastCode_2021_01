using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.DTOs
{
    /// <summary>
    /// Clase Data Transfer Object para el manejo de la información recibida en el front para el objeto cliente
    /// </summary>
    public class ClienteDTO : PersonaDTO
    {
        public DateTime FechaRegistro { get; set; }
        public int Puntos { get; set; }
        public ClienteDTO(string id, string nombre, string apellido, string cedula, string telefono, string correo, int puntos)
            : base(id, nombre, apellido, cedula, telefono, correo)
        {
            FechaRegistro = DateTime.Now;
            Puntos = puntos;
        }

        public ClienteDTO()
        {
        }
    }
}
