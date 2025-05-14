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
    public class ProdutoraController : ControllerBase
    {
        private readonly IProdutoraService _produtoraService;
        public ProdutoraController(IProdutoraService produtoraService)
        {
            _produtoraService = produtoraService;
        }

        [HttpGet]
        public async Task<IActionResult> BuscaProdutora()
        {
            return Ok(await _produtoraService.BuscaProdutoraAsync());
        }
        //Possui dois get, então usamos Route
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> BuscaProdutora([FromRoute]int id)
        {
            return Ok(await _produtoraService.BuscaProdutoraAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AdicionaProdutoraAsync(ProdutoraRequest request)
        {
            return Ok(await _produtoraService.AdicionaProdutoraAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarProdutoraAsync(ProdutoraRequest request, int id)
        {
            return Ok(await _produtoraService.AtualizarProdutoraAsync(request, id));
        }

        [HttpDelete]
        public async Task<IActionResult> DeletarProdutoraAsync(int id)
        {
            return Ok(await _produtoraService.DeletarProdutoraAsync(id));
        }
    }
}

//PUT --> atualizar
//POST --> criar
//GET --> selecionar