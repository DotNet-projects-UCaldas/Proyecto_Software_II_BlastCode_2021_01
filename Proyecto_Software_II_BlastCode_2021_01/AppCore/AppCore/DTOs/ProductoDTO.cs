using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.DTOs
{
    public class ProductoDTO
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        public ProductoDTO(string id, string nombre, int precio, string codigo, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Codigo = codigo;
            Descripcion = descripcion;
        }
    }
}
