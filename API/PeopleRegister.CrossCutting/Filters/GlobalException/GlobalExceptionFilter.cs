using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PeopleRegister.Domain.Exceptions;
using System.Net;

namespace PeopleRegister.CrossCutting.Filters;

public class GlobalExceptionFilter : IExceptionFilter
{
    public async void OnException(ExceptionContext context)
    {
        var result = new ObjectResult(new
        {
            context.Exception.Message,
            context.Exception.Source,
            ExceptionType = context.Exception.GetType().FullName,
        })
        {
            StatusCode = context.Exception is NotFoundException ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.InternalServerError
        };

        context.Result = result;
    }
}
