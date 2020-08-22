using System;
using GraphQL;

namespace Identity.API.Identity
{
    public class IdentityType
    {
        private readonly IServiceProvider _serviceProvider;

        public IdentityType(IServiceProvider serviceProvider)
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