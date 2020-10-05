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
            return View();
        }



        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                _userService.Register(model);
                return RedirectToAction("About", "Home");

            }
            else
                return View(model);
        }



        [AllowAnonymous]
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        


        [AllowAnonymous]
        [HttpPost]
        public IActionResult LogIn(LoginViewModel model, string returnurl)
        {
            //check for role to redirect to otheer page. Authorize the role is the problem!
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
              //  if (_userService.CheckIfUserExists(model.Username))
                _userService.Login(model);

                if (!string.IsNullOrEmpty(returnurl) && Url.IsLocalUrl(returnurl))
                    return Redirect(returnurl);
            }

            return RedirectToAction("Index", "Home");


        }


        public async Task<IActionResult> LogOut()
        {
           await _userService.LogOut();
            return RedirectToAction("Index", "Home"); // ima problem, ne sake redirect da naprave na log in da naprave
        }

        
    }
}