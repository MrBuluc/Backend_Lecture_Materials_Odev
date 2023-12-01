using MilanMolat.Application.Abstract.DefraudedPersonRepositories;
using MilanMolat.Infrastructure.Context;

namespace MilanMolat.Infrastructure.Repositories.DefraudedPerson
{
    public class DefraudedPersonReadRepository : ReadRepository<Domain.Entities.DefraudedPerson>, IDefraudedPersonReadRepository
    {
        public DefraudedPersonReadRepository(MilanMolatDbContext context) : base(context)
        {
            
        }
    }
}
