using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using SCA.Models;

namespace SCA.Controllers
{
    public class AccountController : Controller
    {
        private List<UsuarioViewModel> TestUserStorage;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioViewModel userFromFore)
        {
            if (userFromFore.UserName.ToLower() == "admin" && userFromFore.Password == "12345678")
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, userFromFore.UserName) 
                };

                var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "SuperSecureLogin"));
                await HttpContext.Authentication.SignInAsync("Cookie", userPrincipal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,
                    AllowRefresh = false
                });

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrMsg = "UserName or Password is invalid";

                return View("Index");
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.Authentication.SignOutAsync("Cookie");

            return RedirectToAction("Index", "Home");
        }
    }
}