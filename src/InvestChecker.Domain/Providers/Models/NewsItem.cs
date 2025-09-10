namespace InvestChecker.Domain.Providers.Models;

public class NewsItem
{
    public string Title { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public DateTime PublishedDate { get; set; }
    public string Description { get; set; } = string.Empty;
}