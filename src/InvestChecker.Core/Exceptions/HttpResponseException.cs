using System.Net;

namespace InvestChecker.Core.Exceptions;
public abstract class HttpResponseException : Exception
{
    public record ExceptionMessage(string Title, string Description);

    protected HttpResponseException(HttpStatusCode statusCode, string userDescription, string? description = null)
    {
        StatusCode = statusCode;
        Value = new ExceptionMessage(string.Empty, userDescription);
        InternalMessage = description;
    }

    public HttpStatusCode StatusCode { get; }
    public ExceptionMessage Value { get; }
    public string? InternalMessage { get; }
}