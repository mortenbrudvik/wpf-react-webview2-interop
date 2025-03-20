using MediatR;
using WpfReactApp.UI.WebApi;

namespace WpfReactApp.UI.Users;

public class UserRemovedNotification(string userId) : INotification
{
    public string UserId { get; } = userId;
}

public class UserRemovedEventHandler(EventAggregator eventAggregator) : INotificationHandler<UserRemovedNotification>
{
    public Task Handle(UserRemovedNotification notification, CancellationToken cancellationToken)
    {
        eventAggregator.Publish("userService.userRemoved", notification.UserId);
        return Task.CompletedTask;
    }
}