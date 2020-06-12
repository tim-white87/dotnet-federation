using System;
using GraphQL;
using Microsoft.AspNetCore.Identity;

namespace user.GraphQL
{
    /// <summary>
    /// User anemic model
    /// </summary>
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }

    /// <summary>
    /// User Resolver
    /// </summary>
    [GraphQLMetadata("User", IsTypeOf = typeof(User))]
    public class UserType
    {
        public static readonly string Schema = @"
            extend type Query {
                me: User
            }

            type User @key(fields: ""id"") {
                id: ID!
                name: String
                username: String
            }";

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
        public string Id(User user) => user.Id;

        /// <summary>
        /// Name field resolver
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string Name(User user) => user.Name;

        /// <summary>
        /// Username field resolver
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string Username(User user) => user.UserName;
    }
}