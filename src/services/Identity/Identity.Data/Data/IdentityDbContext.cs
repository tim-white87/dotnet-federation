using Identity.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Identity.Data.Data
{
    public class IdentityDbContext : DbContext
    {
        public DbSet<AppUser> Users { get; set; }

        public IdentityDbContext(DbContextOptions options) : base(options) { }
    }
}