using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_aplication.Models;
using CRUD_aplication.Service.Implementation;
using CRUD_aplication.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> BuscaCategoria()
        {
            return Ok(await _categoriaService.BuscaCategoriaAsync());
        }
        //Possui dois get, então usamos Route
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> BuscaCategoria([FromRoute] int id)
        {
            return Ok(await _categoriaService.BuscaCategoriaAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AdicionaCategoriaAsync(CategoriaRequest request)
        {
            return Ok(await _categoriaService.AdicionaCategoriaAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarCategoriaAsync(CategoriaRequest request, int id)
        {
            return Ok(await _categoriaService.AtualizarCategoriaAsync(request, id));
        }

        [HttpDelete]
        public async Task<IActionResult> DeletarCategoriaAsync(int id)
        {
            return Ok(await _categoriaService.DeletarCategoriaAsync(id));
        }
    }
}

//PUT --> atualizar
//POST --> criar
//GET --> selecionar