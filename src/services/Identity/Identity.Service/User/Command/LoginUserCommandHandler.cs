using System;
using System.Threading;
using System.Threading.Tasks;
using Identity.Data.Models;
using IdentityServer4;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Service.User.Command
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, bool>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginUserCommandHandler(
            IServiceScopeFactory serviceScopeFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var signInManager = scopedServices.GetRequiredService<SignInManager<AppUser>>();
            var user = await signInManager.UserManager.FindByNameAsync(command.LoginUserModel.Username);
            var isValidSignIn = await signInManager.UserManager.CheckPasswordAsync(user, command.LoginUserModel.Password);
            if (isValidSignIn)
            {
                return await SignInUser(user, command.LoginUserModel.RememberLogin);
            }
            return false;
        }

        private async Task<bool> SignInUser(AppUser user, bool rememberLogin = false)
        {
            AuthenticationProperties props = null;
            if (rememberLogin)
            {
                props = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.Add(TimeSpan.FromDays(30))
                };
            }
            var isuser = new IdentityServerUser(user.SubjectId)
            {
                DisplayName = user.UserName
            };
            try
            {
                await _httpContextAccessor.HttpContext.SignInAsync(isuser, props);
                var token = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
                Console.WriteLine($"token: {token}");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}