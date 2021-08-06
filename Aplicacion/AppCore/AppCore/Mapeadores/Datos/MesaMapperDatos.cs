using AccesoDatos.Modelos;
using AppCore.Dominio;
using AppCore.DTOs;
using AppCore.Mapeadores.Abstract;
using AppCore.Mapeadores.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Mapeadores.Datos
{
    /// <summary>
    /// Clase para mapear las ventas del dominio a ventas Modelo de la capa de acceso a datos
    /// </summary>
    public class MesaMapperDatos : MapperBase<Mesa, MesaModel>
    {
        private readonly VentaMapperDatos _ventaMapperDatos = new VentaMapperDatos();

        public override MesaModel mapearT1T2(Mesa entrada)
        {
            List<VentaModel> ventas = _ventaMapperDatos.mapearT1T2(entrada.Ventas);

            return new MesaModel(entrada.NumeroMesa, (List<VentaModel>)ventas) {
                Id = entrada.Id
            };
        }

         public override List<MesaModel> mapearT1T2(List<Mesa> entrada)
        {
            List<MesaModel> listaMesas = new List<MesaModel>();

            foreach (var mesa in entrada)
            {
                listaMesas.Add(mapearT1T2(mesa));
            }

            return listaMesas;
        }

        public override List<Mesa> mapearT2T1(List<MesaModel> entrada)
        {
            List<Mesa> listaMesas = new List<Mesa>();
            foreach (var mesa in entrada)
            {
                listaMesas.Add(mapearT2T1(mesa));
            }

            return listaMesas;
        }


        public override Mesa mapearT2T1(MesaModel entrada) {
            List<Venta> ventas = _ventaMapperDatos.mapearT2T1(entrada.Ventas);

            return new Mesa(entrada.NumeroMesa, (List<Venta>)ventas) {
                Id = entrada.Id,
            };
        }

    }
}