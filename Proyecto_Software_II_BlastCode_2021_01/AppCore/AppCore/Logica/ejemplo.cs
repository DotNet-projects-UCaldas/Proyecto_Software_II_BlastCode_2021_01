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
    public class VentasMostradorController : ControllerBase
    {
        private readonly IRepositorioVenta _repo;
        private readonly VentaMapper _mapper;
        private readonly IRepositorioCliente _repoCliente;
        private readonly ClienteMapper _mapperCliente;
        public VentasMostradorController(IRepositorioVenta repo, VentaMapper mapeadorVenta)
        {
            this._repo = repo;
            this._mapper = mapeadorVenta;
        }

        // GET: api/<VentasController>
        [HttpGet]
        public IEnumerable<VentaDTO> Get()
        {
            IEnumerable<VentaDTO> ventas = _mapper.mapearT2T1(_repo.ListarVentas());
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

            var clienteDto = venta.Clientes.FirstOrDefault();
            var clienteModel = _mapperCliente.mapearT1T2(clienteDto);
            var clientes = _repoCliente.ListarClientes();

            if (clientes.Contains(clienteModel))
            {
                clienteModel.Puntos += venta.Valor / 1000;
                venta.Clientes[0] = _mapperCliente.mapearT2T1(clienteModel);
            }
            else {

                _repo.AgregarVenta(_mapper.mapearT1T2(venta));
            }
                       
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
