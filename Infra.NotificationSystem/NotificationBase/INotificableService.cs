using System.Collections.Generic;

namespace Infra.NotificationSystem.NotificationBase
{
    public interface INotificableService
    {
        void AddNotification(string message, string? property = null);
        IReadOnlyCollection<Notification> GetNotifications();
        bool HasNotifications();
    }
}
