using AccesoDatos.Interfaces;
using AppCore.DTOs;
using AppCore.Logica;
using AppCore.Mapeadores;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestAppCore
{
    [TestClass]
    public class UnitTestAvVcController
    {
        public static IRepositorioVenta _repositorioVenta;
        public static VentaMapperCore _ventaMapperCore;
        public static VentaMapperDatos _ventaMapperDatos;
       // public AsignarVentasVClientesController _controller = new AsignarVentasVClientesController();
        [TestMethod]
        public void GetM()
        {
            AsignarVentasVClientesController _controller = new AsignarVentasVClientesController();
            VentaDTO nuevaVenta = new VentaDTO();
            ClienteDTO clienteDTO = new ClienteDTO();
            ProductoDTO productoDTO = new ProductoDTO();
            List<VentaDTO> lista = new List<VentaDTO>();

            clienteDTO.Id = "7557d7e3-52af-4353-9a5c-e0297bd80798";
            clienteDTO.Nombre = "Prueba";
            clienteDTO.Apellido = "Apellido Prueba";
            clienteDTO.Cedula = "12345678Z";
            clienteDTO.Telefono = "55555555X";
            clienteDTO.Correo = "cliente@correo.com";
            clienteDTO.FechaRegistro = new DateTime(2021, 07, 26);
            clienteDTO.Puntos = 100;

            productoDTO.Id = "4797d7e3-52af-4353-9a5c-e0297bd80471";
            productoDTO.Nombre = "Te Hatsu";
            productoDTO.Precio = 7000;
            productoDTO.Codigo = "TH02";
            productoDTO.Descripcion = "Te Hatsu sabor te negro";

            nuevaVenta.Id = "2fd6cd19-5e59-49b9-abb6-9c69b47cc0ec";
            nuevaVenta.Valor = 50000;
            nuevaVenta.Fecha = new DateTime(2021, 07, 26);
            nuevaVenta.Productos.Add(productoDTO);
            nuevaVenta.Clientes.Add(clienteDTO);
            nuevaVenta.TipoDeVenta = 0;
            nuevaVenta.NumeroMesa = 10;
            nuevaVenta.Direccion = "Carrera 23 43 - 28";
            nuevaVenta.Estado = true;

            lista.Add(nuevaVenta);


            Task<List<VentaDTO>> prueba = _controller.asignarVvC(nuevaVenta.Clientes, nuevaVenta.Id);

            Assert.AreEqual(lista, prueba);

        }
    }
}