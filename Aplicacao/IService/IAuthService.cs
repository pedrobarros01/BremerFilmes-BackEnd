using Application.Dto;
using Application.ViewModel;
using Domain.Structure;
using Dominio.Model;

namespace Application.IService
{
    public interface IAuthService
    {
        LoginResultDto Login(LoginDto loginDto);
        Task<ResponseBaseViewModel<UsuarioViewModel>> CadastroUsuario(LoginDto cadastroDTO);
        ResponseBaseViewModel<UsuarioSearchViewModel> GetUserById(int id);
        Task<ResponseBaseViewModel<UsuarioViewModel>> AtualizarUsuario(UserEditDto userEdit, int id);
    }
}
