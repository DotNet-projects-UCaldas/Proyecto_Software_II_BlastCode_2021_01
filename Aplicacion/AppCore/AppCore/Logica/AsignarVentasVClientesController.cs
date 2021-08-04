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

namespace AppCore.Logica
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignarVentasVClientesController : ControllerBase
    {
        private readonly IRepositorioVenta _repositorioVenta;
        private readonly VentaMapper _ventaMapper;

        public AsignarVentasVClientesController(IRepositorioVenta repositorioVenta, VentaMapper ventaMapper)
        {
            this._repositorioVenta = repositorioVenta;
            this._ventaMapper = ventaMapper;
        }

        // GET: api/<AsignarVentasVClientesController>
        [HttpGet]
        public async Task<List<VentaDTO>> Get()
        {
            return _ventaMapper.mapearT2T1(_repositorioVenta.ListarVentas()); ;
        }

        // GET api/<AsignarVentasVClientesController>/5
        [HttpGet("{Id}")]
        public async Task<VentaDTO> Get(string Id)
        {
            return _ventaMapper.mapearT2T1(_repositorioVenta.VentaById(Id));
        }

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
        }
    }
}
