using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace YetGenAkbankJump.Persistence.Contexts
{
    public class YetgenIdentityContextFactory : IDesignTimeDbContextFactory<YetgenIdentityContext>
    {
        public YetgenIdentityContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<YetgenIdentityContext> optionsBuilder = new();
            optionsBuilder.UseNpgsql(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetSection("YetgenPostgreSQLDB").Value);

            return new YetgenIdentityContext(optionsBuilder.Options);
        }
    }
}
