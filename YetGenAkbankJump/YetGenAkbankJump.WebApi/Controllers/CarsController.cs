using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YetGenAkbankJump.Domain.Entities;
using YetGenAkbankJump.WebApi.Data;

namespace YetGenAkbankJump.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(CarsContext.LuxuryCars.ToList());
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Id cannot be empty.");
            }

            Car car = CarsContext.LuxuryCars.FirstOrDefault(x => x.Id == id);
            if (car == null)
            {
                return NotFound("The car requested with given id was not found. ");
            }
            return Ok(car);
        }
    }
}
