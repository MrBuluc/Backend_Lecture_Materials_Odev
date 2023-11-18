using YetGenAkbankJumpOOPConsole.Common;

namespace YetGenAkbankJumpOOPConsole.Entities
{
    public class Log : ICreatedByEntity, IDeletedByEntity
    {
        public string CreatedByUserId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string DeletedByUserId { get; set; }
        public DateTimeOffset DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
