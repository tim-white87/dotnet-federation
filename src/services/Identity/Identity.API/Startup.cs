using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Identity.API.GraphQl;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Identity.Data.Extensions;
using Identity.Data.Models;
using Microsoft.AspNetCore.Identity;
using Identity.Data.Data;

namespace Identity.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));
            services.AddIdentityDbContext();
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();
            services.AddIdentityServer()
                .AddIdentityServerDbContex()
                .AddAspNetIdentity<AppUser>();
            services.AddSchema();
            services.AddGraphQL(options =>
            {
                options.EnableMetrics = Environment.IsDevelopment();
                options.ExposeExceptions = Environment.IsDevelopment();
            })
                .AddSystemTextJson(deserializerSettings => { }, serializerSettings => { });
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            app.UseGraphQL<ISchema>();
            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
