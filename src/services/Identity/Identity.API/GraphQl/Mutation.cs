using Identity.API.Identity;

namespace Identity.API.GraphQl
{
    public class Mutation
    {
        public IdentityMutation IdentityMutation() => new IdentityMutation();
    }
}