using AccesoDatos.Interfaces;
using AccesoDatos.Repositorios;
using AppCore.DTOs;
using AppCore.Mapeadores;
using AppCore.Mapeadores.Datos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
/// <summary>
/// Controlador para el manejo del caso de uso Regustrar ventas por mostrador
/// </summary>
namespace AppCore.Logica
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasMostradorController : ControllerBase
    {
        private readonly IRepositorioVenta _repositorioVentas;
        private readonly VentaMapperCore _ventaMapperCore;
       
        private readonly VentaMapperDatos _ventaMapperDatos;
        private readonly IRepositorioCliente _repoCliente;

        private readonly ClienteMapperCore _clienteMapperCore;
        private readonly ClienteMapperDatos _clienteMapperDatos;


        public VentasMostradorController(IRepositorioVenta repositorioVenta, VentaMapperCore mapeadorVentaCore,
            IRepositorioCliente repoCliente, VentaMapperDatos ventaMapperDatos, 
            ClienteMapperDatos clienteMapperDatos, ClienteMapperCore clienteMapperCore)
        {
            this._repositorioVentas = repositorioVenta;
            this._ventaMapperCore = mapeadorVentaCore;
            this._repoCliente = repoCliente;
            this._ventaMapperDatos = ventaMapperDatos;
            this._clienteMapperDatos = clienteMapperDatos;
            this._clienteMapperCore = clienteMapperCore;


        }

        // GET: api/<VentasMostradorController>
        /// <summary>
        /// Método para consultar las ventas
        /// </summary>
        /// <returns>Lista de ventas</returns>
        [HttpGet]
        public IEnumerable<VentaDTO> Get()
        {
            return _ventaMapperCore.mapearT2T1(_ventaMapperDatos.mapearT2T1(_repositorioVentas.ListarVentas())); 
        }

        // GET api/<VentasMostradorController>/5
         /// <summary>
        /// Método para buscar una venta por el Id
        /// </summary>
        /// <param name="Id">Id de la venta a buscar</param>
        /// <returns>Retorna la venta buscada</returns>
        [HttpGet("{id}")]
        public VentaDTO Get(string id)
        {
          return _ventaMapperCore.mapearT2T1(_ventaMapperDatos.mapearT2T1(_repositorioVentas.VentaById(id)));
        }

        // POST api/<VentasMostradorController>
        /// <summary>
        /// Método para la creación de una venta
        /// </summary>
        /// <param name="value">Objeto venta</param>
        /// <returns>Venta almacenada</returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VentaDTO venta)
        {

            var clientes =  _clienteMapperCore.mapearT2T1(_clienteMapperDatos.mapearT2T1(_repoCliente.ListarClientes()));

            foreach(var cliente in clientes)
            {
                foreach(var clienteVenta in venta.Clientes)
                {
                    if (clienteVenta.Id == cliente.Id)
                    {
                        cliente.Puntos += venta.Valor / 1000;

                        _repoCliente.EditarCliente(_clienteMapperDatos.mapearT1T2(_clienteMapperCore.mapearT1T2(cliente)));

                    }
                }
            }
            _repositorioVentas.AgregarVenta(_ventaMapperDatos.mapearT1T2(_ventaMapperCore.mapearT1T2(venta)));
            return NoContent();
        }

       

        // PUT api/<VentasMostradorController>/5
         /// <summary>
        /// Método para editar una venta que se encuentra guardada en el sistema 
        /// </summary>
        /// <param name="value">Objeto venta</param>
        /// <returns>Venta almacenada</returns>
        [HttpPut]
        public async Task<VentaDTO> Put([FromBody] VentaDTO value)
        {
            VentaDTO ventaEditada = value;
            if (_repositorioVentas.EditarVenta(_ventaMapperDatos.mapearT1T2(_ventaMapperCore.mapearT1T2(ventaEditada))) != null)
            {
                return ventaEditada;
            }
            else
                return null;
            
        }

        // PUT api/<VentasMostradorController>
        /// <summary>
        /// Método para cerrar una cuenta ya registrada
        /// </summary>
        /// <param name="Id">Id de la venta a cerrar</param>
        /// <returns>venta eliminada</returns>
        [HttpPut("confirmarVenta")]
        public async Task<VentaDTO> confirmarVenta(string IdVenta)
        {
            VentaDTO venta = _ventaMapperCore.mapearT2T1(_ventaMapperDatos.mapearT2T1(_repositorioVentas.VentaById(IdVenta)));
            venta.Estado = false;
            if (_repositorioVentas.EditarVenta(_ventaMapperDatos.mapearT1T2(_ventaMapperCore.mapearT1T2(venta))) != null)
            {
                return venta;
            }
            else
                return null;

        }


        // DELETE api/<VentasMostradorController>
        /// <summary>
        /// Método para borrar una venta por el número de Id
        /// </summary>
        /// <param name="Id">Id de la venta a eliminar</param>
        /// <returns>venta eliminada</returns>
        [HttpDelete("{Id}")]
        public async Task<VentaDTO> Delete(string Id)
        {
            return _ventaMapperCore.mapearT2T1(_ventaMapperDatos.mapearT2T1(_repositorioVentas.EliminarVenta(Id)));
        }
    }
}
