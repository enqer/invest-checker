using InvestChecker.Api.Filters;
using InvestChecker.Application;
using InvestChecker.Core.AppSettings;
using InvestChecker.Core.SharedKernel;
using InvestChecker.Infrastructure;
using InvestChecker.Quartz;

namespace InvestChecker.Api;

public static class Configuration
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddInfrastructure();
        builder.Services.AddApplication();
        builder.Services.AddQuartz(builder.Configuration);

        builder.Services
               .AddOptionsWithValidation<BusinessNewsOptions>();

        builder.Services.AddControllers(options =>
        {
            options.Filters.Add<HttpResponseExceptionFilter>();
        });

        builder.ConfigureEnvironmentVariables();
    }

    private static void ConfigureEnvironmentVariables(this WebApplicationBuilder builder)
    {
        builder.Configuration
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
            .AddEnvironmentVariables();
    }

    private static IServiceCollection AddOptionsWithValidation<TOptions>(this IServiceCollection services) where TOptions : class, IAppOptions
    {
        return services
            .AddOptions<TOptions>()
            .BindConfiguration(TOptions.ConfigSectionPath, binderOptions => binderOptions.BindNonPublicProperties = true)
            .ValidateDataAnnotations()
            .ValidateOnStart()
            .Services;
    }
}
