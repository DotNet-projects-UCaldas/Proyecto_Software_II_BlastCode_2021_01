using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Dominio
{
    public class Persona
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public Persona(string nombre, string apellido, string cedula, string telefono, string correo)
        {
            Id = Guid.NewGuid().ToString();
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
            Telefono = telefono;
            Correo = correo;

        }

    }
}
