using Identity.Infrastructure.Constants;
using Identity.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Identity.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IdentityDbContext>
    {
        public IdentityDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentityDbContext>();
            var connectionString = App.Configuration.GetConnectionString(Database.ConnectionStringKey);
            optionsBuilder.UseNpgsql(connectionString);
            return new IdentityDbContext(optionsBuilder.Options);
        }
    }
}