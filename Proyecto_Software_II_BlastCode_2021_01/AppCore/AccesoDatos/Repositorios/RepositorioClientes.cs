using AccesoDatos.DAOs;
using AccesoDatos.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace AccesoDatos.Repositorios
{
    public class RepositorioClientes
    {
        
        public bool AgregarCliente(ClienteModel cliente)
        {
            string rutaDB = "./wwwroot/clientesDB.json";
            string jsonData = System.IO.File.ReadAllText(rutaDB);
            List<ClienteModel> clientes = JsonConvert.DeserializeObject<List<ClienteModel>>(jsonData);
            if (clientes.Where(x => x.Id == cliente.Id).FirstOrDefault() == null)
            {
                clientes.Add(cliente);
            }
            else return false;
            string jsonString = JsonConvert.SerializeObject(clientes, Formatting.Indented);
            File.WriteAllText(rutaDB, jsonString);
            return true;
        }

    }
}
