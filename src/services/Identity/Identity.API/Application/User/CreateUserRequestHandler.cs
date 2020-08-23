using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.API.Application.User
{
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, bool>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public CreateUserRequestHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var res = await _userManager.CreateAsync(request.User, request.Password);
            return res.Succeeded;
        }
    }
}