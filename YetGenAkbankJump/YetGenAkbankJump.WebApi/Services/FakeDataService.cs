using Bogus;
using YetGenAkbankJump.Domain.Entities;
using YetGenAkbankJump.Persistence.Contexts;

namespace YetGenAkbankJump.WebApi.Services
{
    public class FakeDataService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly Random _random;

        public FakeDataService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

            _random = new Random();
        }

        public async Task<int> GenerateStudentDataAsync(CancellationToken cancellationToken)
        {
            List<Student> students = new Faker<Student>("tr").RuleFor(s => s.Id, new Guid()).RuleFor(s => s.FirstName, f => f.Name.FirstName()).RuleFor(s => s.LastName, f => f.Name.LastName()).RuleFor(s => s.Country, f => f.Address.Country()).RuleFor(s => s.City, f => f.Address.City()).RuleFor(s => s.Company, f => f.Company.CompanyName()).RuleFor(s => s.Age, f => Convert.ToInt16(_random.Next(10, 59))).RuleFor(s => s.RegistrationFee, f => _random.Next(0, 9999)).RuleFor(s => s.CreatedOn, f => DateTimeOffset.UtcNow).RuleFor(s => s.CreatedByUserId, f => "Mr. Bülüç").Generate(10000);

            foreach (Student student in students)
            {
                student.Id = Guid.NewGuid();
            }

            await _applicationDbContext.Students.AddRangeAsync(students, cancellationToken);

            return await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
