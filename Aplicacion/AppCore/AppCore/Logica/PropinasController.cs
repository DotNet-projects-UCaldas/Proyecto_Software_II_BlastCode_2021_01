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
/// <summary>
/// Controlador para el manejo del caso de uso Repartir propina
/// </summary>

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

        // <summary>
        /// Método del caso de uso: Reparte propinas entre los diferentes meseros
        /// </summary>
        /// <returns>Meseros con propina actualizada</returns>
        [HttpGet("obtenerpropinas")]
        public List<MeseroDTO> obtenerPropinas()
        {
            List<MeseroDTO> meseros = _mapperMeseroCore.mapearT2T1(_mapperMeseroDatos.mapearT2T1(_repoMesero.ListarMeseros()));
            List<VentaDTO> ventas = _mapperVentaCore.mapearT2T1(_mapperVentaDatos.mapearT2T1(_repoVenta.ListarVentas()));


            /*foreach (var mesero in meseros)
            {
                DateTime fechaIngreso = mesero.FechaIngreso;
                DateTime fechaSalida = mesero.FechaSalida;
                mesero.Propina = 0;
                foreach (var venta in ventas)
                {
                    if (venta.Fecha > fechaIngreso && venta.Fecha < fechaSalida)
                    {
                        mesero.Propina += venta.Propina;
                    }
                }
                _repoMesero.EditarMesero(_mapperMeseroDatos.mapearT1T2(_mapperMeseroCore.mapearT1T2(mesero)));
            }*/
            foreach (var mesero in meseros)
            {
                mesero.Propina = 0;
            }
            int k = 0;
            foreach (var venta in ventas)
            {
                k = 0;
                foreach (var mesero in meseros)
                {
                    if (venta.Fecha > mesero.FechaIngreso && venta.Fecha < mesero.FechaSalida)
                    {
                        k++;
                    }
                }
                foreach (var mesero in meseros)
                {
                    if (venta.Fecha > mesero.FechaIngreso && venta.Fecha < mesero.FechaSalida)
                    {
                        mesero.Propina += venta.Propina / k;
                    }
                }
            }

            foreach (var mesero in meseros)
            {
                _repoMesero.EditarMesero(_mapperMeseroDatos.mapearT1T2(_mapperMeseroCore.mapearT1T2(mesero)));
            }

            //return "ok";
            return _mapperMeseroCore.mapearT2T1(_mapperMeseroDatos.mapearT2T1(_repoMesero.ListarMeseros()));

        }


        // GET: api/<PropinasController>
        /// <summary>
        /// Método para consultar los Meseros
        /// </summary>
        /// <returns>Lista de meseros</returns>
        [HttpGet ("getmeseros")]
        public async Task<List<MeseroDTO>> GetMeseros()
        {
            return _mapperMeseroCore.mapearT2T1(_mapperMeseroDatos.mapearT2T1(_repoMesero.ListarMeseros()));
        }

        // GET api/<PropinasController>/5
        /// <summary>
        /// Método para buscar un mesero por el Id
        /// </summary>
        /// <param name="Id">Id del mesero a buscar</param>
        /// <returns>Retorna el mesero buscado</returns>
        [HttpGet("{Id}")]
        public async Task<MeseroDTO> Get(string Id)
        {
            return _mapperMeseroCore.mapearT2T1(_mapperMeseroDatos.mapearT2T1(_repoMesero.MeseroById(Id)));
        }

        // POST api/<PropinasController>
        /// <summary>
        /// Método para la creación de un mesero
        /// </summary>
        /// <param name="value">Objeto mesero</param>
        /// <returns>Mesero almacenado</returns>
        [HttpPost]
        public async Task<MeseroDTO> Post([FromBody] MeseroDTO value)
        {
            _repoMesero.AgregarMesero(_mapperMeseroDatos.mapearT1T2(_mapperMeseroCore.mapearT1T2(value)));
            return value;
        }

        // PUT api/<PropinasController>
        /// <summary>
        /// Método para editar un mesero
        /// </summary>
        /// <param name="value">Mesero editado</param>
        /// <returns>El mesero editado</returns>
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
        /// <summary>
        /// Método para borrar un mesero por el número de Id
        /// </summary>
        /// <param name="Id">Id del mesero a eliminar</param>
        /// <returns>mesero eliminado</returns>
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
