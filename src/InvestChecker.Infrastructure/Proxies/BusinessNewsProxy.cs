using InvestChecker.Application.Common.Interfaces;
using InvestChecker.Core.AppSettings;
using InvestChecker.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using System.ServiceModel.Syndication;
using System.Xml;

namespace InvestChecker.Infrastructure.Proxies;

internal class BusinessNewsProxy : IBusinessNewsProvider
{
    private readonly HttpClient httpClient;

    public BusinessNewsProxy(IHttpClientFactory httpClientFactory, IOptions<BusinessNewsOptions> options)
    {
        httpClient = httpClientFactory.CreateClient(InternalHttpClientHandler.ClientName);
        httpClient.BaseAddress = new Uri(options.Value.Host);
    }

    public async Task<SyndicationFeed> GetLastestNews(CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetAsync("rss", cancellationToken);
        response.EnsureSuccessStatusCode();
        var stream = await response.Content.ReadAsStreamAsync(cancellationToken)
                ?? throw new NullReferenceException("Should return value");

        using var reader = XmlReader.Create(stream);
        return SyndicationFeed.Load(reader);
    }
}
