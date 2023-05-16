using System.Security.Cryptography;

namespace codebattle_api.utils
{
    public class PasswordHasher
    {

        private const int SaltSize = 16; // Size of the salt in bytes
        private const int HashSize = 32; // Size of the hash in bytes
        private const int Iterations = 10000; // Number of iterations for the Argon2 algorithm

        public PasswordHasher()
        {

        }

        public static bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, HashSize, salt, 0, SaltSize);

            using (var argon2 = new Rfc2898DeriveBytes(enteredPassword, salt, Iterations))
            {
                byte[] enteredPasswordHash = argon2.GetBytes(HashSize);
                return CompareByteArrays(enteredPasswordHash, hashBytes, HashSize);
            }
        }

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

        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        private static bool CompareByteArrays(byte[] array1, byte[] array2, int length)
        {
            if (array1 == null || array2 == null || array1.Length != length || array2.Length != length)
            {
                return false;
            }
            for (int i = 0; i < length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}