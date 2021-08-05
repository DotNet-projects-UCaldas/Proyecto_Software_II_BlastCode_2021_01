using AccesoDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IRepositorioMesero
    {
        public MeseroModel AgregarMesero(MeseroModel nuevaMesero);
        public MeseroModel EditarMesero(MeseroModel mesero);
        public List<MeseroModel> ListarMeseros();
        public MeseroModel EliminarMesero(string Id);
        public MeseroModel MeseroById(string Id);

    }
}