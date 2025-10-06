using CsvHelper;
using CsvHelper.Configuration;
using InvestChecker.Application.Common.Interfaces;
using InvestChecker.Application.Common.Models;
using InvestChecker.Core.AppSettings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace InvestChecker.Infrastructure.Services;

internal class FileService(ILogger<FileService> logger, IOptions<ProcessingDataModelOptions> options) : IFileReader
{
    public async IAsyncEnumerable<PreprocessDataNews> GetPreprocessDataNews()
    {
        using var reader = new StreamReader(options.Value.Path);
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            Delimiter = ",",
            Quote = '"',
        };

        using var csv = new CsvReader(reader, config);

        await foreach (var record in csv.GetRecordsAsync<PreprocessDataNews>())
        {
            yield return record;
        }
    }
}
