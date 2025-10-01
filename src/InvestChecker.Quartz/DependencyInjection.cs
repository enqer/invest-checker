using InvestChecker.Quartz.Jobs.Syncs.ProcessingDataModelSync;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace InvestChecker.Quartz;

public static class DependencyInjection
{
    private const string CONFIG_QUARTZ_KEY = "Quartz";

    public static void AddQuartz(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddQuartz(x =>
        {
            x.RegisterJobTrigger<ProcessingDataModelSyncJob>(configuration, true);
        });
        services.AddQuartzHostedService(x => x.WaitForJobsToComplete = true);
    }

    private static void RegisterJobTrigger<T>(this IServiceCollectionQuartzConfigurator quartzConfigurator, IConfiguration configuration, bool startImmediately = false) where T : IJob
    {
        string jobName = typeof(T).Name;
        string key = $"{CONFIG_QUARTZ_KEY}:{jobName}";
        string cronSchedule = configuration[key] ?? throw new NullReferenceException($"Fill section {key}");
        if (string.IsNullOrEmpty(cronSchedule))
        {
            throw new Exception($"Not added Quartz cron schedule for: {jobName}");
        }
        var jobKey = new JobKey(jobName);
        quartzConfigurator.AddJob<T>(x =>
        {
            x.WithIdentity(jobKey);
        });
        if (startImmediately)
        {
            quartzConfigurator.AddTrigger(x =>
            {
                x.ForJob(jobKey).WithIdentity($"{jobName}-start-now-trigger").StartNow();
            });
        }
        quartzConfigurator.AddTrigger(x =>
        {
            x.ForJob(jobKey).WithIdentity($"{jobName}-trigger").WithCronSchedule(cronSchedule);
        });
    }
}
