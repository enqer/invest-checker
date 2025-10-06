using InvestChecker.Application.Common.Models;

namespace InvestChecker.Application.Common.Interfaces;

public interface IFileReader
{
    IAsyncEnumerable<PreprocessDataNews> GetPreprocessDataNews();
}
