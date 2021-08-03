using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Modelos
{
    
    public class MesaModel
    {
        public string Id { get; set; }
        public int NumeroMesa { get; set; }
        public List<VentaModel> Ventas { get; set; }

        public MesaModel(int numeroMesa, List<VentaModel> ventas)
        {
            NumeroMesa = numeroMesa;
            Ventas = ventas;
        }
        public MesaModel()
        {

        }
    }
}
