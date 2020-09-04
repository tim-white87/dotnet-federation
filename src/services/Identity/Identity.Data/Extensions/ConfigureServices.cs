using Identity.Data.Data;
using Identity.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Data.Extensions
{
    public static class ConfigureServices
    {
        public static void AddApplicationDbContext(this IServiceCollection services, string connectionString = null)
        {
            connectionString = string.IsNullOrEmpty(connectionString) ?
                App.DbConnectionString : connectionString;
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));
        }
    }
}