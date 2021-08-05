using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Modelos
{
    public class MeseroModel : PersonaModel
    {
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public int Propina { get; set; }
        
        public MeseroModel(string nombre, string apellido, string cedula, string telefono, string correo, DateTime fechaIngreso, DateTime fechaSalida, int propina)
            : base(nombre, apellido, cedula, telefono, correo)
        {
            FechaRegistro = fechaIngreso;
            FechaSalida = fechaSalida;
            Propina = propina;
        }

        public MeseroModel()
        {
        }
    }
}