using System;
using GraphQL;

namespace Identity.API.Identity
{
    [GraphQLMetadata("Account", IsTypeOf = typeof(AccountViewModel))]
    public class AccountType
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// IdentityType constructor
        /// </summary>
        /// <param name="sp">Service Provider</param>
        public AccountType(IServiceProvider sp)
        {
            _serviceProvider = sp;
        }

        /// <summary>
        /// Id field resolver
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public string Id(AccountViewModel identity) => identity.Id;

        /// <summary>
        /// Name field resolver
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public string Name(AccountViewModel identity) => identity.Name;

        /// <summary>
        /// Username field resolver
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public string Username(AccountViewModel identity) => identity.Username;
    }
}