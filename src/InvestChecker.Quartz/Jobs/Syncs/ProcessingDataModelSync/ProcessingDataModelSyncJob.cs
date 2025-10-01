using InvestChecker.Application.UseCases.News.Commands.ProcessingDataModelSync;
using MediatR;
using Microsoft.Extensions.Logging;
using Quartz;

namespace InvestChecker.Quartz.Jobs.Syncs.ProcessingDataModelSync;

[DisallowConcurrentExecution]
internal class ProcessingDataModelSyncJob(ILogger<ProcessingDataModelSyncJob> logger, IMediator mediator) : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        logger.LogInformation($"Start job {nameof(ProcessingDataModelSyncJob)}");
        var command = new ProcessingModelDataSyncCommand();
        await mediator.Send(command);
        logger.LogInformation($"Complete job {nameof(ProcessingDataModelSyncJob)}");
    }
}
