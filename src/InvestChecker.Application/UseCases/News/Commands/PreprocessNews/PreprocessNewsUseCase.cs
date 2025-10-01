using InvestChecker.Application.Common.Abstractions.Messaging;
using InvestChecker.Application.UseCases.News.Commands.PreprocessNews.Viewmodels;

namespace InvestChecker.Application.UseCases.News.Commands.PreprocessNews;

public sealed record NewsCommand(string Text) : ICommand<RateViewmodel>;

internal sealed class PreprocessNewsUseCase : ICommandHandler<NewsCommand, RateViewmodel>
{
    public async Task<RateViewmodel> Handle(NewsCommand request, CancellationToken cancellationToken)
    {
        return new RateViewmodel(3, 2);
    }
}
