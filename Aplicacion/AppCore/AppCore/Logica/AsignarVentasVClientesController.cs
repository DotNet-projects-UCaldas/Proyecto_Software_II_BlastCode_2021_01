using AccesoDatos.Interfaces;
using AppCore.DTOs;
using AppCore.Mapeadores;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
/// <summary>
/// Controlador para el manejo del caso de uso asignar venta a diferentes clientes
/// </summary>
namespace AppCore.Logica
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignarVentasVClientesController : ControllerBase
    {
        private readonly IRepositorioVenta _repositorioVenta;
        private readonly VentaMapperCore _ventaMapperCore;
        private readonly VentaMapperDatos _ventaMapperDatos;

        public AsignarVentasVClientesController()
        {

        }

        public AsignarVentasVClientesController(IRepositorioVenta repositorioVenta, VentaMapperCore ventaMapperCore, VentaMapperDatos ventaMapperDatos)
        {
            this._repositorioVenta = repositorioVenta;
            this._ventaMapperCore = ventaMapperCore;
            this._ventaMapperDatos = ventaMapperDatos;
        }

        // GET: api/<AsignarVentasVClientesController>
        /// <summary>
        /// Método para consultar las ventas
        /// </summary>
        /// <returns>Lista de ventas</returns>
        [HttpGet]
        public async Task<List<VentaDTO>> Get()
        {
            return _ventaMapperCore.mapearT2T1(_ventaMapperDatos.mapearT2T1(_repositorioVenta.ListarVentas())); 
        }

        // GET api/<AsignarVentasVClientesController>
        /// <summary>
        /// Método para buscar una venta por el Id
        /// </summary>
        /// <param name="Id">Id de la venta a buscar</param>
        /// <returns>Retorna la venta buscada</returns>
        [HttpGet("{Id}")]
        public async Task<VentaDTO> Get(string Id)
        {
            return _ventaMapperCore.mapearT2T1(_ventaMapperDatos.mapearT2T1(_repositorioVenta.VentaById(Id)));
        }

        // POST api/<AsignarVentasVClientesController>
        /// <summary>
        /// Método para la creación de una venta
        /// </summary>
        /// <param name="value">Objeto venta</param>
        /// <returns>Venta almacenada</returns>
        [HttpPost]
        public async Task<VentaDTO> Post([FromBody] VentaDTO value)
        {
            _repositorioVenta.AgregarVenta(_ventaMapperDatos.mapearT1T2(_ventaMapperCore.mapearT1T2(value)));
            return value;
        }

        // PUT api/<AsignarVentasVClientesController>
        /// <summary>
        /// Método para editar una venta
        /// </summary>
        /// <param name="value">Venta editada</param>
        /// <returns>La venta editada</returns>
        [HttpPut]
        public async Task<VentaDTO> Put([FromBody] VentaDTO value)
        {
            VentaDTO ventaEditada = value;
            if (_repositorioVenta.EditarVenta(_ventaMapperDatos.mapearT1T2(_ventaMapperCore.mapearT1T2(ventaEditada))) != null)
            {
                return ventaEditada;
            }
            else
                return null;
            
        }

        // DELETE api/<AsignarVentasVClientesController>
        /// <summary>
        /// Método para borrar una venta por el número de Id
        /// </summary>
        /// <param name="Id">Id de la venta a eliminar</param>
        /// <returns>venta eliminada</returns>
        [HttpDelete("{Id}")]
        public async Task<VentaDTO> Delete(string Id)
        {
            return _ventaMapperCore.mapearT2T1(_ventaMapperDatos.mapearT2T1(_repositorioVenta.EliminarVenta(Id)));
        }

        /// <summary>
        /// Método del caso de uso: asigna una venta a varios clientes dividiendo el valor
        /// </summary>
        /// <param name="clientes">Clientes a los que se les asigna la venta</param>
        /// <param name="IdVenta">Id de la venta que se está dividiendo</param>
        /// <returns></returns>
        [HttpPost("asignarventavarios")]
        public async Task<List<VentaDTO>> asignarVvC([FromBody] List<ClienteDTO> clientes, string IdVenta)
        {
            VentaDTO venta = _ventaMapperCore.mapearT2T1(_ventaMapperDatos.mapearT2T1(_repositorioVenta.VentaById(IdVenta)));
            venta.Clientes.RemoveAll(c => c.Id != null || c.Id != "");
            int totalParticion = clientes.Count;
            List<VentaDTO> ventasNuevas = new List<VentaDTO>();
            int valorCadaUno = venta.Valor / totalParticion;

            foreach (var cliente in clientes)
            {
                VentaDTO nuevaVenta = new VentaDTO();
                nuevaVenta = venta;
                nuevaVenta.Valor = valorCadaUno;
                nuevaVenta.Clientes.Add(cliente);
                ventasNuevas.Add(nuevaVenta);
                _repositorioVenta.AgregarVenta(_ventaMapperDatos.mapearT1T2(_ventaMapperCore.mapearT1T2(nuevaVenta)));
            }

            venta = _ventaMapperCore.mapearT2T1(_ventaMapperDatos.mapearT2T1(_repositorioVenta.EliminarVenta(IdVenta)));

            return ventasNuevas;
        }
    }
}
