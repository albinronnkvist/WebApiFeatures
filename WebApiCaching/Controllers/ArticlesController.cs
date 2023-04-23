using Microsoft.AspNetCore.Mvc;
using WebApiCaching.Repositories;
using WebApiCaching.Repositories.ArticleRepository;

namespace WebApiCaching.Controllers;

[ApiController]
[Route("api/articles")]
public class ArticlesController : ControllerBase
{
    private readonly IArticleRepository _articleRepository;

    public ArticlesController(IArticleRepository articleRepository)
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
    public async Task<IActionResult> GetSingle([FromRoute] long id)
    {
        var article = await _articleRepository.GetSingleAsync(id);
        if (article is null)
            return NotFound();

        return Ok(article);
    }
}
