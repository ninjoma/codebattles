using System.Security.Cryptography;

namespace codebattle_api.utils
{
    /// <summary>
    /// Class to encrypt and Compare Argon2 Passwords
    /// </summary>
    public static class PasswordHasher
    {
        private const int SaltSize = 16; // Tamaño de la sal en bytes
        private const int HashSize = 32; // Tamaño del hash en bytes
        private const int Iterations = 10000; // Número de iteraciones para el algoritmo Argon2

        public static string HashPassword(string password)
        {
            byte[] salt = GenerateSalt();

            using (var argon2 = new Rfc2898DeriveBytes(password, salt, Iterations))
            {
                byte[] hash = argon2.GetBytes(HashSize);
                byte[] hashBytes = new byte[HashSize + SaltSize];
                Array.Copy(hash, 0, hashBytes, 0, HashSize);
                Array.Copy(salt, 0, hashBytes, HashSize, SaltSize);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public static bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, HashSize, salt, 0, SaltSize);

            using (var argon2 = new Rfc2898DeriveBytes(enteredPassword, salt, Iterations))
            {
                byte[] enteredPasswordHash = argon2.GetBytes(HashSize);

                // Comparar solo los bytes de hash sin incluir la sal
                for (int i = 0; i < HashSize; i++)
                {
                    if (enteredPasswordHash[i] != hashBytes[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
    }
}