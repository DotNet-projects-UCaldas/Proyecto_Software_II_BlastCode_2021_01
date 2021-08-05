using AccesoDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorios
{
    public interface IRepositorioMesero
    {
        public MeseroModel AgregarMesero(MeseroModel nuevoMesero);
        public MeseroModel EditarMesero(MeseroModel mesero);
        public IEnumerable<MeseroModel> ListarMeseros();
        public MeseroModel EliminarMesero(string Id);
    }
}
