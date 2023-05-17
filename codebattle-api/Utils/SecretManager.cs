namespace codebattle_api.utils
{
    /// <summary>
    /// Class to get Secrets
    /// </summary>
    public static class SecretManager
    {
        private static IConfigurationRoot _configuration;

        static SecretManager()
        {
            _configuration = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();
        }

        public static string? GetSecret(string secretName)
        {
            return _configuration[secretName];
        }
    }
}