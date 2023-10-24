namespace WebAPITest.Security
{
    using System.Security.Cryptography;


    // Generate random keys for diff purposes, parameter us the  wanted key lenght.
    public static class KeyGenerator
    {
        public static string GenerateSecretKey(int length)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var bytes = new byte[length];
                rng.GetBytes(bytes);
                return Convert.ToBase64String(bytes);
            }
        }
    }

}
