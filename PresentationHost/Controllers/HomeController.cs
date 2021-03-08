using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationHost.Models;
using PresentationHost.SessionState;
using TK.Core.Contracts.Service;
using TK.Core.Entites;

namespace PresentationHost.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IProdctService productService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public HomeController(IProdctService productService
            ,IHttpContextAccessor httpContextAccessor)
        {
            this.productService = productService;
            this.httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            List<Product> prodcuts = productService.GetChippestProduct();
            var tmp = productService.GetChippestProduct();
            if (prodcuts.Count <= 3)
            {
                var All_Products = productService.GetProducts();
                if (All_Products.Count < 4)
                {
                    foreach (var item in tmp)
                    {
                        prodcuts.Remove(item);
                    }
                    foreach (var item in All_Products)
                    {
                        prodcuts.Add(item);
                    }
                }
                
            }

            SessionManager sessionManager = new SessionManager(httpContextAccessor);
            if (User.Identity.IsAuthenticated)
            {
                var session = sessionManager.GetLogInfo();
                if (string.IsNullOrEmpty(session) || session!=User.Identity.Name)
                {
                    sessionManager.SetLogInfo(User.Identity.Name);
                }
                ViewBag.name = sessionManager.GetLogInfo();
            }
            return View(prodcuts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
