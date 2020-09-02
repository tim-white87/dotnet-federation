using Identity.API.GraphQl.Identity;
using Identity.Data.Models;
using MediatR;

namespace Identity.API.Application.User
{
    public class LoginUserRequest : IRequest<AppUser>
    {
        public readonly LoginInputType Input;

        public LoginUserRequest(LoginInputType input)
        {
            Input = input;
        }
    }
}