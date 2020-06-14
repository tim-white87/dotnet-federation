using Microsoft.AspNetCore.Identity;

namespace UserService.User
{
    /// <summary>
    /// User model
    /// </summary>
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}