using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Dominio
{
    /// <summary>
    /// Clase para la lógica del dominio del objeto venta
    /// </summary>
    public class Venta
    {
        public string Id { get; set; }
        public int Valor { get; set; }
        public DateTime Fecha { get; set; }
        public List<Cliente> Clientes { get; set; }
        public List<Producto> Productos { get; set; }
        public TipoVenta TipoDeVenta { get; set; }
        public int NumeroMesa { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; } = true;
        public Venta(int valor, DateTime fecha, List<Cliente> clientes, List<Producto> productos,
            TipoVenta tipoVenta, int numeroMesa, string direccion, bool estado)
        {
            Valor = valor;
            Fecha = fecha;
            Clientes = clientes;
            Productos = productos;
            TipoDeVenta = tipoVenta;
            NumeroMesa = numeroMesa;
            Direccion = direccion;
            Estado = estado;


        }

        public Venta()
        {
        }

        public enum TipoVenta
        {
            Mostrador, Mesa, Domicilio
        }

    }
}
