using Microsoft.AspNetCore.Mvc;
using http_query_rfc.src.application.Common;
using http_query_rfc.src.Application.DTOs;
using http_query_rfc.src.Application.Abstractions;

namespace http_query_rfc.src.api.Controllers;

[ApiController]
[Route($"{ApiRouteConstants.BaseApiRoute}")]
public class EventsController(
    IUserRepository userRepository
) : ControllerBase
{
    [HttpGet($"{ApiRouteConstants.GetUsers}")]
    public async Task<IActionResult> AllUsersWithGet(
        [FromQuery] UserQueryDto query
    )
    {
        var users = await userRepository.GetUsers();
        return Ok(FilterUsers(users, query));
    }

    [HttpPost($"{ApiRouteConstants.GetUsers}")]
    public async Task<IActionResult> QueryUsersWithPost(
        [FromBody] UserQueryDto query
    )
    {
        var users = await userRepository.GetUsers();
        return Ok(FilterUsers(users, query));
    }

    [AcceptVerbs("QUERY")]
    [Route(ApiRouteConstants.GetUsers)]
    public async Task<IActionResult> QueryUsers(
        [FromBody] UserQueryDto query
    )
    {
        var users = await userRepository.GetUsers();
        return Ok(FilterUsers(users, query));
    }

    private static List<UserDto> FilterUsers(
        IEnumerable<UserDto> users,
        UserQueryDto query
    )
    {
        return users.Where(user =>
            (string.IsNullOrWhiteSpace(query.Name) ||
                user.Name.Contains(query.Name, StringComparison.OrdinalIgnoreCase)) &&
            (string.IsNullOrWhiteSpace(query.LastName) ||
                user.LastName.Contains(query.LastName, StringComparison.OrdinalIgnoreCase)) &&
            (string.IsNullOrWhiteSpace(query.Email) ||
                user.Email.Contains(query.Email, StringComparison.OrdinalIgnoreCase)) &&
            (!query.MinAge.HasValue || user.Age >= query.MinAge) &&
            (!query.MaxAge.HasValue || user.Age <= query.MaxAge))
            .ToList();
    }
}
