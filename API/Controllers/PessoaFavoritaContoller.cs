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

        [HttpDelete("deletar-pessoa-favorita/{id}")]
        public async Task<IActionResult> DeletarPessoaFavorita(int id)
        {
            var response = await _pessoaFavoritaService.DeletarPesssoaFavorita(id);
            if (!response.Status)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("pegar-pessoa-favorita-por-usuario-e-cargo/{idUsuario}/{idPessoaTMDB}/{cargo}")]
        public IActionResult PegarPessoaFavoritaPorUsuarioETMDB(int idUsuario, int idPessoaTMDB, string cargo)
        {
            var response =  _pessoaFavoritaService.PegarPessoaFavoritaPorUsuarioETMDB(idUsuario, idPessoaTMDB, cargo);
            if (!response.Status && response.Descricao != "404")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("pegar-atores-favoritos-por-usuario/{idUsuario}")]
        public IActionResult PegarAtoresFavoritosPorUsuario(int idUsuario)
        {
            var response = _pessoaFavoritaService.PegarAtoresFavoritosPorUsuario(idUsuario);
            if (!response.Status && response.Descricao != "404")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("pegar-diretores-favoritos-por-usuario/{idUsuario}")]
        public IActionResult PegarDiretoresFavoritosPorUsuario(int idUsuario)
        {
            var response = _pessoaFavoritaService.PegarDiretoresFavoritosPorUsuario(idUsuario);
            if (!response.Status && response.Descricao != "404")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}