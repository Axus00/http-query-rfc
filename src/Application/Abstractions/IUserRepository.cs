using http_query_rfc.src.Application.DTOs;

namespace http_query_rfc.src.Application.Abstractions;
public interface IUserRepository
{
    public Task<IReadOnlyList<UserDto>> GetUsers();
    public Task<UserDto> GetUserById(Guid id);
}
