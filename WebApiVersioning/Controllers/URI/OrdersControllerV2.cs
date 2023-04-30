using Microsoft.AspNetCore.Mvc;

namespace WebApiVersioning.Controllers.URI;

[ApiController]
[Route("api/v{version:apiVersion}/orders")]
[ApiVersion("2.0")]
// Using URI: api/v2/products
public class OrdersControllerV2 : ControllerBase
{
    [HttpGet]
    public IActionResult GetVersion()
    {
        return Ok("Version 2");
    }
}
