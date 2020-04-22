using System;
using GraphQL.Types;
using GraphQL.Utilities.Federation;
using Microsoft.Extensions.DependencyInjection;

namespace Messages.GraphQL
{
    /// <summary>
    /// GraphQL Schema
    /// </summary>
    public class MessagesGraphQL
    {
        private static IServiceProvider _service;
        private static UsersStore _store;

        public static ISchema BuildSchema(IServiceProvider s)
        {
            _service = s;
            _store = s.GetRequiredService<UsersStore>();

            return FederatedSchema.For(@"
                extend type Query {
                    me: User
                }

                type User @key(fields: ""id"") {
                    id: ID!
                    name: String
                    username: String
                    derp: String
                }
            ", _ =>
            {
                _.ServiceProvider = _service;
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