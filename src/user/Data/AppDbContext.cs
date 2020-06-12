using Microsoft.EntityFrameworkCore;
using user.GraphQL;

namespace user.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }
    }
}