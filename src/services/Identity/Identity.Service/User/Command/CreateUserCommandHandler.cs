using System.Threading;
using System.Threading.Tasks;
using Identity.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Service.User.Command
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public CreateUserCommandHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<bool> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var userManager = scopedServices.GetRequiredService<UserManager<AppUser>>();
            // TODO: automap
            var user = new AppUser
            {
                UserName = command.User.Username
            };
            var res = await userManager.CreateAsync(user, command.User.Password);
            if (res.Succeeded)
            {
                // if (await _roleManager.FindByNameAsync(role) == null)
                // {
                //     await _roleManager.CreateAsync(new IdentityRole(role));
                // }
                // await userManager.AddToRoleAsync(user, role);
                await userManager.AddClaimAsync(user, new System.Security.Claims.Claim("sub", user.SubjectId));
                await userManager.AddClaimAsync(user, new System.Security.Claims.Claim("name", user.UserName));
                // await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("role", role));
            }
            return res.Succeeded;
        }
    }
}