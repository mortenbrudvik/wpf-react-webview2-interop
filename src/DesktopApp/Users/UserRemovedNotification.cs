using MediatR;
using WebView.Interop;

namespace DesktopApp.Users;

public class UserRemovedNotification(string userId) : INotification
{
    public string UserId { get; } = userId;
}

public class UserRemovedEventHandler(ApiEventAggregator eventAggregator) : INotificationHandler<UserRemovedNotification>
{
    public Task Handle(UserRemovedNotification notification, CancellationToken cancellationToken)
    {
        eventAggregator.Publish("userService.userRemoved", notification.UserId);
        return Task.CompletedTask;
    }
}