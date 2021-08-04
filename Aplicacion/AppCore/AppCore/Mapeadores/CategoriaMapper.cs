using AccesoDatos.Modelos;
using AppCore.DTOs;
using AppCore.Mapeadores.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Mapeadores
{
    public class CategoriaMapper : MapperCategoria<CategoriaDTO, CategoriaModel>
    {
        private readonly SubCategoriaMapper _subCategoriaMapper = new SubCategoriaMapper();
        public override CategoriaModel mapearT1T2(CategoriaDTO entrada)
        {
            List<SubCategoriaModel> subCategorias = _subCategoriaMapper.mapearT1T2(entrada.SubCategorias);

            return new CategoriaModel()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Descripcion = entrada.Descripcion,
                SubCategorias = subCategorias
            };
        }

        public override CategoriaDTO mapearT2T1(CategoriaModel entrada)
        {
            List<SubCategoriaDTO> subCategorias = _subCategoriaMapper.mapearT2T1(entrada.SubCategorias);

            return new CategoriaDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Descripcion = entrada.Descripcion,
                SubCategorias = subCategorias
            };
        }

        public override List<CategoriaModel> mapearT1T2(List<CategoriaDTO> entrada)
        {
            List<CategoriaModel> listaCategoria = new List<CategoriaModel>();
            foreach (var item in entrada)
            {
                listaCategoria.Add(mapearT1T2(item));
            }

            return listaCategoria;
        }

        public override List<CategoriaDTO> mapearT2T1(List<CategoriaModel> entrada)
        {
            List<CategoriaDTO> listaCategoria = new List<CategoriaDTO>();
            foreach (var item in entrada)
            {
                listaCategoria.Add(mapearT2T1(item));
            }

            return listaCategoria;
        }
    }
}
