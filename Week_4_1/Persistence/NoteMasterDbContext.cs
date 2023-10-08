using Microsoft.EntityFrameworkCore;
using Week_4_1.Entities;

namespace Week_4_1.Persistence
{
    public class NoteMasterDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("NoteMaster");
        }
    }
}
