using Identity.Service.User.Models;
using MediatR;

namespace Identity.Service.User.Command
{
    public class CreateUserCommand : IRequest<bool>
    {
        public readonly CreateUserModel User;

        public CreateUserCommand(CreateUserModel user)
        {
            User = user;
        }
    }
}