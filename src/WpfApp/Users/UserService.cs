namespace WpfApp.Users;

public class UserService
{
    public List<User> GetUsers() => new List<User>
    {
        new User { Id = "1", Name = "John" },
        new User { Id = "2", Name = "Jane" }
    };
}