using System;
using GraphQL.Utilities;
using Identity.API.GraphQl.Identity;
using MediatR;

namespace Identity.API.GraphQl
{
    public class Mutation
    {
        private readonly IServiceProvider _serviceProvider;

        public Mutation(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IdentityMutation IdentityOps() => new IdentityMutation(_serviceProvider.GetRequiredService<IMediator>());
    }
}