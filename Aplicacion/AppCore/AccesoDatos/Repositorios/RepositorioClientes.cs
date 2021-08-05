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

        public ClienteModel AgregarCliente(ClienteModel nuevoCliente)
        {
            nuevoCliente.Id = Guid.NewGuid().ToString();
            string rutaDB = "./wwwroot/clienteDB.json";
            string jsonData = System.IO.File.ReadAllText(rutaDB);
            List<ClienteModel> clientes;
            try
            {
                clientes = JsonConvert.DeserializeObject<List<ClienteModel>>(jsonData);
            }
            catch (Exception)
            {
                clientes = null;
            }

            if (clientes != null && clientes.Where(v => v.Id == nuevoCliente.Id).FirstOrDefault() == null)
            {
                clientes.Add(nuevoCliente);
                string jsonString = JsonConvert.SerializeObject(clientes, Formatting.Indented);
                File.WriteAllText(rutaDB, jsonString);
                return nuevoCliente;
            }
            else return null;
        }

        public ClienteModel EditarCliente(ClienteModel cliente)
        {
            string rutaDB = "./wwwroot/clientesDB.json";
            string jsonData = System.IO.File.ReadAllText(rutaDB);
            List<ClienteModel> clientes;
            try
            {
                clientes = JsonConvert.DeserializeObject<List<ClienteModel>>(jsonData);
            }
            catch (Exception)
            {
                clientes = null;
            }

            if (clientes != null && clientes.Where(v => v.Id == cliente.Id).FirstOrDefault() == null)
            {

                clientes[clientes.FindIndex(v => v.Id == cliente.Id)] = cliente;
                string jsonString = JsonConvert.SerializeObject(clientes, Formatting.Indented);
                File.WriteAllText(rutaDB, jsonString);
                return cliente;
            }
            else return null;
        }

        public List<ClienteModel> ListarClientes()
        {
            string rutaDB = "./wwwroot/clientesDB.json";
            string jsonData = System.IO.File.ReadAllText(rutaDB);
            List<ClienteModel> clientes;
            try
            {
                clientes = JsonConvert.DeserializeObject<List<ClienteModel>>(jsonData);
            }
            catch (Exception)
            {
                clientes = null;
            }

            if (clientes != null)
            {

                return clientes;
            }
            else return null;
        }

        public ClienteModel EliminarCliente(string Id)
        {
            string rutaDB = "./wwwroot/clientesDB.json";
            string jsonData = System.IO.File.ReadAllText(rutaDB);
            ClienteModel clienteEliminado;
            List<ClienteModel> clientes;
            try
            {
                clientes = JsonConvert.DeserializeObject<List<ClienteModel>>(jsonData);
            }
            catch (Exception)
            {
                clientes = null;
            }

            if (clientes != null && clientes.Where(v => v.Id == Id).FirstOrDefault() != null)
            {
                clienteEliminado = clientes.Where(v => v.Id == Id).FirstOrDefault();
                return clienteEliminado;
            }
            else return null;
        }
    }
}