using Microsoft.AspNetCore.Mvc;
using WebApiCaching.Repositories.AuthorRepository;

namespace WebApiCaching.Controllers;

[ApiController]
[Route("api/authors")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorsController(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var authors = await _authorRepository.GetAllAsync();

        return Ok(authors);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingle([FromRoute] long id)
    {
        var author = await _authorRepository.GetSingleAsync(id);
        if (author == null)
            return NotFound();

        return Ok(author);
    }
}
