namespace Week_10_1.Application
{
    public interface IConfigurationService
    {
        public static IConfigurationService GetInstance;

        public string GetValue(string key);
    }
}