using System;
using System.Collections.Generic;
using GraphQL.Types;
using GraphQL.Utilities.Federation;
using Messages.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Messages.GraphQL
{
    /// <summary>
    /// GraphQL Schema
    /// </summary>
    public class Schema
    {
        private static IServiceProvider _service;
        private static DataStore _store;

        /// <summary>
        /// Builds the federated schema
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public static ISchema BuildSchema(IServiceProvider serviceProvider)
        {
            _service = serviceProvider;
            _store = serviceProvider.GetRequiredService<DataStore>();

            return FederatedSchema.For(String.Join("", new List<string>{
                UserType.Schema,
                MessageType.Schema
            }), _ =>
            {
                _.ServiceProvider = _service;
                _.Types.Include<Query>();
                _.Types.Include<MessageType>();
                _.Types.Include<UserType>();
            });
        }
    }
}