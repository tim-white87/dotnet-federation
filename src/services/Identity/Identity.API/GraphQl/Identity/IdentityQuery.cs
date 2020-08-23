using System;
using GraphQL;
using Identity.API.User;

namespace Identity.API.GraphQl.Identity
{
    public class IdentityQuery
    {
        [GraphQLMetadata("me")]
        public UserModel GetMe()
        {
            return new UserModel
            {
                Id = "test",
                Name = "Timmy"
            };
        }
    }
}