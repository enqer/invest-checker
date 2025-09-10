using InvestChecker.Application.Common.Interfaces;
using InvestChecker.Core.AppSettings;
using Microsoft.Extensions.Options;

namespace InvestChecker.Infrastructure.Proxies;

internal class BusinessNewsProxy(HttpClient httpClient, IOptions<BusinessNewsOptions> options) : IBusinessNewsProvider
{
    public async Task<object[]> GetLastestNews(CancellationToken cancellationToken)
    {
        var response = await httpClient.GetAsync(options.Value.Host, cancellationToken);
        return null;
    }
}
