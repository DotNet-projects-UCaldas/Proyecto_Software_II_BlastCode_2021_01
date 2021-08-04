using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Modelos
{
    public class PersonaModel
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public PersonaModel(string nombre, string apellido, string cedula, string telefono, string correo)
        {
            Id = Guid.NewGuid().ToString();
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
            Telefono = telefono;
            Correo = correo;

        }

        public PersonaModel()
        {

        }
    }
}
