using System;
using System.Collections.Generic;
using System.Text;
using AccesoDatos.Interfaces;
using AccesoDatos.Modelos;
using AccesoDatos.Repositorios;

namespace AccesoDatos.DAOs
{
    class SubCategoriaDAO : IRepositorioSubCategorias
    {
        private readonly RepositorioSubCategorias _repoSubCategorias = new RepositorioSubCategorias();

        public SubCategoriaModel modificarSubcategoria(SubCategoriaModel subcategoria)
        {
            SubCategoriaModel SubCate_modificada = _repoSubCategorias.modificarSubcategoria(subcategoria);

            return SubCate_modificada;
        }
    }
}
