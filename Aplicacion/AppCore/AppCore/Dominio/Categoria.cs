using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Dominio
{
    public class Categoria
    {
         // ZONA DE VARIABLES
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<SubCategoria> SubCategorias { get; set; }

        // ZONA DE METODOS 
        public Categoria(string nombre, string descripcion, List<SubCategoria> subCategorias)
        {
            Id = Guid.NewGuid().ToString(); 
            Nombre = nombre;
            Descripcion = descripcion;
            SubCategorias = subCategorias;
        }
    }
}
