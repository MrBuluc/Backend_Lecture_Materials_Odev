using YetGenAkbankJumpOOPConsole.Enums;

namespace YetGenAkbankJumpOOPConsole.Common
{
    public class PersonBase
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTimeOffset CreateOn { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public void SayMyName() => Console.WriteLine(FullName);
    }
}
