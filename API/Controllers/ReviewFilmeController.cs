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

        [HttpDelete("deletar-review")]
        public async Task<IActionResult> Deletar([FromHeader] int id)
        {
            var response = await _reviewService.DeletarReview(id);
            if (!response.Status)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("dar-curtida")]
        public async Task<IActionResult> DarCurtida([FromHeader] int id)
        {
            var response = await _reviewService.DarCurtida(id);
            if (!response.Status && response.Descricao != "404")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("editar-comentario")]
        public async Task<IActionResult> EditarComentario([FromBody] ReviewEditDto edit)
        {
            var response = await _reviewService.EditarComentario(edit);
            if (!response.Status)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("pegar-review")]
        public IActionResult PegarReview([FromHeader] int id)
        {
            var response =  _reviewService.PegarReview(id);
            if (!response.Status && response.Descricao != "404")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("pegar-reviews")]
        public IActionResult PegarReviews()
        {
            var response = _reviewService.PegarReviews();
            if (!response.Status && response.Descricao != "404")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("pegar-reviews-de-usuario")]
        public IActionResult PegarReviewsPorUsuario([FromHeader] int idUsuario)
        {
            var response = _reviewService.PegarReviewsPorUsuario(idUsuario);
            if (!response.Status && response.Descricao != "404")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("pegar-reviews-de-filme")]
        public IActionResult PegarReviewsPorFilme([FromHeader] int idTmdbFilme)
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