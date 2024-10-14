using Application.Dto;
using Application.ViewModel;
using AutoMapper;
using Domain.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class ResponseBaseMapper : Profile
    {
        public ResponseBaseMapper() 
        {
            CreateMap(typeof(ResponseBaseViewModel<>), typeof(ResponseBase<>)).ReverseMap();
        }
    }
}
