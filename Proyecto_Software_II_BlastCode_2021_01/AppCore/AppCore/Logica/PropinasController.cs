using AccesoDatos.Interfaces;
using AppCore.DTOs;
using AppCore.Dominio;
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
        private readonly MeseroMapperCore _mapperMeseroCore;
        private readonly MeseroMapperDatos _mapperMeseroDatos;

        private readonly IRepositorioVenta _repoVenta;
        private readonly VentaMapperCore _mapperVentaCore;
        private readonly VentaMapperDatos _mapperVentaDatos;

        public PropinasController(IRepositorioMesero repoMesero, MeseroMapperCore mapperMeseroCore, MeseroMapperDatos mapperMeseroDatos,
                                  IRepositorioVenta repoVenta, VentaMapperCore mapperVentaCore, VentaMapperDatos mapperVentaDatos)
        {
            this._repoMesero = repoMesero;
            this._mapperMeseroCore = mapperMeseroCore;
            this._mapperMeseroDatos = mapperMeseroDatos;

            this._repoVenta = repoVenta;
            this._mapperVentaCore = mapperVentaCore;
            this._mapperVentaDatos = mapperVentaDatos;

        }


        [HttpGet("obtenerpropinas")]
        public string obtenerPropinas()
        {
            List<MeseroDTO> meseros = _mapperMeseroCore.mapearT2T1(_mapperMeseroDatos.mapearT2T1(_repoMesero.ListarMeseros()));
            List<VentaDTO> ventas = _mapperVentaCore.mapearT2T1(_mapperVentaDatos.mapearT2T1(_repoVenta.ListarVentas()));


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
                _repoMesero.EditarMesero(_mapperMeseroDatos.mapearT1T2(_mapperMeseroCore.mapearT1T2(mesero)));
            }
            return "ok";
        }


        // GET: api/<PropinasController>
        [HttpGet ("getmeseros")]
        public async Task<List<MeseroDTO>> GetMeseros()
        {
            return _mapperMeseroCore.mapearT2T1(_mapperMeseroDatos.mapearT2T1(_repoMesero.ListarMeseros()));
        }

        // GET api/<PropinasController>/5
        [HttpGet("{Id}")]
        public async Task<MeseroDTO> Get(string Id)
        {
            return _mapperMeseroCore.mapearT2T1(_mapperMeseroDatos.mapearT2T1(_repoMesero.MeseroById(Id)));
        }

        // POST api/<PropinasController>
        [HttpPost]
        public async Task<MeseroDTO> Post([FromBody] MeseroDTO value)
        {
            _repoMesero.AgregarMesero(_mapperMeseroDatos.mapearT1T2(_mapperMeseroCore.mapearT1T2(value)));
            return value;
        }

        // PUT api/<PropinasController>
        [HttpPut]
        public async Task<MeseroDTO> Put([FromBody] MeseroDTO value)
        {
            MeseroDTO meseroEditado = value;
            if (_repoMesero.EditarMesero(_mapperMeseroDatos.mapearT1T2(_mapperMeseroCore.mapearT1T2(value))) != null)
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
            return _mapperMeseroCore.mapearT2T1(_mapperMeseroDatos.mapearT2T1(_repoMesero.EliminarMesero(Id)));
        }



        // GET: api/<PropinasController>
        [HttpGet ("getventas")]
        public async Task<List<VentaDTO>> GetVentas()
        {
            return _mapperVentaCore.mapearT2T1(_mapperVentaDatos.mapearT2T1(_repoVenta.ListarVentas()));
        }
    }
}
