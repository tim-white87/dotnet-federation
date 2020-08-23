using System.Threading;
using System.Threading.Tasks;
using Identity.API.User;
using MediatR;

namespace Identity.API.Application.User
{
    public class GetUserRequestHandler : IRequestHandler<GetUserRequest, UserModel>
    {
        public Task<UserModel> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}