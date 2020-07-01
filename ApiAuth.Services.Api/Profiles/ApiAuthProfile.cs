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
        }
    }
}
