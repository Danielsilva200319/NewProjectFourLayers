using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<City, CityDto>().ReverseMap();
        CreateMap<State,StateListCityDto>().ReverseMap();
        CreateMap<State, StateDto>().ReverseMap();
        CreateMap<Country, CountryDto>().ReverseMap();
        CreateMap<Costumer, CostumerDto>().ReverseMap();
    }
}