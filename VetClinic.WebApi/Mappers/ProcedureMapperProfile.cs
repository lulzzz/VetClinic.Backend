﻿using AutoMapper;
using VetClinic.Core.Entities;
using VetClinic.WebApi.ViewModels;

namespace VetClinic.WebApi.Mappers
{
    public class ProcedureMapperProfile : Profile
    {
        public ProcedureMapperProfile()
        {
            CreateMap<Procedure, ProcedureViewModel>().ReverseMap();
        }
    }
}
