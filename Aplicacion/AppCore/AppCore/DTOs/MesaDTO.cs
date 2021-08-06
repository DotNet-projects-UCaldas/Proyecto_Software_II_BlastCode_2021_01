using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
///     Clase con la lógica para hacer la transferencia de datos 
/// </summary>
/// <remarks>
///     Autor: Lucas Bohorquez
///     Versión: 1.0
/// </remarks>
namespace AppCore.DTOs
{
    /// <summary>
    /// Clase Data Transfer Object para el manejo de la información recibida en el front para el objeto mesa
    /// </summary>
    public class MesaDTO
    {
        public string Id { get; set; }
        public int NumeroMesa { get; set; }
        public List<VentaDTO> Ventas { get; set; }

        public MesaDTO(int numeroMesa, List<VentaDTO> ventas)
        {
            Id = Guid.NewGuid().ToString();
            NumeroMesa = numeroMesa;
            Ventas = ventas;
        }

        public MesaDTO()
        {

        }
    }
}
