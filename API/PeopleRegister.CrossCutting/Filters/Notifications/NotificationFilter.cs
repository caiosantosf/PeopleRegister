using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;

namespace PeopleRegister.CrossCutting.Filters;

public class NotificationFilter : IAsyncResultFilter
{
    private readonly Notifiable<Notification> notificationContext;

    public NotificationFilter()
    {
        notificationContext = new NotificationContext();
    }

    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (!notificationContext.IsValid)
        {
            var error = new { Messages = notificationContext.Notifications.Select(s => s.Message) };

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var notifications = JsonConvert.SerializeObject(error);
            await context.HttpContext.Response.WriteAsync(notifications);

            return;
        }

        await next();
    }

    public class NotificationMessage
    {
        public NotificationMessage(string message, string detail)
        {
            Message = message;
            Detail = detail;
        }

        public string Message { get; }
        public string Detail { get; }
    }

    public class NotificationContext : Notifiable<Notification>
    {
        public new void AddNotification(string message, string detail = "") => base.AddNotification(message, detail);

        public new IEnumerable<NotificationMessage> Notifications => base.Notifications.Select(notification => new NotificationMessage(notification.Key, notification.Message));
    }
}
