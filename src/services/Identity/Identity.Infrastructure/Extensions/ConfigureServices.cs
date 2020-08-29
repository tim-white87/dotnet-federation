using Identity.Infrastructure.Data;
using Identity.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Infrastructure.Extensions
{
    public static class ConfigureServices
    {
        public static void AddIdentityDbContext(this IServiceCollection services, string connectionString = null)
        {
            connectionString = string.IsNullOrEmpty(connectionString) ?
                App.DbConnectionString : connectionString;
            services.AddDbContext<IdentityDbContext>(options =>
                options.UseNpgsql(connectionString));
        }
    }
}