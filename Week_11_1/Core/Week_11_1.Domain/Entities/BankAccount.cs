using Week_11_1.Domain.Common;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Week_11_1.Domain.ModelMetadaTypes;

namespace Week_11_1.Domain.Entities
{
    [ModelMetadataType(typeof(BankAccountMetadata))]
    public class BankAccount : EntityBase<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Balance { get; set; }

        public BankAccount()
        {
            CreatedOn = DateTimeOffset.UtcNow; // Set the CreatedOn field to the current UTC time.
            CreatedByUserId = "1";    // Set the CreatedByUserId to a specific user ID or retrieve it from your authentication system.
        }
    }
}
