using MediatR;

namespace AppUI.Users;

// Request
public class GetUsersRequest : IRequest<List<User>> { }

// Handler
public class GetUsersHandler : IRequestHandler<GetUsersRequest, List<User>>
{
    private readonly UserService _userService;
    public GetUsersHandler(UserService userService) => _userService = userService;

    public Task<List<User>> Handle(GetUsersRequest request, CancellationToken ct)
    {
        return Task.FromResult(_userService.GetUsers());
    }
}