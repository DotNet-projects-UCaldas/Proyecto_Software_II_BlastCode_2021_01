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
    public class MeseroMapperDatos : MapperBase<Mesero, MeseroModel>
        //: MapperMesero<Mesero, MeseroModel>
    {
        public override MeseroModel mapearT1T2(Mesero entrada)
        {
            return new MeseroModel()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Apellido = entrada.Apellido,
                Cedula = entrada.Cedula,
                Telefono = entrada.Telefono,
                Correo = entrada.Correo,
                FechaIngreso = entrada.FechaIngreso,
                FechaSalida = entrada.FechaSalida,
                Propina = entrada.Propina
            };
        }

        public override List<MeseroModel> mapearT1T2(List<Mesero> entrada)
        {
            List<MeseroModel> listaMeseros = new List<MeseroModel>();
            foreach (var mesero in entrada)
            {
                listaMeseros.Add(mapearT1T2(mesero));
            }

            return listaMeseros;
        }

        public override Mesero mapearT2T1(MeseroModel entrada)
        {
            return new Mesero()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Apellido = entrada.Apellido,
                Cedula = entrada.Cedula,
                Telefono = entrada.Telefono,
                Correo = entrada.Correo,
                FechaIngreso = entrada.FechaIngreso,
                FechaSalida = entrada.FechaSalida,
                Propina = entrada.Propina
            };
        }

        public override List<Mesero> mapearT2T1(List<MeseroModel> entrada)
        {
            List<Mesero> listaMeseros = new List<Mesero>();
            foreach (var mesero in entrada)
            {
                listaMeseros.Add(mapearT2T1(mesero));
            }

            return listaMeseros;
        }
    }
}