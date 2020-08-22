using Identity.API.Identity;

namespace Identity.API.GraphQl
{
    public class Query
    {
        public IdentityType Identity() => new IdentityType();
    }
}