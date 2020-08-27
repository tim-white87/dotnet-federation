using Identity.API.GraphQl.Identity;
using MediatR;

namespace Identity.API.Application.User
{
    public class CreateUserRequest : IRequest<bool>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}