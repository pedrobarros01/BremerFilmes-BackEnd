using Application.Dto;
using Application.ViewModel;

namespace Application.IService
{
    public interface IAuthService
    {
        LoginResultDto Login(LoginDto loginDto);
        Task<ResponseBaseViewModel<UsuarioViewModel>> CadastroUsuario(LoginDto cadastroDTO);
    }
}
