using Microsoft.AspNetCore.Identity;

namespace Identity.Infrastructure.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
    }
}