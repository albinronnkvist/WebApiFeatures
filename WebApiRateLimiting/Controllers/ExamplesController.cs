using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Options;
using WebApiRateLimiting.Options.RateLimiting;

namespace WebApiRateLimiting.Controllers;

[ApiController]
[Route("api/examples")]
public class ExamplesController : ControllerBase
{
    private readonly RateLimitingOptions _options;

    public ExamplesController(IOptions<RateLimitingOptions> options)
    {
        _options = options.Value;
    }

    [HttpGet("disabled")]
    [DisableRateLimiting]
    public async Task<IActionResult> WithDisabled()
    {
        await Task.Delay(100);

        return Ok("Rate limiting disabled");
    }

    [HttpGet("fixed-window")]
    [EnableRateLimiting("fixed")]
    public async Task<IActionResult> WithFixedWindow()
    {
        await Task.Delay(100);

        return Ok("Fixed window rate limiting enabled. " +
                  $"{_options.FixedWindow.PermitLimit} requests are allowed every {_options.FixedWindow.WindowInSeconds} seconds.");
    }

    [HttpGet("sliding-window")]
    [EnableRateLimiting("sliding")]
    public async Task<IActionResult> WithSlidingWindow()
    {
        await Task.Delay(100);

        var evaluationPeriod = _options.SlidingWindow.WindowInSeconds / _options.SlidingWindow.SegmentsPerWindow;

        return Ok("Sliding window rate limiting enabled. " +
                  $"{_options.SlidingWindow.PermitLimit} requests are allowed every {_options.SlidingWindow.WindowInSeconds} seconds. " +
                  $"Available requests are evaluated every {evaluationPeriod} seconds.\n\n\n\n " +
                  "Example 15 requests per 15 seconds with 3 segments:\n\n " +
                  "- If you make 10 requests in the first segment(0-5 seconds) and 4 requests in the second segment(5-10 seconds), you will have 1 request left in the third segment(10-15 seconds) which you decide to make. You have now made 15 requests in 0-15 seconds, which is the max limit.\n\n " +
                  "- In the 15-20 seconds window, the 0-5 seconds window is no longer evaluated. So you get 10 requests back, you now have a total of 10 requests you can make, but you decide not to do it yet.\n\n " +
                  "- In the 20-25 seconds window, the 5-10 seconds window is no longer evaluated either. So you get 4 requests back, you now have a total of 14 requests.\n\n" +
                  "And so on...");
    }

    [HttpGet("token-bucket")]
    [EnableRateLimiting("token")]
    public async Task<IActionResult> WithTokenBucket()
    {
        await Task.Delay(100);

        return Ok("Token bucket rate limiting enabled. " +
                  $"You can make a maximum of {_options.TokenBucket.TokenLimit} requests. " +
                  $"When the max limit is reached, you get a '429 too many requests' response. You will have to wait for {_options.TokenBucket.ReplenishmentPeriodInSeconds} seconds and after that you can make {_options.TokenBucket.TokensPerPeriod} new requests.\n\n" +
                  $"{_options.TokenBucket.TokensPerPeriod} requests are added every {_options.TokenBucket.ReplenishmentPeriodInSeconds} seconds but will never exceed more than the max limit of {_options.TokenBucket.TokenLimit}");
    }

    [HttpGet("concurrency")]
    [EnableRateLimiting("concurrency")]
    public async Task<IActionResult> WithConcurrency()
    {
        await Task.Delay(100);

        return Ok("Concurrency rate limiting enabled. " +
                  $"{_options.Concurrency.PermitLimit} concurrent requests are allowed.\n\n" +
                  "Each request reduces the concurrency limit by one. When a request completes, the limit is increased by one.");
    }
}
