using Application.Dto;
using Application.IService;
using Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PessoaFavoritaController : ControllerBase
    {
        private readonly IPessoaFavoritaService _pessoaFavoritaService;

        public PessoaFavoritaController(IPessoaFavoritaService pessoaFavoritaService)
        {
            _pessoaFavoritaService = pessoaFavoritaService;
        }

        [HttpPost("adicionar-pessoa-favorita")]
        public async Task<IActionResult> CriarPessoaFavorita([FromBody] PessoaFavCreateDto body)
        {
            var response = await _pessoaFavoritaService.CriarPessoaFavorita(body);
            if (!response.Status)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("deletar-pessoa-favorita")]
        public async Task<IActionResult> DeletarPessoaFavorita([FromHeader] int id)
        {
            var response = await _pessoaFavoritaService.DeletarPesssoaFavorita(id);
            if (!response.Status)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("pegar-pessoa-favorita-por-usuario")]
        public IActionResult PegarPessoaFavoritaPorUsuario([FromHeader] int idUsuario)
        {
            var response =  _pessoaFavoritaService.PegarPessoasFavoritaPorUsuario(idUsuario);
            if (!response.Status)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}