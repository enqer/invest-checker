using System.Net;

namespace InvestChecker.Core.Exceptions;

public class BadRequestException : HttpResponseException
{
    public BadRequestException(string userDescription, string? description = null) : base(HttpStatusCode.BadRequest, userDescription, description)
    {
    }
}