using AccesoDatos.Modelos;
using AppCore.DTOs;
using AppCore.Mapeadores.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Mapeadores
{
    public class SubCategoriaMapper : MapperSubCategoria<SubCategoriaDTO, SubCategoriaModel>
    {
        public override SubCategoriaModel mapearT1T2(SubCategoriaDTO entrada)
        {
            return new SubCategoriaModel()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Descripcion = entrada.Descripcion
            };
        }

        public override SubCategoriaDTO mapearT2T1(SubCategoriaModel entrada)
        {
            return new SubCategoriaDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Descripcion = entrada.Descripcion
            };
        }

        public override List<SubCategoriaModel> mapearT1T2(List<SubCategoriaDTO> entrada)
        {
            List<SubCategoriaModel> listaSubCategoria = new List<SubCategoriaModel>();
            foreach (var item in entrada)
            {
                listaSubCategoria.Add(mapearT1T2(item));
            }

            return listaSubCategoria;
        }

        public override List<SubCategoriaDTO> mapearT2T1(List<SubCategoriaModel> entrada)
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
