using AccesoDatos.Modelos;
using AppCore.DTOs;
using AppCore.Mapeadores.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Mapeadores
{
    public class VentaMapper : MapperVenta<VentaDTO, VentaModel>
    {
        public override VentaModel mapearT1T2(VentaDTO entrada)
        {
            List<VentaModel> ventas = new List<VentaModel>();
            List<ProductoModel> productos = new List<ProductoModel>();
            ClienteModel cliente = new ClienteModel(){
                Nombre = "ClienteNombre",
                Apellido = "ClienteApellido",
                Cedula = "ClienteCedula",
                Telefono = "ClienteTelefono",
                Correo = "ClienteCorreo",
                Puntos = 100,
                Ventas = ventas
            };
            return new VentaModel()
            {
                Id = entrada.Id,
                Valor = entrada.Valor,
                Fecha = entrada.Fecha,
                Cliente = cliente,
                Productos = productos
            };
        }

        public override IEnumerable<VentaModel> mapearT1T2(IEnumerable<VentaDTO> entrada)
        {
            foreach ( var venta in entrada)
            {
                yield return mapearT1T2(venta);
            }
        }

        public override VentaDTO mapearT2T1(VentaModel entrada)
        {
            List<VentaDTO> ventas = new List<VentaDTO>();
            List<ProductoDTO> productos = new List<ProductoDTO>();
            DTOs.ClienteDTO cliente = new DTOs.ClienteDTO()
            {
                Id = "IdCliente",
                Nombre = "ClienteNombre",
                Apellido = "ClienteApellido",
                Cedula = "ClienteCedula",
                Telefono = "ClienteTelefono",
                Correo = "ClienteCorreo",
                Puntos = 100,
                Ventas = ventas
            };
            return new VentaDTO()
            {
                Id = entrada.Id,
                Valor = entrada.Valor,
                Fecha = entrada.Fecha,
                Cliente = cliente,
                Productos = productos
            };
        }

        public override IEnumerable<VentaDTO> mapearT2T1(IEnumerable<VentaModel> entrada)
        {
            foreach (var venta in entrada)
            {
                yield return mapearT2T1(venta);
            }
        }
    }
}
