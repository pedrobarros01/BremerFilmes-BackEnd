using Application.Dto;

namespace Application.IService
{
    public interface IAuthService
    {
        LoginResultDto Login(LoginDto loginDto);
    }
}
