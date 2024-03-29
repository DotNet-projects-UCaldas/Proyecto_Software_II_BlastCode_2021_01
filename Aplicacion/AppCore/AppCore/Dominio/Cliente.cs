﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Dominio
{
    /// <summary>
    /// Clase para la lógica del dominio del objeto cliente
    /// </summary>
    public class Cliente : Persona
    {
        public DateTime FechaRegistro { get; set; }
        public int Puntos { get; set; }
       

        public Cliente(string nombre, string apellido, string cedula, string telefono, string correo, int puntos)
            : base(nombre, apellido, cedula, telefono, correo)
        {
            FechaRegistro = DateTime.Now;
            Puntos = puntos;
         
        }

        public Cliente()
        {

        }
    }
}
