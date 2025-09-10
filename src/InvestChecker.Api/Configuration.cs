using InvestChecker.Application;
using InvestChecker.Core.AppSettings;
using InvestChecker.Core.SharedKernel;
using InvestChecker.Infrastructure;

namespace InvestChecker.Api;

public static class Configuration
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddApplication();

        builder.Services
               .AddOptionsWithValidation<BusinessNewsOptions>();

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
