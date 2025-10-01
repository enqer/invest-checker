
using InvestChecker.Application.Common.Abstractions.Messaging;

namespace InvestChecker.Application.UseCases.News.Commands.ProcessingDataModelSync;

public sealed record ProcessingModelDataSyncCommand : ICommand;

internal sealed class ProcessingDataModelSyncUseCase : ICommandHandler<ProcessingModelDataSyncCommand>
{
    public async Task Handle(ProcessingModelDataSyncCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine("Test");
        await Task.CompletedTask;
    }
}
