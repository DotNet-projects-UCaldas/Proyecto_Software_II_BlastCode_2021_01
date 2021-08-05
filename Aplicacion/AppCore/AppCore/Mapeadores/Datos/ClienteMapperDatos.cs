using AccesoDatos.Modelos;
using AppCore.Dominio;
using AppCore.DTOs;
using AppCore.Mapeadores.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Mapeadores.Datos
{
    public class ClienteMapperDatos : MapperBase<Cliente, ClienteModel>
    {
        public override ClienteModel mapearT1T2(Cliente entrada)
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

        public override List<ClienteModel> mapearT1T2(List<Cliente> entrada)
        {
            List<ClienteModel> listaClientes = new List<ClienteModel>();
            foreach (var cliente in entrada)
            {
                listaClientes.Add(mapearT1T2(cliente));
            }

            return listaClientes;
        }

        public override Cliente mapearT2T1(ClienteModel entrada)
        {
            return new Cliente()
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

        public override List<Cliente> mapearT2T1(List<ClienteModel> entrada)
        {
            List<Cliente> listaClientes = new List<Cliente>();
            foreach (var cliente in entrada)
            {
                listaClientes.Add(mapearT2T1(cliente));
            }

            return listaClientes;
        }
    }
}
