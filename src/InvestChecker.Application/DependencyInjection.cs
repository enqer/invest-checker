using Microsoft.Extensions.DependencyInjection;

namespace InvestChecker.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}
