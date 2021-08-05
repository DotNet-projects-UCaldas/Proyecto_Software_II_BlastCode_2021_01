using AccesoDatos.Modelos;
using AppCore.Dominio;
using AppCore.DTOs;
using AppCore.Mapeadores.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Mapeadores.Datos
{
    public class ProductoMapperDatos : MapperBase<Producto, ProductoModel>
    {
        public override ProductoModel mapearT1T2(Producto entrada)
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

        public override List<ProductoModel> mapearT1T2(List<Producto> entrada)
        {
            List<ProductoModel> listaProductos = new List<ProductoModel>();

            foreach (var producto in entrada)
            {
                listaProductos.Add(mapearT1T2(producto));
            }

            return listaProductos;
        }

        public override Producto mapearT2T1(ProductoModel entrada)
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

        public override List<Producto> mapearT2T1(List<ProductoModel> entrada)
        {
            List<Producto> listaProductos = new List<Producto>();

            foreach (var producto in entrada)
            {
                listaProductos.Add(mapearT2T1(producto));
            }

            return listaProductos;
        }
    }
}