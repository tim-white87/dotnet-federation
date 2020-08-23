using GraphQL;
using Identity.API.User;

namespace Identity.API.GraphQl.Identity
{
    [GraphQLMetadata("User", IsTypeOf = typeof(UserModel))]
    public class AccountType
    {
        /// <summary>
        /// Id field resolver
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public string Id(UserModel identity) => identity.Id;

        /// <summary>
        /// Name field resolver
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public string Name(UserModel identity) => identity.Name;

        /// <summary>
        /// Username field resolver
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public string Username(UserModel identity) => identity.Username;
    }
}