using GraphQL;
using Identity.API.Identity;

namespace Identity.API.GraphQl
{
    public class Query
    {
        [GraphQLMetadata("identity")]
        public IdentityType Identity()
        {
            return new IdentityType();
        }
    }
}