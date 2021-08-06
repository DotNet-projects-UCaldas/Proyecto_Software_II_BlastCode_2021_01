using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Excepciones
{
    /// <summary>
    /// Clase exception para el manejo de errore en la clase cliente
    /// </summary>
    [Serializable]
    public class ClienteException : Exception
    {
        public string NombreCliente { get; }
        public ClienteException() { }
        public ClienteException(string mensaje) : base(mensaje) { }
        public ClienteException(string mensaje, Exception inner) : base(mensaje, inner) { }
        public ClienteException(string mensaje, string nombreCliente) : this(mensaje) { NombreCliente = nombreCliente; }

    }
}
