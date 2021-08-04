using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.DTOs
{
    public class VentaDTO
    {
        public string Id { get; set; }
        public int Valor { get; set; }
        public DateTime Fecha { get; set; }
        public List<ClienteDTO> Clientes { get; set; }
        public List<ProductoDTO> Productos { get; set; }
        public TipoVenta TipoDeVenta { get; set; }
        public int NumeroMesa { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }
        public VentaDTO(int valor, DateTime fecha, List<ClienteDTO> clientes, List<ProductoDTO> productos,
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

        public VentaDTO()
        {
        }

        public enum TipoVenta
        {
            Mostrador, Mesa, Domicilio
        }
    }
}
