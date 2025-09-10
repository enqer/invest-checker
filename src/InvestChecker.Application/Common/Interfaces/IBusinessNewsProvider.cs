namespace InvestChecker.Application.Common.Interfaces;

public interface IBusinessNewsProvider
{
    Task<object[]> GetLastestNews(CancellationToken cancellationToken);
}
