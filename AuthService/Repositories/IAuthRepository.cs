using AuthService.Models;

namespace AuthService.Repositories
{
    public interface IAuthRepository
    {
        Task Register(User user);
        Task<User?> Login(string email, string password);
        Task<User?> FindByEmailAsync(string email);
    }
}