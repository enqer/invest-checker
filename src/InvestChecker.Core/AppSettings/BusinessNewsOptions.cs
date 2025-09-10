using InvestChecker.Core.SharedKernel;

namespace InvestChecker.Core.AppSettings;

public sealed class BusinessNewsOptions : IAppOptions
{
    public static string ConfigSectionPath => "BusinessNews";

    public string Host { get; private init; } = string.Empty;
}
