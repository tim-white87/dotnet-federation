namespace UserService.User
{
    using GraphQL;

    namespace UserService.User
    {
        /// <summary>
        /// Me resolver
        /// </summary>
        public class UserQuery
        {
            [GraphQLMetadata("me")]
            public UserModel GetUser()
            {
                return new UserModel
                {
                    Name = "Timmy"
                };
            }
        }
    }
}