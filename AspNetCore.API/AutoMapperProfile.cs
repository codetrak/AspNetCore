using System.Collections.Generic;
using AspNetCore.API.Dto;
using AspNetCore.Domain.Entities;
using AutoMapper;

namespace AspNetCore.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateMap<Person, PersonDto>();
            // CreateMap<Location, PersonDto>();
            // CreateMap<Phone, PersonDto>();
            // CreateMap<Email, PersonDto>();
        }
    }
}