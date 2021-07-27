using AccesoDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IRepositorioVenta
    {
        public VentaModel AgregarVenta(VentaModel nuevaVenta);
        public VentaModel EditarVenta(VentaModel venta);
        public IEnumerable<VentaModel> ListarVentas();
        public VentaModel EliminarVenta(string Id);

    }
}
