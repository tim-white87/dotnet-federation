using Microsoft.EntityFrameworkCore;
using UserService.User;

namespace UserService.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }
    }
}