using http_query_rfc.src.Application.Abstractions;
using http_query_rfc.src.Application.DTOs;
using http_query_rfc.src.Infrastructure.Seed;

namespace http_query_rfc.src.Infrastructure;

public class UserRepository(
    ISeedUserService seedUserService
) : IUserRepository
{
    public Task<UserDto> GetUserById(Guid id)
    {
        var user = seedUserService
            .GetUsers()
            .Single(u => u.Id == id);
        
        return Task.FromResult(user);
    }

    public Task<IReadOnlyList<UserDto>> GetUsers()
    {
        var allUsers = seedUserService
            .GetUsers()
            .ToList()
            .AsReadOnly();
        
        return Task.FromResult<IReadOnlyList<UserDto>>(allUsers);
    }
}
