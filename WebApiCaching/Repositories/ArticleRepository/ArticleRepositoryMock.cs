using WebApiCaching.Entities;

namespace WebApiCaching.Repositories.ArticleRepository;

public class ArticleRepositoryMock : IArticleRepository
{
    public async Task<IEnumerable<Article>> GetAllAsync()
    {
        await Task.Delay(1000); // Fake db response time
        return GetArticlesFromDbFake();
    }

    public async Task<Article?> GetSingleAsync(long id)
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
                Id = 1,
                Title = "AI Chef Cooks Up a Tasty Byte",
                Content = "As technology continues to advance, artificial intelligence (AI) has made its way into the culinary world with an AI chef that can cook up a tasty byte hehe.",
                CreatedAtUtc = DateTimeOffset.UtcNow.AddDays(-1),
                UpdatedAtUtc = DateTimeOffset.UtcNow,
                AuthorId = 1
            },
            new()
            {
                Id = 2,
                Title = "Drone-Delivered Pizza: A Slice of the Future",
                Content = "The dream of drone-delivered pizza is becoming a reality as pizzerias and tech companies team up to bring slices to doorsteps in record time.",
                CreatedAtUtc = DateTimeOffset.UtcNow.AddDays(-5),
                UpdatedAtUtc = DateTimeOffset.UtcNow.AddDays(-2),
                AuthorId = 2
            },
            new()
            {
                Id = 3,
                Title = "Dancing Cows Perform 'Moosical': A Dairy Tale of Love and Adventure",
                Content = "In a field in rural France, a group of cows have been rehearsing for months for their upcoming performance of 'Moosical', a heartwarming tale of love and adventure told through dance.",
                CreatedAtUtc = DateTimeOffset.UtcNow.AddDays(-7),
                UpdatedAtUtc = DateTimeOffset.UtcNow.AddDays(-3),
                AuthorId = 3
            }
        }.AsEnumerable();
    }
}
