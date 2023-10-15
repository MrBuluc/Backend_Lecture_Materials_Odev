using Microsoft.Extensions.Configuration;

namespace Productify.Persistence.Contexts
{
    public static class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/Productify.MVC"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetSection("ConnectionStrings")["PostgreSQL"];

            }
        }
    }
}
