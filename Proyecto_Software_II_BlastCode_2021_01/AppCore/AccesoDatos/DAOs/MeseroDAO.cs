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
            MeseroModel MeseroGuardado = _repoMeseros.AgregarMesero(nuevoMesero);

            return MeseroGuardado;
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

        public List<MeseroModel> ListarMeseros()
        {
            List<MeseroModel> meseros = _repoMeseros.ListarMeseros();

            return meseros;
        }

        public MeseroModel MeseroById(string Id)
        {
            return _repoMeseros.MeseroById(Id);
        }
    }
}
