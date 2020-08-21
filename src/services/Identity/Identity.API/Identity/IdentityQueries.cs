using GraphQL;

namespace Identity.API.Identity
{
    public class IdentityQueries
    {
        public IdentityViewModel Me()
        {
            return new IdentityViewModel
            {
                Id = "test",
                Name = "Timmy"
            };
        }
    }
}