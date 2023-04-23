using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using WebApiCaching.Repositories.ArticleRepository;
using WebApiCaching.Repositories.AuthorRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

// Alternative #1 (Using Scrutor)
builder.Services.AddScoped<IArticleRepository, ArticleRepositoryMock>();
builder.Services.Decorate<IArticleRepository>((inner, provider) => 
    new ArticleRepositoryMemoryCacheDecorator(inner, provider.GetRequiredService<IMemoryCache>()));

builder.Services.AddScoped<IAuthorRepository, AuthorRepositoryMock>();
builder.Services.Decorate<IAuthorRepository>((inner, provider) =>
    new AuthorRepositoryRedisCacheDecorator(inner, provider.GetRequiredService<IDistributedCache>()));

// Alternative #2
//builder.Services.AddScoped<IArticleRepository>(serviceProvider =>
//{
//    var memoryCache = serviceProvider.GetRequiredService<IMemoryCache>();

//    var concreteArticleRepository = new ArticleRepositoryMock();
//    var withMemoryCache = new ArticleRepositoryMemoryCacheDecorator(concreteArticleRepository, memoryCache);

//    return withMemoryCache;
//});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
