using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Excepciones
{
    /// <summary>
    /// Clase exception para el manejo de errore en la clase producto
    /// </summary>
    [Serializable]
    public class ProductoException : Exception
    {
        public string NombreProducto { get; }
        public ProductoException() { }
        public ProductoException(string mensaje) : base(mensaje) { }
        public ProductoException(string mensaje, Exception inner) : base(mensaje, inner) { }
        public ProductoException(string mensaje, string nombreProducto) : this(mensaje) { NombreProducto = nombreProducto; }

    }
}
