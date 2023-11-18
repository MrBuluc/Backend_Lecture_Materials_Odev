using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YetGenAkbankJump.Domain.Dtos;
using YetGenAkbankJump.Domain.Entities;
using YetGenAkbankJump.Persistence.Contexts;

namespace YetGenAkbankJump.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CategoriesController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CategoryAddDto categoryAddDto, CancellationToken cancellationToken)
        {
            if (categoryAddDto is null)
            {
                return BadRequest("Category's name cannot be null");
            }

            Category category = new()
            {
                Id = Guid.NewGuid(),
                Name = categoryAddDto.Name,
                CreatedByUserId = "Mr. Bülüç",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
            };

            await _applicationDbContext.Categories.AddAsync(category, cancellationToken);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Ok(category);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _applicationDbContext.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            return Ok(await _applicationDbContext.Categories.AsNoTracking().ToListAsync(cancellationToken));
        }
    }
}
