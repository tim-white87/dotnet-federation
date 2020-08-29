using System;
using System.Threading.Tasks;
using GraphQL;
using Identity.API.Application.User;
using Identity.Data.Models;
using MediatR;

namespace Identity.API.GraphQl.Identity
{
    [GraphQLMetadata("Identity")]
    public class IdentityType
    {
        private readonly IMediator _mediator;

        public IdentityType(IMediator mediator)
        {
            _mediator = mediator;
        }

        [GraphQLMetadata("me")]
        public async Task<AppUser> GetMe() => await _mediator.Send(new GetUserRequest());

    }
}