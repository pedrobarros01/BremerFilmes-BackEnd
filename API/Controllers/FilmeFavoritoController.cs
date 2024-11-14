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
    public class FilmeFavoritoController : ControllerBase
    {
        private readonly IFilmesFavoritosService _filmesFavoritosService;

        public FilmeFavoritoController(IFilmesFavoritosService filmesFavoritosService)
        {
            _filmesFavoritosService = filmesFavoritosService;
        }

        [HttpPost("adicionar-filme-favorito")]
        public async Task<IActionResult> CriarFilmeFavorito([FromBody] FilmeFavCreateDto body)
        {
            var response = await _filmesFavoritosService.CriarFilmeFavorito(body);
            if (!response.Status)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("deletar-filme-favorito/{id}")]
        public async Task<IActionResult> DeletarFilmeFavorito(int id)
        {
            var response = await _filmesFavoritosService.DeletarFilmeFavorito(id);
            if (!response.Status)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("pegar-filme-favorito-por-usuario/{idUsuario}")]
        public IActionResult PegaFilmeFavoritoPorUsuario(int idUsuario)
        {
            var response =  _filmesFavoritosService.PegarFilmesFavoritosPorUsuario(idUsuario);
            if (!response.Status)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("pegar-filme-favorito-do-usuario/{idUsuario}/{idFilme}")]
        public IActionResult PegaFilmeFavoritoDoUsuario(int idUsuario, int idFilme)
        {
            var response = _filmesFavoritosService.PegarFilmeFavoritoPorUsuarioETMDB(idUsuario, idFilme);
            return Ok(response);
        }
    }
}