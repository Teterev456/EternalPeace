using System.Security.Cryptography;
using System.Text;

namespace EternalPeace.Services
{
    public static class HashingUtils
    {
        public static string PasswordToHash(string password)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}