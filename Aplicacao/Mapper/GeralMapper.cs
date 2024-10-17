using Application.Dto;
using Application.ViewModel;
using AutoMapper;
using Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class GeralMapper : Profile
    {
        public GeralMapper() 
        {
            CreateMap<User, UsuarioViewModel>();
            CreateMap<UsuarioViewModel, User>();
            CreateMap<LoginDto, UsuarioViewModel>();
            CreateMap<UsuarioViewModel, LoginDto>();
        }
    }
}