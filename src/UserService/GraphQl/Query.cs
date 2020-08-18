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
        public UserModel GetUser()
        {
            return new UserModel
            {
                Name = "Timmy",
                UserName = "tim"
            };
        }
    }
}