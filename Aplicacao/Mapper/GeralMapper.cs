using Application.Dto;
using Application.ViewModel;
using AutoMapper;
using Domain.Model;
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
            CreateMap<UsuarioSearchViewModel, User>();
            CreateMap<User, UsuarioSearchViewModel>();
            CreateMap<LoginDto, UsuarioViewModel>()
                .ForMember(UsuarioViewModel => UsuarioViewModel.PasswordHash, map => map.MapFrom(LoginDto => LoginDto.Password));
            CreateMap<UsuarioViewModel, LoginDto>()
                .ForMember(LoginDTO => LoginDTO.Password, map => map.MapFrom(Usuario => Usuario.PasswordHash))
                ;
            CreateMap<ReviewCreateDto, ReviewFilme>();
            CreateMap<ReviewFilmeViewModel, ReviewFilme>();
            CreateMap<ReviewFilme, ReviewFilmeViewModel>();
            CreateMap<PessoaFavoritaViewModel, PessoaFav>();
            CreateMap<PessoaFav, PessoaFavoritaViewModel>();
            CreateMap<PessoaFavCreateDto, PessoaFavoritaViewModel>();
            CreateMap<FilmeFavoritoViewModel, FilmeFav>();
            CreateMap<FilmeFav, FilmeFavoritoViewModel>();
            CreateMap<FilmeFavCreateDto, FilmeFavoritoViewModel>();

        }
    }
}