using Identity.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Data.Extensions
{
    public static class IdentityServerBuilder
    {
        public static IIdentityServerBuilder AddIdentityServerDbContex(this IIdentityServerBuilder identityServerBuilder, string connectionString = null)
        {
            connectionString = string.IsNullOrEmpty(connectionString) ?
                App.DbConnectionString : connectionString;
            identityServerBuilder.AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseNpgsql(connectionString);
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseNpgsql(connectionString);
                    options.EnableTokenCleanup = true;
                });
            return identityServerBuilder;
        }
    }
}