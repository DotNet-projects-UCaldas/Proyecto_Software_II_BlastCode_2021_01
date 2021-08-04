using AccesoDatos.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AccesoDatos.Repositorios
{
    class RepositorioSubCategorias
    {
        // public SubCategoriaModel agregarSubcategoria(SubCategoriaModel nuevaSubcategoria)
        // {

        // }

        public SubCategoriaModel modificarSubcategoria(SubCategoriaModel subcategoria)
        {
            string rutaDB = "./wwwroot/categoriasDB.json";
            string jsonData = System.IO.File.ReadAllText(rutaDB);
            List<CategoriaModel> Categorias;

            try
            {
                Categorias = JsonConvert.DeserializeObject<List<CategoriaModel>>(jsonData);
            }
            catch (Exception)
            {
                Categorias = null;
            }

            if (Categorias != null)
            {
                foreach (var item in Categorias)
                {
                    if (item.SubCategorias.Where(sub => sub.Id == subcategoria.Id).FirstOrDefault() != null)
                    {
                        item.SubCategorias[item.SubCategorias.FindIndex(sub => sub.Id == subcategoria.Id)] = subcategoria;
                        string jsonString = JsonConvert.SerializeObject(Categorias, Formatting.Indented);
                        File.WriteAllText(rutaDB, jsonString);
                        return subcategoria;
                    }
                }
            }
            return null;
        }
    }
}
