using Bogus.DataSets;

namespace http_query_rfc.src.Application.DTOs;
public class UserDto
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public int Age { get; set; }

    public string Email { get; set; } = string.Empty;

    public DateOnly CreatedAt { get; set; }

    public DateOnly UpdatedAt { get; set; }
}
