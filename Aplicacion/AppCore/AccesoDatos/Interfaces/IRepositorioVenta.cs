﻿using AccesoDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    /// <summary>
    /// Interfaz para el repositorio de ventas
    /// </summary>
    public interface IRepositorioVenta
    {
        public VentaModel AgregarVenta(VentaModel nuevaVenta);
        public VentaModel EditarVenta(VentaModel venta);
        public List<VentaModel> ListarVentas();
        public VentaModel EliminarVenta(string Id);
        public VentaModel VentaById(string Id);

    }
}
