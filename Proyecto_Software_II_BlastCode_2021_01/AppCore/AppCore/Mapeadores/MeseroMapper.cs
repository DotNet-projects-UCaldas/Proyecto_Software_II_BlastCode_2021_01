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
                Nombre = entrada.Nombre;
                Apellido = entrada.Apellido;
                Cedula = entrada.Cedula;
                Telefono = entrada.Telefono;
                Correo = entrada.Correo;
                FechaRegistro = entrada.FechaIngreso;
                FechaSalida = entrada.FechaSalida;
                Propina = entrada.Propina;
            };
        }

        public override IEnumerable<MeseroModel> mapearT1T2(IEnumerable<MeseroDTO> entrada)
        {
            foreach ( var mesero in entrada)
            {
                yield return mapearT1T2(mesero);
            }
        }

        public override MeseroDTO mapearT2T1(MeseroModel entrada)
        {
            return new MeseroDTO()
            {
                Nombre = entrada.Nombre;
                Apellido = entrada.Apellido;
                Cedula = entrada.Cedula;
                Telefono = entrada.Telefono;
                Correo = entrada.Correo;
                FechaRegistro = entrada.FechaIngreso;
                FechaSalida = entrada.FechaSalida;
                Propina = entrada.Propina;
            };
        }

        public override IEnumerable<MeseroDTO> mapearT2T1(IEnumerable<MeseroModel> entrada)
        {
            foreach (var mesero in entrada)
            {
                yield return mapearT2T1(mesero);
            }
        }
    }
}