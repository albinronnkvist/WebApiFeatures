using Microsoft.Extensions.Caching.Memory;
using WebApiCaching.Entities;

namespace WebApiCaching.Repositories.ArticleRepository;

public class ArticleRepositoryMemoryCacheDecorator : IArticleRepository
{
    private readonly IArticleRepository _innerArticleRepository;
    private readonly IMemoryCache _cache;

    public ArticleRepositoryMemoryCacheDecorator(IArticleRepository articleRepository, IMemoryCache cache)
    {
        _innerArticleRepository = articleRepository;
        _cache = cache;
    }

    public async Task<IEnumerable<Article>> GetAllAsync()
    {
        return await _innerArticleRepository.GetAllAsync();
    }

    public async Task<Article?> GetSingleAsync(long id)
    {
        if (_cache.TryGetValue<Article?>(id, out var cachedArticle))
        {
            return cachedArticle;
        }

        var article = await _innerArticleRepository.GetSingleAsync(id);
        if (article is not null)
        {
            _cache.Set(id, article, TimeSpan.FromMinutes(10));
        }

        return article;
    }
}
