using System.Threading;
using System.Threading.Tasks;
using Identity.Data.Models;
using MediatR;

namespace Identity.Service.User.Command
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AppUser>
    {
        public Task<AppUser> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}