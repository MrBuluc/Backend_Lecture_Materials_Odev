using Week_9_2;

Console.WriteLine("Singleton");

ConfigurationService configurationService = ConfigurationService.GetInstance();
ConfigurationService.GetInstance();
ConfigurationService.GetInstance();
ConfigurationService.GetInstance();

Console.WriteLine(configurationService.GetValue("ConnectionStrings:PostgreSQL"));
