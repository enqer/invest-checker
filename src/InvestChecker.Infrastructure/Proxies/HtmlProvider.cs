using HtmlAgilityPack;
using InvestChecker.Application.Common.Interfaces;
using InvestChecker.Core.AppSettings;
using InvestChecker.Domain.Providers.Models;
using InvestChecker.Infrastructure.Configurations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.ServiceModel.Syndication;

namespace InvestChecker.Infrastructure.Proxies;

internal class HtmlProvider : IHtmlProvider
{
    private readonly HttpClient httpClient;
    private readonly ILogger<BusinessNewsProxy> logger;

    public HtmlProvider(IHttpClientFactory httpClientFactory, IOptions<BusinessNewsOptions> options, ILogger<BusinessNewsProxy> logger)
    {
        httpClient = httpClientFactory.CreateClient(InternalHttpClientHandler.ClientName);
        httpClient.BaseAddress = new Uri(options.Value.Host);
        this.logger = logger;
    }
    public async Task<IEnumerable<NewsItem>> GetNews(SyndicationFeed feed, CancellationToken cancellationToken = default)
    {
        var news = new List<NewsItem>();
        foreach (var item in feed.Items)
        {
            var articleLink = item.Links.FirstOrDefault()?.Uri.ToString();
            var fullContent = "Brak pełnej treści";
            if (!string.IsNullOrEmpty(articleLink))
            {
                try
                {
                    var htmlResponse = await httpClient.GetAsync(articleLink, cancellationToken);
                    htmlResponse.EnsureSuccessStatusCode();
                    var htmlContent = await htmlResponse.Content.ReadAsStringAsync(cancellationToken);

                    var htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(htmlContent);

                    var articleNode = htmlDoc.DocumentNode.SelectSingleNode("//article[@id='article']");
                    if (articleNode != null)
                    {
                        fullContent = articleNode.InnerText.Trim();
                    }
                }
                catch (Exception ex)
                {
                    logger.LogWarning("Error occured on fetching content with message: {message}", ex.Message);
                }
            }

            news.Add(new NewsItem
            {
                Title = item.Title?.Text ?? string.Empty,
                Link = articleLink ?? string.Empty,
                PublishedDate = item.PublishDate.DateTime,
                Description = fullContent
            });

        }
        return news;
    }
}
