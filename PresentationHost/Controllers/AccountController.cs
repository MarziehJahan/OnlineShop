using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using PresentationHost.EmailSend;
using PresentationHost.Models;
using System.Threading.Tasks;
using TK.Infrastruture.Sql;

namespace PresentationHost.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager
            , SignInManager<AppUser> signInManager
            
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Login(string returnurl)
        {

            LoginViewModel viewModel = new LoginViewModel()
            {
                returnUrl = returnurl
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Login( string returnUrl =null,LoginViewModel model=null)
        {
            var user = await this.userManager.FindByNameAsync(model.username);
            if (user != null)
            {

                Microsoft.AspNetCore.Identity.SignInResult result = new Microsoft.AspNetCore.Identity.SignInResult();
                var passwordCheck = await signInManager.PasswordSignInAsync(user, model.password, false, false);
                if (passwordCheck.Succeeded)
                {
                    return Redirect(model.returnUrl ?? "/");
                }
                //if (passwordCheck.RequiresTwoFactor)
                //{
                //    return RedirectToAction("LoginTwoStep",
                //        new { model.Email, model.RememberMe, returnUrl });
                //}

            }
            ModelState.AddModelError("", "نام کاربری یا رمز عبور اشتباه است. لطفا مجددا تلاش کنید");

            return View(model);
          
        }
        public async Task<IActionResult> Signout()
        {
            await signInManager.SignOutAsync();
            return Redirect("/");
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> LoginTwoStep(string Email,bool RememberMe,string returnUrl=null)
        {
            var user = await userManager.FindByEmailAsync(Email);
            if (user==null)
            {
                ViewBag.Error = "کاربری یافت نشد. لطفا مجددا تلاش کنید";
                return View();
            }
            var providers = await userManager.GetValidTwoFactorProvidersAsync(user);
            if (!providers.Contains("Email"))
            {
                ViewBag.Error = "خطا! ";
                return View();
            }
            var token = await userManager.GenerateTwoFactorTokenAsync(user, "Email");
            EmailHelper emailHelper = new EmailHelper();
            bool emailResult = emailHelper.SendEmailTwoFactorCode(Email, token);
            
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> LoginTwoStep(TwoStepModel twoStepModel, string returnUrl = null)
        {
            return View();
        }

    }
}
