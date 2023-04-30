namespace WebApiRateLimiting.Options.RateLimiting;

public record RateLimitingOptions
{
    public required FixedRateLimitingOptions FixedWindow { get; init; }
    public required SlidingRateLimitingOptions SlidingWindow { get; init; }
    public required TokenBucketRateLimitingOptions TokenBucket { get; init; }
    public required ConcurrencyRateLimitingOptions Concurrency { get; init; }
}
