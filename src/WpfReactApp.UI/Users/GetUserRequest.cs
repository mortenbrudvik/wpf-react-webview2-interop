using MediatR;

namespace WpfReactApp.UI.Users;

public class GetUserRequest(string id) : IRequest<User?>
{
    public string Id { get; set; } = id; // Add setter
}

public class GetUserHandler(UserService userService) : IRequestHandler<GetUserRequest, User?>
{
    public Task<User?> Handle(GetUserRequest request, CancellationToken ct)
    {
        return Task.FromResult(userService.GetUser(request.Id));
    }
}