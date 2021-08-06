using AccesoDatos.Interfaces;
using AccesoDatos.Modelos;
using AccesoDatos.Repositorios;
using AppCore.DTOs;
using AppCore.Mapeadores;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppCore.Logica
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly IRepositorioVenta _repo;
        private readonly VentaMapperCore _ventaMapperCore;
        private readonly VentaMapperDatos _ventaMapperDatos;
        public VentasController(IRepositorioVenta repo, VentaMapperCore ventaMapperCore, VentaMapperDatos ventaMapperDatos)
        {
            this._repo = repo;
            this._ventaMapperCore = ventaMapperCore;
            this._ventaMapperDatos = ventaMapperDatos;
        }

        // GET: api/<VentasController>
        [HttpGet]
        public IEnumerable<VentaDTO> Get()
        {
            IEnumerable<VentaDTO> ventas = _ventaMapperCore.mapearT2T1(_ventaMapperDatos.mapearT2T1(_repo.ListarVentas()));
            return ventas;
        }

        // GET api/<VentasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VentasController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VentaDTO venta)
        {
            _repo.AgregarVenta(_ventaMapperDatos.mapearT1T2(_ventaMapperCore.mapearT1T2(venta)));
            return NoContent();
        }

        // PUT api/<VentasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VentasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}