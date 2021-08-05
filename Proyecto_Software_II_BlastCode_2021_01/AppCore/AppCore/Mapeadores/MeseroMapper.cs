using AccesoDatos.Modelos;
using AppCore.DTOs;
using AppCore.Mapeadores.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AppCore.Mapeadores
{
    public class MeseroMapper : MapperMesero<MeseroDTO, MeseroModel>
    {
        public override MeseroModel mapearT1T2(MeseroDTO entrada)
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

        public override List<MeseroModel> mapearT1T2(List<MeseroDTO> entrada)
        {
            List<MeseroModel> listaMeseros = new List<MeseroModel>();
            foreach (var mesero in entrada)
            {
                listaMeseros.Add(mapearT1T2(mesero));
            }

            return listaMeseros;
        }

        public override MeseroDTO mapearT2T1(MeseroModel entrada)
        {
            return new MeseroDTO()
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

        public override List<MeseroDTO> mapearT2T1(List<MeseroModel> entrada)
        {
            List<MeseroDTO> listaMeseros = new List<MeseroDTO>();
            foreach (var mesero in entrada)
            {
                listaMeseros.Add(mapearT2T1(mesero));
            }

            return listaMeseros;
        }
    }
}