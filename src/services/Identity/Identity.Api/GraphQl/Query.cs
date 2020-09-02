using System;
using GraphQL;
using GraphQL.Utilities;
using Identity.API.GraphQl.Identity;
using MediatR;

namespace Identity.API.GraphQl
{
    public class Query
    {
        private readonly IServiceProvider _serviceProvider;

        public Query(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [GraphQLMetadata("identity")]
        public IdentityType IdentityType() => new IdentityType(_serviceProvider.GetRequiredService<IMediator>());
    }
}