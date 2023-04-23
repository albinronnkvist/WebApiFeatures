using WebApiCaching.Entities;

namespace WebApiCaching.Repositories;

public class ArticleRepositoryMock : IArticleRepository
{
    public async Task<IEnumerable<Article>> GetAllAsync()
    {
        await Task.Delay(1000); // Fake db response time
        return GetArticlesFromDbFake();
    }

    public async Task<Article?> GetSingleAsync(Guid id)
    {
        await Task.Delay(1000); // Fake db response time
        return GetArticlesFromDbFake().FirstOrDefault(x => x.Id == id);
    }

    private static IEnumerable<Article> GetArticlesFromDbFake()
    {
        return new List<Article>
        {
            new()
            {
                Id = Guid.Parse("a05e9759-45c8-4286-9970-4944e09064f1"),
                Title = "Title 1",
                Author = "Bob Bobson",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                CreatedAtUtc = DateTimeOffset.UtcNow.AddDays(-1),
                UpdatedAtUtc = DateTimeOffset.UtcNow
            },
            new()
            {
                Id = Guid.Parse("b05e9759-45c8-4286-9970-4944e09064f2"),
                Title = "Title 2",
                Author = "Nellie Nelson",
                Content = "Vivamus lacinia odio vitae vestibulum ultrices.",
                CreatedAtUtc = DateTimeOffset.UtcNow.AddDays(-5),
                UpdatedAtUtc = DateTimeOffset.UtcNow.AddDays(-2)
            },
            new()
            {
                Id = Guid.Parse("c05e9759-45c8-4286-9970-4944e09064f3"),
                Title = "Title 3",
                Author = "Gloria Glson",
                Content = "Vivamus lacinia odio vitae vestibulum ultrices.",
                CreatedAtUtc = DateTimeOffset.UtcNow.AddDays(-7),
                UpdatedAtUtc = DateTimeOffset.UtcNow.AddDays(-3)
            }
        }.AsEnumerable();
    }
}
