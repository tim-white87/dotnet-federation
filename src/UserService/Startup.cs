using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using UserService.GraphQL;
using UserService.Data;

namespace UserService
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
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddSchema();
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
