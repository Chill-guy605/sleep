using SleepTrackerApi.Models;
using SleepTrackerApi.Data;
using System;
using System.Threading.Tasks;

namespace SleepTrackerApi.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterUserAsync(string login, string password)
        {
            var user = new User
            {
                Login = login,
                PasswordHash = password, // Это автоматически хеширует пароль
                AuthToken = GenerateAuthToken() // Генерация токена аутентификации
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            
            return user;
        }

        private string GenerateAuthToken()
        {
            // Генерация уникального токена для аутентификации
            return Guid.NewGuid().ToString();
        }
    }
}
