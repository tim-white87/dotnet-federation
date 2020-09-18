using Identity.Service.User.Models;
using MediatR;

namespace Identity.Service.User.Command
{
    public class LoginUserCommand : IRequest<bool>
    {
        public readonly LoginUserModel LoginUserModel;

        public LoginUserCommand(LoginUserModel user)
        {
            LoginUserModel = user;
        }
    }
}