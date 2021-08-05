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
    public class ProductoMapperCore : MapperBase<ProductoDTO, Producto>
    {
        public override Producto mapearT1T2(ProductoDTO entrada)
        {
            return new Producto()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Precio = entrada.Precio,
                Codigo = entrada.Codigo,
                Descripcion = entrada.Descripcion
            };
        }

        public override List<Producto> mapearT1T2(List<ProductoDTO> entrada)
        {
            List<Producto> listaProductos = new List<Producto>();

            foreach (var producto in entrada)
            {
                listaProductos.Add(mapearT1T2(producto));
            }

            return listaProductos;
        }

        public override ProductoDTO mapearT2T1(Producto entrada)
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

        public override List<ProductoDTO> mapearT2T1(List<Producto> entrada)
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