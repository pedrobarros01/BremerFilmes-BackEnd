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
    public class ReviewFilmeController : ControllerBase
    {
        private readonly IReviewFilmeService _reviewService;

        public ReviewFilmeController(IReviewFilmeService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost("criar-review")]
        public async Task<IActionResult> CriarReview([FromBody] ReviewCreateDto body)
        {
            var response = await _reviewService.CriarReview(body);
            if (!response.Status)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("deletar-review/{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var response = await _reviewService.DeletarReview(id);
            if (!response.Status)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("dar-curtida/{id}")]
        public async Task<IActionResult> DarCurtida(int id)
        {
            var response = await _reviewService.DarCurtida(id);
            if (!response.Status && response.Descricao != "404")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("editar-review")]
        public async Task<IActionResult> EditarComentario([FromBody] ReviewEditDto edit)
        {
            var response = await _reviewService.EditarComentario(edit);
            if (!response.Status)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }



        [HttpGet("pegar-reviews-de-usuario/{idUsuario}")]
        public IActionResult PegarReviewsPorUsuario( int idUsuario)
        {
            var response = _reviewService.PegarReviewsPorUsuario(idUsuario);
            if (!response.Status && response.Descricao != "404")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("pegar-reviews-de-filme/{idTmdbFilme}")]
        public IActionResult PegarReviewsPorFilme(int idTmdbFilme)
        {
            var response = _reviewService.PegarReviewsPorFilme(idTmdbFilme);
            if (!response.Status && response.Descricao != "404")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}