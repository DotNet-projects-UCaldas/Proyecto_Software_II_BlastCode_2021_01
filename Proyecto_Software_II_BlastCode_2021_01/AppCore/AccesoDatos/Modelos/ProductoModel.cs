using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Modelos
{
    public class ProductoModel
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        public ProductoModel(string nombre, int precio, string codigo, string descripcion)
        {
            Nombre = nombre;
            Precio = precio;
            Codigo = codigo;
            Descripcion = descripcion;
        }
    }
}
