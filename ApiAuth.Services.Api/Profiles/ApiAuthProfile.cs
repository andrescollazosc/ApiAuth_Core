using ApiAuth.Domain.Entities;
using ApiAuth.Services.Dto;
using AutoMapper;

namespace ApiAuth.Services.Api.Profiles
{
    public class ApiAuthProfile : Profile {
        public ApiAuthProfile()
        {
            this.CreateMap<Users, UserSignUpDto>().ReverseMap();
            this.CreateMap<Users, UserViewDto>().ReverseMap();
            this.CreateMap<Users, UserUpdateDto>().ReverseMap();
            this.CreateMap<Users, UserLoggedDto>().ReverseMap();
            this.CreateMap<UserType, UserTypeDto>().ReverseMap();
            this.CreateMap<ProfileEnt, ProfileEntDto>().ReverseMap();
            this.CreateMap<Menu, MenuDto>().ReverseMap();
            this.CreateMap<ChildMenu, ChildMenuDto>().ReverseMap();
            this.CreateMap<EditorialHouse, EditorialHouseDto>().ReverseMap();
            this.CreateMap<Hero, HeroViewDto>().ReverseMap();
            this.CreateMap<Hero, HeroRegisterDto>().ReverseMap();
        }
    }
}
