using Microsoft.AspNetCore.Mvc;
using YetGenAkbankJump.MVCClient.Models;
using YetGenAkbankJumpOOPConsole.Utilities;

namespace YetGenAkbankJump.MVCClient.Controllers
{
    public class PasswordsController : Controller
    {
        private readonly PasswordGenerator passwordGenerator;

        public PasswordsController()
        {
            passwordGenerator = new PasswordGenerator();
        }

        [HttpGet]
        public IActionResult Index()
        {
            PasswordsIndexViewModel model = new()
            {
                Password = passwordGenerator.Generate(15, true, true, true, true)
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(PasswordsIndexViewModel model)
        {
            model.Password = passwordGenerator.Generate(model.PasswordLength, model.IncludeNumbers, true, true, true);

            return View(model);
        }
    }
}
