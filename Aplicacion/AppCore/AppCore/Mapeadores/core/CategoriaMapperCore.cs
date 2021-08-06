using AccesoDatos.Modelos;
using AppCore.DTOs;
using AppCore.Dominio;
using AppCore.Mapeadores.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Mapeadores
{
    public class CategoriaMapperCore : MapperBase<CategoriaDTO, Categoria>
    {
        private readonly SubCategoriaMapperCore _subCategoriaMapper = new SubCategoriaMapperCore();
        public override Categoria mapearT1T2(CategoriaDTO entrada)
        {
            List<SubCategoria> subCategorias = _subCategoriaMapper.mapearT1T2(entrada.SubCategorias);

            return new Categoria()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Descripcion = entrada.Descripcion,
                SubCategorias = subCategorias
            };
        }

        public override CategoriaDTO mapearT2T1(Categoria entrada)
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

        public override List<Categoria> mapearT1T2(List<CategoriaDTO> entrada)
        {
            List<Categoria> listaCategoria = new List<Categoria>();
            foreach (var item in entrada)
            {
                listaCategoria.Add(mapearT1T2(item));
            }

            return listaCategoria;
        }

        public override List<CategoriaDTO> mapearT2T1(List<Categoria> entrada)
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