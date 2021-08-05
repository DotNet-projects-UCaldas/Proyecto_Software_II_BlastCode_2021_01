using AccesoDatos.Interfaces;
using AccesoDatos.Modelos;
using AccesoDatos.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.DAOs
{
    public class MeseroDAO : IRepositorioMesero
    {
        private readonly RepositorioMeseros _repoMeseros = new RepositorioMeseros();
        public MeseroModel AgregarMesero(MeseroModel nuevoMesero)
        {
            _repoMeseros.AgregarMesero(nuevoMesero);

            return null;
        }

        public MeseroModel EditarMesero(MeseroModel mesero)
        {
            MeseroModel meseroEditado = _repoMeseros.EditarMesero(mesero);

            return meseroEditado;
        }

        public MeseroModel EliminarMesero(string Id)
        {
            MeseroModel meseroEliminado = _repoMeseros.EliminarMesero(Id);

            return meseroEliminado;
        }

        public IEnumerable<MeseroModel> ListarMeseros()
        {
            List<MeseroModel> meseros = _repoMeseros.ListarMeseros();

            return meseros;
        }
  
    }
}
