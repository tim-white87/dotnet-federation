using System;
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

            return FederatedSchema.For(@"
                extend type Query {
                    me: User
                    messages: [Message]
                }

                type User @key(fields: ""id"") {
                    id: ID!
                    name: String
                    username: String
                    derp: String
                }

                type Message @key(fields: ""id"") {
                    id: ID!
                    title: String
                    content: String
                }
            ", _ =>
            {
                _.ServiceProvider = _service;
                _.Types.Include<MessageType>();
                _.Types.Include<Query>();
                _.Types.For("User").ResolveReferenceAsync(context =>
                {
                    var id = (string)context.Arguments["id"];
                    return _store.GetUserById(id);
                });
            });
        }
    }
}