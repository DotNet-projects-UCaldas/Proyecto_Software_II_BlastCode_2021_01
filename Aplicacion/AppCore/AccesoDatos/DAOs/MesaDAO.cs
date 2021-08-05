using AccesoDatos.Interfaces;
using AccesoDatos.Modelos;
using AccesoDatos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.DAOs
{
    /// <summary>
    /// Clase Data Access Object para gestionar la Clase MesaModelo
    /// </summary>
    public class MesaDAO : IRepositorioMesa
    {
        private readonly RepositorioMesas _repoMesas = new RepositorioMesas();
        /// <summary>
        /// Método para agregar una nueva mesa
        /// </summary>
        /// <param name="nuevaMesa">Mesa a agregar</param>
        /// <returns>Mesa agregada</returns>
        public MesaModel AgregarMesa(MesaModel nuevaMesa)
        {
            MesaModel mesaGuardada = _repoMesas.AgregarMesa(nuevaMesa);
            return mesaGuardada;
        }
        /// <summary>
        /// Método para guardar una mesa editada 
        /// </summary>
        /// <param name="mesa">Mesa editada</param>
        /// <returns>Mesa editada</returns>
        public MesaModel EditarMesa(MesaModel mesa)
        {
            MesaModel mesaEditada = _repoMesas.EditarMesa(mesa);
            return mesaEditada;
        }
        /// <summary>
        /// Método para eliminar una mesa
        /// </summary>
        /// <param name="Id">Id de la mesa a eliminar</param>
        /// <returns></returns>
        public MesaModel EliminarMesa(string Id)
        {
            MesaModel mesaEliminada = _repoMesas.EliminarMesa(Id);
            return mesaEliminada;
        }
        /// <summary>
        /// Método que retorna las mesas
        /// </summary>
        /// <returns>Lista de mesas MesaModel</returns>
        public List<MesaModel> ListarMesas()
        {
            return _repoMesas.ListarMesas();
        }
    }
}
