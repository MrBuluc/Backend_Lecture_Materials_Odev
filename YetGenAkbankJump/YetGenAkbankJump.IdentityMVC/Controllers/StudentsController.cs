using Microsoft.AspNetCore.Mvc;

namespace YetGenAkbankJump.IdentityMVC.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
