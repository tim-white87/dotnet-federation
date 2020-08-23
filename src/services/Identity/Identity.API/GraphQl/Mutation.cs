using Identity.API.GraphQl.Identity;

namespace Identity.API.GraphQl
{
    public class Mutation
    {
        public IdentityMutation IdentityOps() => new IdentityMutation();
    }
}