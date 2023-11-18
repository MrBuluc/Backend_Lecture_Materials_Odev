using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using YetGenAkbankJump.Domain.Entities;
using YetGenAkbankJump.Shared.Helpers;
using YetGenAkbankJump.WebApi.Data;

namespace YetGenAkbankJump.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IStringLocalizer<CommonTranslations> _localization;

        public CarsController(IStringLocalizer<CommonTranslations> localization)
        {
            _localization = localization;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(CarsContext.LuxuryCars.ToList());
        }

        [HttpGet("WelcomeMesssage")]
        public IActionResult WelcomeMessage()
        {
            return Ok(_localization[CommonTranslationKeys.WelcomeMessage]);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(_localization[CommonTranslationKeys.IdCannotBeNull]);
            }

            Car car = CarsContext.LuxuryCars.FirstOrDefault(x => x.Id == id);
            if (car is null)
            {
                return NotFound("The car requested with given id was not found. ");
            }
            return Ok(car);
        }
    }
}
