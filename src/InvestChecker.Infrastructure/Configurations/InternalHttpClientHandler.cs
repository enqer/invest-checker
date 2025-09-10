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
        request.Headers.Add("User-Agent", "Mozilla/5.0");
        request.Headers.Add("Accept", "*/*");
        return await base.SendAsync(request, cancellationToken);
    }
}