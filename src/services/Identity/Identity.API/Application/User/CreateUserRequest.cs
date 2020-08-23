using Identity.API.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.API.Application.User
{
    public class CreateUserRequest : IRequest<bool>
    {
        public IdentityUser User { get; set; }
        public string Password { get; set; }
    }
}