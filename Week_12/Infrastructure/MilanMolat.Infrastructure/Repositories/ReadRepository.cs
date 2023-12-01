using Microsoft.EntityFrameworkCore;
using MilanMolat.Application.Abstract;
using MilanMolat.Domain.Common;
using MilanMolat.Infrastructure.Context;

namespace MilanMolat.Infrastructure.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : EntityBase
    {
        private readonly MilanMolatDbContext _context;

        public ReadRepository(MilanMolatDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public List<T> GetAll()
        {
            return Table.ToList();
        }

        public T GetById(string id)
        {
            return Table.FirstOrDefault(x => x.Id == Guid.Parse(id));
        }
    }
}
