using WpfReactApp.UI.WebApi;

namespace WpfReactApp.UI.Users;

public class UserService(EventAggregator eventAggregator)
{
    private readonly List<User> _users = [];
    public List<User> GetUsers() => _users;

    public void AddUser(User user)
    {
        _users.Add(user);
        eventAggregator.Publish("userService.userAdded", user);
    }

    public void RemoveUser(string userId)
    {
        var user = _users.FirstOrDefault(u => u.Id == userId);
        if (user != null)
        {
            _users.Remove(user);
            eventAggregator.Publish("userService.userRemoved", userId);
        }
    }
}