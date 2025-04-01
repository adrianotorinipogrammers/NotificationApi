using Infra.NotificationSystem.NotificationBase;
using Infra.NotificationSystem.ServiceBase;

namespace NotificationApi.UserServiceExemplo
{
    public interface IUserService: INotificableService
    {
        public void CreateUser(string username, string email);
    }
}
