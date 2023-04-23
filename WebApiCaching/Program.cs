using Microsoft.Extensions.Caching.Memory;
using WebApiCaching.Repositories;
using WebApiCaching.Repositories.ArticleRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();

// Alternative #1 (Using Scrutor)
builder.Services.AddScoped<IArticleRepository, ArticleRepositoryMock>();
builder.Services.Decorate<IArticleRepository>((inner, provider) => 
    new ArticleRepositoryMemoryCacheDecorator(inner, provider.GetRequiredService<IMemoryCache>()));

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
