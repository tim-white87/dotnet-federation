using GraphQL;
using Identity.API.Identity;

namespace Identity.API.GraphQl
{
    public sealed class Query
    {
        [GraphQLMetadata("identity")]
        public IdentityQueries Identity()
        {
            return new IdentityQueries();
        }
    }

}