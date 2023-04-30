namespace WebApiRateLimiting.Options.RateLimiting;

public record FixedRateLimitingOptions(string PolicyName, int PermitLimit, int WindowInSeconds, int QueueLimit);
