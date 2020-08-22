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

        public IdentityType Identity() => new IdentityType(_serviceProvider);
    }
}