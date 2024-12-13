using CSVDataIntegrationApp.Core.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;

namespace CSVDataIntegrationApp.Server.ActionHelpers;

public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext actionExecutedContext)
    {
        var code = 500;
        if (actionExecutedContext.Exception is InvalidOperationException)
        {
            code = 409;
        }

        if (actionExecutedContext.Exception is FormatException)
        {
            code = 400;
        }

        if (actionExecutedContext.Exception is ArgumentNullException)
        {
            code = 400;
        }

        if (actionExecutedContext.Exception is NotFoundException)
        {
            code = 404;
        }

        if (actionExecutedContext.Exception is ValidationException)
        {
            code = 422;
        }

        if (actionExecutedContext.Exception is InvalidInputException)
        {
            code = 422;
        }




        actionExecutedContext.HttpContext.Response.StatusCode = code;
        actionExecutedContext.Result = new JsonResult(new
        {
            error = actionExecutedContext.Exception.Message
        });
    }
}
