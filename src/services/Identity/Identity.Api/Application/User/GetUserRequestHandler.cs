using System.Threading;
using System.Threading.Tasks;
using Identity.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.API.Application.User
{
    public class GetUserRequestHandler : IRequestHandler<GetUserRequest, AppUser>
    {
        private readonly UserManager<AppUser> _userManager;

        public GetUserRequestHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<AppUser> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            return await _userManager.GetUserAsync(new System.Security.Claims.ClaimsPrincipal());
        }
    }
}