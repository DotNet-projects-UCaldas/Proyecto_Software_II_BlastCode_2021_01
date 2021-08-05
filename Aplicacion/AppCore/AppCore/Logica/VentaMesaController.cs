using Microsoft.AspNetCore.Mvc;
using AccesoDatos.Interfaces;
using AppCore.Mapeadores;
using System.Threading.Tasks;
using AppCore.DTOs;
using System.Collections.Generic;

namespace AppCore.Logica
{
    /// <summary>
    ///     Clase con la lógica para generar las principales peticiones de ventas en mesa
    /// </summary>
    /// <remarks>
    ///     Autor: José Cruz
    ///     Versión: 1.0
    /// </remarks>
    [Route("api/[controller]")]
    [ApiController]
    public class VentaMesaController: ControllerBase
    {
        private IRepositorioVenta _venta;
        private IRepositorioMesa _mesa;
        private VentaMapper _mapVenta;
        private MesaMapper _mapMesa;

        public VentaMesaController(IRepositorioVenta venta, IRepositorioMesa mesa, VentaMapper mapVenta, MesaMapper mapMesa) {
            _venta = venta;
            _mesa = mesa;
            _mapVenta = mapVenta;
            _mapMesa = mapMesa;
        }

        // GET: api/<VentaMesaController>
        /// <summary>
        ///     Función encargada de obtener el listado de mesas con sus ventas
        /// </summary>
        /// <returns>
        ///     Las mesas existentes
        /// </returns>
        [HttpGet]
        public async Task<List<MesaDTO>> GetMesas() {
            return _mapMesa.mapearT2T1(_mesa.ListarMesas()); ;
        }

        // GET: api/<VentaMesaController>/5
        /// <summary>
        ///     función encargada de obtener una mesa y sus ventas por su Id
        /// </summary>
        /// <param name="Id">
        ///     El Id de la venta a buscar
        /// </param>
        /// <returns>
        ///     La mesa, si se econtró
        /// </returns>
        [HttpGet("{Id}")]
        public async Task<MesaDTO> GetMesa(string Id) {
            return _mapMesa.mapearT2T1(_mesa.MesaById(Id));
        }

        /// <summary>
        ///     Función encargada de crear una venta asociada a una mesa
        /// </summary>
        /// <param name="venta">
        ///     Toda la información de la venta que se asociará a una mesa
        /// </param>
        /// <param name="Id">
        ///     El Id de la mesa a la que se le asociará la venta
        /// </param>
        /// <returns>
        ///     La Mesa a la que se le asignó la venta con los datos actualizados
        /// </returns>
        public async Task<MesaDTO> crearVentaEnMesa([FromBody] VentaDTO venta, string Id) {
            return null;
        }

        /*
        // POST api/<AsignarVentasVClientesController>
        [HttpPost]
        public async Task<VentaDTO> Post([FromBody] VentaDTO value)
        {
            _repositorioVenta.AgregarVenta(_ventaMapper.mapearT1T2(value));
            return value;
        }

        // PUT api/<AsignarVentasVClientesController>
        [HttpPut]
        public async Task<VentaDTO> Put([FromBody] VentaDTO value)
        {
            VentaDTO ventaEditada = value;
            if (_repositorioVenta.EditarVenta(_ventaMapper.mapearT1T2(ventaEditada)) != null)
            {
                return ventaEditada;
            }
            else
                return null;
            
        }

        // DELETE api/<AsignarVentasVClientesController>/5
        [HttpDelete("{Id}")]
        public async Task<VentaDTO> Delete(string Id)
        {
            return _ventaMapper.mapearT2T1(_repositorioVenta.EliminarVenta(Id));
        }*/
    }
}