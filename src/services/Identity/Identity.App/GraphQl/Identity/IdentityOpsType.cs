using System;
using System.Threading.Tasks;
using GraphQL;
using Identity.API.Application.User;
using Identity.Data.Models;
using MediatR;

namespace Identity.API.GraphQl.Identity
{
    [GraphQLMetadata("IdentityOps")]
    public class IdentityOpsType
    {
        private readonly IMediator _mediator;

        public IdentityOpsType(IMediator mediator)
        {
            _mediator = mediator;
        }

        [GraphQLMetadata("login")]
        public async Task<AppUser> Login(LoginInputType input) => await _mediator.Send(new LoginUserRequest(input));

        [GraphQLMetadata("register")]
        public async Task<bool> Register(RegisterInputType input) => await _mediator.Send(new CreateUserRequest(input));
    }
}