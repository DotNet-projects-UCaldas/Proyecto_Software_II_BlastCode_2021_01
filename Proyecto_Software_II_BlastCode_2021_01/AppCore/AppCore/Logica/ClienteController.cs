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
    public class ClienteController : ControllerBase
    {
        private readonly IRepositorioCliente _repo;
        private readonly ClienteMapper _mapper;
        
        public ClienteController(IRepositorioCliente repo, ClienteMapper mapeadorCliente)
        {
            this._repo = repo;
            this._mapper = mapeadorCliente;
        }

        // GET: api/<VentasController>
        [HttpGet]
        public IEnumerable<ClienteDTO> Get()
        {
            IEnumerable<ClienteDTO> clientes = _mapper.mapearT2T1(_repo.ListarClientes());
            return clientes;
        }

        // GET api/<VentasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VentasController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteDTO cliente)
        {

            
            _repo.AgregarCliente(_mapper.mapearT1T2(cliente));
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
