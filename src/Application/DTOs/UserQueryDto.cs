namespace http_query_rfc.src.Application.DTOs;

public class UserQueryDto
{
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public int? MinAge { get; set; }
    public int? MaxAge { get; set; }
}
