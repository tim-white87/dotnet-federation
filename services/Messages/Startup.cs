using GraphQL;
using GraphQL.Server.Ui.Playground;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using GraphQL.Server;
using GraphQL.Utilities.Federation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Messages.Data;
using Messages.GraphQL;

namespace Messages
{
    /// <summary>
    /// Startup: Called on app start
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public static IConfiguration Configuration { get; private set; }
        public IWebHostEnvironment Environment { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // GraphQL types
            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            // Apollo Federation Types
            services.AddSingleton<AnyScalarGraphType>();
            services.AddSingleton<ServiceGraphType>();

            // Custom Types
            services.AddSingleton<DataStore>();
            services.AddSingleton<Query>();
            services.AddSingleton<MessageType>();
            services.AddSingleton<ISchema>(c => GraphQL.Schema.BuildSchema(c));

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = Environment.IsDevelopment();
                options.ExposeExceptions = Environment.IsDevelopment();
            })
                .AddSystemTextJson(deserializerSettings => { }, serializerSettings => { });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        /// </summary>
        /// <param name="app">app instance</param>
        /// <param name="env">env instance</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();
            }
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            app.UseGraphQL<ISchema>();
            app.UseRouting();
            // app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
