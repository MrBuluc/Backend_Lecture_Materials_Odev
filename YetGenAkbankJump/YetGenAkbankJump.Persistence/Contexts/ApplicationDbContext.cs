using Microsoft.EntityFrameworkCore;
using System.Reflection;
using YetGenAkbankJump.Domain.Entities;
using YetGenAkbankJump.Domain.Identity;

namespace YetGenAkbankJump.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories {  get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Student> Students { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Ignore<User>();
            modelBuilder.Ignore<Role>();
            modelBuilder.Ignore<UserSetting>();
            
            base.OnModelCreating(modelBuilder);
        }

    }
}
