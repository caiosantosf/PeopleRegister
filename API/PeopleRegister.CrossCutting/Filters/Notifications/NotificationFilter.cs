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
            var error = new Error(NotificationContext.Notifications.Select(s => s.Message), HttpStatusCode.BadRequest);

            context.HttpContext.Response.StatusCode = error.Status;
            context.HttpContext.Response.ContentType = "application/json";

            var notifications = JsonConvert.SerializeObject(error);
            await context.HttpContext.Response.WriteAsync(notifications);

            return;
        }

        await next();
    }
}
