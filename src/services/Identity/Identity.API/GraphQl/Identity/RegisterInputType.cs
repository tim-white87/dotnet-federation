using GraphQL;
using GraphQL.Types;

namespace Identity.API.GraphQl.Identity
{
    [GraphQLMetadata("RegisterInput")]
    public class RegisterInputType
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}