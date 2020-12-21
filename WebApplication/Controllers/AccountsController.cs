using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using WebModels.ViewModels;

namespace WebApplication.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        private readonly IUserService _userService;

        public AccountsController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }



        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
               await _userService.Register(model);
                return RedirectToAction("About", "Home");

            }
            else
                return View(model);
        }



        [AllowAnonymous]
        [HttpGet]
        public IActionResult LogIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel model, string returnurl)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var result = await _userService.Login(model);      // if everything is valid, you  still stay on the login page like you are not logged
                if (result == true)
                {
                    if (!string.IsNullOrEmpty(returnurl) && Url.IsLocalUrl(returnurl))
                        return Redirect(returnurl);
                    else
                        return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "User and password do not match!");
                return View(model);
            }

        }


        public IActionResult LogOut()
        {
            _userService.LogOut();
            return RedirectToAction("Index", "Home"); // ima problem, ne sake redirect da naprave na log in da naprave
        }

        
    }
}