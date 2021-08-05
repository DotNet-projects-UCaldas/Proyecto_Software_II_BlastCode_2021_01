using AccesoDatos.Modelos;
using AppCore.DTOs;
using AppCore.Mapeadores.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Mapeadores
{
    public class VentaMapperCore : MapperBase<VentaDTO, VentaModel>
    {
        private readonly ClienteMapper _clienteMapper = new ClienteMapper();
        private readonly ProductoMapper _productoMapper = new ProductoMapper();
        public override VentaModel mapearT1T2(VentaDTO entrada)
        {
            List<ClienteModel> clientes = _clienteMapper.mapearT1T2(entrada.Clientes);
            List<ProductoModel> productos = _productoMapper.mapearT1T2(entrada.Productos);

            return new VentaModel()
            {
                Id = entrada.Id,
                Valor = entrada.Valor,
                Fecha = entrada.Fecha,
                Clientes = clientes,
                Productos = productos,
                TipoDeVenta = (VentaModel.TipoVenta)entrada.TipoDeVenta,
                NumeroMesa = entrada.NumeroMesa,
                Direccion = entrada.Direccion,
                Estado = entrada.Estado
            };
        }

        public override List<VentaModel> mapearT1T2(List<VentaDTO> entrada)
        {
            List<VentaModel> listaVentas = new List<VentaModel>();
            foreach (var venta in entrada)
            {
                listaVentas.Add(mapearT1T2(venta));
            }

            return listaVentas;
        }

        public override VentaDTO mapearT2T1(VentaModel entrada)
        {
            List<ClienteDTO> clientes = _clienteMapper.mapearT2T1(entrada.Clientes);
            List<ProductoDTO> productos = _productoMapper.mapearT2T1(entrada.Productos);

            return new VentaDTO()
            {
                Id = entrada.Id,
                Valor = entrada.Valor,
                Fecha = entrada.Fecha,
                Clientes = clientes,
                Productos = productos,
                TipoDeVenta = (VentaDTO.TipoVenta)entrada.TipoDeVenta,
                NumeroMesa = entrada.NumeroMesa,
                Direccion = entrada.Direccion,
                Estado = entrada.Estado
            };
        }

        public override List<VentaDTO> mapearT2T1(List<VentaModel> entrada)
        {
            List<VentaDTO> listaVentas = new List<VentaDTO>();
            foreach (var venta in entrada)
            {
                listaVentas.Add(mapearT2T1(venta));
            }

            return listaVentas;
        }

        public enum TipoVenta
        {
            Mostrador, Mesa, Domicilio
        }
    }
}