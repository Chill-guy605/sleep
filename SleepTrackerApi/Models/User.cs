using System.Security.Cryptography;
using System.Text;

namespace SleepTrackerApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }

        private string passwordHash;
        public string PasswordHash
        {
            get { return passwordHash; }
            set
            {
                // Хешируем пароль перед сохранением
                passwordHash = HashPassword(value);
            }
        }

        public string AuthToken { get; set; }

        public ICollection<SleepRecord> SleepRecords { get; set; }

        // Метод для хеширования пароля
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}

