using System;
using GraphQL;
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

        [GraphQLMetadata("identityOps")]
        public IdentityOpsType IdentityOps() => new IdentityOpsType(_serviceProvider.GetRequiredService<IMediator>());
    }
}