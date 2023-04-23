using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using WebApiCaching.Entities;

namespace WebApiCaching.Repositories.AuthorRepository;

public class AuthorRepositoryRedisCacheDecorator : IAuthorRepository
{
    private readonly IAuthorRepository _innerAuthorRepository;
    private readonly IDistributedCache _cache;

    public AuthorRepositoryRedisCacheDecorator(IAuthorRepository innerAuthorRepository, IDistributedCache cache)
    {
        _innerAuthorRepository = innerAuthorRepository;
        _cache = cache;
    }


    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        return await _innerAuthorRepository.GetAllAsync();
    }

    public async Task<Author?> GetSingleAsync(long id)
    {
        var key = $"{nameof(Author)}-{id}";

        var cachedAuthor = await _cache.GetStringAsync(key);
        if (!string.IsNullOrEmpty(cachedAuthor)) 
            return JsonSerializer.Deserialize<Author>(cachedAuthor);
        
        var author = await _innerAuthorRepository.GetSingleAsync(id);
        if (author is not null)
        {
            await _cache.SetStringAsync(key, JsonSerializer.Serialize(author));
        }

        return author;
    }
}
