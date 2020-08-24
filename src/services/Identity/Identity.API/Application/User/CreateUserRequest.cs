using Identity.Infrastructure.Models;
using MediatR;

namespace Identity.API.Application.User
{
    public class CreateUserRequest : IRequest<bool>
    {
        public AppUser User { get; set; }
        public string Password { get; set; }
    }
}