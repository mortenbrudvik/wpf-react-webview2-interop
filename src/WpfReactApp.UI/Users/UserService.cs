using MediatR;

namespace WpfReactApp.UI.Users;

public class UserService(IMediator mediator)
{
    private readonly List<User> _users = [];

    public List<User> GetUsers() => _users;

    public User? GetUser(string id) => _users.FirstOrDefault(u => u.Id == id);
    
    public async Task AddUser(User user)
    {
        _users.Add(user);
        await mediator.Publish(new UserAddedNotification(user));
    }

    public async Task RemoveUser(string userId)
    {
        var user = _users.FirstOrDefault(u => u.Id == userId);
        if (user != null)
        {
            _users.Remove(user);
            await mediator.Publish(new UserRemovedNotification(userId));
        }
    }
}