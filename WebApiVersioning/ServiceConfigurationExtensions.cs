using Microsoft.AspNetCore.Mvc.Versioning;

namespace WebApiVersioning;

public static class ServiceConfigurationExtensions
{
    public static void ConfigureOpenApi(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public static void ConfigureVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(o =>
        {
            // Use version 1.0 if a client doesn't specify the version
            o.AssumeDefaultVersionWhenUnspecified = true;
            o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);

            // Show actively supported API versions
            // It will add both api-supported-versions and api-deprecated-versions headers to our response.
            o.ReportApiVersions = true;

            // Combine different ways of reading the API version
            // (from a query string, request header, and media type).
            o.ApiVersionReader = ApiVersionReader.Combine(
                new QueryStringApiVersionReader("api-version"),
                new HeaderApiVersionReader("X-Version"),
                new MediaTypeApiVersionReader("ver"));
        });

        services.AddVersionedApiExplorer(
            options =>
            {
                options.GroupNameFormat = "'v'VVV"; // format the version as “‘v’major[.minor][-status]”
                options.SubstituteApiVersionInUrl = true; // only necessary when versioning by the URI segment
            });
    }
}
