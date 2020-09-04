using Identity.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Data.Extensions
{
    public static class IdentityServerBuilderExtensions
    {
        public static IIdentityServerBuilder AddIdentityServerStores(this IIdentityServerBuilder identityServerBuilder, string connectionString = null)
        {
            connectionString = string.IsNullOrEmpty(connectionString) ?
                App.DbConnectionString : connectionString;
            identityServerBuilder.AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseNpgsql(connectionString,
                        sql => sql.MigrationsAssembly(App.MigrationsAssembly));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseNpgsql(connectionString,
                        sql => sql.MigrationsAssembly(App.MigrationsAssembly));
                    options.EnableTokenCleanup = true;
                });
            return identityServerBuilder;
        }
    }
}