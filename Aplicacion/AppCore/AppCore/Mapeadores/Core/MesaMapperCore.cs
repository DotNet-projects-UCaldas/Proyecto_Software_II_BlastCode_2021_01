using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.DTOs;
using AppCore.Mapeadores.Abstract;
using AccesoDatos.Modelos;
using AppCore.Dominio;

namespace AppCore.Mapeadores
{
    public class MesaMapperCore: MapperBase<MesaDTO, Mesa>
    {

        private readonly VentaMapperCore _ventaMapper = new VentaMapperCore();

        public override Mesa mapearT1T2(MesaDTO entrada)
        {
            List<Venta> ventas = _ventaMapper.mapearT1T2(entrada.Ventas);

            return new Mesa(entrada.NumeroMesa, (List<Venta>)ventas) {
                Id = entrada.Id
            };
        }

        public override List<Mesa> mapearT1T2(List<MesaDTO> entrada)
        {
            List<Mesa> listaMesas = new List<Mesa>();

            foreach (var mesa in entrada)
            {
                listaMesas.Add(mapearT1T2(mesa));
            }

            return listaMesas;
        }

        public override List<MesaDTO> mapearT2T1(List<Mesa> entrada)
        {
            List<MesaDTO> listaMesas = new List<MesaDTO>();
            foreach (var mesa in entrada)
            {
                listaMesas.Add(mapearT2T1(mesa));
            }

            return listaMesas;
        }


        public override MesaDTO mapearT2T1(Mesa entrada) {
            List<VentaDTO> ventas = _ventaMapper.mapearT2T1(entrada.Ventas);

            return new MesaDTO()
            {
                Id = entrada.Id,
                NumeroMesa = entrada.NumeroMesa,
                Ventas = (List<VentaDTO>)ventas
            };
        }

    }
}
