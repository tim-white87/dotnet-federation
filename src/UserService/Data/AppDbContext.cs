using Microsoft.EntityFrameworkCore;
using UserService.User;

namespace user.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }
    }
}