using Application.Dto;
using Application.IService;
using Application.ViewModel;
using AutoMapper;
using Domain.Structure;
using Dominio.Model;
using Persistence.IRepository;
using System;
using System.Security.Cryptography;

namespace Aplicacao.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthService(IUserRepository userRepository, ITokenService tokenService, IMapper mapper)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        private string GenerateHashPassword(string password)
        {
            // Gera um salt aleatório de 16 bytes
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // Gera o hash da senha com o salt
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000))
            {
                byte[] hash = pbkdf2.GetBytes(20); // 20 bytes de hash

                // Concatena salt + hash para armazenar no banco
                byte[] hashBytes = new byte[36];
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);

                return Convert.ToBase64String(hashBytes);
            }
        }

        public async Task<ResponseBaseViewModel<UsuarioViewModel>> CadastroUsuario(LoginDto cadastroDTO)
        {
            string passwordHash = GenerateHashPassword(cadastroDTO.Password);
            cadastroDTO.Password = passwordHash;
            
            var user = _userRepository.GetUserByUsername(cadastroDTO.Username);
            if (user != null)
            {
                return new ResponseBaseViewModel<UsuarioViewModel>
                {
                    Dados = null,
                    Descricao = "Já exoste esse usuário",
                    Mensagem = "Já existe esse usuário",
                    Status = false
                };
            }
            UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
            usuarioViewModel.DtUserCreate = DateTime.UtcNow;
            usuarioViewModel.Username = cadastroDTO.Username;
            usuarioViewModel.PasswordHash = cadastroDTO.Password;
            usuarioViewModel.Status = true;
            User userorg = _mapper.Map<User>(usuarioViewModel);
            userorg = await _userRepository.Cadastrar(userorg);

            return new ResponseBaseViewModel<UsuarioViewModel>
            {
                Dados = null,
                Descricao = "Cadastrado com sucesso",
                Mensagem = "Cadastrado comm sucesso",
                Status = true

            };
        }

        public LoginResultDto Login(LoginDto loginDto)
        {
            var user = _userRepository.GetUserByUsername(loginDto.Username);
            UsuarioViewModel usuarioViewModel = _mapper.Map<UsuarioViewModel>(user);
            if (user == null || !VerifyPassword(user.PasswordHash, loginDto.Password))
            {
                return new LoginResultDto
                {
                    Success = false,
                    Message = "Invalid username or password"
                };
            }

            var token = _tokenService.GenerateToken(usuarioViewModel);

            return new LoginResultDto
            {
                Success = true,
                Token = token
            };
        }

        private bool VerifyPassword(string storedHash, string providedPassword)
        {
            // Converte o hash armazenado para um array de bytes
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            // Extrai o salt (primeiros 16 bytes)
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // Gera o hash da senha fornecida usando o mesmo salt
            using (var pbkdf2 = new Rfc2898DeriveBytes(providedPassword, salt, 100000))
            {
                byte[] hash = pbkdf2.GetBytes(20); // 20 bytes de hash

                // Compara byte a byte o hash armazenado com o hash gerado
                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 16] != hash[i])
                        return false; // Hashs não coincidem
                }
            }
            return true; // Hashs coincidem
        }

        public ResponseBaseViewModel<UsuarioSearchViewModel> GetUserById(int id)
        {
            ResponseBaseViewModel<UsuarioSearchViewModel> responseBaseViewModel;
            try
            {
                var response = _userRepository.GetUserById(id);
                responseBaseViewModel = _mapper.Map<ResponseBaseViewModel<UsuarioSearchViewModel>>(response);
                return responseBaseViewModel;
            }
            catch (Exception ex)
            {

                responseBaseViewModel = new ResponseBaseViewModel<UsuarioSearchViewModel>();
                responseBaseViewModel.Mensagem = MsgErro.ErroParametroRecebido;
                responseBaseViewModel.Descricao = ex.Message;
                return responseBaseViewModel;
            }
        }

        public async Task<ResponseBaseViewModel<UsuarioViewModel>> AtualizarUsuario(UserEditDto userEditDto, int id)
        {
            ResponseBaseViewModel<UsuarioViewModel> responseBaseViewModel;
            try
            {
                var response = await _userRepository.AtualizarUsuario(userEditDto.Descricao, userEditDto.Localizacao, id);
                if (response == null)
                {
                    throw new Exception("Não foi possivel atualizar usuario");
                }
                responseBaseViewModel = _mapper.Map<ResponseBaseViewModel<UsuarioViewModel>>(response);
                return responseBaseViewModel;
            }
            catch (Exception ex)
            {

                responseBaseViewModel = new ResponseBaseViewModel<UsuarioViewModel>();
                responseBaseViewModel.Mensagem = MsgErro.ErroParametroRecebido;
                responseBaseViewModel.Descricao = ex.Message;
                return responseBaseViewModel;
            }
        }
    }
}
