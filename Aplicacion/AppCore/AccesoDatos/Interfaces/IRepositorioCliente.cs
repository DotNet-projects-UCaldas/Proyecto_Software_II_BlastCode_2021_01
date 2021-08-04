using AccesoDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorios
{
    public interface IRepositorioCliente
    {
        public ClienteModel AgregarCliente(ClienteModel nuevoCliente);
        public ClienteModel EditarCliente(ClienteModel cliente);
        public List<ClienteModel> ListarClientes();
        public ClienteModel EliminarCliente(string Id);
    }
}
