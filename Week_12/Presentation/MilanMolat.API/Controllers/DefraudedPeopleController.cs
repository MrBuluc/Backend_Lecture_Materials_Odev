using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilanMolat.Application.Abstract.DefraudedPersonRepositories;
using MilanMolat.Domain.Entities;
using MilanMolat.Infrastructure.Context;

namespace MilanMolat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefraudedPeopleController : ControllerBase
    {
        private readonly IDefraudedPersonReadRepository _defraudedPersonReadRepository;
        private readonly MilanMolatDbContext _context;

        public DefraudedPeopleController(IDefraudedPersonReadRepository defraudedPersonReadRepository, MilanMolatDbContext context)
        {
            _defraudedPersonReadRepository = defraudedPersonReadRepository;
            _context = context;
        }

        [HttpGet("[action]")]
        public void CreateExampleInstancess()
        {
            List<DefraudedPerson> defraudedPeople = new()
            {
                new DefraudedPerson { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe" }, new DefraudedPerson { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith" }, new DefraudedPerson { Id = Guid.NewGuid(), FirstName = "Alice", LastName = "Johnson" }, new DefraudedPerson { Id = Guid.NewGuid(), FirstName = "Bob", LastName = "Brown" }, new DefraudedPerson { Id = Guid.NewGuid(), FirstName = "Charlie", LastName = "Davis" }
            };
            _context.DefraudedPeople.AddRange(defraudedPeople);
            _context.SaveChanges();

            Console.WriteLine(string.Join("\n", defraudedPeople.Select(x => x.Id).ToList()));
        }

        [HttpGet("[action]")]
        public string GetDefraudedPersonName(Guid id)
        {
            DefraudedPerson? defraudedPerson = _defraudedPersonReadRepository.GetById(id.ToString());
            return defraudedPerson is null ? "Couldn't Find" : defraudedPerson.FirstName;
        }
    }
}
