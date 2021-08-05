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
    public class PropinasController : ControllerBase
    {
        private readonly IRepositorioMesero _repoMesero;
        private readonly MeseroMapper _mapperMesero;

        private readonly IRepositorioVenta _repoVenta;
        private readonly VentaMapper _mapperVenta;

        public PropinasController(IRepositorioMesero repoMesero, MeseroMapper mapeadorMesero, IRepositorioVenta repoVenta, VentaMapper mapeadorVenta)
        {
            this._repoMesero = repoMesero;
            this._mapperMesero = mapeadorMesero;
            this._repoVenta = repoVenta;
            this._mapperVenta = mapeadorVenta;
        }

        public obtenerPropinas()
        {
            //Console.WriteLine("Hola!!!");
            Enumerable<MeseroDTO> meseros = GetMeseros();
            Enumerable<VentaDTO> ventas = GetVentas();

            foreach ( var mesero in meseros)
            {
                DateTime fechaIngreso = mesero.FechaIngreso;
                DateTime fechaSalida = mesero.FechaSalida;
                foreach ( var venta in ventas)
                {
                    if(venta.Fecha > fechaIngreso && venta.Fecha < fechaSalida)
                    {
                        mesero.Propina += venta.Propina;
                    }
                }
                Put(mesero);
            }

        }


        // GET: api/<PropinasController>
        [HttpGet]
        public async Task<List<MeseroDTO>> GetMeseros()
        {
            return _mapperMesero.mapearT2T1(_repoMesero.ListarMeseros());
        }

        // POST api/<PropinasController>
        [HttpPost]
        public async Task<MeseroDTO> Post([FromBody] MeseroDTO value)
        {
            _repoMesero.AgregarMesero(_mapperMesero.mapearT1T2(value));
            return value;
        }

         // PUT api/<AsignarVentasVClientesController>
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

}
