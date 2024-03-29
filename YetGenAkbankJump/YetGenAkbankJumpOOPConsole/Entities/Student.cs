﻿using YetGenAkbankJumpOOPConsole.Common;

namespace YetGenAkbankJumpOOPConsole.Entities
{
    public class Student : EntityBase<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int No { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }
    }
}
