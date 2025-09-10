using InvestChecker.Application.Commons.Interfaces;
using InvestChecker.Infrastructure.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvestChecker.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IRSSProvider, RSSProvider>();
        return services;
    }

}
