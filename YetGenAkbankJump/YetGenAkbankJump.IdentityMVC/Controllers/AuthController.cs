using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using YetGenAkbankJump.Domain.Identity;
using YetGenAkbankJump.IdentityMVC.ViewModels;

namespace YetGenAkbankJump.IdentityMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IToastNotification _toastNotification;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IToastNotification toastNotification)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _toastNotification = toastNotification;
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(Index), "Home");
            }

            return View(new AuthRegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(AuthRegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            Guid userId = Guid.NewGuid();

            IdentityResult identityResult = await _userManager.CreateAsync(new User()
            {
                Id = userId,
                Email = registerViewModel.Email,
                FirstName = registerViewModel.FirstName,
                Surname = registerViewModel.Surname,
                Gender = registerViewModel.Gender,
                BirthDate = registerViewModel.BirthDate.Value.ToUniversalTime(),
                UserName = registerViewModel.Username,
                CreatedOn = DateTimeOffset.UtcNow,
                CreatedByUserId = userId.ToString(),
            }, registerViewModel.Password);

            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);

                }

                return View(registerViewModel);
            }

            _toastNotification.AddSuccessToastMessage("You've successfully registered to the application.");

            return View(registerViewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new AuthLoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(AuthLoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            User? user = await _userManager.FindByEmailAsync(loginViewModel.Email);

            if (user is null)
            {
                _toastNotification.AddErrorToastMessage("Your email or password is incorrect.");

                return View(loginViewModel);
            }

            Microsoft.AspNetCore.Identity.SignInResult loginResult = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, true, false);

            if (!loginResult.Succeeded)
            {
                _toastNotification.AddErrorToastMessage("Your email or password is incorrect.");

                return View(loginViewModel);
            }

            _toastNotification.AddSuccessToastMessage($"Welcome {user.UserName}!");

            return RedirectToAction("Index", controllerName: "Students");
        }
    }
}
