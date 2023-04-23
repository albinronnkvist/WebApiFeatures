using WebApiCaching.Entities;

namespace WebApiCaching.Repositories;

public interface IArticleRepository
{
    Task<IEnumerable<Article>> GetAllAsync();
    Task<Article?> GetSingleAsync(Guid id);
}
