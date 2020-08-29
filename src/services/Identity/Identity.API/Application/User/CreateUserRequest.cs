using Identity.API.GraphQl.Identity;
using MediatR;

namespace Identity.API.Application.User
{
    public class CreateUserRequest : IRequest<bool>
    {
        public readonly RegisterInputType Input;

        public CreateUserRequest(RegisterInputType input)
        {
            Input = input;
        }
    }
}