using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Excepciones
{
    /// <summary>
    /// Clase exception para el manejo de errore en la clase venta
    /// </summary>
    public class MeseroException : Exception
    {
        public string IdMesero { get; }
        public MeseroException() { }
        public MeseroException(string mensaje) : base(mensaje) { }
        public MeseroException(string mensaje, Exception inner) : base(mensaje, inner) { }
        public MeseroException(string mensaje, string idMesero) : this(mensaje) { IdMesero = idMesero; }
    }
}
