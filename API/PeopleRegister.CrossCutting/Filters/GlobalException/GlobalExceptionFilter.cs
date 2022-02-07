using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PeopleRegister.Domain.Exceptions;
using System.Collections;
using System.Net;

namespace PeopleRegister.CrossCutting.Filters;

public class GlobalExceptionFilter : IExceptionFilter
{
    public async void OnException(ExceptionContext context)
    {
        int statusCode;

        if (context.Exception is NotFoundException)
            statusCode = (int)HttpStatusCode.NotFound;
        else if (context.Exception is BadRequestException)
            statusCode = (int)HttpStatusCode.BadRequest;
        else
            statusCode = (int)HttpStatusCode.InternalServerError;

        ObjectResult result;
        IDictionary messages;

        if (context.Exception.Data.Count > 0)
            messages = context.Exception.Data;
        else
        {
            messages = new Dictionary<string, string>
            {
                { "error", context.Exception.Message }
            };
        }
            
        result = new ObjectResult(new
        {
            Messages = messages,
            context.Exception.Source,
            ExceptionType = context.Exception.GetType().FullName,
        })
        {
            StatusCode = statusCode
        };
       

        context.Result = result;
    }

    public class Messages
    {

    }
}
