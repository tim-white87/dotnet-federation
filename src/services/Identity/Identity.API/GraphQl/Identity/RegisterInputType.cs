using GraphQL;
using GraphQL.Types;

namespace Identity.API.GraphQl.Identity
{
    [GraphQLMetadata("RegisterInputType", IsTypeOf = typeof(InputObjectGraphType))]
    public class RegisterInputType : InputObjectGraphType
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}