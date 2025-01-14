﻿using AutoMapper;
using VetClinic.Core.Entities;
using VetClinic.WebApi.ViewModels;

namespace VetClinic.WebApi.Mappers
{
    public class PositionMapperProfile : Profile
    {
        public PositionMapperProfile()
        {
            CreateMap<Position, PositionViewModel>().ReverseMap();
        }
    }
}
