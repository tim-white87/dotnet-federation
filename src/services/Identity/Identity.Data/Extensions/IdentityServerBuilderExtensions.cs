using Identity.Data.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Data.Extensions
{
    public static class IdentityServerBuilderExtensions
    {
        public static IIdentityServerBuilder AddIdentityServerStores(this IIdentityServerBuilder identityServerBuilder, string connectionString = null)
        {
            connectionString = string.IsNullOrEmpty(connectionString) ?
                AppConfig.DbConnectionString : connectionString;
            identityServerBuilder.AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseNpgsql(connectionString,
                        sql => sql.MigrationsAssembly(AppConfig.MigrationsAssembly));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseNpgsql(connectionString,
                        sql => sql.MigrationsAssembly(AppConfig.MigrationsAssembly));
                    options.EnableTokenCleanup = true;
                });
            return identityServerBuilder;
        }
    }
}