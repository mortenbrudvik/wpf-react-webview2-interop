using MediatR;
using WebView.Interop;

namespace DesktopApp.Users;

public class UserAddedNotification(User user) : INotification
{
    public User User { get; } = user;
}

public class UserAddedEventHandler(ApiEventAggregator eventAggregator) : INotificationHandler<UserAddedNotification>
{
    public Task Handle(UserAddedNotification notification, CancellationToken cancellationToken)
    {
        eventAggregator.Publish("userService.userAdded", notification.User);
        return Task.CompletedTask;
    }
}