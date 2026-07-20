using System.Net;

namespace http_query_rfc.src.shared;
public class ApiResponse
{
    public HttpStatusCode StatusCode;
    public required string Message;
}