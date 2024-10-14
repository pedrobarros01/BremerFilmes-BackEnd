using Application.Dto;
using Application.IService;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExemploController : ControllerBase
    {
        private readonly IExemploService _exemploService;

        public ExemploController(IExemploService exemploService)
        {
            _exemploService = exemploService;
        }

        [HttpGet("obter-exemplos-usando-sql")]
        public async Task<IActionResult> GetWithSql()
        {
            var result = await _exemploService.ConsultarExemploUsandoSQL();
            return Ok(result);
        }

        [HttpGet("obter-exemplos-usando-linked")]
        public async Task<IActionResult> GetWithLinked()
        {
            var result = await _exemploService.ConsultarExemploUsandoLinked();
            return Ok(result);
        }

        [HttpGet("obter-exemplos-por-id")]
        public async Task<IActionResult> GetById([FromHeader] int id)
        {
            var result = await _exemploService.ConsultarExemploPorId(id);
            return Ok(result);
        }

        [HttpPost("Cadastrar-exemplo")]
        public async Task<IActionResult> Post([FromBody] ExemploDto exemploCadastroDto)
        {
            var result = await _exemploService.CadastrarExemplo(exemploCadastroDto);
            return Ok(result);
        }

        [HttpPut("Atualizar-exemplo")]
        public async Task<IActionResult> Put([FromBody] ExemploDto exemploAtualizacaoDto)
        {
            var result = await _exemploService.EditarExemplo(exemploAtualizacaoDto);
            return Ok(result);
        }

        [HttpDelete("Desativar-exemplo")]
        public async Task<IActionResult> Delete([FromHeader] int idExemplo)
        {
            var result = await _exemploService.DesativarExemplo(idExemplo);
            return Ok(result);
        }

    }
}
