using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Excepciones
{
    /// <summary>
    /// Clase exception para el manejo de errores en la clase venta
    /// </summary>
    [Serializable]
    public class VentaException : Exception
    {
        public string IdVenta { get; }
        public VentaException() { }
        public VentaException(string mensaje) : base(mensaje) { }
        public VentaException(string mensaje, Exception inner) : base(mensaje, inner) { }
        public VentaException(string mensaje, string idVenta) : this(mensaje) { IdVenta = idVenta; }

    }
}
