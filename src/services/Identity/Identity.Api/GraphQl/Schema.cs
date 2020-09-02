using System;
using System.Collections.Generic;
using GraphQL;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using GraphQL.Utilities.Federation;
using Identity.Api.GraphQl.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Api.GraphQl
{
    public static class Schema
    {
        /// <summary>
        /// Extension of configuration that adds the types
        /// and adds the built schema
        /// </summary>
        /// <param name="services"></param>
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
            services.AddSingleton<UserType>();

            services.AddSingleton<Mutation>();
            services.AddSingleton<IdentityOpsType>();
            services.AddSingleton<RegisterInputType>();
            services.AddSingleton<LoginInputType>();
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
                _.Types.Include<UserType>();

                _.Types.Include<Mutation>();
                _.Types.Include<IdentityOpsType>();
                _.Types.Include<RegisterInputType>();
                _.Types.Include<LoginInputType>();
            });
        }
    }
}