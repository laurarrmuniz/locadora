using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_aplication.Models;
using CRUD_aplication.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmesController : ControllerBase
    {
        private readonly IFilmeService _filmeService;
        public FilmesController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }
        [HttpGet]
        public async Task<IActionResult> BuscaFilmes()
        {
            return Ok(await _filmeService.BuscaFilmesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AdicionaAsync(FilmesRequest request)
        {
            return Ok(await _filmeService.AdicionaAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> AtualizaAsync(FilmesRequest request, int id)
        {
            return Ok(await _filmeService.AtualizaAsync(request, id));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _filmeService.DeleteAsync(id));
        }
    }
}

//PUT --> atualizar
//POST --> criar
//GET --> selecionar