using Application.Dto;
using Application.ViewModel;
using AutoMapper;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class ExemploMapper : Profile
    {
        public ExemploMapper() 
        {
            CreateMap<ExemploViewModel,Exemplo>().ReverseMap()
               .ForMember(Exemplo => Exemplo.Id,
                       map => map.MapFrom(ExemploViewModel => ExemploViewModel.Id))
               .ForMember(Exemplo => Exemplo.Nome,
                       map => map.MapFrom(ExemploViewModel => ExemploViewModel.Nome))
               .ForMember(Exemplo => Exemplo.Descricao,
                       map => map.MapFrom(ExemploViewModel => ExemploViewModel.Descricao))
               .ForMember(Exemplo => Exemplo.Status,
                       map => map.MapFrom(ExemploViewModel => ExemploViewModel.Status))
               .ForMember(Exemplo => Exemplo.Dinheiro,
                       map => map.MapFrom(ExemploViewModel => ExemploViewModel.Dinheiro))
               .ForMember(Exemplo => Exemplo.ValorDouble,
                       map => map.MapFrom(ExemploViewModel => ExemploViewModel.ValorDouble))
               .ForMember(Exemplo => Exemplo.ValorFloat,
                       map => map.MapFrom(ExemploViewModel => ExemploViewModel.ValorFloat));

            CreateMap<ExemploDto, Exemplo>().ReverseMap()
                .ForMember(ExemploDto => ExemploDto.Id,
                        map => map.MapFrom(Exemplo => Exemplo.Id))
                .ForMember(ExemploDto => ExemploDto.Nome,
                        map => map.MapFrom(Exemplo => Exemplo.Nome))
                .ForMember(ExemploDto => ExemploDto.Descricao,
                        map => map.MapFrom(Exemplo => Exemplo.Descricao))
                .ForMember(ExemploDto => ExemploDto.Dinheiro,
                        map => map.MapFrom(Exemplo => Exemplo.Dinheiro))
                .ForMember(ExemploDto => ExemploDto.ValorDouble,
                        map => map.MapFrom(Exemplo => Exemplo.ValorDouble))
                .ForMember(ExemploDto => ExemploDto.ValorFloat,
                        map => map.MapFrom(Exemplo => Exemplo.ValorFloat));
        }
    }
}