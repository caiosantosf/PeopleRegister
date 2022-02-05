using Flunt.Notifications;

namespace PeopleRegister.CrossCutting.Filters;

public class NotificationContext
{
    public IReadOnlyCollection<Notification> Notifications;

    public void SetNotification(IReadOnlyCollection<Notification> notifications)
    {
        Notifications = notifications.ToList();
    }
}

