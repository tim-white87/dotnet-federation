using System;
using GraphQL;

namespace Identity.API.Identity
{
    [GraphQLMetadata("Identity", IsTypeOf = typeof(IdentityViewModel))]
    public class IdentityType
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// IdentityType constructor
        /// </summary>
        /// <param name="sp">Service Provider</param>
        public IdentityType(IServiceProvider sp)
        {
            _serviceProvider = sp;
        }

        /// <summary>
        /// Id field resolver
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public string Id(IdentityViewModel identity) => identity.Id;

        /// <summary>
        /// Name field resolver
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public string Name(IdentityViewModel identity) => identity.Name;

        /// <summary>
        /// Username field resolver
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public string Username(IdentityViewModel identity) => identity.Username;
    }
}