using MilanMolat.Domain.Common;

namespace MilanMolat.Application.Abstract
{
    public interface IReadRepository<T> : IRepository<T> where T : EntityBase
    {
        T GetById(string id);
        List<T> GetAll();
    }
}
