namespace WebApiCaching.Entities;

public class Article
{
    public required string Title { get; set; }
    public string? Author { get; set; }
    public required string Content { get; set; }
    public DateTimeOffset CreatedAtUtc { get; set; }
    public DateTimeOffset UpdatedAtUtc { get; set; }
}
