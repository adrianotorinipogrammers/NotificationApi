namespace Infra.NotificationSystem.NotificationBase
{
    public class Notification
    {
        public string Message { get; }
        public string Property { get; }

        public Notification(string message, string property = null)
        {
            Message = message;
            Property = property;
        }
    }
}
