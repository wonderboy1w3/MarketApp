using AutoMapper;
using MarketApp.Domain.Entities;
using MarketApp.Domain.Entities.Users;
using MarketApp.Service.DTOs;

namespace MarketApp.Service.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Product, ProductForCreationDto>().ReverseMap();
        CreateMap<User, UserForLoginDto>().ReverseMap();
    }
}
