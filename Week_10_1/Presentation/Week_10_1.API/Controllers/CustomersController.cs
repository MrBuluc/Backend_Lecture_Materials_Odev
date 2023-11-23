using Microsoft.AspNetCore.Mvc;
using Week_10_1.Application;

namespace Week_10_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IConfigurationService _configurationService;

        public CustomersController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        [HttpGet]
        public IActionResult Get(string key)
        {
            return Ok(_configurationService.GetValue(key));
        }
    }
}
