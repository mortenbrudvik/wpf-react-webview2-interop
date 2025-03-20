using MediatR;

namespace WpfReactApp.UI.Users;

public class GetUsersRequest : IRequest<List<User>> { }

public class GetUsersHandler(UserService userService) : IRequestHandler<GetUsersRequest, List<User>>
{
    public Task<List<User>> Handle(GetUsersRequest request, CancellationToken ct)
    {
        return Task.FromResult(userService.GetUsers());
    }
}