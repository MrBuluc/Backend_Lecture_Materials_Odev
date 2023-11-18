using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YetGenAkbankJump.Domain.Dtos;
using YetGenAkbankJump.Domain.Entities;
using YetGenAkbankJump.Persistence.Contexts;

namespace YetGenAkbankJump.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, cancellationToken));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            return Ok(await _context.Products.Include(x => x.ProductCategories).ThenInclude(x => x.Category).AsNoTracking().Select(x => new ProductDto()
            {
                Id = x.Id,
                CreatedOn = x.CreatedOn,
                Name = x.Name,
                Categories = x.ProductCategories.Select(x => new ProductGetAllCategoryDto()
                {
                    Id = x.Category.Id,
                    Name = x.Category.Name,
                }).ToList()
            }).ToListAsync(cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(ProductAddDto productAddDto, CancellationToken cancellationToken)
        {
            if (productAddDto is null || string.IsNullOrEmpty(productAddDto.Name))
            {
                return BadRequest();
            }

            List<ProductCategory> productCategories = new List<ProductCategory>();

            Guid id = Guid.NewGuid();

            if (productAddDto.CategoryIds is not null && productAddDto.CategoryIds.Any())
            {
                foreach (Guid categoryId in productAddDto.CategoryIds)
                {
                    productCategories.Add(new ProductCategory()
                    {
                        CategoryId = categoryId,
                        ProductId = id,
                        CreatedOn = DateTimeOffset.UtcNow,
                        CreatedByUserId = "Mr. Bülüç"
                    });
                }
            }

            Product product = new Product()
            {
                Id = id,
                Name = productAddDto.Name,
                CreatedByUserId = "Mr. Bülüç",
                CreatedOn = DateTimeOffset.UtcNow,
                IsDeleted = false,
                ProductCategories = productCategories
            };

            await _context.Products.AddAsync(product, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Ok(product);
        }
    }
}
