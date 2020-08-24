using Identity.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Data
{
    public class IdentityDbContext : DbContext
    {
        public DbSet<AppUser> Users { get; set; }

        public IdentityDbContext(DbContextOptions options) : base(options) { }
    }
}