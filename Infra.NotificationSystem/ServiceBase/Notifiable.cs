using Infra.NotificationSystem.NotificationBase;
using System.Collections.Generic;
using System.Linq;

namespace Infra.NotificationSystem.ServiceBase
{
    public abstract class Notifiable
    {
        private readonly List<Notification> _notifications;

        public IReadOnlyCollection<Notification> Notifications => _notifications.AsReadOnly();

        public Notifiable()
        {
            _notifications = new List<Notification>();
        }

        public void AddNotification(string message, string property = null)
        {
            _notifications.Add(new Notification(message, property));
        }

        public void AddNotifications(IEnumerable<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }
    }
}
