using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesteEntrevista.Domain.DTO;
using TesteEntrevista.Domain.Interfaces.Services;

namespace TesteEntrevista.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CaminhoesController : ControllerBase
    {
        private readonly ICaminhaoService _caminhaoService;

        public CaminhoesController(ICaminhaoService caminhaoService)
        {
            _caminhaoService = caminhaoService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CaminhaoResponseDTO>), 200)]
        public async Task<IActionResult> RecuperarCaminhoes()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CaminhaoResponseDTO), 200)]
        public async Task<IActionResult> RecuperarCaminhaoPorId(int id)
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(typeof(CaminhaoResponseDTO), 201)]
        public async Task<IActionResult> CriarCaminhao()
        {
            return Ok();
        }

        [HttpPut("id")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> AtualizarCaminhao(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> ApagarCaminhao(int id)
        {
            return Ok();
        }
    }
}