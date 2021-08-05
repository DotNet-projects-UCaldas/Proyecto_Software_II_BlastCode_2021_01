using AccesoDatos.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AccesoDatos.Repositorios
{
    public class RepositorioMesas
    {
        private List<MesaModel> mesas;
        private readonly string rutaDB = "./wwwroot/mesasDB.json";

        public RepositorioMesas() {
            string jsonData = System.IO.File.ReadAllText(rutaDB);
            try {
                mesas = JsonConvert.DeserializeObject<List<MesaModel>>(jsonData);
            } catch(Exception) {
                mesas = null;
            }
        }

        public MesaModel AgregarMesa(MesaModel nuevaMesa) {
            nuevaMesa.Id = Guid.NewGuid().ToString();
            
            if (mesas != null && mesas.Where(v => v.Id == nuevaMesa.Id).FirstOrDefault() == null) {
                mesas.Add(nuevaMesa);
                string jsonString = JsonConvert.SerializeObject(mesas, Formatting.Indented);
                File.WriteAllText(rutaDB, jsonString);
                return nuevaMesa;
            }
            
            return null;
        }

        public MesaModel EditarMesa(MesaModel mesa) {
            if (mesas != null && mesas.Where(v => v.Id == mesa.Id).FirstOrDefault() == null) {

                mesas[mesas.FindIndex(v => v.Id == mesa.Id)] = mesa;
                string jsonString = JsonConvert.SerializeObject(mesas, Formatting.Indented);
                File.WriteAllText(rutaDB, jsonString);
                return mesa;
            }
            
            return null;
        }

        public List<MesaModel> ListarMesas() {
            return mesas;
        }

        public MesaModel EliminarMesa(string Id) {
            MesaModel mesaEliminada;

            if (mesas != null && mesas.Where(v => v.Id == Id).FirstOrDefault() != null) {
                mesaEliminada = mesas.Where(v => v.Id == Id).FirstOrDefault();
                return mesaEliminada;
            }
            
            return null;
        }

        public MesaModel MesaById(string Id) {
            MesaModel mesa;

            if (mesas != null && mesas.Where(v => v.Id == Id).FirstOrDefault() != null) {
                mesa = mesas.Where(v => v.Id == Id).FirstOrDefault();
                return mesa;
            }

            return null;
        }
    }
}
