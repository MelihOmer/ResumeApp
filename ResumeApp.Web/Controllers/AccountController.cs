using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ResumeApp.Core.Dtos.AppUserDtos;
using ResumeApp.Core.Entities.Identity;

namespace ResumeApp.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl)
        {

            return View(new AppUserLoginDto() { ReturnUrl = returnUrl});
        }
        [HttpPost]
        public async Task<IActionResult> Login(AppUserLoginDto loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDto.UserName,loginDto.Password,loginDto.RememberMe,false);
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(loginDto.ReturnUrl))
                {
                    return Redirect(loginDto.ReturnUrl);
                }
                return RedirectToAction("Index","Panel");
            }
            return View(loginDto);
            
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
