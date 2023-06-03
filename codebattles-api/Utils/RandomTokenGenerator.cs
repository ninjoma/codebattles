using System;
using System.Security.Cryptography;
using System.Text;

namespace codebattle_api.utils
{
    public static class RandomTokenGenerator
    {
        public static string GenerateToken()
        {
            return new Guid(RandomNumberGenerator.GetBytes(16)).ToString();
        }
        
    }
}