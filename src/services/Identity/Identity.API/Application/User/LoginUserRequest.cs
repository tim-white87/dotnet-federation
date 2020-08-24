using Identity.Infrastructure.Models;
using MediatR;

namespace Identity.API.Application.User
{
    public class LoginUserRequest : IRequest<AppUser>
    {

    }
}