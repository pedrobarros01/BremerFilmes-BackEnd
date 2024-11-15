using Application.Dto;
using Application.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
            
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var result = _authService.Login(loginDto);

            if (!result.Success)
                return Unauthorized(result.Message);

            return Ok(new { token = result.Token });
        }
        [HttpPut("atualizar-usuario/{id}")]
        [Authorize]
        public async Task<IActionResult> Atualizacao(int id, [FromBody] UserEditDto userEditDto)
        {
            var result = await _authService.AtualizarUsuario(userEditDto, id);

            if (!result.Status)
                return BadRequest(result.Mensagem);

            return Ok(result);
        }

        [HttpPost("cadastro")]
        
        public async Task<IActionResult> Cadastro([FromBody] LoginDto loginDto)
        {
            var result = await _authService.CadastroUsuario(loginDto);

            if (!result.Status)
                return Unauthorized(result.Mensagem);

            return Ok(result);
        }

        [HttpGet("pegar-usuario-por-id/{id}")]
        [Authorize]
        public IActionResult PegarUsuarioPorId(int id)
        {
            var result = _authService.GetUserById(id);

            if (!result.Status)
                return Unauthorized(result.Mensagem);

            return Ok(result);
        }
    }
}