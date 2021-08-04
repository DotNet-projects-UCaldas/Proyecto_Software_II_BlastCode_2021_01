using AccesoDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Dominio
{
    public class Mesa
    {
        public string Id { get; set; }
        public int NumeroMesa { get; set; }
        public List<Venta> Ventas { get; set; }

        public Mesa(int numeroMesa, List<Venta> ventas)
        {
            Id = Guid.NewGuid().ToString();
            NumeroMesa = numeroMesa;
            Ventas = ventas;
        }

    }
}
