using Application.Dto;
using Application.IService;
using Dominio.Model;
using Persistence.IRepository;
using System;

namespace Aplicacao.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public LoginResultDto Login(LoginDto loginDto)
        {
            var user = _userRepository.GetUserByUsername(loginDto.Username);

            if (user == null || !VerifyPassword(user.PasswordHash, loginDto.Password))
            {
                return new LoginResultDto
                {
                    Success = false,
                    Message = "Invalid username or password"
                };
            }

            var token = _tokenService.GenerateToken(user);

            return new LoginResultDto
            {
                Success = true,
                Token = token
            };
        }

        private bool VerifyPassword(string storedHash, string providedPassword)
        {
            // Verificação de senha hash (exemplo básico, substitua com sua própria lógica)
            return storedHash == providedPassword; // Exemplo simples, use uma hash function de verdade aqui
        }
    }
}
