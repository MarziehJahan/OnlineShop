using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> roleManager;
        public RoleController(RoleManager<AppRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            //List<RoleViewModel> roleViews = new List<RoleViewModel>();
            //foreach (var item in roles)
            //{
            //    roleViews.Add(new RoleViewModel() { Name = item.Name });
            //}
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Index(RoleViewModel model)
        {
            AppRole appRole = new AppRole()
            {
                Name = model.Name
            };
            var result = roleManager.CreateAsync(appRole).Result;
            return View();
        }
    }
}
