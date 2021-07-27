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
        public bool AgregarCliente(ClienteModel cliente)
        {
            _repoClientes.AgregarCliente(cliente);
            return true;
        }

  
    }
}
