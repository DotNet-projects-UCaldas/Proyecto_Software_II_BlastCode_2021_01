using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Modelos
{
    public class VentaModel
    {
        public string Id { get; set; }
        public int Valor { get; set; }
        public DateTime Fecha { get; set; }
        public List<ClienteModel> Clientes { get; set; }
        public List<ProductoModel> Productos { get; set; }
        public TipoVenta TipoDeVenta { get; set; }
        public int NumeroMesa { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; } = true;
        public int Propina { get; set; }
        public VentaModel(int valor, DateTime fecha, List<ClienteModel> clientes, List<ProductoModel> productos,
            TipoVenta tipoVenta, int numeroMesa, string direccion, bool estado, int propina)
        {
            Valor = valor;
            Fecha = fecha;
            Clientes = clientes;
            Productos = productos;
            TipoDeVenta = tipoVenta;
            NumeroMesa = numeroMesa;
            Direccion = direccion;
            Estado = estado;
            Propina = propina;

        }

        public VentaModel()
        {
        }

        public enum TipoVenta
        {
            Mostrador, Mesa, Domicilio
        }
    }
}