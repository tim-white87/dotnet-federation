using System.Linq;
using Identity.Data.Config;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Data.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseIdentityServerConfigs(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
            IdentityServerConfig.SaveIdentityResources(context);
            IdentityServerConfig.SaveApis(context);
            IdentityServerConfig.SaveClients(context);
            return app;
        }


    }
}