using WebApiCaching.Entities;

namespace WebApiCaching.Repositories.AuthorRepository;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAllAsync();
    Task<Author?> GetSingleAsync(long id);
}
