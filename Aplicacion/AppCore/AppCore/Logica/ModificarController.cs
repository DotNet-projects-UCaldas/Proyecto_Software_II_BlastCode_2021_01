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
        private readonly CategoriaMapperCore _mapperCate;
        private readonly CategoriaMapperDatos _mapperCateDatos;


        private readonly IRepositorioSubCategorias _repoSubCate;
        private readonly SubCategoriaMapperCore _mapperSubCate;
        private readonly SubCategoriaMapperDatos _mapperSubCateDatos;

        public Modificar(IRepositorioCategorias repoCate, CategoriaMapperCore mapperCate, IRepositorioSubCategorias repoSubCate, SubCategoriaMapperCore mapperSubCate, CategoriaMapperDatos mapperCateDatos, SubCategoriaMapperDatos mapperSubCateDatos) 
        {
            this._repoCate = repoCate;
            this._mapperCate = mapperCate;
            this._mapperCateDatos = mapperCateDatos;
            this._repoSubCate = repoSubCate;
            this._mapperSubCate = mapperSubCate;
            this._mapperSubCateDatos = mapperSubCateDatos;
        }






        // GET: api/<CategoriasController>
        [HttpGet]
        public async Task<List<CategoriaDTO>> Get()
        {
            List<CategoriaDTO> categorias = _mapperCate.mapearT2T1(_mapperCateDatos.mapearT2T1(_repoCate.ListarCategorias()));
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
        [HttpPut]
        public async Task<CategoriaDTO> Put([FromBody] CategoriaDTO value)
        {
            CategoriaDTO categoriaEditada = value;
            if (_repoCate.modificarCategoria(_mapperCateDatos.mapearT1T2(_mapperCate.mapearT1T2(value))) != null)
            {
                return categoriaEditada;
            }
            else
            {
                return null;
            }
        }

        [HttpPut("putSub")]
        public async Task<SubCategoriaDTO> PutSub([FromBody] SubCategoriaDTO value)
        {
            SubCategoriaDTO subCateEditada = value;
            if (_repoSubCate.modificarSubcategoria(_mapperSubCateDatos.mapearT1T2(_mapperSubCate.mapearT1T2(value))) != null)
            {
                return subCateEditada;
            }
            else
            {
                return null;
            }
        }

        // DELETE api/<CategoriasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}