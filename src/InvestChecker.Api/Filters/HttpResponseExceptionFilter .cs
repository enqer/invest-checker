using InvestChecker.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace InvestChecker.Api.Filters;

public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
{
    private readonly ILogger<HttpResponseExceptionFilter> logger;

    public HttpResponseExceptionFilter(ILogger<HttpResponseExceptionFilter> logger)
    {
        this.logger = logger;
    }

    public int Order => int.MaxValue - 10;

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is HttpResponseException httpResponseException)
        {
            context.Result = new ObjectResult(httpResponseException.Value)
            {
                StatusCode = (int)httpResponseException.StatusCode
            };
            StringBuilder sb = new StringBuilder();
            sb.Append("External message: {externalMessage}.");
            if (httpResponseException.InternalMessage != null)
            {
                sb.Append(" Internal message: {internalMessage}");
            }
            var message = sb.ToString();
            logger.LogWarning(context.Exception, message, httpResponseException.Value.Description, httpResponseException.InternalMessage);

            context.ExceptionHandled = true;
        }
    }
}