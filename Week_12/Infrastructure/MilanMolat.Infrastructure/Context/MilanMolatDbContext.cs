using Microsoft.EntityFrameworkCore;
using MilanMolat.Domain.Entities;

namespace MilanMolat.Infrastructure.Context
{
    public class MilanMolatDbContext : DbContext
    {
        public DbSet<DefraudedPerson> DefraudedPeople { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MilanMolat");
        }
    }
}
