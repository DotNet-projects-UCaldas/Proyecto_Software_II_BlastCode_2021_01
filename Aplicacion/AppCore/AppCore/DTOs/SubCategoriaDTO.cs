using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.DTOs
{
    public class SubCategoriaDTO
    {
        // ZONA DE VARIABLES
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        // ZONA DE METODOS
        public SubCategoriaDTO()
        {
        }

        public SubCategoriaDTO(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}
