
using InvestChecker.Application.Common.Abstractions.Messaging;
using InvestChecker.Application.Common.Interfaces;

namespace InvestChecker.Application.UseCases.News.Commands.ProcessingDataModelSync;

public sealed record ProcessingModelDataSyncCommand : ICommand;

internal sealed class ProcessingDataModelSyncUseCase(IFileReader fileReader) : ICommandHandler<ProcessingModelDataSyncCommand>
{
    public async Task Handle(ProcessingModelDataSyncCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine("Test");
        var newsStream = fileReader.GetPreprocessDataNews();
        await foreach (var newsItem in newsStream.WithCancellation(cancellationToken))
        {
            Console.WriteLine(newsItem.Id);
        }
        await Task.CompletedTask;
    }
}
