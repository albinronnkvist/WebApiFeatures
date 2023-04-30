using Microsoft.AspNetCore.Mvc;

namespace WebApiVersioning.Controllers.QueryStringAndMediaHeader;

[ApiController]
[Route("api/products")]
[ApiVersion("2.0")]
// Using query string: api/products?api-version=2.0
// Using Media/Header: add "X-Version" header with value "2.0"
public class ProductsControllerV2 : ControllerBase
{
    [HttpGet]
    public IActionResult GetVersion()
    {
        return Ok("Version 2");
    }
}