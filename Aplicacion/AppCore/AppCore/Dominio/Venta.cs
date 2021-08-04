using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Dominio
{
    public class Venta
    {
        public string Id { get; set; }
        public int Valor { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }
        public List<Producto> Productos { get; set; }
        
        public Venta(int valor, DateTime fecha, Cliente cliente, List<Producto> productos )
        {
            Id = Guid.NewGuid().ToString(); 
            Valor = valor;
            Fecha = fecha;
            Cliente = cliente;
            Productos = productos;
        }
        
    }
}
