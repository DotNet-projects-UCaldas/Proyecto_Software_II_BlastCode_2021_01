using AccesoDatos.Modelos;
using AppCore.DTOs;
using AppCore.Mapeadores.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Mapeadores
{
    public class ClienteMapper : MapperCliente<ClienteDTO, ClienteModel>
    {
        public override ClienteModel mapearT1T2(ClienteDTO entrada)
        {
            return new ClienteModel()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Apellido = entrada.Apellido,
                Cedula = entrada.Cedula,
                Telefono = entrada.Telefono,
                Correo = entrada.Correo,
                Puntos = entrada.Puntos,
            };
        }

        public override List<ClienteModel> mapearT1T2(List<ClienteDTO> entrada)
        {
            List<ClienteModel> listaClientes = new List<ClienteModel>();
            foreach (var cliente in entrada)
            {
                listaClientes.Add(mapearT1T2(cliente));
            }

            return listaClientes;
        }

        public override ClienteDTO mapearT2T1(ClienteModel entrada)
        {
            return new ClienteDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Apellido = entrada.Apellido,
                Cedula = entrada.Cedula,
                Telefono = entrada.Telefono,
                Correo = entrada.Correo,
                Puntos = entrada.Puntos,
            };
        }

        public override List<ClienteDTO> mapearT2T1(List<ClienteModel> entrada)
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
