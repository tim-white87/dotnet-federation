using System.Threading.Tasks;
using GraphQL;
using Identity.API.Application.User;
using Identity.Infrastructure.Models;
using MediatR;

namespace Identity.API.GraphQl.Identity
{
    public class IdentityQuery
    {
        private readonly IMediator _mediator;

        public IdentityQuery(IMediator mediator)
        {
            _mediator = mediator;
        }

        [GraphQLMetadata("me")]
        public async Task<AppUser> GetMe() => await _mediator.Send(new GetUserRequest());
    }
}