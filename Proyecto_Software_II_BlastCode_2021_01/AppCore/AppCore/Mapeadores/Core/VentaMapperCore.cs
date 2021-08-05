using AccesoDatos.Modelos;
using AppCore.Dominio;
using AppCore.DTOs;
using AppCore.Mapeadores.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Mapeadores
{
    public class VentaMapperCore : MapperBase<VentaDTO, Venta>
    {
        private readonly ClienteMapperCore _clienteMapper = new ClienteMapperCore();
        private readonly ProductoMapperCore _productoMapper = new ProductoMapperCore();
        public override Venta mapearT1T2(VentaDTO entrada)
        {
            List<Cliente> clientes = _clienteMapper.mapearT1T2(entrada.Clientes);
            List<Producto> productos = _productoMapper.mapearT1T2(entrada.Productos);

            return new Venta()
            {
                Id = entrada.Id,
                Valor = entrada.Valor,
                Fecha = entrada.Fecha,
                Clientes = clientes,
                Productos = productos,
                TipoDeVenta = (Venta.TipoVenta)entrada.TipoDeVenta,
                NumeroMesa = entrada.NumeroMesa,
                Direccion = entrada.Direccion,
                Estado = entrada.Estado,
                Propina = entrada.Propina
            };
        }

        public override List<Venta> mapearT1T2(List<VentaDTO> entrada)
        {
            List<Venta> listaVentas = new List<Venta>();
            foreach (var venta in entrada)
            {
                listaVentas.Add(mapearT1T2(venta));
            }

            return listaVentas;
        }

        public override VentaDTO mapearT2T1(Venta entrada)
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
                Estado = entrada.Estado,
                Propina = entrada.Propina
            };
        }

        public override List<VentaDTO> mapearT2T1(List<Venta> entrada)
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