using System.Threading;
using System.Threading.Tasks;
using Identity.API.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.API.Application.User
{
    public class GetUserRequestHandler : IRequestHandler<GetUserRequest, UserModel>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public GetUserRequestHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<UserModel> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var res = await _userManager.GetUserAsync(new System.Security.Claims.ClaimsPrincipal());
            return new UserModel
            {
                Id = res.Id,
                Username = res.UserName
            };
        }
    }
}