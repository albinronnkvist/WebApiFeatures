using Microsoft.AspNetCore.Mvc;
using WebApiCaching.Repositories;

namespace WebApiCaching.Controllers;

[ApiController]
[Route("api/news")]
public class NewsController : ControllerBase
{
    private readonly IArticleRepository _articleRepository;

    public NewsController(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var articles = await _articleRepository.GetAllAsync();

        return Ok(articles);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetArticle([FromRoute] Guid id)
    {
        var article = await _articleRepository.GetSingleAsync(id);
        if (article is null)
            return NotFound();

        return Ok(article);
    }
}
