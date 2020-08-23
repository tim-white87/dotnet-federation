using System;
using Identity.API.Identity;

namespace Identity.API.GraphQl
{
    public class Query
    {
        private readonly IServiceProvider _serviceProvider;

        public Query(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IdentityQuery Identity() => new IdentityQuery(_serviceProvider);
    }
}