using Microsoft.Extensions.Configuration;

namespace Week_9_2
{
    public class ConfigurationService
    {
        private static ConfigurationService _instance;

        public static ConfigurationService GetInstance()
        {
            return _instance ??= new ConfigurationService();
        }

        ConfigurationService()
        {
            Console.WriteLine("Instance Created!");
        }

        public string GetValue(string key)
        {
            ConfigurationManager configurationManager = new();

            configurationManager.SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName);

            configurationManager.AddJsonFile("Configuration.json");

            return configurationManager.GetSection(key).Value;
        }
    }
}
