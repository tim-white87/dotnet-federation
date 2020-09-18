namespace Identity.Service.User.Models
{
    public class LoginUserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
    }
}