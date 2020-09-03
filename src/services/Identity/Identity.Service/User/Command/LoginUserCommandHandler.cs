using System.Threading;
using System.Threading.Tasks;
using Identity.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Service.User.Command
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, bool>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public LoginUserCommandHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<bool> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var signInManager = scopedServices.GetRequiredService<SignInManager<AppUser>>();
            var res = await signInManager.PasswordSignInAsync(command.User.Username, command.User.Password, true, false);
            return res.Succeeded;
        }
    }
}