using Identity.Api.GraphQl.Identity;
using MediatR;

namespace Identity.Api.Application.User
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