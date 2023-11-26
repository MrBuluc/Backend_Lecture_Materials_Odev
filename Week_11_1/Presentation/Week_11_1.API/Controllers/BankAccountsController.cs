using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week_11_1.API.Models;
using Week_11_1.Domain.Entities;
using Week_11_1.Persistence.Contexts;

namespace Week_11_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        public PerfectAppDbContext _perfectAppDbContext;

        public BankAccountsController(PerfectAppDbContext perfectAppDbContext)
        {
            _perfectAppDbContext = perfectAppDbContext;
        }

        [HttpPost("[action]")]
        public void SetDefaultUsersData()
        {
            _perfectAppDbContext.BankAccounts.AddRange(new List<BankAccount>
        {
            new BankAccount
            {
                Id = Guid.Parse("b2b2bc11-30dc-4288-984e-db75194d841d"),
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "123-456-7890",
                Balance = 1000.00m
            },
            new BankAccount
            {
                Id = Guid.Parse("734565e0-10d3-4db7-9700-dafb2e1e67d6"),
                FirstName = "Jane",
                LastName = "Smith",
                PhoneNumber = "987-654-3210",
                Balance = 1500.50m
            },
            new BankAccount
            {
                Id = Guid.Parse("a7fd9cfd-caa4-4f5d-9bc5-6a661d175797"),
                FirstName = "Alice",
                LastName = "Johnson",
                PhoneNumber = "555-555-5555",
                Balance = 200.75m
            },
            new BankAccount
            {
                Id = Guid.Parse("4e885bce-503f-4d1c-8f2d-9855594493d2"),
                FirstName = "Bob",
                LastName = "Brown",
                PhoneNumber = "777-888-9999",
                Balance = 2500.25m
            },
            new BankAccount
            {
                Id = Guid.Parse("32894ecc-d090-42c8-a1a9-1f9646ed28a5"),
                FirstName = "Eve",
                LastName = "White",
                PhoneNumber = "333-222-1111",
                Balance = 500.10m
            }
        });

            _perfectAppDbContext.SaveChanges();
        }

        [HttpGet("[action]/{bankAccountId:guid}")]
        public GetBankAccountDataResponseModel? GetBankAccountData(Guid bankAccountId)
        {
            BankAccount? bankAccount = _perfectAppDbContext.BankAccounts.FirstOrDefault(x => x.Id == bankAccountId);

            if (bankAccount is null)
            {
                return null;
            }

            return new GetBankAccountDataResponseModel()
            {
                FirstName = bankAccount.FirstName,
                LastName = bankAccount.LastName,
                Balance = bankAccount.Balance
            };
        }

        [HttpPost]
        public GetBankAccountDataResponseModel? CreateBankAccount(CreateBankAccountRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            Guid id = Guid.NewGuid();

            _perfectAppDbContext.BankAccounts.Add(new BankAccount()
            {
                Id = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Balance = request.Balance,
            });

            _perfectAppDbContext.SaveChanges();

            BankAccount bankAccount = _perfectAppDbContext.BankAccounts.FirstOrDefault(x => x.Id == id);
            return new GetBankAccountDataResponseModel()
            {
                FirstName = bankAccount.FirstName,
                LastName = bankAccount.LastName,
                Balance = bankAccount.Balance,

            };
        }
    }
}
