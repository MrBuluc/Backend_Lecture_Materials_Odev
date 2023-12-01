using Microsoft.EntityFrameworkCore;
using MilanMolat.Domain.Common;

namespace MilanMolat.Application.Abstract
{
    public interface IRepository<T> where T : EntityBase
    {
        DbSet<T> Table { get; }
    }
}
