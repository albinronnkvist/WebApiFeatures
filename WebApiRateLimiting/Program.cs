using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Options;
using WebApiRateLimiting.Options.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<RateLimitingOptions>(
    builder.Configuration.GetSection(nameof(RateLimitingOptions)));

var rateLimitingOptions = builder.Configuration
    .GetSection(nameof(RateLimitingOptions))
    .Get<RateLimitingOptions>();
ArgumentNullException.ThrowIfNull(rateLimitingOptions);

builder.Services.AddRateLimiter(opt =>
{
    // Fixed window limiter
    opt.AddFixedWindowLimiter(policyName: rateLimitingOptions.FixedWindow.PolicyName, options =>
    {
        options.PermitLimit = rateLimitingOptions.FixedWindow.PermitLimit;
        options.Window = TimeSpan.FromSeconds(rateLimitingOptions.FixedWindow.WindowInSeconds);
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = rateLimitingOptions.FixedWindow.QueueLimit;
    });

    // Sliding window limiter
    opt.AddSlidingWindowLimiter(policyName: rateLimitingOptions.SlidingWindow.PolicyName, options =>
    {
        options.PermitLimit = rateLimitingOptions.SlidingWindow.PermitLimit;
        options.Window = TimeSpan.FromSeconds(rateLimitingOptions.SlidingWindow.WindowInSeconds);
        options.SegmentsPerWindow = rateLimitingOptions.SlidingWindow.SegmentsPerWindow;
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = rateLimitingOptions.SlidingWindow.QueueLimit;
    });

    // Token bucket limiter
    opt.AddTokenBucketLimiter(policyName: rateLimitingOptions.TokenBucket.PolicyName, options =>
    {
        options.TokenLimit = rateLimitingOptions.TokenBucket.TokenLimit;
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = rateLimitingOptions.TokenBucket.QueueLimit;
        options.ReplenishmentPeriod = TimeSpan.FromSeconds(rateLimitingOptions.TokenBucket.ReplenishmentPeriodInSeconds);
        options.TokensPerPeriod = rateLimitingOptions.TokenBucket.TokensPerPeriod;
        options.AutoReplenishment = rateLimitingOptions.TokenBucket.AutoReplenishment;
    });

    // Concurrency limiter
    opt.AddConcurrencyLimiter(policyName: rateLimitingOptions.Concurrency.PolicyName, options =>
    {
        options.PermitLimit = rateLimitingOptions.Concurrency.PermitLimit;
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = rateLimitingOptions.Concurrency.QueueLimit;
    });

    opt.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseRateLimiter();

app.UseAuthorization();

app.MapControllers();

app.Run();
