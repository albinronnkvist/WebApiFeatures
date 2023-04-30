using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace WebApiFilters.Filters;

public class ExecutionTimeActionFilterAsync : IAsyncActionFilter
{
    private readonly ILogger<ExecutionTimeActionFilter> _logger;
    private readonly Stopwatch _stopwatch;

    public ExecutionTimeActionFilterAsync(ILogger<ExecutionTimeActionFilter> logger)
    {
        _logger = logger;
        _stopwatch = new Stopwatch();
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        _stopwatch.Start();
        await Task.Delay(1000);

        // Above this line: do something before the action executes.
        await next();
        // Below this line: do something after the action executes.

        _stopwatch.Stop();
        _logger.LogInformation("Action execution time: {ElapsedMs}ms",
            _stopwatch.ElapsedMilliseconds);
    }
}
