using System;
using GraphQL;

namespace Identity.API.Identity
{
    public class IdentityMutation
    {
        [GraphQLMetadata("login")]
        public AccountViewModel Login()
        {
            throw new NotImplementedException();
        }

        [GraphQLMetadata("register")]
        public AccountViewModel Register()
        {
            throw new NotImplementedException();
        }
    }
}