using WebApiCaching.Entities;

namespace WebApiCaching.Repositories.AuthorRepository;

public class AuthorRepositoryMock : IAuthorRepository
{
    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        await Task.Delay(1000); // Fake db response time
        return GetAuthorsFromDbFake();
    }

    public async Task<Author?> GetSingleAsync(long id)
    {
        await Task.Delay(1000); // Fake db response time
        return GetAuthorsFromDbFake().FirstOrDefault(x => x.Id == id);
    }

    private static IEnumerable<Author> GetAuthorsFromDbFake()
    {
        return new List<Author>
        {
            new()
            {
                Id = 1,
                Name = "Ed Itorial",
                Age = 55
            },
            new()
            {
                Id = 2,
                Name = "Phil Columns",
                Age = 20
            },
            new()
            {
                Id = 3,
                Name = "Reed Wrightly",
                Age = 35
            }
        }.AsEnumerable();
    }
}
