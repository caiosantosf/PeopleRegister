using Flunt.Notifications;
using System.Collections.Generic;

namespace PeopleRegister.Domain.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {
    }

    public BadRequestException(IReadOnlyCollection<Notification> notifications)
    {
        foreach (var notification in notifications)
        {
            base.Data.Add(notification.Key, notification.Message);
        }
    }
}