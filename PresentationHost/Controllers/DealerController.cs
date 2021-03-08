using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationHost.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TK.Core.Contracts.Service;
using TK.Core.Entites;
using TK.Infrastruture.Sql;

namespace PresentationHost.Controllers
{
    public class DealerController : Controller
    {
        private readonly IDealerService dealerService;
        private readonly IProdctService prodctService;
        private readonly ICategoryService categoryService;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public DealerController(IDealerService dealerService
            ,IProdctService prodctService,
            ICategoryService categoryService
            ,UserManager<AppUser> userManager
            ,SignInManager<AppUser> signInManager
          )
        {
            this.dealerService = dealerService;
            this.prodctService = prodctService;
            this.categoryService = categoryService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DealerSignUp()
        {
            return View();
        }
   
        [Authorize(Roles = "Seller")]
        public IActionResult DealerPage()
        {
            return View();
        }
        
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult AddProductByDealer(AddProductForDealerViewModel model)
        {
            //if (model.img == null || model.img.Length == 0)
            //    return Content("file not selected");
            var guid = Guid.NewGuid();
            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot", "Files", guid + ".png"
                        );

            using (var stream = new FileStream(path, FileMode.Create))
            {
               model.img.CopyToAsync(stream);
            }
            var cat = categoryService.GetCategory(model.CategoryName);
            Product product = new Product()
            {
                InseretTime = DateTime.Now,
                Description = model.Description,
                Name = model.ProductName,
                Price = model.Price,
                Medias = new List<Media>()
                {
                    new Media()
                    {
                        Path = $"Files/{guid}.png"
                    }
                }
            };
            if (cat==null)
            {
                Category category = new Category() { CategoryName = model.CategoryName };
                categoryService.AddCategory(category);
                product.Category = category;
            }
            else
            {
                product.Category = cat;
            }
            var name = User.Identity.Name;
            Dealer dealer = new Dealer()
            {
                Name = model.DealerName,
                Surname = model.DealerSurname,
                phoneNumber = model.phoneNumber
            };
            dealerService.AddDealer(dealer);
            prodctService.AddProduct(product);
            return RedirectToAction("Index", "Home");
        }
    }
}