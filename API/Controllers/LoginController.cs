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

        [HttpPost("cadastro")]
        public async Task<IActionResult> Cadastro([FromBody] LoginDto loginDto)
        {
            var result = await _authService.CadastroUsuario(loginDto);

            if (!result.Status)
                return Unauthorized(result.Mensagem);

            return Ok(result);
        }

        [HttpGet("pegar-usuario-por-id")]
        [Authorize]
        public IActionResult PegarUsuarioPorId([FromHeader]int id)
        {
            var result = _authService.GetUserById(id);

            if (!result.Status)
                return Unauthorized(result.Mensagem);

            return Ok(result);
        }
    }
}