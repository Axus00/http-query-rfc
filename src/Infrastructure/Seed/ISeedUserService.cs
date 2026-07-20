using http_query_rfc.src.Application.DTOs;

namespace http_query_rfc.src.Infrastructure.Seed;
public interface ISeedUserService
{
    IReadOnlyList<UserDto> GetUsers();
    UserDto? GetUserById(Guid id);
}
