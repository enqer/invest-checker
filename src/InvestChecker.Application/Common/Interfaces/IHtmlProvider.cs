using InvestChecker.Domain.Providers.Models;
using System.ServiceModel.Syndication;

namespace InvestChecker.Application.Common.Interfaces;

public interface IHtmlProvider
{
    Task<IEnumerable<NewsItem>> GetNews(SyndicationFeed feed, CancellationToken cancellationToken = default);
}
