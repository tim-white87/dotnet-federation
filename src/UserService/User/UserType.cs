using System;
using GraphQL;

namespace UserService.User
{
    /// <summary>
    /// User Resolver
    /// </summary>
    [GraphQLMetadata("User", IsTypeOf = typeof(UserModel))]
    public class UserType
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// UserType constructor
        /// </summary>
        /// <param name="sp">Service Provider</param>
        public UserType(IServiceProvider sp)
        {
            _serviceProvider = sp;
        }

        /// <summary>
        /// Id field resolver
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string Id(UserModel user) => user.Id;

        /// <summary>
        /// Name field resolver
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string Name(UserModel user) => user.Name;

        /// <summary>
        /// Username field resolver
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string Username(UserModel user) => user.UserName;
    }
}