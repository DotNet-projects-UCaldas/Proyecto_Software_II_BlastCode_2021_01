using AccesoDatos.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AccesoDatos.Repositorios
{
    public class RepositorioVentas
    {
        public VentaModel AgregarVenta(VentaModel nuevaVenta)
        {
            nuevaVenta.Id = Guid.NewGuid().ToString();
            string rutaDB = "./wwwroot/ventasDB.json";
            string jsonData = System.IO.File.ReadAllText(rutaDB);
            List<VentaModel> ventas;
            try
            {
              ventas = JsonConvert.DeserializeObject<List<VentaModel>>(jsonData);
            }
            catch (Exception)
            {
                ventas = null;
            }
            
            if (ventas != null && ventas.Where(v => v.Id == nuevaVenta.Id).FirstOrDefault() == null)
            {
                ventas.Add(nuevaVenta);
                string jsonString = JsonConvert.SerializeObject(ventas, Formatting.Indented);
                File.WriteAllText(rutaDB, jsonString);
                return nuevaVenta;
            }
            else return null;
        }

        public VentaModel EditarVenta(VentaModel venta)
        {
            string rutaDB = "./wwwroot/ventasDB.json";
            string jsonData = System.IO.File.ReadAllText(rutaDB);
            List<VentaModel> ventas;
            try
            {
                ventas = JsonConvert.DeserializeObject<List<VentaModel>>(jsonData);
            }
            catch (Exception)
            {
                ventas = null;
            }

            if (ventas != null && ventas.Where(v => v.Id == venta.Id).FirstOrDefault() == null)
            {

                ventas[ventas.FindIndex(v => v.Id == venta.Id)] = venta;
                string jsonString = JsonConvert.SerializeObject(ventas, Formatting.Indented);
                File.WriteAllText(rutaDB, jsonString);
                return venta;
            }
            else return null;
        }

        public List<VentaModel> ListarVentas()
        {
            string rutaDB = "./wwwroot/ventasDB.json";
            string jsonData = System.IO.File.ReadAllText(rutaDB);
            List<VentaModel> ventas;
            try
            {
                ventas = JsonConvert.DeserializeObject<List<VentaModel>>(jsonData);
            }
            catch (Exception)
            {
                ventas = null;
            }

            if (ventas != null)
            {

                return ventas;
            }
            else return null;
        }

        public VentaModel EliminarVenta(string Id)
        {
            string rutaDB = "./wwwroot/ventasDB.json";
            string jsonData = System.IO.File.ReadAllText(rutaDB);
            VentaModel ventaEliminada;
            List<VentaModel> ventas;
            try
            {
                ventas = JsonConvert.DeserializeObject<List<VentaModel>>(jsonData);
            }
            catch (Exception)
            {
                ventas = null;
            }

            if (ventas != null && ventas.Where(v => v.Id == Id).FirstOrDefault() != null)
            {
                ventaEliminada = ventas.Where(v => v.Id == Id).FirstOrDefault();
                return ventaEliminada;
            }
            else return null;
        }
    }
}
