using Microsoft.EntityFrameworkCore;
using Week_11_1.Domain.Entities;

namespace Week_11_1.Persistence.Contexts
{
    public class PerfectAppDbContext : DbContext
    {
        public DbSet<BankAccount> BankAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("PerfectApp");
        }
    }
}
