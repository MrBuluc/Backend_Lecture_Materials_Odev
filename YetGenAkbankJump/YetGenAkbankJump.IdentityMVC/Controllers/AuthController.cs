﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Web;
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
            User user = new()
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
            };

            IdentityResult identityResult = await _userManager.CreateAsync(user, registerViewModel.Password);

            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);

                }

                return View(registerViewModel);
            }

            Console.WriteLine($"Verify Link: https://localhost:7046/Auth/VerifyEmail?email={user.Email}&token={HttpUtility.UrlEncode(await _userManager.GenerateEmailConfirmationTokenAsync(user))}");

            _toastNotification.AddSuccessToastMessage("You've successfully registered to the application.");

            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public async Task<IActionResult> VerifyEmailAsync(string email, string token)
        {
            User? user = await _userManager.FindByEmailAsync(email);

            if (user is not null)
            {
                IdentityResult identityResult = await _userManager.ConfirmEmailAsync(user, token);

                if (identityResult.Succeeded)
                {
                    _toastNotification.AddSuccessToastMessage("You've successsfully verified your email.");

                    return View();
                }

                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                _toastNotification.AddErrorToastMessage("We unfortunately couldn't verify your email.");

                return RedirectToAction(nameof(Login));
            }

            _toastNotification.AddErrorToastMessage("We unfortunately couldn't find your email.");

            return RedirectToAction(nameof(Login));
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
