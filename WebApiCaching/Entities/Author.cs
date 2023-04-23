namespace WebApiCaching.Entities;

public class Author
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required int Age { get; set; }
    public List<Article>? Articles { get; set; }
}
