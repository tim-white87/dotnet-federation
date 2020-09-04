using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Identity.Api.GraphQl;
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
using AutoMapper;
using Identity.Service.User.Models;

namespace Identity.Api
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
            services.AddMediatR(typeof(Startup), typeof(CreateUserModel));
            services.AddAutoMapper(typeof(Startup));
            services.AddApplicationDbContext();
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddIdentityServer()
                .AddIdentityServerStores()
                // .AddDeveloperSigningCredential()
                // .AddInMemoryIdentityResources(Config.Ids)
                // .AddInMemoryApiResources(Config.Apis)
                // .AddInMemoryClients(Config.Clients)
                .AddAspNetIdentity<AppUser>()
                .AddJwtBearerClientAuthentication(); ;
            services.AddSchema();
            services.AddGraphQL(options =>
            {
                options.EnableMetrics = Environment.IsDevelopment();
                options.ExposeExceptions = Environment.IsDevelopment();
            })
                .AddSystemTextJson(
                    deserializerSettings => { },
                    serializerSettings => { });
            services.AddCors();
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
            app.UseAuthentication();
            app.UseAuthorization();
            // app.UseCors(builder => builder
            //     .WithOrigins(Configuration.GetSection("AllowedCorsOrigins").Get<string[]>())
            //     .AllowCredentials()
            //     .AllowAnyHeader()
            //     .AllowAnyMethod());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
