using System;
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

        public IdentityQuery Identity() => new IdentityQuery(_serviceProvider.GetRequiredService<IMediator>());
    }
}