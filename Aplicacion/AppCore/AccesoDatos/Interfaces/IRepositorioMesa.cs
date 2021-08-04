using AccesoDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IRepositorioMesa
    {
        public MesaModel AgregarMesa(MesaModel nuevaMesa);
        public MesaModel EditarMesa(MesaModel mesa);
        public List<MesaModel> ListarMesas();
        public MesaModel EliminarMesa(string Id);
    }
}
