using Microsoft.AspNetCore.Mvc;

namespace WebApiVersioning.Controllers.URI;

[ApiController]
[Route("api/v{version:apiVersion}/orders")]
// Indicate that the API version is deprecated
// client will get this information from the header of api-deprecated-versions from response.
[ApiVersion("1.0", Deprecated = true)]
// Using URI: api/v1/products
public class OrdersControllerV1 : ControllerBase
{
    [HttpGet]
    public IActionResult GetVersion()
    {
        return Ok("Version 1 (deprecated)");
    }
}
