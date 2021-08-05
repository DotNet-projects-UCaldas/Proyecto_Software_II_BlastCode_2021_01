using AccesoDatos.Interfaces;
using AccesoDatos.Modelos;
using AccesoDatos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.DAOs
{
    public class MesaDAO : IRepositorioMesa
    {
        private readonly RepositorioMesas _repoMesas = new RepositorioMesas();

        public MesaModel AgregarMesa(MesaModel nuevaMesa)
        {
            MesaModel mesaGuardada = _repoMesas.AgregarMesa(nuevaMesa);
            return mesaGuardada;
        }

        public MesaModel EditarMesa(MesaModel mesa)
        {
            MesaModel mesaEditada = _repoMesas.EditarMesa(mesa);
            return mesaEditada;
        }

        public MesaModel EliminarMesa(string Id)
        {
            MesaModel mesaEliminada = _repoMesas.EliminarMesa(Id);
            return mesaEliminada;
        }

        public List<MesaModel> ListarMesas()
        {
            return _repoMesas.ListarMesas();
        }

        public MesaModel MesaById(string Id) {
            MesaModel mesa = _repoMesas.MesaById(Id);
            return mesa;
        }
    }
}
