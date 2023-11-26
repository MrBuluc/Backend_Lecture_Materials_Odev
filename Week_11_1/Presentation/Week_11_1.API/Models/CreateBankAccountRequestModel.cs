using Microsoft.AspNetCore.Mvc;
using Week_11_1.Domain.ModelMetadaTypes;

namespace Week_11_1.API.Models
{
    [ModelMetadataType(typeof(BankAccountMetadata))]
    public class CreateBankAccountRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
