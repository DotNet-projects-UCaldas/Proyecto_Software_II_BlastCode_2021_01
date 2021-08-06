using AccesoDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IRepositorioCategorias
    {

        // public CategoriaModel crearCategoria();
        public CategoriaModel modificarCategoria(CategoriaModel categoria);

        public List<CategoriaModel> ListarCategorias();
    }
}