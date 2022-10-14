using Microsoft.AspNetCore.Http;

namespace MarketApp.Service.Helpers;

public class HttpContextHelper
{
    public static IHttpContextAccessor Accessor { get; set; }
    public static HttpContext HttpContext { get; set; }
    public static long? UserId => GetUserId();
    public static string UserRole => HttpContext?.User.FindFirst("Role")?.Value;

    private static long? GetUserId()
    {
        long id;
        bool canParse = long.TryParse(HttpContext?.User?.Claims.FirstOrDefault(p => p.Type == "Id")?.Value, out id);

        return canParse ? id : null;
    }
}