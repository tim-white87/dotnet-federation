using AutoMapper;

namespace Identity.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserModel, RegisterInputType>();
            CreateMap<LoginUserModel, LoginInputType>();
        }
    }
}