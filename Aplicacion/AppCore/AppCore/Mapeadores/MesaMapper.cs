using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.DTOs;
using AppCore.Mapeadores.Abstract;
using AccesoDatos.Modelos;

namespace AppCore.Mapeadores
{
    public class MesaMapper: MapperMesa<MesaDTO, MesaModel>
    {
        private readonly VentaMapper _ventaMapper = new VentaMapper();

        public override MesaModel mapearT1T2(MesaDTO entrada)
        {
            List<VentaModel> ventas = _ventaMapper.mapearT1T2(entrada.Ventas);

            return new MesaModel()
            {
                Id = entrada.Id,
                NumeroMesa = entrada.NumeroMesa,
                Ventas = (List<VentaModel>)ventas
            };
        }

        public override List<MesaModel> mapearT1T2(List<MesaDTO> entrada)
        {
            List<MesaModel> listaMesas = new List<MesaModel>();

            foreach (var mesa in entrada)
            {
                listaMesas.Add(mapearT1T2(mesa));
            }

            return listaMesas;
        }

        public override List<MesaDTO> mapearT2T1(List<MesaModel> entrada)
        {
            List<MesaDTO> listaMesas = new List<MesaDTO>();
            foreach (var mesa in entrada)
            {
                listaMesas.Add(mapearT2T1(mesa));
            }

            return listaMesas;
        }


        public override MesaDTO mapearT2T1(MesaModel entrada) {
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
