using Microsoft.EntityFrameworkCore;

namespace UserService.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserService.User.User> Users { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }
    }
}