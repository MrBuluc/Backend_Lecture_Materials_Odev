using Week_4_1.Common;

namespace Freelancer.Entities
{
    public class Customer : Person<Guid>
    {
        public string PhoneNumber { get; set; }

        public Customer(Guid id, DateTimeOffset createdOn, string firstName, string lastName, string phoneNumber) : base(id, createdOn, firstName, lastName)
        {
            PhoneNumber = phoneNumber;
        }

        public override string? ToString()
        {
            return $"Customer(Id: {Id}, CreatedOn: {CreatedOn}, FirstName: {FirstName}, LastName: {LastName}, PhoneNumber: {PhoneNumber})";
        }
    }
}
