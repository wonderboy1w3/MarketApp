using MarketApp.Domain.Commons;
using MarketApp.Domain.Enums;

namespace MarketApp.Domain.Entities.Users;

public class User : Auditable
{
    public string Username { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
}
