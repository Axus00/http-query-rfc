using http_query_rfc.src.Application.DTOs;
using http_query_rfc.src.Infrastructure.Seed.Bogus.Generators;

namespace http_query_rfc.src.Infrastructure.Seed;

public class SeedUserService : ISeedUserService
{
    private readonly List<UserDto> _users = DataSeed.GenerateUserData();
    private readonly object _lock = new();

    public IReadOnlyList<UserDto> GetUsers()
    {
        lock (_lock)
        {
            return _users.ToList().AsReadOnly();
        }
    }

    public UserDto? GetUserById(Guid id)
    {
        lock (_lock)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }
    }

}
