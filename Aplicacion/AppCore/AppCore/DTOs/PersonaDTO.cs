using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.DTOs
{
    /// <summary>
    /// Clase Data Transfer Object para el manejo de la información recibida en el front para el objeto persona del que heredan cliente y mesero
    /// </summary>
    public class PersonaDTO
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public PersonaDTO(string id, string nombre, string apellido, string cedula, string telefono, string correo)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
            Telefono = telefono;
            Correo = correo;

        }

        public PersonaDTO()
        {

        }
    }
}
