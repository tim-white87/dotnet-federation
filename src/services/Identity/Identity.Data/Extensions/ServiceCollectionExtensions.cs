using Identity.Data.Data;
using Identity.Data.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationDbContext(this IServiceCollection services, string connectionString = null)
        {
            connectionString = string.IsNullOrEmpty(connectionString) ?
                AppConfig.DbConnectionString : connectionString;
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));
        }
    }
}