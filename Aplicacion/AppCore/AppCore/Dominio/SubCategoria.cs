using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Dominio
{
    public class SubCategoria
    {
        // ZONA DE VARIABLES
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        // ZONA DE METODOS
        public SubCategoria(string nombre, string descripcion)
        {
            Id = Guid.NewGuid().ToString();
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}
