using AccesoDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IRepositorioSubCategorias
    {

        // public SubCategoriaModel agregarSubcategoria(SubCategoriaModel nuevaSubcategoria);
        public SubCategoriaModel modificarSubcategoria(SubCategoriaModel subcategoria);
    }
}