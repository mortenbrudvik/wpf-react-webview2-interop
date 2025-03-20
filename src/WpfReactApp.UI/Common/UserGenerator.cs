using Bogus;
using WpfReactApp.UI.Users;

namespace WpfReactApp.UI.Common;

public static class UserGenerator
{
    public static User Create()
    {
        var userFaker = new Faker<User>()
            .RuleFor(x => x.Id, f => Guid.NewGuid().ToString())
            .RuleFor(x => x.Name, f => f.Name.FullName());
        
        return userFaker.Generate();
    }
}