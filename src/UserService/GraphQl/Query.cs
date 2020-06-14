using GraphQL;
using UserService.User;

namespace UserService.GraphQl
{
    /// <summary>
    /// Me resolver
    /// </summary>
    public class Query
    {
        // TODO: can I use composition here?
        [GraphQLMetadata("me")]
        public User.User GetUser()
        {
            return new User.User
            {
                Name = "Timmy",
                UserName = "tim"
            };
        }
    }
}