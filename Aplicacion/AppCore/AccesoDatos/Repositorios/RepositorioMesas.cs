using AccesoDatos.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AccesoDatos.Repositorios
{
    /// <summary>
    /// Base de datos de mesas
    /// </summary>
    public class RepositorioMesas
    {
        public MesaModel AgregarMesa(MesaModel nuevaMesa)
        {
            nuevaMesa.Id = Guid.NewGuid().ToString();
            string rutaDB = "./wwwroot/mesasDB.json";
            string jsonData = System.IO.File.ReadAllText(rutaDB);
            List<MesaModel> mesas;
            try
            {
                mesas = JsonConvert.DeserializeObject<List<MesaModel>>(jsonData);
            }
            catch (Exception)
            {
                mesas = null;
            }

            if (mesas != null && mesas.Where(v => v.Id == nuevaMesa.Id).FirstOrDefault() == null)
            {
                mesas.Add(nuevaMesa);
                string jsonString = JsonConvert.SerializeObject(mesas, Formatting.Indented);
                File.WriteAllText(rutaDB, jsonString);
                return nuevaMesa;
            }
            else return null;
        }

        public MesaModel EditarMesa(MesaModel mesa)
        {
            string rutaDB = "./wwwroot/mesasDB.json";
            string jsonData = System.IO.File.ReadAllText(rutaDB);
            List<MesaModel> mesas;
            try
            {
                mesas = JsonConvert.DeserializeObject<List<MesaModel>>(jsonData);
            }
            catch (Exception)
            {
                 mesas = null;
            }

            if (mesas != null && mesas.Where(v => v.Id == mesa.Id).FirstOrDefault() == null)
            {

                mesas[mesas.FindIndex(v => v.Id == mesa.Id)] = mesa;
                string jsonString = JsonConvert.SerializeObject(mesas, Formatting.Indented);
                File.WriteAllText(rutaDB, jsonString);
                return mesa;
            }
            else return null;
        }

        public List<MesaModel> ListarMesas()
        {
            string rutaDB = "./wwwroot/mesasDB.json";
            string jsonData = System.IO.File.ReadAllText(rutaDB);
            List<MesaModel> mesas;
            try
            {
                mesas = JsonConvert.DeserializeObject<List<MesaModel>>(jsonData);
            }
            catch (Exception)
            {
                mesas = null;
            }

            if (mesas != null)
            {

                return mesas;
            }
            else return null;
        }

        public MesaModel EliminarMesa(string Id)
        {
            string rutaDB = "./wwwroot/mesasDB.json";
            string jsonData = System.IO.File.ReadAllText(rutaDB);
            MesaModel mesaEliminada;
            List <MesaModel> mesas;
            try
            {
                mesas = JsonConvert.DeserializeObject<List<MesaModel>>(jsonData);
            }
            catch (Exception)
            {
                mesas = null;
            }

            if (mesas != null && mesas.Where(v => v.Id == Id).FirstOrDefault() != null)
            {
                mesaEliminada = mesas.Where(v => v.Id == Id).FirstOrDefault();
                return mesaEliminada;
            }
            else return null;
        }
    }
}
