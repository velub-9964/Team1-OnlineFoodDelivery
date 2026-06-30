using AuthService.DTOs;

namespace AuthService.Services
{
    public interface IAuthService
    {
        Task Register(RegisterDto dto);
        Task<string> Login(LoginDto dto);
        Task<UserDto?> FindByEmailAsync(string email);
    }
}