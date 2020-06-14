using GraphQL;

namespace UserService.User
{
    /// <summary>
    /// Me resolver
    /// </summary>
    public class UserQuery
    {
        [GraphQLMetadata("me")]
        public User GetUser()
        {
            return new User
            {
                Name = "Timmy"
            };
        }
    }
}