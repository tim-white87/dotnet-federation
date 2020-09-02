using System.Threading.Tasks;
using AutoMapper;
using GraphQL;
using Identity.Data.Models;
using Identity.Service.User.Command;
using Identity.Service.User.Models;
using MediatR;

namespace Identity.Api.GraphQl.Identity
{
    [GraphQLMetadata("IdentityOps")]
    public class IdentityOpsType
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public IdentityOpsType(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [GraphQLMetadata("login")]
        public async Task<AppUser> Login(LoginInputType input) => await _mediator.Send(new LoginUserCommand(_mapper.Map<LoginUserModel>(input)));

        [GraphQLMetadata("register")]
        public async Task<bool> Register(RegisterInputType input) => await _mediator.Send(new CreateUserCommand(_mapper.Map<CreateUserModel>(input)));
    }
}