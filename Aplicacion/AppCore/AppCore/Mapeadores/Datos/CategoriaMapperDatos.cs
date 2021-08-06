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
    public class CategoriaMapperDatos : MapperBase<Categoria, CategoriaModel>
    {
        private readonly SubCategoriaMapperDatos _subCategoriaMapper = new SubCategoriaMapperDatos();
        public override CategoriaModel mapearT1T2(Categoria entrada)
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

        public override Categoria mapearT2T1(CategoriaModel entrada)
        {
            List<SubCategoria> subCategorias = _subCategoriaMapper.mapearT2T1(entrada.SubCategorias);

            return new Categoria()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Descripcion = entrada.Descripcion,
                SubCategorias = subCategorias
            };
        }

        public override List<CategoriaModel> mapearT1T2(List<Categoria> entrada)
        {
            List<CategoriaModel> listaCategoria = new List<CategoriaModel>();
            foreach (var item in entrada)
            {
                listaCategoria.Add(mapearT1T2(item));
            }

            return listaCategoria;
        }

        public override List<Categoria> mapearT2T1(List<CategoriaModel> entrada)
        {
            List<Categoria> listaCategoria = new List<Categoria>();
            foreach (var item in entrada)
            {
                listaCategoria.Add(mapearT2T1(item));
            }

            return listaCategoria;
        }
    }
}