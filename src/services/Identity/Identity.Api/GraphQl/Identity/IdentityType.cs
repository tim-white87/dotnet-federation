using System;
using System.Threading.Tasks;
using GraphQL;
using Identity.Api.Application.User;
using Identity.Data.Models;
using MediatR;

namespace Identity.Api.GraphQl.Identity
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