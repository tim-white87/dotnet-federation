using System;
using System.Collections.Generic;
using GraphQL;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using GraphQL.Utilities.Federation;
using Microsoft.Extensions.DependencyInjection;
using UserService.User;
using UserService.User.UserService.User;

namespace UserService.GraphQl
{
    /// <summary>
    /// GraphQL Schema
    /// </summary>
    public static class Schema
    {
        public static void AddSchema(this IServiceCollection services)
        {
            services.AddSchemaTypes();
            services.AddSingleton(c => BuildSchema(c));
        }

        /// <summary>
        /// Adds the schema type singletons
        /// </summary>
        /// <param name="services"></param>
        private static void AddSchemaTypes(this IServiceCollection services)
        {
            // GraphQL types
            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            // Apollo Federation Types
            services.AddSingleton<AnyScalarGraphType>();
            services.AddSingleton<ServiceGraphType>();

            // Custom Types
            services.AddSingleton<UserQuery>();
            services.AddSingleton<UserType>();
        }

        /// <summary>
        /// Builds the federated schema
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        private static ISchema BuildSchema(IServiceProvider serviceProvider)
        {
            return FederatedSchema.For(string.Join("", new List<string>{
                UserSchema.Schema
            }), _ =>
            {
                _.ServiceProvider = serviceProvider;
                _.Types.Include<UserQuery>();
                _.Types.Include<UserType>();
            });
        }
    }
}