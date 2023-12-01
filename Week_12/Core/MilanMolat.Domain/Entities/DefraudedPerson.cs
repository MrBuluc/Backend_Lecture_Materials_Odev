using MilanMolat.Domain.Common;

namespace MilanMolat.Domain.Entities
{
    public class DefraudedPerson : EntityBase
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
