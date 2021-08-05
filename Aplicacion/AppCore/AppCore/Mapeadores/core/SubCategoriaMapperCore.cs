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
    public class SubCategoriaMapperCore : MapperBase<SubCategoriaDTO, SubCategoria>
    {
        public override SubCategoria mapearT1T2(SubCategoriaDTO entrada)
        {
            return new SubCategoria()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Descripcion = entrada.Descripcion
            };
        }

        public override SubCategoriaDTO mapearT2T1(SubCategoria entrada)
        {
            return new SubCategoriaDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Descripcion = entrada.Descripcion
            };
        }

        public override List<SubCategoria> mapearT1T2(List<SubCategoriaDTO> entrada)
        {
            List<SubCategoria> listaSubCategoria = new List<SubCategoria>();
            foreach (var item in entrada)
            {
                listaSubCategoria.Add(mapearT1T2(item));
            }

            return listaSubCategoria;
        }

        public override List<SubCategoriaDTO> mapearT2T1(List<SubCategoria> entrada)
        {
            List<SubCategoriaDTO> listaSubCategoria = new List<SubCategoriaDTO>();
            foreach (var item in entrada)
            {
                listaSubCategoria.Add(mapearT2T1(item));
            }

            return listaSubCategoria;
        }
    }
}