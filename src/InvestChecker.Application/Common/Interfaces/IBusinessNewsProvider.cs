using System.ServiceModel.Syndication;

namespace InvestChecker.Application.Common.Interfaces;

public interface IBusinessNewsProvider
{
    Task<SyndicationFeed> GetLastestNews(CancellationToken cancellationToken = default);
}
