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
    public class PropinasController : ControllerBase
    {
        private readonly IRepositorioMesero _repoMesero;
        private readonly MeseroMapper _mapperMesero;

        private readonly IRepositorioVenta _repoVenta;
        private readonly VentaMapper _mapperVenta;

        public PropinasController(IRepositorioMesero repoMesero, MeseroMapper mapeadorMesero,
                                  IRepositorioVenta repoVenta, VentaMapper mapeadorVenta)
        {
            this._repoMesero = repoMesero;
            this._mapperMesero = mapeadorMesero;
            this._repoVenta = repoVenta;
            this._mapperVenta = mapeadorVenta;
        }


        [HttpGet("obtenerpropinas")]
        public string obtenerPropinas()
        {
            List<MeseroDTO> meseros = _mapperMesero.mapearT2T1(_repoMesero.ListarMeseros());//GetMeseros();
            List<VentaDTO> ventas = _mapperVenta.mapearT2T1(_repoVenta.ListarVentas());//GetVentas();

            foreach (var mesero in meseros)
            {
                DateTime fechaIngreso = mesero.FechaIngreso;
                DateTime fechaSalida = mesero.FechaSalida;
                foreach (var venta in ventas)
                {
                    if (venta.Fecha > fechaIngreso && venta.Fecha < fechaSalida)
                    {
                        mesero.Propina += venta.Propina;
                    }
                }
                _repoMesero.EditarMesero(_mapperMesero.mapearT1T2(mesero));
            }
            return "ok";
        }


        // GET: api/<PropinasController>
        [HttpGet ("getmesero")]
        public async Task<List<MeseroDTO>> GetMeseros()
        {
            return _mapperMesero.mapearT2T1(_repoMesero.ListarMeseros());
        }

        // GET api/<PropinasController>/5
        [HttpGet("{Id}")]
        public async Task<MeseroDTO> Get(string Id)
        {
            return _mapperMesero.mapearT2T1(_repoMesero.MeseroById(Id));
        }

        // POST api/<PropinasController>
        [HttpPost]
        public async Task<MeseroDTO> Post([FromBody] MeseroDTO value)
        {
            _repoMesero.AgregarMesero(_mapperMesero.mapearT1T2(value));
            return value;
        }

        // PUT api/<PropinasController>
        [HttpPut]
        public async Task<MeseroDTO> Put([FromBody] MeseroDTO value)
        {
            MeseroDTO meseroEditado = value;
            if (_repoMesero.EditarMesero(_mapperMesero.mapearT1T2(meseroEditado)) != null)
            {
                return meseroEditado;
            }
            else
                return null;
        }

        // DELETE api/<PropinasController>/5
        [HttpDelete("{Id}")]
        public async Task<MeseroDTO> Delete(string Id)
        {
            return _mapperMesero.mapearT2T1(_repoMesero.EliminarMesero(Id));
        }



        // GET: api/<PropinasController>
        [HttpGet ("getventas")]
        public async Task<List<VentaDTO>> GetVentas()
        {
            return _mapperVenta.mapearT2T1(_repoVenta.ListarVentas());
        }
    }
}
