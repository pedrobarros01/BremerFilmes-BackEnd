using Application.Dto;
using Application.IService;
using Application.ViewModel;
using AutoMapper;
using Domain.Structure;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Persistence.IRepository;
using Persistence.Repository;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Service
{
    public class TokenService : ITokenService
    {
        private IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(UsuarioViewModel user)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("username", user.Username),
                new Claim("id", user.Id.ToString()),
                new Claim("loginTimestamp", DateTime.UtcNow.ToString())
            };
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SymmetricSecurityKey"]));
            var signingcredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                expires: DateTime.UtcNow.AddMinutes(100),
                claims: claims,
                signingCredentials: signingcredentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
