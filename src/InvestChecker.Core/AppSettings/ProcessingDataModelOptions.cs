using InvestChecker.Core.SharedKernel;

namespace InvestChecker.Core.AppSettings;

public sealed class ProcessingDataModelOptions : IAppOptions
{
    public static string ConfigSectionPath => "ProcessingDataModel";

    public string Path { get; private init; } = string.Empty;
}
