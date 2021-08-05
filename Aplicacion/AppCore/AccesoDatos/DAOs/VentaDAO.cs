using AccesoDatos.Interfaces;
using AccesoDatos.Modelos;
using AccesoDatos.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.DAOs
{
    /// <summary>
    /// Clase Data Access Object para gestionar la Clase VentaModelo
    /// </summary>
    public class VentaDAO : IRepositorioVenta
    {
        private readonly RepositorioVentas _repoVentas = new RepositorioVentas();
        /// <summary>
        /// Método para agregar una nueva venta
        /// </summary>
        /// <param name="nuevaVenta">Venta a agregar</param>
        /// <returns>La venta agregada</returns>
        public VentaModel AgregarVenta(VentaModel nuevaVenta)
        {
            VentaModel ventaGuardada = _repoVentas.AgregarVenta(nuevaVenta);

            return ventaGuardada;
        }
        /// <summary>
        /// Método para guardar una venta editada
        /// </summary>
        /// <param name="venta">Venta editada</param>
        /// <returns>Venta editada</returns>
        public VentaModel EditarVenta(VentaModel venta)
        {
            VentaModel ventaEditada = _repoVentas.EditarVenta(venta);

            return ventaEditada;
        }
        /// <summary>
        /// Método para eliminar una venta
        /// </summary>
        /// <param name="Id">Id de la venta a eliminar</param>
        /// <returns>La venta eliminada</returns>
        public VentaModel EliminarVenta(string Id)
        {
            VentaModel ventaEliminada = _repoVentas.EliminarVenta(Id);

            return ventaEliminada;
        }
        /// <summary>
        /// Método que retorna las ventas
        /// </summary>
        /// <returns>Lista de ventas VentaModel</returns>
        public List<VentaModel> ListarVentas()
        {
            List<VentaModel> ventas = _repoVentas.ListarVentas();

            return ventas;
        }

        public VentaModel VentaById(string Id)
        {
            return _repoVentas.VentaById(Id);
        }
    }
}
