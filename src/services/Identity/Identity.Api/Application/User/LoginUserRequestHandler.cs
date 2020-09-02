using System.Threading;
using Identity.Data.Models;
using MediatR;

namespace Identity.Api.Application.User
{
    public class LoginUserRequestHandler : IRequestHandler<LoginUserRequest, AppUser>
    {
        public System.Threading.Tasks.Task<AppUser> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}