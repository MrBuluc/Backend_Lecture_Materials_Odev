using Microsoft.AspNetCore.Mvc;
using YetGenAkbankJump.Shared.Utilities;
using YetGenAkbankJumpOOPConsole.Utilities;

namespace YetGenAkbankJump.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperPasswordsController : ControllerBase
    {
        private PasswordGenerator _passwordGenerator;
        private readonly RequestCountService _requestCountService;

        public SuperPasswordsController(PasswordGenerator passwordGenerator, RequestCountService requestCountService)
        {
            _passwordGenerator = passwordGenerator;
            _requestCountService = requestCountService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _requestCountService.Count++;
            return Ok(_passwordGenerator.Generate(12, true, true, true, true));
        }

        [HttpGet("GetCount")]
        public IActionResult GetCount()
        {
            _requestCountService.Count++;
            return Ok(_passwordGenerator.GeneratedPasswordsCount);
        }

        [HttpGet("GetRequestCount")]
        public IActionResult GetRequestCount()
        {
            _requestCountService.Count++;
            return Ok(_requestCountService.Count);
        }
    }
}
