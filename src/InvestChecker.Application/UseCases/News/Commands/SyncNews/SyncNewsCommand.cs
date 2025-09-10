using InvestChecker.Application.Common.Abstractions.Messaging;
using InvestChecker.Domain.Providers.Models;

namespace InvestChecker.Application.UseCases.News.Commands.SyncNews;

public class SyncNewsCommand : IQuery<IEnumerable<NewsItem>>;
