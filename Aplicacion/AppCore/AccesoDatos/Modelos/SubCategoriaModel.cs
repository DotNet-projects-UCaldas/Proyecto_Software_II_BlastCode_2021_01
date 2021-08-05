using System;
using System.Collections.Generic;

namespace AccesoDatos.Modelos
{
    public class SubCategoriaModel
    {
        // ZONA DE VARIABLES
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        // ZONA DE METODOS
        public SubCategoriaModel()
        {
        }

        public SubCategoriaModel(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }

    }
}