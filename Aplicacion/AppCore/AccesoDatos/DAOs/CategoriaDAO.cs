using System;
using System.Collections.Generic;
using System.Text;
using AccesoDatos.Interfaces;
using AccesoDatos.Modelos;
using AccesoDatos.Repositorios;

namespace AccesoDatos.DAOs
{
    class CategoriaDAO : IRepositorioCategorias
    {
        private readonly RepositorioCategorias _repoCategorias = new RepositorioCategorias();

        public CategoriaModel modificarCategoria(CategoriaModel categoria)
        {
            CategoriaModel cate_modificada = _repoCategorias.modificarCategoria(categoria);

            return cate_modificada;
        }

        public List<CategoriaModel> ListarCategorias()
        {
            List<CategoriaModel> categorias = _repoCategorias.ListarCategorias();

            return categorias;
        }
    }
}
