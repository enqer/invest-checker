using Microsoft.AspNetCore.Http;

namespace InvestChecker.Infrastructure.Configurations;

internal class InternalHttpClientHandler : HttpClientHandler
{
    public const string ClientName = "InternalClient";

    private readonly IHttpContextAccessor _httpContextAccessor;

    public InternalHttpClientHandler(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var context = _httpContextAccessor.HttpContext;

        return await base.SendAsync(request, cancellationToken);
    }
}