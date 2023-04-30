namespace WebApiRateLimiting.Options.RateLimiting;

public record ConcurrencyRateLimitingOptions(string PolicyName, int PermitLimit, int QueueLimit);
