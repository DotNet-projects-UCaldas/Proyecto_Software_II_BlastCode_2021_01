using AccesoDatos.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AccesoDatos.Repositorios
{
    public class RepositorioMeseros
    {
        
        public MeseroModel AgregarMesero(MeseroModel nuevoMesero)
        {
            nuevoMesero.Id = Guid.NewGuid().ToString();
            string rutaDB = "./wwwroot/meserosDB.json";
            string jsonData = System.IO.File.ReadAllText(rutaDB);
            List<MeseroModel> meseros;
            try
            {
              meseros = JsonConvert.DeserializeObject<List<MeseroModel>>(jsonData);
            }
            catch (Exception)
            {
                meseros = null;
            }
            
            if (meseros != null && meseros.Where(v => v.Id == nuevoMesero.Id).FirstOrDefault() == null)
            {
                meseros.Add(nuevoMesero);
                string jsonString = JsonConvert.SerializeObject(meseros, Formatting.Indented);
                File.WriteAllText(rutaDB, jsonString);
                return nuevoMesero;
            }
            else return null;
        }

        public MeseroModel EditarMesero(MeseroModel mesero)
        {
            string rutaDB = "./wwwroot/meserosDB.json";
            string jsonData = System.IO.File.ReadAllText(rutaDB);
            List<MeseroModel> meseros;
            try
            {
                meseros = JsonConvert.DeserializeObject<List<MeseroModel>>(jsonData);
            }
            catch (Exception)
            {
                meseros = null;
            }

            if (meseros != null && meseros.Where(v => v.Id == mesero.Id).FirstOrDefault() != null)
            {
                Console.WriteLine("hola: " + meseros.FindIndex(v => v.Id == mesero.Id));
                meseros[meseros.FindIndex(v => v.Id == mesero.Id)] = mesero;
                string jsonString = JsonConvert.SerializeObject(meseros, Formatting.Indented);
                File.WriteAllText(rutaDB, jsonString);
                return mesero;
            }
            else return null;
        }

        public List<MeseroModel> ListarMeseros()
        {
            string rutaDB = "./wwwroot/meserosDB.json";
            string jsonData = System.IO.File.ReadAllText(rutaDB);
            List<MeseroModel> meseros;
            try
            {
                meseros = JsonConvert.DeserializeObject<List<MeseroModel>>(jsonData);
            }
            catch (Exception)
            {
                meseros = null;
            }

            if (meseros != null)
            {

                return meseros;
            }
            else return null;
        }

        public MeseroModel EliminarMesero(string Id)
        {
            string rutaDB = "./wwwroot/meserosDB.json";
            string jsonData = System.IO.File.ReadAllText(rutaDB);
            MeseroModel meseroEliminado;
            List<MeseroModel> meseros;
            try
            {
                meseros = JsonConvert.DeserializeObject<List<MeseroModel>>(jsonData);
            }
            catch (Exception)
            {
                meseros = null;
            }

            if (meseros != null && meseros.Where(v => v.Id == Id).FirstOrDefault() != null)
            {
                meseroEliminado = meseros.Where(v => v.Id == Id).FirstOrDefault();
                meseros.Remove(meseroEliminado);
                string jsonString = JsonConvert.SerializeObject(meseros, Formatting.Indented);
                File.WriteAllText(rutaDB, jsonString);
                return meseroEliminado;
            }
            else return null;
        }

        public MeseroModel MeseroById(string Id)
        {
            string rutaDB = "./wwwroot/meserosDB.json";
            string jsonData = System.IO.File.ReadAllText(rutaDB);
            MeseroModel mesero;
            List<MeseroModel> meseros;
            try
            {
                meseros = JsonConvert.DeserializeObject<List<MeseroModel>>(jsonData);
            }
            catch (Exception)
            {
                meseros = null;
            }

            if (meseros != null && meseros.Where(v => v.Id == Id).FirstOrDefault() != null)
            {
                mesero = meseros.Where(v => v.Id == Id).FirstOrDefault();
                return mesero;
            }
            else return null;
        }

    }
}
