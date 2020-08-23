using System;
using GraphQL;
using Identity.API.User;

namespace Identity.API.GraphQl.Identity
{
    public class IdentityMutation
    {
        [GraphQLMetadata("login")]
        public UserModel Login()
        {
            throw new NotImplementedException();
        }

        [GraphQLMetadata("register")]
        public UserModel Register()
        {
            throw new NotImplementedException();
        }
    }
}