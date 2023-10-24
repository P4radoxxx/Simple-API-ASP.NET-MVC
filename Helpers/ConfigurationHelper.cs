using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebAPITest.Helpers

{
    public static class ConfigurationHelper
    {


        // Get the conection string from appsettings.json, easier than create a config builder instance every time.
        // Because i'm a lazy b*tch :D
        private static IConfiguration configuration;



        static ConfigurationHelper()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static string GetConnectionString(string name)
        {
            return configuration.GetConnectionString(name);
        }
    }
}
