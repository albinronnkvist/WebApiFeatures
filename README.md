Different useful features in ASP.NET Core Web API.

# Caching

Caching is a technique used to store and reuse responses, improving performance and reducing server load. It can be implemented using in-memory caching, distributed caching, or response caching middleware.
In this example I demonstrate _in-memory caching_ and _distributed caching_ using _Redis_. 
It's implemented with the _Decorator Pattern_, where _Scrutor_ is used for simplified DI registration. 

## Configure Redis

- Setup Redis server

  - Pull image: 
  ```
  docker pull redis
  ```
  - Run container:
  ```
  docker run -p 6379:6379 --name redis -d redis
  ```
  
- appsettings.json
```
"ConnectionStrings": {
    "Redis": "localhost:6379" // Replace with the appropriate connection string for your Redis server
}
```
# Versioning

Versioning allows you to manage changes to the API while maintaining backward compatibility for clients. It can be implemented using various strategies, such as query string parameters, URL path segments, HTTP headers, or media type parameters.

# Filters

Filters are components that enable you to execute custom code before or after specific stages of the request processing pipeline. They can be used for tasks such as logging, caching, error handling, or authorization, and are applied using attributes on controllers or actions, or registered globally in the startup file.

# Rate limiting

Rate limiting is a technique used to control the number of requests a client can make to a server within a specified time window. It helps protect against excessive load, prevents abuse, and maintains the overall performance and stability of the API.
In this example I demonstrate four rate limiting strategies: Fixed Window, Sliding Window, Token Bucket and Concurrency Limiter.

