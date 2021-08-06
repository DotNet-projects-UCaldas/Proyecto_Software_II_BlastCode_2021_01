using AccesoDatos.Modelos;
using AccesoDatos.Interfaces;
using AccesoDatos.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.DAOs
{
    /// <summary>
    /// Clase Data Access Object para gestionar la Clase ClienteModelo
    /// </summary>
    public class ClienteDAO : IRepositorioCliente
    {
        private readonly RepositorioClientes _repoClientes = new RepositorioClientes();
        /// <summary>
        /// Método para agregar un nuevo cliente
        /// </summary>
        /// <param name="nuevoCliente">Nuevo objeto ClienteModel</param>
        /// <returns>El cliente guardado</returns>
        public ClienteModel AgregarCliente(ClienteModel nuevoCliente)
        {
            ClienteModel clienteGuardado = _repoClientes.AgregarCliente(nuevoCliente);
            return clienteGuardado;
        }
        /// <summary>
        /// Método para editar un cliente
        /// </summary>
        /// <param name="cliente">Cliente Editado a guardar</param>
        /// <returns>El cliente editado</returns>
        public ClienteModel EditarCliente(ClienteModel cliente)
        {
            ClienteModel clienteEditado = _repoClientes.EditarCliente(cliente);
            return clienteEditado;
        }
        /// <summary>
        /// Método para eliminar un cliente
        /// </summary>
        /// <param name="Id">Id del cliente a eliminar</param>
        /// <returns>El cliente eliminado</returns>
        public ClienteModel EliminarCliente(string Id)
        {
            ClienteModel clienteEliminado = _repoClientes.EliminarCliente(Id);
            return clienteEliminado;
        }
        /// <summary>
        /// Método que retorna todos los clientes
        /// </summary>
        /// <returns>Lista de clientes Model</returns>
        public List<ClienteModel> ListarClientes()
        {
            return _repoClientes.ListarClientes();
        }
    }
}
