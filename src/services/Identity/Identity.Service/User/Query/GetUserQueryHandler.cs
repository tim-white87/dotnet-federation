using System.Threading;
using System.Threading.Tasks;
using Identity.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Service.User.Query
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, AppUser>
    {
        private readonly UserManager<AppUser> _userManager;

        public GetUserQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<AppUser> Handle(GetUserQuery query, CancellationToken cancellationToken)
        {
            return await _userManager.GetUserAsync(new System.Security.Claims.ClaimsPrincipal());
        }
    }
}