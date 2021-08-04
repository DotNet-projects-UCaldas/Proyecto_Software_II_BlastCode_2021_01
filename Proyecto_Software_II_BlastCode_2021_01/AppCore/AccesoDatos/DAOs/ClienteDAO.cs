using AccesoDatos.Modelos;
using AccesoDatos.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.DAOs
{
    public class ClienteDAO : IRepositorioCliente
    {
        private readonly RepositorioClientes _repoClientes = new RepositorioClientes();

        public ClienteModel AgregarCliente(ClienteModel nuevoCliente)
        {
            ClienteModel clienteGuardado = _repoClientes.AgregarCliente(nuevoCliente);
            return clienteGuardado;
        }

        public ClienteModel EditarCliente(ClienteModel cliente)
        {
            ClienteModel clienteEditado = _repoClientes.EditarCliente(cliente);
            return clienteEditado;
        }

        public ClienteModel EliminarCliente(string Id)
        {
            ClienteModel clienteEliminado = _repoClientes.EliminarCliente(Id);
            return clienteEliminado;
        }

        public List<ClienteModel> ListarClientes()
        {
            return _repoClientes.ListarClientes();
        }
    }
}
