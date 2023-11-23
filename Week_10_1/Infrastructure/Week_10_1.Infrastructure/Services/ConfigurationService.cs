using Microsoft.Extensions.Configuration;
using Week_10_1.Application;

namespace Week_10_1.Infrastructure.Service
{
    public class ConfigurationService : IConfigurationService
    {
        private static ConfigurationService _instance;

        public static ConfigurationService GetInstance()
        {
            return _instance ??= new ConfigurationService();
        }

        public ConfigurationService()
        {
            Console.WriteLine("Instance Created!");
        }

        public string GetValue(string key)
        {
            ConfigurationManager configurationManager = new();

            configurationManager.SetBasePath(Directory.GetCurrentDirectory());

            configurationManager.AddJsonFile("appsettings.json");

            return configurationManager.GetSection(key).Value;
        }
    }
}
