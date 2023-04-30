namespace WebApiRateLimiting.Options.RateLimiting;

public record SlidingRateLimitingOptions(string PolicyName, 
    int PermitLimit, int WindowInSeconds, int QueueLimit, int SegmentsPerWindow);
