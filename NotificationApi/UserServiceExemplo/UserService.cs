using Infra.NotificationSystem.NotificationBase;
using Infra.NotificationSystem.ServiceBase;

namespace NotificationApi.UserServiceExemplo
{
    public class UserService : Notifiable, IUserService
    {
        public void CreateUser(string username, string email)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                AddNotification("O nome do usuário não pode estar vazio ou em branco", nameof(username));
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                AddNotification("O E-mail do usuário não pode estar vazio ou em branco", nameof(email));
            }

            if (HasNotifications())
            {
                return;
            }
        }

        public IReadOnlyCollection<Notification> GetNotifications()
        {
            return Notifications;
        }

        public  bool HasNotifications()
        {
            return Notifications.Any();
        }
    }
}
