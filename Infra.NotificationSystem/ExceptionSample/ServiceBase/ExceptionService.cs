using Infra.NotificationSystem.NotificationBase;
using System.Collections.Generic;
using System.Linq;

namespace Infra.NotificationSystem.ExceptionSample.ExceptionServiceBase
{
    public class ExceptionNotificationService : ServiceBase.Notifiable, INotificableService
    {
        public IReadOnlyCollection<Notification> GetNotifications()
        {
            return Notifications;
        }

        bool INotificableService.HasNotifications()
        {
            return Notifications.Any();
        }
    }
}

