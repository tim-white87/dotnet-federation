using AutoMapper;
using Identity.Api.GraphQl.Identity;
using Identity.Service.User.Models;

namespace Identity.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterInputType, CreateUserModel>();
            CreateMap<LoginInputType, LoginUserModel>();
        }
    }
}