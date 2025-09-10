using System.Net;

namespace InvestChecker.Core.Exceptions;

public class NotFoundException : HttpResponseException
{
    public NotFoundException(string userDescription, string? description = null) : base(HttpStatusCode.NotFound, userDescription, description)
    {
    }
}