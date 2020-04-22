using System.Threading.Tasks;
using GraphQL;
using GraphQL.Http;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using GraphQL.Utilities.Federation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Messages
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // GraphQL types
            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            // Apollo Federation Types
            services.AddSingleton<AnyScalarGraphType>();
            services.AddSingleton<ServiceGraphType>();

            // Custom Types
            services.AddSingleton<UsersStore>();
            services.AddTransient<Query>();

            services.AddTransient<ISchema>(s =>
            {
                var store = s.GetRequiredService<UsersStore>();

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
                    _.ServiceProvider = s;
                    _.Types.Include<Query>();
                    _.Types.For("User").ResolveReferenceAsync(context =>
                    {
                        var id = (string)context.Arguments["id"];
                        return store.GetUserById(id);
                    });
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            // app.UseHttpsRedirection();
            app.UseRouting();
            // app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public class Query
    {
        private readonly UsersStore _store;

        public Query(UsersStore store)
        {
            _store = store;
        }

        public Task<User> Me()
        {
            return _store.Me();
        }
    }

}
