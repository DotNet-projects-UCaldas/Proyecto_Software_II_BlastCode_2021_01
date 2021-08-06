using AccesoDatos.Modelos;
using AppCore.Dominio;
using AppCore.DTOs;
using AppCore.Mapeadores.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Mapeadores
{
    public class SubCategoriaMapperDatos : MapperBase<SubCategoria, SubCategoriaModel>
    {
        public override SubCategoriaModel mapearT1T2(SubCategoria entrada)
        {
            return new SubCategoriaModel()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Descripcion = entrada.Descripcion
            };
        }

        public override SubCategoria mapearT2T1(SubCategoriaModel entrada)
        {
            return new SubCategoria()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Descripcion = entrada.Descripcion
            };
        }

        public override List<SubCategoriaModel> mapearT1T2(List<SubCategoria> entrada)
        {
            List<SubCategoriaModel> listaSubCategoria = new List<SubCategoriaModel>();
            foreach (var item in entrada)
            {
                listaSubCategoria.Add(mapearT1T2(item));
            }

            return listaSubCategoria;
        }

        public override List<SubCategoria> mapearT2T1(List<SubCategoriaModel> entrada)
        {
            List<SubCategoria> listaSubCategoria = new List<SubCategoria>();
            foreach (var item in entrada)
            {
                listaSubCategoria.Add(mapearT2T1(item));
            }

            return listaSubCategoria;
        }
    }
}