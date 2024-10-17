using Application.Dto;
using Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface ITokenService
    {
        string GenerateToken(UsuarioViewModel user);
    }
}
