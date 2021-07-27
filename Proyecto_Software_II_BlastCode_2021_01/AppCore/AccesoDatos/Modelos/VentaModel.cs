using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Modelos
{
    public class VentaModel
    {
        public string Id { get; set; }
        public int Valor { get; set; }
        public DateTime Fecha { get; set; }
        public ClienteModel Cliente { get; set; }
        public List<ProductoModel> Productos { get; set; }
        public VentaModel(int valor, DateTime fecha, ClienteModel cliente, List<ProductoModel> productos)
        {
            Valor = valor;
            Fecha = fecha;
            Cliente = cliente;
            Productos = productos;
        }

        public VentaModel()
        {
        }
    }
}
