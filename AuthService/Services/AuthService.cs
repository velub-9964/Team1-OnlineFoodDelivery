using System.Security.Cryptography;
using System.Text;
using AuthService.DTOs;
using AuthService.Models;
using AuthService.Repositories;

namespace AuthService.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;
        private readonly IJwtService _jwtService;

        public AuthService(IAuthRepository repository, IJwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }

        public async Task Register(RegisterDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password))
                throw new ArgumentException("Email and password are required.");

            var normalizedEmail = dto.Email.Trim().ToLowerInvariant();
            var existingUser = await _repository.FindByEmailAsync(normalizedEmail);
            if (existingUser != null)
                throw new Exception("User already exists!");

            var user = new User
            {
                Name = dto.Name.Trim(),
                Email = normalizedEmail,
                PasswordHash = HashPassword(dto.Password),
                // Role = Role.Customer
            };

            await _repository.Register(user);
        }

        public async Task<string> Login(LoginDto dto)
        {
            var normalizedEmail = dto.Email.Trim().ToLowerInvariant();
            var user = await _repository.Login(normalizedEmail, HashPassword(dto.Password));

            if (user == null)
                throw new UnauthorizedAccessException("Invalid email or password.");

            return _jwtService.GenerateToken(user);
        }

        public async Task<UserDto?> FindByEmailAsync(string email)
        {
            var userData = await _repository.FindByEmailAsync(email.Trim().ToLowerInvariant());
            if (userData == null)
                return null;

            return new UserDto
            {
                Name = userData.Name,
                Email = userData.Email
            };
        }

        private static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(bytes);
        }

    }
}
