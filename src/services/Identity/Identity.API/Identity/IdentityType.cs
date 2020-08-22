using GraphQL;

namespace Identity.API.Identity
{
    public class IdentityType
    {
        [GraphQLMetadata("me")]
        public AccountViewModel GetMe()
        {
            return new AccountViewModel
            {
                Id = "test",
                Name = "Timmy"
            };
        }
    }
}