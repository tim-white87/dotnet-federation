using System;
using GraphQL;
using GraphQL.Utilities;
using Identity.Api.GraphQl.Identity;
using MediatR;

namespace Identity.Api.GraphQl
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