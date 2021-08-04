using AccesoDatos.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AccesoDatos.Repositorios
{
    class RepositorioCategorias
    {
        // public CategoriaModel crearCategoria(){
            
        // }

        public CategoriaModel modificarCategoria(CategoriaModel categoria)
        {
            string rutaDB = "./wwwroot/ventasDB.json";
            string jsonData = System.IO.File.ReadAllText(rutaDB);
            List<CategoriaModel> categorias;

            try
            {
                categorias = JsonConvert.DeserializeObject<List<CategoriaModel>>(jsonData);
            }
            catch (System.Exception)
            {
                categorias = null;
            }

            if (categorias != null && categorias.Where(cat => cat.Id == categoria.Id).FirstOrDefault() != null)
            {
                categorias[categorias.FindIndex(cat => cat.Id == categoria.Id)] = categoria;
                string jsonString = JsonConvert.SerializeObject(categorias, Formatting.Indented);
                File.WriteAllText(rutaDB, jsonString);
                return categoria;
            }
            return null;
        }
    }
}
