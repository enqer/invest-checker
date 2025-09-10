using InvestChecker.Application.Common.Interfaces;
using InvestChecker.Infrastructure.Configurations;
using InvestChecker.Infrastructure.Proxies;
using Microsoft.Extensions.DependencyInjection;

namespace InvestChecker.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<InternalHttpClientHandler>();
        services.AddHttpClient(InternalHttpClientHandler.ClientName)
                .ConfigurePrimaryHttpMessageHandler<InternalHttpClientHandler>()
                .AddPolicyHandler(HttpClientPolicy.GetRetryPolicy());
        services.AddHttpContextAccessor();
        services.AddScoped<IBusinessNewsProvider, BusinessNewsProxy>();
        services.AddScoped<IHtmlProvider, HtmlProvider>();

        return services;
    }
}
