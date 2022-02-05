using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;
using System.Web.Http.Filters;

namespace PeopleRegister.CrossCutting.Filters;

public class GlobalExceptionFilter : ExceptionFilterAttribute
{
    public override void OnException(HttpActionExecutedContext context)
    {
        context.Response.Content = new StringContent(string.Format(JsonConvert.SerializeObject(
            new { Error = $"Um erro inesperado aconteceu no servidor - {context.Exception.Message}" })));

        context.Response.StatusCode = HttpStatusCode.InternalServerError;

        base.OnException(context);
    }
}
