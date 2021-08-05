using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.DTOs
{
    public class CategoriaDTO
    {
        // ZONA DE VARIABLES
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<SubCategoriaDTO> SubCategorias { get; set; }

        // ZONA DE METODOS
        public CategoriaDTO()
        {
        }

        public CategoriaDTO(string nombre, string descripcion, List<SubCategoriaDTO> subCategorias)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            SubCategorias = subCategorias;
        }
    }
}
