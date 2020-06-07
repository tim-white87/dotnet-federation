using System;
using System.Collections.Generic;
using GraphQL.Types;
using GraphQL.Utilities.Federation;
using Microsoft.Extensions.DependencyInjection;

namespace user.GraphQL
{
    /// <summary>
    /// GraphQL Schema
    /// </summary>
    public class Schema
    {
        private static IServiceProvider _service;

        /// <summary>
        /// Builds the federated schema
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public static ISchema BuildSchema(IServiceProvider serviceProvider)
        {
            _service = serviceProvider;

            return FederatedSchema.For(string.Join("", new List<string>{
                UserType.Schema
            }), _ =>
            {
                _.ServiceProvider = _service;
                _.Types.Include<UserType>();
            });
        }
    }
}