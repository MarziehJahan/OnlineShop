using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TK.Infrastruture.Sql;

namespace PresentationHost.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserSignUp()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult UserSignUp(UserViewModel model)
        {
            if (userManager.Users.Any(a => a.UserName == model.Username))
            {
                ViewBag.message = "خطا !";
                ModelState.AddModelError("", "نام کاربری قبلا انتخاب شده است");
            }
            else
            {
                AppUser appUser = new AppUser()
                {
                    UserName = model.Username,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };
                var result = userManager
                    .CreateAsync(appUser, model.Password.ToString()).Result;

                if (result.Succeeded)
                {
                    var res = userManager.AddToRoleAsync(appUser, "User").Result;
                 
                    ViewBag.message = "ثبت نام با موفقیت انجام شد";
                }
                else
                {
                    ModelState.AddModelError("", "رمز عبور باید حداقل 6 کاراکتر داشته باشد");
                    ModelState.AddModelError("", "رمز عبور باید حداقل یک حرف بزرگ و یک حرف کوچک و یک عدد شامل شود");

                    ViewBag.message = "خطا !";
                }
            }
            return View(model);
        }
    }
}
