using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace WebApiFilters.Filters;

public class ExecutionTimeActionFilter : IActionFilter
{
    private readonly ILogger<ExecutionTimeActionFilter> _logger;
    private readonly Stopwatch _stopwatch;

    public ExecutionTimeActionFilter(ILogger<ExecutionTimeActionFilter> logger)
    {
        _logger = logger;
        _stopwatch = new Stopwatch();
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _stopwatch.Start();
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _stopwatch.Stop();
        _logger.LogInformation("Action execution time: {ElapsedMs}ms", 
            _stopwatch.ElapsedMilliseconds);
    }
}
