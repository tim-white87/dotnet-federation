using System;
using System.Collections.Generic;
using GraphQL;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using GraphQL.Utilities.Federation;
using Identity.API.GraphQl.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.API.GraphQl
{
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
            services.AddSingleton<Query>();
            services.AddSingleton<IdentityType>();
            services.AddSingleton<AccountType>();

            services.AddSingleton<Mutation>();
            services.AddSingleton<IdentityOpsType>();
            services.AddSingleton<RegisterInputType>();
        }

        /// <summary>
        /// Builds the federated schema
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        private static ISchema BuildSchema(IServiceProvider serviceProvider)
        {
            return FederatedSchema.For(string.Join("", new List<string>{
                IdentitySchema.Definition
            }), _ =>
            {
                _.ServiceProvider = serviceProvider;

                _.Types.Include<Query>();
                _.Types.Include<IdentityType>();
                _.Types.Include<AccountType>();

                _.Types.Include<Mutation>();
                _.Types.Include<IdentityOpsType>();
                _.Types.Include<RegisterInputType>();
            });
        }
    }
}