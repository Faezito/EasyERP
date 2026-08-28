using System.Security.Claims;

namespace Model.DTOs.Login;

public class LoginResult
{
    public ClaimsPrincipal Claims { get; set; } = default!;
    public string Token { get; set; } = string.Empty;
}
