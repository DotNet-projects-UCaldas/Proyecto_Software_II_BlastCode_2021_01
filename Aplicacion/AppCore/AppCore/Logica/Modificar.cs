using AccesoDatos.Interfaces;
using AccesoDatos.Modelos;
using AccesoDatos.Repositorios;
using AppCore.DTOs;
using AppCore.Mapeadores;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppCore.Logica
{
    [Route("api/[controller]")]
    [ApiController]
    public class Modificar : ControllerBase
    {
        private readonly IRepositorioCategorias _repoCate;
        private readonly CategoriaMapper _mapperCate;


        private readonly IRepositorioSubCategorias _repoSubCate;
        private readonly SubCategoriaMapper _mapperSubCate;

        public Modificar(IRepositorioCategorias repoCate, CategoriaMapper mapperCate, IRepositorioSubCategorias repoSubCate, SubCategoriaMapper mapperSubCate)
        {
            this._repoCate = repoCate;
            this._mapperCate = mapperCate;
            this._repoSubCate = repoSubCate;
            this._mapperSubCate = mapperSubCate;
        }






        // GET: api/<CategoriasController>
        [HttpGet]
        public IEnumerable<CategoriaDTO> Get()
        {
            IEnumerable<CategoriaDTO> categorias = _mapperCate.mapearT2T1(_repoCate.ListarCategorias());

            return categorias;
        }

        // GET api/<CategoriasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoriasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoriasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}