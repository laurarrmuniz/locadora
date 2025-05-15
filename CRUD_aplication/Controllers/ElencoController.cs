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
    public class ElencoController : ControllerBase
    {
        private readonly IElencoService _elencoService;
        public ElencoController(IElencoService elencoService)
        {
            _elencoService = elencoService;
        }

        [HttpGet]
        public async Task<IActionResult> BuscaElenco()
        {
            return Ok(await _elencoService.BuscaElencoAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscaElenco(int id)
        {
            var result = await _elencoService.BuscaElencoAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionaElencoAsync(ElencoRequest request)
        {
            return Ok(await _elencoService.AdicionaElencoAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarAsync(ElencoRequest request, int id)
        {
            return Ok(await _elencoService.AtualizarElencoAsync(request, id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _elencoService.DeleteAsync(id);
            if (result == false)
                return NotFound();
            return Ok(result);
        }

    }
}
