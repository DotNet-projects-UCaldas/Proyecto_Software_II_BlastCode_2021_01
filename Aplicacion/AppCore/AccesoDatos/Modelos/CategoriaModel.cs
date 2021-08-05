using System;
using System.Collections.Generic;

namespace AccesoDatos.Modelos
{
    public class CategoriaModel
    {
        // ZONA DE VARIABLES
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<SubCategoriaModel> SubCategorias { get; set; }

        // ZONA DE METODOS
        public CategoriaModel()
        {
        }

        public CategoriaModel(string nombre, string descripcion, List<SubCategoriaModel> subCategorias)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            SubCategorias = subCategorias;
        }
    }
}