using System;
using GraphQL;

namespace Identity.API.Identity
{
    public class IdentityQuery
    {
        private readonly IServiceProvider _serviceProvider;

        public IdentityQuery(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [GraphQLMetadata("me")]
        public AccountViewModel GetMe()
        {
            return new AccountViewModel
            {
                Id = "test",
                Name = "Timmy"
            };
        }
    }
}