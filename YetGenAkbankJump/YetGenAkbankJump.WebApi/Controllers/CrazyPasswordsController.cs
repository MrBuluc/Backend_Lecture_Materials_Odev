using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using YetGenAkbankJump.Shared.Helpers;
using YetGenAkbankJump.Shared.Services;
using YetGenAkbankJump.Shared.Utilities;
using YetGenAkbankJumpOOPConsole.Utilities;

namespace YetGenAkbankJump.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrazyPasswordsController : ControllerBase
    {
        private readonly PasswordGenerator _passwordGenerator;
        private readonly RequestCountService _requestCountService;
        private readonly IStringLocalizer<CommonTranslations> _localizer;
        private readonly ITextService _textService;
        private readonly IIPService _ipService;

        public CrazyPasswordsController(PasswordGenerator passwordGenerator, IStringLocalizer<CommonTranslations> localizer, ITextService textService, IIPService ipService, RequestCountService requestCountService)
        {
            _passwordGenerator = passwordGenerator;
            _localizer = localizer;
            _textService = textService;
            _ipService = ipService;
            _requestCountService = requestCountService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _requestCountService.Count++;

            _ipService.Ip = "91.93.226.142";

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
