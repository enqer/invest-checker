using InvestChecker.Application.Common.Abstractions.Messaging;
using InvestChecker.Application.Common.Interfaces;

namespace InvestChecker.Application.UseCases.News.Commands.SyncNews;

internal sealed class SyncNewsHandler(IBusinessNewsProvider businessNewsProvider) : ICommandHandler<SyncNewsCommand>
{
    public async Task Handle(SyncNewsCommand request, CancellationToken cancellationToken)
    {
        var lastestNews = await businessNewsProvider.GetLastestNews(cancellationToken);
    }
}
