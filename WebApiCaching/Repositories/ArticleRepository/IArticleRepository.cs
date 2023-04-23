using WebApiCaching.Entities;

namespace WebApiCaching.Repositories.ArticleRepository;

public interface IArticleRepository
{
    Task<IEnumerable<Article>> GetAllAsync();
    Task<Article?> GetSingleAsync(long id);
}
