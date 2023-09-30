using NorthwindService.Application.Services.Data.Abstract;
using NorthwindService.Infrastructure.Data.Context;
using System.Security.Cryptography;
using System.Text;

namespace NorthwindService.Application.Services.Data.Helper
{
    public static class CryptoHelper
    {

        public static (string hashedPassword, string salt) GetSaltedHashedPassword(string password)
        {
            // Salt üret
            byte[] saltBytes = new byte[16];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            string salt = Convert.ToBase64String(saltBytes);  // Salt'ı string'e dönüştür.

            // Şifreyi ve salt'ı birleştir
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] combinedBytes = new byte[saltBytes.Length + passwordBytes.Length];
            Buffer.BlockCopy(saltBytes, 0, combinedBytes, 0, saltBytes.Length);
            Buffer.BlockCopy(passwordBytes, 0, combinedBytes, saltBytes.Length, passwordBytes.Length);

            // Saltlanmış şifreyi hash'le
            byte[] hashedBytes;
            using (SHA256 sha256 = SHA256.Create())
            {
                hashedBytes = sha256.ComputeHash(combinedBytes);
            }

            // Hash'lenmiş veriyi hex string olarak dönüştür
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in hashedBytes)
            {
                stringBuilder.Append(b.ToString("x2"));
            }

            return (hashedPassword: stringBuilder.ToString(), salt: salt);
        }
    }
}
