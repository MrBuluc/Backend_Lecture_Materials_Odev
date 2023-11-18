using Microsoft.EntityFrameworkCore;
using System.Reflection;
using YetGenAkbankJump.Domain.Entities;

namespace YetGenAkbankJump.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories {  get; set; }
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            base.OnModelCreating(modelBuilder);
        }

    }
}
