using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week_10_1.Infrastructure.Service;

namespace Week_10_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController()
        {
            
        }

        [HttpGet]
        public IActionResult Get(string name)
        {
            return Ok(ConfigurationService.GetInstance().GetValue(name));
        }
    }
}
