using Identity.Data.Models;
using Identity.Service.User.Models;
using MediatR;

namespace Identity.Service.User.Command
{
    public class LoginUserCommand : IRequest<AppUser>
    {
        public readonly LoginUserModel User;

        public LoginUserCommand(LoginUserModel user)
        {
            User = user;
        }
    }
}