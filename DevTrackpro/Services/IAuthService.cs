using DevTrackPro.DTOs;
using Microsoft.AspNetCore.Identity;
namespace DevTrackPro.Services;

public interface IAuthService
{
    Task<IdentityResult> RegisterAsync(RegisterDto dto);
    Task<string?> LoginAsync(LoginDto dto);
    Task<string> GenerateJwtTokenAsync(IdentityUser user);
}