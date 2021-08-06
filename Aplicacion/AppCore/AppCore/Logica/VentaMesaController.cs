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
        private IRepositorioCliente _cliente;
        private VentaMapper _mapVenta;
        private MesaMapper _mapMesa;
        private ClienteMapper _mapCliente;

        public VentaMesaController(IRepositorioVenta venta, IRepositorioMesa mesa, VentaMapper mapVenta, MesaMapper mapMesa) {
            _venta = venta;
            _mesa = mesa;
            _mapVenta = mapVenta;
            _mapMesa = mapMesa;
        }

        /// <summary>
        ///     Función encargada de obtener el listado de mesas con sus ventas
        /// </summary>
        /// <returns>
        ///     Las mesas existentes
        /// </returns>
        // GET: api/<VentaMesaController>
        [HttpGet]
        public async Task<List<MesaDTO>> GetMesas() {
            return _mapMesa.mapearT2T1(_mesa.ListarMesas()); ;
        }
        
        /// <summary>
        ///     función encargada de obtener una mesa y sus ventas por su Id
        /// </summary>
        /// <param name="Id">
        ///     El Id de la venta a buscar
        /// </param>
        /// <returns>
        ///     La mesa, si se econtró
        /// </returns>
        // GET: api/<VentaMesaController>/5
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
        // PUT: api/<VentaMesaController>/5
        [HttpPut("{Id}")]
        public async Task<MesaDTO> crearVentaEnMesa([FromBody] VentaDTO venta, string Id) {
            MesaDTO mesa = _mapMesa.mapearT2T1(_mesa.MesaById(Id));

            if (mesa != null) {
                venta = _mapVenta.mapearT2T1(_venta.AgregarVenta(_mapVenta.mapearT1T2(venta)));
                mesa.Ventas.Add(venta);
                mesa = _mapMesa.mapearT2T1(_mesa.EditarMesa(_mapMesa.mapearT1T2(mesa)));
            }

            return mesa;
        }

        /// <summary>
        ///     Función encargada de añadir información de un cliente a la venta
        /// </summary>
        /// <param name="cliente">
        ///     Información del cliente
        /// </param>
        /// <param name="Id">
        ///     El id de la venta 
        /// </param>
        /// <returns>
        ///     La venta actualizada
        /// </returns>
        // PUT: api/<VentaMesaController>/5
        [HttpPut("{Id}")]
        public async Task<VentaDTO> asignarclienteAVenta([FromBody] ClienteDTO cliente, string Id) {
            VentaDTO venta = _mapVenta.mapearT2T1(_venta.VentaById(Id));

            if (venta != null) {
                cliente = _mapCliente.mapearT2T1(_cliente.AgregarCliente(_mapCliente.mapearT1T2(cliente)));
                venta.Clientes.Add(cliente);
                venta = _mapVenta.mapearT2T1(_venta.EditarVenta(_mapVenta.mapearT1T2(venta)));
            }

            return venta;
        }
    }
}