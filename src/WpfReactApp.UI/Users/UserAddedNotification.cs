using MediatR;
using WpfReactApp.UI.WebApi;

namespace WpfReactApp.UI.Users;

public class UserAddedNotification(User user) : INotification
{
    public User User { get; } = user;
}

public class UserAddedEventHandler(EventAggregator eventAggregator) : INotificationHandler<UserAddedNotification>
{
    public Task Handle(UserAddedNotification notification, CancellationToken cancellationToken)
    {
        eventAggregator.Publish("userService.userAdded", notification.User);
        return Task.CompletedTask;
    }
}