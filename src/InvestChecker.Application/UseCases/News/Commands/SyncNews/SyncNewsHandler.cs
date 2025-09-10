using InvestChecker.Application.Common.Abstractions.Messaging;
using InvestChecker.Application.Common.Interfaces;
using InvestChecker.Domain.Providers.Models;

namespace InvestChecker.Application.UseCases.News.Commands.SyncNews;

internal sealed class SyncNewsHandler(IBusinessNewsProvider businessNewsProvider, IHtmlProvider htmlProvider) : IQueryHandler<SyncNewsCommand, IEnumerable<NewsItem>>
{
    public async Task<IEnumerable<NewsItem>> Handle(SyncNewsCommand request, CancellationToken cancellationToken)
    {
        var lastestNews = await businessNewsProvider.GetLastestNews(cancellationToken);
        var news = await htmlProvider.GetNews(lastestNews, cancellationToken);

        return news;
    }
}
