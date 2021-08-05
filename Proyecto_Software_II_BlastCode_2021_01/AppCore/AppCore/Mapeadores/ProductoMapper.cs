using AccesoDatos.Modelos;
using AppCore.DTOs;
using AppCore.Mapeadores.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Mapeadores
{
    public class ProductoMapper : MapperProducto<ProductoDTO, ProductoModel>
    {
        public override ProductoModel mapearT1T2(ProductoDTO entrada)
        {
            return new ProductoModel()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Precio = entrada.Precio,
                Codigo = entrada.Codigo,
                Descripcion = entrada.Descripcion
            };
        }

        public override List<ProductoModel> mapearT1T2(List<ProductoDTO> entrada)
        {
            List<ProductoModel> listaProductos = new List<ProductoModel>();

            foreach (var producto in entrada)
            {
                listaProductos.Add(mapearT1T2(producto));
            }

            return listaProductos;
        }

        public override ProductoDTO mapearT2T1(ProductoModel entrada)
        {
            return new ProductoDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Precio = entrada.Precio,
                Codigo = entrada.Codigo,
                Descripcion = entrada.Descripcion
            };
        }

        public override List<ProductoDTO> mapearT2T1(List<ProductoModel> entrada)
        {
            List<ProductoDTO> listaProductos = new List<ProductoDTO>();

            foreach (var producto in entrada)
            {
                listaProductos.Add(mapearT2T1(producto));
            }

            return listaProductos;
        }
    }
}