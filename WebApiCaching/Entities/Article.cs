namespace WebApiCaching.Entities;

public class Article
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public DateTimeOffset CreatedAtUtc { get; set; }
    public DateTimeOffset UpdatedAtUtc { get; set; }

    public required int AuthorId { get; set; }
    public Author? Author { get; set; }
}
