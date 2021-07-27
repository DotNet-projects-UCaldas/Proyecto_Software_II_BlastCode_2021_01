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
        public ClienteDTO Cliente { get; set; }
        public List<ProductoDTO> Productos { get; set; }
        public VentaDTO(string id, int valor, DateTime fecha, ClienteDTO cliente, List<ProductoDTO> productos)
        {
            Id = id;
            Valor = valor;
            Fecha = fecha;
            Cliente = cliente;
            Productos = productos;
        }

        public VentaDTO()
        {
        }
    }
}
