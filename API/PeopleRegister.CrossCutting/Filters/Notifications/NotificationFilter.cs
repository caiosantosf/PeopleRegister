using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;

namespace PeopleRegister.CrossCutting.Filters;

public class NotificationFilter : IAsyncResultFilter
{
    private readonly Notifiable<Notification> NotificationContext;

    public NotificationFilter(Notifiable<Notification> notificationContext)
    {
        NotificationContext = notificationContext;
    }

    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (!NotificationContext.IsValid)
        {
            var error = new { Messages = NotificationContext.Notifications.Select(s => s.Message) };

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var notifications = JsonConvert.SerializeObject(error);
            await context.HttpContext.Response.WriteAsync(notifications);

            return;
        }

        await next();
    }
}
