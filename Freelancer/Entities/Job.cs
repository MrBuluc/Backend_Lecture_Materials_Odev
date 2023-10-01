using Freelancer.Common;

namespace Freelancer.Entities
{
    internal class Job : EntityBase<Guid>
    {
        public Job(Guid ıd, DateTimeOffset createdOn) : base(ıd, createdOn)
        {
        }
    }
}
