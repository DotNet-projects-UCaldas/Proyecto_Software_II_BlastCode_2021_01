using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Modelos
{
    public class ClienteModel : PersonaModel
    {
        public DateTime FechaRegistro { get; set; }
        public int Puntos { get; set; }
        
        public ClienteModel(string nombre, string apellido, string cedula, string telefono, string correo, int puntos)
            : base(nombre, apellido, cedula, telefono, correo)
        {
            FechaRegistro = DateTime.Now;
            Puntos = puntos;
        }

        public ClienteModel()
        {
        }
    }
}
