using Microsoft.AspNetCore.Mvc;

namespace WebApiVersioning.Controllers.QueryStringAndMediaHeader;

[ApiController]
[Route("api/products")]
[ApiVersion("1.0")]
// Using query string: api/products?api-version=1.0
// Using Media/Header: add "X-Version" header with value "1.0"
public class ProductsControllerV1 : ControllerBase
{
    [HttpGet]
    public IActionResult GetVersion()
    {
        return Ok("Version 1");
    }
}
