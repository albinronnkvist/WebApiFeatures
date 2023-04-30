using Microsoft.AspNetCore.Mvc;
using WebApiFilters.Entities;
using WebApiFilters.Filters;
using WebApiFilters.Filters.FilterAttributes;

namespace WebApiFilters.Controllers;

[ApiController]
[Route("api/procucts")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    [ResponseHeader("Filter-Header", "Filter Value")]
    [ServiceFilter(typeof(ExecutionTimeActionFilter))]
    public async Task<IActionResult> GetProducts()
    {
        await Task.Delay(200);
        var products = new List<Product>
        {
            new()
            {
                Id = 1,
                Name = "Phone",
                Description = "Google Pixel 5",
                Price = 20.5m
            }
        };

        return Ok(products);
    }
}
