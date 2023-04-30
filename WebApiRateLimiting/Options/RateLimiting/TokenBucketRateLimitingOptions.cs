namespace WebApiRateLimiting.Options.RateLimiting;

public record TokenBucketRateLimitingOptions(string PolicyName, 
    int TokenLimit, 
    int QueueLimit, 
    int ReplenishmentPeriodInSeconds, 
    int TokensPerPeriod, 
    bool AutoReplenishment);
