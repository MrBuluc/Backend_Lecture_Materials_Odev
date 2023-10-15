using Microsoft.EntityFrameworkCore;
using Week_5_2.Entities;
using Week_5_2.Services;

namespace Week_5_2.Contexts
{
    public class ShopifyDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Dictionary<string, dynamic>? dbSecrets = JsonService.GetJson("D:\\Users\\HAKKICAN\\Desktop\\Software\\C#\\YetGen Jump & Akbank Backend Programı Eğitimi\\Week_5_2\\Secrets\\DbSecrets.json");
            if (dbSecrets is not null && dbSecrets.Any())
            {
                optionsBuilder.UseNpgsql($"Server={dbSecrets["Server"]};Port=5432;Database=ShopifyHakkicanBuluc;User Id={dbSecrets["User Id"]};Password={dbSecrets["Password"]};");
            }

        }
    }
}
