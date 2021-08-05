using AccesoDatos.Modelos;
using AppCore.Dominio;
using AppCore.DTOs;
using AppCore.Mapeadores.Abstract;
using AppCore.Mapeadores.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Mapeadores
{
    /// <summary>
    /// Clase para mapear las ventas del dominio a ventas Modelo de la capa de acceso a datos
    /// </summary>
    public class VentaMapperDatos : MapperBase<Venta, VentaModel>
    {
        private readonly ClienteMapperDatos _clienteMapperDatos = new ClienteMapperDatos();
        private readonly ProductoMapperDatos _productoMapperDatos = new ProductoMapperDatos();
        public override VentaModel mapearT1T2(Venta entrada)
        {
            List<ClienteModel> clientes = _clienteMapperDatos.mapearT1T2(entrada.Clientes);
            List<ProductoModel> productos = _productoMapperDatos.mapearT1T2(entrada.Productos);

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

        public override List<VentaModel> mapearT1T2(List<Venta> entrada)
        {
            List<VentaModel> listaVentas = new List<VentaModel>();
            foreach (var venta in entrada)
            {
                listaVentas.Add(mapearT1T2(venta));
            }

            return listaVentas;
        }

        public override Venta mapearT2T1(VentaModel entrada)
        {
            List<Cliente> clientes = _clienteMapperDatos.mapearT2T1(entrada.Clientes);
            List<Producto> productos = _productoMapperDatos.mapearT2T1(entrada.Productos);

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
                Estado = entrada.Estado
            };
        }

        public override List<Venta> mapearT2T1(List<VentaModel> entrada)
        {
            List<Venta> listaVentas = new List<Venta>();
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