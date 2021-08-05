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
       
       
        public VentasMostradorController(IRepositorioVenta repo, VentaMapper mapeadorVenta, IRepositorioCliente repoCliente)
        {
            this._repo = repo;
            this._mapper = mapeadorVenta;
            this._repoCliente = repoCliente;
           
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
        public VentaDTO Get(string id)
        {
            return _mapper.mapearT2T1(_repo.VentaById(id));
        }

        // POST api/<VentasController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VentaDTO venta)
        {

            var clientes = _repoCliente.ListarClientes();

            foreach(var cliente in clientes)
            {
                foreach(var clienteVenta in venta.Clientes)
                {
                    if (clienteVenta.Id == cliente.Id)
                    {
                        cliente.Puntos += venta.Valor / 1000;
                        
                        _repoCliente.EditarCliente(cliente);
                    }
                }
            }
            _repo.AgregarVenta(_mapper.mapearT1T2(venta));
            return NoContent();
        }

       

        // PUT api/<VentasController>/5
        [HttpPut]
        public void Put([FromBody] VentaDTO venta)
        {
            _repo.EditarVenta(_mapper.mapearT1T2(venta));
        }


        // DELETE api/<VentasController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _repo.EliminarVenta(id);
        }
        
        [HttpCerrar("{id}")]
        public void Cerrar(string id)
        {
            
        }
    }
}
