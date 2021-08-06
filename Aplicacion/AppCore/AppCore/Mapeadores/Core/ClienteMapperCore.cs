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
    /// <summary>
    /// Clase para mapear los clientes DTO a clientes del dominio
    /// </summary>
    public class ClienteMapperCore : MapperBase<ClienteDTO, Cliente>
    {
        public override Cliente mapearT1T2(ClienteDTO entrada)
        {
            return new Cliente()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Apellido = entrada.Apellido,
                Cedula = entrada.Cedula,
                Telefono = entrada.Telefono,
                Correo = entrada.Correo,
                FechaRegistro = entrada.FechaRegistro,
                Puntos = entrada.Puntos,
            };
        }

        public override List<Cliente> mapearT1T2(List<ClienteDTO> entrada)
        {
            List<Cliente> listaClientes = new List<Cliente>();
            foreach (var cliente in entrada)
            {
                listaClientes.Add(mapearT1T2(cliente));
            }

            return listaClientes;
        }

        public override ClienteDTO mapearT2T1(Cliente entrada)
        {
            return new ClienteDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Apellido = entrada.Apellido,
                Cedula = entrada.Cedula,
                Telefono = entrada.Telefono,
                Correo = entrada.Correo,
                FechaRegistro = entrada.FechaRegistro,
                Puntos = entrada.Puntos,
            };
        }

        public override List<ClienteDTO> mapearT2T1(List<Cliente> entrada)
        {
            List<ClienteDTO> listaClientes = new List<ClienteDTO>();
            foreach (var cliente in entrada)
            {
                listaClientes.Add(mapearT2T1(cliente));
            }

            return listaClientes;
        }
    }
}
