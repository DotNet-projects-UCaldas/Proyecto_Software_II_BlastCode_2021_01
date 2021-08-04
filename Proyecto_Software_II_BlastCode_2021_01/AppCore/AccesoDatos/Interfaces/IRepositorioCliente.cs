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
        public bool AgregarCliente(ClienteModel cliente);
    }
}
