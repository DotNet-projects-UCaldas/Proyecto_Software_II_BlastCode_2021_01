using AccesoDatos.Interfaces;
using AccesoDatos.Modelos;
using AccesoDatos.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.DAOs
{
    public class VentaDAO : IRepositorioVenta
    {
        private readonly RepositorioVentas _repoVentas = new RepositorioVentas();
        public VentaModel AgregarVenta(VentaModel nuevaVenta)
        {
            _repoVentas.AgregarVenta(nuevaVenta);

            return null;
        }

        public VentaModel EditarVenta(VentaModel venta)
        {
            VentaModel ventaEditada = _repoVentas.EditarVenta(venta);

            return ventaEditada;
        }

        public VentaModel EliminarVenta(string Id)
        {
            VentaModel ventaEliminada = _repoVentas.EliminarVenta(Id);

            return ventaEliminada;
        }

        public IEnumerable<VentaModel> ListarVentas()
        {
            List<VentaModel> ventas = _repoVentas.ListarVentas();

            return ventas;
        }
    }
}
