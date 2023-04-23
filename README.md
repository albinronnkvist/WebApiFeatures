# WebApiCaching

An example of _in-memory caching_ and _distributed caching_ using _Redis_ in ASP.NET Core Web API. 
Caching is implemented with the _Decorator Pattern_. _Scrutor_ is used for simplified DI registration. 

## Configure Redis

### Setup Redis server

Pull image: 
  ```
  docker pull redis
  ```
Run container:
  ```
  docker run -p 6379:6379 --name redis -d redis
  ```
  
### appsettings.json
```
"ConnectionStrings": {
    "Redis": "localhost:6379" // Replace with the appropriate connection string for your Redis server
}
```
