using Microsoft.AspNetCore.Identity;

namespace Identity.Data.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
    }
}