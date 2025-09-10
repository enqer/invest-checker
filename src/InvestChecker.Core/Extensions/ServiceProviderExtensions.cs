using InvestChecker.Core.SharedKernel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace InvestChecker.Core.Extensions;
public static class ServiceProviderExtensions
{
    public static TOptions GetOptions<TOptions>(this IServiceProvider serviceProvider)
        where TOptions : class, IAppOptions
    {
        return serviceProvider.GetRequiredService<IOptions<TOptions>>().Value;
    }
}
